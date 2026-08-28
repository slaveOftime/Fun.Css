#nowarn "44" // obsolete-op usage is intentional: verifies legacy names keep working (backward compatibility)

module Fun.Css.Tests.MiscTests

open Microsoft.Extensions.ObjectPool
open Xunit


let objectPoolProvider = DefaultObjectPoolProvider()
let stringBuilderPool = objectPoolProvider.CreateStringBuilderPool()

type StyleStrBuilder() =
    inherit Fun.Css.CssBuilder()

    member inline _.Run([<InlineIfLambda>] combine: Fun.Css.Internal.CombineKeyValue) =
        let sb = stringBuilderPool.Get()
        let str = combine.Invoke(sb).ToString()
        stringBuilderPool.Return sb
        str

let style = StyleStrBuilder()

[<Fact>]
let ``border radius, color, width and style`` () =
    let actual =
        style {
            borderRadius 10
            borderRadius "50%"
            borderColor "red"
            borderWidth 2
            borderStyleSolid
            borderStyleDashed
            borderStyleDotted
            borderStyleDouble
            borderStyleGroove
            borderStyleRidge
            borderStyleInset
            borderStyleOutset
            borderStyleNone
            borderStyleHidden
            borderStyleInitial
            borderStyleInheritFromParent
        }

    Assert.Equal(
        "border-radius: 10px; border-radius: 50%; border-color: red; border-width: 2px; border-style: solid; border-style: dashed; border-style: dotted; border-style: double; border-style: groove; border-style: ridge; border-style: inset; border-style: outset; border-style: none; border-style: hidden; border-style: initial; border-style: inherit; ",
        actual
    )

[<Fact>]
let ``borderWidth multi-value overloads`` () =
    let actual =
        style {
            borderWidth "1px" "2px"
            borderWidth "1px"
            borderWidth "1px" "2px" "3px" "4px"
        }

    Assert.Equal("border-width: 1px 2px; border-width: 1px; border-width: 1px 2px 3px 4px; ", actual)

[<Fact>]
let ``cursor variants`` () =
    let actual =
        style {
            cursor "crosshair"
            cursorAuto
            cursorPointer
            cursorMove
            cursorNotAllowed
            cursorGrab
            cursorGrabbing
            cursorZoomIn
            cursorZoomOut
            cursorWait
            cursorText
            cursorNone
        }

    Assert.Equal(
        "cursor: crosshair; cursor: auto; cursor: pointer; cursor: move; cursor: not-allowed; cursor: grab; cursor: grabbing; cursor: zoom-in; cursor: zoom-out; cursor: wait; cursor: text; cursor: none; ",
        actual
    )

[<Fact>]
let ``visibility keywords`` () =
    let actual =
        style {
            visibilityHidden
            visibilityVisible
            visibilityCollapse
            visibilityInitial
            visibilityInheritFromParent
        }

    Assert.Equal(
        "visibility: hidden; visibility: visible; visibility: collapse; visibility: initial; visibility: inherit; ",
        actual
    )

[<Fact>]
let ``float and clear`` () =
    let actual =
        style {
            floatLeft
            floatRight
            floatNone
        }

    Assert.Equal("float: left; float: right; float: none; ", actual)

[<Fact>]
let ``floatStyle keywords and string overload`` () =
    let actual =
        style {
            floatStyleLeft
            floatStyleRight
            floatStyleNone
            floatStyle "var(--float)"
        }

    Assert.Equal("float: left; float: right; float: none; float: var(--float); ", actual)

[<Fact>]
let ``colors and caret`` () =
    let actual =
        style {
            color "rebeccapurple"
            backgroundColor "#fff"
            caretColor "auto"
        }

    Assert.Equal("color: rebeccapurple; background-color: #fff; caret-color: auto; ", actual)

[<Fact>]
let ``background image and url helper`` () =
    let actual =
        style {
            backgroundImage "linear-gradient(red, blue)"
            backgroundImageUrl "images/bg.png"
        }

    Assert.Equal("background-image: linear-gradient(red, blue); background-image: url('images/bg.png'); ", actual)

[<Fact>]
let ``backgroundSize overloads`` () =
    let actual =
        style {
            backgroundSize "100% 100%"
            backgroundSize "100px" "auto"
            backgroundSizeAuto
            backgroundSizeCover
            backgroundSizeContain
        }

    Assert.Equal(
        "background-size: 100% 100%; background-size: 100px auto; background-size: auto; background-size: cover; background-size: contain; ",
        actual
    )

[<Fact>]
let ``backgroundRepeat keywords`` () =
    let actual =
        style {
            backgroundRepeatRepeat
            backgroundRepeatRepeatX
            backgroundRepeatRepeatY
            backgroundRepeatNoRepeat
            backgroundRepeatInitial
            backgroundRepeatInheritFromParent
        }

    Assert.Equal(
        "background-repeat: repeat; background-repeat: repeat-x; background-repeat: repeat-y; background-repeat: no-repeat; background-repeat: initial; background-repeat: inherit; ",
        actual
    )

[<Fact>]
let ``listStyleType and listStylePosition keywords`` () =
    let actual =
        style {
            listStyleTypeDisc
            listStyleTypeCircle
            listStyleTypeSquare
            listStyleTypeDecimal
            listStyleTypeLowerRoman
            listStyleTypeUpperAlpha
            listStyleTypeNone
            listStylePositionInside
            listStylePositionOutside
        }

    Assert.Equal(
        "list-style-type: disc; list-style-type: circle; list-style-type: square; list-style-type: decimal; list-style-type: lower-roman; list-style-type: upper-alpha; list-style-type: none; list-style-position: inside; list-style-position: outside; ",
        actual
    )

[<Fact>]
let ``direction keywords`` () =
    let actual =
        style {
            directionLeftToRight
            directionRightToLeft
            directionInitial
            directionInheritFromParent
        }

    Assert.Equal("direction: ltr; direction: rtl; direction: initial; direction: inherit; ", actual)

[<Fact>]
let ``userSelect keywords`` () =
    let actual =
        style {
            userSelectAll
            userSelectAuto
            userSelectNone
            userSelectText
            userSelectInitial
            userSelectInheritFromParent
        }

    Assert.Equal(
        "user-select: all; user-select: auto; user-select: none; user-select: text; user-select: initial; user-select: inherit; ",
        actual
    )

[<Fact>]
let ``scrollBehavior keywords`` () =
    let actual =
        style {
            scrollBehaviorAuto
            scrollBehaviorSmooth
            scrollBehaviorInitial
            scrollBehaviorInheritFromParent
        }

    Assert.Equal(
        "scroll-behavior: auto; scroll-behavior: smooth; scroll-behavior: initial; scroll-behavior: inherit; ",
        actual
    )

[<Fact>]
let ``outlineStyle keywords`` () =
    let actual =
        style {
            outlineStyleAuto
            outlineStyleDashed
            outlineStyleDotted
            outlineStyleSolid
            outlineStyleNone
            outlineStyleInitial
            outlineStyleInheritFromParent
        }

    Assert.Equal(
        "outline-style: auto; outline-style: dashed; outline-style: dotted; outline-style: solid; outline-style: none; outline-style: initial; outline-style: inherit; ",
        actual
    )

[<Fact>]
let ``writingMode keywords`` () =
    let actual =
        style {
            writingModeHorizontalTopBottom
            writingModeVerticalLeftRight
            writingModeVerticalRightLeft
            writingModeInitial
            writingModeInheritFromParent
        }

    Assert.Equal(
        "writing-mode: horizontal-tb; writing-mode: vertical-lr; writing-mode: vertical-rl; writing-mode: initial; writing-mode: inherit; ",
        actual
    )

[<Fact>]
let ``emptyCells and tableLayout`` () =
    let actual =
        style {
            emptyCellsShow
            emptyCellsHide
            tableLayoutAuto
            tableLayoutFixed'
        }

    Assert.Equal("empty-cells: show; empty-cells: hide; table-layout: auto; table-layout: fixed; ", actual)

[<Fact>]
let ``tableLayoutFixed (new name) and string overloads`` () =
    let actual =
        style {
            tableLayoutFixed
            tableLayout "var(--table-layout)"
            emptyCells "var(--empty-cells)"
        }

    Assert.Equal("table-layout: fixed; table-layout: var(--table-layout); empty-cells: var(--empty-cells); ", actual)

[<Fact>]
let ``fill and stroke for SVG`` () =
    let actual = style { fill "currentColor" }
    Assert.Equal("fill: currentColor; ", actual)

[<Fact>]
let ``string overloads for keyword-only properties (design token support)`` () =
    let actual =
        style {
            visibility "var(--visibility)"
            overflow "var(--overflow)"
            overflowX "var(--overflow-x)"
            overflowY "var(--overflow-y)"
            resize "var(--resize)"
            userSelect "var(--user-select)"
            scrollBehavior "var(--scroll-behavior)"
            listStyleType "var(--list-style-type)"
            listStylePosition "var(--list-style-position)"
            borderCollapse "var(--border-collapse)"
            direction "var(--direction)"
            writingMode "var(--writing-mode)"
            outlineStyle "var(--outline-style)"
            backgroundClip "var(--background-clip)"
            backgroundBlendMode "var(--background-blend-mode)"
            filter "var(--filter)"
        }

    Assert.Equal(
        "visibility: var(--visibility); overflow: var(--overflow); overflow-x: var(--overflow-x); overflow-y: var(--overflow-y); resize: var(--resize); user-select: var(--user-select); scroll-behavior: var(--scroll-behavior); list-style-type: var(--list-style-type); list-style-position: var(--list-style-position); border-collapse: var(--border-collapse); direction: var(--direction); writing-mode: var(--writing-mode); outline-style: var(--outline-style); background-clip: var(--background-clip); background-blend-mode: var(--background-blend-mode); filter: var(--filter); ",
        actual
    )

[<Fact>]
let ``new standard property coverage ops`` () =
    let actual =
        style {
            order 2
            order "var(--order)"
            flexFlow "row wrap"
            outline "2px solid red"
            outlineWidth 2.5
            background "url(a.png) no-repeat center / cover"
            backgroundAttachmentFixed
            backgroundOrigin "padding-box"
            backgroundPositionX "left"
            backgroundPositionY "10px"
            font "italic bold 12px/1.5 sans-serif"
            textDecorationThickness "0.1em"
            textDecorationSkipInkNone
            textAlignLastCenter
            tabSize 4
            overflowWrap "anywhere"
            textRenderingOptimizeLegibility
            textSizeAdjust "100%"
            textOrientationUpright
            gridAutoRows "minmax(100px, auto)"
            gridAutoColumns "auto"
            gridAutoFlowRowDense
            grid "auto-flow / 1fr 1fr"
            listStyle "square inside"
            transitionBehaviorAllowDiscrete
            transformBoxFillBox
            backfaceVisibilityHidden
            inset 0
            aspectRatio "16 / 9"
            containPaint
            marginBlockStart 10
            marginInlineEnd "var(--margin-end)"
            paddingBlockStart 10
            paddingInlineEnd "1em"
            scrollSnapAlignStart
            scrollSnapTypeXMandatory
            scrollSnapStopAlways
            scrollMargin "10px"
            scrollPadding "10px"
            borderTopLeftRadius 8
            borderBottomRightRadius "50%"
        }

    Assert.Equal(
        "order: 2; order: var(--order); flex-flow: row wrap; outline: 2px solid red; outline-width: 2.5px; background: url(a.png) no-repeat center / cover; background-attachment: fixed; background-origin: padding-box; background-position-x: left; background-position-y: 10px; font: italic bold 12px/1.5 sans-serif; text-decoration-thickness: 0.1em; text-decoration-skip-ink: none; text-align-last: center; tab-size: 4; overflow-wrap: anywhere; text-rendering: optimizeLegibility; text-size-adjust: 100%; text-orientation: upright; grid-auto-rows: minmax(100px, auto); grid-auto-columns: auto; grid-auto-flow: row dense; grid: auto-flow / 1fr 1fr; list-style: square inside; transition-behavior: allow-discrete; transform-box: fill-box; backface-visibility: hidden; inset: 0px; aspect-ratio: 16 / 9; contain: paint; margin-block-start: 10px; margin-inline-end: var(--margin-end); padding-block-start: 10px; padding-inline-end: 1em; scroll-snap-align: start; scroll-snap-type: x mandatory; scroll-snap-stop: always; scroll-margin: 10px; scroll-padding: 10px; border-top-left-radius: 8px; border-bottom-right-radius: 50%; ",
        actual
    )

[<Fact>]
let ``layout coverage ops`` () =
    let actual =
        style {
            clearBoth
            clear "var(--clear)"
            objectFitCover
            objectFit "contain"
            objectPosition "top right"
            pointerEventsNone
            pointerEvents "var(--pe)"
            touchActionManipulation
            willChangeTransform
            overscrollBehaviorContain
            overscrollBehaviorXNone
            overscrollBehaviorYAuto
            isolationIsolate
            mixBlendModeMultiply
            mixBlendMode "var(--blend)"
            overflowBlockHidden
            overflowInlineAuto
            content "\"hello\""
            perspective "500px"
            perspectiveNone
            perspectiveOrigin "50% 50%"
        }

    Assert.Equal(
        "clear: both; clear: var(--clear); object-fit: cover; object-fit: contain; object-position: top right; pointer-events: none; pointer-events: var(--pe); touch-action: manipulation; will-change: transform; overscroll-behavior: contain; overscroll-behavior-x: none; overscroll-behavior-y: auto; isolation: isolate; mix-blend-mode: multiply; mix-blend-mode: var(--blend); overflow-block: hidden; overflow-inline: auto; content: \"hello\"; perspective: 500px; perspective: none; perspective-origin: 50% 50%; ",
        actual
    )

[<Fact>]
let ``border and mask coverage ops`` () =
    let actual =
        style {
            borderImage "url(b.png) 30 round"
            borderImageSource "url(b.png)"
            borderImageSlice "30"
            borderImageWidth "10px"
            borderImageOutset "5px"
            borderImageRepeatRound
            borderBlock "1px solid red"
            borderBlockColor "red"
            borderBlockStyleDashed
            borderBlockWidth "2px"
            borderInline "1px solid blue"
            borderInlineColor "blue"
            borderInlineStyleDotted
            borderInlineWidth "3px"
            borderBlockStart "1px solid red"
            borderBlockEnd "1px solid red"
            borderInlineStart "2px solid blue"
            borderInlineEnd "2px solid blue"
            marginTrimBlock
            mask "url(m.png)"
            maskImage "url(m.png)"
            maskSize "cover"
            maskRepeatNoRepeat
            maskPosition "center"
            maskClip "padding-box"
            maskOrigin "content-box"
            maskCompositeIntersect
        }

    Assert.Equal(
        "border-image: url(b.png) 30 round; border-image-source: url(b.png); border-image-slice: 30; border-image-width: 10px; border-image-outset: 5px; border-image-repeat: round; border-block: 1px solid red; border-block-color: red; border-block-style: dashed; border-block-width: 2px; border-inline: 1px solid blue; border-inline-color: blue; border-inline-style: dotted; border-inline-width: 3px; border-block-start: 1px solid red; border-block-end: 1px solid red; border-inline-start: 2px solid blue; border-inline-end: 2px solid blue; margin-trim: block; mask: url(m.png); mask-image: url(m.png); mask-size: cover; mask-repeat: no-repeat; mask-position: center; mask-clip: padding-box; mask-origin: content-box; mask-composite: intersect; ",
        actual
    )

[<Fact>]
let ``typography coverage ops`` () =
    let actual =
        style {
            fontSizeAdjust "0.5"
            fontSizeAdjustFromFont
            fontSynthesisWeight
            fontFeatureSettings "\"liga\" 1"
            fontVariationSettings "\"wght\" 700"
            fontVariantCapsSmallCaps
            fontVariantLigaturesCommonLigatures
            fontVariantNumericTabularNums
            fontVariantEastAsianSimplified
            fontVariantAlternatesHistoricalForms
            fontVariantPositionSub
            fontVariantEmojiEmoji
            hyphensAuto
            wordSpacingNormal
            lineClamp 3
            unicodeBidiIsolate
            colorSchemeDark
            forcedColorAdjustNone
        }

    Assert.Equal(
        "font-size-adjust: 0.5; font-size-adjust: from-font; font-synthesis: weight; font-feature-settings: \"liga\" 1; font-variation-settings: \"wght\" 700; font-variant-caps: small-caps; font-variant-ligatures: common-ligatures; font-variant-numeric: tabular-nums; font-variant-east-asian: simplified; font-variant-alternates: historical-forms; font-variant-position: sub; font-variant-emoji: emoji; hyphens: auto; word-spacing: normal; line-clamp: 3; unicode-bidi: isolate; color-scheme: dark; forced-color-adjust: none; ",
        actual
    )

[<Fact>]
let ``table list grid and break coverage ops`` () =
    let actual =
        style {
            captionSideBottom
            counterReset "section"
            counterIncrement "item 2"
            counterSet "section 5"
            columns "auto 3"
            columnWidthAuto
            columnCount 3
            columnFillBalance
            columnSpanAll
            columnRule "1px solid gray"
            columnRuleWidthThin
            columnRuleStyleSolid
            columnRuleColor "gray"
            containIntrinsicSize "300px 200px"
            containIntrinsicWidth "300px"
            containIntrinsicHeight "200px"
            breakBeforePage
            breakAfterAlways
            breakInsideAvoid
            pageBreakBeforeAlways
            pageBreakAfterAvoid
            pageBreakInsideAuto
        }

    Assert.Equal(
        "caption-side: bottom; counter-reset: section; counter-increment: item 2; counter-set: section 5; columns: auto 3; column-width: auto; column-count: 3; column-fill: balance; column-span: all; column-rule: 1px solid gray; column-rule-width: thin; column-rule-style: solid; column-rule-color: gray; contain-intrinsic-size: 300px 200px; contain-intrinsic-width: 300px; contain-intrinsic-height: 200px; break-before: page; break-after: always; break-inside: avoid; page-break-before: always; page-break-after: avoid; page-break-inside: auto; ",
        actual
    )

[<Fact>]
let ``scroll longhand and new overload coverage ops`` () =
    let actual =
        style {
            scrollMarginTop "10px"
            scrollMarginRight "10px"
            scrollMarginBottom "10px"
            scrollMarginLeft "10px"
            scrollPaddingTop "1em"
            scrollPaddingRight "1em"
            scrollPaddingBottom "1em"
            scrollPaddingLeft "1em"
            backgroundSize 100
            backgroundSize 50.5
            transitionProperty [ "opacity"; "transform" ]
        }

    Assert.Equal(
        "scroll-margin-top: 10px; scroll-margin-right: 10px; scroll-margin-bottom: 10px; scroll-margin-left: 10px; scroll-padding-top: 1em; scroll-padding-right: 1em; scroll-padding-bottom: 1em; scroll-padding-left: 1em; background-size: 100px; background-size: 50.5px; transition-property: opacity, transform; ",
        actual
    )
