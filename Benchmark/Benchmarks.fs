namespace Benchmark.StyleBuilding

open System.Text
open BenchmarkDotNet.Attributes


type StyleStr() =
    inherit Fun.Css.CssBuilder()

    member inline _.Run([<InlineIfLambda>] combine: Fun.Css.Internal.CombineKeyValue) =
        let sb = StringBuilder()
        combine.Invoke(sb).ToString()


[<MemoryDiagnoser>]
type Benchmarks() =

    [<Benchmark>]
    member _.BuildStyleWithFunCss() =
        StyleStr() {
            backgroundColor "#44c767"
            borderRadius 30
            borderWidth 1
            borderStyleSolid
            borderColor "#18ab29"
            displayInlineBlock
            cursorPointer
            fontSize 17
        }
