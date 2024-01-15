#r "./Fun.Css/bin/Debug/netstandard2.0/Fun.Css.dll"

open System.Text
open Fun.Css

type StyleStrBuilder() =
    inherit Fun.Css.CssBuilder()

    member inline _.Run([<InlineIfLambda>] combine: Fun.Css.Internal.CombineKeyValue) =
        let sb = StringBuilder()
        let str = combine.Invoke(sb).ToString()
        str

// With a helper function
let styleStr = StyleStrBuilder()

styleStr {
    background "#44c767"
    backgroundColorTransparent
    borderRadius 30
    borderWidth 1
    borderStyleSolid
    borderColorColor "#18ab29"
    displayInlineBlock
    cursorPointer
    fontSize 17
    displayFlex
    marginLeftPercentage 1.1
    alignItemsStart
    alignContentCenter
    overflowAuto
    textAlignLastLeft
    justifyContentFlexStart
    whiteSpaceNowrap
    textDecorationLineUnderline
    fontWeightBold
    // overflowHidden
    overflowWrapBreakWord
    flex 1
    // margin 10
    margin 10 5
    margin 10 5 1
    margin 10 5 1 3
}
|> printfn "%s"
