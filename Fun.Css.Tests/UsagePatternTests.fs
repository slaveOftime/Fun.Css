module Fun.Css.Tests.UsagePatternTests

// Tests for the consumption patterns documented in SKILL.md: reusable style
// fragments, custom operation extensions, fragment composition, and mixing
// conditional blocks with custom operations.

open System.Text
open Microsoft.Extensions.ObjectPool
open Xunit
open Fun.Css
open Fun.Css.Internal

let private objectPoolProvider = DefaultObjectPoolProvider()
let private stringBuilderPool = objectPoolProvider.CreateStringBuilderPool()

type private StyleStrBuilder() =
    inherit Fun.Css.CssBuilder()

    member inline _.Run([<InlineIfLambda>] combine: CombineKeyValue) =
        let sb = stringBuilderPool.Get()
        let str = combine.Invoke(sb).ToString()
        stringBuilderPool.Return sb
        str

let private style = StyleStrBuilder()

let private render (comb: CombineKeyValue) =
    let sb = stringBuilderPool.Get()
    let str = comb.Invoke(sb).ToString()
    stringBuilderPool.Return sb
    str

// Fragment builder with the default Run (returns the CombineKeyValue fragment).
let private css = Fun.Css.CssBuilder()

// SKILL.md "Reusable styles > 1. Shared fragment values"
module private SharedStyles =
    let ClickableGreen =
        css {
            cursorPointer
            color "green"
        }

// SKILL.md "Reusable styles > 2. Custom operation extensions"
[<AutoOpen>]
module private StyleExtensions =
    type Fun.Css.CssBuilder with

        [<CustomOperation "VStack">]
        member inline _.VStack([<InlineIfLambda>] comb: CombineKeyValue) =
            comb
            &&& css {
                displayFlex
                flexDirectionColumn
            }

        [<CustomOperation "EvenHStack">]
        member inline this.EvenHStack([<InlineIfLambda>] comb: CombineKeyValue) =
            comb
            &&& css {
                displayFlex
                custom "justify-content" "space-evenly"
            }

[<Fact>]
let ``shared fragment value embeds into a style block`` () =
    let actual =
        style {
            SharedStyles.ClickableGreen
            fontSize 16
        }

    Assert.Equal("cursor: pointer; color: green; font-size: 16px; ", actual)

[<Fact>]
let ``custom operation extension composes predefined styles`` () =
    let actual = style { VStack }

    Assert.Equal("display: flex; flex-direction: column; ", actual)

[<Fact>]
let ``multiple custom operation extensions compose in order`` () =
    let actual =
        style {
            VStack
            EvenHStack
        }

    Assert.Equal("display: flex; flex-direction: column; display: flex; justify-content: space-evenly; ", actual)

[<Fact>]
let ``one style block embeds another fragment directly`` () =
    let baseFrag =
        css {
            margin 0
            padding 10
        }

    let actual =
        style {
            baseFrag
            color "red"
        }

    Assert.Equal("margin: 0px; padding: 10px; color: red; ", actual)

[<Fact>]
let ``fragments merge with andand combinator`` () =
    let baseFrag =
        css {
            margin 0
            padding 10
        }

    let combined = baseFrag &&& css { color "red" }

    Assert.Equal("margin: 0px; padding: 10px; color: red; ", render combined)

[<Fact>]
let ``conditional yield block combines with custom ops via andand`` () =
    let condFrag =
        css {
            if true then
                yield ("font-weight", "bold")

            for size in [ 8; 12 ] do
                yield ("margin-bottom", string size + "px")
        }

    let actual = style { condFrag &&& css { displayFlex } }

    Assert.Equal("font-weight: bold; margin-bottom: 8px; margin-bottom: 12px; display: flex; ", actual)

[<Fact>]
let ``conditional block result concatenates with built string`` () =
    let custom = style { displayFlex }

    let conditional =
        style {
            if true then
                yield ("color", "blue")
        }

    Assert.Equal("display: flex; color: blue; ", custom + conditional)
