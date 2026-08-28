namespace Fun.Css

open System
open System.Text


module Internal =
    type CombineKeyValue = delegate of StringBuilder -> StringBuilder

    /// Merge two togeter
    let inline (&&&) ([<InlineIfLambda>] comb1: CombineKeyValue) ([<InlineIfLambda>] comb2: CombineKeyValue) =
        CombineKeyValue(fun sb -> comb2.Invoke(comb1.Invoke(sb)))

    /// Append key value pair
    let inline (&>>) ([<InlineIfLambda>] comb: CombineKeyValue) (x: string, value: string) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append(x).Append(": ").Append(value).Append("; "))

    /// Rewrites every "key: value; " declaration produced by comb into
    /// "key: value !important; ". Declarations are always terminated by "; ",
    /// so a textual rewrite that inserts " !important" before each ";" is safe:
    /// the only ";" the operations emit are declaration terminators.
    let applyImportant (comb: CombineKeyValue) =
        CombineKeyValue(fun sb ->
            let inner = StringBuilder()
            comb.Invoke(inner) |> ignore
            let s = inner.ToString()

            let mutable i = 0
            let len = s.Length

            while i < len do
                if s.[i] = ';' then
                    sb.Append(" !important;") |> ignore
                else
                    sb.Append(s.[i]) |> ignore

                i <- i + 1

            sb)


    type Makers =
        static member inline mkPxWithKV(k: string, v: int) =
            CombineKeyValue(fun sb -> sb.Append(k).Append(": ").Append(v).Append("px; "))

        static member inline mkPxWithKV(k: string, v: float) =
            CombineKeyValue(fun sb -> sb.Append(k).Append(": ").Append(v).Append("px; "))

        static member inline mkWithKV(k: string, v: int) =
            CombineKeyValue(fun sb -> sb.Append(k).Append(": ").Append(v).Append("; "))

        static member inline mkWithKV(k: string, v: float) =
            CombineKeyValue(fun sb -> sb.Append(k).Append(": ").Append(v).Append("; "))


open Internal
open type Makers


type CssBuilder(?important: bool) =

    /// When true, every property emitted by the block is suffixed with " !important".
    /// Defaults to false.
    member val Important = defaultArg important false

    member inline _.Yield(_: unit) = CombineKeyValue(fun sb -> sb)
    member inline _.Yield([<InlineIfLambda>] x: CombineKeyValue) = x

    member inline _.Yield(keyValue: string) =
        CombineKeyValue(fun s -> s.Append(keyValue).Append("; "))

    member inline _.Yield((key, value): string * string) =
        CombineKeyValue(fun s -> s.Append(key).Append(": ").Append(value).Append("; "))

    member inline _.Yield((key, value): string * int) =
        CombineKeyValue(fun s -> s.Append(key).Append(": ").Append(value).Append("; "))

    member inline _.Yield((key, value): string * float) =
        CombineKeyValue(fun s -> s.Append(key).Append(": ").Append(value).Append("; "))

    member inline _.Yield((key, value): string * bool) =
        CombineKeyValue(fun s -> s.Append(key).Append(": ").Append(value).Append("; "))

    /// Applies the " !important" suffix to every declaration when Important is
    /// true; otherwise returns the combine unchanged. Subclasses that override
    /// Run should route the final combine through this so the important flag is
    /// honored regardless of the output type.
    member this.ApplyImportant(combine: CombineKeyValue) : CombineKeyValue =
        if this.Important then
            applyImportant combine
        else
            combine

    member inline this.Run([<InlineIfLambda>] combine: CombineKeyValue) = this.ApplyImportant(combine)

    member inline _.For([<InlineIfLambda>] comb: CombineKeyValue, [<InlineIfLambda>] fn: unit -> CombineKeyValue) =
        comb &&& (fn ())

    member inline _.For(ls: 'T seq, [<InlineIfLambda>] fn: 'T -> CombineKeyValue) =
        ls |> Seq.map fn |> Seq.fold (&&&) (CombineKeyValue(fun x -> x))

    member inline _.Delay([<InlineIfLambda>] fn: unit -> CombineKeyValue) =
        CombineKeyValue(fun x -> fn().Invoke(x))

    member inline _.Zero() = CombineKeyValue(fun sb -> sb)

    member inline _.Combine([<InlineIfLambda>] render1: CombineKeyValue, [<InlineIfLambda>] render2: CombineKeyValue) =
        render1 &&& render2


    /// Define a custom property
    [<CustomOperation("custom")>]
    member inline _.custom([<InlineIfLambda>] comb: CombineKeyValue, key: string, value: string) = comb &>> (key, value)


    /// Specifies the magnification scale of the element. The CSS zoom property scales the targeted element, which can affect the page layout.
    [<CustomOperation("zoom")>]
    member inline _.zoom([<InlineIfLambda>] comb: CombineKeyValue, x: float) = comb &&& mkWithKV ("zoom", x)

    /// Specifies that all the element's properties should be changed to their initial values.
    [<CustomOperation("allInitial")>]
    member inline _.allInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("all", "initial")

    /// Specifies that all the element's properties should be changed to their inherited values.
    [<CustomOperation("allInherit")>]
    member inline _.allInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("all", "inherit")

    /// Specifies that all the element's properties should be changed to their inherited values if they inherit by default, or to their initial values if not.
    [<CustomOperation("allUnset")>]
    member inline _.allUnset([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("all", "unset")

    /// Specifies behavior that depends on the stylesheet origin to which the declaration belongs:
    ///
    /// User-agent origin
    ///     Equivalent to unset.
    /// User origin
    ///     Rolls back the cascade to the user-agent level, so that the specified values are calculated as if no author-level or user-level rules were specified for the element.
    /// Author origin
    ///     Rolls back the cascade to the user level, so that the specified values are calculated as if no author-level rules were specified for the element. For purposes of revert, the Author origin includes the Override and Animation origins.
    [<CustomOperation("allRevert")>]
    member inline _.allRevert([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("all", "revert")



    // --------------------------------------------------------------------
    // Align styles
    // --------------------------------------------------------------------


    /// Default. The element inherits its parent container's align-items property, or "stretch" if it has no parent container.
    [<CustomOperation("alignSelfAuto")>]
    member inline _.alignSelfAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("align-self", "auto")

    /// The element is positioned to fit the container
    [<CustomOperation("alignSelfStretch")>]
    member inline _.alignSelfStretch([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("align-self", "stretch")

    /// The element is positioned at the center of the container
    [<CustomOperation("alignSelfCenter")>]
    member inline _.alignSelfCenter([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("align-self", "center")

    /// The element is positioned at the beginning of the container
    [<CustomOperation("alignSelfFlexStart")>]
    member inline _.alignSelfFlexStart([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("align-self", "flex-start")

    /// The element is positioned at the end of the container
    [<CustomOperation("alignSelfFlexEnd")>]
    member inline _.alignSelfFlexEnd([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("align-self", "flex-end")

    /// The element is positioned at the baseline of the container
    [<CustomOperation("alignSelfBaseline")>]
    member inline _.alignSelfBaseline([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("align-self", "baseline")

    /// Sets this property to its default value)
    [<CustomOperation("alignSelfInitial")>]
    member inline _.alignSelfInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("align-self", "initial")

    /// Inherits this property from its parent element
    [<CustomOperation("alignSelfInheritFromParent")>]
    member inline _.alignSelfInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("align-self", "inherit")

    /// Sets the alignment of the item inside its container using a CSS string value (e.g. "center", "var(--align-self)").
    [<CustomOperation("alignSelf")>]
    member inline _.alignSelf([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("align-self", value)

    /// Default. Items are stretched to fit the container
    [<CustomOperation("alignItemsStretch")>]
    member inline _.alignItemsStretch([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("align-items", "stretch")

    /// Items are positioned at the center of the container
    [<CustomOperation("alignItemsCenter")>]
    member inline _.alignItemsCenter([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("align-items", "center")

    /// Items are positioned at the beginning of the container
    [<CustomOperation("alignItemsFlexStart")>]
    member inline _.alignItemsFlexStart([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("align-items", "flex-start")

    /// Items are positioned at the end of the container
    [<CustomOperation("alignItemsFlexEnd")>]
    member inline _.alignItemsFlexEnd([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("align-items", "flex-end")

    /// Items are positioned at the baseline of the container
    [<CustomOperation("alignItemsBaseline")>]
    member inline _.alignItemsBaseline([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("align-items", "baseline")

    /// Sets this property to its default value)
    [<CustomOperation("alignItemsInitial")>]
    member inline _.alignItemsInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("align-items", "initial")

    /// Inherits this property from its parent element
    [<CustomOperation("alignItemsInheritFromParent")>]
    member inline _.alignItemsInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("align-items", "inherit")

    /// Sets the alignment of items inside the container using a CSS string value (e.g. "center", "var(--align-items)").
    [<CustomOperation("alignItems")>]
    member inline _.alignItems([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("align-items", value)

    /// Default value. Lines stretch to take up the remaining space.
    [<CustomOperation("alignContentStretch")>]
    member inline _.alignContentStretch([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("align-content", "stretch")

    /// Lines are packed toward the center of the flex container.
    [<CustomOperation("alignContentCenter")>]
    member inline _.alignContentCenter([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("align-content", "center")

    /// Lines are packed toward the start of the flex container.
    [<CustomOperation("alignContentFlexStart")>]
    member inline _.alignContentFlexStart([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("align-content", "flex-start")

    /// Lines are packed toward the end of the flex container.
    [<CustomOperation("alignContentFlexEnd")>]
    member inline _.alignContentFlexEnd([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("align-content", "flex-end")

    /// Lines are evenly distributed in the flex container.
    [<CustomOperation("alignContentSpaceBetween")>]
    member inline _.alignContentSpaceBetween([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("align-content", "space-between")

    /// Lines are evenly distributed in the flex container, with half-size spaces on either end.
    [<CustomOperation("alignContentSpaceAround")>]
    member inline _.alignContentSpaceAround([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("align-content", "space-around")

    /// Sets this property to its default value.
    [<CustomOperation("alignContentInitial")>]
    member inline _.alignContentInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("align-content", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("alignContentInheritFromParent")>]
    member inline _.alignContentInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("align-content", "inherit")

    /// Sets the alignment of lines inside the container using a CSS string value (e.g. "center", "var(--align-content)").
    [<CustomOperation("alignContent")>]
    member inline _.alignContent([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("align-content", value)

    /// The CSS justify-content property defines how the browser distributes space between and around content items along the main axis of a flex container and the inline axis of grid and multicol containers
    [<CustomOperation("justifyContent")>]
    member inline _.justifyContent([<InlineIfLambda>] comb: CombineKeyValue, x: string) =
        comb &>> ("justify-content", x)

    /// The items are packed flush to each other toward the start edge of the alignment container in the main axis.
    [<CustomOperation("justifyContentStart")>]
    member inline _.justifyContentStart([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-content", "start")

    /// The items are packed flush to each other toward the end edge of the alignment container in the main axis.
    [<CustomOperation("justifyContentEnd")>]
    member inline _.justifyContentEnd([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("justify-content", "end")

    /// The items are packed flush to each other toward the start edge of the alignment container on the flex container's main-start side. This only applies to flex layout items. For items that are not children of a flex container, this value is treated like start.
    [<CustomOperation("justifyContentFlexStart")>]
    member inline _.justifyContentFlexStart([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-content", "flex-start")

    /// The items are packed flush to each other at the end edge of the alignment container on the flex container's main-end side. This only applies to flex layout items. For items that are not children of a flex container, this value is treated like end.
    [<CustomOperation("justifyContentFlexEnd")>]
    member inline _.justifyContentFlexEnd([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-content", "flex-end")

    /// The items are packed flush to each other toward the center of the alignment container along the main axis.
    [<CustomOperation("justifyContentCenter")>]
    member inline _.justifyContentCenter([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-content", "center")

    /// The items are packed flush to each other toward the left edge of the alignment container. When the property's horizontal axis is not parallel with the inline axis, such as when flex-direction: column; is set, this value behaves like start.
    [<CustomOperation("justifyContentLeft")>]
    member inline _.justifyContentLeft([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("justify-content", "left")

    /// The items are packed flush to each other toward the right edge of the alignment container in the appropriate axis. If the property's axis is not parallel with the inline axis (in a grid container) or the main-axis (in a flexbox container), this value behaves like start.
    [<CustomOperation("justifyContentRight")>]
    member inline _.justifyContentRight([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-content", "right")

    /// Behaves as stretch, except in the case of multi-column containers with a non-auto column-width, in which case the columns take their specified column-width rather than stretching to fill the container. As stretch behaves as start in flex containers, normal also behaves as start.
    [<CustomOperation("justifyContentNormal")>]
    member inline _.justifyContentNormal([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-content", "normal")

    /// The items are evenly distributed within the alignment container along the main axis. The spacing between each pair of adjacent items is the same. The first item is flush with the main-start edge, and the last item is flush with the main-end edge.
    [<CustomOperation("justifyContentSpaceBetween")>]
    member inline _.justifyContentSpaceBetween([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-content", "space-between")

    /// The items are evenly distributed within the alignment container along the main axis. The spacing between each pair of adjacent items is the same. The empty space before the first and after the last item equals half of the space between each pair of adjacent items. If there is only one item, it will be centered.
    [<CustomOperation("justifyContentSpaceAround")>]
    member inline _.justifyContentSpaceAround([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-content", "space-around")

    /// The items are evenly distributed within the alignment container along the main axis. The spacing between each pair of adjacent items, the main-start edge and the first item, and the main-end edge and the last item, are all exactly the same.
    [<CustomOperation("justifyContentSpaceEvenly")>]
    member inline _.justifyContentSpaceEvenly([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-content", "space-evenly")

    /// If the combined size of the items along the main axis is less than the size of the alignment container, any auto-sized items have their size increased equally (not proportionally), while still respecting the constraints imposed by max-height/max-width (or equivalent functionality), so that the combined size exactly fills the alignment container along the main axis.
    [<CustomOperation("justifyContentStretch")>]
    member inline _.justifyContentStretch([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-content", "stretch")

    /// Sets this property to its default value.
    [<CustomOperation("justifyContentInitial")>]
    member inline _.justifyContentInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-content", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("justifyContentInheritFromParent")>]
    member inline _.justifyContentInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-content", "inherit")

    /// The CSS justify-items property defines the default justify-self for all items of the box, giving them all a default way of justifying each box along the appropriate axis.
    [<CustomOperation("justifyItems")>]
    member inline _.justifyItems([<InlineIfLambda>] comb: CombineKeyValue, x: string) = comb &>> ("justify-items", x)

    /// The effect of this keyword is dependent of the layout mode we are in:
    /// In block-level layouts, the keyword is a synonym of start.
    /// In absolutely-positioned layouts, the keyword behaved like start on replaced absolutely-positioned boxes, and as stretch on all other absolutely-positioned boxes.
    /// In table cell layouts, this keyword has no meaning as this property is ignored.
    /// In flexbox layouts, this keyword has no meaning as this property is ignored.
    /// In grid layouts, this keyword leads to a behavior similar to the one of stretch, except for boxes with an aspect ratio or an intrinsic size where it behaves like start.
    [<CustomOperation("justifyItemsNormal")>]
    member inline _.justifyItemsNormal([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("justify-items", "normal")

    /// The item is packed flush to each other toward the start edge of the alignment container in the appropriate axis
    [<CustomOperation("justifyItemsStart")>]
    member inline _.justifyItemsStart([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("justify-items", "start")

    /// The item is packed flush to each other toward the end edge of the alignment container in the appropriate axis.
    [<CustomOperation("justifyItemsEnd")>]
    member inline _.justifyItemsEnd([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("justify-items", "end")

    /// For items that are not children of a flex container, this value is treated like start.
    [<CustomOperation("justifyItemsFlexStart")>]
    member inline _.justifyItemsFlexStart([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-items", "flex-start")

    /// For items that are not children of a flex container, this value is treated like end.
    [<CustomOperation("justifyItemsFlexEnd")>]
    member inline _.justifyItemsFlexEnd([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-items", "flex-end")

    /// The item is packed flush to the edge of the alignment container of the start side of the item, in the appropriate axis.
    [<CustomOperation("justifyItemsSelfStart")>]
    member inline _.justifyItemsSelfStart([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-items", "self-start")

    /// The item is packed flush to the edge of the alignment container of the end side of the item, in the appropriate axis.
    [<CustomOperation("justifyItemsSelfEnd")>]
    member inline _.justifyItemsSelfEnd([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-items", "self-end")

    /// The items are packed flush to each other toward the center of the alignment container.
    [<CustomOperation("justifyItemsCenter")>]
    member inline _.justifyItemsCenter([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("justify-items", "center")

    /// The items are packed flush to each other toward the left edge of the alignment container. If the property's axis is not parallel with the inline axis, this value behaves like start.
    [<CustomOperation("justifyItemsLeft")>]
    member inline _.justifyItemsLeft([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("justify-items", "left")

    /// The items are packed flush to each other toward the right edge of the alignment container in the appropriate axis. If the property's axis is not parallel with the inline axis, this value behaves like start.
    [<CustomOperation("justifyItemsRight")>]
    member inline _.justifyItemsRight([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("justify-items", "right")

    /// Specifies participation in first- or last-baseline alignment: aligns the alignment baseline of the box's first or last baseline set with the corresponding baseline in the shared first or last baseline set of all the boxes in its baseline-sharing group. The fallback alignment for first baseline is start, the one for last baseline is end.
    [<CustomOperation("justifyItemsBaseline")>]
    member inline _.justifyItemsBaseline([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-items", "baseline")

    ///If the combined size of the items is less than the size of the alignment container, any auto-sized items have their size increased equally (not proportionally), while still respecting the constraints imposed by max-height/max-width (or equivalent functionality), so that the combined size exactly fills the alignment container.
    [<Obsolete("Use justifyItemsStretch instead (typo in the old name)")>]
    [<CustomOperation("justifyItemsStrench")>]
    member inline _.justifyItemsStrench([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-items", "stretch")

    /// The items are stretched to fill the container.
    [<CustomOperation("justifyItemsStretch")>]
    member inline _.justifyItemsStretch([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-items", "stretch")

    /// In the case of anchor-positioned elements, aligns the items to the center of the associated anchor element in the inline direction. See Centering on the anchor using anchor-center.
    [<CustomOperation("justifyItemsAnchorCenter")>]
    member inline _.justifyItemsAnchorCenter([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-items", "anchor-center")

    /// The CSS justify-self property sets the way a box is justified inside its alignment container along the appropriate axis.
    [<CustomOperation("justifySelf")>]
    member inline _.justifySelf([<InlineIfLambda>] comb: CombineKeyValue, x: string) = comb &>> ("justify-self", x)

    /// The effect of this keyword is dependent of the layout mode we are in:
    /// In block-level layouts, the keyword is a synonym of start.
    /// In absolutely-positioned layouts, the keyword behaves like start on replaced absolutely-positioned boxes, and as stretch on all other absolutely-positioned boxes.
    /// In table cell layouts, this keyword has no meaning as this property is ignored.
    /// In flexbox layouts, this keyword has no meaning as this property is ignored.
    /// In grid layouts, this keyword leads to a behavior similar to the one of stretch, except for boxes with an aspect ratio or an intrinsic size where it behaves like start.
    [<CustomOperation("justifySelfNormal")>]
    member inline _.justifySelfNormal([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("justify-self", "normal")

    /// The item is packed flush to each other toward the start edge of the alignment container in the appropriate axis.
    [<CustomOperation("justifySelfStart")>]
    member inline _.justifySelfStart([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("justify-self", "start")

    /// The item is packed flush to each other toward the end edge of the alignment container in the appropriate axis.
    [<CustomOperation("justifySelfEnd")>]
    member inline _.justifySelfEnd([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("justify-self", "end")

    /// For items that are not children of a flex container, this value is treated like start.
    [<CustomOperation("justifySelfFlexStart")>]
    member inline _.justifySelfFlexStart([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-self", "flex-start")

    /// For items that are not children of a flex container, this value is treated like end.
    [<CustomOperation("justifySelfFlexEnd")>]
    member inline _.justifySelfFlexEnd([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("justify-self", "flex-end")

    /// The item is packed flush to the edge of the alignment container of the start side of the item, in the appropriate axis.
    [<CustomOperation("justifySelfSelfStart")>]
    member inline _.justifySelfSelfStart([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-self", "self-start")

    /// The item is packed flush to the edge of the alignment container of the end side of the item, in the appropriate axis.
    [<CustomOperation("justifySelfSelfEnd")>]
    member inline _.justifySelfSelfEnd([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("justify-self", "self-end")

    /// The items are packed flush to each other toward the center of the alignment container.
    [<CustomOperation("justifySelfCenter")>]
    member inline _.justifySelfCenter([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("justify-self", "center")

    /// The items are packed flush to each other toward the left edge of the alignment container. If the property's axis is not parallel with the inline axis, this value behaves like start.
    [<CustomOperation("justifySelfLeft")>]
    member inline _.justifySelfLeft([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("justify-self", "left")

    /// The items are packed flush to each other toward the right edge of the alignment container in the appropriate axis. If the property's axis is not parallel with the inline axis, this value behaves like start.
    [<CustomOperation("justifySelfRight")>]
    member inline _.justifySelfRight([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("justify-self", "right")

    /// Specifies participation in first- or last-baseline alignment: aligns the alignment baseline of the box's first or last baseline set with the corresponding baseline in the shared first or last baseline set of all the boxes in its baseline-sharing group. The fallback alignment for first baseline is start, the one for last baseline is end.
    [<CustomOperation("justifySelfBaseline")>]
    member inline _.justifySelfBaseline([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-self", "baseline")

    /// If the combined size of the items is less than the size of the alignment container, any auto-sized items have their size increased equally (not proportionally), while still respecting the constraints imposed by max-height/max-width (or equivalent functionality), so that the combined size exactly fills the alignment container.
    [<Obsolete("Use justifySelfStretch instead (typo in the old name)")>]
    [<CustomOperation("justifySelfStrench")>]
    member inline _.justifySelfStrench([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("justify-self", "stretch")

    /// The item is stretched to fill the container.
    [<CustomOperation("justifySelfStretch")>]
    member inline _.justifySelfStretch([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("justify-self", "stretch")

    /// In the case of anchor-positioned elements, aligns the item to the center of the associated anchor element in the inline direction. See Centering on the anchor using anchor-center.
    [<CustomOperation("justifySelfAnchorCenter")>]
    member inline _.justifySelfAnchorCenter([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("justify-self", "anchor-center")




    // --------------------------------------------------------------------
    // Animation styles
    // --------------------------------------------------------------------


    /// Specifies a shorthand for all the animation properties. Accepts a CSS animation string (e.g. "slidein 3s ease-in 1s infinite reverse both paused").
    [<CustomOperation("animation")>]
    member inline _.animation([<InlineIfLambda>] comb: CombineKeyValue, x: string) = comb &>> ("animation", x)

    /// Default value. Specifies a animation effect with a slow start, then fast, then end slowly (equivalent to cubic-bezier(0.25,0.1,0.25,1)).
    [<CustomOperation("animationTimingFunctionEase")>]
    member inline _.animationTimingFunctionEase([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-timing-function", "ease")

    /// Specifies a animation effect with the same speed from start to end (equivalent to cubic-bezier(0,0,1,1)))
    [<CustomOperation("animationTimingFunctionLinear")>]
    member inline _.animationTimingFunctionLinear([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-timing-function", "linear")

    /// Specifies a animation effect with a slow start (equivalent to cubic-bezier(0.42,0,1,1)).
    [<CustomOperation("animationTimingFunctionEaseIn")>]
    member inline _.animationTimingFunctionEaseIn([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-timing-function", "ease-in")

    /// Specifies a animation effect with a slow end (equivalent to cubic-bezier(0,0,0.58,1)).
    [<CustomOperation("animationTimingFunctionEaseOut")>]
    member inline _.animationTimingFunctionEaseOut([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-timing-function", "ease-out")

    /// Specifies a animation effect with a slow start and end (equivalent to cubic-bezier(0.42,0,0.58,1)))
    [<CustomOperation("animationTimingFunctionEaseInOut")>]
    member inline _.animationTimingFunctionEaseInOut([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-timing-function", "ease-in-out")

    /// Define your own values in the cubic-bezier function. Possible values are numeric values from 0 to 1
    [<CustomOperation("animationTimingFunctionCubicBezier")>]
    member inline _.animationTimingFunctionCubicBezier
        ([<InlineIfLambda>] comb: CombineKeyValue, n1: float, n2: float, n3: float, n4: float)
        =
        CombineKeyValue(fun sb ->
            comb
                .Invoke(sb)
                .Append("animation-timing-function: ")
                .Append("cubic-bezier(")
                .Append(n1)
                .Append(",")
                .Append(n2)
                .Append(",")
                .Append(n3)
                .Append(",")
                .Append(n4)
                .Append("); "))

    /// Sets this property to its default value)
    [<CustomOperation("animationTimingFunctionInitial")>]
    member inline _.animationTimingFunctionInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-timing-function", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("animationTimingFunctionInheritFromParent")>]
    member inline _.animationTimingFunctionInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-timing-function", "inherit")

    /// Sets the animation timing function using a CSS string value (e.g. "ease-in", "cubic-bezier(0.1,0.7,1,0.1)", "var(--animation-timing)").
    [<CustomOperation("animationTimingFunction")>]
    member inline _.animationTimingFunction([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("animation-timing-function", value)

    /// Default value. The animation should be played as normal
    [<CustomOperation("animationDirectionNormal")>]
    member inline _.animationDirectionNormal([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-direction", "normal")

    /// The animation should play in reverse direction
    [<CustomOperation("animationDirectionReverse")>]
    member inline _.animationDirectionReverse([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-direction", "reverse")

    /// The animation will be played as normal every odd time (1, 3, 5, etc..) and in reverse direction every even time (2, 4, 6, etc...).
    [<CustomOperation("animationDirectionAlternate")>]
    member inline _.animationDirectionAlternate([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-direction", "alternate")

    /// The animation will be played in reverse direction every odd time (1, 3, 5, etc..) and in a normal direction every even time (2,4,6,etc...))
    [<CustomOperation("animationDirectionAlternateReverse")>]
    member inline _.animationDirectionAlternateReverse([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-direction", "alternate-reverse")

    /// Sets this property to its default value)
    [<CustomOperation("animationDirectionInitial")>]
    member inline _.animationDirectionInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-direction", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("animationDirectionInheritFromParent")>]
    member inline _.animationDirectionInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-direction", "inherit")

    /// Sets the animation direction using a CSS string value (e.g. "alternate", "var(--animation-direction)").
    [<CustomOperation("animationDirection")>]
    member inline _.animationDirection([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("animation-direction", value)

    /// Default value. Specifies that the animation is running.
    [<CustomOperation("animationPlayStateRunning")>]
    member inline _.animationPlayStateRunning([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-play-state", "running")

    /// Specifies that the animation is paused
    [<CustomOperation("animationPlayStatePaused")>]
    member inline _.animationPlayStatePaused([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-play-state", "paused")

    /// Sets this property to its default value)
    [<CustomOperation("animationPlayStateInitial")>]
    member inline _.animationPlayStateInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-play-state", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("animationPlayStateInheritFromParent")>]
    member inline _.animationPlayStateInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-play-state", "inherit")

    /// Sets whether the animation is running using a CSS string value (e.g. "paused", "var(--animation-play-state)").
    [<CustomOperation("animationPlayState")>]
    member inline _.animationPlayState([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("animation-play-state", value)

    /// Specifies that the animation should be played infinite times (forever))
    [<CustomOperation("animationIterationCountInfinite")>]
    member inline _.animationIterationCountInfinite([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-iteration-count", "infinite")

    /// Sets this property to its default value)
    [<CustomOperation("animationIterationCountInitial")>]
    member inline _.animationIterationCountInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-iteration-count", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("animationIterationCountInheritFromParent")>]
    member inline _.animationIterationCountInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-iteration-count", "inherit")

    /// Sets the number of times the animation runs using a CSS string value (e.g. "infinite", "var(--animation-count)").
    [<CustomOperation("animationIterationCount")>]
    member inline _.animationIterationCount([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("animation-iteration-count", value)

    /// Default value. Animation will not apply any styles to the element before or after it is executing
    [<CustomOperation("animationFillModeNone")>]
    member inline _.animationFillModeNone([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-fill-mode", "none")

    /// The element will retain the style values that is set by the last keyframe (depends on animation-direction and animation-iteration-count).
    [<CustomOperation("animationFillModeForwards")>]
    member inline _.animationFillModeForwards([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-fill-mode", "forwards")

    /// The element will get the style values that is set by the first keyframe (depends on animation-direction), and retain this during the animation-delay period
    [<CustomOperation("animationFillModeBackwards")>]
    member inline _.animationFillModeBackwards([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-fill-mode", "backwards")

    /// The animation will follow the rules for both forwards and backwards, extending the animation properties in both directions
    [<CustomOperation("animationFillModeBoth")>]
    member inline _.animationFillModeBoth([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-fill-mode", "both")

    /// Sets this property to its default value)
    [<CustomOperation("animationFillModeInitial")>]
    member inline _.animationFillModeInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-fill-mode", "initial")

    /// Inherits this property from its parent element
    [<CustomOperation("animationFillModeInheritFromParent")>]
    member inline _.animationFillModeInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("animation-fill-mode", "inherit")

    /// Sets the animation fill mode using a CSS string value (e.g. "both", "var(--animation-fill-mode)").
    [<CustomOperation("animationFillMode")>]
    member inline _.animationFillMode([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("animation-fill-mode", value)

    /// Sets one or more animations to apply to an element. Each name is an @keyframes at-rule that
    /// sets the property values for the animation sequence.
    [<CustomOperation("animationName")>]
    member inline _.animationName([<InlineIfLambda>] comb: CombineKeyValue, keyframeName: string) =
        comb &>> ("animation-name", keyframeName)

    /// Sets the length of time that an animation takes to complete one cycle.
    [<CustomOperation("animationDuration")>]
    member inline _.animationDuration([<InlineIfLambda>] comb: CombineKeyValue, timespan: TimeSpan) =
        comb &>> ("animation-duration", string timespan.TotalMilliseconds + "ms")

    /// Sets the length of time that an animation takes to complete one cycle.
    [<CustomOperation("animationDuration")>]
    member inline _.animationDuration([<InlineIfLambda>] comb: CombineKeyValue, seconds: int) =
        comb &>> ("animation-duration", string seconds + "s")

    /// Sets when an animation starts.
    ///
    /// The animation can start later, immediately from its beginning, or immediately and partway through the animation.
    [<CustomOperation("animationDelay")>]
    member inline _.animationDelay([<InlineIfLambda>] comb: CombineKeyValue, timespan: TimeSpan) =
        comb &>> ("animation-delay", string timespan.TotalMilliseconds + "ms")

    /// Sets when an animation starts.
    ///
    /// The animation can start later, immediately from its beginning, or immediately and partway through the animation.
    [<CustomOperation("animationDelay")>]
    member inline _.animationDelay([<InlineIfLambda>] comb: CombineKeyValue, seconds: int) =
        comb &>> ("animation-delay", string seconds + "s")

    /// The number of times the animation runs.
    [<Obsolete("Use animationIterationCount instead - this operation emitted the non-existent 'animation-duration-count' property")>]
    [<CustomOperation("animationDurationCount")>]
    member inline _.animationDurationCount([<InlineIfLambda>] comb: CombineKeyValue, count: int) =
        comb &&& mkWithKV ("animation-iteration-count", count)

    /// The number of times the animation runs.
    [<CustomOperation("animationIterationCount")>]
    member inline _.animationIterationCount([<InlineIfLambda>] comb: CombineKeyValue, count: int) =
        comb &&& mkWithKV ("animation-iteration-count", count)




    // --------------------------------------------------------------------
    // Background styles
    // --------------------------------------------------------------------


    /// Attaches one or more shadows to an element. Accepts a CSS box-shadow string (e.g. "2px 4px 8px rgba(0,0,0,0.2)"; multiple shadows can be separated by commas).
    [<CustomOperation("boxShadow")>]
    member inline _.boxShadow([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("box-shadow", value)

    /// Attaches a shadow with the given horizontal and vertical offsets (in pixels) and color.
    [<CustomOperation("boxShadow")>]
    member inline _.boxShadow
        ([<InlineIfLambda>] comb: CombineKeyValue, horizontalOffset: int, verticalOffset: int, color: string)
        =
        CombineKeyValue(fun sb ->
            comb
                .Invoke(sb)
                .Append("box-shadow: ")
                .Append(horizontalOffset)
                .Append("px ")
                .Append(verticalOffset)
                .Append("px ")
                .Append(color)
                .Append("; "))

    /// Attaches a shadow with the given horizontal offset, vertical offset, and blur radius (all in pixels), plus a color.
    [<CustomOperation("boxShadow")>]
    member inline _.boxShadow
        ([<InlineIfLambda>] comb: CombineKeyValue, horizontalOffset: int, verticalOffset: int, blur: int, color: string)
        =
        CombineKeyValue(fun sb ->
            comb
                .Invoke(sb)
                .Append("box-shadow: ")
                .Append(horizontalOffset)
                .Append("px ")
                .Append(verticalOffset)
                .Append("px ")
                .Append(blur)
                .Append("px ")
                .Append(color)
                .Append("; "))

    /// Attaches a shadow with the given horizontal offset, vertical offset, blur radius, and spread radius (all in pixels), plus a color.
    [<CustomOperation("boxShadow")>]
    member inline _.boxShadow
        (
            [<InlineIfLambda>] comb: CombineKeyValue,
            horizontalOffset: int,
            verticalOffset: int,
            blur: int,
            spread: int,
            color: string
        ) =
        CombineKeyValue(fun sb ->
            comb
                .Invoke(sb)
                .Append("box-shadow: ")
                .Append(horizontalOffset)
                .Append("px ")
                .Append(verticalOffset)
                .Append("px ")
                .Append(blur)
                .Append("px ")
                .Append(spread)
                .Append("px ")
                .Append(color)
                .Append("; "))

    /// Removes the box shadow from an element.
    [<CustomOperation("boxShadowNone")>]
    member inline _.boxShadowNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("box-shadow", "none")

    /// Inherits this property from its parent element.
    [<CustomOperation("boxShadowInheritFromParent")>]
    member inline _.boxShadowInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("box-shadow", "inherit")

    /// Sets the size of the element's background image.
    ///
    /// The image can be left to its natural size, stretched, or constrained to fit the available space.
    [<CustomOperation("backgroundSize")>]
    member inline _.backgroundSize([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("background-size", value)

    /// Sets the size of the element's background image (in pixels).
    ///
    /// The image can be left to its natural size, stretched, or constrained to fit the available space.
    [<CustomOperation("backgroundSize")>]
    member inline _.backgroundSize([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("background-size", value)

    /// Sets the size of the element's background image (in pixels).
    ///
    /// The image can be left to its natural size, stretched, or constrained to fit the available space.
    [<CustomOperation("backgroundSize")>]
    member inline _.backgroundSize([<InlineIfLambda>] comb: CombineKeyValue, value: float) =
        comb &&& mkPxWithKV ("background-size", value)

    /// Sets the size of the element's background image.
    ///
    /// The image can be left to its natural size, stretched, or constrained to fit the available space.
    [<CustomOperation("backgroundSize")>]
    member inline _.backgroundSize([<InlineIfLambda>] comb: CombineKeyValue, width: string, height: string) =
        comb
        &&& CombineKeyValue(fun sb ->
            sb.Append("background-size: ").Append(width).Append(" ").Append(height).Append("; "))

    /// Default value. The background image is displayed in its original size
    ///
    /// See [example here](https://www.w3schools.com/cssref/playit.asp?filename=playcss_background-size&preval=auto))
    [<CustomOperation("backgroundSizeAuto")>]
    member inline _.backgroundSizeAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("background-size", "auto")

    /// Resize the background image to cover the entire container, even if it has to stretch the image or cut a little bit off one of the edges.
    ///
    /// See [example here](https://www.w3schools.com/cssref/playit.asp?filename=playcss_background-size&preval=cover))
    [<CustomOperation("backgroundSizeCover")>]
    member inline _.backgroundSizeCover([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-size", "cover")

    /// Resize the background image to make sure the image is fully visible
    ///
    /// See [example here](https://www.w3schools.com/cssref/playit.asp?filename=playcss_background-size&preval=contain))
    [<CustomOperation("backgroundSizeContain")>]
    member inline _.backgroundSizeContain([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-size", "contain")

    /// Sets this property to its default value.
    [<CustomOperation("backgroundSizeInitial")>]
    member inline _.backgroundSizeInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-size", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("backgroundSizeInheritFromParent")>]
    member inline _.backgroundSizeInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-size", "inherit")

    /// Sets the initial position for each background image.
    ///
    /// The position is relative to the position layer set by background-origin.
    [<CustomOperation("backgroundPosition")>]
    member inline _.backgroundPosition([<InlineIfLambda>] comb: CombineKeyValue, position: string) =
        comb &>> ("background-position", position)

    /// The background image will scroll with the page. This is default.
    [<CustomOperation("backgroundPositionScroll")>]
    member inline _.backgroundPositionScroll([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-position", "scroll")

    /// The background image will not scroll with the page.
    [<CustomOperation("backgroundPositionFixedNoScroll")>]
    member inline _.backgroundPositionFixedNoScroll([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-position", "fixed")

    /// The background image will scroll with the element's contents.
    [<CustomOperation("backgroundPositionLocal")>]
    member inline _.backgroundPositionLocal([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-position", "local")

    /// Sets this property to its default value.
    [<CustomOperation("backgroundPositionInitial")>]
    member inline _.backgroundPositionInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-position", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("backgroundPositionInheritFromParent")>]
    member inline _.backgroundPositionInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-position", "inherit")

    /// This is default. Sets the blending mode to normal.
    [<CustomOperation("backgroundBlendModeNormal")>]
    member inline _.backgroundBlendModeNormal([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-blend-mode", "normal")

    /// Sets the blending mode to screen
    [<CustomOperation("backgroundBlendModeScreen")>]
    member inline _.backgroundBlendModeScreen([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-blend-mode", "screen")

    /// Sets the blending mode to overlay
    [<CustomOperation("backgroundBlendModeOverlay")>]
    member inline _.backgroundBlendModeOverlay([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-blend-mode", "overlay")

    /// Sets the blending mode to darken
    [<CustomOperation("backgroundBlendModeDarken")>]
    member inline _.backgroundBlendModeDarken([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-blend-mode", "darken")

    /// Sets the blending mode to multiply
    [<CustomOperation("backgroundBlendModeLighten")>]
    member inline _.backgroundBlendModeLighten([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-blend-mode", "lighten")

    /// Sets the blending mode to color-dodge
    [<Obsolete("Use backgroundBlendModeColorDodge instead (typo in the old name)")>]
    [<CustomOperation("backgroundBlendModeCollorDodge")>]
    member inline _.backgroundBlendModeCollorDodge([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-blend-mode", "color-dodge")

    /// Sets the blending mode to color-dodge
    [<CustomOperation("backgroundBlendModeColorDodge")>]
    member inline _.backgroundBlendModeColorDodge([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-blend-mode", "color-dodge")

    /// Sets the blending mode to saturation
    [<CustomOperation("backgroundBlendModeSaturation")>]
    member inline _.backgroundBlendModeSaturation([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-blend-mode", "saturation")

    /// Sets the blending mode to color
    [<CustomOperation("backgroundBlendModeColor")>]
    member inline _.backgroundBlendModeColor([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-blend-mode", "color")

    /// Sets the blending mode to luminosity
    [<CustomOperation("backgroundBlendModeLuminosity")>]
    member inline _.backgroundBlendModeLuminosity([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-blend-mode", "luminosity")

    /// Sets the background blending mode using a CSS string value (e.g. "multiply", "var(--background-blend-mode)").
    [<CustomOperation("backgroundBlendMode")>]
    member inline _.backgroundBlendMode([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("background-blend-mode", value)

    /// Default value. The background extends behind the border.
    [<CustomOperation("backgroundClipBorderBox")>]
    member inline _.backgroundClipBorderBox([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-clip", "border-box")

    /// The background extends to the inside edge of the border.
    [<CustomOperation("backgroundClipPaddingBox")>]
    member inline _.backgroundClipPaddingBox([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-clip", "padding-box")

    /// The background extends to the edge of the content box.
    [<CustomOperation("backgroundClipContentBox")>]
    member inline _.backgroundClipContentBox([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-clip", "content-box")

    /// Sets this property to its default value.
    [<CustomOperation("backgroundClipInitial")>]
    member inline _.backgroundClipInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-clip", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("backgroundClipInheritFromParent")>]
    member inline _.backgroundClipInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-clip", "inherit")

    /// Sets how far the background extends using a CSS string value (e.g. "padding-box", "var(--background-clip)").
    [<CustomOperation("backgroundClip")>]
    member inline _.backgroundClip([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("background-clip", value)

    /// Sets how background images are repeated.
    ///
    /// A background image can be repeated along the horizontal and vertical axes, or not repeated at all.
    [<CustomOperation("backgroundRepeat")>]
    member inline _.backgroundRepeat([<InlineIfLambda>] comb: CombineKeyValue, repeat: string) =
        comb &>> ("background-repeat", repeat)

    /// The background image is repeated both vertically and horizontally. This is default.
    [<CustomOperation("backgroundRepeatRepeat")>]
    member inline _.backgroundRepeatRepeat([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-repeat", "repeat")

    /// The background image is only repeated horizontally.
    [<CustomOperation("backgroundRepeatRepeatX")>]
    member inline _.backgroundRepeatRepeatX([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-repeat", "repeat-x")

    /// The background image is only repeated vertically.
    [<CustomOperation("backgroundRepeatRepeatY")>]
    member inline _.backgroundRepeatRepeatY([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-repeat", "repeat-y")

    /// The background-image is not repeated.
    [<CustomOperation("backgroundRepeatNoRepeat")>]
    member inline _.backgroundRepeatNoRepeat([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-repeat", "no-repeat")

    /// Sets this property to its default value.
    [<CustomOperation("backgroundRepeatInitial")>]
    member inline _.backgroundRepeatInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-repeat", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("backgroundRepeatInheritFromParent")>]
    member inline _.backgroundRepeatInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-repeat", "inherit")

    /// Sets the background color of an element.
    [<CustomOperation("backgroundColor")>]
    member inline _.backgroundColor([<InlineIfLambda>] comb: CombineKeyValue, color: string) =
        comb &>> ("background-color", color)

    /// Sets one or more background images on an element.
    [<CustomOperation("backgroundImage")>]
    member inline _.backgroundImage([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("background-image", value)

    /// Short-hand for `style.backgroundImage(sprintf "url('%s')", value)` to set the backround image using a url.
    [<CustomOperation("backgroundImageUrl")>]
    member inline _.backgroundImageUrl([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("background-image", "url('" + value + "')")

    /// Shorthand for all background properties (e.g. "url(a.png) no-repeat center / cover").
    [<CustomOperation("background")>]
    member inline _.background([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("background", value)

    /// Sets whether the background scrolls with the page. Accepts scroll | fixed | local or a CSS variable.
    [<CustomOperation("backgroundAttachment")>]
    member inline _.backgroundAttachment([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("background-attachment", value)

    /// The background scrolls with the page. This is default.
    [<CustomOperation("backgroundAttachmentScroll")>]
    member inline _.backgroundAttachmentScroll([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-attachment", "scroll")

    /// The background is fixed with regard to the viewport.
    [<CustomOperation("backgroundAttachmentFixed")>]
    member inline _.backgroundAttachmentFixed([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-attachment", "fixed")

    /// The background scrolls with the element's contents.
    [<CustomOperation("backgroundAttachmentLocal")>]
    member inline _.backgroundAttachmentLocal([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-attachment", "local")

    /// Sets this property to its default value.
    [<CustomOperation("backgroundAttachmentInitial")>]
    member inline _.backgroundAttachmentInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-attachment", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("backgroundAttachmentInheritFromParent")>]
    member inline _.backgroundAttachmentInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-attachment", "inherit")

    /// Sets the origin of the background. Accepts border-box | padding-box | content-box or a CSS variable.
    [<CustomOperation("backgroundOrigin")>]
    member inline _.backgroundOrigin([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("background-origin", value)

    /// The background is relative to the border box.
    [<CustomOperation("backgroundOriginBorderBox")>]
    member inline _.backgroundOriginBorderBox([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-origin", "border-box")

    /// The background is relative to the padding box. This is default.
    [<CustomOperation("backgroundOriginPaddingBox")>]
    member inline _.backgroundOriginPaddingBox([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-origin", "padding-box")

    /// The background is relative to the content box.
    [<CustomOperation("backgroundOriginContentBox")>]
    member inline _.backgroundOriginContentBox([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-origin", "content-box")

    /// Sets this property to its default value.
    [<CustomOperation("backgroundOriginInitial")>]
    member inline _.backgroundOriginInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-origin", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("backgroundOriginInheritFromParent")>]
    member inline _.backgroundOriginInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("background-origin", "inherit")

    /// Sets the horizontal background position (e.g. "left", "10px", "var(--bg-x)").
    [<CustomOperation("backgroundPositionX")>]
    member inline _.backgroundPositionX([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("background-position-x", value)

    /// Sets the vertical background position (e.g. "top", "10px", "var(--bg-y)").
    [<CustomOperation("backgroundPositionY")>]
    member inline _.backgroundPositionY([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("background-position-y", value)


    /// Shorthand for setting all mask-* properties.
    [<CustomOperation("mask")>]
    member inline _.mask([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("mask", value)

    /// Sets the image used as the mask layer (e.g. url(...) or a gradient).
    [<CustomOperation("maskImage")>]
    member inline _.maskImage([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("mask-image", value)

    /// Sets the size of the mask image.
    [<CustomOperation("maskSize")>]
    member inline _.maskSize([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("mask-size", value)

    /// Default. The mask is repeated.
    [<CustomOperation("maskRepeatRepeat")>]
    member inline _.maskRepeatRepeat([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("mask-repeat", "repeat")

    /// The mask is not repeated.
    [<CustomOperation("maskRepeatNoRepeat")>]
    member inline _.maskRepeatNoRepeat([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("mask-repeat", "no-repeat")

    /// Repeated horizontally only.
    [<CustomOperation("maskRepeatRepeatX")>]
    member inline _.maskRepeatRepeatX([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("mask-repeat", "repeat-x")

    /// Repeated vertically only.
    [<CustomOperation("maskRepeatRepeatY")>]
    member inline _.maskRepeatRepeatY([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("mask-repeat", "repeat-y")

    /// Sets whether and how the mask image is repeated.
    [<CustomOperation("maskRepeat")>]
    member inline _.maskRepeat([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("mask-repeat", value)

    /// Sets this property to its default value.
    [<CustomOperation("maskRepeatInitial")>]
    member inline _.maskRepeatInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("mask-repeat", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("maskRepeatInheritFromParent")>]
    member inline _.maskRepeatInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("mask-repeat", "inherit")

    /// Sets the initial position of the mask image.
    [<CustomOperation("maskPosition")>]
    member inline _.maskPosition([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("mask-position", value)

    /// Determines the area affected by the mask (e.g. "border-box", "padding-box", "content-box").
    [<CustomOperation("maskClip")>]
    member inline _.maskClip([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("mask-clip", value)

    /// Sets the origin of the mask (e.g. "border-box", "padding-box", "content-box").
    [<CustomOperation("maskOrigin")>]
    member inline _.maskOrigin([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("mask-origin", value)

    /// Default. Mask layers are added.
    [<CustomOperation("maskCompositeAdd")>]
    member inline _.maskCompositeAdd([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("mask-composite", "add")

    /// Mask layers are subtracted.
    [<CustomOperation("maskCompositeSubtract")>]
    member inline _.maskCompositeSubtract([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("mask-composite", "subtract")

    /// Mask layers are intersected.
    [<CustomOperation("maskCompositeIntersect")>]
    member inline _.maskCompositeIntersect([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("mask-composite", "intersect")

    /// Mask layers are excluded (XOR).
    [<CustomOperation("maskCompositeExclude")>]
    member inline _.maskCompositeExclude([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("mask-composite", "exclude")

    /// Sets how multiple mask layers are composited together.
    [<CustomOperation("maskComposite")>]
    member inline _.maskComposite([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("mask-composite", value)

    /// Sets this property to its default value.
    [<CustomOperation("maskCompositeInitial")>]
    member inline _.maskCompositeInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("mask-composite", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("maskCompositeInheritFromParent")>]
    member inline _.maskCompositeInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("mask-composite", "inherit")





    // --------------------------------------------------------------------
    // Border styles
    // --------------------------------------------------------------------


    /// Sets the width of the outline.
    [<CustomOperation("outlineWidth")>]
    member inline _.outlineWidth([<InlineIfLambda>] comb: CombineKeyValue, width: int) =
        comb &&& mkPxWithKV ("outline-width", width)

    /// Sets the width of the outline.
    [<CustomOperation("outlineWidth")>]
    member inline _.outlineWidth([<InlineIfLambda>] comb: CombineKeyValue, width: string) =
        comb &>> ("outline-width", width)

    /// Specifies a medium outline. This is default.
    [<CustomOperation("outlineWidthMedium")>]
    member inline _.outlineWidthMedium([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("outline-width", "medium")

    /// Specifies a thin outline.
    [<CustomOperation("outlineWidthThin")>]
    member inline _.outlineWidthThin([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("outline-width", "thin")

    /// Specifies a thick outline.
    [<CustomOperation("outlineWidthThick")>]
    member inline _.outlineWidthThick([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("outline-width", "thick")

    /// Sets this property to its default value)
    [<CustomOperation("outlineWidthInitial")>]
    member inline _.outlineWidthInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("outline-width", "initial")

    /// Inherits this property from its parent element
    [<CustomOperation("outlineWidthInheritFromParent")>]
    member inline _.outlineWidthInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("outline-width", "inherit")

    /// Sets whether table borders should collapse into a single border or be separated as in standard HTML.
    /// Borders are separated; each cell will display its own borders. This is default.
    [<CustomOperation("borderCollapseSeparate")>]
    member inline _.borderCollapseSeparate([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-collapse", "separate")

    /// Borders are collapsed into a single border when possible (border-spacing and empty-cells properties have no effect))
    [<CustomOperation("borderCollapseCollapse")>]
    member inline _.borderCollapseCollapse([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-collapse", "collapse")

    /// Sets this property to its default value)
    [<CustomOperation("borderCollapseInitial")>]
    member inline _.borderCollapseInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-collapse", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("borderCollapseInheritFromParent")>]
    member inline _.borderCollapseInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-collapse", "inherit")

    /// Sets whether table borders collapse using a CSS string value (e.g. "collapse", "var(--border-collapse)").
    [<CustomOperation("borderCollapse")>]
    member inline _.borderCollapse([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-collapse", value)

    /// Sets the distance between the borders of adjacent <table> cells. Applies only when border-collapse is separate.
    [<CustomOperation("borderSpacing")>]
    member inline _.borderSpacing([<InlineIfLambda>] comb: CombineKeyValue, horizontal: string, ?vertical: string) =
        comb &>> ("border-spacing", horizontal + ", " + string vertical)

    /// Sets this property to its default value)
    [<CustomOperation("borderSpacingInitial")>]
    member inline _.borderSpacingInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-spacing", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("borderSpacingInheritFromParent")>]
    member inline _.borderSpacingInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-spacing", "inherit")

    /// Sets the line style for all four sides of an element's border.
    [<CustomOperation("borderStyle")>]
    member inline _.borderStyle([<InlineIfLambda>] comb: CombineKeyValue, style: string) =
        comb &>> ("border-style", style)

    /// Specifies a dotted border.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
    [<CustomOperation("borderStyleDotted")>]
    member inline _.borderStyleDotted([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("border-style", "dotted")

    /// Specifies a dashed border.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
    [<CustomOperation("borderStyleDashed")>]
    member inline _.borderStyleDashed([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("border-style", "dashed")

    /// Specifies a solid border.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
    [<CustomOperation("borderStyleSolid")>]
    member inline _.borderStyleSolid([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("border-style", "solid")

    /// Specifies a double border.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
    [<CustomOperation("borderStyleDouble")>]
    member inline _.borderStyleDouble([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("border-style", "double")

    /// Specifies a 3D grooved border. The effect depends on the border-color value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
    [<CustomOperation("borderStyleGroove")>]
    member inline _.borderStyleGroove([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("border-style", "groove")

    /// Specifies a 3D ridged border. The effect depends on the border-color value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
    [<CustomOperation("borderStyleRidge")>]
    member inline _.borderStyleRidge([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("border-style", "ridge")

    /// Specifies a 3D inset border. The effect depends on the border-color value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
    [<CustomOperation("borderStyleInset")>]
    member inline _.borderStyleInset([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("border-style", "inset")

    /// Specifies a 3D outset border. The effect depends on the border-color value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
    [<CustomOperation("borderStyleOutset")>]
    member inline _.borderStyleOutset([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("border-style", "outset")

    /// Default value. Specifies no border.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
    [<CustomOperation("borderStyleNone")>]
    member inline _.borderStyleNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("border-style", "none")

    /// The same as "none", except in border conflict resolution for table elements.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=hidden
    [<CustomOperation("borderStyleHidden")>]
    member inline _.borderStyleHidden([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("border-style", "hidden")

    /// Sets this property to its default value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=hidden
    ///
    /// Read about initial value https://www.w3schools.com/cssref/css_initial.asp
    [<CustomOperation("borderStyleInitial")>]
    member inline _.borderStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("border-style", "initial")

    /// Inherits this property from its parent element.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=hidden
    ///
    /// Read about inherit https://www.w3schools.com/cssref/css_inherit.asp
    [<CustomOperation("borderStyleInheritFromParent")>]
    member inline _.borderStyleInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-style", "inherit")

    /// Permits the user agent to render a custom outline style.
    [<CustomOperation("outlineStyleAuto")>]
    member inline _.outlineStyleAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("outline-style", "auto")

    /// Specifies no outline. This is default.
    [<CustomOperation("outlineStyleNone")>]
    member inline _.outlineStyleNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("outline-style", "none")

    /// Specifies a hidden outline
    [<CustomOperation("outlineStyleHidden")>]
    member inline _.outlineStyleHidden([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("outline-style", "hidden")

    /// Specifies a dotted outline
    [<CustomOperation("outlineStyleDotted")>]
    member inline _.outlineStyleDotted([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("outline-style", "dotted")

    /// Specifies a dashed outline
    [<CustomOperation("outlineStyleDashed")>]
    member inline _.outlineStyleDashed([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("outline-style", "dashed")

    /// Specifies a solid outline
    [<CustomOperation("outlineStyleSolid")>]
    member inline _.outlineStyleSolid([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("outline-style", "solid")

    /// Specifies a double outliner
    [<CustomOperation("outlineStyleDouble")>]
    member inline _.outlineStyleDouble([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("outline-style", "double")

    /// Specifies a 3D grooved outline. The effect depends on the outline-color value)
    [<CustomOperation("outlineStyleGroove")>]
    member inline _.outlineStyleGroove([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("outline-style", "groove")

    /// Specifies a 3D ridged outline. The effect depends on the outline-color value)
    [<CustomOperation("outlineStyleRidge")>]
    member inline _.outlineStyleRidge([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("outline-style", "ridge")

    /// Specifies a 3D inset  outline. The effect depends on the outline-color value)
    [<CustomOperation("outlineStyleInset")>]
    member inline _.outlineStyleInset([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("outline-style", "inset")

    /// Specifies a 3D outset outline. The effect depends on the outline-color value)
    [<CustomOperation("outlineStyleOutset")>]
    member inline _.outlineStyleOutset([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("outline-style", "outset")

    /// Sets this property to its default value)
    [<CustomOperation("outlineStyleInitial")>]
    member inline _.outlineStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("outline-style", "initial")

    /// Inherits this property from its parent element
    [<CustomOperation("outlineStyleInheritFromParent")>]
    member inline _.outlineStyleInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("outline-style", "inherit")

    /// Sets the style of an outline using a CSS string value (e.g. "solid", "var(--outline-style)").
    [<CustomOperation("outlineStyle")>]
    member inline _.outlineStyle([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("outline-style", value)

    /// The outline-offset property adds space between an outline and the edge or border of an element.
    ///
    /// The space between an element and its outline is transparent.
    ///
    /// Outlines differ from borders in three ways:
    ///
    ///  - An outline is a line drawn around elements, outside the border edge
    ///  - An outline does not take up space
    ///  - An outline may be non-rectangular
    ///
    [<CustomOperation("outlineOffset")>]
    member inline _.outlineOffset([<InlineIfLambda>] comb: CombineKeyValue, offset: int) =
        comb &&& mkPxWithKV ("outline-offset", offset)

    /// The outline-offset property adds space between an outline and the edge or border of an element.
    ///
    /// The space between an element and its outline is transparent.
    ///
    /// Outlines differ from borders in three ways:
    ///
    ///  - An outline is a line drawn around elements, outside the border edge
    ///  - An outline does not take up space
    ///  - An outline may be non-rectangular
    ///
    [<CustomOperation("outlineOffset")>]
    member inline _.outlineOffset([<InlineIfLambda>] comb: CombineKeyValue, offset: string) =
        comb &>> ("outline-offset", offset)

    /// An outline is a line that is drawn around elements (outside the borders) to make the element "stand out".
    ///
    /// The `outline-color` property specifies the color of an outline.
    /// **Note**: Always declare the outline-style property before the outline-color property. An element must have an outline before you change the color of it.
    [<CustomOperation("outlineColor")>]
    member inline _.outlineColor([<InlineIfLambda>] comb: CombineKeyValue, color: string) =
        comb &>> ("outline-color", color)

    /// Sets the line style of an element's border.
    [<CustomOperation("border")>]
    member inline _.border([<InlineIfLambda>] comb: CombineKeyValue, style: string) = comb &>> ("border", style)

    /// Sets the line style of an element's left border.
    [<CustomOperation("borderLeft")>]
    member inline _.borderLeft([<InlineIfLambda>] comb: CombineKeyValue, style: string) =
        comb &>> ("border-left", style)

    /// Sets the line style of an element's top border.
    [<CustomOperation("borderTop")>]
    member inline _.borderTop([<InlineIfLambda>] comb: CombineKeyValue, style: string) = comb &>> ("border-top", style)

    /// Sets the line style of an element's right border.
    [<CustomOperation("borderRight")>]
    member inline _.borderRight([<InlineIfLambda>] comb: CombineKeyValue, style: string) =
        comb &>> ("border-right", style)

    /// Sets the line style of an element's bottom border.
    [<CustomOperation("borderBottom")>]
    member inline _.borderBottom([<InlineIfLambda>] comb: CombineKeyValue, style: string) =
        comb &>> ("border-bottom", style)

    /// Sets the line style of an element's bottom border.
    [<CustomOperation("borderBottomStyle")>]
    member inline _.borderBottomStyle([<InlineIfLambda>] comb: CombineKeyValue, style: string) =
        comb &>> ("border-bottom-style", style)

    /// Sets the width of the bottom border of an element.
    [<CustomOperation("borderBottomWidth")>]
    member inline _.borderBottomWidth([<InlineIfLambda>] comb: CombineKeyValue, width: int) =
        comb &&& mkPxWithKV ("border-bottom-width", width)

    /// Sets the width of the bottom border of an element.
    [<CustomOperation("borderBottomWidth")>]
    member inline _.borderBottomWidth([<InlineIfLambda>] comb: CombineKeyValue, width: string) =
        comb &>> ("border-bottom-width", width)

    /// Sets the color of an element's bottom border.
    ///
    /// It can also be set with the shorthand CSS properties border-color or border-bottom.
    [<CustomOperation("borderBottomColor")>]
    member inline _.borderBottomColor([<InlineIfLambda>] comb: CombineKeyValue, color: string) =
        comb &>> ("border-bottom-color", color)

    /// Sets the line style of an element's top border.
    [<CustomOperation("borderTopStyle")>]
    member inline _.borderTopStyle([<InlineIfLambda>] comb: CombineKeyValue, style: string) =
        comb &>> ("border-top-style", style)

    /// Sets the width of the top border of an element.
    [<CustomOperation("borderTopWidth")>]
    member inline _.borderTopWidth([<InlineIfLambda>] comb: CombineKeyValue, width: int) =
        comb &&& mkPxWithKV ("border-top-width", width)

    /// Sets the width of the top border of an element.
    [<CustomOperation("borderTopWidth")>]
    member inline _.borderTopWidth([<InlineIfLambda>] comb: CombineKeyValue, width: string) =
        comb &>> ("border-top-width", width)

    /// Sets the color of an element's top border.
    ///
    /// It can also be set with the shorthand CSS properties border-color or border-bottom.
    [<CustomOperation("borderTopColor")>]
    member inline _.borderTopColor([<InlineIfLambda>] comb: CombineKeyValue, color: string) =
        comb &>> ("border-top-color", color)

    /// Sets the line style of an element's right border.
    [<CustomOperation("borderRightStyle")>]
    member inline _.borderRightStyle([<InlineIfLambda>] comb: CombineKeyValue, style: string) =
        comb &>> ("border-right-style", style)

    /// Sets the width of the right border of an element.
    [<CustomOperation("borderRightWidth")>]
    member inline _.borderRightWidth([<InlineIfLambda>] comb: CombineKeyValue, width: int) =
        comb &&& mkPxWithKV ("border-right-width", width)

    /// Sets the width of the right border of an element.
    [<CustomOperation("borderRightWidth")>]
    member inline _.borderRightWidth([<InlineIfLambda>] comb: CombineKeyValue, width: string) =
        comb &>> ("border-right-width", width)

    /// Sets the color of an element's right border.
    ///
    /// It can also be set with the shorthand CSS properties border-color or border-bottom.
    [<CustomOperation("borderRightColor")>]
    member inline _.borderRightColor([<InlineIfLambda>] comb: CombineKeyValue, color: string) =
        comb &>> ("border-right-color", color)

    /// Sets the line style of an element's left border.
    [<CustomOperation("borderLeftStyle")>]
    member inline _.borderLeftStyle([<InlineIfLambda>] comb: CombineKeyValue, style: string) =
        comb &>> ("border-left-style", style)

    /// Sets the width of the left border of an element.
    [<CustomOperation("borderLeftWidth")>]
    member inline _.borderLeftWidth([<InlineIfLambda>] comb: CombineKeyValue, width: int) =
        comb &&& mkPxWithKV ("border-left-width", width)

    /// Sets the width of the left border of an element.
    [<CustomOperation("borderLeftWidth")>]
    member inline _.borderLeftWidth([<InlineIfLambda>] comb: CombineKeyValue, width: string) =
        comb &>> ("border-left-width", width)

    /// Sets the color of an element's left border.
    ///
    /// It can also be set with the shorthand CSS properties border-color or border-bottom.
    [<CustomOperation("borderLeftColor")>]
    member inline _.borderLeftColor([<InlineIfLambda>] comb: CombineKeyValue, color: string) =
        comb &>> ("border-left-color", color)

    /// Sets the color of an element's border.
    [<CustomOperation("borderColor")>]
    member inline _.borderColor([<InlineIfLambda>] comb: CombineKeyValue, color: string) =
        comb &>> ("border-color", color)

    /// Rounds the corners of an element's outer border edge. You can set a single radius to make
    /// circular corners, or two radii to make elliptical corners.
    [<CustomOperation("borderRadius")>]
    member inline _.borderRadius([<InlineIfLambda>] comb: CombineKeyValue, radius: int) =
        comb &&& mkPxWithKV ("border-radius", radius)

    /// Rounds the corners of an element's outer border edge. You can set a single radius to make
    /// circular corners, or two radii to make elliptical corners.
    [<CustomOperation("borderRadius")>]
    member inline _.borderRadius([<InlineIfLambda>] comb: CombineKeyValue, radius: string) =
        comb &>> ("border-radius", radius)

    /// Sets the width of an element's border.
    [<CustomOperation("borderWidth")>]
    member inline _.borderWidth([<InlineIfLambda>] comb: CombineKeyValue, width: int) =
        comb &&& mkPxWithKV ("border-width", width)

    /// Sets the width of an element's border.
    [<CustomOperation("borderWidth")>]
    member inline _.borderWidth([<InlineIfLambda>] comb: CombineKeyValue, top: string, ?right: string) =
        comb
        &&& CombineKeyValue(fun sb ->
            let sb = sb.Append("border-width: ").Append(top)

            match right with
            | Some x -> sb.Append(" ").Append(x).Append("; ")
            | None -> sb.Append("; "))

    /// Sets the width of an element's border.
    [<CustomOperation("borderWidth")>]
    member inline _.borderWidth
        ([<InlineIfLambda>] comb: CombineKeyValue, top: string, right: string, bottom: string, ?left: string)
        =
        CombineKeyValue(fun sb ->
            let sb =
                comb
                    .Invoke(sb)
                    .Append("border-width: ")
                    .Append(top)
                    .Append(" ")
                    .Append(right)
                    .Append(" ")
                    .Append(bottom)

            match left with
            | Some x -> sb.Append(" ").Append(x).Append("; ")
            | None -> sb.Append("; "))

    /// Shorthand for outline-width, outline-style and outline-color (e.g. "2px solid red").
    [<CustomOperation("outline")>]
    member inline _.outline([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("outline", value)

    /// Sets the outline width with a unitless number converted to px.
    [<CustomOperation("outlineWidth")>]
    member inline _.outlineWidth([<InlineIfLambda>] comb: CombineKeyValue, value: float) =
        comb &&& mkPxWithKV ("outline-width", value)

    /// Rounds the top-left corner. Accepts a CSS length (e.g. "8px") or radius string.
    [<CustomOperation("borderTopLeftRadius")>]
    member inline _.borderTopLeftRadius([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-top-left-radius", value)

    /// Rounds the top-left corner in pixels.
    [<CustomOperation("borderTopLeftRadius")>]
    member inline _.borderTopLeftRadius([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("border-top-left-radius", value)

    /// Rounds the top-right corner. Accepts a CSS length (e.g. "8px") or radius string.
    [<CustomOperation("borderTopRightRadius")>]
    member inline _.borderTopRightRadius([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-top-right-radius", value)

    /// Rounds the top-right corner in pixels.
    [<CustomOperation("borderTopRightRadius")>]
    member inline _.borderTopRightRadius([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("border-top-right-radius", value)

    /// Rounds the bottom-right corner. Accepts a CSS length (e.g. "8px") or radius string.
    [<CustomOperation("borderBottomRightRadius")>]
    member inline _.borderBottomRightRadius([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-bottom-right-radius", value)

    /// Rounds the bottom-right corner in pixels.
    [<CustomOperation("borderBottomRightRadius")>]
    member inline _.borderBottomRightRadius([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("border-bottom-right-radius", value)

    /// Rounds the bottom-left corner. Accepts a CSS length (e.g. "8px") or radius string.
    [<CustomOperation("borderBottomLeftRadius")>]
    member inline _.borderBottomLeftRadius([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-bottom-left-radius", value)

    /// Rounds the bottom-left corner in pixels.
    [<CustomOperation("borderBottomLeftRadius")>]
    member inline _.borderBottomLeftRadius([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("border-bottom-left-radius", value)


    /// Shorthand for setting all border-image-* properties (source, slice, width, outset, repeat).
    [<CustomOperation("borderImage")>]
    member inline _.borderImage([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-image", value)

    /// Sets the source image used to create an element's border image (e.g. url(...) or a gradient).
    [<CustomOperation("borderImageSource")>]
    member inline _.borderImageSource([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-image-source", value)

    /// Divides the border image into regions (e.g. "30", "30% fill").
    [<CustomOperation("borderImageSlice")>]
    member inline _.borderImageSlice([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-image-slice", value)

    /// Sets the width of the border image (e.g. "1", "10px").
    [<CustomOperation("borderImageWidth")>]
    member inline _.borderImageWidth([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-image-width", value)

    /// Sets the distance by which the border image is set out from the border box.
    [<CustomOperation("borderImageOutset")>]
    member inline _.borderImageOutset([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-image-outset", value)

    /// Default. The region is stretched to fill the gap.
    [<CustomOperation("borderImageRepeatStretch")>]
    member inline _.borderImageRepeatStretch([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-image-repeat", "stretch")

    /// The region is tiled to fill the gap.
    [<CustomOperation("borderImageRepeatRepeat")>]
    member inline _.borderImageRepeatRepeat([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-image-repeat", "repeat")

    /// The region is tiled and rescaled to fill the gap with a whole number of tiles.
    [<CustomOperation("borderImageRepeatRound")>]
    member inline _.borderImageRepeatRound([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-image-repeat", "round")

    /// The region is tiled with extra space distributed between tiles.
    [<CustomOperation("borderImageRepeatSpace")>]
    member inline _.borderImageRepeatSpace([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-image-repeat", "space")

    /// Defines how the edge regions of the border image are scaled and tiled.
    [<CustomOperation("borderImageRepeat")>]
    member inline _.borderImageRepeat([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-image-repeat", value)

    /// Sets this property to its default value.
    [<CustomOperation("borderImageRepeatInitial")>]
    member inline _.borderImageRepeatInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-image-repeat", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("borderImageRepeatInheritFromParent")>]
    member inline _.borderImageRepeatInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-image-repeat", "inherit")

    /// Shorthand for setting the block-start and block-end borders (width, style, color).
    [<CustomOperation("borderBlock")>]
    member inline _.borderBlock([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-block", value)

    /// Sets the color of the block-start and block-end borders.
    [<CustomOperation("borderBlockColor")>]
    member inline _.borderBlockColor([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-block-color", value)

    /// No border.
    [<CustomOperation("borderBlockStyleNone")>]
    member inline _.borderBlockStyleNone([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-block-style", "none")

    /// A solid line.
    [<CustomOperation("borderBlockStyleSolid")>]
    member inline _.borderBlockStyleSolid([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-block-style", "solid")

    /// A dashed line.
    [<CustomOperation("borderBlockStyleDashed")>]
    member inline _.borderBlockStyleDashed([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-block-style", "dashed")

    /// A dotted line.
    [<CustomOperation("borderBlockStyleDotted")>]
    member inline _.borderBlockStyleDotted([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-block-style", "dotted")

    /// A double line.
    [<CustomOperation("borderBlockStyleDouble")>]
    member inline _.borderBlockStyleDouble([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-block-style", "double")

    /// Sets the style of the block-start and block-end borders.
    [<CustomOperation("borderBlockStyle")>]
    member inline _.borderBlockStyle([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-block-style", value)

    /// Sets this property to its default value.
    [<CustomOperation("borderBlockStyleInitial")>]
    member inline _.borderBlockStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-block-style", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("borderBlockStyleInheritFromParent")>]
    member inline _.borderBlockStyleInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-block-style", "inherit")

    /// Sets the width of the block-start and block-end borders.
    [<CustomOperation("borderBlockWidth")>]
    member inline _.borderBlockWidth([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-block-width", value)

    /// Shorthand for setting the inline-start and inline-end borders (width, style, color).
    [<CustomOperation("borderInline")>]
    member inline _.borderInline([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-inline", value)

    /// Sets the color of the inline-start and inline-end borders.
    [<CustomOperation("borderInlineColor")>]
    member inline _.borderInlineColor([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-inline-color", value)

    /// No border.
    [<CustomOperation("borderInlineStyleNone")>]
    member inline _.borderInlineStyleNone([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-inline-style", "none")

    /// A solid line.
    [<CustomOperation("borderInlineStyleSolid")>]
    member inline _.borderInlineStyleSolid([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-inline-style", "solid")

    /// A dashed line.
    [<CustomOperation("borderInlineStyleDashed")>]
    member inline _.borderInlineStyleDashed([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-inline-style", "dashed")

    /// A dotted line.
    [<CustomOperation("borderInlineStyleDotted")>]
    member inline _.borderInlineStyleDotted([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-inline-style", "dotted")

    /// A double line.
    [<CustomOperation("borderInlineStyleDouble")>]
    member inline _.borderInlineStyleDouble([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-inline-style", "double")

    /// Sets the style of the inline-start and inline-end borders.
    [<CustomOperation("borderInlineStyle")>]
    member inline _.borderInlineStyle([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-inline-style", value)

    /// Sets this property to its default value.
    [<CustomOperation("borderInlineStyleInitial")>]
    member inline _.borderInlineStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-inline-style", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("borderInlineStyleInheritFromParent")>]
    member inline _.borderInlineStyleInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("border-inline-style", "inherit")

    /// Sets the width of the inline-start and inline-end borders.
    [<CustomOperation("borderInlineWidth")>]
    member inline _.borderInlineWidth([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-inline-width", value)

    /// Shorthand for setting the block-start border (width, style, color).
    [<CustomOperation("borderBlockStart")>]
    member inline _.borderBlockStart([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-block-start", value)

    /// Shorthand for setting the block-end border (width, style, color).
    [<CustomOperation("borderBlockEnd")>]
    member inline _.borderBlockEnd([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-block-end", value)

    /// Shorthand for setting the inline-start border (width, style, color).
    [<CustomOperation("borderInlineStart")>]
    member inline _.borderInlineStart([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-inline-start", value)

    /// Shorthand for setting the inline-end border (width, style, color).
    [<CustomOperation("borderInlineEnd")>]
    member inline _.borderInlineEnd([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("border-inline-end", value)





    // --------------------------------------------------------------------
    // BoxSpacing styles
    // --------------------------------------------------------------------


    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    [<CustomOperation("margin")>]
    member inline _.margin([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& mkPxWithKV ("margin", value)

    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    [<CustomOperation("margin")>]
    member inline _.margin([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("margin", value)

    /// Sets the margin area on the vertical and horizontal axis.
    [<CustomOperation("margin")>]
    member inline _.margin([<InlineIfLambda>] comb: CombineKeyValue, vertical: int, horizonal: int) =
        CombineKeyValue(fun sb ->
            comb.Invoke(sb).Append("margin: ").Append(vertical).Append("px ").Append(horizonal).Append("px; "))

    /// Sets the margin area on the vertical and horizontal axis.
    [<CustomOperation("margin")>]
    member inline _.margin([<InlineIfLambda>] comb: CombineKeyValue, vertical: string, horizonal: string) =
        CombineKeyValue(fun sb ->
            comb.Invoke(sb).Append("margin: ").Append(vertical).Append(" ").Append(horizonal).Append("; "))

    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    [<CustomOperation("margin")>]
    member inline _.margin([<InlineIfLambda>] comb: CombineKeyValue, top: int, right: int, bottom: int, left: int) =
        CombineKeyValue(fun sb ->
            comb
                .Invoke(sb)
                .Append("margin: ")
                .Append(top)
                .Append("px ")
                .Append(right)
                .Append("px ")
                .Append(bottom)
                .Append("px ")
                .Append(left)
                .Append("px; "))

    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    [<CustomOperation("margin")>]
    member inline _.margin
        ([<InlineIfLambda>] comb: CombineKeyValue, top: string, right: string, bottom: string, left: string)
        =
        CombineKeyValue(fun sb ->
            comb
                .Invoke(sb)
                .Append("margin: ")
                .Append(top)
                .Append(" ")
                .Append(right)
                .Append(" ")
                .Append(bottom)
                .Append(" ")
                .Append(left)
                .Append("; "))

    /// Sets the margin area on the left side of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    [<CustomOperation("marginLeft")>]
    member inline _.marginLeft([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("margin-left", value)

    /// Sets the margin area on the left side of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    [<CustomOperation("marginLeft")>]
    member inline _.marginLeft([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("margin-left", value)

    /// sets the margin area on the right side of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    [<CustomOperation("marginRight")>]
    member inline _.marginRight([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("margin-right", value)

    /// sets the margin area on the right side of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    [<CustomOperation("marginRight")>]
    member inline _.marginRight([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("margin-right", value)

    /// Sets the margin area on the top of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    [<CustomOperation("marginTop")>]
    member inline _.marginTop([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("margin-top", value)

    /// Sets the margin area on the top of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    [<CustomOperation("marginTop")>]
    member inline _.marginTop([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("margin-top", value)

    /// Sets the margin area on the bottom of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    [<CustomOperation("marginBottom")>]
    member inline _.marginBottom([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("margin-bottom", value)

    /// Sets the margin area on the bottom of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    [<CustomOperation("marginBottom")>]
    member inline _.marginBottom([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("margin-bottom", value)

    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    [<CustomOperation("padding")>]
    member inline _.padding([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("padding", value)

    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    [<CustomOperation("padding")>]
    member inline _.padding([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("padding", value)

    /// Sets the padding area for vertical and horizontal axis.
    [<CustomOperation("padding")>]
    member inline _.padding([<InlineIfLambda>] comb: CombineKeyValue, vertical: int, horizontal: int) =
        CombineKeyValue(fun sb ->
            comb.Invoke(sb).Append("padding: ").Append(vertical).Append("px ").Append(horizontal).Append("px; "))

    /// Sets the padding area for vertical and horizontal axis.
    [<CustomOperation("padding")>]
    member inline _.padding([<InlineIfLambda>] comb: CombineKeyValue, vertical: string, horizontal: string) =
        CombineKeyValue(fun sb ->
            comb.Invoke(sb).Append("padding: ").Append(vertical).Append(" ").Append(horizontal).Append("; "))

    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    [<CustomOperation("padding")>]
    member inline _.padding
        ([<InlineIfLambda>] comb: CombineKeyValue, top: string, right: string, bottom: string, left: string)
        =
        CombineKeyValue(fun sb ->
            comb
                .Invoke(sb)
                .Append("padding: ")
                .Append(top)
                .Append(" ")
                .Append(right)
                .Append(" ")
                .Append(bottom)
                .Append(" ")
                .Append(left)
                .Append("; "))

    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    [<CustomOperation("padding")>]
    member inline _.padding([<InlineIfLambda>] comb: CombineKeyValue, top: int, right: int, bottom: int, left: int) =
        CombineKeyValue(fun sb ->
            comb
                .Invoke(sb)
                .Append("padding: ")
                .Append(top)
                .Append("px ")
                .Append(right)
                .Append("px ")
                .Append(bottom)
                .Append("px ")
                .Append(left)
                .Append("px; "))

    /// Sets the height of the padding area on the bottom of an element.
    [<CustomOperation("paddingBottom")>]
    member inline _.paddingBottom([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("padding-bottom", value)

    /// Sets the height of the padding area on the bottom of an element.
    [<CustomOperation("paddingBottom")>]
    member inline _.paddingBottom([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("padding-bottom", value)

    /// Sets the width of the padding area to the left of an element.
    [<CustomOperation("paddingLeft")>]
    member inline _.paddingLeft([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("padding-left", value)

    /// Sets the width of the padding area to the left of an element.
    [<CustomOperation("paddingLeft")>]
    member inline _.paddingLeft([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("padding-left", value)

    /// Sets the width of the padding area on the right of an element.
    [<CustomOperation("paddingRight")>]
    member inline _.paddingRight([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("padding-right", value)

    /// Sets the width of the padding area on the right of an element.
    [<CustomOperation("paddingRight")>]
    member inline _.paddingRight([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("padding-right", value)

    /// Sets the height of the padding area on the top of an element.
    [<CustomOperation("paddingTop")>]
    member inline _.paddingTop([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("padding-top", value)

    /// Sets the height of the padding area on the top of an element.
    [<CustomOperation("paddingTop")>]
    member inline _.paddingTop([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("padding-top", value)


    /// Default. Margins are not trimmed.
    [<CustomOperation("marginTrimNone")>]
    member inline _.marginTrimNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("margin-trim", "none")

    /// Trim block-axis margins adjoining the box.
    [<CustomOperation("marginTrimBlock")>]
    member inline _.marginTrimBlock([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("margin-trim", "block")

    /// Trim inline-axis margins adjoining the box.
    [<CustomOperation("marginTrimInline")>]
    member inline _.marginTrimInline([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("margin-trim", "inline")

    /// Controls whether the margins of a box's children are trimmed when they adjoin the box's edges.
    [<CustomOperation("marginTrim")>]
    member inline _.marginTrim([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("margin-trim", value)

    /// Sets this property to its default value.
    [<CustomOperation("marginTrimInitial")>]
    member inline _.marginTrimInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("margin-trim", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("marginTrimInheritFromParent")>]
    member inline _.marginTrimInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("margin-trim", "inherit")





    // --------------------------------------------------------------------
    // Color styles
    // --------------------------------------------------------------------


    /// The element is hidden (but still takes up space).
    [<CustomOperation("visibilityHidden")>]
    member inline _.visibilityHidden([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("visibility", "hidden")

    /// Default value. The element is visible.
    [<CustomOperation("visibilityVisible")>]
    member inline _.visibilityVisible([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("visibility", "visible")

    /// Only for table rows (`<tr> `), row groups (`<tbody> `), columns (`<col> `), column groups
    /// (`<colgroup> `). This value removes a row or column, but it does not affect the table layout.
    /// The space taken up by the row or column will be available for other content.
    ///
    /// If collapse is used on other elements, it renders as "hidden")
    [<CustomOperation("visibilityCollapse")>]
    member inline _.visibilityCollapse([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("visibility", "collapse")

    /// Sets this property to its default value.
    [<CustomOperation("visibilityInitial")>]
    member inline _.visibilityInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("visibility", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("visibilityInheritFromParent")>]
    member inline _.visibilityInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("visibility", "inherit")

    /// Sets the visibility of an element using a CSS string value (e.g. "hidden", "var(--visibility)").
    [<CustomOperation("visibility")>]
    member inline _.visibility([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("visibility", value)

    /// Sets the color of the insertion caret, the visible marker where the next character typed will be inserted.
    ///
    /// This is sometimes referred to as the text input cursor. The caret appears in elements such as <input> or
    /// those with the contenteditable attribute. The caret is typically a thin vertical line that flashes to
    /// help make it more noticeable. By default, it is black, but its color can be altered with this property.
    [<CustomOperation("caretColor")>]
    member inline _.caretColor([<InlineIfLambda>] comb: CombineKeyValue, color: string) =
        comb &>> ("caret-color", color)

    /// Sets the foreground color value of an element's text and text decorations, and sets the
    /// `currentcolor` value. `currentcolor` may be used as an indirect value on other properties
    /// and is the default for other color properties, such as border-color.
    [<CustomOperation("color")>]
    member inline _.color([<InlineIfLambda>] comb: CombineKeyValue, color: string) = comb &>> ("color", color)

    /// Sets the opacity of an element.
    ///
    /// Opacity is the degree to which content behind an element is hidden, and is the opposite of transparency.
    [<CustomOperation("opacity")>]
    member inline _.opacity([<InlineIfLambda>] comb: CombineKeyValue, value: double) =
        comb &&& mkWithKV ("opacity", value)

    /// Sets the color of an SVG shape.
    [<CustomOperation("fill")>]
    member inline _.fill([<InlineIfLambda>] comb: CombineKeyValue, color: string) = comb &>> ("fill", color)




    // --------------------------------------------------------------------
    // Filter styles
    // --------------------------------------------------------------------


    /// Default value. Specifies no effects.
    [<CustomOperation("filterNone")>]
    member inline _.filterNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("filter", "none")

    /// Applies a blur effect to the elemeen. A larger value will create more blur.
    ///
    /// This overload takes an integer that represents a percentage from 0 to 100.
    [<CustomOperation("filterBlur")>]
    member inline _.filterBlur([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb
        &&& CombineKeyValue(fun sb -> sb.Append("filter: blur(").Append(value).Append("%); "))

    /// Applies a blur effect to the elemeen. A larger value will create more blur.
    ///
    /// This overload takes a floating number that goes from 0 to 1,
    [<CustomOperation("filterBlur")>]
    member inline _.filterBlur([<InlineIfLambda>] comb: CombineKeyValue, value: double) =
        comb
        &&& CombineKeyValue(fun sb -> sb.Append("filter: blur(").Append(value * 100.).Append("%); "))

    /// Adjusts the brightness of the elemeen
    ///
    /// This overload takes an integer that represents a percentage from 0 to 100.
    ///
    /// Values over 100% will provide brighter results.
    [<CustomOperation("filterBrightness")>]
    member inline _.filterBrightness([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb
        &&& CombineKeyValue(fun sb -> sb.Append("filter: brightness(").Append(value).Append("%); "))

    /// Adjusts the brightness of the elemeen. A larger value will create more blur.
    ///
    /// This overload takes a floating number that goes from 0 to 1,
    [<CustomOperation("filterBrightness")>]
    member inline _.filterBrightness([<InlineIfLambda>] comb: CombineKeyValue, value: double) =
        comb
        &&& CombineKeyValue(fun sb -> sb.Append("filter: brightness(").Append(value * 100.).Append("%); "))

    /// Adjusts the contrast of the element.
    ///
    /// This overload takes an integer that represents a percentage from 0 to 100.
    [<CustomOperation("filterContrast")>]
    member inline _.filterContrast([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb
        &&& CombineKeyValue(fun sb -> sb.Append("filter: contrast(").Append(value).Append("%); "))

    /// Adjusts the contrast of the element. A larger value will create more contrast.
    ///
    /// This overload takes a floating number that goes from 0 to 1
    [<CustomOperation("filterContrast")>]
    member inline _.filterContrast([<InlineIfLambda>] comb: CombineKeyValue, value: double) =
        comb
        &&& CombineKeyValue(fun sb -> sb.Append("filter: contrast(").Append(value * 100.).Append("%); "))

    /// Applies a drop shadow effect.
    [<CustomOperation("filterDropShadow")>]
    member inline _.filterDropShadow
        (
            [<InlineIfLambda>] comb: CombineKeyValue,
            horizontalOffset: int,
            verticalOffset: int,
            blur: int,
            spread: int,
            color: string
        ) =
        comb
        &&& CombineKeyValue(fun sb ->
            sb
                .Append("filter: drop-shadow(")
                .Append(horizontalOffset)
                .Append("px ")
                .Append(verticalOffset)
                .Append("px ")
                .Append(blur)
                .Append("px ")
                .Append(spread)
                .Append("px ")
                .Append(color)
                .Append("); "))

    /// Applies a drop shadow effect.
    [<CustomOperation("filterDropShadow")>]
    member inline _.filterDropShadow
        ([<InlineIfLambda>] comb: CombineKeyValue, horizontalOffset: int, verticalOffset: int, blur: int, color: string)
        =
        comb
        &&& CombineKeyValue(fun sb ->
            sb
                .Append("filter: drop-shadow(")
                .Append(horizontalOffset)
                .Append("px ")
                .Append(verticalOffset)
                .Append("px ")
                .Append(blur)
                .Append("px ")
                .Append(color)
                .Append("); "))

    /// Applies a drop shadow effect.
    [<CustomOperation("filterDropShadow")>]
    member inline _.filterDropShadow
        ([<InlineIfLambda>] comb: CombineKeyValue, horizontalOffset: int, verticalOffset: int, color: string)
        =
        comb
        &&& CombineKeyValue(fun sb ->
            sb
                .Append("filter: drop-shadow(")
                .Append(horizontalOffset)
                .Append("px ")
                .Append(verticalOffset)
                .Append("px ")
                .Append(color)
                .Append("); "))

    /// Converts the image to grayscale
    ///
    /// This overload takes an integer that represents a percentage from 0 to 100.
    [<CustomOperation("filterGrayscale")>]
    member inline _.filterGrayscale([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb
        &&& CombineKeyValue(fun sb -> sb.Append("filter: grayscale(").Append(value).Append("%); "))

    /// Converts the image to grayscale
    ///
    /// This overload takes a floating number that goes from 0 to 1
    [<CustomOperation("filterGrayscale")>]
    member inline _.filterGrayscale([<InlineIfLambda>] comb: CombineKeyValue, value: double) =
        comb
        &&& CombineKeyValue(fun sb -> sb.Append("filter: grayscale(").Append(value).Append("%); "))

    /// Applies a hue rotation on the image. The value defines the number of degrees around the color circle the image
    /// samples will be adjusted. 0deg is default, and represents the original image.
    ///
    /// **Note**: Maximum value is 360
    [<CustomOperation("filterHueRotate")>]
    member inline _.filterHueRotate([<InlineIfLambda>] comb: CombineKeyValue, degrees: int) =
        comb
        &&& CombineKeyValue(fun sb -> sb.Append("filter: hue-rotate(").Append(degrees).Append("deg); "))

    /// Inverts the element.
    ///
    /// This overload takes an integer that represents a percentage from 0 to 100.
    [<CustomOperation("filterInvert")>]
    member inline _.filterInvert([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("filter: ").Append("invert(").Append(value).Append("%); "))

    /// Inverts the element.
    ///
    /// This overload takes a floating number that goes from 0 to 1
    [<CustomOperation("filterInvert")>]
    member inline _.filterInvert([<InlineIfLambda>] comb: CombineKeyValue, value: double) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("filter: ").Append("invert(").Append(value).Append("%); "))

    /// Sets the opacity of the element.
    ///
    /// This overload takes an integer that represents a percentage from 0 to 100.
    [<CustomOperation("filterOpacity")>]
    member inline _.filterOpacity([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("filter: ").Append("opacity(").Append(value).Append("%); "))

    /// Sets the opacity of the element.
    ///
    /// This overload takes a floating number that goes from 0 to 1
    [<CustomOperation("filterOpacity")>]
    member inline _.filterOpacity([<InlineIfLambda>] comb: CombineKeyValue, value: double) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("filter: ").Append("opacity(").Append(value).Append("%); "))

    /// Sets the saturation of the element.
    ///
    /// This overload takes an integer that represents a percentage from 0 to 100.
    [<CustomOperation("filterSaturate")>]
    member inline _.filterSaturate([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("filter: ").Append("saturate(").Append(value).Append("%); "))

    /// Sets the saturation of the element.
    ///
    /// This overload takes a floating number that goes from 0 to 1
    [<CustomOperation("filterSaturate")>]
    member inline _.filterSaturate([<InlineIfLambda>] comb: CombineKeyValue, value: double) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("filter: ").Append("saturate(").Append(value).Append("%); "))

    /// Applies Sepia filter to the element.
    ///
    /// This overload takes an integer that represents a percentage from 0 to 100.
    [<CustomOperation("filterSepia")>]
    member inline _.filterSepia([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("filter: ").Append("sepia(").Append(value).Append("); "))

    /// Applies Sepia filter to the element.
    ///
    /// This overload takes a floating number that goes from 0 to 1
    [<CustomOperation("filterSepia")>]
    member inline _.filterSepia([<InlineIfLambda>] comb: CombineKeyValue, value: double) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("filter: ").Append("sepia(").Append(value).Append("); "))

    /// The url() function takes the location of an XML file that specifies an SVG filter, and may include an anchor to a specific filter element.
    ///
    /// Example: `filter: url(svg-url#element-id)`
    [<CustomOperation("filterUrl")>]
    member inline _.filterUrl([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("filter: ").Append("url(").Append(value).Append("); "))

    /// Sets this property to its default value.
    [<CustomOperation("filterInitial")>]
    member inline _.filterInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("filter", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("filterInheritFromParent")>]
    member inline _.filterInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("filter", "inherit")

    /// Sets the filter effects using a CSS string value (e.g. "blur(4px) grayscale(50%)", "var(--filter)").
    [<CustomOperation("filter")>]
    member inline _.filter([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("filter", value)




    // --------------------------------------------------------------------
    // Flex styles
    // --------------------------------------------------------------------


    /// Default value. The length is equal to the length of the flexible item. If the item has
    /// no length specified, the length will be according to its content.
    [<CustomOperation("flexBasisAuto")>]
    member inline _.flexBasisAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("flex-basis", "auto")

    /// Sets this property to its default value.
    [<CustomOperation("flexBasisInitial")>]
    member inline _.flexBasisInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("flex-basis", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("flexBasisInheritFromParent")>]
    member inline _.flexBasisInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("flex-basis", "inherit")

    /// Default value. The flexible items are displayed horizontally, as a row
    [<CustomOperation("flexDirectionRow")>]
    member inline _.flexDirectionRow([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("flex-direction", "row")

    /// Same as row, but in reverse order.
    [<CustomOperation("flexDirectionRowReverse")>]
    member inline _.flexDirectionRowReverse([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("flex-direction", "row-reverse")

    /// The flexible items are displayed vertically, as a column
    [<CustomOperation("flexDirectionColumn")>]
    member inline _.flexDirectionColumn([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("flex-direction", "column")

    /// Same as column, but in reverse order
    [<CustomOperation("flexDirectionColumnReverse")>]
    member inline _.flexDirectionColumnReverse([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("flex-direction", "column-reverse")

    /// Sets this property to its default value.
    [<CustomOperation("flexDirectionInitial")>]
    member inline _.flexDirectionInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("flex-direction", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("flexDirectionInheritFromParent")>]
    member inline _.flexDirectionInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("flex-direction", "inherit")

    /// Sets the direction of flexible items using a CSS string value (e.g. "row", "var(--flex-direction)").
    [<CustomOperation("flexDirection")>]
    member inline _.flexDirection([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("flex-direction", value)

    /// Default value. Specifies that the flexible items will not wrap.
    [<CustomOperation("flexWrapNowrap")>]
    member inline _.flexWrapNowrap([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("flex-wrap", "nowrap")

    /// Specifies that the flexible items will wrap if necessary
    [<CustomOperation("flexWrapWrap")>]
    member inline _.flexWrapWrap([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("flex-wrap", "wrap")

    /// Specifies that the flexible items will wrap, if necessary, in reverse order
    [<CustomOperation("flexWrapWrapReverse")>]
    member inline _.flexWrapWrapReverse([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("flex-wrap", "wrap-reverse")

    /// Sets this property to its default value.
    [<CustomOperation("flexWrapInitial")>]
    member inline _.flexWrapInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("flex-wrap", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("flexWrapInheritFromParent")>]
    member inline _.flexWrapInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("flex-wrap", "inherit")

    /// Sets whether flexible items wrap using a CSS string value (e.g. "wrap", "var(--flex-wrap)").
    [<CustomOperation("flexWrap")>]
    member inline _.flexWrap([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("flex-wrap", value)

    /// Sets the flex shrink factor of a flex item. If the size of all flex items is larger than
    /// the flex container, items shrink to fit according to flex-shrink.
    [<CustomOperation("flexShrink")>]
    member inline _.flexShrink([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkWithKV ("flex-shrink", value)

    /// Sets the initial main size of a flex item. It sets the size of the content box unless
    /// otherwise set with box-sizing.
    [<CustomOperation("flexBasis")>]
    member inline _.flexBasis([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("flex-basis", value)

    /// Sets the initial main size of a flex item. It sets the size of the content box unless
    /// otherwise set with box-sizing.
    [<CustomOperation("flexBasis")>]
    member inline _.flexBasis([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("flex-basis", value)

    /// Sets the flex grow factor of a flex item main size. It specifies how much of the remaining
    /// space in the flex container should be assigned to the item (the flex grow factor).
    [<CustomOperation("flexGrow")>]
    member inline _.flexGrow([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkWithKV ("flex-grow", value)

    /// Shorthand of flex-grow, flex-shrink and flex-basis
    [<CustomOperation("flex")>]
    member inline _.flex([<InlineIfLambda>] comb: CombineKeyValue, grow: int, shrink: int, ?basis: string) =
        CombineKeyValue(fun sb ->
            let sb = comb.Invoke(sb).Append("flex: ")
            sb.Append(grow) |> ignore
            sb.Append(' ').Append(shrink) |> ignore
            basis |> Option.iter (fun x -> sb.Append(' ').Append(x) |> ignore)
            sb.Append("; "))

    /// Shorthand of flex-grow and flex-basis
    [<CustomOperation("flex")>]
    member inline _.flex([<InlineIfLambda>] comb: CombineKeyValue, grow: int, ?basis: string) =
        CombineKeyValue(fun sb ->
            let sb = comb.Invoke(sb).Append("flex: ")
            sb.Append(grow) |> ignore
            basis |> Option.iter (fun x -> sb.Append(' ').Append(x) |> ignore)
            sb.Append("; "))

    /// Shorthand of flex-grow, flex-shrink and flex-basis
    [<CustomOperation("flex")>]
    member inline _.flex([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("flex", value)

    /// Sets the order of a flex item. Accepts a CSS order value.
    [<CustomOperation("order")>]
    member inline _.order([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& mkWithKV ("order", value)

    /// Sets the order of a flex item using a CSS string value (e.g. "1", "var(--order)").
    [<CustomOperation("order")>]
    member inline _.order([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("order", value)

    /// Shorthand for flex-direction and flex-wrap (e.g. "row wrap", "column nowrap").
    [<CustomOperation("flexFlow")>]
    member inline _.flexFlow([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("flex-flow", value)




    // --------------------------------------------------------------------
    // Grid styles
    // --------------------------------------------------------------------


    /// Sets the width of each individual grid column in pixels.
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: 100px 200px 100px;
    /// ```
    /// **F#**
    /// ```f#
    /// gridTemplateColumns: [100; 200; 100]
    /// ```
    [<CustomOperation("gridTemplateColumns")>]
    member inline _.gridTemplateColumns([<InlineIfLambda>] comb: CombineKeyValue, value: int seq) =
        CombineKeyValue(fun sb ->
            let sb = comb.Invoke(sb).Append("grid-template-columns: ")
            use e = value.GetEnumerator()

            if e.MoveNext() then
                sb.Append(e.Current).Append("px") |> ignore

                while e.MoveNext() do
                    sb.Append(" ").Append(e.Current).Append("px") |> ignore

            sb.Append("; "))

    /// Sets the width of each individual grid column.
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: 1fr 1fr 2fr;
    /// ```
    [<CustomOperation("gridTemplateColumns")>]
    member inline _.gridTemplateColumns([<InlineIfLambda>] comb: CombineKeyValue, value) =
        comb &>> ("grid-template-columns", value)

    /// Sets the width of a number of grid columns to the defined width, as well as naming the lines between them
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: repeat(3, 1fr [col-start]);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateColumns (3, "1fr", "col-start"))
    /// ```
    [<CustomOperation("gridTemplateColumns")>]
    member inline _.gridTemplateColumns
        ([<InlineIfLambda>] comb: CombineKeyValue, count: int, size: string, ?areaName: string)
        =
        let areaName =
            match areaName with
            | Some n -> ", [" + n + "]"
            | None -> ""

        CombineKeyValue(fun sb ->
            comb
                .Invoke(sb)
                .Append("grid-template-columns: ")
                .Append("repeat(")
                .Append(count)
                .Append(", ")
                .Append(size)
                .Append(areaName)
                .Append("); "))

    /// Sets the width of a number of grid rows to the defined width
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: 100px 200px 100px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows [100, 200, 100]
    /// ```
    [<CustomOperation("gridTemplateRows")>]
    member inline _.gridTemplateRows([<InlineIfLambda>] comb: CombineKeyValue, value: int seq) =
        CombineKeyValue(fun sb ->
            let sb = comb.Invoke(sb).Append("grid-template-rows: ")
            use e = value.GetEnumerator()

            if e.MoveNext() then
                sb.Append(e.Current).Append("px") |> ignore

                while e.MoveNext() do
                    sb.Append(" ").Append(e.Current).Append("px") |> ignore

            sb.Append("; "))

    /// Sets the width of a number of grid rows to the defined width
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: 1fr 10% 250px auto;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows ["1fr"]
    /// ```
    [<CustomOperation("gridTemplateRows")>]
    member inline _.gridTemplateRows([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("grid-template-rows", value)

    /// Sets the width of a number of grid rows to the defined width
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: repeat(3, 10%);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows (3, length.percent 10))
    /// ```
    [<CustomOperation("gridTemplateRows")>]
    member inline _.gridTemplateRows
        ([<InlineIfLambda>] comb: CombineKeyValue, count: int, size: string, ?areaName: string)
        =
        let areaName =
            match areaName with
            | Some n -> " [" + n + "]"
            | None -> ""

        CombineKeyValue(fun sb ->
            comb
                .Invoke(sb)
                .Append("grid-template-rows: ")
                .Append("repeat(")
                .Append(count)
                .Append(", ")
                .Append(size)
                .Append(areaName)
                .Append("); "))

    /// 2D representation of grid layout as blocks with names
    ///
    /// **CSS**
    /// ```css
    /// grid-template-areas:
    ///     'header header header header'
    ///     'nav nav . sidebar'
    ///     'footer footer footer footer';
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateAreas [
    ///     "header header header header"
    ///     "nav    nav    .      sidebar"
    ///     "footer footer footer footer"
    /// ]
    /// ```
    [<CustomOperation("gridTemplateAreas")>]
    member inline _.gridTemplateAreas([<InlineIfLambda>] comb: CombineKeyValue, value: string list) =
        CombineKeyValue(fun sb ->
            let sb = comb.Invoke(sb).Append("grid-template-areas: ")
            let mutable first = true

            for item in value do
                if first then first <- false else sb.Append(" ") |> ignore
                sb.Append("'").Append(item).Append("'") |> ignore

            sb.Append("; "))

    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the columns.
    ///
    /// **CSS**
    /// ```css
    /// column-gap: 10px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.columnGap 10
    /// ```
    [<CustomOperation("columnGap")>]
    member inline _.columnGap([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("column-gap", value)

    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the columns.
    ///
    /// **CSS**
    /// ```css
    /// column-gap: 1em;
    /// ```
    /// **F#**
    /// ```f#
    /// style.columnGap (length.em 1))
    /// ```
    [<CustomOperation("columnGap")>]
    member inline _.columnGap([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("column-gap", value)

    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows.
    ///
    /// **CSS**
    /// ```css
    /// row-gap: 10px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.rowGap 10
    /// ```
    [<CustomOperation("rowGap")>]
    member inline _.rowGap([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("row-gap", value)

    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows.
    ///
    /// **CSS**
    /// ```css
    /// row-gap: 1em;
    /// ```
    /// **F#**
    /// ```f#
    /// style.rowGap (length.em 1))
    /// ```
    [<CustomOperation("rowGap")>]
    member inline _.rowGap([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("row-gap", value)

    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 1em 2em;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap (length.em 1, length.em 2))
    /// ```
    [<CustomOperation("gap")>]
    member inline _.gap([<InlineIfLambda>] comb: CombineKeyValue, rowGap: string, columnGap: string) =
        CombineKeyValue(fun sb ->
            comb.Invoke(sb).Append("gap: ").Append(rowGap).Append(" ").Append(columnGap).Append("; "))

    /// Sets the gap (both row and column) to the same CSS length value.
    [<CustomOperation("gap")>]
    member inline _.gap([<InlineIfLambda>] comb: CombineKeyValue, gap: string) = comb &>> ("gap", gap)

    /// Sets the gap (both row and column) in pixels.
    [<CustomOperation("gap")>]
    member inline _.gap([<InlineIfLambda>] comb: CombineKeyValue, gap: int) = comb &>> ("gap", string gap + "px")

    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// When there are multiple named lines with the same name, you can specify which one by count
    ///
    /// **CSS**
    /// ```css
    /// grid-column-start: col 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnStart ("col", 2))
    /// ```
    [<CustomOperation("gridColumnStart")>]
    member inline _.gridColumnStart([<InlineIfLambda>] comb: CombineKeyValue, value: string, ?count: int) =
        CombineKeyValue(fun sb ->
            let sb' = comb.Invoke(sb).Append("grid-column-start: ").Append(value)

            (match count with
             | Some x -> sb'.Append(", ").Append(x)
             | _ -> sb')
                .Append("; "))

    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-column-start: 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnStart 2
    /// ```
    [<CustomOperation("gridColumnStart")>]
    member inline _.gridColumnStart([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkWithKV ("grid-column-start", value)

    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-column-start: span odd-col;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnStart (gridColumn.span "odd-col"))
    /// ```
    [<CustomOperation("gridColumnStart")>]
    member inline _.gridColumnStart([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("grid-column-start", value)

    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _When there are multiple named lines with the same name, you can specify which one by count_
    ///
    /// **CSS**
    /// ```css
    /// grid-column-end: odd-col 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnEnd ("odd-col", 2))
    /// ```
    [<CustomOperation("gridColumnEnd")>]
    member inline _.gridColumnEnd([<InlineIfLambda>] comb: CombineKeyValue, value: string, ?count: int) =
        CombineKeyValue(fun sb ->
            let sb' = comb.Invoke(sb).Append("grid-column-end: ").Append(value)

            (match count with
             | Some x -> sb'.Append(", ").Append(x)
             | _ -> sb')
                .Append("; "))

    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-column-end: 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnEnd 2
    /// ```
    [<CustomOperation("gridColumnEnd")>]
    member inline _.gridColumnEnd([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkWithKV ("grid-column-end", value)

    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-column-end: span 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnEnd (gridColumn.span 2))
    /// ```
    [<CustomOperation("gridColumnEnd")>]
    member inline _.gridColumnEnd([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("grid-column-end", value)

    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-row-start: col 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowStart ("col", 2))
    /// ```
    [<CustomOperation("gridRowStart")>]
    member inline _.gridRowStart([<InlineIfLambda>] comb: CombineKeyValue, value: string, ?count: int) =
        CombineKeyValue(fun sb ->
            let sb' = comb.Invoke(sb).Append("grid-row-start: ").Append(value)

            (match count with
             | Some x -> sb'.Append(", ").Append(x)
             | _ -> sb')
                .Append("; "))

    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-row-start: 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowStart 2
    /// ```
    [<CustomOperation("gridRowStart")>]
    member inline _.gridRowStart([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkWithKV ("grid-row-start", value)

    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-row-start: span odd-col;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowStart (gridRow.span "odd-col"))
    /// ```
    [<CustomOperation("gridRowStart")>]
    member inline _.gridRowStart([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("grid-row-start", value)

    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _When there are multiple named lines with the same name, you can specify which one by count_
    ///
    /// **CSS**
    /// ```css
    /// grid-row-end: odd-col 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowEnd ("odd-col", 2))
    /// ```
    [<CustomOperation("gridRowEnd")>]
    member inline _.gridRowEnd([<InlineIfLambda>] comb: CombineKeyValue, value: string, ?count: int) =
        CombineKeyValue(fun sb ->
            let sb' = comb.Invoke(sb).Append("grid-row-end: ").Append(value)

            (match count with
             | Some x -> sb'.Append(", ").Append(x)
             | _ -> sb')
                .Append("; "))

    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-row-end: 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowEnd 2
    /// ```
    [<CustomOperation("gridRowEnd")>]
    member inline _.gridRowEnd([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkWithKV ("grid-row-end", value)

    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-row-end: span 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowEnd (gridRow.span 2))
    /// ```
    [<CustomOperation("gridRowEnd")>]
    member inline _.gridRowEnd([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("grid-row-end", value)

    /// Determines a grid item��s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridColumnStart` and `gridColumnEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-column: col-2 / col-4;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumn ("col-2", "col-4"))
    /// ```
    [<CustomOperation("gridColumn")>]
    member inline _.gridColumn([<InlineIfLambda>] comb: CombineKeyValue, start: string, end': string) =
        CombineKeyValue(fun sb ->
            comb.Invoke(sb).Append("grid-column: ").Append(start).Append(" / ").Append(end').Append("; "))

    /// Determines a grid item��s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridColumnStart` and `gridColumnEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-column: 1 / 3;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumn (1, 3))
    /// ```
    [<CustomOperation("gridColumn")>]
    member inline _.gridColumn([<InlineIfLambda>] comb: CombineKeyValue, start: int, end': int) =
        comb &>> ("grid-column", string start + " / " + string end')

    /// Determines a grid item��s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridRowStart` and `gridRowEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-row: row-2 / row-4;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRow ("row-2", "row-4"))
    /// ```
    [<CustomOperation("gridRow")>]
    member inline _.gridRow([<InlineIfLambda>] comb: CombineKeyValue, start: string, end': string) =
        CombineKeyValue(fun sb ->
            comb.Invoke(sb).Append("grid-row: ").Append(start).Append(" / ").Append(end').Append("; "))

    /// Sets the named grid area the item is placed in
    ///
    /// **CSS**
    /// ```css
    /// grid-area: header;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridArea "header")
    /// ```
    [<CustomOperation("gridArea")>]
    member inline _.gridArea([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("grid-area", value)

    /// Shorthand for `grid-template-areas`, `grid-template-columns` and `grid-template-rows`.
    ///
    /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-template
    ///
    /// **CSS**
    /// ```css
    /// grid-template:  [header-top] 'a a a'      [header-bottom]
    ///                   [main-top] 'b b b' 1fr  [main-bottom]
    ///                              / auto 1fr auto;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplate "[header-top] 'a a a'      [header-bottom] " +
    ///                      "[main-top] 'b b b' 1fr  [main-bottom] " +
    ///                                "/ auto 1fr auto")
    /// ```
    [<CustomOperation("gridTemplate")>]
    member inline _.gridTemplate([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("grid-template", value)

    /// Sets the size of implicitly-created grid rows (e.g. "100px", "auto", "minmax(100px, auto)").
    [<CustomOperation("gridAutoRows")>]
    member inline _.gridAutoRows([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("grid-auto-rows", value)

    /// Sets the size of implicitly-created grid columns (e.g. "100px", "auto").
    [<CustomOperation("gridAutoColumns")>]
    member inline _.gridAutoColumns([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("grid-auto-columns", value)

    /// Sets how auto-placed items flow into the grid. Accepts row | column | dense | "row dense" etc. or a CSS variable.
    [<CustomOperation("gridAutoFlow")>]
    member inline _.gridAutoFlow([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("grid-auto-flow", value)

    /// Items are placed by filling each row in turn. This is default.
    [<CustomOperation("gridAutoFlowRow")>]
    member inline _.gridAutoFlowRow([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("grid-auto-flow", "row")

    /// Items are placed by filling each column in turn.
    [<CustomOperation("gridAutoFlowColumn")>]
    member inline _.gridAutoFlowColumn([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("grid-auto-flow", "column")

    /// Items are placed by rows, filling earlier holes with smaller items.
    [<CustomOperation("gridAutoFlowRowDense")>]
    member inline _.gridAutoFlowRowDense([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("grid-auto-flow", "row dense")

    /// Items are placed by columns, filling earlier holes with smaller items.
    [<CustomOperation("gridAutoFlowColumnDense")>]
    member inline _.gridAutoFlowColumnDense([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("grid-auto-flow", "column dense")

    /// Sets this property to its default value.
    [<CustomOperation("gridAutoFlowInitial")>]
    member inline _.gridAutoFlowInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("grid-auto-flow", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("gridAutoFlowInheritFromParent")>]
    member inline _.gridAutoFlowInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("grid-auto-flow", "inherit")

    /// Shorthand for grid-template-rows/columns/areas and grid-auto-rows/columns/flow.
    [<CustomOperation("grid")>]
    member inline _.grid([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("grid", value)


    /// Shorthand for column-width and column-count (multi-column layout).
    [<CustomOperation("columns")>]
    member inline _.columns([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("columns", value)

    /// Default. The width is determined by other properties (column-count).
    [<CustomOperation("columnWidthAuto")>]
    member inline _.columnWidthAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("column-width", "auto")

    /// Sets the ideal column width in a multi-column layout. Also accepts a length via the string overload.
    [<CustomOperation("columnWidth")>]
    member inline _.columnWidth([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("column-width", value)

    /// Sets this property to its default value.
    [<CustomOperation("columnWidthInitial")>]
    member inline _.columnWidthInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("column-width", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("columnWidthInheritFromParent")>]
    member inline _.columnWidthInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("column-width", "inherit")

    /// Sets the number of columns in a multi-column layout.
    [<CustomOperation("columnCount")>]
    member inline _.columnCount([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkWithKV ("column-count", value)

    /// Sets the number of columns in a multi-column layout.
    [<CustomOperation("columnCount")>]
    member inline _.columnCount([<InlineIfLambda>] comb: CombineKeyValue, value: float) =
        comb &&& mkWithKV ("column-count", value)

    /// Sets the number of columns in a multi-column layout.
    [<CustomOperation("columnCount")>]
    member inline _.columnCount([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("column-count", value)

    /// Default. Content is balanced between columns.
    [<CustomOperation("columnFillBalance")>]
    member inline _.columnFillBalance([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("column-fill", "balance")

    /// Columns are filled sequentially.
    [<CustomOperation("columnFillAuto")>]
    member inline _.columnFillAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("column-fill", "auto")

    /// Controls how content is partitioned into columns.
    [<CustomOperation("columnFill")>]
    member inline _.columnFill([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("column-fill", value)

    /// Sets this property to its default value.
    [<CustomOperation("columnFillInitial")>]
    member inline _.columnFillInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("column-fill", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("columnFillInheritFromParent")>]
    member inline _.columnFillInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("column-fill", "inherit")

    /// Default. The element does not span.
    [<CustomOperation("columnSpanNone")>]
    member inline _.columnSpanNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("column-span", "none")

    /// The element spans across all columns.
    [<CustomOperation("columnSpanAll")>]
    member inline _.columnSpanAll([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("column-span", "all")

    /// Makes an element span across all columns.
    [<CustomOperation("columnSpan")>]
    member inline _.columnSpan([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("column-span", value)

    /// Sets this property to its default value.
    [<CustomOperation("columnSpanInitial")>]
    member inline _.columnSpanInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("column-span", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("columnSpanInheritFromParent")>]
    member inline _.columnSpanInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("column-span", "inherit")

    /// Shorthand for column-rule-width, column-rule-style, and column-rule-color.
    [<CustomOperation("columnRule")>]
    member inline _.columnRule([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("column-rule", value)

    /// A thin rule.
    [<CustomOperation("columnRuleWidthThin")>]
    member inline _.columnRuleWidthThin([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("column-rule-width", "thin")

    /// Default. A medium rule.
    [<CustomOperation("columnRuleWidthMedium")>]
    member inline _.columnRuleWidthMedium([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("column-rule-width", "medium")

    /// A thick rule.
    [<CustomOperation("columnRuleWidthThick")>]
    member inline _.columnRuleWidthThick([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("column-rule-width", "thick")

    /// Sets the width of the rule between columns. Also accepts a length via the string overload.
    [<CustomOperation("columnRuleWidth")>]
    member inline _.columnRuleWidth([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("column-rule-width", value)

    /// Sets this property to its default value.
    [<CustomOperation("columnRuleWidthInitial")>]
    member inline _.columnRuleWidthInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("column-rule-width", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("columnRuleWidthInheritFromParent")>]
    member inline _.columnRuleWidthInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("column-rule-width", "inherit")

    /// Default. No rule.
    [<CustomOperation("columnRuleStyleNone")>]
    member inline _.columnRuleStyleNone([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("column-rule-style", "none")

    /// A hidden rule.
    [<CustomOperation("columnRuleStyleHidden")>]
    member inline _.columnRuleStyleHidden([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("column-rule-style", "hidden")

    /// A dotted rule.
    [<CustomOperation("columnRuleStyleDotted")>]
    member inline _.columnRuleStyleDotted([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("column-rule-style", "dotted")

    /// A dashed rule.
    [<CustomOperation("columnRuleStyleDashed")>]
    member inline _.columnRuleStyleDashed([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("column-rule-style", "dashed")

    /// A solid rule.
    [<CustomOperation("columnRuleStyleSolid")>]
    member inline _.columnRuleStyleSolid([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("column-rule-style", "solid")

    /// A double rule.
    [<CustomOperation("columnRuleStyleDouble")>]
    member inline _.columnRuleStyleDouble([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("column-rule-style", "double")

    /// A grooved rule.
    [<CustomOperation("columnRuleStyleGroove")>]
    member inline _.columnRuleStyleGroove([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("column-rule-style", "groove")

    /// A ridged rule.
    [<CustomOperation("columnRuleStyleRidge")>]
    member inline _.columnRuleStyleRidge([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("column-rule-style", "ridge")

    /// An inset rule.
    [<CustomOperation("columnRuleStyleInset")>]
    member inline _.columnRuleStyleInset([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("column-rule-style", "inset")

    /// An outset rule.
    [<CustomOperation("columnRuleStyleOutset")>]
    member inline _.columnRuleStyleOutset([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("column-rule-style", "outset")

    /// Sets the style of the rule between columns.
    [<CustomOperation("columnRuleStyle")>]
    member inline _.columnRuleStyle([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("column-rule-style", value)

    /// Sets this property to its default value.
    [<CustomOperation("columnRuleStyleInitial")>]
    member inline _.columnRuleStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("column-rule-style", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("columnRuleStyleInheritFromParent")>]
    member inline _.columnRuleStyleInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("column-rule-style", "inherit")

    /// Sets the color of the rule between columns.
    [<CustomOperation("columnRuleColor")>]
    member inline _.columnRuleColor([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("column-rule-color", value)





    // --------------------------------------------------------------------
    // Layout styles
    // --------------------------------------------------------------------


    /// Sets the height of an element.
    [<CustomOperation("height")>]
    member inline _.height([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& mkPxWithKV ("height", value)

    /// Sets the height of an element.
    [<CustomOperation("height")>]
    member inline _.height([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("height", value)

    /// Inherits this property from its parent element.
    [<CustomOperation("heightInheritFromParent")>]
    member inline _.heightInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("height", "inherit")

    /// Sets this property to its default value.
    [<CustomOperation("heightInitial")>]
    member inline _.heightInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("height", "initial")

    /// The intrinsic preferred height.
    [<CustomOperation("heightMaxContent")>]
    member inline _.heightMaxContent([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("height", "max-content")

    /// The intrinsic minimum height.
    [<CustomOperation("heightMinContent")>]
    member inline _.heightMinContent([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("height", "min-content")

    /// Sets the maximum height of an element.
    [<CustomOperation("maxHeight")>]
    member inline _.maxHeight([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("max-height", value)

    /// Sets the maximum height of an element.
    [<CustomOperation("maxHeight")>]
    member inline _.maxHeight([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("max-height", value)

    /// Inherits this property from its parent element.
    [<CustomOperation("maxHeightInheritFromParent")>]
    member inline _.maxHeightInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("max-height", "inherit")

    /// Sets this property to its default value.
    [<CustomOperation("maxHeightInitial")>]
    member inline _.maxHeightInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("max-height", "initial")

    /// The intrinsic preferred height.
    [<CustomOperation("maxHeightMaxContent")>]
    member inline _.maxHeightMaxContent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("max-height", "max-content")

    /// The intrinsic minimum height.
    [<CustomOperation("maxHeightMinContent")>]
    member inline _.maxHeightMinContent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("max-height", "min-content")

    /// Sets the minimum height of an element.
    [<CustomOperation("minHeight")>]
    member inline _.minHeight([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("min-height", value)

    /// Sets the minimum height of an element.
    [<CustomOperation("minHeight")>]
    member inline _.minHeight([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("min-height", value)

    /// Inherits this property from its parent element.
    [<CustomOperation("minHeightInheritFromParent")>]
    member inline _.minHeightInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("min-height", "inherit")

    /// Sets this property to its default value.
    [<CustomOperation("minHeightInitial")>]
    member inline _.minHeightInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("min-height", "initial")

    /// The intrinsic preferred height.
    [<CustomOperation("minHeightMaxContent")>]
    member inline _.minHeightMaxContent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("min-height", "max-content")

    /// The intrinsic minimum height.
    [<CustomOperation("minHeightMinContent")>]
    member inline _.minHeightMinContent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("min-height", "min-content")

    /// Allows a straight jump "scroll effect" between elements within the scrolling box. This is default
    [<CustomOperation("scrollBehaviorAuto")>]
    member inline _.scrollBehaviorAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("scroll-behavior", "auto")

    /// Allows a smooth animated "scroll effect" between elements within the scrolling box.
    [<CustomOperation("scrollBehaviorSmooth")>]
    member inline _.scrollBehaviorSmooth([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("scroll-behavior", "smooth")

    /// Sets this property to its default value.
    [<CustomOperation("scrollBehaviorInitial")>]
    member inline _.scrollBehaviorInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("scroll-behavior", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("scrollBehaviorInheritFromParent")>]
    member inline _.scrollBehaviorInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("scroll-behavior", "inherit")

    /// Sets the scroll behavior using a CSS string value (e.g. "smooth", "var(--scroll-behavior)").
    [<CustomOperation("scrollBehavior")>]
    member inline _.scrollBehavior([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("scroll-behavior", value)

    /// The content is not clipped, and it may be rendered outside the left and right edges. This is default.
    [<CustomOperation("overflowVisible")>]
    member inline _.overflowVisible([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("overflow", "visibile")

    /// The content is clipped - and no scrolling mechanism is provided.
    [<CustomOperation("overflowHidden")>]
    member inline _.overflowHidden([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("overflow", "hidden")

    /// The content is clipped and a scrolling mechanism is provided.
    [<CustomOperation("overflowScroll")>]
    member inline _.overflowScroll([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("overflow", "scroll")

    /// Should cause a scrolling mechanism to be provided for overflowing boxes
    [<CustomOperation("overflowAuto")>]
    member inline _.overflowAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("overflow", "auto")

    /// Sets this property to its default value.
    [<CustomOperation("overflowInitial")>]
    member inline _.overflowInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("overflow", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("overflowInheritFromParent")>]
    member inline _.overflowInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overflow", "inherit")

    /// Sets the overflow behavior using a CSS string value (e.g. "auto", "hidden scroll", "var(--overflow)").
    [<CustomOperation("overflow")>]
    member inline _.overflow([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("overflow", value)

    /// The content is not clipped, and it may be rendered outside the left and right edges. This is default.
    [<CustomOperation("overflowXVisible")>]
    member inline _.overflowXVisible([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("overflow-x", "visibile")

    /// The content is clipped - and no scrolling mechanism is provided.
    [<CustomOperation("overflowXHidden")>]
    member inline _.overflowXHidden([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("overflow-x", "hidden")

    /// The content is clipped and a scrolling mechanism is provided.
    [<CustomOperation("overflowXScroll")>]
    member inline _.overflowXScroll([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("overflow-x", "scroll")

    /// Should cause a scrolling mechanism to be provided for overflowing boxes
    [<CustomOperation("overflowXAuto")>]
    member inline _.overflowXAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("overflow-x", "auto")

    /// Sets this property to its default value.
    [<CustomOperation("overflowXInitial")>]
    member inline _.overflowXInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("overflow-x", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("overflowXInheritFromParent")>]
    member inline _.overflowXInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overflow-x", "inherit")

    /// Sets the overflow behavior of the horizontal direction using a CSS string value (e.g. "auto", "var(--overflow-x)").
    [<CustomOperation("overflowX")>]
    member inline _.overflowX([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("overflow-x", value)

    /// The content is not clipped, and it may be rendered outside the left and right edges. This is default.
    [<CustomOperation("overflowYVisible")>]
    member inline _.overflowYVisible([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("overflow-y", "visibile")

    /// The content is clipped - and no scrolling mechanism is provided.
    [<CustomOperation("overflowYHidden")>]
    member inline _.overflowYHidden([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("overflow-y", "hidden")

    /// The content is clipped and a scrolling mechanism is provided.
    [<CustomOperation("overflowYScroll")>]
    member inline _.overflowYScroll([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("overflow-y", "scroll")

    /// Should cause a scrolling mechanism to be provided for overflowing boxes
    [<CustomOperation("overflowYAuto")>]
    member inline _.overflowYAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("overflow-y", "auto")

    /// Sets this property to its default value.
    [<CustomOperation("overflowYInitial")>]
    member inline _.overflowYInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("overflow-y", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("overflowYInheritFromParent")>]
    member inline _.overflowYInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overflow-y", "inherit")

    /// Sets the overflow behavior of the vertical direction using a CSS string value (e.g. "auto", "var(--overflow-y)").
    [<CustomOperation("overflowY")>]
    member inline _.overflowY([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("overflow-y", value)

    /// The element must float on the left side of its containing block.
    [<Obsolete("Use floatStyleLeft instead for consistency with floatStyleInitial/floatStyleInheritFromParent")>]
    [<CustomOperation("floatLeft")>]
    member inline _.floatLeft([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("float", "left")

    /// The element must float on the right side of its containing block.
    [<Obsolete("Use floatStyleRight instead for consistency with floatStyleInitial/floatStyleInheritFromParent")>]
    [<CustomOperation("floatRight")>]
    member inline _.floatRight([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("float", "right")

    /// The element must not float.
    [<Obsolete("Use floatStyleNone instead for consistency with floatStyleInitial/floatStyleInheritFromParent")>]
    [<CustomOperation("floatNone")>]
    member inline _.floatNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("float", "none")

    /// The element does not float, (will be displayed just where it occurs in the text). This is default
    [<CustomOperation("floatStyleNone")>]
    member inline _.floatStyleNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("float", "none")

    /// The element floats to the left of its container.
    [<CustomOperation("floatStyleLeft")>]
    member inline _.floatStyleLeft([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("float", "left")

    /// The element floats to the right of its container.
    [<CustomOperation("floatStyleRight")>]
    member inline _.floatStyleRight([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("float", "right")

    /// Sets this property to its default value.
    [<CustomOperation("floatStyleInitial")>]
    member inline _.floatStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("float", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("floatStyleInheritFromParent")>]
    member inline _.floatStyleInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("float", "inherit")

    /// Sets the float behavior using a CSS string value (e.g. "left", "var(--float)").
    [<CustomOperation("floatStyle")>]
    member inline _.floatStyle([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("float", value)

    /// Default. Text can be selected if the browser allows it.
    [<CustomOperation("userSelectAuto")>]
    member inline _.userSelectAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("user-select", "auto")

    /// Prevents text selection.
    [<CustomOperation("userSelectNone")>]
    member inline _.userSelectNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("user-select", "none")

    /// The text can be selected by the user.
    [<CustomOperation("userSelectText")>]
    member inline _.userSelectText([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("user-select", "text")

    /// Text selection is made with one click instead of a double-click.
    [<CustomOperation("userSelectAll")>]
    member inline _.userSelectAll([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("user-select", "all")

    /// Sets this property to its default value.
    [<CustomOperation("userSelectInitial")>]
    member inline _.userSelectInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("user-select", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("userSelectInheritFromParent")>]
    member inline _.userSelectInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("user-select", "inherit")

    /// Sets whether the user can select text using a CSS string value (e.g. "none", "var(--user-select)").
    [<CustomOperation("userSelect")>]
    member inline _.userSelect([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("user-select", value)

    /// Specifies the mouse cursor to display when pointing over an element. Accepts a CSS cursor value (a keyword or a url()).
    [<CustomOperation("cursor")>]
    member inline _.cursor([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("cursor", value)

    /// The User Agent will determine the cursor to display based on the current context. E.g., equivalent to text when hovering text.
    [<CustomOperation("cursorAuto")>]
    member inline _.cursorAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "auto")

    /// The cursor indicates an alias of something is to be created
    [<CustomOperation("cursorAlias")>]
    member inline _.cursorAlias([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "alias")

    /// The platform-dependent default cursor. Typically an arrow.
    [<CustomOperation("cursorDefaultCursor")>]
    member inline _.cursorDefaultCursor([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "default")

    /// No cursor is rendered.
    [<CustomOperation("cursorNone")>]
    member inline _.cursorNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "none")

    /// A context menu is available.
    [<CustomOperation("cursorContextMenu")>]
    member inline _.cursorContextMenu([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "context-menu")

    /// Help information is available.
    [<CustomOperation("cursorHelp")>]
    member inline _.cursorHelp([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "help")

    /// The cursor is a pointer that indicates a link. Typically an image of a pointing hand.
    [<CustomOperation("cursorPointer")>]
    member inline _.cursorPointer([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "pointer")

    /// The program is busy in the background, but the user can still interact with the interface (in contrast to `wait`).
    [<CustomOperation("cursorProgress")>]
    member inline _.cursorProgress([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "progress")

    /// The program is busy, and the user can't interact with the interface (in contrast to progress). Sometimes an image of an hourglass or a watch.
    [<CustomOperation("cursorWait")>]
    member inline _.cursorWait([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "wait")

    /// The table cell or set of cells can be selected.
    [<CustomOperation("cursorCell")>]
    member inline _.cursorCell([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "cell")

    /// Cross cursor, often used to indicate selection in a bitmap.
    [<CustomOperation("cursorCrosshair")>]
    member inline _.cursorCrosshair([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "crosshair")

    /// The text can be selected. Typically the shape of an I-beam.
    [<CustomOperation("cursorText")>]
    member inline _.cursorText([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "text")

    /// The vertical text can be selected. Typically the shape of a sideways I-beam.
    [<CustomOperation("cursorVerticalText")>]
    member inline _.cursorVerticalText([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "vertical-text")

    /// Something is to be copied.
    [<CustomOperation("cursorCopy")>]
    member inline _.cursorCopy([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "copy")

    /// Something is to be moved.
    [<CustomOperation("cursorMove")>]
    member inline _.cursorMove([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "move")

    /// An item may not be dropped at the current location. On Windows and Mac OS X, `no-drop` is the same as `not-allowed`.
    [<CustomOperation("cursorNoDrop")>]
    member inline _.cursorNoDrop([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "no-drop")

    /// The requested action will not be carried out.
    [<CustomOperation("cursorNotAllowed")>]
    member inline _.cursorNotAllowed([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "not-allowed")

    /// Something can be grabbed (dragged to be moved).
    [<CustomOperation("cursorGrab")>]
    member inline _.cursorGrab([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "grab")

    /// Something is being grabbed (dragged to be moved).
    [<CustomOperation("cursorGrabbing")>]
    member inline _.cursorGrabbing([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "grabbing")

    /// Something can be scrolled in any direction (panned).
    [<CustomOperation("cursorAllScroll")>]
    member inline _.cursorAllScroll([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "all-scroll")

    /// The item/column can be resized horizontally. Often rendered as arrows pointing left and right with a vertical bar separating them.
    [<CustomOperation("cursorColumnResize")>]
    member inline _.cursorColumnResize([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "col-resize")

    /// The item/row can be resized vertically. Often rendered as arrows pointing up and down with a horizontal bar separating them.
    [<CustomOperation("cursorRowResize")>]
    member inline _.cursorRowResize([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "row-resize")

    /// Directional resize arrow
    [<CustomOperation("cursorNorthResize")>]
    member inline _.cursorNorthResize([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "n-resize")

    /// Directional resize arrow
    [<CustomOperation("cursorEastResize")>]
    member inline _.cursorEastResize([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "e-resize")

    /// Directional resize arrow
    [<CustomOperation("cursorSouthResize")>]
    member inline _.cursorSouthResize([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "s-resize")

    /// Directional resize arrow
    [<CustomOperation("cursorWestResize")>]
    member inline _.cursorWestResize([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "w-resize")

    /// Directional resize arrow
    [<CustomOperation("cursorNorthEastResize")>]
    member inline _.cursorNorthEastResize([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "ne-resize")

    /// Directional resize arrow
    [<CustomOperation("cursorNorthWestResize")>]
    member inline _.cursorNorthWestResize([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "nw-resize")

    /// Directional resize arrow
    [<CustomOperation("cursorSouthEastResize")>]
    member inline _.cursorSouthEastResize([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "se-resize")

    /// Directional resize arrow
    [<CustomOperation("cursorSouthWestResize")>]
    member inline _.cursorSouthWestResize([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "sw-resize")

    /// Directional resize arrow
    [<CustomOperation("cursorEastWestResize")>]
    member inline _.cursorEastWestResize([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "ew-resize")

    /// Directional resize arrow
    [<CustomOperation("cursorNorthSouthResize")>]
    member inline _.cursorNorthSouthResize([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "ns-resize")

    /// Directional resize arrow
    [<CustomOperation("cursorNorthEastSouthWestResize")>]
    member inline _.cursorNorthEastSouthWestResize([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("cursor", "nesw-resize")

    /// Directional resize arrow
    [<CustomOperation("cursorNorthWestSouthEastResize")>]
    member inline _.cursorNorthWestSouthEastResize([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("cursor", "nwse-resize")

    /// Something can be zoomed (magnified) in
    [<CustomOperation("cursorZoomIn")>]
    member inline _.cursorZoomIn([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "zoom-in")

    /// Something can be zoomed out
    [<CustomOperation("cursorZoomOut")>]
    member inline _.cursorZoomOut([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("cursor", "zoom-out")

    /// Default value. Elements render in order, as they appear in the document flow.
    [<Obsolete("Use positionStatic instead")>]
    [<CustomOperation("positionDefaultStatic")>]
    member inline _.positionDefaultStatic([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("position", "static")

    /// Default value. Elements render in order, as they appear in the document flow.
    [<CustomOperation("positionStatic")>]
    member inline _.positionStatic([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("position", "static")

    /// The element is positioned relative to its first positioned (not static) ancestor element.
    [<CustomOperation("positionAbsolute")>]
    member inline _.positionAbsolute([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("position", "absolute")

    /// The element is positioned relative to the browser window
    [<CustomOperation("positionFixed")>]
    member inline _.positionFixed([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("position", "fixed")

    /// The element is positioned relative to its normal position, so "left:20px" adds 20 pixels to the element's LEFT position.
    [<CustomOperation("positionRelative")>]
    member inline _.positionRelative([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("position", "relative")

    /// The element is positioned based on the user's scroll position
    ///
    /// A sticky element toggles between relative and fixed, depending on the scroll position. It is positioned relative until a given offset position is met in the viewport - then it "sticks" in place (like position:fixed).
    ///
    /// Note: Not supported in IE/Edge 15 or earlier. Supported in Safari from version 6.1 with a -webkit- prefix.
    [<CustomOperation("positionSticky")>]
    member inline _.positionSticky([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("position", "sticky")

    /// Sets this property to its default value.
    [<CustomOperation("positionInitial")>]
    member inline _.positionInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("position", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("positionInheritFromParent")>]
    member inline _.positionInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("position", "inherit")

    /// Sets the positioning method using a CSS string value (e.g. "absolute", "var(--position)").
    [<CustomOperation("position")>]
    member inline _.position([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("position", value)

    /// Default value. The width and height properties include the content, but does not include the padding, border, or margin.
    [<CustomOperation("boxSizingContentBox")>]
    member inline _.boxSizingContentBox([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("box-sizing", "content-box")

    /// The width and height properties include the content, padding, and border, but do not include the margin. Note that padding and border will be inside of the box.
    [<CustomOperation("boxSizingBorderBox")>]
    member inline _.boxSizingBorderBox([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("box-sizing", "border-box")

    /// Sets this property to its default value.
    [<CustomOperation("boxSizingInitial")>]
    member inline _.boxSizingInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("box-sizing", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("boxSizingInheritFromParent")>]
    member inline _.boxSizingInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("box-sizing", "inherit")

    /// Sets how the total width and height is calculated using a CSS string value (e.g. "border-box", "var(--box-sizing)").
    [<CustomOperation("boxSizing")>]
    member inline _.boxSizing([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("box-sizing", value)

    /// Default value. The element offers no user-controllable method for resizing it.
    [<CustomOperation("resizeNone")>]
    member inline _.resizeNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("resize", "none")

    /// The element displays a mechanism for allowing the user to resize it, which may be resized both horizontally and vertically.
    [<CustomOperation("resizeBoth")>]
    member inline _.resizeBoth([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("resize", "both")

    /// The element displays a mechanism for allowing the user to resize it in the horizontal direction.
    [<CustomOperation("resizeHorizontal")>]
    member inline _.resizeHorizontal([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("resize", "horizontal")

    /// The element displays a mechanism for allowing the user to resize it in the vertical direction.
    [<CustomOperation("resizeVertical")>]
    member inline _.resizeVertical([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("resize", "vertical")

    /// The element displays a mechanism for allowing the user to resize it in the block direction (either horizontally or vertically, depending on the writing-mode and direction value).
    [<CustomOperation("resizeBlock")>]
    member inline _.resizeBlock([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("resize", "block")

    /// The element displays a mechanism for allowing the user to resize it in the inline direction (either horizontally or vertically, depending on the writing-mode and direction value).
    [<Obsolete("Use resizeInlineValue instead")>]
    [<CustomOperation("resizeInline'")>]
    member inline _.resizeInline'([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("resize", "inline")

    /// The element can be resized in the inline direction (horizontally, in horizontal writing modes).
    [<CustomOperation("resizeInlineValue")>]
    member inline _.resizeInlineValue([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("resize", "inline")

    /// Sets this property to its default value.
    [<CustomOperation("resizeInitial")>]
    member inline _.resizeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("resize", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("resizeInheritFromParent")>]
    member inline _.resizeInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("resize", "inherit")

    /// Sets whether an element is resizable using a CSS string value (e.g. "both", "var(--resize)").
    [<CustomOperation("resize")>]
    member inline _.resize([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("resize", value)

    /// Displays an element as an inline element (like `<span> `). Any height and width properties will have no effect.
    [<Obsolete("Use displayInline instead")>]
    [<CustomOperation("displayInlineElement")>]
    member inline _.displayInlineElement([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("display", "inline")

    /// Displays an element as an inline element (like `<span> `). Any height and width properties will have no effect.
    [<CustomOperation("displayInline")>]
    member inline _.displayInline([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("display", "inline")

    /// Displays an element as a block element (like `<p> `). It starts on a new line, and takes up the whole width.
    [<CustomOperation("displayBlock")>]
    member inline _.displayBlock([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("display", "block")

    /// Makes the container disappear, making the child elements children of the element the next level up in the DOM.
    [<CustomOperation("displayContents")>]
    member inline _.displayContents([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("display", "contents")

    /// Displays an element as a block-level flex container.
    [<CustomOperation("displayFlex")>]
    member inline _.displayFlex([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("display", "flex")

    /// Displays an element as a block container box, and lays out its contents using flow layout.
    ///
    /// It always establishes a new block formatting context for its contents.
    [<CustomOperation("displayFlowRoot")>]
    member inline _.displayFlowRoot([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("display", "flow-root")

    /// Displays an element as a block-level grid container.
    [<CustomOperation("displayGrid")>]
    member inline _.displayGrid([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("display", "grid")

    /// Displays an element as an inline-level block container. The element itself is formatted as an inline element, but you can apply height and width values.
    [<CustomOperation("displayInlineBlock")>]
    member inline _.displayInlineBlock([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("display", "inline-block")

    /// Displays an element as an inline-level flex container.
    [<CustomOperation("displayInlineFlex")>]
    member inline _.displayInlineFlex([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("display", "inline-flex")

    /// Displays an element as an inline-level grid container
    [<CustomOperation("displayInlineGrid")>]
    member inline _.displayInlineGrid([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("display", "inline-grid")

    /// The element is displayed as an inline-level table.
    [<CustomOperation("displayInlineTable")>]
    member inline _.displayInlineTable([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("display", "inline-table")

    /// Let the element behave like a `<li> ` element
    [<CustomOperation("displayListItem")>]
    member inline _.displayListItem([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("display", "list-item")

    /// Displays an element as either block or inline, depending on context.
    [<CustomOperation("displayRunIn")>]
    member inline _.displayRunIn([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("display", "run-in")

    /// Let the element behave like a `<table> ` element.
    [<CustomOperation("displayTable")>]
    member inline _.displayTable([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("display", "table")

    /// Let the element behave like a <caption> element.
    [<CustomOperation("displayTableCaption")>]
    member inline _.displayTableCaption([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("display", "table-caption")

    /// Let the element behave like a <colgroup> element.
    [<CustomOperation("displayTableColumnGroup")>]
    member inline _.displayTableColumnGroup([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("display", "table-column-group")

    /// Let the element behave like a <thead> element.
    [<CustomOperation("displayTableHeaderGroup")>]
    member inline _.displayTableHeaderGroup([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("display", "table-header-group")

    /// Let the element behave like a <tfoot> element.
    [<CustomOperation("displayTableFooterGroup")>]
    member inline _.displayTableFooterGroup([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("display", "table-footer-group")

    /// Let the element behave like a <tbody> element.
    [<CustomOperation("displayTableRowGroup")>]
    member inline _.displayTableRowGroup([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("display", "table-row-group")

    /// Let the element behave like a <td> element.
    [<CustomOperation("displayTableCell")>]
    member inline _.displayTableCell([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("display", "table-cell")

    /// Let the element behave like a <col> element.
    [<CustomOperation("displayTableColumn")>]
    member inline _.displayTableColumn([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("display", "table-column")

    /// Let the element behave like a <tr> element.
    [<CustomOperation("displayTableRow")>]
    member inline _.displayTableRow([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("display", "table-row")

    /// The element is completely removed.
    [<CustomOperation("displayNone")>]
    member inline _.displayNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("display", "none")

    /// Sets this property to its default value.
    [<CustomOperation("displayInitial")>]
    member inline _.displayInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("display", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("displayInheritFromParent")>]
    member inline _.displayInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("display", "inherit")

    /// Sets the display behavior using a CSS string value (e.g. "flex", "var(--display)").
    [<CustomOperation("display")>]
    member inline _.display([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("display", value)

    /// The zIndex property sets or returns the stack order of a positioned element.
    ///
    /// An element with greater stack order (1) is always in front of another element with lower stack order (0).
    ///
    /// **Tip**: A positioned element is an element with the position property set to: relative, absolute, or fixed.
    ///
    /// **Tip**: This property is useful if you want to create overlapping elements.
    [<CustomOperation("zIndex")>]
    member inline _.zIndex([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& mkWithKV ("z-index", value)

    /// Specifies the vertical position of a positioned element. It has no effect on non-positioned elements.
    [<CustomOperation("top")>]
    member inline _.top([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& mkPxWithKV ("top", value)

    /// Specifies the vertical position of a positioned element. It has no effect on non-positioned elements.
    [<CustomOperation("top")>]
    member inline _.top([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("top", value)

    /// Specifies the vertical position of a positioned element. It has no effect on non-positioned elements.
    [<CustomOperation("bottom")>]
    member inline _.bottom([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& mkPxWithKV ("bottom", value)

    /// Specifies the vertical position of a positioned element. It has no effect on non-positioned elements.
    [<CustomOperation("bottom")>]
    member inline _.bottom([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("bottom", value)

    /// Specifies the horizontal position of a positioned element. It has no effect on non-positioned elements.
    [<CustomOperation("left")>]
    member inline _.left([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& mkPxWithKV ("left", value)

    /// Specifies the horizontal position of a positioned element. It has no effect on non-positioned elements.
    [<CustomOperation("left")>]
    member inline _.left([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("left", value)

    /// Specifies the horizontal position of a positioned element. It has no effect on non-positioned elements.
    [<CustomOperation("right")>]
    member inline _.right([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& mkPxWithKV ("right", value)

    /// Specifies the horizontal position of a positioned element. It has no effect on non-positioned elements.
    [<CustomOperation("right")>]
    member inline _.right([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("right", value)

    /// Sets the minimum width of an element.
    ///
    /// It prevents the used value of the width property from becoming smaller than the value specified for min-width.
    [<CustomOperation("minWidth")>]
    member inline _.minWidth([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("min-width", value)

    /// Sets the minimum width of an element.
    ///
    /// It prevents the used value of the width property from becoming smaller than the value specified for min-width.
    [<CustomOperation("minWidth")>]
    member inline _.minWidth([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("min-width", value)

    /// Sets the maximum width of an element.
    ///
    /// It prevents the used value of the width property from becoming larger than the value specified by max-width.
    [<CustomOperation("maxWidth")>]
    member inline _.maxWidth([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("max-width", value)

    /// Sets the maximum width of an element.
    ///
    /// It prevents the used value of the width property from becoming larger than the value specified by max-width.
    [<CustomOperation("maxWidth")>]
    member inline _.maxWidth([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("max-width", value)

    /// Sets the width of an element.
    ///
    /// By default, the property defines the width of the content area.
    [<CustomOperation("width")>]
    member inline _.width([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& mkPxWithKV ("width", value)

    /// Sets the width of an element.
    ///
    /// By default, the property defines the width of the content area.
    [<CustomOperation("width")>]
    member inline _.width([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("width", value)

    /// Shorthand for top/right/bottom/left (e.g. "0", "10px 20px", "var(--inset)").
    [<CustomOperation("inset")>]
    member inline _.inset([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("inset", value)

    /// Shorthand for top/right/bottom/left in pixels.
    [<CustomOperation("inset")>]
    member inline _.inset([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& mkPxWithKV ("inset", value)

    /// Sets the preferred aspect ratio (e.g. "16 / 9", "1", "auto").
    [<CustomOperation("aspectRatio")>]
    member inline _.aspectRatio([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("aspect-ratio", value)

    /// Sets layout/style/paint containment. Accepts none | strict | content | size | layout | style | paint or a CSS variable.
    [<CustomOperation("contain")>]
    member inline _.contain([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("contain", value)

    /// No containment. This is default.
    [<CustomOperation("containNone")>]
    member inline _.containNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("contain", "none")

    /// All containment rules applied.
    [<CustomOperation("containStrict")>]
    member inline _.containStrict([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("contain", "strict")

    /// All containment except size.
    [<CustomOperation("containContent")>]
    member inline _.containContent([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("contain", "content")

    /// Size containment.
    [<CustomOperation("containSize")>]
    member inline _.containSize([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("contain", "size")

    /// Layout containment.
    [<CustomOperation("containLayout")>]
    member inline _.containLayout([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("contain", "layout")

    /// Paint containment.
    [<CustomOperation("containPaint")>]
    member inline _.containPaint([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("contain", "paint")

    /// Sets this property to its default value.
    [<CustomOperation("containInitial")>]
    member inline _.containInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("contain", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("containInheritFromParent")>]
    member inline _.containInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("contain", "inherit")

    /// Sets the block-start margin (top in horizontal-tb). Accepts a CSS length or variable.
    [<CustomOperation("marginBlockStart")>]
    member inline _.marginBlockStart([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("margin-block-start", value)

    /// Sets the block-start margin in pixels.
    [<CustomOperation("marginBlockStart")>]
    member inline _.marginBlockStart([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("margin-block-start", value)

    /// Sets the block-end margin (bottom in horizontal-tb). Accepts a CSS length or variable.
    [<CustomOperation("marginBlockEnd")>]
    member inline _.marginBlockEnd([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("margin-block-end", value)

    /// Sets the block-end margin in pixels.
    [<CustomOperation("marginBlockEnd")>]
    member inline _.marginBlockEnd([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("margin-block-end", value)

    /// Sets the inline-start margin (left in ltr). Accepts a CSS length or variable.
    [<CustomOperation("marginInlineStart")>]
    member inline _.marginInlineStart([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("margin-inline-start", value)

    /// Sets the inline-start margin in pixels.
    [<CustomOperation("marginInlineStart")>]
    member inline _.marginInlineStart([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("margin-inline-start", value)

    /// Sets the inline-end margin (right in ltr). Accepts a CSS length or variable.
    [<CustomOperation("marginInlineEnd")>]
    member inline _.marginInlineEnd([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("margin-inline-end", value)

    /// Sets the inline-end margin in pixels.
    [<CustomOperation("marginInlineEnd")>]
    member inline _.marginInlineEnd([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("margin-inline-end", value)

    /// Sets the block-start padding. Accepts a CSS length or variable.
    [<CustomOperation("paddingBlockStart")>]
    member inline _.paddingBlockStart([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("padding-block-start", value)

    /// Sets the block-start padding in pixels.
    [<CustomOperation("paddingBlockStart")>]
    member inline _.paddingBlockStart([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("padding-block-start", value)

    /// Sets the block-end padding. Accepts a CSS length or variable.
    [<CustomOperation("paddingBlockEnd")>]
    member inline _.paddingBlockEnd([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("padding-block-end", value)

    /// Sets the block-end padding in pixels.
    [<CustomOperation("paddingBlockEnd")>]
    member inline _.paddingBlockEnd([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("padding-block-end", value)

    /// Sets the inline-start padding. Accepts a CSS length or variable.
    [<CustomOperation("paddingInlineStart")>]
    member inline _.paddingInlineStart([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("padding-inline-start", value)

    /// Sets the inline-start padding in pixels.
    [<CustomOperation("paddingInlineStart")>]
    member inline _.paddingInlineStart([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("padding-inline-start", value)

    /// Sets the inline-end padding. Accepts a CSS length or variable.
    [<CustomOperation("paddingInlineEnd")>]
    member inline _.paddingInlineEnd([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("padding-inline-end", value)

    /// Sets the inline-end padding in pixels.
    [<CustomOperation("paddingInlineEnd")>]
    member inline _.paddingInlineEnd([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("padding-inline-end", value)

    /// Sets the scroll snap position of the element. Accepts none | start | end | center | "block start" etc. or a CSS variable.
    [<CustomOperation("scrollSnapAlign")>]
    member inline _.scrollSnapAlign([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("scroll-snap-align", value)

    /// No snap position. This is default.
    [<CustomOperation("scrollSnapAlignNone")>]
    member inline _.scrollSnapAlignNone([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("scroll-snap-align", "none")

    /// Snaps to the start edge.
    [<CustomOperation("scrollSnapAlignStart")>]
    member inline _.scrollSnapAlignStart([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("scroll-snap-align", "start")

    /// Snaps to the end edge.
    [<CustomOperation("scrollSnapAlignEnd")>]
    member inline _.scrollSnapAlignEnd([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("scroll-snap-align", "end")

    /// Snaps to the center.
    [<CustomOperation("scrollSnapAlignCenter")>]
    member inline _.scrollSnapAlignCenter([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("scroll-snap-align", "center")

    /// Sets this property to its default value.
    [<CustomOperation("scrollSnapAlignInitial")>]
    member inline _.scrollSnapAlignInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("scroll-snap-align", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("scrollSnapAlignInheritFromParent")>]
    member inline _.scrollSnapAlignInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("scroll-snap-align", "inherit")

    /// Sets how strictly snap points are enforced. Accepts none | x | y | block | inline | both | mandatory | proximity or a combined string/CSS variable.
    [<CustomOperation("scrollSnapType")>]
    member inline _.scrollSnapType([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("scroll-snap-type", value)

    /// No snapping. This is default.
    [<CustomOperation("scrollSnapTypeNone")>]
    member inline _.scrollSnapTypeNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("scroll-snap-type", "none")

    /// Mandatory snapping on the x axis.
    [<CustomOperation("scrollSnapTypeXMandatory")>]
    member inline _.scrollSnapTypeXMandatory([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("scroll-snap-type", "x mandatory")

    /// Proximity snapping on the x axis.
    [<CustomOperation("scrollSnapTypeXProximity")>]
    member inline _.scrollSnapTypeXProximity([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("scroll-snap-type", "x proximity")

    /// Mandatory snapping on the y axis.
    [<CustomOperation("scrollSnapTypeYMandatory")>]
    member inline _.scrollSnapTypeYMandatory([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("scroll-snap-type", "y mandatory")

    /// Proximity snapping on the y axis.
    [<CustomOperation("scrollSnapTypeYProximity")>]
    member inline _.scrollSnapTypeYProximity([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("scroll-snap-type", "y proximity")

    /// Mandatory snapping on both axes.
    [<CustomOperation("scrollSnapTypeBothMandatory")>]
    member inline _.scrollSnapTypeBothMandatory([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("scroll-snap-type", "both mandatory")

    /// Sets this property to its default value.
    [<CustomOperation("scrollSnapTypeInitial")>]
    member inline _.scrollSnapTypeInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("scroll-snap-type", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("scrollSnapTypeInheritFromParent")>]
    member inline _.scrollSnapTypeInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("scroll-snap-type", "inherit")

    /// Sets whether the scroll may pass over a snap position. Accepts normal | always or a CSS variable.
    [<CustomOperation("scrollSnapStop")>]
    member inline _.scrollSnapStop([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("scroll-snap-stop", value)

    /// Snap positions may be passed. This is default.
    [<CustomOperation("scrollSnapStopNormal")>]
    member inline _.scrollSnapStopNormal([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("scroll-snap-stop", "normal")

    /// Snap positions must not be passed.
    [<CustomOperation("scrollSnapStopAlways")>]
    member inline _.scrollSnapStopAlways([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("scroll-snap-stop", "always")

    /// Sets this property to its default value.
    [<CustomOperation("scrollSnapStopInitial")>]
    member inline _.scrollSnapStopInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("scroll-snap-stop", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("scrollSnapStopInheritFromParent")>]
    member inline _.scrollSnapStopInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("scroll-snap-stop", "inherit")

    /// Shorthand for all scroll-margin properties (e.g. "10px", "10px 20px").
    [<CustomOperation("scrollMargin")>]
    member inline _.scrollMargin([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("scroll-margin", value)

    /// Shorthand for all scroll-padding properties (e.g. "10px", "10px 20px").
    [<CustomOperation("scrollPadding")>]
    member inline _.scrollPadding([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("scroll-padding", value)


    /// Default. The element is not moved below floating elements.
    [<CustomOperation("clearNone")>]
    member inline _.clearNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("clear", "none")

    /// The element is moved below left-floating elements.
    [<CustomOperation("clearLeft")>]
    member inline _.clearLeft([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("clear", "left")

    /// The element is moved below right-floating elements.
    [<CustomOperation("clearRight")>]
    member inline _.clearRight([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("clear", "right")

    /// The element is moved below both left and right-floating elements.
    [<CustomOperation("clearBoth")>]
    member inline _.clearBoth([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("clear", "both")

    /// The element is moved below floats on the inline-start side.
    [<CustomOperation("clearInlineStart")>]
    member inline _.clearInlineStart([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("clear", "inline-start")

    /// The element is moved below floats on the inline-end side.
    [<CustomOperation("clearInlineEnd")>]
    member inline _.clearInlineEnd([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("clear", "inline-end")

    /// Sets whether an element must be moved below (cleared) floating elements that precede it.
    [<CustomOperation("clear")>]
    member inline _.clear([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("clear", value)

    /// Sets this property to its default value.
    [<CustomOperation("clearInitial")>]
    member inline _.clearInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("clear", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("clearInheritFromParent")>]
    member inline _.clearInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("clear", "inherit")

    /// Default. The content is sized to fill the element's content box, stretching if necessary.
    [<CustomOperation("objectFitFill")>]
    member inline _.objectFitFill([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("object-fit", "fill")

    /// The content is scaled to maintain its aspect ratio while fitting within the content box.
    [<CustomOperation("objectFitContain")>]
    member inline _.objectFitContain([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("object-fit", "contain")

    /// The content is sized to maintain its aspect ratio while filling the entire content box, clipping to fit.
    [<CustomOperation("objectFitCover")>]
    member inline _.objectFitCover([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("object-fit", "cover")

    /// The content is not resized.
    [<CustomOperation("objectFitNone")>]
    member inline _.objectFitNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("object-fit", "none")

    /// The content is sized as if none or contain were specified, whichever results in a smaller concrete object size.
    [<CustomOperation("objectFitScaleDown")>]
    member inline _.objectFitScaleDown([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("object-fit", "scale-down")

    /// Sets how the content of a replaced element (e.g. img or video) should be resized to fit its container.
    [<CustomOperation("objectFit")>]
    member inline _.objectFit([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("object-fit", value)

    /// Sets this property to its default value.
    [<CustomOperation("objectFitInitial")>]
    member inline _.objectFitInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("object-fit", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("objectFitInheritFromParent")>]
    member inline _.objectFitInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("object-fit", "inherit")

    /// Specifies the alignment of a replaced element's contents within the element's box (e.g. "50% 50%", "top right").
    [<CustomOperation("objectPosition")>]
    member inline _.objectPosition([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("object-position", value)

    /// Default. The element behaves as it would if pointer-events were not specified.
    [<CustomOperation("pointerEventsAuto")>]
    member inline _.pointerEventsAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("pointer-events", "auto")

    /// The element is never the target of pointer events.
    [<CustomOperation("pointerEventsNone")>]
    member inline _.pointerEventsNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("pointer-events", "none")

    /// Sets under what circumstances an element can become the target of pointer events.
    [<CustomOperation("pointerEvents")>]
    member inline _.pointerEvents([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("pointer-events", value)

    /// Sets this property to its default value.
    [<CustomOperation("pointerEventsInitial")>]
    member inline _.pointerEventsInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("pointer-events", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("pointerEventsInheritFromParent")>]
    member inline _.pointerEventsInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("pointer-events", "inherit")

    /// Default. Enable all touch behaviors.
    [<CustomOperation("touchActionAuto")>]
    member inline _.touchActionAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("touch-action", "auto")

    /// Disable all touch behaviors.
    [<CustomOperation("touchActionNone")>]
    member inline _.touchActionNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("touch-action", "none")

    /// Enable horizontal single-finger panning.
    [<CustomOperation("touchActionPanX")>]
    member inline _.touchActionPanX([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("touch-action", "pan-x")

    /// Enable vertical single-finger panning.
    [<CustomOperation("touchActionPanY")>]
    member inline _.touchActionPanY([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("touch-action", "pan-y")

    /// Enable panning and pinch-zoom, but disable double-tap zooming.
    [<CustomOperation("touchActionManipulation")>]
    member inline _.touchActionManipulation([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("touch-action", "manipulation")

    /// Sets how an element's region can be manipulated by a touchscreen user (e.g. panning, zooming).
    [<CustomOperation("touchAction")>]
    member inline _.touchAction([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("touch-action", value)

    /// Sets this property to its default value.
    [<CustomOperation("touchActionInitial")>]
    member inline _.touchActionInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("touch-action", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("touchActionInheritFromParent")>]
    member inline _.touchActionInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("touch-action", "inherit")

    /// Default. No particular optimization is expressed.
    [<CustomOperation("willChangeAuto")>]
    member inline _.willChangeAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("will-change", "auto")

    /// The element's scroll position is expected to change.
    [<CustomOperation("willChangeScrollPosition")>]
    member inline _.willChangeScrollPosition([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("will-change", "scroll-position")

    /// The element's contents are expected to change.
    [<CustomOperation("willChangeContents")>]
    member inline _.willChangeContents([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("will-change", "contents")

    /// The element's transform is expected to change.
    [<CustomOperation("willChangeTransform")>]
    member inline _.willChangeTransform([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("will-change", "transform")

    /// The element's opacity is expected to change.
    [<CustomOperation("willChangeOpacity")>]
    member inline _.willChangeOpacity([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("will-change", "opacity")

    /// Hints to the browser how an element is expected to change, so it can optimize ahead of time.
    [<CustomOperation("willChange")>]
    member inline _.willChange([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("will-change", value)

    /// Sets this property to its default value.
    [<CustomOperation("willChangeInitial")>]
    member inline _.willChangeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("will-change", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("willChangeInheritFromParent")>]
    member inline _.willChangeInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("will-change", "inherit")

    /// Default. The default scroll overflow behavior occurs.
    [<CustomOperation("overscrollBehaviorAuto")>]
    member inline _.overscrollBehaviorAuto([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overscroll-behavior", "auto")

    /// No scroll chaining to neighboring scrolling areas.
    [<CustomOperation("overscrollBehaviorContain")>]
    member inline _.overscrollBehaviorContain([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overscroll-behavior", "contain")

    /// No scroll chaining and no default affordances (e.g. pull-to-refresh).
    [<CustomOperation("overscrollBehaviorNone")>]
    member inline _.overscrollBehaviorNone([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overscroll-behavior", "none")

    /// Sets what a browser does when reaching the boundary of a scrolling area (shorthand for overscroll-behavior-x/y).
    [<CustomOperation("overscrollBehavior")>]
    member inline _.overscrollBehavior([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("overscroll-behavior", value)

    /// Sets this property to its default value.
    [<CustomOperation("overscrollBehaviorInitial")>]
    member inline _.overscrollBehaviorInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overscroll-behavior", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("overscrollBehaviorInheritFromParent")>]
    member inline _.overscrollBehaviorInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overscroll-behavior", "inherit")

    /// Default.
    [<CustomOperation("overscrollBehaviorXAuto")>]
    member inline _.overscrollBehaviorXAuto([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overscroll-behavior-x", "auto")

    /// No scroll chaining horizontally.
    [<CustomOperation("overscrollBehaviorXContain")>]
    member inline _.overscrollBehaviorXContain([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overscroll-behavior-x", "contain")

    /// No scroll chaining or affordances horizontally.
    [<CustomOperation("overscrollBehaviorXNone")>]
    member inline _.overscrollBehaviorXNone([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overscroll-behavior-x", "none")

    /// Sets the browser's behavior when the horizontal boundary of a scrolling area is reached.
    [<CustomOperation("overscrollBehaviorX")>]
    member inline _.overscrollBehaviorX([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("overscroll-behavior-x", value)

    /// Sets this property to its default value.
    [<CustomOperation("overscrollBehaviorXInitial")>]
    member inline _.overscrollBehaviorXInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overscroll-behavior-x", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("overscrollBehaviorXInheritFromParent")>]
    member inline _.overscrollBehaviorXInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overscroll-behavior-x", "inherit")

    /// Default.
    [<CustomOperation("overscrollBehaviorYAuto")>]
    member inline _.overscrollBehaviorYAuto([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overscroll-behavior-y", "auto")

    /// No scroll chaining vertically.
    [<CustomOperation("overscrollBehaviorYContain")>]
    member inline _.overscrollBehaviorYContain([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overscroll-behavior-y", "contain")

    /// No scroll chaining or affordances vertically.
    [<CustomOperation("overscrollBehaviorYNone")>]
    member inline _.overscrollBehaviorYNone([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overscroll-behavior-y", "none")

    /// Sets the browser's behavior when the vertical boundary of a scrolling area is reached.
    [<CustomOperation("overscrollBehaviorY")>]
    member inline _.overscrollBehaviorY([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("overscroll-behavior-y", value)

    /// Sets this property to its default value.
    [<CustomOperation("overscrollBehaviorYInitial")>]
    member inline _.overscrollBehaviorYInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overscroll-behavior-y", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("overscrollBehaviorYInheritFromParent")>]
    member inline _.overscrollBehaviorYInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overscroll-behavior-y", "inherit")

    /// Default. A new stacking context is created only if needed.
    [<CustomOperation("isolationAuto")>]
    member inline _.isolationAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("isolation", "auto")

    /// The element creates a new stacking context.
    [<CustomOperation("isolationIsolate")>]
    member inline _.isolationIsolate([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("isolation", "isolate")

    /// Determines whether an element must create a new stacking context.
    [<CustomOperation("isolation")>]
    member inline _.isolation([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("isolation", value)

    /// Sets this property to its default value.
    [<CustomOperation("isolationInitial")>]
    member inline _.isolationInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("isolation", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("isolationInheritFromParent")>]
    member inline _.isolationInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("isolation", "inherit")

    /// Default. No blending.
    [<CustomOperation("mixBlendModeNormal")>]
    member inline _.mixBlendModeNormal([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("mix-blend-mode", "normal")

    /// Multiply blend.
    [<CustomOperation("mixBlendModeMultiply")>]
    member inline _.mixBlendModeMultiply([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("mix-blend-mode", "multiply")

    /// Screen blend.
    [<CustomOperation("mixBlendModeScreen")>]
    member inline _.mixBlendModeScreen([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("mix-blend-mode", "screen")

    /// Overlay blend.
    [<CustomOperation("mixBlendModeOverlay")>]
    member inline _.mixBlendModeOverlay([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("mix-blend-mode", "overlay")

    /// Darken blend.
    [<CustomOperation("mixBlendModeDarken")>]
    member inline _.mixBlendModeDarken([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("mix-blend-mode", "darken")

    /// Lighten blend.
    [<CustomOperation("mixBlendModeLighten")>]
    member inline _.mixBlendModeLighten([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("mix-blend-mode", "lighten")

    /// Color-dodge blend.
    [<CustomOperation("mixBlendModeColorDodge")>]
    member inline _.mixBlendModeColorDodge([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("mix-blend-mode", "color-dodge")

    /// Color-burn blend.
    [<CustomOperation("mixBlendModeColorBurn")>]
    member inline _.mixBlendModeColorBurn([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("mix-blend-mode", "color-burn")

    /// Hard-light blend.
    [<CustomOperation("mixBlendModeHardLight")>]
    member inline _.mixBlendModeHardLight([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("mix-blend-mode", "hard-light")

    /// Soft-light blend.
    [<CustomOperation("mixBlendModeSoftLight")>]
    member inline _.mixBlendModeSoftLight([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("mix-blend-mode", "soft-light")

    /// Difference blend.
    [<CustomOperation("mixBlendModeDifference")>]
    member inline _.mixBlendModeDifference([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("mix-blend-mode", "difference")

    /// Exclusion blend.
    [<CustomOperation("mixBlendModeExclusion")>]
    member inline _.mixBlendModeExclusion([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("mix-blend-mode", "exclusion")

    /// Hue blend.
    [<CustomOperation("mixBlendModeHue")>]
    member inline _.mixBlendModeHue([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("mix-blend-mode", "hue")

    /// Saturation blend.
    [<CustomOperation("mixBlendModeSaturation")>]
    member inline _.mixBlendModeSaturation([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("mix-blend-mode", "saturation")

    /// Color blend.
    [<CustomOperation("mixBlendModeColor")>]
    member inline _.mixBlendModeColor([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("mix-blend-mode", "color")

    /// Luminosity blend.
    [<CustomOperation("mixBlendModeLuminosity")>]
    member inline _.mixBlendModeLuminosity([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("mix-blend-mode", "luminosity")

    /// Sets how an element's content should blend with the content of the element's parent and background.
    [<CustomOperation("mixBlendMode")>]
    member inline _.mixBlendMode([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("mix-blend-mode", value)

    /// Sets this property to its default value.
    [<CustomOperation("mixBlendModeInitial")>]
    member inline _.mixBlendModeInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("mix-blend-mode", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("mixBlendModeInheritFromParent")>]
    member inline _.mixBlendModeInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("mix-blend-mode", "inherit")

    /// Default. Content is not clipped.
    [<CustomOperation("overflowBlockVisible")>]
    member inline _.overflowBlockVisible([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overflow-block", "visible")

    /// Content is clipped.
    [<CustomOperation("overflowBlockHidden")>]
    member inline _.overflowBlockHidden([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overflow-block", "hidden")

    /// A scrollbar is always shown.
    [<CustomOperation("overflowBlockScroll")>]
    member inline _.overflowBlockScroll([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overflow-block", "scroll")

    /// A scrollbar is shown only when needed.
    [<CustomOperation("overflowBlockAuto")>]
    member inline _.overflowBlockAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("overflow-block", "auto")

    /// Sets what shows when content overflows the block-start and block-end edges of a box.
    [<CustomOperation("overflowBlock")>]
    member inline _.overflowBlock([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("overflow-block", value)

    /// Sets this property to its default value.
    [<CustomOperation("overflowBlockInitial")>]
    member inline _.overflowBlockInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overflow-block", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("overflowBlockInheritFromParent")>]
    member inline _.overflowBlockInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overflow-block", "inherit")

    /// Default. Content is not clipped.
    [<CustomOperation("overflowInlineVisible")>]
    member inline _.overflowInlineVisible([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overflow-inline", "visible")

    /// Content is clipped.
    [<CustomOperation("overflowInlineHidden")>]
    member inline _.overflowInlineHidden([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overflow-inline", "hidden")

    /// A scrollbar is always shown.
    [<CustomOperation("overflowInlineScroll")>]
    member inline _.overflowInlineScroll([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overflow-inline", "scroll")

    /// A scrollbar is shown only when needed.
    [<CustomOperation("overflowInlineAuto")>]
    member inline _.overflowInlineAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("overflow-inline", "auto")

    /// Sets what shows when content overflows the inline-start and inline-end edges of a box.
    [<CustomOperation("overflowInline")>]
    member inline _.overflowInline([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("overflow-inline", value)

    /// Sets this property to its default value.
    [<CustomOperation("overflowInlineInitial")>]
    member inline _.overflowInlineInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overflow-inline", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("overflowInlineInheritFromParent")>]
    member inline _.overflowInlineInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overflow-inline", "inherit")

    /// Generates content for a pseudo-element or replaces an element's content (e.g. "normal", "none", a quoted string, or a counter).
    [<CustomOperation("content")>]
    member inline _.content([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("content", value)

    /// Default. No perspective transform is applied.
    [<CustomOperation("perspectiveNone")>]
    member inline _.perspectiveNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("perspective", "none")

    /// Determines the distance between the z=0 plane and the user to give a 3D-positioned element some perspective. Also accepts a length (use the string overload, e.g. "500px").
    [<CustomOperation("perspective")>]
    member inline _.perspective([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("perspective", value)

    /// Sets this property to its default value.
    [<CustomOperation("perspectiveInitial")>]
    member inline _.perspectiveInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("perspective", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("perspectiveInheritFromParent")>]
    member inline _.perspectiveInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("perspective", "inherit")

    /// Determines the position at which the viewer is looking (the vanishing point for the perspective property, e.g. "50% 50%").
    [<CustomOperation("perspectiveOrigin")>]
    member inline _.perspectiveOrigin([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("perspective-origin", value)

    /// Sets the intrinsic size used when an element is subject to size containment (shorthand).
    [<CustomOperation("containIntrinsicSize")>]
    member inline _.containIntrinsicSize([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("contain-intrinsic-size", value)

    /// Sets the intrinsic width used when an element is subject to size containment.
    [<CustomOperation("containIntrinsicWidth")>]
    member inline _.containIntrinsicWidth([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("contain-intrinsic-width", value)

    /// Sets the intrinsic height used when an element is subject to size containment.
    [<CustomOperation("containIntrinsicHeight")>]
    member inline _.containIntrinsicHeight([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("contain-intrinsic-height", value)

    /// Default.
    [<CustomOperation("breakBeforeAuto")>]
    member inline _.breakBeforeAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-before", "auto")

    /// Avoid any break before.
    [<CustomOperation("breakBeforeAvoid")>]
    member inline _.breakBeforeAvoid([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-before", "avoid")

    /// Always break before.
    [<CustomOperation("breakBeforeAlways")>]
    member inline _.breakBeforeAlways([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-before", "always")

    /// Force breaks through all fragmentation contexts.
    [<CustomOperation("breakBeforeAll")>]
    member inline _.breakBeforeAll([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-before", "all")

    /// Avoid a page break before.
    [<CustomOperation("breakBeforeAvoidPage")>]
    member inline _.breakBeforeAvoidPage([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("break-before", "avoid-page")

    /// Force a page break before.
    [<CustomOperation("breakBeforePage")>]
    member inline _.breakBeforePage([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-before", "page")

    /// Force one or two page breaks so the next page is a left page.
    [<CustomOperation("breakBeforeLeft")>]
    member inline _.breakBeforeLeft([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-before", "left")

    /// Force one or two page breaks so the next page is a right page.
    [<CustomOperation("breakBeforeRight")>]
    member inline _.breakBeforeRight([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-before", "right")

    /// Force breaks so the next page is a recto page.
    [<CustomOperation("breakBeforeRecto")>]
    member inline _.breakBeforeRecto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-before", "recto")

    /// Force breaks so the next page is a verso page.
    [<CustomOperation("breakBeforeVerso")>]
    member inline _.breakBeforeVerso([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-before", "verso")

    /// Avoid a column break before.
    [<CustomOperation("breakBeforeAvoidColumn")>]
    member inline _.breakBeforeAvoidColumn([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("break-before", "avoid-column")

    /// Force a column break before.
    [<CustomOperation("breakBeforeColumn")>]
    member inline _.breakBeforeColumn([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-before", "column")

    /// Avoid a region break before.
    [<CustomOperation("breakBeforeAvoidRegion")>]
    member inline _.breakBeforeAvoidRegion([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("break-before", "avoid-region")

    /// Force a region break before.
    [<CustomOperation("breakBeforeRegion")>]
    member inline _.breakBeforeRegion([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-before", "region")

    /// Sets how page, column, or region breaks should occur before the generated box.
    [<CustomOperation("breakBefore")>]
    member inline _.breakBefore([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("break-before", value)

    /// Sets this property to its default value.
    [<CustomOperation("breakBeforeInitial")>]
    member inline _.breakBeforeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-before", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("breakBeforeInheritFromParent")>]
    member inline _.breakBeforeInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("break-before", "inherit")

    /// Default.
    [<CustomOperation("breakAfterAuto")>]
    member inline _.breakAfterAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-after", "auto")

    /// Avoid any break after.
    [<CustomOperation("breakAfterAvoid")>]
    member inline _.breakAfterAvoid([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-after", "avoid")

    /// Always break after.
    [<CustomOperation("breakAfterAlways")>]
    member inline _.breakAfterAlways([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-after", "always")

    /// Force breaks through all fragmentation contexts.
    [<CustomOperation("breakAfterAll")>]
    member inline _.breakAfterAll([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-after", "all")

    /// Avoid a page break after.
    [<CustomOperation("breakAfterAvoidPage")>]
    member inline _.breakAfterAvoidPage([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("break-after", "avoid-page")

    /// Force a page break after.
    [<CustomOperation("breakAfterPage")>]
    member inline _.breakAfterPage([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-after", "page")

    /// Force breaks so the next page is a left page.
    [<CustomOperation("breakAfterLeft")>]
    member inline _.breakAfterLeft([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-after", "left")

    /// Force breaks so the next page is a right page.
    [<CustomOperation("breakAfterRight")>]
    member inline _.breakAfterRight([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-after", "right")

    /// Force breaks so the next page is a recto page.
    [<CustomOperation("breakAfterRecto")>]
    member inline _.breakAfterRecto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-after", "recto")

    /// Force breaks so the next page is a verso page.
    [<CustomOperation("breakAfterVerso")>]
    member inline _.breakAfterVerso([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-after", "verso")

    /// Avoid a column break after.
    [<CustomOperation("breakAfterAvoidColumn")>]
    member inline _.breakAfterAvoidColumn([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("break-after", "avoid-column")

    /// Force a column break after.
    [<CustomOperation("breakAfterColumn")>]
    member inline _.breakAfterColumn([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-after", "column")

    /// Avoid a region break after.
    [<CustomOperation("breakAfterAvoidRegion")>]
    member inline _.breakAfterAvoidRegion([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("break-after", "avoid-region")

    /// Force a region break after.
    [<CustomOperation("breakAfterRegion")>]
    member inline _.breakAfterRegion([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-after", "region")

    /// Sets how page, column, or region breaks should occur after the generated box.
    [<CustomOperation("breakAfter")>]
    member inline _.breakAfter([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("break-after", value)

    /// Sets this property to its default value.
    [<CustomOperation("breakAfterInitial")>]
    member inline _.breakAfterInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-after", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("breakAfterInheritFromParent")>]
    member inline _.breakAfterInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("break-after", "inherit")

    /// Default.
    [<CustomOperation("breakInsideAuto")>]
    member inline _.breakInsideAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-inside", "auto")

    /// Avoid any break inside.
    [<CustomOperation("breakInsideAvoid")>]
    member inline _.breakInsideAvoid([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-inside", "avoid")

    /// Avoid a page break inside.
    [<CustomOperation("breakInsideAvoidPage")>]
    member inline _.breakInsideAvoidPage([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("break-inside", "avoid-page")

    /// Avoid a column break inside.
    [<CustomOperation("breakInsideAvoidColumn")>]
    member inline _.breakInsideAvoidColumn([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("break-inside", "avoid-column")

    /// Avoid a region break inside.
    [<CustomOperation("breakInsideAvoidRegion")>]
    member inline _.breakInsideAvoidRegion([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("break-inside", "avoid-region")

    /// Sets how page, column, or region breaks should occur inside the generated box.
    [<CustomOperation("breakInside")>]
    member inline _.breakInside([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("break-inside", value)

    /// Sets this property to its default value.
    [<CustomOperation("breakInsideInitial")>]
    member inline _.breakInsideInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("break-inside", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("breakInsideInheritFromParent")>]
    member inline _.breakInsideInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("break-inside", "inherit")

    /// Default.
    [<CustomOperation("pageBreakBeforeAuto")>]
    member inline _.pageBreakBeforeAuto([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("page-break-before", "auto")

    /// Always break before.
    [<CustomOperation("pageBreakBeforeAlways")>]
    member inline _.pageBreakBeforeAlways([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("page-break-before", "always")

    /// Avoid a page break before.
    [<CustomOperation("pageBreakBeforeAvoid")>]
    member inline _.pageBreakBeforeAvoid([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("page-break-before", "avoid")

    /// Force breaks so the next page is a left page.
    [<CustomOperation("pageBreakBeforeLeft")>]
    member inline _.pageBreakBeforeLeft([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("page-break-before", "left")

    /// Force breaks so the next page is a right page.
    [<CustomOperation("pageBreakBeforeRight")>]
    member inline _.pageBreakBeforeRight([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("page-break-before", "right")

    /// Legacy alias of break-before. Sets how page breaks occur before the element.
    [<CustomOperation("pageBreakBefore")>]
    member inline _.pageBreakBefore([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("page-break-before", value)

    /// Sets this property to its default value.
    [<CustomOperation("pageBreakBeforeInitial")>]
    member inline _.pageBreakBeforeInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("page-break-before", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("pageBreakBeforeInheritFromParent")>]
    member inline _.pageBreakBeforeInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("page-break-before", "inherit")

    /// Default.
    [<CustomOperation("pageBreakAfterAuto")>]
    member inline _.pageBreakAfterAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("page-break-after", "auto")

    /// Always break after.
    [<CustomOperation("pageBreakAfterAlways")>]
    member inline _.pageBreakAfterAlways([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("page-break-after", "always")

    /// Avoid a page break after.
    [<CustomOperation("pageBreakAfterAvoid")>]
    member inline _.pageBreakAfterAvoid([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("page-break-after", "avoid")

    /// Force breaks so the next page is a left page.
    [<CustomOperation("pageBreakAfterLeft")>]
    member inline _.pageBreakAfterLeft([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("page-break-after", "left")

    /// Force breaks so the next page is a right page.
    [<CustomOperation("pageBreakAfterRight")>]
    member inline _.pageBreakAfterRight([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("page-break-after", "right")

    /// Legacy alias of break-after. Sets how page breaks occur after the element.
    [<CustomOperation("pageBreakAfter")>]
    member inline _.pageBreakAfter([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("page-break-after", value)

    /// Sets this property to its default value.
    [<CustomOperation("pageBreakAfterInitial")>]
    member inline _.pageBreakAfterInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("page-break-after", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("pageBreakAfterInheritFromParent")>]
    member inline _.pageBreakAfterInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("page-break-after", "inherit")

    /// Default.
    [<CustomOperation("pageBreakInsideAuto")>]
    member inline _.pageBreakInsideAuto([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("page-break-inside", "auto")

    /// Avoid a page break inside.
    [<CustomOperation("pageBreakInsideAvoid")>]
    member inline _.pageBreakInsideAvoid([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("page-break-inside", "avoid")

    /// Legacy alias of break-inside. Sets how page breaks occur inside the element.
    [<CustomOperation("pageBreakInside")>]
    member inline _.pageBreakInside([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("page-break-inside", value)

    /// Sets this property to its default value.
    [<CustomOperation("pageBreakInsideInitial")>]
    member inline _.pageBreakInsideInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("page-break-inside", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("pageBreakInsideInheritFromParent")>]
    member inline _.pageBreakInsideInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("page-break-inside", "inherit")

    /// Sets the top scroll snap margin.
    [<CustomOperation("scrollMarginTop")>]
    member inline _.scrollMarginTop([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("scroll-margin-top", value)

    /// Sets the right scroll snap margin.
    [<CustomOperation("scrollMarginRight")>]
    member inline _.scrollMarginRight([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("scroll-margin-right", value)

    /// Sets the bottom scroll snap margin.
    [<CustomOperation("scrollMarginBottom")>]
    member inline _.scrollMarginBottom([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("scroll-margin-bottom", value)

    /// Sets the left scroll snap margin.
    [<CustomOperation("scrollMarginLeft")>]
    member inline _.scrollMarginLeft([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("scroll-margin-left", value)

    /// Sets the top scroll snap padding.
    [<CustomOperation("scrollPaddingTop")>]
    member inline _.scrollPaddingTop([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("scroll-padding-top", value)

    /// Sets the right scroll snap padding.
    [<CustomOperation("scrollPaddingRight")>]
    member inline _.scrollPaddingRight([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("scroll-padding-right", value)

    /// Sets the bottom scroll snap padding.
    [<CustomOperation("scrollPaddingBottom")>]
    member inline _.scrollPaddingBottom([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("scroll-padding-bottom", value)

    /// Sets the left scroll snap padding.
    [<CustomOperation("scrollPaddingLeft")>]
    member inline _.scrollPaddingLeft([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("scroll-padding-left", value)





    // --------------------------------------------------------------------
    // List styles
    // --------------------------------------------------------------------


    /// Default value. The marker is a filled circle
    [<CustomOperation("listStyleTypeDisc")>]
    member inline _.listStyleTypeDisc([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("list-style-type", "disc")

    /// The marker is traditional Armenian numbering
    [<CustomOperation("listStyleTypeArmenian")>]
    member inline _.listStyleTypeArmenian([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "armenian")

    /// The marker is a circle
    [<CustomOperation("listStyleTypeCircle")>]
    member inline _.listStyleTypeCircle([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "circle")

    /// The marker is plain ideographic numbers
    [<CustomOperation("listStyleTypeCjkIdeographic")>]
    member inline _.listStyleTypeCjkIdeographic([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "cjk-ideographic")

    /// The marker is a number
    [<CustomOperation("listStyleTypeDecimal")>]
    member inline _.listStyleTypeDecimal([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "decimal")

    /// The marker is a number with leading zeros (01, 02, 03, etc.))
    [<CustomOperation("listStyleTypeDecimalLeadingZero")>]
    member inline _.listStyleTypeDecimalLeadingZero([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "decimal-leading-zero")

    /// The marker is traditional Georgian numbering
    [<CustomOperation("listStyleTypeGeorgian")>]
    member inline _.listStyleTypeGeorgian([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "georgian")

    /// The marker is traditional Hebrew numbering
    [<CustomOperation("listStyleTypeHebrew")>]
    member inline _.listStyleTypeHebrew([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "hebrew")

    /// The marker is traditional Hiragana numbering
    [<CustomOperation("listStyleTypeHiragana")>]
    member inline _.listStyleTypeHiragana([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "hiragana")

    /// The marker is traditional Hiragana iroha numbering
    [<CustomOperation("listStyleTypeHiraganaIroha")>]
    member inline _.listStyleTypeHiraganaIroha([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "hiragana-iroha")

    /// The marker is traditional Katakana numbering
    [<CustomOperation("listStyleTypeKatakana")>]
    member inline _.listStyleTypeKatakana([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "katakana")

    /// The marker is traditional Katakana iroha numbering
    [<CustomOperation("listStyleTypeKatakanaIroha")>]
    member inline _.listStyleTypeKatakanaIroha([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "katakana-iroha")

    /// The marker is lower-alpha (a, b, c, d, e, etc.))
    [<CustomOperation("listStyleTypeLowerAlpha")>]
    member inline _.listStyleTypeLowerAlpha([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "lower-alpha")

    /// The marker is lower-greek
    [<CustomOperation("listStyleTypeLowerGreek")>]
    member inline _.listStyleTypeLowerGreek([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "lower-greek")

    /// The marker is lower-latin (a, b, c, d, e, etc.))
    [<CustomOperation("listStyleTypeLowerLatin")>]
    member inline _.listStyleTypeLowerLatin([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "lower-latin")

    /// The marker is lower-roman (i, ii, iii, iv, v, etc.))
    [<CustomOperation("listStyleTypeLowerRoman")>]
    member inline _.listStyleTypeLowerRoman([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "lower-roman")

    /// No marker is shown
    [<CustomOperation("listStyleTypeNone")>]
    member inline _.listStyleTypeNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("list-style-type", "none")

    /// The marker is a square
    [<CustomOperation("listStyleTypeSquare")>]
    member inline _.listStyleTypeSquare([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "square")

    /// The marker is upper-alpha (A, B, C, D, E, etc.))
    [<CustomOperation("listStyleTypeUpperAlpha")>]
    member inline _.listStyleTypeUpperAlpha([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "upper-alpha")

    /// The marker is upper-greek
    [<CustomOperation("listStyleTypeUpperGreek")>]
    member inline _.listStyleTypeUpperGreek([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "upper-greek")

    /// The marker is upper-latin (A, B, C, D, E, etc.))
    [<CustomOperation("listStyleTypeUpperLatin")>]
    member inline _.listStyleTypeUpperLatin([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "upper-latin")

    /// The marker is upper-roman (I, II, III, IV, V, etc.))
    [<CustomOperation("listStyleTypeUpperRoman")>]
    member inline _.listStyleTypeUpperRoman([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "upper-roman")

    /// Sets this property to its default value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
    [<CustomOperation("listStyleTypeInitial")>]
    member inline _.listStyleTypeInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "initial")

    /// Inherits this property from its parent element.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
    [<CustomOperation("listStyleTypeInheritFromParent")>]
    member inline _.listStyleTypeInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-type", "inherit")

    /// Sets the list item marker type using a CSS string value (e.g. "disc", "var(--list-style-type)").
    [<CustomOperation("listStyleType")>]
    member inline _.listStyleType([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("list-style-type", value)

    /// Removes the list-style-image marker.
    [<CustomOperation("propertyNone")>]
    member inline _.propertyNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("list-style-image", "none")

    /// The path to the image to be used as a list-item marker
    [<CustomOperation("propertyUrl")>]
    member inline _.propertyUrl([<InlineIfLambda>] comb: CombineKeyValue, path: string) =
        comb
        &&& CombineKeyValue(fun sb -> sb.Append("list-style-image: url(").Append(path).Append("); "))

    /// Sets this property to its default value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
    [<CustomOperation("propertyInitial")>]
    member inline _.propertyInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-image", "initial")

    /// Inherits this property from its parent element.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
    [<CustomOperation("propertyInheritFromParent")>]
    member inline _.propertyInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-image", "inherit")

    /// The bullet points will be inside the list item
    [<CustomOperation("listStylePositionInside")>]
    member inline _.listStylePositionInside([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-position", "inside")

    /// The bullet points will be outside the list item. This is default
    [<CustomOperation("listStylePositionOutside")>]
    member inline _.listStylePositionOutside([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-position", "outside")

    /// Sets this property to its default value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
    [<CustomOperation("listStylePositionInitial")>]
    member inline _.listStylePositionInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-position", "initial")

    /// Inherits this property from its parent element.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
    [<CustomOperation("listStylePositionInheritFromParent")>]
    member inline _.listStylePositionInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("list-style-position", "inherit")

    /// Sets the position of the list item marker using a CSS string value (e.g. "inside", "var(--list-style-position)").
    [<CustomOperation("listStylePosition")>]
    member inline _.listStylePosition([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("list-style-position", value)

    /// Shorthand for list-style-type, list-style-position and list-style-image (e.g. "square inside").
    [<CustomOperation("listStyle")>]
    member inline _.listStyle([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("list-style", value)


    /// Resets a CSS counter to a given value (e.g. "section", "item 0").
    [<CustomOperation("counterReset")>]
    member inline _.counterReset([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("counter-reset", value)

    /// Increases or decreases a CSS counter (e.g. "section", "item 2").
    [<CustomOperation("counterIncrement")>]
    member inline _.counterIncrement([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("counter-increment", value)

    /// Sets a CSS counter to a given value (e.g. "section 5").
    [<CustomOperation("counterSet")>]
    member inline _.counterSet([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("counter-set", value)





    // --------------------------------------------------------------------
    // Table styles
    // --------------------------------------------------------------------


    /// Browsers use an automatic table layout algorithm. The column width is set by the widest unbreakable
    /// content in the cells. The content will dictate the layout
    [<CustomOperation("tableLayoutAuto")>]
    member inline _.tableLayoutAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("table-layout", "auto")

    /// Sets a fixed table layout algorithm. The table and column widths are set by the widths of table and col
    /// or by the width of the first row of cells. Cells in other rows do not affect column widths. If no widths
    /// are present on the first row, the column widths are divided equally across the table, regardless of content
    /// inside the cells
    [<Obsolete("Use tableLayoutFixed instead")>]
    [<CustomOperation("tableLayoutFixed'")>]
    member inline _.tableLayoutFixed'([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("table-layout", "fixed")

    /// Sets a fixed table layout algorithm. The table and column widths are set by the widths of table and col elements or by the width of the first row of cells.
    [<CustomOperation("tableLayoutFixed")>]
    member inline _.tableLayoutFixed([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("table-layout", "fixed")

    /// Sets this property to its default value.
    [<CustomOperation("tableLayoutInitial")>]
    member inline _.tableLayoutInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("table-layout", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("tableLayoutInheritFromParent")>]
    member inline _.tableLayoutInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("table-layout", "inherit")

    /// Sets the table layout algorithm using a CSS string value (e.g. "fixed", "var(--table-layout)").
    [<CustomOperation("tableLayout")>]
    member inline _.tableLayout([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("table-layout", value)

    /// Display borders on empty cells. This is default
    [<CustomOperation("emptyCellsShow")>]
    member inline _.emptyCellsShow([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("empty-cells", "show")

    /// Hide borders on empty cells
    [<CustomOperation("emptyCellsHide")>]
    member inline _.emptyCellsHide([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("empty-cells", "hide")

    /// Sets this property to its default value)
    [<CustomOperation("emptyCellsInitial")>]
    member inline _.emptyCellsInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("empty-cells", "initial")

    /// Inherits this property from its parent element
    [<CustomOperation("emptyCellsInheritFromParent")>]
    member inline _.emptyCellsInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("empty-cells", "inherit")

    /// Sets whether empty table cells show borders using a CSS string value (e.g. "hide", "var(--empty-cells)").
    [<CustomOperation("emptyCells")>]
    member inline _.emptyCells([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("empty-cells", value)


    /// Default. The caption box is above the table.
    [<CustomOperation("captionSideTop")>]
    member inline _.captionSideTop([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("caption-side", "top")

    /// The caption box is below the table.
    [<CustomOperation("captionSideBottom")>]
    member inline _.captionSideBottom([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("caption-side", "bottom")

    /// The caption box is at the block-start edge.
    [<CustomOperation("captionSideBlockStart")>]
    member inline _.captionSideBlockStart([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("caption-side", "block-start")

    /// The caption box is at the block-end edge.
    [<CustomOperation("captionSideBlockEnd")>]
    member inline _.captionSideBlockEnd([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("caption-side", "block-end")

    /// The caption box is at the inline-start edge.
    [<CustomOperation("captionSideInlineStart")>]
    member inline _.captionSideInlineStart([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("caption-side", "inline-start")

    /// The caption box is at the inline-end edge.
    [<CustomOperation("captionSideInlineEnd")>]
    member inline _.captionSideInlineEnd([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("caption-side", "inline-end")

    /// Positions the table caption box on the specified side.
    [<CustomOperation("captionSide")>]
    member inline _.captionSide([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("caption-side", value)

    /// Sets this property to its default value.
    [<CustomOperation("captionSideInitial")>]
    member inline _.captionSideInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("caption-side", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("captionSideInheritFromParent")>]
    member inline _.captionSideInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("caption-side", "inherit")





    // --------------------------------------------------------------------
    // Transform styles
    // --------------------------------------------------------------------


    /// Specifies that child elements will NOT preserve its 3D position. This is default.
    [<CustomOperation("transformStyleFlat")>]
    member inline _.transformStyleFlat([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("transform-style", "flat")

    /// Specifies that child elements will preserve its 3D position
    [<CustomOperation("transformStylePreserve3D")>]
    member inline _.transformStylePreserve3D([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transform-style", "preserve-3d")

    /// Sets this property to its default value.
    [<CustomOperation("transformStyleInitial")>]
    member inline _.transformStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transform-style", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("transformStyleInheritFromParent")>]
    member inline _.transformStyleInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transform-style", "inherit")

    /// Sets how nested elements are rendered in 3D space using a CSS string value (e.g. "preserve-3d", "var(--transform-style)").
    [<CustomOperation("transformStyle")>]
    member inline _.transformStyle([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("transform-style", value)

    /// Applies a 2D or 3D transformation to an element. Accepts a CSS transform value (e.g. "rotate(45deg)", "translate(10px, 20px)", "scale(1.5)").
    [<CustomOperation("transform")>]
    member inline _.transform([<InlineIfLambda>] comb: CombineKeyValue, transformation: string) =
        comb &>> ("transform", transformation)

    /// Defines that there should be no transformation.
    [<CustomOperation("transformNone")>]
    member inline _.transformNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("transform", "none")

    /// Allows you to change the position of transformed elements.
    [<CustomOperation("transformOrigin")>]
    member inline _.transformOrigin([<InlineIfLambda>] comb: CombineKeyValue, x: string) =
        comb &>> ("transform-origin", x)

    /// Allows you to change the position of transformed elements, using separate x and y values.
    [<CustomOperation("transformOrigin")>]
    member inline _.transformOrigin([<InlineIfLambda>] comb: CombineKeyValue, x: string, y: string) =
        CombineKeyValue(fun sb ->
            comb.Invoke(sb).Append("transform-origin: ").Append(x).Append(" ").Append(y).Append("; "))

    /// Defines a 2D transformation, using a matrix of six values.
    [<CustomOperation("transformMatrix")>]
    member inline _.transformMatrix
        ([<InlineIfLambda>] comb: CombineKeyValue, x1: int, y1: int, z1: int, x2: int, y2: int, z2: int)
        =
        CombineKeyValue(fun sb ->
            comb
                .Invoke(sb)
                .Append("transform: ")
                .Append("matrix(")
                .Append(x1)
                .Append(",")
                .Append(y1)
                .Append(",")
                .Append(z1)
                .Append(",")
                .Append(x2)
                .Append(",")
                .Append(y2)
                .Append(",")
                .Append(z2)
                .Append("); "))

    /// Defines a 2D translation.
    [<CustomOperation("transformTranslate")>]
    member inline _.transformTranslate([<InlineIfLambda>] comb: CombineKeyValue, x: int, y: int) =
        CombineKeyValue(fun sb ->
            comb
                .Invoke(sb)
                .Append("transform: ")
                .Append("translate(")
                .Append(x)
                .Append("px, ")
                .Append(y)
                .Append("px); "))

    /// Defines a 2D translation.
    [<CustomOperation("transformTranslate")>]
    member inline _.transformTranslate([<InlineIfLambda>] comb: CombineKeyValue, x: string, y: string) =
        CombineKeyValue(fun sb ->
            comb.Invoke(sb).Append("transform: ").Append("translate(").Append(x).Append(", ").Append(y).Append("); "))

    /// Defines a 3D translation.
    [<CustomOperation("transformTranslate3D")>]
    member inline _.transformTranslate3D([<InlineIfLambda>] comb: CombineKeyValue, x: int, y: int, z: int) =
        CombineKeyValue(fun sb ->
            comb
                .Invoke(sb)
                .Append("transform: ")
                .Append("translate3d(")
                .Append(x)
                .Append("px, ")
                .Append(y)
                .Append("px, ")
                .Append(z)
                .Append("px); "))

    /// Defines a 3D translation.
    [<CustomOperation("transformTranslate3D")>]
    member inline _.transformTranslate3D([<InlineIfLambda>] comb: CombineKeyValue, x: string, y: string, z: string) =
        CombineKeyValue(fun sb ->
            comb
                .Invoke(sb)
                .Append("transform: ")
                .Append("translate3d(")
                .Append(x)
                .Append(", ")
                .Append(y)
                .Append(", ")
                .Append(z)
                .Append("); "))

    /// Defines a translation, using only the value for the X-axis.
    [<CustomOperation("transformTranslateX")>]
    member inline _.transformTranslateX([<InlineIfLambda>] comb: CombineKeyValue, x: int) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("transform: ").Append("translateX(").Append(x).Append("px); "))

    /// Defines a translation, using only the value for the X-axis.
    [<CustomOperation("transformTranslateX")>]
    member inline _.transformTranslateX([<InlineIfLambda>] comb: CombineKeyValue, x: string) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("transform: ").Append("translateX(").Append(x).Append("); "))

    /// Defines a translation, using only the value for the Y-axis
    [<CustomOperation("transformTranslateY")>]
    member inline _.transformTranslateY([<InlineIfLambda>] comb: CombineKeyValue, y: int) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("transform: ").Append("translateY(").Append(y).Append("px); "))

    /// Defines a translation, using only the value for the Y-axis
    [<CustomOperation("transformTranslateY")>]
    member inline _.transformTranslateY([<InlineIfLambda>] comb: CombineKeyValue, y: string) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("transform: ").Append("translateY(").Append(y).Append("); "))

    /// Defines a 3D translation, using only the value for the Z-axis
    [<CustomOperation("transformTranslateZ")>]
    member inline _.transformTranslateZ([<InlineIfLambda>] comb: CombineKeyValue, z: int) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("transform: ").Append("translateZ(").Append(z).Append("px); "))

    /// Defines a 3D translation, using only the value for the Z-axis
    [<CustomOperation("transformTranslateZ")>]
    member inline _.transformTranslateZ([<InlineIfLambda>] comb: CombineKeyValue, z: string) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("transform: ").Append("translateZ(").Append(z).Append("); "))

    /// Defines a 2D scale transformation.
    [<CustomOperation("transformScale")>]
    member inline _.transformScale([<InlineIfLambda>] comb: CombineKeyValue, x: int, y: int) =
        CombineKeyValue(fun sb ->
            comb.Invoke(sb).Append("transform: ").Append("scale(").Append(x).Append(", ").Append(y).Append("); "))

    /// Defines a scale transformation.
    /// Defines a scale transformation.
    [<CustomOperation("transformScale")>]
    member inline _.transformScale([<InlineIfLambda>] comb: CombineKeyValue, n: float) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("transform: ").Append("scale(").Append(n).Append("); "))

    /// Defines a 3D scale transformation
    [<CustomOperation("transformScale3D")>]
    member inline _.transformScale3D([<InlineIfLambda>] comb: CombineKeyValue, x: int, y: int, z: int) =
        CombineKeyValue(fun sb ->
            comb
                .Invoke(sb)
                .Append("transform: ")
                .Append("scale3d(")
                .Append(x)
                .Append(", ")
                .Append(y)
                .Append(", ")
                .Append(z)
                .Append("); "))

    /// Defines a scale transformation by giving a value for the X-axis.
    [<CustomOperation("transformScaleX")>]
    member inline _.transformScaleX([<InlineIfLambda>] comb: CombineKeyValue, x: int) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("transform: ").Append("scaleX(").Append(x).Append("); "))

    /// Defines a scale transformation by giving a value for the Y-axis.
    [<CustomOperation("transformScaleY")>]
    member inline _.transformScaleY([<InlineIfLambda>] comb: CombineKeyValue, y: int) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("transform: ").Append("scaleY(").Append(y).Append("); "))

    /// Defines a 3D translation, using only the value for the Z-axis
    [<CustomOperation("transformScaleZ")>]
    member inline _.transformScaleZ([<InlineIfLambda>] comb: CombineKeyValue, z: int) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("transform: ").Append("scaleZ(").Append(z).Append("); "))

    /// Defines a 2D rotation, the angle is specified in the parameter.
    [<CustomOperation("transformRotate")>]
    member inline _.transformRotate([<InlineIfLambda>] comb: CombineKeyValue, deg: int) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("transform: ").Append("rotate(").Append(deg).Append("deg); "))

    /// Defines a 2D rotation, the angle is specified in the parameter.
    [<CustomOperation("transformRotate")>]
    member inline _.transformRotate([<InlineIfLambda>] comb: CombineKeyValue, deg: float) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("transform: ").Append("rotate(").Append(deg).Append("deg); "))

    /// Defines a 3D rotation along the X-axis.
    [<CustomOperation("transformRotateX")>]
    member inline _.transformRotateX([<InlineIfLambda>] comb: CombineKeyValue, deg: float) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("transform: ").Append("rotateX(").Append(deg).Append("deg); "))

    /// Defines a 3D rotation along the Y-axis
    [<CustomOperation("transformRotateY")>]
    member inline _.transformRotateY([<InlineIfLambda>] comb: CombineKeyValue, deg: float) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("transform: ").Append("rotateY(").Append(deg).Append("deg); "))

    /// Defines a 3D rotation along the Z-axis
    [<CustomOperation("transformRotateZ")>]
    member inline _.transformRotateZ([<InlineIfLambda>] comb: CombineKeyValue, deg: float) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("transform: ").Append("rotateZ(").Append(deg).Append("deg); "))

    /// Defines a 2D skew transformation along the X- and the Y-axis.
    [<CustomOperation("transformSkew")>]
    member inline _.transformSkew([<InlineIfLambda>] comb: CombineKeyValue, xAngle: float, yAngle: float) =
        CombineKeyValue(fun sb ->
            comb
                .Invoke(sb)
                .Append("transform: ")
                .Append("skew(")
                .Append(xAngle)
                .Append("deg, ")
                .Append(yAngle)
                .Append("deg); "))

    /// Defines a 2D skew transformation along the X-axis
    [<CustomOperation("transformSkewX")>]
    member inline _.transformSkewX([<InlineIfLambda>] comb: CombineKeyValue, xAngle: float) =
        CombineKeyValue(fun sb ->
            comb.Invoke(sb).Append("transform: ").Append("skewX(").Append(xAngle).Append("deg); "))

    /// Defines a 2D skew transformation along the Y-axis
    [<CustomOperation("transformSkewY")>]
    member inline _.transformSkewY([<InlineIfLambda>] comb: CombineKeyValue, yAngle: float) =
        CombineKeyValue(fun sb ->
            comb.Invoke(sb).Append("transform: ").Append("skewY(").Append(yAngle).Append("deg); "))

    /// Defines a perspective view for a 3D transformed element
    [<CustomOperation("transformPerspective")>]
    member inline _.transformPerspective([<InlineIfLambda>] comb: CombineKeyValue, n: int) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append("transform: ").Append("perspective(").Append(n).Append("); "))

    /// Sets this property to its default value.
    [<CustomOperation("transformInitial")>]
    member inline _.transformInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("transform", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("transformInheritFromParent")>]
    member inline _.transformInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transform", "inherit")

    /// Sets the reference box for transforms. Accepts content-box | border-box | fill-box | stroke-box | view-box or a CSS variable.
    [<CustomOperation("transformBox")>]
    member inline _.transformBox([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("transform-box", value)

    /// Transforms are relative to the content box.
    [<CustomOperation("transformBoxContentBox")>]
    member inline _.transformBoxContentBox([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transform-box", "content-box")

    /// Transforms are relative to the border box.
    [<CustomOperation("transformBoxBorderBox")>]
    member inline _.transformBoxBorderBox([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transform-box", "border-box")

    /// Transforms are relative to the object bounding box (SVG).
    [<CustomOperation("transformBoxFillBox")>]
    member inline _.transformBoxFillBox([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transform-box", "fill-box")

    /// Transforms are relative to the nearest SVG viewport. This is default.
    [<CustomOperation("transformBoxViewBox")>]
    member inline _.transformBoxViewBox([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transform-box", "view-box")

    /// Sets this property to its default value.
    [<CustomOperation("transformBoxInitial")>]
    member inline _.transformBoxInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transform-box", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("transformBoxInheritFromParent")>]
    member inline _.transformBoxInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transform-box", "inherit")

    /// Sets whether the back face of a transformed element is visible. Accepts visible | hidden or a CSS variable.
    [<CustomOperation("backfaceVisibility")>]
    member inline _.backfaceVisibility([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("backface-visibility", value)

    /// The back face is visible. This is default.
    [<CustomOperation("backfaceVisibilityVisible")>]
    member inline _.backfaceVisibilityVisible([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("backface-visibility", "visible")

    /// The back face is hidden.
    [<CustomOperation("backfaceVisibilityHidden")>]
    member inline _.backfaceVisibilityHidden([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("backface-visibility", "hidden")

    /// Sets this property to its default value.
    [<CustomOperation("backfaceVisibilityInitial")>]
    member inline _.backfaceVisibilityInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("backface-visibility", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("backfaceVisibilityInheritFromParent")>]
    member inline _.backfaceVisibilityInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("backface-visibility", "inherit")




    // --------------------------------------------------------------------
    // Transition styles
    // --------------------------------------------------------------------


    /// Default value. Specifies a transition effect with a slow start, then fast, then end slowly (equivalent to cubic-bezier(0.25,0.1,0.25,1)).
    [<CustomOperation("transitionTimingFunctionEase")>]
    member inline _.transitionTimingFunctionEase([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transition-timing-function", "ease")

    /// Specifies a transition effect with the same speed from start to end (equivalent to cubic-bezier(0,0,1,1)))
    [<CustomOperation("transitionTimingFunctionLinear")>]
    member inline _.transitionTimingFunctionLinear([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transition-timing-function", "linear")

    /// Specifies a transition effect with a slow start (equivalent to cubic-bezier(0.42,0,1,1)).
    [<CustomOperation("transitionTimingFunctionEaseIn")>]
    member inline _.transitionTimingFunctionEaseIn([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transition-timing-function", "ease-in")

    /// Specifies a transition effect with a slow end (equivalent to cubic-bezier(0,0,0.58,1)).
    [<CustomOperation("transitionTimingFunctionEaseOut")>]
    member inline _.transitionTimingFunctionEaseOut([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transition-timing-function", "ease-out")

    /// Specifies a transition effect with a slow start and end (equivalent to cubic-bezier(0.42,0,0.58,1)))
    [<CustomOperation("transitionTimingFunctionEaseInOut")>]
    member inline _.transitionTimingFunctionEaseInOut([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transition-timing-function", "ease-in-out")

    /// Equivalent to steps(1, start))
    [<CustomOperation("transitionTimingFunctionStepStart")>]
    member inline _.transitionTimingFunctionStepStart([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transition-timing-function", "step-start")

    /// Equivalent to steps(1, end))
    [<CustomOperation("transitionTimingFunctionStepEnd")>]
    member inline _.transitionTimingFunctionStepEnd([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transition-timing-function", "step-end")

    /// Define your own values in the cubic-bezier function. Possible values are numeric values from 0 to 1
    [<CustomOperation("transitionTimingFunctionCubicBezier")>]
    member inline _.transitionTimingFunctionCubicBezier
        ([<InlineIfLambda>] comb: CombineKeyValue, n1: float, n2: float, n3: float, n4: float)
        =
        CombineKeyValue(fun sb ->
            comb
                .Invoke(sb)
                .Append("transition-timing-function: ")
                .Append("cubic-bezier(")
                .Append(n1)
                .Append(",")
                .Append(n2)
                .Append(",")
                .Append(n3)
                .Append(",")
                .Append(n4)
                .Append("); "))

    /// Sets this property to its default value)
    [<CustomOperation("transitionTimingFunctionInitial")>]
    member inline _.transitionTimingFunctionInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transition-timing-function", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("transitionTimingFunctionInheritFromParent")>]
    member inline _.transitionTimingFunctionInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transition-timing-function", "inherit")

    /// Sets the transition timing function using a CSS string value (e.g. "ease-in", "steps(4, end)", "var(--transition-timing)").
    [<CustomOperation("transitionTimingFunction")>]
    member inline _.transitionTimingFunction([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("transition-timing-function", value)

    /// Specifies a shorthand for all the transition properties. Accepts a CSS transition value (e.g. "all 0.3s ease-in-out").
    [<CustomOperation("transition")>]
    member inline _.transition([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("transition", value)

    /// Sets the length of time a transition animation should take to complete. By default, the
    /// value is 0s, meaning that no animation will occur.
    [<CustomOperation("transitionDuration")>]
    member inline _.transitionDuration([<InlineIfLambda>] comb: CombineKeyValue, timespan: TimeSpan) =
        comb &>> ("transition-duration", timespan.TotalMilliseconds.ToString() + "ms")

    /// Sets the length of time a transition animation should take to complete. By default, the
    /// value is 0s, meaning that no animation will occur.
    [<CustomOperation("transitionDurationSeconds")>]
    member inline _.transitionDurationSeconds([<InlineIfLambda>] comb: CombineKeyValue, n: float) =
        comb &>> ("transition-duration", string n + "s")

    /// Sets the length of time a transition animation should take to complete. By default, the
    /// value is 0s, meaning that no animation will occur.
    [<CustomOperation("transitionDurationMilliseconds")>]
    member inline _.transitionDurationMilliseconds([<InlineIfLambda>] comb: CombineKeyValue, n: float) =
        comb &>> ("transition-duration", string n + "ms")

    /// Sets the length of time a transition animation should take to complete. By default, the
    /// value is 0s, meaning that no animation will occur.
    [<CustomOperation("transitionDurationSeconds")>]
    member inline _.transitionDurationSeconds([<InlineIfLambda>] comb: CombineKeyValue, n: int) =
        comb &>> ("transition-duration", string n + "s")

    /// Sets the length of time a transition animation should take to complete. By default, the
    /// value is 0s, meaning that no animation will occur.
    [<CustomOperation("transitionDurationMilliseconds")>]
    member inline _.transitionDurationMilliseconds([<InlineIfLambda>] comb: CombineKeyValue, n: int) =
        comb &>> ("transition-duration", string n + "ms")

    /// Specifies the duration to wait before starting a property's transition effect when its value changes.
    [<CustomOperation("transitionDelay")>]
    member inline _.transitionDelay([<InlineIfLambda>] comb: CombineKeyValue, timespan: TimeSpan) =
        comb &>> ("transition-delay", timespan.TotalMilliseconds.ToString() + "ms")

    /// Specifies the duration to wait before starting a property's transition effect when its value changes.
    [<CustomOperation("transitionDelaySeconds")>]
    member inline _.transitionDelaySeconds([<InlineIfLambda>] comb: CombineKeyValue, n: float) =
        comb &>> ("transition-delay", string n + "s")

    /// Specifies the duration to wait before starting a property's transition effect when its value changes.
    [<CustomOperation("transitionDelayMilliseconds")>]
    member inline _.transitionDelayMilliseconds([<InlineIfLambda>] comb: CombineKeyValue, n: float) =
        comb &>> ("transition-delay", string n + "ms")

    /// Specifies the duration to wait before starting a property's transition effect when its value changes.
    [<CustomOperation("transitionDelaySeconds")>]
    member inline _.transitionDelaySeconds([<InlineIfLambda>] comb: CombineKeyValue, n: int) =
        comb &>> ("transition-delay", string n + "s")

    /// Specifies the duration to wait before starting a property's transition effect when its value changes.
    [<CustomOperation("transitionDelayMilliseconds")>]
    member inline _.transitionDelayMilliseconds([<InlineIfLambda>] comb: CombineKeyValue, n: int) =
        comb &>> ("transition-delay", string n + "ms")

    /// Sets the CSS properties to which a transition effect should be applied.
    [<CustomOperation("transitionProperty")>]
    member inline _.transitionProperty([<InlineIfLambda>] comb: CombineKeyValue, property: string) =
        comb &>> ("transition-property", property)

    /// Sets the CSS properties to which a transition effect should be applied, joined with ", ".
    [<CustomOperation("transitionProperty")>]
    member inline _.transitionProperty([<InlineIfLambda>] comb: CombineKeyValue, properties: string seq) =
        CombineKeyValue(fun sb ->
            let sb = comb.Invoke(sb).Append("transition-property: ")
            use e = properties.GetEnumerator()

            if e.MoveNext() then
                sb.Append(e.Current) |> ignore

                while e.MoveNext() do
                    sb.Append(", ").Append(e.Current) |> ignore

            sb.Append("; "))

    /// Sets whether discrete-property transitions occur. Accepts normal | allow-discrete or a CSS variable.
    [<CustomOperation("transitionBehavior")>]
    member inline _.transitionBehavior([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("transition-behavior", value)

    /// Discrete properties do not transition. This is default.
    [<CustomOperation("transitionBehaviorNormal")>]
    member inline _.transitionBehaviorNormal([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transition-behavior", "normal")

    /// Discrete properties transition (flip at 50%).
    [<CustomOperation("transitionBehaviorAllowDiscrete")>]
    member inline _.transitionBehaviorAllowDiscrete([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transition-behavior", "allow-discrete")

    /// Sets this property to its default value.
    [<CustomOperation("transitionBehaviorInitial")>]
    member inline _.transitionBehaviorInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transition-behavior", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("transitionBehaviorInheritFromParent")>]
    member inline _.transitionBehaviorInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("transition-behavior", "inherit")




    // --------------------------------------------------------------------
    // Typography styles
    // --------------------------------------------------------------------


    /// The browser determines the justification algorithm
    [<CustomOperation("textJustifyAuto")>]
    member inline _.textJustifyAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("text-justify", "auto")

    /// Increases/Decreases the space between words
    [<CustomOperation("textJustifyInterWord")>]
    member inline _.textJustifyInterWord([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-justify", "inter-word")

    /// Increases/Decreases the space between characters
    [<CustomOperation("textJustifyInterCharacter")>]
    member inline _.textJustifyInterCharacter([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-justify", "inter-character")

    /// Disables justification methods
    [<CustomOperation("textJustifyNone")>]
    member inline _.textJustifyNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("text-justify", "none")

    /// Sets this property to its default value.
    [<CustomOperation("textJustifyInitial")>]
    member inline _.textJustifyInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("text-justify", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("textJustifyInheritFromParent")>]
    member inline _.textJustifyInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-justify", "inherit")

    /// Sets the justification method using a CSS string value (e.g. "inter-word", "var(--text-justify)").
    [<CustomOperation("textJustify")>]
    member inline _.textJustify([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("text-justify", value)

    /// Sequences of whitespace will collapse into a single whitespace. Text will wrap when necessary. This is default.
    [<CustomOperation("whiteSpaceNormal")>]
    member inline _.whiteSpaceNormal([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("white-space", "normal")

    /// Sequences of whitespace will collapse into a single whitespace. Text will never wrap to the next line.
    /// The text continues on the same line until a `<br> ` tag is encountered.
    [<CustomOperation("whiteSpaceNowrap")>]
    member inline _.whiteSpaceNowrap([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("white-space", "nowrap")

    /// Whitespace is preserved by the browser. Text will only wrap on line breaks. Acts like the <pre> tag in HTML.
    [<CustomOperation("whiteSpacePre")>]
    member inline _.whiteSpacePre([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("white-space", "pre")

    /// Sequences of whitespace will collapse into a single whitespace. Text will wrap when necessary, and on line breaks
    [<CustomOperation("whiteSpacePreLine")>]
    member inline _.whiteSpacePreLine([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("white-space", "pre-line")

    /// Whitespace is preserved by the browser. Text will wrap when necessary, and on line breaks
    [<CustomOperation("whiteSpacePreWrap")>]
    member inline _.whiteSpacePreWrap([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("white-space", "pre-wrap")

    /// Sets this property to its default value.
    [<CustomOperation("whiteSpaceInitial")>]
    member inline _.whiteSpaceInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("white-space", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("whiteSpaceInheritFromParent")>]
    member inline _.whiteSpaceInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("white-space", "inherit")

    /// Sets how white space is handled using a CSS string value (e.g. "pre-wrap", "var(--white-space)").
    [<CustomOperation("whiteSpace")>]
    member inline _.whiteSpace([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("white-space", value)

    /// Default value. Uses default line break rules.
    [<Obsolete("Use wordBreakNormal instead")>]
    [<CustomOperation("wordbreakNormal")>]
    member inline _.wordbreakNormal([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("word-break", "normal")

    /// Sets whether line breaks appear wherever the text would otherwise overflow its content box.
    [<CustomOperation("wordBreakNormal")>]
    member inline _.wordBreakNormal([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("word-break", "normal")

    /// To prevent overflow, word may be broken at any character
    [<Obsolete("Use wordBreakBreakAll instead")>]
    [<CustomOperation("wordbreakBreakAll")>]
    member inline _.wordbreakBreakAll([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("word-break", "break-all")

    /// Word breaks may be inserted between any two characters.
    [<CustomOperation("wordBreakBreakAll")>]
    member inline _.wordBreakBreakAll([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("word-break", "break-all")

    /// Word breaks should not be used for Chinese/Japanese/Korean (CJK) text. Non-CJK text behavior is the same as value "normal")
    [<Obsolete("Use wordBreakKeepAll instead")>]
    [<CustomOperation("wordbreakKeepAll")>]
    member inline _.wordbreakKeepAll([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("word-break", "keep-all")

    /// Word breaks should not be used for Chinese/Japanese/Korean (CJK) text.
    [<CustomOperation("wordBreakKeepAll")>]
    member inline _.wordBreakKeepAll([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("word-break", "keep-all")

    /// To prevent overflow, word may be broken at arbitrary points.
    [<Obsolete("Use wordBreakBreakWord instead")>]
    [<CustomOperation("wordbreakBreakWord")>]
    member inline _.wordbreakBreakWord([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("word-break", "break-word")

    /// Allows unbreakable words to be broken.
    [<CustomOperation("wordBreakBreakWord")>]
    member inline _.wordBreakBreakWord([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("word-break", "break-word")

    /// Sets this property to its default value.
    [<Obsolete("Use wordBreakInitial instead")>]
    [<CustomOperation("wordbreakInitial")>]
    member inline _.wordbreakInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("word-break", "initial")

    /// Sets this property to its default value.
    [<CustomOperation("wordBreakInitial")>]
    member inline _.wordBreakInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("word-break", "initial")

    /// Inherits this property from its parent element.
    [<Obsolete("Use wordBreakInheritFromParent instead")>]
    [<CustomOperation("wordbreakInheritFromParent")>]
    member inline _.wordbreakInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("word-break", "inherit")

    /// Inherits this property from its parent element.
    [<CustomOperation("wordBreakInheritFromParent")>]
    member inline _.wordBreakInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("word-break", "inherit")

    /// Sets line breaking rules for words using a CSS string value (e.g. "break-all", "var(--word-break)").
    [<CustomOperation("wordBreak")>]
    member inline _.wordBreak([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("word-break", value)

    /// The font display strategy is defined by the user agent.
    ///
    /// Default value)
    [<CustomOperation("fontDisplayAuto")>]
    member inline _.fontDisplayAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-display", "auto")

    /// Gives the font face a short block period and an infinite swap period.
    [<CustomOperation("fontDisplayBlock")>]
    member inline _.fontDisplayBlock([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-display", "block")

    /// Gives the font face an extremely small block period and an infinite swap period.
    [<CustomOperation("fontDisplaySwap")>]
    member inline _.fontDisplaySwap([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-display", "swap")

    /// Gives the font face an extremely small block period and a short swap period.
    [<CustomOperation("fontDisplayFallback")>]
    member inline _.fontDisplayFallback([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-display", "fallback")

    /// Gives the font face an extremely small block period and no swap period.
    [<CustomOperation("fontDisplayOptional")>]
    member inline _.fontDisplayOptional([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-display", "optional")

    /// Default. The browser determines whether font kerning should be applied or not
    [<CustomOperation("fontKerningAuto")>]
    member inline _.fontKerningAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-kerning", "auto")

    /// Specifies that font kerning is applied
    [<CustomOperation("fontKerningNormal")>]
    member inline _.fontKerningNormal([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-kerning", "normal")

    /// Specifies that font kerning is not applied
    [<CustomOperation("fontKerningNone")>]
    member inline _.fontKerningNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-kerning", "none")

    /// Sets the font kerning using a CSS string value (e.g. "auto", "var(--font-kerning)").
    [<CustomOperation("fontKerning")>]
    member inline _.fontKerning([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("font-kerning", value)

    /// Defines from thin to thick characters. 400 is the same as normal, and 700 is the same as bold.
    /// Possible values are [100, 200, 300, 400, 500, 600, 700, 800, 900]
    [<CustomOperation("fontWeight")>]
    member inline _.fontWeight([<InlineIfLambda>] comb: CombineKeyValue, weight: int) =
        comb &&& mkWithKV ("font-weight", weight)

    /// Defines font weight using a CSS string value (e.g. "bold", "var(--font-weight-strong)").
    [<CustomOperation("fontWeight")>]
    member inline _.fontWeight([<InlineIfLambda>] comb: CombineKeyValue, weight: string) =
        comb &>> ("font-weight", weight)

    /// Defines normal characters. This is default.
    [<CustomOperation("fontWeightNormal")>]
    member inline _.fontWeightNormal([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-weight", "normal")

    /// Defines thick characters.
    [<CustomOperation("fontWeightBold")>]
    member inline _.fontWeightBold([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-weight", "bold")

    /// Defines thicker characters
    [<CustomOperation("fontWeightBolder")>]
    member inline _.fontWeightBolder([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-weight", "bolder")

    /// Defines lighter characters.
    [<CustomOperation("fontWeightLighter")>]
    member inline _.fontWeightLighter([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-weight", "lighter")

    /// Sets this property to its default value.
    [<CustomOperation("fontWeightInitial")>]
    member inline _.fontWeightInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-weight", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("fontWeightInheritFromParent")>]
    member inline _.fontWeightInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-weight", "inherit")

    /// Sets the spacing between text characters.
    [<CustomOperation("letterSpacing")>]
    member inline _.letterSpacing([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("letter-spacing", value)

    /// Sets the spacing between text characters.
    [<CustomOperation("letterSpacing")>]
    member inline _.letterSpacing([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("letter-spacing", value)

    /// Specifies the default letter spacing for the current font.
    [<CustomOperation("letterSpacingNormal")>]
    member inline _.letterSpacingNormal([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("letter-spacing", "normal")

    /// Sets this property to its default value.
    [<CustomOperation("letterSpacingInitial")>]
    member inline _.letterSpacingInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("letter-spacing", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("letterSpacingInheritFromParent")>]
    member inline _.letterSpacingInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("letter-spacing", "inherit")

    /// The browser displays a normal font style. This is defaut.
    [<CustomOperation("fontStyleNormal")>]
    member inline _.fontStyleNormal([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-style", "normal")

    /// The browser displays an italic font style.
    [<CustomOperation("fontStyleItalic")>]
    member inline _.fontStyleItalic([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-style", "italic")

    /// The browser displays an oblique font style.
    [<CustomOperation("fontStyleOblique")>]
    member inline _.fontStyleOblique([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-style", "oblique")

    /// Sets this property to its default value.
    [<CustomOperation("fontStyleInitial")>]
    member inline _.fontStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-style", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("fontStyleInheritFromParent")>]
    member inline _.fontStyleInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-style", "inherit")

    /// Sets the font style using a CSS string value (e.g. "italic", "var(--font-style)").
    [<CustomOperation("fontStyle")>]
    member inline _.fontStyle([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("font-style", value)

    /// The browser displays a normal font. This is default
    [<CustomOperation("fontVariantNormal")>]
    member inline _.fontVariantNormal([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-variant", "normal")

    /// The browser displays a small-caps font
    [<CustomOperation("fontVariantSmallCaps")>]
    member inline _.fontVariantSmallCaps([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant", "small-caps")

    /// Sets this property to its default value.
    [<CustomOperation("fontVariantInitial")>]
    member inline _.fontVariantInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-variant", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("fontVariantInheritFromParent")>]
    member inline _.fontVariantInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant", "inherit")

    /// Sets the font variant using a CSS string value (e.g. "small-caps", "var(--font-variant)").
    [<CustomOperation("fontVariant")>]
    member inline _.fontVariant([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("font-variant", value)

    /// Break words only at allowed break points
    [<CustomOperation("wordWrapNormal")>]
    member inline _.wordWrapNormal([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("word-wrap", "normal")

    /// Allows unbreakable words to be broken
    [<CustomOperation("wordWrapBreakWord")>]
    member inline _.wordWrapBreakWord([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("word-wrap", "break-word")

    /// Sets this property to its default value.
    [<CustomOperation("wordWrapInitial")>]
    member inline _.wordWrapInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("word-wrap", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("wordWrapInheritFromParent")>]
    member inline _.wordWrapInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("word-wrap", "inherit")

    /// Sets the word wrapping behavior using a CSS string value (e.g. "break-word", "var(--word-wrap)").
    [<CustomOperation("wordWrap")>]
    member inline _.wordWrap([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("word-wrap", value)

    /// Sets the kind of decoration that is used on text in an element. Accepts a CSS text-decoration-line value (e.g. "underline overline").
    [<CustomOperation("textDecorationLine")>]
    member inline _.textDecorationLine([<InlineIfLambda>] comb: CombineKeyValue, line: string) =
        comb &>> ("text-decoration-line", line)

    /// Specifies no text decoration line.
    [<CustomOperation("textDecorationLineNone")>]
    member inline _.textDecorationLineNone([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration-line", "none")

    /// Draws a line beneath the text.
    [<CustomOperation("textDecorationLineUnderline")>]
    member inline _.textDecorationLineUnderline([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration-line", "underline")

    /// Draws a line above the text.
    [<CustomOperation("textDecorationLineOverline")>]
    member inline _.textDecorationLineOverline([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration-line", "overline")

    /// Draws a line through the text (strikethrough).
    [<CustomOperation("textDecorationLineLineThrough")>]
    member inline _.textDecorationLineLineThrough([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration-line", "line-through")

    /// Sets this property to its default value.
    [<CustomOperation("textDecorationLineInitial")>]
    member inline _.textDecorationLineInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration-line", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("textDecorationLineInheritFromParent")>]
    member inline _.textDecorationLineInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration-line", "inherit")

    /// Specifies the decoration added to text. Accepts a CSS text-decoration value (e.g. "underline", "none", or a shorthand combining line, style, and color).
    [<CustomOperation("textDecoration")>]
    member inline _.textDecoration([<InlineIfLambda>] comb: CombineKeyValue, line: string) =
        comb &>> ("text-decoration", line)

    /// Specifies no text decoration.
    [<CustomOperation("textDecorationNone")>]
    member inline _.textDecorationNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("text-decoration", "none")

    /// Underlines the text.
    [<CustomOperation("textDecorationUnderline")>]
    member inline _.textDecorationUnderline([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration", "underline")

    /// Adds a line above the text.
    [<CustomOperation("textDecorationOverline")>]
    member inline _.textDecorationOverline([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration", "overline")

    /// Adds a line through the text (strikethrough).
    [<CustomOperation("textDecorationLineThrough")>]
    member inline _.textDecorationLineThrough([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration", "line-through")

    /// Sets this property to its default value.
    [<CustomOperation("textDecorationInitial")>]
    member inline _.textDecorationInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("textDecorationInheritFromParent")>]
    member inline _.textDecorationInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration", "inherit")

    /// No capitalization. The text renders as it is. This is default.
    [<CustomOperation("textTransformNone")>]
    member inline _.textTransformNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("text-transform", "none")

    /// Transforms the first character of each word to uppercase.
    [<CustomOperation("textTransformCapitalize")>]
    member inline _.textTransformCapitalize([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-transform", "capitalize")

    /// Transforms all characters to uppercase.
    [<CustomOperation("textTransformUppercase")>]
    member inline _.textTransformUppercase([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-transform", "uppercase")

    /// Transforms all characters to lowercase.
    [<CustomOperation("textTransformLowercase")>]
    member inline _.textTransformLowercase([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-transform", "lowercase")

    /// Sets this property to its default value.
    [<CustomOperation("textTransformInitial")>]
    member inline _.textTransformInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-transform", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("textTransformInheritFromParent")>]
    member inline _.textTransformInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-transform", "inherit")

    /// Sets the text transformation using a CSS string value (e.g. "uppercase", "var(--text-transform)").
    [<CustomOperation("textTransform")>]
    member inline _.textTransform([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("text-transform", value)

    /// Default value. The text is clipped and not accessible.
    [<CustomOperation("textOverflowClip")>]
    member inline _.textOverflowClip([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("text-overflow", "clip")

    /// Render an ellipsis ("...") to represent the clipped text.
    [<CustomOperation("textOverflowEllipsis")>]
    member inline _.textOverflowEllipsis([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-overflow", "ellipsis")

    /// Render the given string to represent the clipped text.
    [<CustomOperation("textOverflowInitial")>]
    member inline _.textOverflowInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-overflow", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("textOverflowInheritFromParent")>]
    member inline _.textOverflowInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-overflow", "inherit")

    /// Sets how overflowed text is signaled using a CSS string value (e.g. "ellipsis", "var(--text-overflow)").
    [<CustomOperation("textOverflow")>]
    member inline _.textOverflow([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("text-overflow", value)

    /// Default value. The line will display as a single line.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=solid
    [<CustomOperation("textDecorationStyleSolid")>]
    member inline _.textDecorationStyleSolid([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration-style", "solid")

    /// The line will display as a double line.
    ///
    /// https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=double
    [<CustomOperation("textDecorationStyleDouble")>]
    member inline _.textDecorationStyleDouble([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration-style", "double")

    /// The line will display as a dotted line.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=dotted
    [<CustomOperation("textDecorationStyleDotted")>]
    member inline _.textDecorationStyleDotted([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration-style", "dotted")

    /// The line will display as a dashed line.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=dashed
    [<CustomOperation("textDecorationStyleDashed")>]
    member inline _.textDecorationStyleDashed([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration-style", "dashed")

    /// The line will display as a wavy line.
    ///
    /// https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=wavy
    [<CustomOperation("textDecorationStyleWavy")>]
    member inline _.textDecorationStyleWavy([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration-style", "wavy")

    /// Sets this property to its default value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=initial
    [<CustomOperation("textDecorationStyleInitial")>]
    member inline _.textDecorationStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration-style", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("textDecorationStyleInheritFromParent")>]
    member inline _.textDecorationStyleInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration-style", "inherit")

    /// Sets the style of text decorations using a CSS string value (e.g. "wavy", "var(--text-decoration-style)").
    [<CustomOperation("textDecorationStyle")>]
    member inline _.textDecorationStyle([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("text-decoration-style", value)

    /// Makes the text as narrow as it gets.
    [<CustomOperation("fontStretchUltraCondensed")>]
    member inline _.fontStretchUltraCondensed([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-stretch", "ultra-condensed")

    /// Makes the text narrower than condensed, but not as narrow as ultra-condensed
    [<CustomOperation("fontStretchExtraCondensed")>]
    member inline _.fontStretchExtraCondensed([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-stretch", "extra-condensed")

    /// Makes the text narrower than semi-condensed, but not as narrow as extra-condensed.
    [<CustomOperation("fontStretchCondensed")>]
    member inline _.fontStretchCondensed([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-stretch", "condensed")

    /// Makes the text narrower than normal, but not as narrow as condensed.
    [<CustomOperation("fontStretchSemiCondensed")>]
    member inline _.fontStretchSemiCondensed([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-stretch", "semi-condensed")

    /// Default value. No font stretching
    [<CustomOperation("fontStretchNormal")>]
    member inline _.fontStretchNormal([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-stretch", "normal")

    /// Makes the text wider than normal, but not as wide as expanded
    [<CustomOperation("fontStretchSemiExpanded")>]
    member inline _.fontStretchSemiExpanded([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-stretch", "semi-expanded")

    /// Makes the text wider than semi-expanded, but not as wide as extra-expanded
    [<CustomOperation("fontStretchExpanded")>]
    member inline _.fontStretchExpanded([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-stretch", "expanded")

    /// Makes the text wider than expanded, but not as wide as ultra-expanded
    [<CustomOperation("fontStretchExtraExpanded")>]
    member inline _.fontStretchExtraExpanded([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-stretch", "extra-expanded")

    /// Makes the text as wide as it gets.
    [<CustomOperation("fontStretchUltraExpanded")>]
    member inline _.fontStretchUltraExpanded([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-stretch", "ultra-expanded")

    /// Sets this property to its default value.
    [<CustomOperation("fontStretchInitial")>]
    member inline _.fontStretchInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-stretch", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("fontStretchInheritFromParent")>]
    member inline _.fontStretchInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-stretch", "inherit")

    /// Sets the font stretch using a CSS string value (e.g. "condensed", "var(--font-stretch)").
    [<CustomOperation("fontStretch")>]
    member inline _.fontStretch([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("font-stretch", value)

    /// The element is aligned with the baseline of the parent. This is default.
    [<CustomOperation("verticalAlignBaseline")>]
    member inline _.verticalAlignBaseline([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("vertical-align", "baseline")

    /// The element is aligned with the subscript baseline of the parent
    [<CustomOperation("verticalAlignSub")>]
    member inline _.verticalAlignSub([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("vertical-align", "sub")

    /// The element is aligned with the superscript baseline of the parent.
    [<CustomOperation("verticalAlignSuper")>]
    member inline _.verticalAlignSuper([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("vertical-align", "super")

    /// The element is aligned with the top of the tallest element on the line.
    [<CustomOperation("verticalAlignTop")>]
    member inline _.verticalAlignTop([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("vertical-align", "top")

    /// The element is aligned with the top of the parent element's font.
    [<CustomOperation("verticalAlignTextTop")>]
    member inline _.verticalAlignTextTop([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("vertical-align", "text-top")

    /// The element is placed in the middle of the parent element.
    [<CustomOperation("verticalAlignMiddle")>]
    member inline _.verticalAlignMiddle([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("vertical-align", "middle")

    /// The element is aligned with the lowest element on the line.
    [<CustomOperation("verticalAlignBottom")>]
    member inline _.verticalAlignBottom([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("vertical-align", "bottom")

    /// The element is aligned with the bottom of the parent element's font
    [<CustomOperation("verticalAlignTextBottom")>]
    member inline _.verticalAlignTextBottom([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("vertical-align", "text-bottom")

    /// Sets this property to its default value.
    [<CustomOperation("verticalAlignInitial")>]
    member inline _.verticalAlignInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("vertical-align", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("verticalAlignInheritFromParent")>]
    member inline _.verticalAlignInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("vertical-align", "inherit")

    /// Sets the vertical alignment using a CSS string value (e.g. "middle", "0.5em", "var(--vertical-align)").
    [<CustomOperation("verticalAlign")>]
    member inline _.verticalAlign([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("vertical-align", value)

    /// Let the content flow horizontally from left to right, vertically from top to bottom
    [<CustomOperation("writingModeHorizontalTopBottom")>]
    member inline _.writingModeHorizontalTopBottom([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("writing-mode", "horizontal-tb")

    /// Let the content flow vertically from top to bottom, horizontally from right to left
    [<CustomOperation("writingModeVerticalRightLeft")>]
    member inline _.writingModeVerticalRightLeft([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("writing-mode", "vertical-rl")

    /// Let the content flow vertically from top to bottom, horizontally from left to right
    [<CustomOperation("writingModeVerticalLeftRight")>]
    member inline _.writingModeVerticalLeftRight([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("writing-mode", "vertical-lr")

    /// Sets this property to its default value.
    [<CustomOperation("writingModeInitial")>]
    member inline _.writingModeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("writing-mode", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("writingModeInheritFromParent")>]
    member inline _.writingModeInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("writing-mode", "inherit")

    /// Sets the writing mode using a CSS string value (e.g. "vertical-rl", "var(--writing-mode)").
    [<CustomOperation("writingMode")>]
    member inline _.writingMode([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("writing-mode", value)

    /// Text direction goes from right-to-left
    [<CustomOperation("directionRightToLeft")>]
    member inline _.directionRightToLeft([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("direction", "rtl")

    /// Text direction goes from left-to-right. This is default
    [<CustomOperation("directionLeftToRight")>]
    member inline _.directionLeftToRight([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("direction", "ltr")

    /// Sets this property to its default value.
    [<CustomOperation("directionInitial")>]
    member inline _.directionInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("direction", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("directionInheritFromParent")>]
    member inline _.directionInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("direction", "inherit")

    /// Sets the text direction using a CSS string value (e.g. "rtl", "var(--direction)").
    [<CustomOperation("direction")>]
    member inline _.direction([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("direction", value)

    /// Aligns the text to the left.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align
    [<CustomOperation("textAlignLeft")>]
    member inline _.textAlignLeft([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("text-align", "left")

    /// Aligns the text to the right.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=right
    [<CustomOperation("textAlignRight")>]
    member inline _.textAlignRight([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("text-align", "right")

    /// Centers the text.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=center
    [<CustomOperation("textAlignCenter")>]
    member inline _.textAlignCenter([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("text-align", "center")

    /// Stretches the lines so that each line has equal width (like in newspapers and magazines).
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=justify
    [<CustomOperation("textAlignJustify")>]
    member inline _.textAlignJustify([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("text-align", "justify")

    /// Sets this property to its default value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
    [<CustomOperation("textAlignInitial")>]
    member inline _.textAlignInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("text-align", "initial")

    /// Inherits this property from its parent element.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
    [<CustomOperation("textAlignInheritFromParent")>]
    member inline _.textAlignInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-align", "inherit")

    /// Sets the horizontal alignment of text using a CSS string value (e.g. "center", "var(--text-align)").
    [<CustomOperation("textAlign")>]
    member inline _.textAlign([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("text-align", value)

    /// Sets the size of the font.
    ///
    /// This property is also used to compute the size of em, ex, and other relative <length> units.
    [<CustomOperation("fontSize")>]
    member inline _.fontSize([<InlineIfLambda>] comb: CombineKeyValue, size: int) =
        comb &&& mkPxWithKV ("font-size", size)

    /// Sets the size of the font.
    ///
    /// This property is also used to compute the size of em, ex, and other relative <length> units.
    [<CustomOperation("fontSize")>]
    member inline _.fontSize([<InlineIfLambda>] comb: CombineKeyValue, size: string) = comb &>> ("font-size", size)

    /// Specifies the height of a text lines.
    ///
    /// This property is also used to compute the size of em, ex, and other relative <length> units.
    ///
    /// Note: Negative values are not allowed.
    [<CustomOperation("lineHeight")>]
    member inline _.lineHeight([<InlineIfLambda>] comb: CombineKeyValue, size: int) =
        comb &&& mkPxWithKV ("line-height", size)

    /// Specifies the height of a text lines.
    ///
    /// This property is also used to compute the size of em, ex, and other relative <length> units.
    ///
    /// Note: Negative values are not allowed.
    [<CustomOperation("lineHeight")>]
    member inline _.lineHeight([<InlineIfLambda>] comb: CombineKeyValue, size: string) = comb &>> ("line-height", size)

    /// Sets the font family for the font specified in a @font-face rule.
    [<CustomOperation("fontFamily")>]
    member inline _.fontFamily([<InlineIfLambda>] comb: CombineKeyValue, family: string) =
        comb &>> ("font-family", family)

    /// Sets the color of decorations added to text by text-decoration-line.
    [<CustomOperation("textDecorationColor")>]
    member inline _.textDecorationColor([<InlineIfLambda>] comb: CombineKeyValue, color: string) =
        comb &>> ("text-decoration-color", color)

    /// Sets the length of empty space (indentation) that is put before lines of text in a block.
    [<CustomOperation("textIndent")>]
    member inline _.textIndent([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkPxWithKV ("text-indent", value)

    /// Sets the length of empty space (indentation) that is put before lines of text in a block.
    [<CustomOperation("textIndent")>]
    member inline _.textIndent([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("text-indent", value)

    /// Shorthand for font-style, font-variant, font-weight, font-size/line-height and font-family (e.g. "italic bold 12px/1.5 sans-serif").
    [<CustomOperation("font")>]
    member inline _.font([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("font", value)

    /// Sets the thickness of text decorations (e.g. "2px", "0.1em", "from-font").
    [<CustomOperation("textDecorationThickness")>]
    member inline _.textDecorationThickness([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("text-decoration-thickness", value)

    /// Sets whether decorations skip over glyph ascenders/descenders. Accepts auto | none | all or a CSS variable.
    [<CustomOperation("textDecorationSkipInk")>]
    member inline _.textDecorationSkipInk([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("text-decoration-skip-ink", value)

    /// Decorations skip ink where appropriate. This is default.
    [<CustomOperation("textDecorationSkipInkAuto")>]
    member inline _.textDecorationSkipInkAuto([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration-skip-ink", "auto")

    /// Decorations are drawn through glyphs.
    [<CustomOperation("textDecorationSkipInkNone")>]
    member inline _.textDecorationSkipInkNone([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration-skip-ink", "none")

    /// Sets this property to its default value.
    [<CustomOperation("textDecorationSkipInkInitial")>]
    member inline _.textDecorationSkipInkInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration-skip-ink", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("textDecorationSkipInkInheritFromParent")>]
    member inline _.textDecorationSkipInkInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-decoration-skip-ink", "inherit")

    /// Sets how the last line of a block is aligned. Accepts left | right | center | justify | start | end or a CSS variable.
    [<CustomOperation("textAlignLast")>]
    member inline _.textAlignLast([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("text-align-last", value)

    /// The last line is aligned to the start of the line. This is default.
    [<CustomOperation("textAlignLastStart")>]
    member inline _.textAlignLastStart([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("text-align-last", "start")

    /// The last line is aligned to the end of the line.
    [<CustomOperation("textAlignLastEnd")>]
    member inline _.textAlignLastEnd([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("text-align-last", "end")

    /// The last line is centered.
    [<CustomOperation("textAlignLastCenter")>]
    member inline _.textAlignLastCenter([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-align-last", "center")

    /// The last line is justified.
    [<CustomOperation("textAlignLastJustify")>]
    member inline _.textAlignLastJustify([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-align-last", "justify")

    /// Sets this property to its default value.
    [<CustomOperation("textAlignLastInitial")>]
    member inline _.textAlignLastInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-align-last", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("textAlignLastInheritFromParent")>]
    member inline _.textAlignLastInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-align-last", "inherit")

    /// Sets the width of a tab character in spaces.
    [<CustomOperation("tabSize")>]
    member inline _.tabSize([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkWithKV ("tab-size", value)

    /// Sets the width of a tab character using a CSS string value (e.g. "4", "2em").
    [<CustomOperation("tabSize")>]
    member inline _.tabSize([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("tab-size", value)

    /// Sets whether long words may be broken to prevent overflow. Accepts normal | break-word | anywhere or a CSS variable.
    [<CustomOperation("overflowWrap")>]
    member inline _.overflowWrap([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("overflow-wrap", value)

    /// Lines may only break at normal break points. This is default.
    [<CustomOperation("overflowWrapNormal")>]
    member inline _.overflowWrapNormal([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("overflow-wrap", "normal")

    /// Long words may be broken at arbitrary points.
    [<CustomOperation("overflowWrapBreakWord")>]
    member inline _.overflowWrapBreakWord([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overflow-wrap", "break-word")

    /// Long words may be broken anywhere.
    [<CustomOperation("overflowWrapAnywhere")>]
    member inline _.overflowWrapAnywhere([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overflow-wrap", "anywhere")

    /// Sets this property to its default value.
    [<CustomOperation("overflowWrapInitial")>]
    member inline _.overflowWrapInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overflow-wrap", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("overflowWrapInheritFromParent")>]
    member inline _.overflowWrapInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("overflow-wrap", "inherit")

    /// Hints to the browser how to render text. Accepts auto | optimizeSpeed | optimizeLegibility | geometricPrecision or a CSS variable.
    [<CustomOperation("textRendering")>]
    member inline _.textRendering([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("text-rendering", value)

    /// The browser uses its default. This is default.
    [<CustomOperation("textRenderingAuto")>]
    member inline _.textRenderingAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("text-rendering", "auto")

    /// The browser emphasizes rendering speed over legibility.
    [<CustomOperation("textRenderingOptimizeSpeed")>]
    member inline _.textRenderingOptimizeSpeed([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-rendering", "optimizeSpeed")

    /// The browser emphasizes legibility over rendering speed.
    [<CustomOperation("textRenderingOptimizeLegibility")>]
    member inline _.textRenderingOptimizeLegibility([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-rendering", "optimizeLegibility")

    /// Sets this property to its default value.
    [<CustomOperation("textRenderingInitial")>]
    member inline _.textRenderingInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-rendering", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("textRenderingInheritFromParent")>]
    member inline _.textRenderingInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-rendering", "inherit")

    /// Sets whether font size may be automatically adjusted (mobile). Accepts none | auto | a percentage or a CSS variable.
    [<CustomOperation("textSizeAdjust")>]
    member inline _.textSizeAdjust([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("text-size-adjust", value)

    /// Font size is not automatically adjusted.
    [<CustomOperation("textSizeAdjustNone")>]
    member inline _.textSizeAdjustNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("text-size-adjust", "none")

    /// Font size may be automatically adjusted. This is default.
    [<CustomOperation("textSizeAdjustAuto")>]
    member inline _.textSizeAdjustAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("text-size-adjust", "auto")

    /// Sets this property to its default value.
    [<CustomOperation("textSizeAdjustInitial")>]
    member inline _.textSizeAdjustInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-size-adjust", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("textSizeAdjustInheritFromParent")>]
    member inline _.textSizeAdjustInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-size-adjust", "inherit")

    /// Sets the orientation of text in vertical writing modes. Accepts mixed | upright | sideways or a CSS variable.
    [<CustomOperation("textOrientation")>]
    member inline _.textOrientation([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("text-orientation", value)

    /// Text uses mixed orientation. This is default.
    [<CustomOperation("textOrientationMixed")>]
    member inline _.textOrientationMixed([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-orientation", "mixed")

    /// All glyphs are rendered upright.
    [<CustomOperation("textOrientationUpright")>]
    member inline _.textOrientationUpright([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-orientation", "upright")

    /// All glyphs are rendered sideways.
    [<CustomOperation("textOrientationSideways")>]
    member inline _.textOrientationSideways([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-orientation", "sideways")

    /// Sets this property to its default value.
    [<CustomOperation("textOrientationInitial")>]
    member inline _.textOrientationInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-orientation", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("textOrientationInheritFromParent")>]
    member inline _.textOrientationInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("text-orientation", "inherit")


    /// Default. No adjustment.
    [<CustomOperation("fontSizeAdjustNone")>]
    member inline _.fontSizeAdjustNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-size-adjust", "none")

    /// Uses the first available font's metric.
    [<CustomOperation("fontSizeAdjustFromFont")>]
    member inline _.fontSizeAdjustFromFont([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-size-adjust", "from-font")

    /// Sets the size of lowercase letters relative to the current font size. Also accepts a number via the string overload (e.g. "0.5").
    [<CustomOperation("fontSizeAdjust")>]
    member inline _.fontSizeAdjust([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("font-size-adjust", value)

    /// Sets this property to its default value.
    [<CustomOperation("fontSizeAdjustInitial")>]
    member inline _.fontSizeAdjustInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-size-adjust", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("fontSizeAdjustInheritFromParent")>]
    member inline _.fontSizeAdjustInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-size-adjust", "inherit")

    /// Do not synthesize bold or italic.
    [<CustomOperation("fontSynthesisNone")>]
    member inline _.fontSynthesisNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-synthesis", "none")

    /// Synthesize bold if needed.
    [<CustomOperation("fontSynthesisWeight")>]
    member inline _.fontSynthesisWeight([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-synthesis", "weight")

    /// Synthesize italic if needed.
    [<CustomOperation("fontSynthesisStyle")>]
    member inline _.fontSynthesisStyle([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("font-synthesis", "style")

    /// Synthesize small-caps if needed.
    [<CustomOperation("fontSynthesisSmallCaps")>]
    member inline _.fontSynthesisSmallCaps([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-synthesis", "small-caps")

    /// Controls which missing typefaces (bold, italic) the browser may synthesize.
    [<CustomOperation("fontSynthesis")>]
    member inline _.fontSynthesis([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("font-synthesis", value)

    /// Sets this property to its default value.
    [<CustomOperation("fontSynthesisInitial")>]
    member inline _.fontSynthesisInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-synthesis", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("fontSynthesisInheritFromParent")>]
    member inline _.fontSynthesisInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-synthesis", "inherit")

    /// Controls advanced typographic OpenType features (e.g. "\"liga\" 1", "\"tnum\"").
    [<CustomOperation("fontFeatureSettings")>]
    member inline _.fontFeatureSettings([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("font-feature-settings", value)

    /// Provides low-level control over variable font axes (e.g. "\"wght\" 700").
    [<CustomOperation("fontVariationSettings")>]
    member inline _.fontVariationSettings([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("font-variation-settings", value)

    /// Default.
    [<CustomOperation("fontVariantCapsNormal")>]
    member inline _.fontVariantCapsNormal([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-caps", "normal")

    /// Small capitals.
    [<CustomOperation("fontVariantCapsSmallCaps")>]
    member inline _.fontVariantCapsSmallCaps([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-caps", "small-caps")

    /// All small capitals.
    [<CustomOperation("fontVariantCapsAllSmallCaps")>]
    member inline _.fontVariantCapsAllSmallCaps([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-caps", "all-small-caps")

    /// Petite capitals.
    [<CustomOperation("fontVariantCapsPetiteCaps")>]
    member inline _.fontVariantCapsPetiteCaps([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-caps", "petite-caps")

    /// All petite capitals.
    [<CustomOperation("fontVariantCapsAllPetiteCaps")>]
    member inline _.fontVariantCapsAllPetiteCaps([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-caps", "all-petite-caps")

    /// Unicase.
    [<CustomOperation("fontVariantCapsUnicase")>]
    member inline _.fontVariantCapsUnicase([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-caps", "unicase")

    /// Titling capitals.
    [<CustomOperation("fontVariantCapsTitlingCaps")>]
    member inline _.fontVariantCapsTitlingCaps([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-caps", "titling-caps")

    /// Controls the usage of alternate glyphs for capital letters.
    [<CustomOperation("fontVariantCaps")>]
    member inline _.fontVariantCaps([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("font-variant-caps", value)

    /// Sets this property to its default value.
    [<CustomOperation("fontVariantCapsInitial")>]
    member inline _.fontVariantCapsInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-caps", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("fontVariantCapsInheritFromParent")>]
    member inline _.fontVariantCapsInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-caps", "inherit")

    /// Default.
    [<CustomOperation("fontVariantLigaturesNormal")>]
    member inline _.fontVariantLigaturesNormal([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-ligatures", "normal")

    /// No ligatures.
    [<CustomOperation("fontVariantLigaturesNone")>]
    member inline _.fontVariantLigaturesNone([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-ligatures", "none")

    /// Common ligatures.
    [<CustomOperation("fontVariantLigaturesCommonLigatures")>]
    member inline _.fontVariantLigaturesCommonLigatures([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-ligatures", "common-ligatures")

    /// Disable common ligatures.
    [<CustomOperation("fontVariantLigaturesNoCommonLigatures")>]
    member inline _.fontVariantLigaturesNoCommonLigatures([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-ligatures", "no-common-ligatures")

    /// Discretionary ligatures.
    [<CustomOperation("fontVariantLigaturesDiscretionaryLigatures")>]
    member inline _.fontVariantLigaturesDiscretionaryLigatures([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-ligatures", "discretionary-ligatures")

    /// Disable discretionary ligatures.
    [<CustomOperation("fontVariantLigaturesNoDiscretionaryLigatures")>]
    member inline _.fontVariantLigaturesNoDiscretionaryLigatures([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-ligatures", "no-discretionary-ligatures")

    /// Historical ligatures.
    [<CustomOperation("fontVariantLigaturesHistoricalLigatures")>]
    member inline _.fontVariantLigaturesHistoricalLigatures([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-ligatures", "historical-ligatures")

    /// Disable historical ligatures.
    [<CustomOperation("fontVariantLigaturesNoHistoricalLigatures")>]
    member inline _.fontVariantLigaturesNoHistoricalLigatures([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-ligatures", "no-historical-ligatures")

    /// Contextual alternates.
    [<CustomOperation("fontVariantLigaturesContextual")>]
    member inline _.fontVariantLigaturesContextual([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-ligatures", "contextual")

    /// Disable contextual alternates.
    [<CustomOperation("fontVariantLigaturesNoContextual")>]
    member inline _.fontVariantLigaturesNoContextual([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-ligatures", "no-contextual")

    /// Controls which ligatures and contextual forms are used.
    [<CustomOperation("fontVariantLigatures")>]
    member inline _.fontVariantLigatures([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("font-variant-ligatures", value)

    /// Sets this property to its default value.
    [<CustomOperation("fontVariantLigaturesInitial")>]
    member inline _.fontVariantLigaturesInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-ligatures", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("fontVariantLigaturesInheritFromParent")>]
    member inline _.fontVariantLigaturesInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-ligatures", "inherit")

    /// Default.
    [<CustomOperation("fontVariantNumericNormal")>]
    member inline _.fontVariantNumericNormal([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-numeric", "normal")

    /// Lining numerals.
    [<CustomOperation("fontVariantNumericLiningNums")>]
    member inline _.fontVariantNumericLiningNums([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-numeric", "lining-nums")

    /// Old-style numerals.
    [<CustomOperation("fontVariantNumericOldstyleNums")>]
    member inline _.fontVariantNumericOldstyleNums([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-numeric", "oldstyle-nums")

    /// Proportional numerals.
    [<CustomOperation("fontVariantNumericProportionalNums")>]
    member inline _.fontVariantNumericProportionalNums([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-numeric", "proportional-nums")

    /// Tabular numerals.
    [<CustomOperation("fontVariantNumericTabularNums")>]
    member inline _.fontVariantNumericTabularNums([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-numeric", "tabular-nums")

    /// Diagonal fractions.
    [<CustomOperation("fontVariantNumericDiagonalFractions")>]
    member inline _.fontVariantNumericDiagonalFractions([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-numeric", "diagonal-fractions")

    /// Stacked fractions.
    [<CustomOperation("fontVariantNumericStackedFractions")>]
    member inline _.fontVariantNumericStackedFractions([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-numeric", "stacked-fractions")

    /// Ordinal markers.
    [<CustomOperation("fontVariantNumericOrdinal")>]
    member inline _.fontVariantNumericOrdinal([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-numeric", "ordinal")

    /// Slashed zero.
    [<CustomOperation("fontVariantNumericSlashedZero")>]
    member inline _.fontVariantNumericSlashedZero([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-numeric", "slashed-zero")

    /// Controls the usage of alternate glyphs for numbers, fractions, and ordinal markers.
    [<CustomOperation("fontVariantNumeric")>]
    member inline _.fontVariantNumeric([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("font-variant-numeric", value)

    /// Sets this property to its default value.
    [<CustomOperation("fontVariantNumericInitial")>]
    member inline _.fontVariantNumericInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-numeric", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("fontVariantNumericInheritFromParent")>]
    member inline _.fontVariantNumericInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-numeric", "inherit")

    /// Default.
    [<CustomOperation("fontVariantEastAsianNormal")>]
    member inline _.fontVariantEastAsianNormal([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-east-asian", "normal")

    /// JIS78 glyph forms.
    [<CustomOperation("fontVariantEastAsianJis78")>]
    member inline _.fontVariantEastAsianJis78([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-east-asian", "jis78")

    /// JIS83 glyph forms.
    [<CustomOperation("fontVariantEastAsianJis83")>]
    member inline _.fontVariantEastAsianJis83([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-east-asian", "jis83")

    /// JIS90 glyph forms.
    [<CustomOperation("fontVariantEastAsianJis90")>]
    member inline _.fontVariantEastAsianJis90([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-east-asian", "jis90")

    /// JIS04 glyph forms.
    [<CustomOperation("fontVariantEastAsianJis04")>]
    member inline _.fontVariantEastAsianJis04([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-east-asian", "jis04")

    /// Simplified glyph forms.
    [<CustomOperation("fontVariantEastAsianSimplified")>]
    member inline _.fontVariantEastAsianSimplified([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-east-asian", "simplified")

    /// Traditional glyph forms.
    [<CustomOperation("fontVariantEastAsianTraditional")>]
    member inline _.fontVariantEastAsianTraditional([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-east-asian", "traditional")

    /// Full-width glyphs.
    [<CustomOperation("fontVariantEastAsianFullWidth")>]
    member inline _.fontVariantEastAsianFullWidth([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-east-asian", "full-width")

    /// Proportional-width glyphs.
    [<CustomOperation("fontVariantEastAsianProportionalWidth")>]
    member inline _.fontVariantEastAsianProportionalWidth([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-east-asian", "proportional-width")

    /// Ruby variant glyphs.
    [<CustomOperation("fontVariantEastAsianRuby")>]
    member inline _.fontVariantEastAsianRuby([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-east-asian", "ruby")

    /// Controls the usage of alternate glyphs for East Asian scripts.
    [<CustomOperation("fontVariantEastAsian")>]
    member inline _.fontVariantEastAsian([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("font-variant-east-asian", value)

    /// Sets this property to its default value.
    [<CustomOperation("fontVariantEastAsianInitial")>]
    member inline _.fontVariantEastAsianInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-east-asian", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("fontVariantEastAsianInheritFromParent")>]
    member inline _.fontVariantEastAsianInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-east-asian", "inherit")

    /// Default.
    [<CustomOperation("fontVariantAlternatesNormal")>]
    member inline _.fontVariantAlternatesNormal([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-alternates", "normal")

    /// Historical forms.
    [<CustomOperation("fontVariantAlternatesHistoricalForms")>]
    member inline _.fontVariantAlternatesHistoricalForms([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-alternates", "historical-forms")

    /// Controls the usage of alternate glyphs.
    [<CustomOperation("fontVariantAlternates")>]
    member inline _.fontVariantAlternates([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("font-variant-alternates", value)

    /// Sets this property to its default value.
    [<CustomOperation("fontVariantAlternatesInitial")>]
    member inline _.fontVariantAlternatesInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-alternates", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("fontVariantAlternatesInheritFromParent")>]
    member inline _.fontVariantAlternatesInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-alternates", "inherit")

    /// Default.
    [<CustomOperation("fontVariantPositionNormal")>]
    member inline _.fontVariantPositionNormal([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-position", "normal")

    /// Subscript glyphs.
    [<CustomOperation("fontVariantPositionSub")>]
    member inline _.fontVariantPositionSub([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-position", "sub")

    /// Superscript glyphs.
    [<CustomOperation("fontVariantPositionSuper")>]
    member inline _.fontVariantPositionSuper([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-position", "super")

    /// Controls the usage of alternate glyphs for subscript and superscript.
    [<CustomOperation("fontVariantPosition")>]
    member inline _.fontVariantPosition([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("font-variant-position", value)

    /// Sets this property to its default value.
    [<CustomOperation("fontVariantPositionInitial")>]
    member inline _.fontVariantPositionInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-position", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("fontVariantPositionInheritFromParent")>]
    member inline _.fontVariantPositionInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-position", "inherit")

    /// Default.
    [<CustomOperation("fontVariantEmojiNormal")>]
    member inline _.fontVariantEmojiNormal([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-emoji", "normal")

    /// Text presentation.
    [<CustomOperation("fontVariantEmojiText")>]
    member inline _.fontVariantEmojiText([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-emoji", "text")

    /// Emoji presentation.
    [<CustomOperation("fontVariantEmojiEmoji")>]
    member inline _.fontVariantEmojiEmoji([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-emoji", "emoji")

    /// Unicode-default presentation.
    [<CustomOperation("fontVariantEmojiUnicode")>]
    member inline _.fontVariantEmojiUnicode([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-emoji", "unicode")

    /// Controls the presentation of emoji code points.
    [<CustomOperation("fontVariantEmoji")>]
    member inline _.fontVariantEmoji([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("font-variant-emoji", value)

    /// Sets this property to its default value.
    [<CustomOperation("fontVariantEmojiInitial")>]
    member inline _.fontVariantEmojiInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-emoji", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("fontVariantEmojiInheritFromParent")>]
    member inline _.fontVariantEmojiInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("font-variant-emoji", "inherit")

    /// Words are not hyphenated.
    [<CustomOperation("hyphensNone")>]
    member inline _.hyphensNone([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("hyphens", "none")

    /// Default. Hyphenation only at explicitly suggested breaks.
    [<CustomOperation("hyphensManual")>]
    member inline _.hyphensManual([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("hyphens", "manual")

    /// The browser chooses hyphenation points automatically.
    [<CustomOperation("hyphensAuto")>]
    member inline _.hyphensAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("hyphens", "auto")

    /// Specifies how words should be hyphenated when text wraps across multiple lines.
    [<CustomOperation("hyphens")>]
    member inline _.hyphens([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("hyphens", value)

    /// Sets this property to its default value.
    [<CustomOperation("hyphensInitial")>]
    member inline _.hyphensInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("hyphens", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("hyphensInheritFromParent")>]
    member inline _.hyphensInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("hyphens", "inherit")

    /// Default. The normal inter-word space.
    [<CustomOperation("wordSpacingNormal")>]
    member inline _.wordSpacingNormal([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("word-spacing", "normal")

    /// Sets the length of space between words. Also accepts a length via the string overload (e.g. "0.2em").
    [<CustomOperation("wordSpacing")>]
    member inline _.wordSpacing([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("word-spacing", value)

    /// Sets this property to its default value.
    [<CustomOperation("wordSpacingInitial")>]
    member inline _.wordSpacingInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("word-spacing", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("wordSpacingInheritFromParent")>]
    member inline _.wordSpacingInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("word-spacing", "inherit")

    /// Limits the contents of a block container to the specified number of lines.
    [<CustomOperation("lineClamp")>]
    member inline _.lineClamp([<InlineIfLambda>] comb: CombineKeyValue, value: int) =
        comb &&& mkWithKV ("line-clamp", value)

    /// Limits the contents of a block container to the specified number of lines.
    [<CustomOperation("lineClamp")>]
    member inline _.lineClamp([<InlineIfLambda>] comb: CombineKeyValue, value: float) =
        comb &&& mkWithKV ("line-clamp", value)

    /// Limits the contents of a block container to the specified number of lines.
    [<CustomOperation("lineClamp")>]
    member inline _.lineClamp([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &>> ("line-clamp", value)

    /// Default.
    [<CustomOperation("unicodeBidiNormal")>]
    member inline _.unicodeBidiNormal([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("unicode-bidi", "normal")

    /// An additional level of embedding is opened.
    [<CustomOperation("unicodeBidiEmbed")>]
    member inline _.unicodeBidiEmbed([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("unicode-bidi", "embed")

    /// Reordering is overridden per the direction property.
    [<CustomOperation("unicodeBidiBidiOverride")>]
    member inline _.unicodeBidiBidiOverride([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("unicode-bidi", "bidi-override")

    /// The element is isolated from its surroundings for bidi resolution.
    [<CustomOperation("unicodeBidiIsolate")>]
    member inline _.unicodeBidiIsolate([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("unicode-bidi", "isolate")

    /// Isolate plus override.
    [<CustomOperation("unicodeBidiIsolateOverride")>]
    member inline _.unicodeBidiIsolateOverride([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("unicode-bidi", "isolate-override")

    /// Bidi per the Unicode plaintext algorithm.
    [<CustomOperation("unicodeBidiPlaintext")>]
    member inline _.unicodeBidiPlaintext([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("unicode-bidi", "plaintext")

    /// Together with direction, determines how bidirectional text is handled.
    [<CustomOperation("unicodeBidi")>]
    member inline _.unicodeBidi([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("unicode-bidi", value)

    /// Sets this property to its default value.
    [<CustomOperation("unicodeBidiInitial")>]
    member inline _.unicodeBidiInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("unicode-bidi", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("unicodeBidiInheritFromParent")>]
    member inline _.unicodeBidiInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("unicode-bidi", "inherit")

    /// Default.
    [<CustomOperation("colorSchemeNormal")>]
    member inline _.colorSchemeNormal([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("color-scheme", "normal")

    /// Light color scheme.
    [<CustomOperation("colorSchemeLight")>]
    member inline _.colorSchemeLight([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("color-scheme", "light")

    /// Dark color scheme.
    [<CustomOperation("colorSchemeDark")>]
    member inline _.colorSchemeDark([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("color-scheme", "dark")

    /// Forbids the user agent from overriding the scheme.
    [<CustomOperation("colorSchemeOnly")>]
    member inline _.colorSchemeOnly([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("color-scheme", "only")

    /// Indicates which color schemes an element can be rendered in (e.g. light/dark).
    [<CustomOperation("colorScheme")>]
    member inline _.colorScheme([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("color-scheme", value)

    /// Sets this property to its default value.
    [<CustomOperation("colorSchemeInitial")>]
    member inline _.colorSchemeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &>> ("color-scheme", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("colorSchemeInheritFromParent")>]
    member inline _.colorSchemeInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("color-scheme", "inherit")

    /// Default. Colors are forced per the system.
    [<CustomOperation("forcedColorAdjustAuto")>]
    member inline _.forcedColorAdjustAuto([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("forced-color-adjust", "auto")

    /// The element's colors are not automatically adjusted.
    [<CustomOperation("forcedColorAdjustNone")>]
    member inline _.forcedColorAdjustNone([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("forced-color-adjust", "none")

    /// Preserve the parent's forced color.
    [<CustomOperation("forcedColorAdjustPreserveParentColor")>]
    member inline _.forcedColorAdjustPreserveParentColor([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("forced-color-adjust", "preserve-parent-color")

    /// Allows certain elements to opt out of forced colors mode.
    [<CustomOperation("forcedColorAdjust")>]
    member inline _.forcedColorAdjust([<InlineIfLambda>] comb: CombineKeyValue, value: string) =
        comb &>> ("forced-color-adjust", value)

    /// Sets this property to its default value.
    [<CustomOperation("forcedColorAdjustInitial")>]
    member inline _.forcedColorAdjustInitial([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("forced-color-adjust", "initial")

    /// Inherits this property from its parent element.
    [<CustomOperation("forcedColorAdjustInheritFromParent")>]
    member inline _.forcedColorAdjustInheritFromParent([<InlineIfLambda>] comb: CombineKeyValue) =
        comb &>> ("forced-color-adjust", "inherit")
