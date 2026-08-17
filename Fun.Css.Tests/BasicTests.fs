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
let ``font-weight string should work`` () =
    let actual = style {
        fontWeight "bold"
        fontWeight "var(--typography-strong-font-weight)"
    }
    Assert.Equal("font-weight: bold; font-weight: var(--typography-strong-font-weight); ", actual)
    
[<Fact>]
let ``letter-spacing should work`` () =
    let actual = style {
        letterSpacing 2
        letterSpacing "0.08em"
        letterSpacingNormal
        letterSpacingInitial
        letterSpacingInheritFromParent
    }
    Assert.Equal("letter-spacing: 2px; letter-spacing: 0.08em; letter-spacing: normal; letter-spacing: initial; letter-spacing: inherit; ", actual)
