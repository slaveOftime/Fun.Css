module Fun.Css.Tests.AnimationTransitionTests

open System
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
let ``animation shorthand and name/duration/delay`` () =
    let actual =
        style {
            animation "slidein 3s ease-in 1s infinite"
            animationName "my-keyframes"
            animationDuration 3
            animationDuration (TimeSpan.FromMilliseconds 500.0)
            animationDelay 1
            animationDelay (TimeSpan.FromMilliseconds 250.0)
        }

    Assert.Equal(
        "animation: slidein 3s ease-in 1s infinite; animation-name: my-keyframes; animation-duration: 3s; animation-duration: 500ms; animation-delay: 1s; animation-delay: 250ms; ",
        actual
    )

[<Fact>]
let ``animation timing functions`` () =
    let actual =
        style {
            animationTimingFunctionEase
            animationTimingFunctionLinear
            animationTimingFunctionEaseIn
            animationTimingFunctionEaseOut
            animationTimingFunctionEaseInOut
            animationTimingFunctionCubicBezier 0.1 0.2 0.3 0.4
            animationTimingFunctionInitial
            animationTimingFunctionInheritFromParent
        }

    Assert.Equal(
        "animation-timing-function: ease; animation-timing-function: linear; animation-timing-function: ease-in; animation-timing-function: ease-out; animation-timing-function: ease-in-out; animation-timing-function: cubic-bezier(0.1,0.2,0.3,0.4); animation-timing-function: initial; animation-timing-function: inherit; ",
        actual
    )

[<Fact>]
let ``animation direction`` () =
    let actual =
        style {
            animationDirectionNormal
            animationDirectionReverse
            animationDirectionAlternate
            animationDirectionAlternateReverse
            animationDirectionInitial
            animationDirectionInheritFromParent
        }

    Assert.Equal(
        "animation-direction: normal; animation-direction: reverse; animation-direction: alternate; animation-direction: alternate-reverse; animation-direction: initial; animation-direction: inherit; ",
        actual
    )

[<Fact>]
let ``animation play state`` () =
    let actual =
        style {
            animationPlayStateRunning
            animationPlayStatePaused
            animationPlayStateInitial
            animationPlayStateInheritFromParent
        }

    Assert.Equal(
        "animation-play-state: running; animation-play-state: paused; animation-play-state: initial; animation-play-state: inherit; ",
        actual
    )

[<Fact>]
let ``animation iteration count`` () =
    let actual =
        style {
            animationIterationCountInfinite
            animationIterationCountInitial
            animationIterationCountInheritFromParent
        }

    Assert.Equal(
        "animation-iteration-count: infinite; animation-iteration-count: initial; animation-iteration-count: inherit; ",
        actual
    )

[<Fact>]
let ``animation fill mode`` () =
    let actual =
        style {
            animationFillModeNone
            animationFillModeForwards
            animationFillModeBackwards
            animationFillModeBoth
            animationFillModeInitial
            animationFillModeInheritFromParent
        }

    Assert.Equal(
        "animation-fill-mode: none; animation-fill-mode: forwards; animation-fill-mode: backwards; animation-fill-mode: both; animation-fill-mode: initial; animation-fill-mode: inherit; ",
        actual
    )

[<Fact>]
let ``animation duration count`` () =
    let actual = style { animationDurationCount 3 }
    Assert.Equal("animation-duration-count: 3; ", actual)

[<Fact>]
let ``transition shorthand and property`` () =
    let actual =
        style {
            transition "all 0.3s ease-in-out"
            transitionProperty "opacity"
        }

    Assert.Equal("transition: all 0.3s ease-in-out; transition-property: opacity; ", actual)

[<Fact>]
let ``transition duration overloads`` () =
    let actual =
        style {
            transitionDuration (TimeSpan.FromMilliseconds 300.0)
            transitionDurationSeconds 2
            transitionDurationSeconds 1.5
            transitionDurationMilliseconds 250
            transitionDurationMilliseconds 250.0
        }

    Assert.Equal(
        "transition-duration: 300ms; transition-duration: 2s; transition-duration: 1.5s; transition-duration: 250ms; transition-duration: 250ms; ",
        actual
    )

[<Fact>]
let ``transition delay overloads`` () =
    let actual =
        style {
            transitionDelay (TimeSpan.FromMilliseconds 100.0)
            transitionDelaySeconds 1
            transitionDelaySeconds 0.5
            transitionDelayMilliseconds 200
            transitionDelayMilliseconds 200.0
        }

    Assert.Equal(
        "transition-delay: 100ms; transition-delay: 1s; transition-delay: 0.5s; transition-delay: 200ms; transition-delay: 200ms; ",
        actual
    )

[<Fact>]
let ``transition timing functions`` () =
    let actual =
        style {
            transitionTimingFunctionEase
            transitionTimingFunctionLinear
            transitionTimingFunctionEaseIn
            transitionTimingFunctionEaseOut
            transitionTimingFunctionEaseInOut
            transitionTimingFunctionStepStart
            transitionTimingFunctionStepEnd
            transitionTimingFunctionCubicBezier 0.1 0.2 0.3 0.4
            transitionTimingFunctionInitial
            transitionTimingFunctionInheritFromParent
        }

    Assert.Equal(
        "transition-timing-function: ease; transition-timing-function: linear; transition-timing-function: ease-in; transition-timing-function: ease-out; transition-timing-function: ease-in-out; transition-timing-function: step-start; transition-timing-function: step-end; transition-timing-function: cubic-bezier(0.1,0.2,0.3,0.4); transition-timing-function: initial; transition-timing-function: inherit; ",
        actual
    )
