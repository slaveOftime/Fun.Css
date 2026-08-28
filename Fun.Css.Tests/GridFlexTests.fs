module Fun.Css.Tests.GridFlexTests

open Microsoft.Extensions.ObjectPool
open Xunit

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

[<Fact>]
let ``gridTemplateColumns overloads`` () =
    let actual =
        style {
            gridTemplateColumns [ 100; 200; 100 ]
            gridTemplateColumns "1fr 1fr 2fr"
            gridTemplateColumns 3 "1fr"
            gridTemplateColumns 3 "1fr" "col-start"
        }

    Assert.Equal(
        "grid-template-columns: 100px 200px 100px; grid-template-columns: 1fr 1fr 2fr; grid-template-columns: repeat(3, 1fr); grid-template-columns: repeat(3, 1fr, [col-start]); ",
        actual
    )

[<Fact>]
let ``gridTemplateRows overloads`` () =
    let actual =
        style {
            gridTemplateRows [ 100; 200 ]
            gridTemplateRows "1fr 10% 250px auto"
            gridTemplateRows 3 "10%"
            gridTemplateRows 3 "10%" "row-start"
        }

    Assert.Equal(
        "grid-template-rows: 100px 200px; grid-template-rows: 1fr 10% 250px auto; grid-template-rows: repeat(3, 10%); grid-template-rows: repeat(3, 10% [row-start]); ",
        actual
    )

[<Fact>]
let ``gridTemplateAreas`` () =
    let actual =
        style { gridTemplateAreas [ "header header header"; "nav main sidebar"; "footer footer footer" ] }

    Assert.Equal("grid-template-areas: 'header header header' 'nav main sidebar' 'footer footer footer'; ", actual)

[<Fact>]
let ``gap overloads`` () =
    let actual =
        style {
            gap 10
            gap "1em"
            gap "1em" "2em"
            rowGap 5
            rowGap "1rem"
            columnGap 6
            columnGap "2rem"
        }

    Assert.Equal(
        "gap: 10px; gap: 1em; gap: 1em 2em; row-gap: 5px; row-gap: 1rem; column-gap: 6px; column-gap: 2rem; ",
        actual
    )

[<Fact>]
let ``gridColumnStart and gridColumnEnd overloads`` () =
    let actual =
        style {
            gridColumnStart 1
            gridColumnStart "col"
            gridColumnStart "col" 2
            gridColumnEnd 3
            gridColumnEnd "col-end"
            gridColumnEnd "col-end" 2
        }

    Assert.Equal(
        "grid-column-start: 1; grid-column-start: col; grid-column-start: col, 2; grid-column-end: 3; grid-column-end: col-end; grid-column-end: col-end, 2; ",
        actual
    )

[<Fact>]
let ``gridRowStart and gridRowEnd overloads`` () =
    let actual =
        style {
            gridRowStart 1
            gridRowStart "row"
            gridRowStart "row" 2
            gridRowEnd 3
            gridRowEnd "row-end"
            gridRowEnd "row-end" 2
        }

    Assert.Equal(
        "grid-row-start: 1; grid-row-start: row; grid-row-start: row, 2; grid-row-end: 3; grid-row-end: row-end; grid-row-end: row-end, 2; ",
        actual
    )

[<Fact>]
let ``gridColumn and gridRow shorthand`` () =
    let actual =
        style {
            gridColumn "1" "3"
            gridColumn 1 3
            gridRow "1" "2"
        }

    Assert.Equal("grid-column: 1 / 3; grid-column: 1 / 3; grid-row: 1 / 2; ", actual)

[<Fact>]
let ``gridArea and gridTemplate`` () =
    let actual =
        style {
            gridArea "header"
            gridTemplate "'a a a' 'b b b' / 1fr 1fr 1fr"
        }

    Assert.Equal("grid-area: header; grid-template: 'a a a' 'b b b' / 1fr 1fr 1fr; ", actual)

[<Fact>]
let ``flex direction and wrap keywords`` () =
    let actual =
        style {
            flexDirectionRow
            flexDirectionRowReverse
            flexDirectionColumn
            flexDirectionColumnReverse
            flexWrapNowrap
            flexWrapWrap
            flexWrapWrapReverse
            flexWrapInitial
            flexWrapInheritFromParent
        }

    Assert.Equal(
        "flex-direction: row; flex-direction: row-reverse; flex-direction: column; flex-direction: column-reverse; flex-wrap: nowrap; flex-wrap: wrap; flex-wrap: wrap-reverse; flex-wrap: initial; flex-wrap: inherit; ",
        actual
    )

[<Fact>]
let ``flexShrink and flexBasis`` () =
    let actual =
        style {
            flexShrink 2
            flexBasis 100
            flexBasis "auto"
            flexBasisAuto
            flexBasisInitial
            flexBasisInheritFromParent
        }

    Assert.Equal(
        "flex-shrink: 2; flex-basis: 100px; flex-basis: auto; flex-basis: auto; flex-basis: initial; flex-basis: inherit; ",
        actual
    )

[<Fact>]
let ``flex and align string overloads`` () =
    let actual =
        style {
            flexDirection "var(--flex-direction)"
            flexWrap "var(--flex-wrap)"
            alignContent "var(--align-content)"
            alignItems "var(--align-items)"
            alignSelf "var(--align-self)"
            transformStyle "var(--transform-style)"
        }

    Assert.Equal(
        "flex-direction: var(--flex-direction); flex-wrap: var(--flex-wrap); align-content: var(--align-content); align-items: var(--align-items); align-self: var(--align-self); transform-style: var(--transform-style); ",
        actual
    )
