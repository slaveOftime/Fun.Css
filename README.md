# Fun.Css [![NuGet](https://img.shields.io/nuget/vpre/Fun.Css)](https://www.nuget.org/packages/Fun.Css)

Fun.Css is an F# library for building type-safe inline CSS with computation expressions.

```fsharp
style {
    backgroundColor "#44c767"
    borderRadius 30
    borderWidth 1
    borderStyleSolid
    borderColor "#18ab29"
    displayInlineBlock
    cursorPointer
    fontSize 17
}
```

## Background

Fun.Css was originally created for [Fun.Blazor](https://github.com/slaveOftime/Fun.Blazor) to provide a type-safe and efficient way to build inline styles.

The project was inspired by Feliz.Engine. While migrating Fun.Blazor to use `InlineIfLambda` for better performance, I found that the same approach could improve CSS generation. Fun.Css therefore uses computation expressions and `InlineIfLambda` to efficiently combine CSS properties.

A custom operation is defined like this:

```fsharp
[<CustomOperation("color")>]
member inline _.color([<InlineIfLambda>] comb: CombineKeyValue, color: string) =
    comb &>> ("color", color)
```

`CombineKeyValue` is a delegate that appends CSS fragments to a `StringBuilder`:

```fsharp
type CombineKeyValue = delegate of StringBuilder -> StringBuilder
```

In release builds, the operations are combined into local functions that append each CSS fragment to a shared `StringBuilder`.

## Usage

The final output type depends on your application. The following examples show how to create builders for Fun.Blazor attributes and plain strings.

### Fun.Blazor

Inherit from `Fun.Css.CssBuilder` and add a `Run` member that returns an `AttrRenderFragment`:

```fsharp
type StyleBuilder() =
    inherit Fun.Css.CssBuilder()

    member inline _.Run([<InlineIfLambda>] combine: Fun.Css.Internal.CombineKeyValue) =
        AttrRenderFragment(fun _ builder index ->
            let sb = stringBuilderPool.Get()
            builder.AddAttribute(index, "style", combine.Invoke(sb).ToString())
            stringBuilderPool.Return sb
            index + 1
        )

let style = StyleBuilder()
```

You can then use the builder directly in Fun.Blazor:

```fsharp
div {
    style {
        color "red"
        height 100
        width 100
    }
}
```

### Plain CSS Strings

To generate a CSS string, create a builder whose `Run` member returns the combined result:

```fsharp
type StyleStrBuilder() =
    inherit Fun.Css.CssBuilder()

    member inline _.Run([<InlineIfLambda>] combine: Fun.Css.Internal.CombineKeyValue) =
        let sb = stringBuilderPool.Get()
        let result = combine.Invoke(sb).ToString()
        stringBuilderPool.Return sb
        result

let styleStr = StyleStrBuilder()
```

## Fable and React

Fun.Css does not directly support React inline-style objects. React expects JavaScript objects with camel-cased property names rather than standard CSS strings.

You can still use Fun.Css with Fable when you need to generate a standard inline CSS string.

## Benchmarks

The following results are provided as a general reference. The comparison with Fss is not equivalent because Fss provides additional type-safety features and automatically generates class names.

See `Benchmark/Benchmarks.fs` for the benchmark source.

BenchmarkDotNet v0.15.8, Linux Debian GNU/Linux 13 (trixie)
Intel Core Ultra 7 265H 3.69GHz, 1 CPU, 16 logical and 16 physical cores
.NET SDK 10.0.400
  [Host]     : .NET 10.0.11 (10.0.11, 10.0.1126.37416), X64 RyuJIT x86-64-v3 DEBUG
  DefaultJob : .NET 10.0.11 (10.0.11, 10.0.1126.37416), X64 RyuJIT x86-64-v3

| Method                     | Mean      | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|--------------------------- |----------:|----------:|----------:|-------:|-------:|----------:|
| BuildStyleWithFunCss       |  79.51 ns |  1.270 ns |  1.061 ns | 0.0318 |      - |     400 B |
| BuildStyleWithFunCssCustom |  72.14 ns |  1.593 ns |  4.673 ns | 0.0318 |      - |     400 B |
| BuildStyleWithFeliz        | 344.64 ns |  6.859 ns | 16.565 ns | 0.1535 | 0.0005 |    1928 B |
| BuildStyleWithFss          | 996.88 ns | 19.811 ns | 51.138 ns | 0.4072 | 0.0010 |    5120 B |
