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

Benchmark for it (may need comparison for it with other libraries):
|               Method |     Mean |   Error |   StdDev |  Gen 0 | Allocated |
|--------------------- |---------:|--------:|---------:|-------:|----------:|
| BuildStyleWithFunCss | 347.2 ns | 8.86 ns | 25.99 ns | 0.2942 |      1 KB |


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

But we may not need to build that, because it looks pretty complex. Maybe we can just do this:

```fsharp
stylesheet ".selected span:hover" {
    color "red"
}
```

Even there is no type safety for the selector and pseudo class or element, but it is very straightforward to do.