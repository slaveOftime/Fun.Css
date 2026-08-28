module Fun.Css.Tests.TransformTests

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
let ``transform string and keywords`` () =
    let actual =
        style {
            transform "translateX(10px) rotate(45deg)"
            transformNone
            transformInitial
            transformInheritFromParent
        }

    Assert.Equal(
        "transform: translateX(10px) rotate(45deg); transform: none; transform: initial; transform: inherit; ",
        actual
    )

[<Fact>]
let ``transformOrigin overloads`` () =
    let actual =
        style {
            transformOrigin "center"
            transformOrigin "left" "top"
        }

    Assert.Equal("transform-origin: center; transform-origin: left top; ", actual)

[<Fact>]
let ``transformMatrix has correct value order`` () =
    // matrix(x1, y2, z1, x2, y2, z2) -- note: y1 is skipped (bug? see TODO.md)
    let actual = style { transformMatrix 1 2 3 4 5 6 }
    Assert.Equal("transform: matrix(1,5,3,4,5,6); ", actual)

[<Fact>]
let ``transformTranslate overloads`` () =
    let actual =
        style {
            transformTranslate 10 20
            transformTranslate "10%" "20%"
        }

    Assert.Equal("transform: translate(10px, 20px); transform: translate(10%, 20%); ", actual)

[<Fact>]
let ``transformTranslate3D overloads`` () =
    let actual =
        style {
            transformTranslate3D 1 2 3
            transformTranslate3D "1em" "2em" "3em"
        }

    Assert.Equal("transform: translate3d(1px, 2px, 3px); transform: translate3d(1em, 2em, 3em); ", actual)

[<Fact>]
let ``transformTranslateX/Y/Z overloads`` () =
    let actual =
        style {
            transformTranslateX 10
            transformTranslateX "10%"
            transformTranslateY 20
            transformTranslateY "20%"
            transformTranslateZ 30
            transformTranslateZ "30%"
        }

    Assert.Equal(
        "transform: translateX(10px); transform: translateX(10%); transform: translateY(20px); transform: translateY(20%); transform: translateZ(30px); transform: translateZ(30%); ",
        actual
    )

[<Fact>]
let ``transformScale overloads`` () =
    let actual =
        style {
            transformScale 2 3
            transformScale 1.5
            transformScale3D 1 2 3
            transformScaleX 2
            transformScaleY 3
            transformScaleZ 4
        }

    Assert.Equal(
        "transform: scale(2, 3); transform: scale(1.5); transform: scale3d(1, 2, 3); transform: scaleX(2); transform: scaleY(3); transform: scaleZ(4); ",
        actual
    )

[<Fact>]
let ``transformRotate overloads`` () =
    let actual =
        style {
            transformRotate 45
            transformRotate 45.5
            transformRotateX 10.0
            transformRotateY 20.0
            transformRotateZ 30.0
        }

    Assert.Equal(
        "transform: rotate(45deg); transform: rotate(45.5deg); transform: rotateX(10deg); transform: rotateY(20deg); transform: rotateZ(30deg); ",
        actual
    )

[<Fact>]
let ``transformSkew overloads`` () =
    let actual =
        style {
            transformSkew 10.0 20.0
            transformSkewX 15.0
            transformSkewY 25.0
        }

    Assert.Equal("transform: skew(10deg, 20deg); transform: skewX(15deg); transform: skewY(25deg); ", actual)

[<Fact>]
let ``transformPerspective`` () =
    let actual = style { transformPerspective 100 }
    Assert.Equal("transform: perspective(100); ", actual)

[<Fact>]
let ``boxShadow overloads`` () =
    let actual =
        style {
            boxShadow "2px 4px 8px rgba(0,0,0,0.2)"
            boxShadow 1 2 "red"
            boxShadow 1 2 3 "blue"
            boxShadow 1 2 3 4 "green"
            boxShadowNone
            boxShadowInheritFromParent
        }

    Assert.Equal(
        "box-shadow: 2px 4px 8px rgba(0,0,0,0.2); box-shadow1px 2px red; box-shadow: 1px 2px 3px blue; box-shadow: 1px 2px 3px 4px green; box-shadow: none; box-shadow: inherit; ",
        actual
    )
