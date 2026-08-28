#nowarn "44" // obsolete-op usage is intentional: verifies legacy names keep working (backward compatibility)

module Fun.Css.Tests.TypographyTests

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
let ``fontSize and lineHeight overloads`` () =
    let actual =
        style {
            fontSize 16
            fontSize "1.5rem"
            lineHeight 24
            lineHeight "1.5"
        }

    Assert.Equal("font-size: 16px; font-size: 1.5rem; line-height: 24px; line-height: 1.5; ", actual)

[<Fact>]
let ``fontWeight overloads and keywords`` () =
    let actual =
        style {
            fontWeight 700
            fontWeightNormal
            fontWeightBold
            fontWeightBolder
            fontWeightLighter
            fontWeightInitial
            fontWeightInheritFromParent
        }

    Assert.Equal(
        "font-weight: 700; font-weight: normal; font-weight: bold; font-weight: bolder; font-weight: lighter; font-weight: initial; font-weight: inherit; ",
        actual
    )

[<Fact>]
let ``fontStyle keywords`` () =
    let actual =
        style {
            fontStyleNormal
            fontStyleItalic
            fontStyleOblique
            fontStyleInitial
            fontStyleInheritFromParent
        }

    Assert.Equal(
        "font-style: normal; font-style: italic; font-style: oblique; font-style: initial; font-style: inherit; ",
        actual
    )

[<Fact>]
let ``fontVariant keywords`` () =
    let actual =
        style {
            fontVariantNormal
            fontVariantSmallCaps
            fontVariantInitial
            fontVariantInheritFromParent
        }

    Assert.Equal(
        "font-variant: normal; font-variant: small-caps; font-variant: initial; font-variant: inherit; ",
        actual
    )

[<Fact>]
let ``fontFamily and textDecorationColor`` () =
    let actual =
        style {
            fontFamily "Arial, sans-serif"
            textDecorationColor "red"
        }

    Assert.Equal("font-family: Arial, sans-serif; text-decoration-color: red; ", actual)

[<Fact>]
let ``textAlign keywords`` () =
    let actual =
        style {
            textAlignLeft
            textAlignRight
            textAlignCenter
            textAlignJustify
            textAlignInitial
            textAlignInheritFromParent
        }

    Assert.Equal(
        "text-align: left; text-align: right; text-align: center; text-align: justify; text-align: initial; text-align: inherit; ",
        actual
    )

[<Fact>]
let ``textDecoration and textDecorationLine`` () =
    let actual =
        style {
            textDecoration "underline dotted red"
            textDecorationNone
            textDecorationUnderline
            textDecorationOverline
            textDecorationLineThrough
            textDecorationLine "underline overline"
            textDecorationLineNone
            textDecorationLineLineThrough
        }

    Assert.Equal(
        "text-decoration: underline dotted red; text-decoration: none; text-decoration: underline; text-decoration: overline; text-decoration: line-through; text-decoration-line: underline overline; text-decoration-line: none; text-decoration-line: line-through; ",
        actual
    )

[<Fact>]
let ``textDecorationStyle keywords`` () =
    let actual =
        style {
            textDecorationStyleSolid
            textDecorationStyleDouble
            textDecorationStyleDotted
            textDecorationStyleDashed
            textDecorationStyleWavy
            textDecorationStyleInitial
            textDecorationStyleInheritFromParent
        }

    Assert.Equal(
        "text-decoration-style: solid; text-decoration-style: double; text-decoration-style: dotted; text-decoration-style: dashed; text-decoration-style: wavy; text-decoration-style: initial; text-decoration-style: inherit; ",
        actual
    )

[<Fact>]
let ``textTransform keywords`` () =
    let actual =
        style {
            textTransformNone
            textTransformCapitalize
            textTransformUppercase
            textTransformLowercase
        }

    Assert.Equal(
        "text-transform: none; text-transform: capitalize; text-transform: uppercase; text-transform: lowercase; ",
        actual
    )

[<Fact>]
let ``textOverflow keywords`` () =
    let actual =
        style {
            textOverflowClip
            textOverflowEllipsis
            textOverflowInitial
            textOverflowInheritFromParent
        }

    Assert.Equal(
        "text-overflow: clip; text-overflow: ellipsis; text-overflow: initial; text-overflow: inherit; ",
        actual
    )

[<Fact>]
let ``textIndent overloads`` () =
    let actual =
        style {
            textIndent 10
            textIndent "2em"
        }
    // note: int overload does NOT emit px (uses mkWithKV instead of mkPxWithKV) - see TODO.md
    Assert.Equal("text-indent: 10px; text-indent: 2em; ", actual)

[<Fact>]
let ``verticalAlign keywords`` () =
    let actual =
        style {
            verticalAlignBaseline
            verticalAlignSub
            verticalAlignSuper
            verticalAlignTop
            verticalAlignTextTop
            verticalAlignMiddle
            verticalAlignBottom
            verticalAlignTextBottom
            verticalAlignInitial
            verticalAlignInheritFromParent
        }

    Assert.Equal(
        // note: verticalAlignSub emits "sup" (bug - see TODO.md)
        "vertical-align: baseline; vertical-align: sub; vertical-align: super; vertical-align: top; vertical-align: text-top; vertical-align: middle; vertical-align: bottom; vertical-align: text-bottom; vertical-align: initial; vertical-align: inherit; ",
        actual
    )

[<Fact>]
let ``whiteSpace keywords`` () =
    let actual =
        style {
            whiteSpaceNormal
            whiteSpaceNowrap
            whiteSpacePre
            whiteSpacePreLine
            whiteSpacePreWrap
            whiteSpaceInitial
            whiteSpaceInheritFromParent
        }

    Assert.Equal(
        "white-space: normal; white-space: nowrap; white-space: pre; white-space: pre-line; white-space: pre-wrap; white-space: initial; white-space: inherit; ",
        actual
    )

[<Fact>]
let ``wordbreak keywords (obsolete names)`` () =
    let actual =
        style {
            wordbreakNormal
            wordbreakBreakAll
            wordbreakKeepAll
            wordbreakBreakWord
            wordbreakInitial
            wordbreakInheritFromParent
        }

    Assert.Equal(
        "word-break: normal; word-break: break-all; word-break: keep-all; word-break: break-word; word-break: initial; word-break: inherit; ",
        actual
    )

[<Fact>]
let ``wordBreak keywords (new names) and string overload`` () =
    let actual =
        style {
            wordBreakNormal
            wordBreakBreakAll
            wordBreakKeepAll
            wordBreakBreakWord
            wordBreakInitial
            wordBreakInheritFromParent
            wordBreak "var(--word-break)"
        }

    Assert.Equal(
        "word-break: normal; word-break: break-all; word-break: keep-all; word-break: break-word; word-break: initial; word-break: inherit; word-break: var(--word-break); ",
        actual
    )

[<Fact>]
let ``textJustify keywords`` () =
    let actual =
        style {
            textJustifyAuto
            textJustifyInterWord
            textJustifyInterCharacter
            textJustifyNone
            textJustifyInitial
            textJustifyInheritFromParent
        }

    Assert.Equal(
        "text-justify: auto; text-justify: inter-word; text-justify: inter-character; text-justify: none; text-justify: initial; text-justify: inherit; ",
        actual
    )

[<Fact>]
let ``typography string overloads`` () =
    let actual =
        style {
            verticalAlign "var(--vertical-align)"
            whiteSpace "var(--white-space)"
            textAlign "var(--text-align)"
            textTransform "var(--text-transform)"
            textJustify "var(--text-justify)"
            textOverflow "var(--text-overflow)"
            wordWrap "var(--word-wrap)"
            fontStyle "var(--font-style)"
            fontVariant "var(--font-variant)"
            fontKerning "var(--font-kerning)"
            fontStretch "var(--font-stretch)"
            textDecorationStyle "var(--text-decoration-style)"
        }

    Assert.Equal(
        "vertical-align: var(--vertical-align); white-space: var(--white-space); text-align: var(--text-align); text-transform: var(--text-transform); text-justify: var(--text-justify); text-overflow: var(--text-overflow); word-wrap: var(--word-wrap); font-style: var(--font-style); font-variant: var(--font-variant); font-kerning: var(--font-kerning); font-stretch: var(--font-stretch); text-decoration-style: var(--text-decoration-style); ",
        actual
    )
