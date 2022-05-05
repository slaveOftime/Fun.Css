namespace Benchmark.StyleBuilding

open System.Text
open BenchmarkDotNet.Attributes
open Fss


type RulesetBuilder(ruleName: string) =
    inherit Fun.Css.CssBuilder()

    member _.Run(combine: Fun.Css.Internal.CombineKeyValue) =
        let sb = StringBuilder()
        sb.Append(ruleName).AppendLine(" {") |> ignore
        sb.Append("    ") |> ignore
        combine.Invoke(sb) |> ignore
        sb.AppendLine().AppendLine("}") |> ignore
        sb.ToString()


[<MemoryDiagnoser>]
type Benchmarks() =

    [<Benchmark>]
    member _.BuildStyleWithFunCss() =
    
        RulesetBuilder ".my-style" {
            backgroundColor "#44c767"
            borderRadius 30
            borderWidth 1
            borderStyleSolid
            borderColor "#18ab29"
            displayInlineBlock
            cursorPointer
            fontSize 17
        }


    [<Benchmark>]
    member _.BuildStyleWithFss() =
        createFss [
            BackgroundColor.hex "44c767"
            BorderRadius.value (px 30)
            BorderWidth.value (px 1)
            BorderStyle.solid
            BorderColor.hex "18ab29"
            Display.inlineBlock
            Cursor.pointer
            FontSize.value (px 17)
        ]


// From Fun.Css
// ".my-style {
//     background-color: #44c767; border-radius: 30px; border-width: 1px; border-style: solid; border-color: #18ab29; display: inline-block; cursor: pointer; font-size: 17px;
// }
// "

// From Fss
// ("css-2130983758",
//  [(".css-2130983758",
//    "{ background-color: #44c767;border-radius: 30px;border-width: 1px;border-style: solid;border-color: #18ab29;display: inline-block;cursor: pointer;font-size: 17px; }")])        
