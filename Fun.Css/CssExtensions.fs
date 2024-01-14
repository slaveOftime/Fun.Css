[<AutoOpen>]
module Fun.Css.Extensions

open Internal


/// The overflow property specifies what should happen if content overflows an element's box.
[<RequireQualifiedAccess>]
module overflow =

    /// If overflow is clipped, a scroll-bar should be added to see the rest of the content
    let auto = CombineKeyValue(fun sb -> sb.Append("overflow: ").Append("auto").Append("; "))

    /// The overflow is clipped, and the rest of the content will be invisible. Forbids scrolling, including programmatic scrolling.
    let clip = CombineKeyValue(fun sb -> sb.Append("overflow: ").Append("clip").Append("; "))

    /// The overflow is clipped, and the rest of the content will be invisible. Content can be scrolled programmatically (e.g. by setting scrollLeft or scrollTo())
    let hidden = CombineKeyValue(fun sb -> sb.Append("overflow: ").Append("hidden").Append("; "))

    /// Inherits this property from its parent element. Read about inherit
    let inherit' = CombineKeyValue(fun sb -> sb.Append("overflow: ").Append("inherit").Append("; "))

    /// Sets this property to its default value. Read about initial
    let initial = CombineKeyValue(fun sb -> sb.Append("overflow: ").Append("initial").Append("; "))

    /// The overflow is clipped, but a scroll-bar is added to see the rest of the content
    let scroll = CombineKeyValue(fun sb -> sb.Append("overflow: ").Append("scroll").Append("; "))

    /// The overflow is not clipped. It renders outside the element's box. This is default
    let visible = CombineKeyValue(fun sb -> sb.Append("overflow: ").Append("visible").Append("; "))

/// The text-align property specifies the horizontal alignment of text in an element.
[<RequireQualifiedAccess>]
module textAlign =

    let left = CombineKeyValue(fun sb -> sb.Append("text-align: ").Append("left").Append("; "))
    let right = CombineKeyValue(fun sb -> sb.Append("text-align: ").Append("right").Append("; "))
    let center = CombineKeyValue(fun sb -> sb.Append("text-align: ").Append("center").Append("; "))
    let justify = CombineKeyValue(fun sb -> sb.Append("text-align: ").Append("justify").Append("; "))
    let initial = CombineKeyValue(fun sb -> sb.Append("text-align: ").Append("initial").Append("; "))
    let inherit' = CombineKeyValue(fun sb -> sb.Append("text-align: ").Append("inherit").Append("; "))