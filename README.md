
# Fun.Css [![Nuget](https://img.shields.io/nuget/vpre/Fun.Css)](https://www.nuget.org/packages/Fun.Css)


First, let`s check how it can look like:
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

Benchmarks (I know it is not fair comparison for Fss because Fss is more type safety and will automatically generate classname for you. But I did not find similar libraries to compare, just take as a reference), You can check the code in Benchmark/Benchmarks.fs:

|                     Method |       Mean |    Error |   StdDev |  Gen 0 | Allocated |
|--------------------------- |-----------:|---------:|---------:|-------:|----------:|
|       BuildStyleWithFunCss |   181.2 ns |  2.33 ns |  2.18 ns | 0.0343 |     432 B |
| BuildStyleWithFunCssCustom |   170.9 ns |  2.31 ns |  2.05 ns | 0.0343 |     432 B |
|        BuildStyleWithFeliz |   519.2 ns |  8.90 ns |  7.89 ns | 0.1593 |   2,000 B |
|          BuildStyleWithFss | 6,042.3 ns | 65.63 ns | 61.39 ns | 0.8545 |  10,736 B |

This project is built in Fun.Blazor at first to help build inline style with type safety way.

Before I was using Feliz.Engine, when I was migrating Fun.Blazor to use InlineIfLambda for better performance, I found I can also make style building faster with the same way. So copied the Feliz.Engine basic methods for css and rebuild with computation plus InlineIfLambda.

The basic stuff is like this:

```fsharp
[<CustomOperation("color")>]
member inline _.color([<InlineIfLambda>] comb: CombineKeyValue, color: string) =
    comb &>> ("color", color)
```

**CombineKeyValue** is defined as:

```fsharp
type CombineKeyValue = delegate of StringBuilder -> StringBuilder
```

So after you build with release mode, everything should combined in a local functions with a StringBuilder provide to append all the string pieces together.


## How to use it in your project

It depends, take [Fun.Blazor](https://github.com/slaveOftime/Fun.Blazor) as an example, I will just inherit **Fun.Css.CssBuilder** and add a new **Run** member to generate the final result. In my case it is a **AttrRenderFragment**

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

// With a helper function
let style = StyleBuilder()
```

Then I can use it in Fun.Blazor like this:

```fsharp
div {
    style { 
        color "red"
        height 100
        width 100
    }
}
```

Another example is just to generate a string for the style, then you can similar do things like:

```fsharp
type StyleStrBuilder() =
    inherit Fun.Css.CssBuilder()

    member inline _.Run([<InlineIfLambda>] combine: Fun.Css.Internal.CombineKeyValue) =
        let sb = stringBuilderPool.Get()
        let str = combine.Invoke(sb).ToString()
        stringBuilderPool.Return sb
        str

// With a helper function
let styleStr = StyleStrBuilder()
```


    For Fable + React, it does not support, because as what I know React is using an js object for the inline style. So the key value is not the pure css standard instead it use camelCase. 
    But you can use it in Fable to build pure css inline style string if you want.


## TODO

[x] Add css selector, pseudo etc. (help wanted 😊)

But we may not need to build that, because it looks pretty complex and very flexible. Maybe we can just do this:

```fsharp
styleElement {
    ruleset ".selected span:hover" {
        color "red"
    }
}
```
And it it generate things like

```html
<style>
    .selected span:hover {
        color: red;
    }
</style>
```

Even there is no type safety for the selector and pseudo class or element, but it is very straightforward to do.