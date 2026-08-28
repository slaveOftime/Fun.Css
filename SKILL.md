---
name: fun-css
description: >-
  Author type-safe inline CSS in F# with the Fun.Css computation-expression
  builder. Use when writing, generating, or refactoring Fun.Css style blocks
  (style { ... }), choosing operation names from CSS property knowledge,
  composing or conditionally building styles, extending the builder, or wiring
  design tokens / CSS variables into Fun.Css or Fun.Blazor code.
---

# Fun.Css

Fun.Css builds inline CSS strings with an F# computation expression. Every CSS property maps to one group of custom operations inside `style { ... }`. If you know CSS, you can guess the API — follow the rules below instead of searching the source.

## Naming rules

1. **Property names are camelCase CSS names.** `background-color` → `backgroundColor`, `text-decoration-line` → `textDecorationLine`.
2. **Keyword variants append the keyword in PascalCase.** `align-items: center` → `alignItemsCenter`; multi-word keywords concatenate: `line-through` → `textDecorationLineThrough`, `row-reverse` → `flexDirectionRowReverse`.
3. **Every keyword-only property also has a `(value: string)` overload.** Never use the `custom` escape hatch for a known property — pass the keyword, a compound value, or a CSS variable.
4. **`...Initial` and `...InheritFromParent`** exist on every keyword group (`displayInitial`, `displayInheritFromParent`).
5. **`int`/`float` overloads add `px`** for dimensional properties (`width 100` → `width: 100px;`) and plain numbers for unitless ones (`opacity 0.5`, `zIndex 10`, `flexGrow 1`). Multi-value overloads take multiple arguments: `margin 10 20` → `margin: 10px 20px;`.
6. **Arguments are space-separated** (curried custom operations), never tuples: `boxShadow 2 4 8 "red"`, not `boxShadow(2, 4, 8, "red")`.

| Pattern | Example | Emits |
|---|---|---|
| `propertyName (value: string)` | `display "flex"` | `display: flex; ` |
| `propertyName (value: int)` | `width 100` | `width: 100px; ` |
| `propertyName (value: float)` | `opacity 0.5` | `opacity: 0.5; ` |
| `propertyNameKeyword` (typed unit op) | `displayFlex` | `display: flex; ` |
| `propertyNameInitial` | `displayInitial` | `display: initial; ` |
| `propertyNameInheritFromParent` | `displayInheritFromParent` | `display: inherit; ` |

Fallback for anything not covered: `custom "css-key" "value"`.

## Usage

### Author a style block

Prefer typed keyword ops for compile-time checking; use the `(value: string)` overload for variables, compound values, or anything without a typed op:

```fsharp
style {
    displayFlex                          // typed keyword op
    alignItems "center"                  // string overload, same property group
    transitionTimingFunction "steps(4, end)"
    width 100
    margin 10 20
}
```

### Design tokens / CSS variables

Every property accepts a string, so a token system plugs in directly:

```fsharp
module Tokens =
    let Display = "var(--display)"
    let TextMain = "var(--color-text-main)"

style {
    display Tokens.Display               // no custom escape hatch needed
    color Tokens.TextMain
    alignItemsCenter                     // typed ops still work side by side
}
```

### Reusable styles

1. **Shared fragment values** — `Fun.Css.CssBuilder()` with the default `Run` returns a `CombineKeyValue` fragment that embeds cleanly in other blocks:

```fsharp
let css = Fun.Css.CssBuilder()

module SharedStyles =
    let ClickableGreen = css {
        cursorPointer
        color "green"
    }

style {
    SharedStyles.ClickableGreen
    fontSize 16
}
```

2. **Custom operation extensions** — extend the builder with named operations:

```fsharp
[<AutoOpen>]
module StyleExtensions =
    open Fun.Css.Internal

    type Fun.Css.CssBuilder with

        [<CustomOperation "VStack">]
        member inline _.VStack([<InlineIfLambda>] comb: CombineKeyValue) =
            comb &&& css {
                displayFlex
                flexDirectionColumn
            }

style {
    VStack
}
```

(In Fun.Blazor, extend its `StyleBuilder` the same way.)

### Compose and branch

**Compose fragments.** With the default `Run`, one `style { ... }` block embeds another directly, or merge fragments with `&&&` from `Fun.Css.Internal`:

```fsharp
let baseFrag = css {
    margin 0
    padding 10
}

let combined = css {
    baseFrag                             // embeds cleanly
    color "red"
}
// or: let combined = baseFrag &&& css { color "red" }
```

**Branch / loop.** A block containing `if`, `for`, or `match` cannot contain *any* custom operation (FS3086) — the whole block must use `yield` with `(key, value)` tuples:

```fsharp
style {
    if isActive then
        yield ("font-weight", "bold")
    for size in sizes do
        yield ("margin-bottom", string size + "px")
}
```

To mix conditional output with custom ops, build them as separate blocks and combine the fragments with `&&&` (or concatenate built strings with `+`).

### Emit output

Subclass `CssBuilder` and override `Run`. Use a pooled `StringBuilder` for hot paths:

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

For Fun.Blazor, override `Run` to return an `AttrRenderFragment` (see README.md).

**`!important`.** Pass `important = true` to the constructor to suffix every property with `!important`:

```fsharp
type StyleStrBuilder() =
    inherit Fun.Css.CssBuilder(important = true)

    member inline this.Run([<InlineIfLambda>] combine: Fun.Css.Internal.CombineKeyValue) =
        let combine = this.ApplyImportant(combine)   // route the final combine through this
        // ... render combine to a string as above
```

When overriding `Run`, route the final combine through `this.ApplyImportant(...)` so the flag is honored. `width 100` then emits `width: 100px !important;`. The default is `false` (no `!important`).

## Gotchas

- **Tuples don't compile.** CE custom operations are curried: `margin 10 20`, not `margin (10, 20)` (FS3099/FS0041).
- **Custom ops fail anywhere in a block containing `if`/`for`/`match`** (FS3086) — not just inside the branches. Keep custom ops in a separate block and combine the outputs.
- **Embedding a string-returning builder adds a stray `"; "`.** Only `CombineKeyValue` fragments (default `Run`) embed cleanly in another `style { }` block; concatenate built strings with `+` instead.
- **`float` is a keyword in F#.** The float property group is `floatStyleLeft`, `floatStyleRight`, `floatStyleNone`, `floatStyle (value: string)`. (`floatLeft` etc. still work but warn.)
