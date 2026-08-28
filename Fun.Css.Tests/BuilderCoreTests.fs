module Fun.Css.Tests.BuilderCoreTests

open System.Text
open Microsoft.Extensions.ObjectPool
open Xunit
open Fun.Css

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

let private render (comb: Internal.CombineKeyValue) =
    let sb = stringBuilderPool.Get()
    let str = comb.Invoke(sb).ToString()
    stringBuilderPool.Return sb
    str

[<Fact>]
let ``Yield unit produces empty string`` () =
    let actual = style { () }
    Assert.Equal("", actual)

[<Fact>]
let ``Yield raw key-value string appends with trailing semicolon`` () =
    let actual = style { "color: red" }
    Assert.Equal("color: red; ", actual)

[<Fact>]
let ``Yield string tuple emits key value pair`` () =
    let actual = style { yield ("color", "blue") }
    Assert.Equal("color: blue; ", actual)

[<Fact>]
let ``Yield int tuple emits key value pair`` () =
    let actual = style { yield ("z-index", 5) }
    Assert.Equal("z-index: 5; ", actual)

[<Fact>]
let ``Yield float tuple emits key value pair`` () =
    let actual = style { yield ("opacity", 0.5) }
    Assert.Equal("opacity: 0.5; ", actual)

[<Fact>]
let ``Yield bool tuple emits key value pair`` () =
    let actual = style { yield ("flag", true) }
    Assert.Equal("flag: True; ", actual)

[<Fact>]
let ``if-else branching works with yielded tuples`` () =
    let useRed = true

    let actual =
        style {
            if useRed then
                yield ("color", "red")
            else
                yield ("color", "blue")
        }

    Assert.Equal("color: red; ", actual)

[<Fact>]
let ``if without else yields Zero`` () =
    let actual =
        style {
            if false then
                yield ("color", "red")
        }

    Assert.Equal("", actual)

[<Fact>]
let ``for loop over sequence works with yielded values`` () =
    let actual =
        style {
            for i in 1..3 do
                yield ($"prop-{i}", string i)
        }

    Assert.Equal("prop-1: 1; prop-2: 2; prop-3: 3; ", actual)

[<Fact>]
let ``for loop with list of colors`` () =
    let colors = [ "red"; "green" ]

    let actual =
        style {
            for c in colors do
                yield ("border-color", c)
        }

    Assert.Equal("border-color: red; border-color: green; ", actual)

[<Fact>]
let ``custom operation appends arbitrary key value`` () =
    let actual =
        style {
            custom "--my-var" "10px"
            custom "scroll-margin-top" "2rem"
        }

    Assert.Equal("--my-var: 10px; scroll-margin-top: 2rem; ", actual)

[<Fact>]
let ``Internal andand combinator merges in order`` () =
    let c1 = Internal.CombineKeyValue(fun sb -> sb.Append("a: 1; "))
    let c2 = Internal.CombineKeyValue(fun sb -> sb.Append("b: 2; "))
    let merged = Internal.(&&&) c1 c2
    Assert.Equal("a: 1; b: 2; ", render merged)

[<Fact>]
let ``Internal and-greater appends key value pair`` () =
    let c1 = Internal.CombineKeyValue(fun sb -> sb)
    let merged = Internal.(&>>) c1 ("color", "red")
    Assert.Equal("color: red; ", render merged)

[<Fact>]
let ``Makers mkPxWithKV appends px suffix for int`` () =
    let m = Internal.Makers.mkPxWithKV ("width", 10)
    Assert.Equal("width: 10px; ", render m)

[<Fact>]
let ``Makers mkPxWithKV appends px suffix for float`` () =
    let m = Internal.Makers.mkPxWithKV ("width", 10.5)
    Assert.Equal("width: 10.5px; ", render m)

[<Fact>]
let ``Makers mkWithKV without px for int`` () =
    let m = Internal.Makers.mkWithKV ("z-index", 3)
    Assert.Equal("z-index: 3; ", render m)

[<Fact>]
let ``Makers mkWithKV without px for float`` () =
    let m = Internal.Makers.mkWithKV ("opacity", 0.25)
    Assert.Equal("opacity: 0.25; ", render m)

type private ImportantStrBuilder(?important: bool) =
    inherit Fun.Css.CssBuilder(?important = important)

    member inline this.Run([<InlineIfLambda>] combine: Internal.CombineKeyValue) =
        let combine = this.ApplyImportant(combine)
        let sb = stringBuilderPool.Get()
        let str = combine.Invoke(sb).ToString()
        stringBuilderPool.Return sb
        str

[<Fact>]
let ``important false by default leaves output unchanged`` () =
    let s = ImportantStrBuilder()

    let actual =
        s {
            color "red"
            width 100
        }

    Assert.Equal("color: red; width: 100px; ", actual)

[<Fact>]
let ``important true appends important to every property`` () =
    let s = ImportantStrBuilder(true)

    let actual =
        s {
            color "red"
            width 100
            displayFlex
            margin 10 20
            opacity 0.5
            zIndex 5
        }

    Assert.Equal(
        "color: red !important; width: 100px !important; display: flex !important; margin: 10px 20px !important; opacity: 0.5 !important; z-index: 5 !important; ",
        actual
    )

[<Fact>]
let ``important true applies to custom and yielded tuples`` () =
    let s = ImportantStrBuilder(true)

    let actual =
        s {
            custom "--my-var" "10px"
            yield ("flag", true)
        }

    Assert.Equal("--my-var: 10px !important; flag: True !important; ", actual)

[<Fact>]
let ``base CssBuilder default Run applies important to fragment`` () =
    let builder = Fun.Css.CssBuilder(important = true)

    let frag =
        builder {
            color "blue"
            fontSize 16
        }

    Assert.Equal("color: blue !important; font-size: 16px !important; ", render frag)
