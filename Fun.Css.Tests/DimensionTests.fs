module Fun.Css.Tests.DimensionTests

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
let ``width overloads`` () =
    let actual =
        style {
            width 100
            width "50%"
        }

    Assert.Equal("width: 100px; width: 50%; ", actual)

[<Fact>]
let ``minWidth and maxWidth overloads`` () =
    let actual =
        style {
            minWidth 10
            minWidth "10rem"
            maxWidth 200
            maxWidth "80%"
        }

    Assert.Equal("min-width: 10px; min-width: 10rem; max-width: 200px; max-width: 80%; ", actual)

[<Fact>]
let ``height overloads and keywords`` () =
    let actual =
        style {
            height 100
            height "100vh"
            heightMaxContent
            heightMinContent
            heightInitial
            heightInheritFromParent
        }

    Assert.Equal(
        "height: 100px; height: 100vh; height: max-content; height: min-content; height: initial; height: inherit; ",
        actual
    )

[<Fact>]
let ``top right bottom left overloads`` () =
    let actual =
        style {
            top 10
            top "10%"
            right 20
            right "auto"
            bottom 30
            bottom "1rem"
            left 40
            left "0"
        }

    Assert.Equal(
        "top: 10px; top: 10%; right: 20px; right: auto; bottom: 30px; bottom: 1rem; left: 40px; left: 0; ",
        actual
    )

[<Fact>]
let ``margin all overloads`` () =
    let actual =
        style {
            margin 10
            margin "1rem"
            margin 10 20
            margin "1rem" "2rem"
            margin 1 2 3 4
            margin "1px" "2px" "3px" "4px"
        }

    Assert.Equal(
        "margin: 10px; margin: 1rem; margin: 10px 20px; margin: 1rem 2rem; margin: 1px 2px 3px 4px; margin: 1px 2px 3px 4px; ",
        actual
    )

[<Fact>]
let ``margin sides overloads`` () =
    let actual =
        style {
            marginLeft 5
            marginLeft "auto"
            marginRight 6
            marginRight "auto"
            marginTop 7
            marginTop "1em"
            marginBottom 8
            marginBottom "2em"
        }

    Assert.Equal(
        "margin-left: 5px; margin-left: auto; margin-right: 6px; margin-right: auto; margin-top: 7px; margin-top: 1em; margin-bottom: 8px; margin-bottom: 2em; ",
        actual
    )

[<Fact>]
let ``padding all overloads`` () =
    let actual =
        style {
            padding 10
            padding "1rem"
            padding 10 20
            padding "1rem" "2rem"
            padding 1 2 3 4
            padding "1px" "2px" "3px" "4px"
        }

    Assert.Equal(
        "padding: 10px; padding: 1rem; padding: 10px 20px; padding: 1rem 2rem; padding: 1px 2px 3px 4px; padding: 1px 2px 3px 4px; ",
        actual
    )

[<Fact>]
let ``padding sides overloads`` () =
    let actual =
        style {
            paddingLeft 5
            paddingLeft "1em"
            paddingRight 6
            paddingRight "2em"
            paddingTop 7
            paddingTop "3em"
            paddingBottom 8
            paddingBottom "4em"
        }

    Assert.Equal(
        "padding-left: 5px; padding-left: 1em; padding-right: 6px; padding-right: 2em; padding-top: 7px; padding-top: 3em; padding-bottom: 8px; padding-bottom: 4em; ",
        actual
    )

[<Fact>]
let ``zIndex and opacity`` () =
    let actual =
        style {
            zIndex 10
            opacity 0.5
        }

    Assert.Equal("z-index: 10; opacity: 0.5; ", actual)

[<Fact>]
let ``zoom`` () =
    let actual = style { zoom 1.5 }
    Assert.Equal("zoom: 1.5; ", actual)

[<Fact>]
let ``box sizing and display samples`` () =
    let actual =
        style {
            boxSizingBorderBox
            displayNone
            displayBlock
            displayInlineElement
            displayGrid
            displayContents
        }

    Assert.Equal(
        "box-sizing: border-box; display: none; display: block; display: inline; display: grid; display: contents; ",
        actual
    )

[<Fact>]
let ``position keywords`` () =
    let actual =
        style {
            positionDefaultStatic
            positionRelative
            positionAbsolute
            positionFixed
            positionSticky
        }

    Assert.Equal(
        "position: static; position: relative; position: absolute; position: fixed; position: sticky; ",
        actual
    )

[<Fact>]
let ``overflow variants`` () =
    let actual =
        style {
            overflowHidden
            overflowXAuto
            overflowYScroll
        }

    Assert.Equal("overflow: hidden; overflow-x: auto; overflow-y: scroll; ", actual)

[<Fact>]
let ``all shorthand keywords`` () =
    let actual =
        style {
            allInitial
            allInherit
            allUnset
            allRevert
        }

    Assert.Equal("all: initial; all: inherit; all: unset; all: revert; ", actual)
