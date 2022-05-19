open BenchmarkDotNet.Running
open Benchmark.StyleBuilding

Benchmarks().BuildStyleWithFunCss() |> printfn "%A"
Benchmarks().BuildStyleWithFunCssCustom() |> printfn "%A"
Benchmarks().BuildStyleWithFeliz() |> printfn "%A"
Benchmarks().BuildStyleWithFss() |> printfn "%A"

BenchmarkRunner.Run(System.Reflection.Assembly.GetExecutingAssembly()) |> ignore
