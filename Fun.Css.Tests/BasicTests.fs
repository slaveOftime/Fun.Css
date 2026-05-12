module Fun.Css.Tests.BasicTests

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
let ``Most used css should work`` () =
    let actual = style {
        backgroundColor "#44c767"
        borderRadius 30
        borderWidth 1
        borderStyleSolid
        borderColor "#18ab29"
        displayInlineBlock
        cursorPointer
        fontSize 17
    }
    Assert.Equal(
        "background-color: #44c767; border-radius: 30px; border-width: 1px; border-style: solid; border-color: #18ab29; display: inline-block; cursor: pointer; font-size: 17px; ",
        actual
    )

[<Fact>]
let ``Flex should work`` () =
    let actual = style {
        displayFlex
        flex 1
        flex 1 1
        flex 1 "10%"
        flex 1 1 "10%"
        flexGrow 1
    }
    Assert.Equal("display: flex; flex: 1; flex: 1 1; flex: 1 10%; flex: 1 1 10%; flex-grow: 1; ", actual)

[<Fact>]
let ``max-height and min-height with intrinsic sizing should emit the right property`` () =
    let actual = style {
        maxHeightMaxContent
        maxHeightMinContent
        minHeightMaxContent
        minHeightMinContent
    }
    Assert.Equal("max-height: max-content; max-height: min-content; min-height: max-content; min-height: min-content; ", actual)

[<Fact>]
let ``flex-direction initial and inherit should emit flex-direction`` () =
    let actual = style {
        flexDirectionInitial
        flexDirectionInheritFromParent
    }
    Assert.Equal("flex-direction: initial; flex-direction: inherit; ", actual)

[<Fact>]
let ``outline-offset should emit outline-offset`` () =
    let actual = style {
        outlineOffset 4
        outlineOffset "1rem"
    }
    Assert.Equal("outline-offset: 4px; outline-offset: 1rem; ", actual)

[<Fact>]
let ``justify-items and justify-self Strench should emit the valid stretch value`` () =
    let actual = style {
        justifyItemsStrench
        justifySelfStrench
    }
    Assert.Equal("justify-items: stretch; justify-self: stretch; ", actual)
