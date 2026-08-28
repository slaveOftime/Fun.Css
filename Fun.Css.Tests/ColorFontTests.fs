module Fun.Css.Tests.ColorFontTests

open Xunit
open Fun.Css

[<Fact>]
let ``color.hsl produces hsl string`` () =
    Assert.Equal("hsl(120,50%,50%)", color.hsl (120.0, 50.0, 50.0))

[<Fact>]
let ``color.rgb produces rgb string`` () =
    Assert.Equal("rgb(255,0,0)", color.rgb (255, 0, 0))

[<Fact>]
let ``color.rgba produces rgba string`` () =
    Assert.Equal("rgba(255,0,0,0.5)", color.rgba (255, 0, 0, 0.5))

[<Fact>]
let ``color named literals are hex values`` () =
    Assert.Equal("#CD5C5C", color.indianRed)
    Assert.Equal("#FF0000", color.red)
    Assert.Equal("#FFC0CB", color.pink)
    Assert.Equal("#FFFFFF", color.white)
    Assert.Equal("#000000", color.black)
    Assert.Equal("transparent", color.transparent)

[<Fact>]
let ``color literals work inside the builder`` () =
    let styled: Internal.CombineKeyValue =
        (CssBuilder()).Yield(("color", color.aliceBlue))

    let str = styled.Invoke(System.Text.StringBuilder()).ToString()
    Assert.Equal("color: #F0F8FF; ", str)

[<Fact>]
let ``font literals are names`` () =
    Assert.Equal("Arial", font.arial)
    Assert.Equal("Arial Black", font.arialBlack)
    Assert.Equal("Andale Mono", font.andaleMono)
