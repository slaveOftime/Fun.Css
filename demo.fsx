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
    background.color.transparent
    border.radius.length 30
    border.width.length 1
    border.style.solid
    border.color.color "#18ab29"
    display.inlineBlock
    cursor.pointer
    font.size.length 17
    display.flex
    margin.left.percentage 1.1
    alignItems.start
    alignContent.center
    overflow.auto
    textAlign.last.left
    justifyContent.flexStart
    whiteSpace.nowrap
    textDecoration.line.underline
    font.weight.bold
    overflow.hidden
    overflow.wrap.breakWord
    flex 1
    margin 10
    margin 10 5
    margin 10 5 1
    margin 10 5 1 3
}
|> printfn "%s"
