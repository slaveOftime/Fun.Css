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

    Assert.Equal("border-width: 1px, 2px; border-width: 1px; border-width: 1px, 2px, 3px, , 4px; ", actual)

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
        "background-size: 100% 100%; background-size: 100px, auto; background-size: auto; background-size: cover; background-size: contain; ",
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
let ``fill and stroke for SVG`` () =
    let actual = style { fill "currentColor" }
    Assert.Equal("fill: currentColor; ", actual)
