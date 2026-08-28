---
name: fun-css
description: >-
  Author type-safe inline CSS in F# with the Fun.Css computation-expression
  builder. Use when writing, generating, or refactoring Fun.Css style blocks
  (style { ... }), choosing operation names from CSS property knowledge,
  composing or conditionally building styles, or wiring design tokens / CSS
  variables into Fun.Css or Fun.Blazor code.
---

# Fun.Css

Fun.Css builds inline CSS strings with an F# computation expression. Every CSS property maps to one group of custom operations inside `style { ... }`. If you know CSS, you can guess the API — follow the rules below instead of searching the source.

## Core rules

1. **Property names are camelCase CSS names.** `background-color` → `backgroundColor`, `text-decoration-line` → `textDecorationLine`.
2. **Keyword variants append the keyword in PascalCase.** `align-items: center` → `alignItemsCenter`; `flex-direction: row-reverse` → `flexDirectionRowReverse`. Multi-word keywords concatenate: `line-through` → `LineThrough`.
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

## Workflow

### 1. Author a style block

Prefer typed keyword ops for compile-time checking; use the `(value: string)` overload for variables, compound values, or anything not covered by a typed op:

```fsharp
style {
    displayFlex                          // typed keyword op
    alignItems "center"                  // string overload, same property group
    transitionTimingFunction "steps(4, end)"
    width 100
    margin 10 20
}
```

### 2. Wire in design tokens / CSS variables

Every property accepts a string, so a token system plugs in directly:

```fsharp
module Tokens =
    module Layout =
        let Display = "var(--display)"
        let Direction = "var(--flex-direction)"
    module Color =
        let TextMain = "var(--color-text-main)"

style {
    display Tokens.Layout.Display        // no custom escape hatch needed
    flexDirection Tokens.Layout.Direction
    color Tokens.Color.TextMain
    alignItemsCenter                     // typed ops still work side by side
}
```

**Reusable styles.** Two more ways to share style logic, both built on a fragment builder (`css` = a `CssBuilder` with the default `Run`, which returns a `CombineKeyValue` fragment):

1. **Shared fragment values** — put common combinations in a module and embed them:

```fsharp
let css = Fun.Css.CssBuilder()           // default Run returns a fragment

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

2. **Custom operation extensions** — extend your builder with named operations:

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

        [<CustomOperation "EvenHStack">]
        member inline this.EvenHStack([<InlineIfLambda>] comb: CombineKeyValue) =
            comb &&& css {
                displayFlex
                custom "justify-content" "space-evenly"
            }

style {
    VStack
    EvenHStack
}
```

(In Fun.Blazor, extend its `StyleBuilder` the same way.)

### 3. Compose and branch

**Compose fragments.** With the default `Run` (which returns the `CombineKeyValue` fragment itself), one `style { ... }` block embeds another directly, or you can merge fragments with `&&&` from `Fun.Css.Internal`:

```fsharp
let frag = Fun.Css.CssBuilder()          // default Run returns CombineKeyValue

let baseFrag = frag {
    margin 0
    padding 10
}

let combined = frag {
    baseFrag                             // embeds cleanly
    color "red"
}
// or: let combined = baseFrag &&& frag { color "red" }
```

Do **not** embed a builder whose `Run` returns a string (e.g. `StyleStrBuilder`) — the compiler auto-yields the string and appends a stray `"; "`. Concatenate the built strings instead: `baseStyles + overrides`.

**Branch / loop.** A block containing `if`, `for`, or `match` cannot contain *any* custom operation (FS3086) — the whole block must use `yield` with `(key, value)` tuples, including for fallback properties:

```fsharp
style {
    if isActive then
        yield ("font-weight", "bold")
    for size in sizes do
        yield ("margin-bottom", string size + "px")
    yield ("container-type", "inline-size")  // fallback, not `custom`
}
```

To combine conditional output with regular custom ops, build them as separate blocks and concatenate the results (or combine fragments with `&&&` before running).

### 4. Emit output

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

## Gotchas

- **Tuples don't compile.** CE custom operations are curried: `margin 10 20`, not `margin (10, 20)` (FS3099/FS0041).
- **Custom ops fail anywhere in a block containing `if`/`for`/`match`** (FS3086) — not just inside the branches. A branchy block must be pure `yield ("css-key", value)` tuples; keep custom ops in a separate block and combine the outputs.
- **Embedding a string-returning builder adds a stray `"; "`.** Only `CombineKeyValue` fragments (default `Run`) embed cleanly in another `style { }` block; concatenate built strings with `+` instead.
- **`float` is a keyword in F#.** The float property group is `floatStyleLeft`, `floatStyleRight`, `floatStyleNone`, `floatStyle (value: string)`. (`floatLeft` etc. still work but warn.)
- **End names take an apostrophe where `end` collides:** `gridColumnEnd`, `gridRowEnd` are fine; only local value bindings need `end'`.

## Deprecation policy

Public API members are **never removed**. Typo'd names stay available with `[<Obsolete>]` pointing to the correctly spelled operation; they keep compiling and emitting identical CSS:

```fsharp
justifyItemsStrench   // works, but warns: use justifyItemsStretch
wordbreakNormal       // works, but warns: use wordBreakNormal
```

When writing new code, always choose the non-obsolete name.

## Reference

- `README.md` — background, Fun.Blazor integration, benchmarks.
- `Fun.Css/CssBuilder.fs` — full operation list (the only source of truth).
- `Fun.Css/TODO.md` — known gaps and improvement backlog.
