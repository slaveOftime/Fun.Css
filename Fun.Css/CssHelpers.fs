[<AutoOpen>]
module Fun.Css.Helpers

open Internal


/// The accent-color property specifies the accent color for user-interface controls like: , ,  and .
type accentColor =

    /// Default value. The browser choose the accent color
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("accent-color: ").Append("auto").Append("; "))
    

    /// Specifies the color to be used as the accent color. All legal color values can be used (rgb, hex, named-color, etc). For more information on legal values, read our CSS Colors Tutorial
    static member inline color(value: string) = CombineKeyValue(fun sb -> sb.Append("accent-color: ").Append(value).Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("accent-color: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("accent-color: ").Append("initial").Append("; "))
    

/// The align-content property specifies how flex lines are distributed along the cross axis in a flexbox container.
type alignContent =

    /// Lines are packed toward the center of the flex container
    static member inline center = CombineKeyValue(fun sb -> sb.Append("align-content: ").Append("center").Append("; "))
    

    /// Lines are packed toward the end of the flex container
    static member inline flexEnd = CombineKeyValue(fun sb -> sb.Append("align-content: ").Append("flex-end").Append("; "))
    

    /// Lines are packed toward the start of the flex container
    static member inline flexStart = CombineKeyValue(fun sb -> sb.Append("align-content: ").Append("flex-start").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("align-content: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("align-content: ").Append("initial").Append("; "))
    

    /// Lines are evenly distributed in the flex container, with half-size spaces on either end
    static member inline spaceAround = CombineKeyValue(fun sb -> sb.Append("align-content: ").Append("space-around").Append("; "))
    

    /// Lines are evenly distributed in the flex container
    static member inline spaceBetween = CombineKeyValue(fun sb -> sb.Append("align-content: ").Append("space-between").Append("; "))
    

    /// Lines are evenly distributed in the flex container, with equal space around them
    static member inline spaceEvenly = CombineKeyValue(fun sb -> sb.Append("align-content: ").Append("space-evenly").Append("; "))
    

    /// Default value. Lines stretch to take up the remaining space
    static member inline stretch = CombineKeyValue(fun sb -> sb.Append("align-content: ").Append("stretch").Append("; "))
    

/// The align-items property specifies the default alignment for items inside a flexbox or grid container.
type alignItems =

    /// Items are positioned at the baseline of the container
    static member inline baseline = CombineKeyValue(fun sb -> sb.Append("align-items: ").Append("baseline").Append("; "))
    

    /// Items are positioned at the center of the container
    static member inline center = CombineKeyValue(fun sb -> sb.Append("align-items: ").Append("center").Append("; "))
    

    /// Items are positioned at the end of the their individual grid cells, in the block direction
    static member inline end' = CombineKeyValue(fun sb -> sb.Append("align-items: ").Append("end").Append("; "))
    

    /// Items are positioned at the end of the container
    static member inline flexEnd = CombineKeyValue(fun sb -> sb.Append("align-items: ").Append("flex-end").Append("; "))
    

    /// Items are positioned at the beginning of the container
    static member inline flexStart = CombineKeyValue(fun sb -> sb.Append("align-items: ").Append("flex-start").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("align-items: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("align-items: ").Append("initial").Append("; "))
    

    /// Default. Behaves like 'stretch' for flexbox and grid items, or 'start' for grid items with a defined block size.
    static member inline normal = CombineKeyValue(fun sb -> sb.Append("align-items: ").Append("normal").Append("; "))
    

    /// Items are positioned at the beginning of their individual grid cells, in the block direction
    static member inline start = CombineKeyValue(fun sb -> sb.Append("align-items: ").Append("start").Append("; "))
    

    /// Items are stretched to fit the container
    static member inline stretch = CombineKeyValue(fun sb -> sb.Append("align-items: ").Append("stretch").Append("; "))
    

/// The align-self property specifies the alignment in the block direction for the selected item inside a flexbox or grid container.
type alignSelf =

    /// Default. The element inherits its parent container's align-items property, or "stretch" if it has no parent container
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("align-self: ").Append("auto").Append("; "))
    

    /// The element is positioned at the baseline of the container
    static member inline baseline = CombineKeyValue(fun sb -> sb.Append("align-self: ").Append("baseline").Append("; "))
    

    /// The element is positioned at the center of the container
    static member inline center = CombineKeyValue(fun sb -> sb.Append("align-self: ").Append("center").Append("; "))
    

    /// The element is positioned at the end of the container
    static member inline flexEnd = CombineKeyValue(fun sb -> sb.Append("align-self: ").Append("flex-end").Append("; "))
    

    /// The element is positioned at the beginning of the container
    static member inline flexStart = CombineKeyValue(fun sb -> sb.Append("align-self: ").Append("flex-start").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("align-self: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("align-self: ").Append("initial").Append("; "))
    

    /// The element is positioned to fit the container
    static member inline stretch = CombineKeyValue(fun sb -> sb.Append("align-self: ").Append("stretch").Append("; "))
    

/// The animation property is a shorthand property for:
[<RequireQualifiedAccess>]
module animation =

    /// The animation-delay property specifies a delay for the start of an animation.
    type delay =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("animation-delay: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("animation-delay: ").Append("initial").Append("; "))
    

        /// Optional. Defines the number of seconds (s) or milliseconds (ms) to wait before the animation will start. Default value is 0. Negative values are allowed. If you use negative values, the animation will start as if it had already been playing for N seconds/milliseconds.
        static member inline time(value: float) = CombineKeyValue(fun sb -> sb.Append("animation-delay: ").Append(value).Append("; "))
    

    /// The animation-direction property defines whether an animation should be played forwards, backwards or in alternate cycles.
    type direction =

        /// The animation is played forwards first, then backwards
        static member inline alternate = CombineKeyValue(fun sb -> sb.Append("animation-direction: ").Append("alternate").Append("; "))
    

        /// The animation is played backwards first, then forwards
        static member inline alternateReverse = CombineKeyValue(fun sb -> sb.Append("animation-direction: ").Append("alternate-reverse").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("animation-direction: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("animation-direction: ").Append("initial").Append("; "))
    

        /// Default value. The animation is played as normal (forwards)
        static member inline normal = CombineKeyValue(fun sb -> sb.Append("animation-direction: ").Append("normal").Append("; "))
    

        /// The animation is played in reverse direction (backwards)
        static member inline reverse = CombineKeyValue(fun sb -> sb.Append("animation-direction: ").Append("reverse").Append("; "))
    

    /// The animation-duration property defines how long an animation should take to complete one cycle.
    type duration =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("animation-duration: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("animation-duration: ").Append("initial").Append("; "))
    

        /// Specifies the length of time an animation should take to complete one cycle. This can be specified in seconds or milliseconds. Default value is 0, which means that no animation will occur
        static member inline time(value: float) = CombineKeyValue(fun sb -> sb.Append("animation-duration: ").Append(value).Append("; "))
    

    /// The animation-iteration-count property specifies the number of times an animation should be played.
    type iterationCount =

        /// Specifies that the animation should be played infinite times (for ever)
        static member inline infinite = CombineKeyValue(fun sb -> sb.Append("animation-iteration-count: ").Append("infinite").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("animation-iteration-count: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("animation-iteration-count: ").Append("initial").Append("; "))
    

        /// A number that defines how many times an animation should be played. Default value is 1
        static member inline number(value: float) = CombineKeyValue(fun sb -> sb.Append("animation-iteration-count: ").Append(value).Append("; "))
    

    /// The animation-name property specifies a name for the @keyframes animation.
    type name =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("animation-name: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("animation-name: ").Append("initial").Append("; "))
    

        /// Specifies the name of the keyframe you want to bind to the selector
        static member inline keyframename = CombineKeyValue(fun sb -> sb.Append("animation-name: ").Append("keyframename").Append("; "))
    

        /// Default value. Specifies that there will be no animation (can be used to override animations coming from the cascade)
        static member inline none = CombineKeyValue(fun sb -> sb.Append("animation-name: ").Append("none").Append("; "))
    

    /// The animation-play-state property specifies whether the animation is running or paused.
    type playState =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("animation-play-state: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("animation-play-state: ").Append("initial").Append("; "))
    

        /// Specifies that the animation is paused
        static member inline paused = CombineKeyValue(fun sb -> sb.Append("animation-play-state: ").Append("paused").Append("; "))
    

        /// Default value. Specifies that the animation is running
        static member inline running = CombineKeyValue(fun sb -> sb.Append("animation-play-state: ").Append("running").Append("; "))
    

    /// The animation-timing-function specifies the speed curve of an animation.
    type timingFunction =

        /// Define your own values in the cubic-bezier function Possible values are numeric values from 0 to 1
        static member inline cubicBezier(value: string) = CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append($"cubic-bezier({value})").Append("; "))
    

        /// Default value. The animation has a slow start, then fast, before it ends slowly
        static member inline ease = CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append("ease").Append("; "))
    

        /// The animation has a slow start
        static member inline easeIn = CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append("ease-in").Append("; "))
    

        /// The animation has both a slow start and a slow end
        static member inline easeInOut = CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append("ease-in-out").Append("; "))
    

        /// The animation has a slow end
        static member inline easeOut = CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append("ease-out").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append("initial").Append("; "))
    

        /// The animation has the same speed from start to end
        static member inline linear = CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append("linear").Append("; "))
    

        /// Equivalent to steps(1, end)
        static member inline stepEnd = CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append("step-end").Append("; "))
    

        /// Equivalent to steps(1, start)
        static member inline stepStart = CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append("step-start").Append("; "))
    

        /// Specifies a stepping function, with two parameters. The first parameter specifies the number of intervals in the function. It must be a positive integer (greater than 0). The second parameter, which is optional, is either the value "start" or "end", and specifies the point at which the change of values occur within the interval. If the second parameter is omitted, it is given the value "end"
        static member inline steps(value: string) = CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append($"steps({value})").Append("; "))
    

/// The aspect-ratio property allows you to define the ratio between width and height of an element.
type aspectRatio =

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("aspect-ratio: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("aspect-ratio: ").Append("initial").Append("; "))
    

    /// First number specifies the number for width in aspect ratio.
    static member inline number(value: float) = CombineKeyValue(fun sb -> sb.Append("aspect-ratio: ").Append(value).Append("; "))
    

/// The backdrop-filter property is used to apply a graphical effect to the area behind an element.
type backdropFilter =

    /// A space-separated list of filter-functions like: blur()brightness()contrast()drop-shadow()grayscale()hue-rotate()invert()opacity()sepia()saturate()or an url to an SVG filter that will be applied to the backdrop
    static member inline filter(value: string) = CombineKeyValue(fun sb -> sb.Append("backdrop-filter: ").Append(value).Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("backdrop-filter: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("backdrop-filter: ").Append("initial").Append("; "))
    

    /// Default value. No filter is applied to the backdrop
    static member inline none = CombineKeyValue(fun sb -> sb.Append("backdrop-filter: ").Append("none").Append("; "))
    

/// The backface-visibility property defines whether or not the back face of an element should be visible when facing the user.
type backfaceVisibility =

    /// The backside is not visible
    static member inline hidden = CombineKeyValue(fun sb -> sb.Append("backface-visibility: ").Append("hidden").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("backface-visibility: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("backface-visibility: ").Append("initial").Append("; "))
    

    /// Default value. The backside is visible
    static member inline visible = CombineKeyValue(fun sb -> sb.Append("backface-visibility: ").Append("visible").Append("; "))
    

/// The background property is a shorthand property for:
[<RequireQualifiedAccess>]
module background =

    /// The background-blend-mode property defines the blending mode of each background layer (color and/or image).
    type blendMode =

        /// Sets the blending mode to color
        static member inline color(value: string) = CombineKeyValue(fun sb -> sb.Append("background-blend-mode: ").Append(value).Append("; "))
    

        /// Sets the blending mode to color-dodge
        static member inline colorDodge(value: string) = CombineKeyValue(fun sb -> sb.Append("background-blend-mode: ").Append(value).Append("; "))
    

        /// Sets the blending mode to darken
        static member inline darken = CombineKeyValue(fun sb -> sb.Append("background-blend-mode: ").Append("darken").Append("; "))
    

        /// Sets the blending mode to lighten
        static member inline lighten = CombineKeyValue(fun sb -> sb.Append("background-blend-mode: ").Append("lighten").Append("; "))
    

        /// Sets the blending mode to luminosity
        static member inline luminosity = CombineKeyValue(fun sb -> sb.Append("background-blend-mode: ").Append("luminosity").Append("; "))
    

        /// Sets the blending mode to multiply
        static member inline multiply = CombineKeyValue(fun sb -> sb.Append("background-blend-mode: ").Append("multiply").Append("; "))
    

        /// This is default. Sets the blending mode to normal
        static member inline normal = CombineKeyValue(fun sb -> sb.Append("background-blend-mode: ").Append("normal").Append("; "))
    

        /// Sets the blending mode to overlay
        static member inline overlay = CombineKeyValue(fun sb -> sb.Append("background-blend-mode: ").Append("overlay").Append("; "))
    

        /// Sets the blending mode to saturation
        static member inline saturation = CombineKeyValue(fun sb -> sb.Append("background-blend-mode: ").Append("saturation").Append("; "))
    

        /// Sets the blending mode to screen
        static member inline screen = CombineKeyValue(fun sb -> sb.Append("background-blend-mode: ").Append("screen").Append("; "))
    

    /// The background-clip property defines how far the background (color or image) should extend within an element.
    type clip =

        /// Default value. The background extends behind the border
        static member inline borderBox = CombineKeyValue(fun sb -> sb.Append("background-clip: ").Append("border-box").Append("; "))
    

        /// The background extends to the edge of the content box
        static member inline contentBox = CombineKeyValue(fun sb -> sb.Append("background-clip: ").Append("content-box").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("background-clip: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("background-clip: ").Append("initial").Append("; "))
    

        /// The background extends to the inside edge of the border
        static member inline paddingBox = CombineKeyValue(fun sb -> sb.Append("background-clip: ").Append("padding-box").Append("; "))
    

    /// The background-color property sets the background color of an element.
    type color =

        /// Specifies the background color. Look at CSS Color Values for a complete list of possible color values.
        static member inline color(value: string) = CombineKeyValue(fun sb -> sb.Append("background-color: ").Append(value).Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("background-color: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("background-color: ").Append("initial").Append("; "))
    

        /// Specifies that the background color should be transparent. This is default
        static member inline transparent = CombineKeyValue(fun sb -> sb.Append("background-color: ").Append("transparent").Append("; "))
    

    /// The background-image property sets one or more background images for an element.
    type image =

        /// Sets a conic gradient as the background image. Define at least two colors
        static member inline conicGradient(value: string) = CombineKeyValue(fun sb -> sb.Append("background-image: ").Append($"conic-gradient({value})").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("background-image: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("background-image: ").Append("initial").Append("; "))
    

        /// Sets a linear gradient as the background image. Define at least two colors (top to bottom)
        static member inline linearGradient(value: string) = CombineKeyValue(fun sb -> sb.Append("background-image: ").Append($"linear-gradient({value})").Append("; "))
    

        /// No background image will be displayed. This is default
        static member inline none = CombineKeyValue(fun sb -> sb.Append("background-image: ").Append("none").Append("; "))
    

        /// Sets a radial gradient as the background image. Define at least two colors (center to edges)
        static member inline radialGradient(value: string) = CombineKeyValue(fun sb -> sb.Append("background-image: ").Append($"radial-gradient({value})").Append("; "))
    

        /// Repeats a conic gradient
        static member inline repeatingConicGradient(value: string) = CombineKeyValue(fun sb -> sb.Append("background-image: ").Append($"repeating-conic-gradient({value})").Append("; "))
    

        /// Repeats a linear gradient
        static member inline repeatingLinearGradient(value: string) = CombineKeyValue(fun sb -> sb.Append("background-image: ").Append($"repeating-linear-gradient({value})").Append("; "))
    

        /// Repeats a radial gradient
        static member inline repeatingRadialGradient(value: string) = CombineKeyValue(fun sb -> sb.Append("background-image: ").Append($"repeating-radial-gradient({value})").Append("; "))
    

        /// The URL to the image. To specify more than one image, separate the URLs with a comma
        static member inline url(value: string) = CombineKeyValue(fun sb -> sb.Append("background-image: ").Append($"url({value})").Append("; "))
    

    /// The background-origin property specifies the origin position (the background positioning area) of a background image.
    type origin =

        /// The background image starts from the upper left corner of the border
        static member inline borderBox = CombineKeyValue(fun sb -> sb.Append("background-origin: ").Append("border-box").Append("; "))
    

        /// The background image starts from the upper left corner of the content
        static member inline contentBox = CombineKeyValue(fun sb -> sb.Append("background-origin: ").Append("content-box").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("background-origin: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("background-origin: ").Append("initial").Append("; "))
    

        /// Default value. The background image starts from the upper left corner of the padding edge
        static member inline paddingBox = CombineKeyValue(fun sb -> sb.Append("background-origin: ").Append("padding-box").Append("; "))
    

    /// The background-position property sets the starting position of a background image.
    type position =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("background-position: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("background-position: ").Append("initial").Append("; "))
    

        /// If you only specify one keyword, the other value will be "center"
        static member inline left(value: string) = CombineKeyValue(fun sb -> sb.Append("background-position: ").Append(value).Append("; "))
    

        /// The first value is the horizontal position and the second value is the vertical. The top left corner is 0% 0%. The right bottom corner is 100% 100%. If you only specify one value, the other value will be 50%. Default value is: 0% 0%
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("background-position: ").Append(string value + "%").Append("; "))
    

        /// The first value is the horizontal position and the second value is the vertical. The top left corner is 0 0. Units can be pixels (0px 0px) or any other CSS units. If you only specify one value, the other value will be 50%. You can mix % and positions
        static member inline xpos(value: string) = CombineKeyValue(fun sb -> sb.Append("background-position: ").Append(value).Append("; "))
    

    /// The background-position-x property sets the position of a background image on the x-axis.
    type positionX =

        /// Positions background center on x-axis.
        static member inline center = CombineKeyValue(fun sb -> sb.Append("background-position-x: ").Append("center").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("background-position-x: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("background-position-x: ").Append("initial").Append("; "))
    

        /// Positions background left side on x-axis.
        static member inline left = CombineKeyValue(fun sb -> sb.Append("background-position-x: ").Append("left").Append("; "))
    

        /// Positions background right side on x-axis.
        static member inline right = CombineKeyValue(fun sb -> sb.Append("background-position-x: ").Append("right").Append("; "))
    

        /// Left side is 0% on x-axis, and right side is 100%. Percentage value refers to width of background positioning area minus width of background image.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("background-position-x: ").Append(string value + "%").Append("; "))
    

        /// Horizontal distance from left side. Units can be pixels (0px) or any other CSS units.
        static member inline xpos' = CombineKeyValue(fun sb -> sb.Append("background-position-x: ").Append("xpos").Append("; "))
    

        /// Two value syntax, only supported in Firefox and Safari. - xpos is set either to "left" or "right". - offset is horizontal distance from background image and "left" or "right" side set with xpos. Units can be pixels or any other CSS units.
        static member inline xpos(value: string) = CombineKeyValue(fun sb -> sb.Append("background-position-x: ").Append(value).Append("; "))
    

    /// The background-position-y property sets the position of a background image on the y-axis.
    type positionY =

        /// Positions background bottom on y-axis.
        static member inline bottom = CombineKeyValue(fun sb -> sb.Append("background-position-y: ").Append("bottom").Append("; "))
    

        /// Positions background center on y-axis.
        static member inline center = CombineKeyValue(fun sb -> sb.Append("background-position-y: ").Append("center").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("background-position-y: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("background-position-y: ").Append("initial").Append("; "))
    

        /// Positions background top on y-axis.
        static member inline top = CombineKeyValue(fun sb -> sb.Append("background-position-y: ").Append("top").Append("; "))
    

        /// Top side is 0% on y-axis, and bottom side is 100%. Percentage value refers to height of background positioning area minus height of background image.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("background-position-y: ").Append(string value + "%").Append("; "))
    

        /// Vertical distance from top side. Units can be pixels (0px) or any other CSS units.
        static member inline ypos' = CombineKeyValue(fun sb -> sb.Append("background-position-y: ").Append("ypos").Append("; "))
    

        /// Two value syntax, only supported in Firefox and Safari. - ypos is set either to "top" or "bottom". - offset is vertical distance from background image and "top" or "bottom" side set with ypos. Units can be pixels or any other CSS units.
        static member inline ypos(value: string) = CombineKeyValue(fun sb -> sb.Append("background-position-y: ").Append(value).Append("; "))
    

    /// The background-repeat property sets if/how a background image will be repeated.
    type repeat =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("background-repeat: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("background-repeat: ").Append("initial").Append("; "))
    

        /// The background-image is not repeated. The image will only be shown once
        static member inline noRepeat = CombineKeyValue(fun sb -> sb.Append("background-repeat: ").Append("no-repeat").Append("; "))
    

        /// The background image is repeated both vertically and horizontally. The last image will be clipped if it does not fit. This is default
        static member inline repeat = CombineKeyValue(fun sb -> sb.Append("background-repeat: ").Append("repeat").Append("; "))
    

        /// The background image is repeated only horizontally
        static member inline repeatX = CombineKeyValue(fun sb -> sb.Append("background-repeat: ").Append("repeat-x").Append("; "))
    

        /// The background image is repeated only vertically
        static member inline repeatY = CombineKeyValue(fun sb -> sb.Append("background-repeat: ").Append("repeat-y").Append("; "))
    

        /// The background-image is repeated and squished or stretched to fill the space (no gaps)
        static member inline round = CombineKeyValue(fun sb -> sb.Append("background-repeat: ").Append("round").Append("; "))
    

        /// The background-image is repeated as much as possible without clipping. The first and last image is pinned to either side of the element, and whitespace is distributed evenly between the images
        static member inline space = CombineKeyValue(fun sb -> sb.Append("background-repeat: ").Append("space").Append("; "))
    

    /// The background-size property specifies the size of the background images.
    type size =

        /// Default value. The background image is displayed in its original size
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("background-size: ").Append("auto").Append("; "))
    

        /// Resize the background image to make sure the image is fully visible
        static member inline contain = CombineKeyValue(fun sb -> sb.Append("background-size: ").Append("contain").Append("; "))
    

        /// Resize the background image to cover the entire container, even if it has to stretch the image or cut a little bit off one of the edges
        static member inline cover = CombineKeyValue(fun sb -> sb.Append("background-size: ").Append("cover").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("background-size: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("background-size: ").Append("initial").Append("; "))
    

        /// Sets the width and height of the background image. The first value sets the width, the second value sets the height. If only one value is given, the second is set to "auto". Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("background-size: ").Append(string value + "px").Append("; "))
    

        /// Sets the width and height of the background image. The first value sets the width, the second value sets the height. If only one value is given, the second is set to "auto". Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("background-size: ").Append(value).Append("; "))
    

        /// Sets the width and height of the background image in percent of the parent element. The first value sets the width, the second value sets the height. If only one value is given, the second is set to "auto"
        static member inline percentage = CombineKeyValue(fun sb -> sb.Append("background-size: ").Append("percentage").Append("; "))
    

/// The block-size property specifies the size of an element in the block direction.
type blockSize =

    /// Specifies block-size in percent relative to size of parent element on the corresponding axis.
    static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("block-size: ").Append(string value + "%").Append("; "))
    

    /// Default. The element's default block-size value.
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("block-size: ").Append("auto").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("block-size: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("block-size: ").Append("initial").Append("; "))
    

    /// Specifies block-size in px, pt, cm, etc. Read about length units
    static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("block-size: ").Append(string value + "px").Append("; "))
    

    /// Specifies block-size in px, pt, cm, etc. Read about length units
    static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("block-size: ").Append(value).Append("; "))
    

/// The border property is a shorthand property for:
[<RequireQualifiedAccess>]
module border =

    /// The border-block property is a shorthand property for these properties:
    type block =

        /// Specifies the color of the border in the block direction. Default value is the color of the text
        static member inline borderBlockColor(value: string) = CombineKeyValue(fun sb -> sb.Append("border-block: ").Append(value).Append("; "))
    

        /// Specifies the style of the border in the block direction. Default value is "none"
        static member inline borderBlockStyle = CombineKeyValue(fun sb -> sb.Append("border-block: ").Append("border-block-style").Append("; "))
    

        /// Specifies the width of the border in the block direction. Default value is "medium"
        static member inline borderBlockWidth = CombineKeyValue(fun sb -> sb.Append("border-block: ").Append("border-block-width").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-block: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-block: ").Append("initial").Append("; "))
    

    /// The border-block-color property sets the color of an element's borders in the block direction.
    type blockColor =

        /// Specifies the border color. Look at CSS Color Values for a complete list of possible color values. Default color is the current color of the element
        static member inline color(value: string) = CombineKeyValue(fun sb -> sb.Append("border-block-color: ").Append(value).Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-block-color: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-block-color: ").Append("initial").Append("; "))
    

        /// Specifies that the border color should be transparent
        static member inline transparent = CombineKeyValue(fun sb -> sb.Append("border-block-color: ").Append("transparent").Append("; "))
    

    /// The border-block-end property is a shorthand property for these properties:
    type blockEnd =

        /// Specifies the color of an element's border at the end in the block direction. Default value is the current color of the border
        static member inline borderBlockEndColor(value: string) = CombineKeyValue(fun sb -> sb.Append("border-block-end: ").Append(value).Append("; "))
    

        /// Specifies the style of an element's border at the end in the block direction. Default value is "none"
        static member inline borderBlockEndStyle = CombineKeyValue(fun sb -> sb.Append("border-block-end: ").Append("border-block-end-style").Append("; "))
    

        /// Specifies the width of an element's border at the end in the block direction. Default value is "medium"
        static member inline borderBlockEndWidth = CombineKeyValue(fun sb -> sb.Append("border-block-end: ").Append("border-block-end-width").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-block-end: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-block-end: ").Append("initial").Append("; "))
    

    /// The border-block-end-color property sets the color of an element's border at the end in the block direction.
    type blockEndColor =

        /// Specifies the border color. Look at CSS Color Values for a complete list of possible color values. Default color is the current color of the element
        static member inline color(value: string) = CombineKeyValue(fun sb -> sb.Append("border-block-end-color: ").Append(value).Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-block-end-color: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-block-end-color: ").Append("initial").Append("; "))
    

        /// Specifies that the border color should be transparent
        static member inline transparent = CombineKeyValue(fun sb -> sb.Append("border-block-end-color: ").Append("transparent").Append("; "))
    

    /// The border-block-end-style property sets the style of an element's border at the end in the block direction.
    type blockEndStyle =

        /// Specifies a dashed border
        static member inline dashed = CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append("dashed").Append("; "))
    

        /// Specifies a dotted border
        static member inline dotted = CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append("dotted").Append("; "))
    

        /// Specifies a double border
        static member inline double = CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append("double").Append("; "))
    

        /// Specifies a 3D grooved border. The effect depends on the border-color value
        static member inline groove = CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append("groove").Append("; "))
    

        /// The same as "none", except in border conflict resolution for table elements
        static member inline hidden = CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append("hidden").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append("initial").Append("; "))
    

        /// Specifies a 3D inset border. The effect depends on the border-color value
        static member inline inset = CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append("inset").Append("; "))
    

        /// Default value. Specifies no border
        static member inline none = CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append("none").Append("; "))
    

        /// Specifies a 3D outset border. The effect depends on the border-color value
        static member inline outset = CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append("outset").Append("; "))
    

        /// Specifies a 3D ridged border. The effect depends on the border-color value
        static member inline rigde = CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append("rigde").Append("; "))
    

        /// Specifies a solid border
        static member inline solid = CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append("solid").Append("; "))
    

    /// The border-block-end-width property sets the width of an element's border at the end in the block direction.
    type blockEndWidth =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-block-end-width: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-block-end-width: ").Append("initial").Append("; "))
    

        /// Allows you to define the thickness of the border. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-block-end-width: ").Append(string value + "px").Append("; "))
    

        /// Allows you to define the thickness of the border. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-block-end-width: ").Append(value).Append("; "))
    

        /// Specifies a medium border. This is default
        static member inline medium = CombineKeyValue(fun sb -> sb.Append("border-block-end-width: ").Append("medium").Append("; "))
    

        /// Specifies a thick border
        static member inline thick = CombineKeyValue(fun sb -> sb.Append("border-block-end-width: ").Append("thick").Append("; "))
    

        /// Specifies a thin border
        static member inline thin = CombineKeyValue(fun sb -> sb.Append("border-block-end-width: ").Append("thin").Append("; "))
    

    /// The border-block-start property is a shorthand property for these properties:
    type blockStart =

        /// Specifies the color of an element's border at the end in the block direction. Default value is the current color of the border
        static member inline borderBlockStartColor(value: string) = CombineKeyValue(fun sb -> sb.Append("border-block-start: ").Append(value).Append("; "))
    

        /// Specifies the style of an element's border at the end in the block direction. Default value is "none"
        static member inline borderBlockStartStyle = CombineKeyValue(fun sb -> sb.Append("border-block-start: ").Append("border-block-start-style").Append("; "))
    

        /// Specifies the width of an element's border at the end in the block direction. Default value is "medium"
        static member inline borderBlockStartWidth = CombineKeyValue(fun sb -> sb.Append("border-block-start: ").Append("border-block-start-width").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-block-start: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-block-start: ").Append("initial").Append("; "))
    

    /// The border-block-start-color property sets the width of an element's border at the start in the block direction.
    type blockStartColor =

        /// Specifies the border color. Look at CSS Color Values for a complete list of possible color values. Default color is the current color of the element
        static member inline color(value: string) = CombineKeyValue(fun sb -> sb.Append("border-block-start-color: ").Append(value).Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-block-start-color: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-block-start-color: ").Append("initial").Append("; "))
    

        /// Specifies that the border color should be transparent
        static member inline transparent = CombineKeyValue(fun sb -> sb.Append("border-block-start-color: ").Append("transparent").Append("; "))
    

    /// The border-block-start-style property sets the style of an element's border at the start in the block direction.
    type blockStartStyle =

        /// Specifies a dashed border
        static member inline dashed = CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append("dashed").Append("; "))
    

        /// Specifies a dotted border
        static member inline dotted = CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append("dotted").Append("; "))
    

        /// Specifies a double border
        static member inline double = CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append("double").Append("; "))
    

        /// Specifies a 3D grooved border. The effect depends on the border-color value
        static member inline groove = CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append("groove").Append("; "))
    

        /// The same as "none", except in border conflict resolution for table elements
        static member inline hidden = CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append("hidden").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append("initial").Append("; "))
    

        /// Specifies a 3D inset border. The effect depends on the border-color value
        static member inline inset = CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append("inset").Append("; "))
    

        /// Default value. Specifies no border
        static member inline none = CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append("none").Append("; "))
    

        /// Specifies a 3D outset border. The effect depends on the border-color value
        static member inline outset = CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append("outset").Append("; "))
    

        /// Specifies a 3D ridged border. The effect depends on the border-color value
        static member inline rigde = CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append("rigde").Append("; "))
    

        /// Specifies a solid border
        static member inline solid = CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append("solid").Append("; "))
    

    /// The border-block-start-width property sets the width of an element's border at the start in the block direction.
    type blockStartWidth =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-block-start-width: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-block-start-width: ").Append("initial").Append("; "))
    

        /// Allows you to define the thickness of the border. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-block-start-width: ").Append(string value + "px").Append("; "))
    

        /// Allows you to define the thickness of the border. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-block-start-width: ").Append(value).Append("; "))
    

        /// Specifies a medium border. This is default
        static member inline medium = CombineKeyValue(fun sb -> sb.Append("border-block-start-width: ").Append("medium").Append("; "))
    

        /// Specifies a thick border
        static member inline thick = CombineKeyValue(fun sb -> sb.Append("border-block-start-width: ").Append("thick").Append("; "))
    

        /// Specifies a thin border
        static member inline thin = CombineKeyValue(fun sb -> sb.Append("border-block-start-width: ").Append("thin").Append("; "))
    

    /// The border-block-style property sets the style of an element's borders in the block direction.
    type blockStyle =

        /// Specifies a dashed border
        static member inline dashed = CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append("dashed").Append("; "))
    

        /// Specifies a dotted border
        static member inline dotted = CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append("dotted").Append("; "))
    

        /// Specifies a double border
        static member inline double = CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append("double").Append("; "))
    

        /// Specifies a 3D grooved border. The effect depends on the border-color value
        static member inline groove = CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append("groove").Append("; "))
    

        /// The same as "none", except in border conflict resolution for table elements
        static member inline hidden = CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append("hidden").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append("initial").Append("; "))
    

        /// Specifies a 3D inset border. The effect depends on the border-color value
        static member inline inset = CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append("inset").Append("; "))
    

        /// Default value. Specifies no border
        static member inline none = CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append("none").Append("; "))
    

        /// Specifies a 3D outset border. The effect depends on the border-color value
        static member inline outset = CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append("outset").Append("; "))
    

        /// Specifies a 3D ridged border. The effect depends on the border-color value
        static member inline rigde = CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append("rigde").Append("; "))
    

        /// Specifies a solid border
        static member inline solid = CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append("solid").Append("; "))
    

    /// The border-block-width property sets the width of an element's borders in the block direction.
    type blockWidth =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-block-width: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-block-width: ").Append("initial").Append("; "))
    

        /// Allows you to define the thickness of the border. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-block-width: ").Append(string value + "px").Append("; "))
    

        /// Allows you to define the thickness of the border. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-block-width: ").Append(value).Append("; "))
    

        /// Specifies a medium border. This is default
        static member inline medium = CombineKeyValue(fun sb -> sb.Append("border-block-width: ").Append("medium").Append("; "))
    

        /// Specifies a thick border
        static member inline thick = CombineKeyValue(fun sb -> sb.Append("border-block-width: ").Append("thick").Append("; "))
    

        /// Specifies a thin border
        static member inline thin = CombineKeyValue(fun sb -> sb.Append("border-block-width: ").Append("thin").Append("; "))
    

    /// The border-bottom property is a shorthand property for (in the following order):
    type bottom =

        /// Optional. Specifies the color of the bottom border. Default value is the color of the text
        static member inline borderBottomColor(value: string) = CombineKeyValue(fun sb -> sb.Append("border-bottom: ").Append(value).Append("; "))
    

        /// Required. Specifies the style of the bottom border. Default value is "none"
        static member inline borderBottomStyle = CombineKeyValue(fun sb -> sb.Append("border-bottom: ").Append("border-bottom-style").Append("; "))
    

        /// Required. Specifies the width of the bottom border. Default value is "medium"
        static member inline borderBottomWidth = CombineKeyValue(fun sb -> sb.Append("border-bottom: ").Append("border-bottom-width").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-bottom: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-bottom: ").Append("initial").Append("; "))
    

    /// The border-bottom-color property sets the color of an element's bottom border.
    type bottomColor =

        /// Specifies the color of the bottom border. Look at CSS Color Values for a complete list of possible color values. Default color is the current color of the element
        static member inline color(value: string) = CombineKeyValue(fun sb -> sb.Append("border-bottom-color: ").Append(value).Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-bottom-color: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-bottom-color: ").Append("initial").Append("; "))
    

        /// Specifies that the border color should be transparent
        static member inline transparent = CombineKeyValue(fun sb -> sb.Append("border-bottom-color: ").Append("transparent").Append("; "))
    

    /// The border-bottom-left-radius property defines the radius of the bottom-left corner.
    type bottomLeftRadius =

        /// Defines the shape of the bottom-left corner in %
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("border-bottom-left-radius: ").Append(string value + "%").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-bottom-left-radius: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-bottom-left-radius: ").Append("initial").Append("; "))
    

        /// Defines the shape of the bottom-left corner. Default value is 0. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-bottom-left-radius: ").Append(string value + "px").Append("; "))
    

        /// Defines the shape of the bottom-left corner. Default value is 0. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-bottom-left-radius: ").Append(value).Append("; "))
    

    /// The border-bottom-right-radius property defines the radius of the bottom-right corner.
    type bottomRightRadius =

        /// Defines the shape of the bottom-right corner in %
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("border-bottom-right-radius: ").Append(string value + "%").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-bottom-right-radius: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-bottom-right-radius: ").Append("initial").Append("; "))
    

        /// Defines the shape of the bottom-right corner. Default value is 0. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-bottom-right-radius: ").Append(string value + "px").Append("; "))
    

        /// Defines the shape of the bottom-right corner. Default value is 0. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-bottom-right-radius: ").Append(value).Append("; "))
    

    /// The border-bottom-style property sets the style of an element's bottom border.
    type bottomStyle =

        /// Specifies a dashed border
        static member inline dashed = CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append("dashed").Append("; "))
    

        /// Specifies a dotted border
        static member inline dotted = CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append("dotted").Append("; "))
    

        /// Specifies a double border
        static member inline double = CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append("double").Append("; "))
    

        /// Specifies a 3D grooved border. The effect depends on the border-color value
        static member inline groove = CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append("groove").Append("; "))
    

        /// The same as "none", except in border conflict resolution for table elements
        static member inline hidden = CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append("hidden").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append("initial").Append("; "))
    

        /// Specifies a 3D inset border. The effect depends on the border-color value
        static member inline inset = CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append("inset").Append("; "))
    

        /// Specifies no border. This is default
        static member inline none = CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append("none").Append("; "))
    

        /// Specifies a 3D outset border. The effect depends on the border-color value
        static member inline outset = CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append("outset").Append("; "))
    

        /// Specifies a 3D ridged border. The effect depends on the border-color value
        static member inline ridge = CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append("ridge").Append("; "))
    

        /// Specifies a solid border
        static member inline solid = CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append("solid").Append("; "))
    

    /// The border-bottom-width property sets the width of an element's bottom border.
    type bottomWidth =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-bottom-width: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-bottom-width: ").Append("initial").Append("; "))
    

        /// Allows you to define the thickness of the bottom border. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-bottom-width: ").Append(string value + "px").Append("; "))
    

        /// Allows you to define the thickness of the bottom border. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-bottom-width: ").Append(value).Append("; "))
    

        /// Specifies a medium bottom border. This is default
        static member inline medium = CombineKeyValue(fun sb -> sb.Append("border-bottom-width: ").Append("medium").Append("; "))
    

        /// Specifies a thick bottom border
        static member inline thick = CombineKeyValue(fun sb -> sb.Append("border-bottom-width: ").Append("thick").Append("; "))
    

        /// Specifies a thin bottom border
        static member inline thin = CombineKeyValue(fun sb -> sb.Append("border-bottom-width: ").Append("thin").Append("; "))
    

    /// The border-collapse property sets whether table borders should collapse into a single border or be separated as in standard HTML.
    type collapse =

        /// Borders are collapsed into a single border when possible (border-spacing and empty-cells properties have no effect)
        static member inline collapse = CombineKeyValue(fun sb -> sb.Append("border-collapse: ").Append("collapse").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-collapse: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-collapse: ").Append("initial").Append("; "))
    

        /// Borders are separated; each cell will display its own borders. This is default.
        static member inline separate = CombineKeyValue(fun sb -> sb.Append("border-collapse: ").Append("separate").Append("; "))
    

    /// The border-color property sets the color of an element's four borders. This property can have from one to four values.
    type color =

        /// Specifies the border color. Look at CSS Color Values for a complete list of possible color values. Default color is the current color of the element
        static member inline color(value: string) = CombineKeyValue(fun sb -> sb.Append("border-color: ").Append(value).Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-color: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-color: ").Append("initial").Append("; "))
    

        /// Specifies that the border color should be transparent
        static member inline transparent = CombineKeyValue(fun sb -> sb.Append("border-color: ").Append("transparent").Append("; "))
    

    /// The border-end-end-radius property defines the radius of the corner between the block-end and the inline-end sides of the element.
    type endEndRadius =

        /// Defines the shape of the corner at block-end and inline-end in percentange of length of element on corresponding axis.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("border-end-end-radius: ").Append(string value + "%").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-end-end-radius: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-end-end-radius: ").Append("initial").Append("; "))
    

        /// Defines the shape of the corner at block-end and inline-end. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-end-end-radius: ").Append(string value + "px").Append("; "))
    

        /// Defines the shape of the corner at block-end and inline-end. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-end-end-radius: ").Append(value).Append("; "))
    

    /// The border-end-start-radius property defines the radius of the corner between the block-end and the inline-start sides of the element.
    type endStartRadius =

        /// Defines the shape of the corner at block-end and inline-start in percentange of length of element on corresponding axis.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("border-end-start-radius: ").Append(string value + "%").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-end-start-radius: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-end-start-radius: ").Append("initial").Append("; "))
    

        /// Defines the shape of the corner at block-end and inline-start. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-end-start-radius: ").Append(string value + "px").Append("; "))
    

        /// Defines the shape of the corner at block-end and inline-start. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-end-start-radius: ").Append(value).Append("; "))
    

    /// The border-image property allows you to specify an image to be used as the border around an element.
    type image =

        /// The amount by which the border image area extends beyond the border box
        static member inline borderImageOutset = CombineKeyValue(fun sb -> sb.Append("border-image: ").Append("border-image-outset").Append("; "))
    

        /// Whether the border image should be repeated, rounded or stretched
        static member inline borderImageRepeat = CombineKeyValue(fun sb -> sb.Append("border-image: ").Append("border-image-repeat").Append("; "))
    

        /// How to slice the border image
        static member inline borderImageSlice = CombineKeyValue(fun sb -> sb.Append("border-image: ").Append("border-image-slice").Append("; "))
    

        /// The path to the image to be used as a border
        static member inline borderImageSource = CombineKeyValue(fun sb -> sb.Append("border-image: ").Append("border-image-source").Append("; "))
    

        /// The width of the border image
        static member inline borderImageWidth = CombineKeyValue(fun sb -> sb.Append("border-image: ").Append("border-image-width").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-image: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-image: ").Append("initial").Append("; "))
    

    /// The border-image-outset property specifies the amount by which the border image area extends beyond the border box.
    type imageOutset =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-image-outset: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-image-outset: ").Append("initial").Append("; "))
    

        /// A length unit specifying how far from the edges the border-image will appear. Default value is 0
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-image-outset: ").Append(string value + "px").Append("; "))
    

        /// A length unit specifying how far from the edges the border-image will appear. Default value is 0
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-image-outset: ").Append(value).Append("; "))
    

        /// Represent multiples of the corresponding border-width
        static member inline number(value: float) = CombineKeyValue(fun sb -> sb.Append("border-image-outset: ").Append(value).Append("; "))
    

    /// The border-image-repeat property specifies whether the border image should be repeated, rounded, spaced or stretched.
    type imageRepeat =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-image-repeat: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-image-repeat: ").Append("initial").Append("; "))
    

        /// The image is tiled (repeated) to fill the area
        static member inline repeat = CombineKeyValue(fun sb -> sb.Append("border-image-repeat: ").Append("repeat").Append("; "))
    

        /// The image is tiled (repeated) to fill the area. If it does not fill the area with a whole number of tiles, the image is rescaled so it fits
        static member inline round = CombineKeyValue(fun sb -> sb.Append("border-image-repeat: ").Append("round").Append("; "))
    

        /// The image is tiled (repeated) to fill the area. If it does not fill the area with a whole number of tiles, the extra space is distributed around the tiles
        static member inline space = CombineKeyValue(fun sb -> sb.Append("border-image-repeat: ").Append("space").Append("; "))
    

        /// Default value. The image is stretched to fill the area
        static member inline stretch = CombineKeyValue(fun sb -> sb.Append("border-image-repeat: ").Append("stretch").Append("; "))
    

    /// The border-image-slice property specifies how to slice the image specified by border-image-source. The image is always sliced into nine sections: four corners, four edges and the middle.
    type imageSlice =

        /// Percentages are relative to the height or width of the image
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("border-image-slice: ").Append(string value + "%").Append("; "))
    

        /// Causes the middle part of the image to be displayed
        static member inline fill = CombineKeyValue(fun sb -> sb.Append("border-image-slice: ").Append("fill").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-image-slice: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-image-slice: ").Append("initial").Append("; "))
    

        /// The number(s) represent pixels for raster images or coordinates for vector images
        static member inline number(value: float) = CombineKeyValue(fun sb -> sb.Append("border-image-slice: ").Append(value).Append("; "))
    

    /// The border-image-source property specifies the path to the image to be used as a border (instead of the normal border around an element).
    type imageSource =

        /// The path to the image to be used as a border
        static member inline image = CombineKeyValue(fun sb -> sb.Append("border-image-source: ").Append("image").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-image-source: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-image-source: ").Append("initial").Append("; "))
    

        /// No image will be used
        static member inline none = CombineKeyValue(fun sb -> sb.Append("border-image-source: ").Append("none").Append("; "))
    

    /// The border-image-width property specifies the width of the border image.
    type imageWidth =

        /// Refers to the size of the border image area: the width of the area for horizontal offsets, the height for vertical offsets
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("border-image-width: ").Append(string value + "%").Append("; "))
    

        /// If specified, the width is the intrinsic width or height of the corresponding image slice
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("border-image-width: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-image-width: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-image-width: ").Append("initial").Append("; "))
    

        /// A length unit (px) specifying the size of the border-width
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-image-width: ").Append(string value + "px").Append("; "))
    

        /// A length unit (px) specifying the size of the border-width
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-image-width: ").Append(value).Append("; "))
    

        /// Default value 1. Represents multiples of the corresponding border-width
        static member inline number(value: float) = CombineKeyValue(fun sb -> sb.Append("border-image-width: ").Append(value).Append("; "))
    

    /// The border-inline property is a shorthand property for these properties:
    type inline' =

        /// Specifies the color of the borders in the inline direction. Default value is the color of the text
        static member inline borderInlineColor(value: string) = CombineKeyValue(fun sb -> sb.Append("border-inline: ").Append(value).Append("; "))
    

        /// Specifies the style of the borders in the inline direction. Default value is "none"
        static member inline borderInlineStyle = CombineKeyValue(fun sb -> sb.Append("border-inline: ").Append("border-inline-style").Append("; "))
    

        /// Specifies the width of the borders in the inline direction. Default value is "medium"
        static member inline borderInlineWidth = CombineKeyValue(fun sb -> sb.Append("border-inline: ").Append("border-inline-width").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-inline: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-inline: ").Append("initial").Append("; "))
    

    /// The border-inline-color property sets the color of an element's borders in the inline direction.
    type inlineColor =

        /// Specifies the border color. Look at CSS Color Values for a complete list of possible color values. Default color is the current color of the element
        static member inline color(value: string) = CombineKeyValue(fun sb -> sb.Append("border-inline-color: ").Append(value).Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-inline-color: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-inline-color: ").Append("initial").Append("; "))
    

        /// Specifies that the border color should be transparent
        static member inline transparent = CombineKeyValue(fun sb -> sb.Append("border-inline-color: ").Append("transparent").Append("; "))
    

    /// The border-inline-end property is a shorthand property for these properties:
    type inlineEnd =

        /// Specifies the color of an element's border at the end of the inline direction. Default value is the current color of the border
        static member inline borderInlineEndColor(value: string) = CombineKeyValue(fun sb -> sb.Append("border-inline-end: ").Append(value).Append("; "))
    

        /// Specifies the style of an element's border at the end of the inline direction. Default value is "none"
        static member inline borderInlineEndStyle = CombineKeyValue(fun sb -> sb.Append("border-inline-end: ").Append("border-inline-end-style").Append("; "))
    

        /// Specifies the width of an element's border at the end of the inline direction. Default value is "medium"
        static member inline borderInlineEndWidth = CombineKeyValue(fun sb -> sb.Append("border-inline-end: ").Append("border-inline-end-width").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-inline-end: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-inline-end: ").Append("initial").Append("; "))
    

    /// The border-inline-end-color property sets the color of an element's border at the end in the inline direction.
    type inlineEndColor =

        /// Specifies the border color. Look at CSS Color Values for a complete list of possible color values. Default color is the current color of the element
        static member inline color(value: string) = CombineKeyValue(fun sb -> sb.Append("border-inline-end-color: ").Append(value).Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-inline-end-color: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-inline-end-color: ").Append("initial").Append("; "))
    

        /// Specifies that the border color should be transparent
        static member inline transparent = CombineKeyValue(fun sb -> sb.Append("border-inline-end-color: ").Append("transparent").Append("; "))
    

    /// The border-inline-end-style property sets the style of an element's border at the end in the inline direction.
    type inlineEndStyle =

        /// Specifies a dashed border
        static member inline dashed = CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append("dashed").Append("; "))
    

        /// Specifies a dotted border
        static member inline dotted = CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append("dotted").Append("; "))
    

        /// Specifies a double border
        static member inline double = CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append("double").Append("; "))
    

        /// Specifies a 3D grooved border. The effect depends on the border-color value
        static member inline groove = CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append("groove").Append("; "))
    

        /// The same as "none", except in border conflict resolution for table elements
        static member inline hidden = CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append("hidden").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append("initial").Append("; "))
    

        /// Specifies a 3D inset border. The effect depends on the border-color value
        static member inline inset = CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append("inset").Append("; "))
    

        /// Default value. Specifies no border
        static member inline none = CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append("none").Append("; "))
    

        /// Specifies a 3D outset border. The effect depends on the border-color value
        static member inline outset = CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append("outset").Append("; "))
    

        /// Specifies a 3D ridged border. The effect depends on the border-color value
        static member inline rigde = CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append("rigde").Append("; "))
    

        /// Specifies a solid border
        static member inline solid = CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append("solid").Append("; "))
    

    /// The border-inline-end-width property sets the width of an element's border at the end in the inline direction.
    type inlineEndWidth =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-inline-end-width: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-inline-end-width: ").Append("initial").Append("; "))
    

        /// Allows you to define the thickness of the border. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-inline-end-width: ").Append(string value + "px").Append("; "))
    

        /// Allows you to define the thickness of the border. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-inline-end-width: ").Append(value).Append("; "))
    

        /// Specifies a medium border. This is default
        static member inline medium = CombineKeyValue(fun sb -> sb.Append("border-inline-end-width: ").Append("medium").Append("; "))
    

        /// Specifies a thick border
        static member inline thick = CombineKeyValue(fun sb -> sb.Append("border-inline-end-width: ").Append("thick").Append("; "))
    

        /// Specifies a thin border
        static member inline thin = CombineKeyValue(fun sb -> sb.Append("border-inline-end-width: ").Append("thin").Append("; "))
    

    /// The border-inline-start property is a shorthand property for these properties:
    type inlineStart =

        /// Specifies the color of an element's border at the end of the inline direction. Default value is the current color of the border
        static member inline borderInlineStartColor(value: string) = CombineKeyValue(fun sb -> sb.Append("border-inline-start: ").Append(value).Append("; "))
    

        /// Specifies the style of an element's border at the end of the inline direction. Default value is "none"
        static member inline borderInlineStartStyle = CombineKeyValue(fun sb -> sb.Append("border-inline-start: ").Append("border-inline-start-style").Append("; "))
    

        /// Specifies the width of an element's border at the end of the inline direction. Default value is "medium"
        static member inline borderInlineStartWidth = CombineKeyValue(fun sb -> sb.Append("border-inline-start: ").Append("border-inline-start-width").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-inline-start: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-inline-start: ").Append("initial").Append("; "))
    

    /// The border-inline-start-color property sets the color of an element's border at the start in the inline direction.
    type inlineStartColor =

        /// Specifies the border color. Look at CSS Color Values for a complete list of possible color values. Default color is the current color of the element
        static member inline color(value: string) = CombineKeyValue(fun sb -> sb.Append("border-inline-start-color: ").Append(value).Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-inline-start-color: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-inline-start-color: ").Append("initial").Append("; "))
    

        /// Specifies that the border color should be transparent
        static member inline transparent = CombineKeyValue(fun sb -> sb.Append("border-inline-start-color: ").Append("transparent").Append("; "))
    

    /// The border-inline-start-style property sets the style of an element's border at the start in the inline direction.
    type inlineStartStyle =

        /// Specifies a dashed border
        static member inline dashed = CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append("dashed").Append("; "))
    

        /// Specifies a dotted border
        static member inline dotted = CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append("dotted").Append("; "))
    

        /// Specifies a double border
        static member inline double = CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append("double").Append("; "))
    

        /// Specifies a 3D grooved border. The effect depends on the border-color value
        static member inline groove = CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append("groove").Append("; "))
    

        /// The same as "none", except in border conflict resolution for table elements
        static member inline hidden = CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append("hidden").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append("initial").Append("; "))
    

        /// Specifies a 3D inset border. The effect depends on the border-color value
        static member inline inset = CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append("inset").Append("; "))
    

        /// Default value. Specifies no border
        static member inline none = CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append("none").Append("; "))
    

        /// Specifies a 3D outset border. The effect depends on the border-color value
        static member inline outset = CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append("outset").Append("; "))
    

        /// Specifies a 3D ridged border. The effect depends on the border-color value
        static member inline rigde = CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append("rigde").Append("; "))
    

        /// Specifies a solid border
        static member inline solid = CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append("solid").Append("; "))
    

    /// The border-inline-start-width property sets the width of an element's border at the start in the inline direction.
    type inlineStartWidth =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-inline-start-width: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-inline-start-width: ").Append("initial").Append("; "))
    

        /// Allows you to define the thickness of the border. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-inline-start-width: ").Append(string value + "px").Append("; "))
    

        /// Allows you to define the thickness of the border. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-inline-start-width: ").Append(value).Append("; "))
    

        /// Specifies a medium border. This is default
        static member inline medium = CombineKeyValue(fun sb -> sb.Append("border-inline-start-width: ").Append("medium").Append("; "))
    

        /// Specifies a thick border
        static member inline thick = CombineKeyValue(fun sb -> sb.Append("border-inline-start-width: ").Append("thick").Append("; "))
    

        /// Specifies a thin border
        static member inline thin = CombineKeyValue(fun sb -> sb.Append("border-inline-start-width: ").Append("thin").Append("; "))
    

    /// The border-inline-style property sets the style of an element's borders in the inline direction.
    type inlineStyle =

        /// Specifies a dashed border
        static member inline dashed = CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append("dashed").Append("; "))
    

        /// Specifies a dotted border
        static member inline dotted = CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append("dotted").Append("; "))
    

        /// Specifies a double border
        static member inline double = CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append("double").Append("; "))
    

        /// Specifies a 3D grooved border. The effect depends on the border-color value
        static member inline groove = CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append("groove").Append("; "))
    

        /// The same as "none", except in border conflict resolution for table elements
        static member inline hidden = CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append("hidden").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append("initial").Append("; "))
    

        /// Specifies a 3D inset border. The effect depends on the border-color value
        static member inline inset = CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append("inset").Append("; "))
    

        /// Default value. Specifies no border
        static member inline none = CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append("none").Append("; "))
    

        /// Specifies a 3D outset border. The effect depends on the border-color value
        static member inline outset = CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append("outset").Append("; "))
    

        /// Specifies a 3D ridged border. The effect depends on the border-color value
        static member inline rigde = CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append("rigde").Append("; "))
    

        /// Specifies a solid border
        static member inline solid = CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append("solid").Append("; "))
    

    /// The border-inline-width property sets the width of an element's borders in the inline direction.
    type inlineWidth =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-inline-width: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-inline-width: ").Append("initial").Append("; "))
    

        /// Allows you to define the thickness of the border. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-inline-width: ").Append(string value + "px").Append("; "))
    

        /// Allows you to define the thickness of the border. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-inline-width: ").Append(value).Append("; "))
    

        /// Specifies a medium border. This is default
        static member inline medium = CombineKeyValue(fun sb -> sb.Append("border-inline-width: ").Append("medium").Append("; "))
    

        /// Specifies a thick border
        static member inline thick = CombineKeyValue(fun sb -> sb.Append("border-inline-width: ").Append("thick").Append("; "))
    

        /// Specifies a thin border
        static member inline thin = CombineKeyValue(fun sb -> sb.Append("border-inline-width: ").Append("thin").Append("; "))
    

    /// The border-left property is a shorthand property for (in the following order):
    type left =

        /// Optional. Specifies the color of the left border. Default value is the color of the text
        static member inline borderLeftColor(value: string) = CombineKeyValue(fun sb -> sb.Append("border-left: ").Append(value).Append("; "))
    

        /// Required. Specifies the style of the left border. Default value is "none"
        static member inline borderLeftStyle = CombineKeyValue(fun sb -> sb.Append("border-left: ").Append("border-left-style").Append("; "))
    

        /// Optional. Specifies the width of the left border. Default value is "medium"
        static member inline borderLeftWidth = CombineKeyValue(fun sb -> sb.Append("border-left: ").Append("border-left-width").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-left: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-left: ").Append("initial").Append("; "))
    

    /// The border-left-color property sets the color of an element's left border.
    type leftColor =

        /// Specifies the color of the left border. Look at CSS Color Values for a complete list of possible color values. Default color is the current color of the element
        static member inline color(value: string) = CombineKeyValue(fun sb -> sb.Append("border-left-color: ").Append(value).Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-left-color: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-left-color: ").Append("initial").Append("; "))
    

        /// Specifies that the border color should be transparent
        static member inline transparent = CombineKeyValue(fun sb -> sb.Append("border-left-color: ").Append("transparent").Append("; "))
    

    /// The border-left-style property sets the style of an element's left border.
    type leftStyle =

        /// Specifies a dashed border
        static member inline dashed = CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append("dashed").Append("; "))
    

        /// Specifies a dotted border
        static member inline dotted = CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append("dotted").Append("; "))
    

        /// Specifies a double border
        static member inline double = CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append("double").Append("; "))
    

        /// Specifies a 3D grooved border. The effect depends on the border-color value
        static member inline groove = CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append("groove").Append("; "))
    

        /// The same as "none", except in border conflict resolution for table elements
        static member inline hidden = CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append("hidden").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append("initial").Append("; "))
    

        /// Specifies a 3D inset border. The effect depends on the border-color value
        static member inline inset = CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append("inset").Append("; "))
    

        /// Specifies no border. This is default
        static member inline none = CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append("none").Append("; "))
    

        /// Specifies a 3D outset border. The effect depends on the border-color value
        static member inline outset = CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append("outset").Append("; "))
    

        /// Specifies a 3D ridged border. The effect depends on the border-color value
        static member inline ridge = CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append("ridge").Append("; "))
    

        /// Specifies a solid border
        static member inline solid = CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append("solid").Append("; "))
    

    /// The border-left-width property sets the width of an element's left border.
    type leftWidth =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-left-width: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-left-width: ").Append("initial").Append("; "))
    

        /// Allows you to define the thickness of the left border. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-left-width: ").Append(string value + "px").Append("; "))
    

        /// Allows you to define the thickness of the left border. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-left-width: ").Append(value).Append("; "))
    

        /// Specifies a medium left border. This is default
        static member inline medium = CombineKeyValue(fun sb -> sb.Append("border-left-width: ").Append("medium").Append("; "))
    

        /// Specifies a thick left border
        static member inline thick = CombineKeyValue(fun sb -> sb.Append("border-left-width: ").Append("thick").Append("; "))
    

        /// Specifies a thin left border
        static member inline thin = CombineKeyValue(fun sb -> sb.Append("border-left-width: ").Append("thin").Append("; "))
    

    /// The border-radius property defines the radius of the element's corners.
    type radius =

        /// Defines the shape of the corners in %
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("border-radius: ").Append(string value + "%").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-radius: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-radius: ").Append("initial").Append("; "))
    

        /// Defines the shape of the corners. Default value is 0. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-radius: ").Append(string value + "px").Append("; "))
    

        /// Defines the shape of the corners. Default value is 0. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-radius: ").Append(value).Append("; "))
    

    /// The border-right property is a shorthand property for (in the following order):
    type right =

        /// Optional. Specifies the color of the right border. Default value is the color of the text
        static member inline borderRightColor(value: string) = CombineKeyValue(fun sb -> sb.Append("border-right: ").Append(value).Append("; "))
    

        /// Required. Specifies the style of the right border. Default value is "none"
        static member inline borderRightStyle = CombineKeyValue(fun sb -> sb.Append("border-right: ").Append("border-right-style").Append("; "))
    

        /// Required. Specifies the width of the right border. Default value is "medium"
        static member inline borderRightWidth = CombineKeyValue(fun sb -> sb.Append("border-right: ").Append("border-right-width").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-right: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-right: ").Append("initial").Append("; "))
    

    /// The border-right-color property sets the color of an element's right border.
    type rightColor =

        /// Specifies the color of the right border. Look at CSS Color Values for a complete list of possible color values. Default color is the current color of the element
        static member inline color(value: string) = CombineKeyValue(fun sb -> sb.Append("border-right-color: ").Append(value).Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-right-color: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-right-color: ").Append("initial").Append("; "))
    

        /// Specifies that the border color should be transparent
        static member inline transparent = CombineKeyValue(fun sb -> sb.Append("border-right-color: ").Append("transparent").Append("; "))
    

    /// The border-right-style property sets the style of an element's right border.
    type rightStyle =

        /// Specifies a dashed border
        static member inline dashed = CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append("dashed").Append("; "))
    

        /// Specifies a dotted border
        static member inline dotted = CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append("dotted").Append("; "))
    

        /// Specifies a double border
        static member inline double = CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append("double").Append("; "))
    

        /// Specifies a 3D grooved border. The effect depends on the border-color value
        static member inline groove = CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append("groove").Append("; "))
    

        /// The same as "none", except in border conflict resolution for table elements
        static member inline hidden = CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append("hidden").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append("initial").Append("; "))
    

        /// Specifies a 3D inset border. The effect depends on the border-color value
        static member inline inset = CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append("inset").Append("; "))
    

        /// Specifies no border. This is default
        static member inline none = CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append("none").Append("; "))
    

        /// Specifies a 3D outset border. The effect depends on the border-color value
        static member inline outset = CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append("outset").Append("; "))
    

        /// Specifies a 3D ridged border. The effect depends on the border-color value
        static member inline ridge = CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append("ridge").Append("; "))
    

        /// Specifies a solid border
        static member inline solid = CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append("solid").Append("; "))
    

    /// The border-right-width property sets the width of an element's right border.
    type rightWidth =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-right-width: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-right-width: ").Append("initial").Append("; "))
    

        /// Allows you to define the thickness of the right border. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-right-width: ").Append(string value + "px").Append("; "))
    

        /// Allows you to define the thickness of the right border. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-right-width: ").Append(value).Append("; "))
    

        /// Specifies a medium right border. This is default
        static member inline medium = CombineKeyValue(fun sb -> sb.Append("border-right-width: ").Append("medium").Append("; "))
    

        /// Specifies a thick right border
        static member inline thick = CombineKeyValue(fun sb -> sb.Append("border-right-width: ").Append("thick").Append("; "))
    

        /// Specifies a thin right border
        static member inline thin = CombineKeyValue(fun sb -> sb.Append("border-right-width: ").Append("thin").Append("; "))
    

    /// The border-spacing property sets the distance between the borders of adjacent cells.
    type spacing =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-spacing: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-spacing: ").Append("initial").Append("; "))
    

        /// Specifies the distance between the borders of adjacent cells in px, cm, etc. Negative values are not allowed. If one value is specified, it defines both the horizontal and vertical spacing between cellsIf two values are specified, the first sets the horizontal spacing and the second sets the vertical spacing
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-spacing: ").Append(value).Append("; "))
    

    /// The border-start-end-radius property defines the radius of the corner between the block-start and the inline-end sides of the element.
    type startEndRadius =

        /// Defines the shape of the corner at block-start and inline-end in percentange of length of element on corresponding axis.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("border-start-end-radius: ").Append(string value + "%").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-start-end-radius: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-start-end-radius: ").Append("initial").Append("; "))
    

        /// Defines the shape of the corner at block-start and inline-end. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-start-end-radius: ").Append(string value + "px").Append("; "))
    

        /// Defines the shape of the corner at block-start and inline-end. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-start-end-radius: ").Append(value).Append("; "))
    

    /// The border-start-start-radius property defines the radius of the corner between the block-start and the inline-start sides of the element.
    type startStartRadius =

        /// Defines the shape of the corner at block-start and inline-start in percentange of length of element on corresponding axis.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("border-start-start-radius: ").Append(string value + "%").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-start-start-radius: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-start-start-radius: ").Append("initial").Append("; "))
    

        /// Defines the shape of the corner at block-start and inline-start. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-start-start-radius: ").Append(string value + "px").Append("; "))
    

        /// Defines the shape of the corner at block-start and inline-start. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-start-start-radius: ").Append(value).Append("; "))
    

    /// The border-style property sets the style of an element's four borders. This property can have from one to four values.
    type style =

        /// Specifies a dashed border
        static member inline dashed = CombineKeyValue(fun sb -> sb.Append("border-style: ").Append("dashed").Append("; "))
    

        /// Specifies a dotted border
        static member inline dotted = CombineKeyValue(fun sb -> sb.Append("border-style: ").Append("dotted").Append("; "))
    

        /// Specifies a double border
        static member inline double = CombineKeyValue(fun sb -> sb.Append("border-style: ").Append("double").Append("; "))
    

        /// Specifies a 3D grooved border. The effect depends on the border-color value
        static member inline groove = CombineKeyValue(fun sb -> sb.Append("border-style: ").Append("groove").Append("; "))
    

        /// The same as "none", except in border conflict resolution for table elements
        static member inline hidden = CombineKeyValue(fun sb -> sb.Append("border-style: ").Append("hidden").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-style: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-style: ").Append("initial").Append("; "))
    

        /// Specifies a 3D inset border. The effect depends on the border-color value
        static member inline inset = CombineKeyValue(fun sb -> sb.Append("border-style: ").Append("inset").Append("; "))
    

        /// Default value. Specifies no border
        static member inline none = CombineKeyValue(fun sb -> sb.Append("border-style: ").Append("none").Append("; "))
    

        /// Specifies a 3D outset border. The effect depends on the border-color value
        static member inline outset = CombineKeyValue(fun sb -> sb.Append("border-style: ").Append("outset").Append("; "))
    

        /// Specifies a 3D ridged border. The effect depends on the border-color value
        static member inline ridge = CombineKeyValue(fun sb -> sb.Append("border-style: ").Append("ridge").Append("; "))
    

        /// Specifies a solid border
        static member inline solid = CombineKeyValue(fun sb -> sb.Append("border-style: ").Append("solid").Append("; "))
    

    /// The border-top shorthand property sets all the top border properties in one declaration.
    type top =

        /// Optional. Specifies the color of the top border. Default value is the color of the text
        static member inline borderTopColor(value: string) = CombineKeyValue(fun sb -> sb.Append("border-top: ").Append(value).Append("; "))
    

        /// Required. Specifies the style of the top border. Default value is "none"
        static member inline borderTopStyle = CombineKeyValue(fun sb -> sb.Append("border-top: ").Append("border-top-style").Append("; "))
    

        /// Required. Specifies the width of the top border. Default value is "medium"
        static member inline borderTopWidth = CombineKeyValue(fun sb -> sb.Append("border-top: ").Append("border-top-width").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-top: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-top: ").Append("initial").Append("; "))
    

    /// The border-top-color property sets the color of an element's top border.
    type topColor =

        /// Specifies the color of the top border. Look at CSS Color Values for a complete list of possible color values. Default color is the current color of the element
        static member inline color(value: string) = CombineKeyValue(fun sb -> sb.Append("border-top-color: ").Append(value).Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-top-color: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-top-color: ").Append("initial").Append("; "))
    

        /// Specifies that the border color should be transparent
        static member inline transparent = CombineKeyValue(fun sb -> sb.Append("border-top-color: ").Append("transparent").Append("; "))
    

    /// The border-top-left-radius property defines the radius of the top-left corner.
    type topLeftRadius =

        /// Defines the shape of the top-left corner in %
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("border-top-left-radius: ").Append(string value + "%").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-top-left-radius: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-top-left-radius: ").Append("initial").Append("; "))
    

        /// Defines the shape of the top-left corner. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-top-left-radius: ").Append(string value + "px").Append("; "))
    

        /// Defines the shape of the top-left corner. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-top-left-radius: ").Append(value).Append("; "))
    

    /// The border-top-right-radius property defines the radius of the top-right corner.
    type topRightRadius =

        /// Defines the shape of the top-right corner in %
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("border-top-right-radius: ").Append(string value + "%").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-top-right-radius: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-top-right-radius: ").Append("initial").Append("; "))
    

        /// Defines the shape of the top-right corner. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-top-right-radius: ").Append(string value + "px").Append("; "))
    

        /// Defines the shape of the top-right corner. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-top-right-radius: ").Append(value).Append("; "))
    

    /// The border-top-style property sets the style of an element's top border.
    type topStyle =

        /// Specifies a dashed border
        static member inline dashed = CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append("dashed").Append("; "))
    

        /// Specifies a dotted border
        static member inline dotted = CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append("dotted").Append("; "))
    

        /// Specifies a double border
        static member inline double = CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append("double").Append("; "))
    

        /// Specifies a 3D grooved border. The effect depends on the border-color value
        static member inline groove = CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append("groove").Append("; "))
    

        /// The same as "none", except in border conflict resolution for table elements
        static member inline hidden = CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append("hidden").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append("initial").Append("; "))
    

        /// Specifies a 3D inset border. The effect depends on the border-color value
        static member inline inset = CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append("inset").Append("; "))
    

        /// Specifies no border. This is default
        static member inline none = CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append("none").Append("; "))
    

        /// Specifies a 3D outset border. The effect depends on the border-color value
        static member inline outset = CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append("outset").Append("; "))
    

        /// Specifies a 3D ridged border. The effect depends on the border-color value
        static member inline ridge = CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append("ridge").Append("; "))
    

        /// Specifies a solid border
        static member inline solid = CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append("solid").Append("; "))
    

    /// The border-top-width property sets the width of an element's top border.
    type topWidth =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-top-width: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-top-width: ").Append("initial").Append("; "))
    

        /// Allows you to define the thickness of the top border. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-top-width: ").Append(string value + "px").Append("; "))
    

        /// Allows you to define the thickness of the top border. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-top-width: ").Append(value).Append("; "))
    

        /// Specifies a medium top border. This is default
        static member inline medium = CombineKeyValue(fun sb -> sb.Append("border-top-width: ").Append("medium").Append("; "))
    

        /// Specifies a thick top border
        static member inline thick = CombineKeyValue(fun sb -> sb.Append("border-top-width: ").Append("thick").Append("; "))
    

        /// Specifies a thin top border
        static member inline thin = CombineKeyValue(fun sb -> sb.Append("border-top-width: ").Append("thin").Append("; "))
    

    /// The border-width property sets the width of an element's four borders. This property can have from one to four values.
    type width =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("border-width: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("border-width: ").Append("initial").Append("; "))
    

        /// Allows you to define the thickness of the border. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("border-width: ").Append(string value + "px").Append("; "))
    

        /// Allows you to define the thickness of the border. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("border-width: ").Append(value).Append("; "))
    

        /// Specifies a medium border. This is default
        static member inline medium = CombineKeyValue(fun sb -> sb.Append("border-width: ").Append("medium").Append("; "))
    

        /// Specifies a thick border
        static member inline thick = CombineKeyValue(fun sb -> sb.Append("border-width: ").Append("thick").Append("; "))
    

        /// Specifies a thin border
        static member inline thin = CombineKeyValue(fun sb -> sb.Append("border-width: ").Append("thin").Append("; "))
    

/// The box-reflect property is used to create a reflection of an element.
type boxReflect =

    /// Creates a reflection above the element.
    static member inline above = CombineKeyValue(fun sb -> sb.Append("box-reflect: ").Append("above").Append("; "))
    

    /// Creates a reflection below the element.
    static member inline below = CombineKeyValue(fun sb -> sb.Append("box-reflect: ").Append("below").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("box-reflect: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("box-reflect: ").Append("initial").Append("; "))
    

    /// Creates a reflection to the left of the element.
    static member inline left = CombineKeyValue(fun sb -> sb.Append("box-reflect: ").Append("left").Append("; "))
    

    /// Default value. No reflection is displayed.
    static member inline none = CombineKeyValue(fun sb -> sb.Append("box-reflect: ").Append("none").Append("; "))
    

    /// Two value syntax: - position sets reflection below, above, left, or right of the element. - offset sets the distance to the reflection. Distance is set in px, pt, cm, etc. Default value is 0. Read about length units
    static member inline position(value: string) = CombineKeyValue(fun sb -> sb.Append("box-reflect: ").Append(value).Append("; "))
    

    /// Creates a reflection to the right of the element.
    static member inline right = CombineKeyValue(fun sb -> sb.Append("box-reflect: ").Append("right").Append("; "))
    

/// The box-shadow property attaches one or more shadows to an element.
type boxShadow =

    /// Optional. The blur radius. The higher the number, the more blurred the shadow will be
    static member inline blur = CombineKeyValue(fun sb -> sb.Append("box-shadow: ").Append("blur").Append("; "))
    

    /// Optional. The color of the shadow. The default value is the text color. Look at CSS Color Values for a complete list of possible color values. Note: In Safari (on PC) the color parameter is required. If you do not specify the color, the shadow is not displayed at all.
    static member inline color(value: string) = CombineKeyValue(fun sb -> sb.Append("box-shadow: ").Append(value).Append("; "))
    

    /// Required. The horizontal offset of the shadow. A positive value puts the shadow on the right side of the box, a negative value puts the shadow on the left side of the box
    static member inline hOffset = CombineKeyValue(fun sb -> sb.Append("box-shadow: ").Append("h-offset").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("box-shadow: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("box-shadow: ").Append("initial").Append("; "))
    

    /// Optional. Changes the shadow from an outer shadow (outset) to an inner shadow
    static member inline inset = CombineKeyValue(fun sb -> sb.Append("box-shadow: ").Append("inset").Append("; "))
    

    /// Default value. No shadow is displayed
    static member inline none = CombineKeyValue(fun sb -> sb.Append("box-shadow: ").Append("none").Append("; "))
    

    /// Optional. The spread radius. A positive value increases the size of the shadow, a negative value decreases the size of the shadow
    static member inline spread = CombineKeyValue(fun sb -> sb.Append("box-shadow: ").Append("spread").Append("; "))
    

    /// Required. The vertical offset of the shadow. A positive value puts the shadow below the box, a negative value puts the shadow above the box
    static member inline vOffset = CombineKeyValue(fun sb -> sb.Append("box-shadow: ").Append("v-offset").Append("; "))
    

/// The box-sizing property defines how the width and height of an element are calculated: should they include padding and borders, or not.
type boxSizing =

    /// The width and height properties (and min/max properties) includes content, padding and border
    static member inline borderBox = CombineKeyValue(fun sb -> sb.Append("box-sizing: ").Append("border-box").Append("; "))
    

    /// Default. The width and height properties (and min/max properties) includes only the content. Border and padding are not included
    static member inline contentBox = CombineKeyValue(fun sb -> sb.Append("box-sizing: ").Append("content-box").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("box-sizing: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("box-sizing: ").Append("initial").Append("; "))
    

/// The caption-side property specifies the placement of a table caption.
type captionSide =

    /// Puts the caption below the table
    static member inline bottom = CombineKeyValue(fun sb -> sb.Append("caption-side: ").Append("bottom").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("caption-side: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("caption-side: ").Append("initial").Append("; "))
    

    /// Puts the caption above the table. This is default
    static member inline top = CombineKeyValue(fun sb -> sb.Append("caption-side: ").Append("top").Append("; "))
    

/// 
type clear =

    /// The element is pushed below both left and right floated elements
    static member inline both = CombineKeyValue(fun sb -> sb.Append("clear: ").Append("both").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("clear: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("clear: ").Append("initial").Append("; "))
    

    /// The element is pushed below left floated elements
    static member inline left = CombineKeyValue(fun sb -> sb.Append("clear: ").Append("left").Append("; "))
    

    /// Default. The element is not pushed below left or right floated elements
    static member inline none = CombineKeyValue(fun sb -> sb.Append("clear: ").Append("none").Append("; "))
    

    /// The element is pushed below right floated elements
    static member inline right = CombineKeyValue(fun sb -> sb.Append("clear: ").Append("right").Append("; "))
    

/// Note: The clip property is deprecated and is replaced by the clip-path property.
[<RequireQualifiedAccess>]
module clip =

    /// The clip-path property lets you clip an element to a basic shape or to an SVG source.
    type path =

        /// Clips an element to a basic shape: circle, ellipse, polygon or inset
        static member inline basicShape = CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append("basic-shape").Append("; "))
    

        /// Uses the border box as the reference box
        static member inline borderBox = CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append("border-box").Append("; "))
    

        /// Defines a URL to an SVG element
        static member inline clipSource = CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append("clip-source").Append("; "))
    

        /// Uses the content box as the reference box
        static member inline contentBox = CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append("content-box").Append("; "))
    

        /// Uses the object bounding box as reference box
        static member inline fillBox = CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append("fill-box").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append("initial").Append("; "))
    

        /// Uses the margin box as the reference box
        static member inline marginBox = CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append("margin-box").Append("; "))
    

        /// This is default. No clipping is done
        static member inline none = CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append("none").Append("; "))
    

        /// Uses the padding box as the reference box
        static member inline paddingBox = CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append("padding-box").Append("; "))
    

        /// Uses the stroke bounding box as reference box
        static member inline strokeBox = CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append("stroke-box").Append("; "))
    

        /// Uses the SVG viewport as reference box
        static member inline viewBox = CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append("view-box").Append("; "))
    

/// The column-count property specifies the number of columns an element should be divided into.
type columnCount =

    /// Default value. The number of columns will be determined by other properties, like e.g. "column-width"
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("column-count: ").Append("auto").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("column-count: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("column-count: ").Append("initial").Append("; "))
    

    /// The optimal number of columns into which the content of the element will be flowed
    static member inline number(value: float) = CombineKeyValue(fun sb -> sb.Append("column-count: ").Append(value).Append("; "))
    

/// The column-fill property specifies how to fill columns, balanced or not.
type columnFill =

    /// Fills each column until it reaches the height, and do this until it runs out of content (so, this value will not necessarily fill all the columns nor fill them evenly)
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("column-fill: ").Append("auto").Append("; "))
    

    /// Default value. Fills each column with about the same amount of content, but will not allow the columns to be taller than the height (so, columns might be shorter than the height as the browser distributes the content evenly horizontally)
    static member inline balance = CombineKeyValue(fun sb -> sb.Append("column-fill: ").Append("balance").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("column-fill: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("column-fill: ").Append("initial").Append("; "))
    

/// The column-gap property specifies the gap between the columns in grid, flexbox or multi-column layout.
type columnGap =

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("column-gap: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("column-gap: ").Append("initial").Append("; "))
    

    /// A specified length that will set the gap between the columns
    static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("column-gap: ").Append(string value + "px").Append("; "))
    

    /// A specified length that will set the gap between the columns
    static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("column-gap: ").Append(value).Append("; "))
    

    /// Default value. Specifies a normal gap between the columns. W3C suggests a value of 1em
    static member inline normal = CombineKeyValue(fun sb -> sb.Append("column-gap: ").Append("normal").Append("; "))
    

/// The column-rule property sets the width, style, and color of the rule between columns.
[<RequireQualifiedAccess>]
module columnRule =

    /// The column-rule-color property specifies the color of the rule between columns.
    type color =

        /// Specifies the color of the rule. Look at CSS Color Values for a complete list of possible color values
        static member inline color(value: string) = CombineKeyValue(fun sb -> sb.Append("column-rule-color: ").Append(value).Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("column-rule-color: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("column-rule-color: ").Append("initial").Append("; "))
    

    /// The column-rule-style property specifies the style of the rule between columns.
    type style =

        /// Defines a dashed rule
        static member inline dashed = CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append("dashed").Append("; "))
    

        /// Defines a dotted rule
        static member inline dotted = CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append("dotted").Append("; "))
    

        /// Defines a double rule
        static member inline double = CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append("double").Append("; "))
    

        /// Specifies a 3D grooved rule. The effect depends on the width and color values
        static member inline groove = CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append("groove").Append("; "))
    

        /// Defines a hidden rule
        static member inline hidden = CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append("hidden").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append("initial").Append("; "))
    

        /// Specifies a 3D inset rule. The effect depends on the width and color values
        static member inline inset = CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append("inset").Append("; "))
    

        /// Default value. Defines no rule
        static member inline none = CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append("none").Append("; "))
    

        /// Specifies a 3D outset rule. The effect depends on the width and color values
        static member inline outset = CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append("outset").Append("; "))
    

        /// Specifies a 3D ridged rule. The effect depends on the width and color values
        static member inline ridge = CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append("ridge").Append("; "))
    

        /// Defines a solid rule
        static member inline solid = CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append("solid").Append("; "))
    

    /// The column-rule-width property specifies the width of the rule between columns.
    type width =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("column-rule-width: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("column-rule-width: ").Append("initial").Append("; "))
    

        /// Specifies the width of the rule
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("column-rule-width: ").Append(string value + "px").Append("; "))
    

        /// Specifies the width of the rule
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("column-rule-width: ").Append(value).Append("; "))
    

        /// Default value. Defines a medium rule
        static member inline medium = CombineKeyValue(fun sb -> sb.Append("column-rule-width: ").Append("medium").Append("; "))
    

        /// Defines a thick rule
        static member inline thick = CombineKeyValue(fun sb -> sb.Append("column-rule-width: ").Append("thick").Append("; "))
    

        /// Defines a thin rule
        static member inline thin = CombineKeyValue(fun sb -> sb.Append("column-rule-width: ").Append("thin").Append("; "))
    

/// The column-span property specifies how many columns an element should span across.
type columnSpan =

    /// The element should span across all columns
    static member inline all = CombineKeyValue(fun sb -> sb.Append("column-span: ").Append("all").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("column-span: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("column-span: ").Append("initial").Append("; "))
    

    /// Default value. The element should span across one column
    static member inline none = CombineKeyValue(fun sb -> sb.Append("column-span: ").Append("none").Append("; "))
    

/// The column-width property specifies the column width.
type columnWidth =

    /// Default value. The column width will be determined by the browser
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("column-width: ").Append("auto").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("column-width: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("column-width: ").Append("initial").Append("; "))
    

    /// A length that specifies the width of the columns. The number of columns will be the minimum number of columns needed to show all the content across the element. Read about length units
    static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("column-width: ").Append(string value + "px").Append("; "))
    

    /// A length that specifies the width of the columns. The number of columns will be the minimum number of columns needed to show all the content across the element. Read about length units
    static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("column-width: ").Append(value).Append("; "))
    

/// The columns property is a shorthand property for:
type columns =

    /// Default value. Sets both the column-width and column-count to "auto"
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("columns: ").Append("auto").Append("; "))
    

    /// Defines the maximum number of columns
    static member inline columnCount = CombineKeyValue(fun sb -> sb.Append("columns: ").Append("column-count").Append("; "))
    

    /// Defines the minimum width for each column
    static member inline columnWidth = CombineKeyValue(fun sb -> sb.Append("columns: ").Append("column-width").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("columns: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("columns: ").Append("initial").Append("; "))
    

/// The content property is used with the ::before and ::after pseudo-elements, to insert generated content.
type content =

    /// Sets the content as one of the selector's attribute
    static member inline attr(value: string) = CombineKeyValue(fun sb -> sb.Append("content: ").Append($"attr({value})").Append("; "))
    

    /// Sets the content to be a closing quote
    static member inline closeQuote = CombineKeyValue(fun sb -> sb.Append("content: ").Append("close-quote").Append("; "))
    

    /// Sets the content as a counter
    static member inline counter = CombineKeyValue(fun sb -> sb.Append("content: ").Append("counter").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("content: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("content: ").Append("initial").Append("; "))
    

    /// Removes the closing quote from the content, if specified
    static member inline noCloseQuote = CombineKeyValue(fun sb -> sb.Append("content: ").Append("no-close-quote").Append("; "))
    

    /// Removes the opening quote from the content, if specified
    static member inline noOpenQuote = CombineKeyValue(fun sb -> sb.Append("content: ").Append("no-open-quote").Append("; "))
    

    /// Sets the content, if specified, to nothing
    static member inline none = CombineKeyValue(fun sb -> sb.Append("content: ").Append("none").Append("; "))
    

    /// Default value. Sets the content, if specified, to normal, which default is "none" (which is nothing)
    static member inline normal = CombineKeyValue(fun sb -> sb.Append("content: ").Append("normal").Append("; "))
    

    /// Sets the content to be an opening quote
    static member inline openQuote = CombineKeyValue(fun sb -> sb.Append("content: ").Append("open-quote").Append("; "))
    

    /// Sets the content to the text you specify
    static member inline string = CombineKeyValue(fun sb -> sb.Append("content: ").Append("string").Append("; "))
    

    /// Sets the content to be some kind of media (an image, a sound, a video, etc.)
    static member inline url(value: string) = CombineKeyValue(fun sb -> sb.Append("content: ").Append($"url({value})").Append("; "))
    

/// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
type cursor =

    /// A comma separated list of URLs to custom cursors. Note: Always specify a generic cursor at the end of the list, in case none of the URL-defined cursors can be used
    static member inline URL = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("URL").Append("; "))
    

    /// The cursor indicates an alias of something is to be created
    static member inline alias = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("alias").Append("; "))
    

    /// The cursor indicates that something can be scrolled in any direction
    static member inline allScroll = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("all-scroll").Append("; "))
    

    /// Default. The browser sets a cursor
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("auto").Append("; "))
    

    /// The cursor indicates that a cell (or set of cells) may be selected
    static member inline cell = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("cell").Append("; "))
    

    /// The cursor indicates that the column can be resized horizontally
    static member inline colResize = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("col-resize").Append("; "))
    

    /// The cursor indicates that a context-menu is available
    static member inline contextMenu = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("context-menu").Append("; "))
    

    /// The cursor indicates something is to be copied
    static member inline copy = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("copy").Append("; "))
    

    /// The cursor render as a crosshair
    static member inline crosshair = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("crosshair").Append("; "))
    

    /// The default cursor
    static member inline default' = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("default").Append("; "))
    

    /// The cursor indicates that an edge of a box is to be moved right (east)
    static member inline eResize = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("e-resize").Append("; "))
    

    /// Indicates a bidirectional resize cursor
    static member inline ewResize = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("ew-resize").Append("; "))
    

    /// The cursor indicates that something can be grabbed
    static member inline grab = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("grab").Append("; "))
    

    /// The cursor indicates that something can be grabbed
    static member inline grabbing = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("grabbing").Append("; "))
    

    /// The cursor indicates that help is available
    static member inline help = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("help").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("initial").Append("; "))
    

    /// The cursor indicates something is to be moved
    static member inline move = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("move").Append("; "))
    

    /// The cursor indicates that an edge of a box is to be moved up (north)
    static member inline nResize = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("n-resize").Append("; "))
    

    /// The cursor indicates that an edge of a box is to be moved up and right (north/east)
    static member inline neResize = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("ne-resize").Append("; "))
    

    /// Indicates a bidirectional resize cursor
    static member inline neswResize = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("nesw-resize").Append("; "))
    

    /// The cursor indicates that the dragged item cannot be dropped here
    static member inline noDrop = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("no-drop").Append("; "))
    

    /// No cursor is rendered for the element
    static member inline none = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("none").Append("; "))
    

    /// The cursor indicates that the requested action will not be executed
    static member inline notAllowed = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("not-allowed").Append("; "))
    

    /// Indicates a bidirectional resize cursor
    static member inline nsResize = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("ns-resize").Append("; "))
    

    /// The cursor indicates that an edge of a box is to be moved up and left (north/west)
    static member inline nwResize = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("nw-resize").Append("; "))
    

    /// Indicates a bidirectional resize cursor
    static member inline nwseResize = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("nwse-resize").Append("; "))
    

    /// The cursor is a pointer and indicates a link
    static member inline pointer = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("pointer").Append("; "))
    

    /// The cursor indicates that the program is busy (in progress)
    static member inline progress = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("progress").Append("; "))
    

    /// The cursor indicates that the row can be resized vertically
    static member inline rowResize = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("row-resize").Append("; "))
    

    /// The cursor indicates that an edge of a box is to be moved down (south)
    static member inline sResize = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("s-resize").Append("; "))
    

    /// The cursor indicates that an edge of a box is to be moved down and right (south/east)
    static member inline seResize = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("se-resize").Append("; "))
    

    /// The cursor indicates that an edge of a box is to be moved down and left (south/west)
    static member inline swResize = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("sw-resize").Append("; "))
    

    /// The cursor indicates text that may be selected
    static member inline text = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("text").Append("; "))
    

    /// The cursor indicates vertical-text that may be selected
    static member inline verticalText = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("vertical-text").Append("; "))
    

    /// The cursor indicates that an edge of a box is to be moved left (west)
    static member inline wResize = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("w-resize").Append("; "))
    

    /// The cursor indicates that the program is busy
    static member inline wait = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("wait").Append("; "))
    

    /// The cursor indicates that something can be zoomed in
    static member inline zoomIn = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("zoom-in").Append("; "))
    

    /// The cursor indicates that something can be zoomed out
    static member inline zoomOut = CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("zoom-out").Append("; "))
    

/// The direction property specifies the text direction/writing direction within a block-level element.
type direction =

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("direction: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("direction: ").Append("initial").Append("; "))
    

    /// Text direction goes from left-to-right. This is default
    static member inline ltr = CombineKeyValue(fun sb -> sb.Append("direction: ").Append("ltr").Append("; "))
    

    /// Text direction goes from right-to-left
    static member inline rtl = CombineKeyValue(fun sb -> sb.Append("direction: ").Append("rtl").Append("; "))
    

/// The display property specifies the display behavior (the type of rendering box) of an element.
type display =

    /// Displays an element as a block element (like ). It starts on a new line, and takes up the whole width
    static member inline block = CombineKeyValue(fun sb -> sb.Append("display: ").Append("block").Append("; "))
    

    /// Makes the container disappear, making the child elements children of the element the next level up in the DOM
    static member inline contents = CombineKeyValue(fun sb -> sb.Append("display: ").Append("contents").Append("; "))
    

    /// Displays an element as a block-level flex container
    static member inline flex = CombineKeyValue(fun sb -> sb.Append("display: ").Append("flex").Append("; "))
    

    /// Displays an element as a block-level grid container
    static member inline grid = CombineKeyValue(fun sb -> sb.Append("display: ").Append("grid").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("display: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("display: ").Append("initial").Append("; "))
    

    /// Displays an element as an inline element (like ). Any height and width properties will have no effect. This is default.
    static member inline inline' = CombineKeyValue(fun sb -> sb.Append("display: ").Append("inline").Append("; "))
    

    /// Displays an element as an inline-level block container. The element itself is formatted as an inline element, but you can apply height and width values
    static member inline inlineBlock = CombineKeyValue(fun sb -> sb.Append("display: ").Append("inline-block").Append("; "))
    

    /// Displays an element as an inline-level flex container
    static member inline inlineFlex = CombineKeyValue(fun sb -> sb.Append("display: ").Append("inline-flex").Append("; "))
    

    /// Displays an element as an inline-level grid container
    static member inline inlineGrid = CombineKeyValue(fun sb -> sb.Append("display: ").Append("inline-grid").Append("; "))
    

    /// The element is displayed as an inline-level table
    static member inline inlineTable = CombineKeyValue(fun sb -> sb.Append("display: ").Append("inline-table").Append("; "))
    

    /// Let the element behave like a element
    static member inline listItem = CombineKeyValue(fun sb -> sb.Append("display: ").Append("list-item").Append("; "))
    

    /// The element is completely removed
    static member inline none = CombineKeyValue(fun sb -> sb.Append("display: ").Append("none").Append("; "))
    

    /// Displays an element as either block or inline, depending on context
    static member inline runIn = CombineKeyValue(fun sb -> sb.Append("display: ").Append("run-in").Append("; "))
    

    /// Let the element behave like a element
    static member inline table = CombineKeyValue(fun sb -> sb.Append("display: ").Append("table").Append("; "))
    

    /// Let the element behave like a element
    static member inline tableCaption = CombineKeyValue(fun sb -> sb.Append("display: ").Append("table-caption").Append("; "))
    

    /// Let the element behave like a
    static member inline tableCell = CombineKeyValue(fun sb -> sb.Append("display: ").Append("table-cell").Append("; "))
    

    /// Let the element behave like a element
    static member inline tableColumn = CombineKeyValue(fun sb -> sb.Append("display: ").Append("table-column").Append("; "))
    

    /// Let the element behave like a element
    static member inline tableColumnGroup = CombineKeyValue(fun sb -> sb.Append("display: ").Append("table-column-group").Append("; "))
    

    /// Let the element behave like a element
    static member inline tableFooterGroup = CombineKeyValue(fun sb -> sb.Append("display: ").Append("table-footer-group").Append("; "))
    

    /// Let the element behave like a element
    static member inline tableHeaderGroup = CombineKeyValue(fun sb -> sb.Append("display: ").Append("table-header-group").Append("; "))
    

    /// Let the element behave like a
    static member inline tableRow = CombineKeyValue(fun sb -> sb.Append("display: ").Append("table-row").Append("; "))
    

    /// Let the element behave like a element
    static member inline tableRowGroup = CombineKeyValue(fun sb -> sb.Append("display: ").Append("table-row-group").Append("; "))
    

/// The empty-cells property sets whether or not to display borders on empty cells in a table.
type emptyCells =

    /// Hide borders on empty cells
    static member inline hide = CombineKeyValue(fun sb -> sb.Append("empty-cells: ").Append("hide").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("empty-cells: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("empty-cells: ").Append("initial").Append("; "))
    

    /// Display borders on empty cells. This is default
    static member inline show = CombineKeyValue(fun sb -> sb.Append("empty-cells: ").Append("show").Append("; "))
    

/// The flex property is a shorthand property for:
[<RequireQualifiedAccess>]
module flex =

    /// The flex-basis property specifies the initial length of a flexible item.
    type basis =

        /// Default value. The length is equal to the length of the flexible item. If the item has no length specified, the length will be according to its content
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("flex-basis: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("flex-basis: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("flex-basis: ").Append("initial").Append("; "))
    

        /// A length unit, or percentage, specifying the initial length of the flexible item(s)
        static member inline number(value: float) = CombineKeyValue(fun sb -> sb.Append("flex-basis: ").Append(value).Append("; "))
    

    /// The flex-direction property specifies the direction of the flexible items.
    type direction =

        /// The flexible items are displayed vertically, as a column
        static member inline column = CombineKeyValue(fun sb -> sb.Append("flex-direction: ").Append("column").Append("; "))
    

        /// Same as column, but in reverse order
        static member inline columnReverse = CombineKeyValue(fun sb -> sb.Append("flex-direction: ").Append("column-reverse").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("flex-direction: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("flex-direction: ").Append("initial").Append("; "))
    

        /// Default value. The flexible items are displayed horizontally, as a row
        static member inline row = CombineKeyValue(fun sb -> sb.Append("flex-direction: ").Append("row").Append("; "))
    

        /// Same as row, but in reverse order
        static member inline rowReverse = CombineKeyValue(fun sb -> sb.Append("flex-direction: ").Append("row-reverse").Append("; "))
    

    /// The flex-flow property is a shorthand property for:
    type flow =

        /// Possible values: row row-reverse column column-reverse initial inherit Default value is "row".Specifying the direction of the flexible items
        static member inline flexDirection = CombineKeyValue(fun sb -> sb.Append("flex-flow: ").Append("flex-direction").Append("; "))
    

        /// Possible values: nowrap wrap wrap-reverse initial inherit Default value is "nowrap".Specifying whether the flexible items should wrap or not
        static member inline flexWrap = CombineKeyValue(fun sb -> sb.Append("flex-flow: ").Append("flex-wrap").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("flex-flow: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("flex-flow: ").Append("initial").Append("; "))
    

    /// The flex-grow property specifies how much the item will grow relative to the rest of the flexible items inside the same container.
    type grow =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("flex-grow: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("flex-grow: ").Append("initial").Append("; "))
    

        /// A number specifying how much the item will grow relative to the rest of the flexible items. Default value is 0
        static member inline number(value: float) = CombineKeyValue(fun sb -> sb.Append("flex-grow: ").Append(value).Append("; "))
    

    /// The flex-shrink property specifies how the item will shrink relative to the rest of the flexible items inside the same container.
    type shrink =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("flex-shrink: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("flex-shrink: ").Append("initial").Append("; "))
    

        /// A number specifying how much the item will shrink relative to the rest of the flexible items. Default value is 1
        static member inline number(value: float) = CombineKeyValue(fun sb -> sb.Append("flex-shrink: ").Append(value).Append("; "))
    

    /// The flex-wrap property specifies whether the flexible items should wrap or not.
    type wrap =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("flex-wrap: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("flex-wrap: ").Append("initial").Append("; "))
    

        /// Default value. Specifies that the flexible items will not wrap
        static member inline nowrap = CombineKeyValue(fun sb -> sb.Append("flex-wrap: ").Append("nowrap").Append("; "))
    

        /// Specifies that the flexible items will wrap if necessary
        static member inline wrap = CombineKeyValue(fun sb -> sb.Append("flex-wrap: ").Append("wrap").Append("; "))
    

        /// Specifies that the flexible items will wrap, if necessary, in reverse order
        static member inline wrapReverse = CombineKeyValue(fun sb -> sb.Append("flex-wrap: ").Append("wrap-reverse").Append("; "))
    

/// The float property specifies whether an element should float to the left, right, or not at all.
type float' =

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("float: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("float: ").Append("initial").Append("; "))
    

    /// The element floats to the left of its container
    static member inline left = CombineKeyValue(fun sb -> sb.Append("float: ").Append("left").Append("; "))
    

    /// The element does not float, (will be displayed just where it occurs in the text). This is default
    static member inline none = CombineKeyValue(fun sb -> sb.Append("float: ").Append("none").Append("; "))
    

    /// The element floats the right of its container
    static member inline right = CombineKeyValue(fun sb -> sb.Append("float: ").Append("right").Append("; "))
    

/// The font property is a shorthand property for:
[<RequireQualifiedAccess>]
module font =

    /// The font-family property specifies the font for an element.
    type family =

        /// A prioritized list of font family names and/or generic family names
        static member inline familyName(value: string) = CombineKeyValue(fun sb -> sb.Append("font-family: ").Append(value).Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("font-family: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("font-family: ").Append("initial").Append("; "))
    

    /// The font-feature-settings property allows control over advanced typographic features in OpenType fonts.
    type featureSettings =

        /// Format: string [1|0|on|off] Always a string of 4 ASCII characters.
        static member inline featureValue = CombineKeyValue(fun sb -> sb.Append("font-feature-settings: ").Append("feature-value").Append("; "))
    

        /// Default. Use the default settings to lay out text
        static member inline normal = CombineKeyValue(fun sb -> sb.Append("font-feature-settings: ").Append("normal").Append("; "))
    

    /// The font-kerning property controls the usage of the kerning information stored in a font.
    type kerning =

        /// Default. The browser determines whether font kerning should be applied or not
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("font-kerning: ").Append("auto").Append("; "))
    

        /// Specifies that font kerning is not applied
        static member inline none = CombineKeyValue(fun sb -> sb.Append("font-kerning: ").Append("none").Append("; "))
    

        /// Specifies that font kerning is applied
        static member inline normal = CombineKeyValue(fun sb -> sb.Append("font-kerning: ").Append("normal").Append("; "))
    

    /// The font-size property sets the size of a font.
    type size =

        /// Sets the font-size to a percent of the parent element's font size
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("font-size: ").Append(string value + "%").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("font-size: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("font-size: ").Append("initial").Append("; "))
    

        /// Sets the font-size to a large size
        static member inline large = CombineKeyValue(fun sb -> sb.Append("font-size: ").Append("large").Append("; "))
    

        /// Sets the font-size to a larger size than the parent element
        static member inline larger = CombineKeyValue(fun sb -> sb.Append("font-size: ").Append("larger").Append("; "))
    

        /// Sets the font-size to a fixed size in px, cm, etc. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("font-size: ").Append(string value + "px").Append("; "))
    

        /// Sets the font-size to a fixed size in px, cm, etc. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("font-size: ").Append(value).Append("; "))
    

        /// Sets the font-size to a medium size. This is default
        static member inline medium = CombineKeyValue(fun sb -> sb.Append("font-size: ").Append("medium").Append("; "))
    

        /// Sets the font-size to a small size
        static member inline small = CombineKeyValue(fun sb -> sb.Append("font-size: ").Append("small").Append("; "))
    

        /// Sets the font-size to a smaller size than the parent element
        static member inline smaller = CombineKeyValue(fun sb -> sb.Append("font-size: ").Append("smaller").Append("; "))
    

        /// Sets the font-size to an extra large size
        static member inline xLarge = CombineKeyValue(fun sb -> sb.Append("font-size: ").Append("x-large").Append("; "))
    

        /// Sets the font-size to an extra small size
        static member inline xSmall = CombineKeyValue(fun sb -> sb.Append("font-size: ").Append("x-small").Append("; "))
    

        /// Sets the font-size to an xx-large size
        static member inline xxLarge = CombineKeyValue(fun sb -> sb.Append("font-size: ").Append("xx-large").Append("; "))
    

        /// Sets the font-size to an xx-small size
        static member inline xxSmall = CombineKeyValue(fun sb -> sb.Append("font-size: ").Append("xx-small").Append("; "))
    

    /// The font-style property specifies the font style for a text.
    type style =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("font-style: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("font-style: ").Append("initial").Append("; "))
    

        /// The browser displays an italic font style
        static member inline italic = CombineKeyValue(fun sb -> sb.Append("font-style: ").Append("italic").Append("; "))
    

        /// The browser displays a normal font style. This is default
        static member inline normal = CombineKeyValue(fun sb -> sb.Append("font-style: ").Append("normal").Append("; "))
    

        /// The browser displays an oblique font style
        static member inline oblique = CombineKeyValue(fun sb -> sb.Append("font-style: ").Append("oblique").Append("; "))
    

    /// In a small-caps font, all lowercase letters are converted to uppercase letters. However, the converted uppercase letters appears in a smaller font size than the original uppercase letters in the text.
    type variant =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("font-variant: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("font-variant: ").Append("initial").Append("; "))
    

        /// The browser displays a normal font. This is default
        static member inline normal = CombineKeyValue(fun sb -> sb.Append("font-variant: ").Append("normal").Append("; "))
    

        /// The browser displays a small-caps font
        static member inline smallCaps = CombineKeyValue(fun sb -> sb.Append("font-variant: ").Append("small-caps").Append("; "))
    

    /// The font-variant-caps property controls the usage of alternate glyphs for capital letters.
    type variantCaps =

        /// Displays petite capitals for both upper and lowercase letters
        static member inline allPetiteCaps = CombineKeyValue(fun sb -> sb.Append("font-variant-caps: ").Append("all-petite-caps").Append("; "))
    

        /// Displays small capitals for both upper and lowercase letters
        static member inline allSmallCaps = CombineKeyValue(fun sb -> sb.Append("font-variant-caps: ").Append("all-small-caps").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("font-variant-caps: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("font-variant-caps: ").Append("initial").Append("; "))
    

        /// Deactivates the use of alternate glyphs
        static member inline normal = CombineKeyValue(fun sb -> sb.Append("font-variant-caps: ").Append("normal").Append("; "))
    

        /// Displays petite capitals
        static member inline petiteCaps = CombineKeyValue(fun sb -> sb.Append("font-variant-caps: ").Append("petite-caps").Append("; "))
    

        /// Displays small capitals
        static member inline smallCaps = CombineKeyValue(fun sb -> sb.Append("font-variant-caps: ").Append("small-caps").Append("; "))
    

        /// Displays titling capitals
        static member inline titlingCaps = CombineKeyValue(fun sb -> sb.Append("font-variant-caps: ").Append("titling-caps").Append("; "))
    

        /// Displays a mix of small capitals for uppercase letters with normal lowercase letters
        static member inline unicase = CombineKeyValue(fun sb -> sb.Append("font-variant-caps: ").Append("unicase").Append("; "))
    

        /// 
        static member inline unset = CombineKeyValue(fun sb -> sb.Append("font-variant-caps: ").Append("unset").Append("; "))
    

    /// The font-weight property sets how thick or thin characters in text should be displayed.
    type weight =

        /// Defines from thin to thick characters. 400 is the same as normal, and 700 is the same as bold
        static member inline value(value: string) = CombineKeyValue(fun sb -> sb.Append("font-weight: ").Append(value).Append("; "))
    

        /// Defines thick characters
        static member inline bold = CombineKeyValue(fun sb -> sb.Append("font-weight: ").Append("bold").Append("; "))
    

        /// Defines thicker characters
        static member inline bolder = CombineKeyValue(fun sb -> sb.Append("font-weight: ").Append("bolder").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("font-weight: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("font-weight: ").Append("initial").Append("; "))
    

        /// Defines lighter characters
        static member inline lighter = CombineKeyValue(fun sb -> sb.Append("font-weight: ").Append("lighter").Append("; "))
    

        /// Defines normal characters. This is default
        static member inline normal = CombineKeyValue(fun sb -> sb.Append("font-weight: ").Append("normal").Append("; "))
    

/// The grid property is a shorthand property for:
[<RequireQualifiedAccess>]
module grid =

    /// The grid-area property specifies a grid item's size and location in a grid layout, and is a shorthand property for the following properties:
    type area =

        /// Specifies on which column-line to stop displaying the item, or how many columns to span.
        static member inline gridColumnEnd = CombineKeyValue(fun sb -> sb.Append("grid-area: ").Append("grid-column-end").Append("; "))
    

        /// Specifies on which column to start displaying the item.
        static member inline gridColumnStart = CombineKeyValue(fun sb -> sb.Append("grid-area: ").Append("grid-column-start").Append("; "))
    

        /// Specifies on which row-line to stop displaying the item, or how many rows to span.
        static member inline gridRowEnd = CombineKeyValue(fun sb -> sb.Append("grid-area: ").Append("grid-row-end").Append("; "))
    

        /// Specifies on which row to start displaying the item.
        static member inline gridRowStart = CombineKeyValue(fun sb -> sb.Append("grid-area: ").Append("grid-row-start").Append("; "))
    

        /// Specifies a name for the grid item
        static member inline itemname = CombineKeyValue(fun sb -> sb.Append("grid-area: ").Append("itemname").Append("; "))
    

    /// The grid-auto-columns property sets a size for the columns in a grid container.
    type autoColumns =

        /// Sets the size of the columns, by using a percent value
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("grid-auto-columns: ").Append(string value + "%").Append("; "))
    

        /// Default value. The size of the columns is determined by the size of the container
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("grid-auto-columns: ").Append("auto").Append("; "))
    

        /// 
        static member inline fitContent(value: string) = CombineKeyValue(fun sb -> sb.Append("grid-auto-columns: ").Append($"fit-content({value})").Append("; "))
    

        /// Sets the size of the columns, by using a legal length value. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("grid-auto-columns: ").Append(string value + "px").Append("; "))
    

        /// Sets the size of the columns, by using a legal length value. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("grid-auto-columns: ").Append(value).Append("; "))
    

        /// Sets the size of each column depending on the largest item in the column
        static member inline maxContent = CombineKeyValue(fun sb -> sb.Append("grid-auto-columns: ").Append("max-content").Append("; "))
    

        /// Sets the size of each column depending on the smallest item in the column
        static member inline minContent = CombineKeyValue(fun sb -> sb.Append("grid-auto-columns: ").Append("min-content").Append("; "))
    

        /// Sets a size range greater than or equal to min and less than or equal to max
        static member inline minmax(value: string) = CombineKeyValue(fun sb -> sb.Append("grid-auto-columns: ").Append($"minmax({value})").Append("; "))
    

    /// The grid-auto-flow property controls how auto-placed items get inserted in the grid.
    type autoFlow =

        /// Places items by filling each column
        static member inline column' = CombineKeyValue(fun sb -> sb.Append("grid-auto-flow: ").Append("column").Append("; "))
    

        /// Places items by filling each column, and fill any holes in the grid
        static member inline column(value: string) = CombineKeyValue(fun sb -> sb.Append("grid-auto-flow: ").Append(value).Append("; "))
    

        /// Place items to fill any holes in the grid
        static member inline dense = CombineKeyValue(fun sb -> sb.Append("grid-auto-flow: ").Append("dense").Append("; "))
    

        /// Default value. Places items by filling each row
        static member inline row' = CombineKeyValue(fun sb -> sb.Append("grid-auto-flow: ").Append("row").Append("; "))
    

        /// Places items by filling each row, and fill any holes in the grid
        static member inline row(value: string) = CombineKeyValue(fun sb -> sb.Append("grid-auto-flow: ").Append(value).Append("; "))
    

    /// The grid-auto-rows property sets a size for the rows in a grid container.
    type autoRows =

        /// Default value. The size of the rows is determined by the size of the largest item in the row
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("grid-auto-rows: ").Append("auto").Append("; "))
    

        /// Sets the size of the rows, by using a legal length value. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("grid-auto-rows: ").Append(string value + "px").Append("; "))
    

        /// Sets the size of the rows, by using a legal length value. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("grid-auto-rows: ").Append(value).Append("; "))
    

        /// Sets the size of each row to depend on the largest item in the row
        static member inline maxContent = CombineKeyValue(fun sb -> sb.Append("grid-auto-rows: ").Append("max-content").Append("; "))
    

        /// Sets the size of each row to depend on the smallest item in the row
        static member inline minContent = CombineKeyValue(fun sb -> sb.Append("grid-auto-rows: ").Append("min-content").Append("; "))
    

    /// The grid-column property specifies a grid item's size and location in a grid layout, and is a shorthand property for the following properties:
    type column =

        /// Specifies on which column-line to stop displaying the item, or how many columns to span.
        static member inline gridColumnEnd = CombineKeyValue(fun sb -> sb.Append("grid-column: ").Append("grid-column-end").Append("; "))
    

        /// Specifies on which column to start displaying the item.
        static member inline gridColumnStart = CombineKeyValue(fun sb -> sb.Append("grid-column: ").Append("grid-column-start").Append("; "))
    

    /// The grid-column-end property defines how many columns an item will span, or on which column-line the item will end (see example at the end of this page).
    type columnEnd =

        /// Default value. The item will span one column
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("grid-column-end: ").Append("auto").Append("; "))
    

        /// Specifies on which column to end the display of the item
        static member inline columnLine = CombineKeyValue(fun sb -> sb.Append("grid-column-end: ").Append("column-line").Append("; "))
    

        /// Specifies the number of columns the item will span
        static member inline span(value: string) = CombineKeyValue(fun sb -> sb.Append("grid-column-end: ").Append(value).Append("; "))
    

    /// The grid-column-gap property defines the size of the gap between the columns in a grid layout.
    type columnGap =

        /// Any legal length value, like px or %. 0 is the default value. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("grid-column-gap: ").Append(string value + "px").Append("; "))
    

        /// Any legal length value, like px or %. 0 is the default value. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("grid-column-gap: ").Append(value).Append("; "))
    

    /// The grid-column-start property defines on which column-line the item will start.
    type columnStart =

        /// Default value. The item will be placed following the flow
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("grid-column-start: ").Append("auto").Append("; "))
    

        /// Specifies on which column to start the display of the item
        static member inline columnLine = CombineKeyValue(fun sb -> sb.Append("grid-column-start: ").Append("column-line").Append("; "))
    

        /// Specifies the number of columns the item will span
        static member inline span(value: string) = CombineKeyValue(fun sb -> sb.Append("grid-column-start: ").Append(value).Append("; "))
    

    /// The grid-gap property defines the size of the gap between the rows and columns in a grid layout, and is a shorthand property for the following properties:
    type gap =

        /// Sets the size of the gap between the columns in a grid layout. 0 is the default value
        static member inline gridColumnGap = CombineKeyValue(fun sb -> sb.Append("grid-gap: ").Append("grid-column-gap").Append("; "))
    

        /// Sets the size of the gap between the rows in a grid layout. 0 is the default value
        static member inline gridRowGap = CombineKeyValue(fun sb -> sb.Append("grid-gap: ").Append("grid-row-gap").Append("; "))
    

    /// The grid-row property specifies a grid item's size and location in a grid layout, and is a shorthand property for the following properties:
    type row =

        /// Specifies on which row-line to stop displaying the item, or how many rows to span.
        static member inline gridRowEnd = CombineKeyValue(fun sb -> sb.Append("grid-row: ").Append("grid-row-end").Append("; "))
    

        /// Specifies on which row to start displaying the item.
        static member inline gridRowStart = CombineKeyValue(fun sb -> sb.Append("grid-row: ").Append("grid-row-start").Append("; "))
    

    /// The grid-row-end property defines how many rows an item will span, or on which row-line the item will end (see example at the end of this page).
    type rowEnd =

        /// Default value. The item will span one row.
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("grid-row-end: ").Append("auto").Append("; "))
    

        /// Specifies on which row to end the display of the item.
        static member inline rowLine = CombineKeyValue(fun sb -> sb.Append("grid-row-end: ").Append("row-line").Append("; "))
    

        /// Specifies the number of rows the item will span.
        static member inline span(value: string) = CombineKeyValue(fun sb -> sb.Append("grid-row-end: ").Append(value).Append("; "))
    

    /// The grid-row-gap property defines the size of the gap between the rows in a grid layout.
    type rowGap =

        /// Any legal length value, like px or %. 0 is the default value
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("grid-row-gap: ").Append(string value + "px").Append("; "))
    

        /// Any legal length value, like px or %. 0 is the default value
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("grid-row-gap: ").Append(value).Append("; "))
    

    /// The grid-row-start property defines on which row-line the item will start.
    type rowStart =

        /// Default value. The item will be placed by following the flow.
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("grid-row-start: ").Append("auto").Append("; "))
    

        /// Specifies on which row to start the display of the item.
        static member inline rowLine = CombineKeyValue(fun sb -> sb.Append("grid-row-start: ").Append("row-line").Append("; "))
    

    /// The grid-template property is a shorthand property for the following properties:
    type template =

        /// Specifies the size(s) of the columns and rows
        static member inline gridTemplate(value: string) = CombineKeyValue(fun sb -> sb.Append("grid-template: ").Append(value).Append("; "))
    

        /// Specifies the grid layout using named items
        static member inline gridTemplateAreas = CombineKeyValue(fun sb -> sb.Append("grid-template: ").Append("grid-template-areas").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("grid-template: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("grid-template: ").Append("initial").Append("; "))
    

        /// Default value. No specific sizing of the columns or rows
        static member inline none = CombineKeyValue(fun sb -> sb.Append("grid-template: ").Append("none").Append("; "))
    

    /// The grid-template-areas property specifies areas within the grid layout.
    type templateAreas =

        /// A sequence that specifies how each columns and row should display
        static member inline itemnames = CombineKeyValue(fun sb -> sb.Append("grid-template-areas: ").Append("itemnames").Append("; "))
    

        /// Default value. No named grid areas
        static member inline none = CombineKeyValue(fun sb -> sb.Append("grid-template-areas: ").Append("none").Append("; "))
    

    /// The grid-template-columns property specifies the number (and the widths) of columns in a grid layout.
    type templateColumns =

        /// The size of the columns is determined by the size of the container and on the size of the content of the items in the column
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("grid-template-columns: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("grid-template-columns: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("grid-template-columns: ").Append("initial").Append("; "))
    

        /// Sets the size of the columns, by using a legal length value. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("grid-template-columns: ").Append(string value + "px").Append("; "))
    

        /// Sets the size of the columns, by using a legal length value. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("grid-template-columns: ").Append(value).Append("; "))
    

        /// Sets the size of each column to depend on the largest item in the column
        static member inline maxContent = CombineKeyValue(fun sb -> sb.Append("grid-template-columns: ").Append("max-content").Append("; "))
    

        /// Sets the size of each column to depend on the smallest item in the column
        static member inline minContent = CombineKeyValue(fun sb -> sb.Append("grid-template-columns: ").Append("min-content").Append("; "))
    

        /// Default value. Columns are created if needed
        static member inline none = CombineKeyValue(fun sb -> sb.Append("grid-template-columns: ").Append("none").Append("; "))
    

    /// The grid-template-rows property specifies the number (and the heights) of the rows in a grid layout.
    type templateRows =

        /// The size of the rows is determined by the size of the container, and on the size of the content of the items in the row
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("grid-template-rows: ").Append("auto").Append("; "))
    

        /// Sets the size of the rows, by using a legal length value. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("grid-template-rows: ").Append(string value + "px").Append("; "))
    

        /// Sets the size of the rows, by using a legal length value. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("grid-template-rows: ").Append(value).Append("; "))
    

        /// Sets the size of each row to depend on the largest item in the row
        static member inline maxContent = CombineKeyValue(fun sb -> sb.Append("grid-template-rows: ").Append("max-content").Append("; "))
    

        /// Sets the size of each row to depend on the smallest item in the row
        static member inline minContent = CombineKeyValue(fun sb -> sb.Append("grid-template-rows: ").Append("min-content").Append("; "))
    

        /// No size is set. Rows are created if needed
        static member inline none = CombineKeyValue(fun sb -> sb.Append("grid-template-rows: ").Append("none").Append("; "))
    

/// The hyphenate-character property defines the character used at the end of line, before a hyphenation break.
type hyphenateCharacter =

    /// Default. The browser selects an appropriate character based on the current typographic conventions
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("hyphenate-character: ").Append("auto").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("hyphenate-character: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("hyphenate-character: ").Append("initial").Append("; "))
    

    /// The character used at the end of line, before a hyphenation break
    static member inline string = CombineKeyValue(fun sb -> sb.Append("hyphenate-character: ").Append("string").Append("; "))
    

/// The hyphens property defines whether hyphenation is allowed to create more soft wrap opportunities within a line of text.
type hyphens =

    /// Words are hyphenated where the algorithm is deciding (if needed)
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("hyphens: ").Append("auto").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("hyphens: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("hyphens: ").Append("initial").Append("; "))
    

    /// Default. Words are only hyphenated at ‐ or ­ (if needed)
    static member inline manual = CombineKeyValue(fun sb -> sb.Append("hyphens: ").Append("manual").Append("; "))
    

    /// Words are not hyphenated
    static member inline none = CombineKeyValue(fun sb -> sb.Append("hyphens: ").Append("none").Append("; "))
    

/// The image-rendering property specifies the type of algorithm to be used for image scaling.
type imageRendering =

    /// Let the browser choose the scaling algorithm. This is default
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("image-rendering: ").Append("auto").Append("; "))
    

    /// Use an algorithm that will preserve the contrast and edges in the image
    static member inline crispEdges = CombineKeyValue(fun sb -> sb.Append("image-rendering: ").Append("crisp-edges").Append("; "))
    

    /// Same as smooth, but with a preference for higher-quality scaling
    static member inline highQuality = CombineKeyValue(fun sb -> sb.Append("image-rendering: ").Append("high-quality").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("image-rendering: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("image-rendering: ").Append("initial").Append("; "))
    

    /// If the image is scaled up, the nearest-neighbor algorithm is used, so the image will appear as being composed of large pixels. If the image is scaled down, it will be the same as auto
    static member inline pixelated = CombineKeyValue(fun sb -> sb.Append("image-rendering: ").Append("pixelated").Append("; "))
    

    /// Use an algorithm that smooth out the colors in the image
    static member inline smooth = CombineKeyValue(fun sb -> sb.Append("image-rendering: ").Append("smooth").Append("; "))
    

/// The inline-size property specifies the size of an element in the inline direction.
type inlineSize =

    /// Specifies the inline-size in percent relative to size of parent element on the corresponding axis.
    static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("inline-size: ").Append(string value + "%").Append("; "))
    

    /// Default. The element's default inline-size value.
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("inline-size: ").Append("auto").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("inline-size: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("inline-size: ").Append("initial").Append("; "))
    

    /// Specifies the inline-size in px, pt, cm, etc. Negative values are allowed. Read about length units
    static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("inline-size: ").Append(string value + "px").Append("; "))
    

    /// Specifies the inline-size in px, pt, cm, etc. Negative values are allowed. Read about length units
    static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("inline-size: ").Append(value).Append("; "))
    

/// The inset property sets the distance between an element and the parent element.
[<RequireQualifiedAccess>]
module inset =

    /// The inset-block property sets the distance between an element and the parent element in the block direction.
    type block =

        /// Specifies distance in percent relative to size of parent element on the corresponding axis.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("inset-block: ").Append(string value + "%").Append("; "))
    

        /// Default. The element's default inset-block value.
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("inset-block: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("inset-block: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("inset-block: ").Append("initial").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("inset-block: ").Append(string value + "px").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("inset-block: ").Append(value).Append("; "))
    

    /// The inset-block-end property sets the distance between the end of an element and the parent element in the block direction.
    type blockEnd =

        /// Specifies distance in percent relative to size of parent element on the corresponding axis.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("inset-block-end: ").Append(string value + "%").Append("; "))
    

        /// Default. The element's default inset distance.
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("inset-block-end: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("inset-block-end: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("inset-block-end: ").Append("initial").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("inset-block-end: ").Append(string value + "px").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("inset-block-end: ").Append(value).Append("; "))
    

    /// The inset-block-start property sets the distance between the start of an element and the parent element in the block direction.
    type blockStart =

        /// Specifies distance in percent relative to size of parent element on the corresponding axis.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("inset-block-start: ").Append(string value + "%").Append("; "))
    

        /// Default. The element's default inset distance.
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("inset-block-start: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("inset-block-start: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("inset-block-start: ").Append("initial").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("inset-block-start: ").Append(string value + "px").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("inset-block-start: ").Append(value).Append("; "))
    

    /// The inset-inline property sets the distance between an element and the parent element in the inline direction.
    type inline' =

        /// Specifies distance in percent relative to size of parent element on the corresponding axis.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("inset-inline: ").Append(string value + "%").Append("; "))
    

        /// Default. The element's default inset-inline distance.
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("inset-inline: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("inset-inline: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("inset-inline: ").Append("initial").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("inset-inline: ").Append(string value + "px").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("inset-inline: ").Append(value).Append("; "))
    

    /// The inset-inline-end property sets the distance between the end of an element and the parent element in the inline direction.
    type inlineEnd =

        /// Specifies distance in percent relative to size of parent element on the corresponding axis.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("inset-inline-end: ").Append(string value + "%").Append("; "))
    

        /// Default. The element's default inset distance.
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("inset-inline-end: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("inset-inline-end: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("inset-inline-end: ").Append("initial").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("inset-inline-end: ").Append(string value + "px").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("inset-inline-end: ").Append(value).Append("; "))
    

    /// The inset-inline-start property sets the distance between the start of an element and the parent element in the inline direction.
    type inlineStart =

        /// Specifies distance in percent relative to size of parent element on the corresponding axis.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("inset-inline-start: ").Append(string value + "%").Append("; "))
    

        /// Default. The element's default inset distance.
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("inset-inline-start: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("inset-inline-start: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("inset-inline-start: ").Append("initial").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("inset-inline-start: ").Append(string value + "px").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("inset-inline-start: ").Append(value).Append("; "))
    

/// The justify-content property aligns the flexible container's items when the items do not use all available space on the main-axis (horizontally).
type justifyContent =

    /// Items are positioned in the center of the container
    static member inline center = CombineKeyValue(fun sb -> sb.Append("justify-content: ").Append("center").Append("; "))
    

    /// Items are positioned at the end of the container
    static member inline flexEnd = CombineKeyValue(fun sb -> sb.Append("justify-content: ").Append("flex-end").Append("; "))
    

    /// Default value. Items are positioned at the beginning of the container
    static member inline flexStart = CombineKeyValue(fun sb -> sb.Append("justify-content: ").Append("flex-start").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("justify-content: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("justify-content: ").Append("initial").Append("; "))
    

    /// Items will have space before, between, and after them
    static member inline spaceAround = CombineKeyValue(fun sb -> sb.Append("justify-content: ").Append("space-around").Append("; "))
    

    /// Items will have space between them
    static member inline spaceBetween = CombineKeyValue(fun sb -> sb.Append("justify-content: ").Append("space-between").Append("; "))
    

    /// Items will have equal space around them
    static member inline spaceEvenly = CombineKeyValue(fun sb -> sb.Append("justify-content: ").Append("space-evenly").Append("; "))
    

/// The justify-items property is set on the grid container to give child elements (grid items) alignment in the inline direction.
type justifyItems =

    /// The element is aligned with the baseline of the parent.
    static member inline baseline(value: string) = CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append(value).Append("; "))
    

    /// Align items to the center
    static member inline center = CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append("center").Append("; "))
    

    /// Align items at the end in the inline direction
    static member inline end' = CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append("end").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append("initial").Append("; "))
    

    /// Align items to the left
    static member inline left = CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append("left").Append("; "))
    

    /// Default value. Grid items with justify-self value 'auto' only inherits grid container justify-items property value if it starts with 'legacy'. It exists to implement the legacy alignment behavior of HTML's 〈center〉 element and align attribute.
    static member inline legacy = CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append("legacy").Append("; "))
    

    /// Dependant on layout context, but similar to 'stretch' for grid layout
    static member inline normal = CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append("normal").Append("; "))
    

    /// 'safe' sets alignment of the item to 'start' if the content overflows'unsafe' keeps the alignment value regardless of wether or not the item content overflows
    static member inline overflowAlignment = CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append("overflow-alignment").Append("; "))
    

    /// Align items to the right
    static member inline right = CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append("right").Append("; "))
    

    /// Align items at the start in the inline direction
    static member inline start = CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append("start").Append("; "))
    

    /// Stretches to fill the grid cell if inline-size (width) is not set.
    static member inline stretch = CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append("stretch").Append("; "))
    

/// The justify-self property aligns a grid item within its grid cell in the inline direction.
type justifySelf =

    /// Default value. Grid container justify-self property value is inherited.
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append("auto").Append("; "))
    

    /// The element is aligned with the baseline of the parent.
    static member inline baseline(value: string) = CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append(value).Append("; "))
    

    /// Align items to the center
    static member inline center = CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append("center").Append("; "))
    

    /// Align items at the end in the inline direction
    static member inline end' = CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append("end").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append("initial").Append("; "))
    

    /// Align items to the left
    static member inline left = CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append("left").Append("; "))
    

    /// Dependant on layout context, but similar to 'stretch' for grid layout for grid items when size is not set. If size is set, the property value behaves lik 'start'.
    static member inline normal = CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append("normal").Append("; "))
    

    /// 'safe' sets alignment of the item to 'start' if the content overflows'unsafe' keeps the alignment value regardless of wether or not the item content overflows
    static member inline overflowAlignment = CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append("overflow-alignment").Append("; "))
    

    /// Align items to the right
    static member inline right = CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append("right").Append("; "))
    

    /// Align items at the start in the inline direction
    static member inline start = CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append("start").Append("; "))
    

    /// Stretches to fill the grid cell if inline-size (width) is not set.
    static member inline stretch = CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append("stretch").Append("; "))
    

/// 
type letterSpacing =

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("letter-spacing: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("letter-spacing: ").Append("initial").Append("; "))
    

    /// Defines a length that is used as the space between characters (negative values are also allowed). Read about length units
    static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("letter-spacing: ").Append(string value + "px").Append("; "))
    

    /// Defines a length that is used as the space between characters (negative values are also allowed). Read about length units
    static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("letter-spacing: ").Append(value).Append("; "))
    

    /// Defines normal space between characters. This is default
    static member inline normal = CombineKeyValue(fun sb -> sb.Append("letter-spacing: ").Append("normal").Append("; "))
    

/// The line-height property specifies the height of a line.
type lineHeight =

    /// A line height in percent of the current font size
    static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("line-height: ").Append(string value + "%").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("line-height: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("line-height: ").Append("initial").Append("; "))
    

    /// A fixed line height in px, pt, cm, etc.
    static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("line-height: ").Append(string value + "px").Append("; "))
    

    /// A fixed line height in px, pt, cm, etc.
    static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("line-height: ").Append(value).Append("; "))
    

    /// A normal line height. This is default
    static member inline normal = CombineKeyValue(fun sb -> sb.Append("line-height: ").Append("normal").Append("; "))
    

    /// A number that will be multiplied with the current font-size to set the line height
    static member inline number(value: float) = CombineKeyValue(fun sb -> sb.Append("line-height: ").Append(value).Append("; "))
    

/// The list-style property is a shorthand for the following properties:
[<RequireQualifiedAccess>]
module listStyle =

    /// The list-style-image property replaces the list-item marker with an image.
    type image =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("list-style-image: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("list-style-image: ").Append("initial").Append("; "))
    

        /// No image will be displayed. Instead, the list-style-type property will define what type of list marker will be rendered. This is default
        static member inline none = CombineKeyValue(fun sb -> sb.Append("list-style-image: ").Append("none").Append("; "))
    

        /// The path to the image to be used as a list-item marker
        static member inline url = CombineKeyValue(fun sb -> sb.Append("list-style-image: ").Append("url").Append("; "))
    

    /// The list-style-position property specifies the position of the list-item markers (bullet points).
    type position =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("list-style-position: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("list-style-position: ").Append("initial").Append("; "))
    

        /// The bullet points will be inside the list item
        static member inline inside = CombineKeyValue(fun sb -> sb.Append("list-style-position: ").Append("inside").Append("; "))
    

        /// The bullet points will be outside the list item. This is default
        static member inline outside = CombineKeyValue(fun sb -> sb.Append("list-style-position: ").Append("outside").Append("; "))
    

    /// The list-style-type specifies the type of list-item marker in a list.
    type type' =

        /// The marker is traditional Armenian numbering
        static member inline armenian = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("armenian").Append("; "))
    

        /// The marker is a circle
        static member inline circle = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("circle").Append("; "))
    

        /// The marker is plain ideographic numbers
        static member inline cjkIdeographic = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("cjk-ideographic").Append("; "))
    

        /// The marker is a number
        static member inline decimal = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("decimal").Append("; "))
    

        /// The marker is a number with leading zeros (01, 02, 03, etc.)
        static member inline decimalLeadingZero = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("decimal-leading-zero").Append("; "))
    

        /// Default value. The marker is a filled circle
        static member inline disc = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("disc").Append("; "))
    

        /// The marker is traditional Georgian numbering
        static member inline georgian = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("georgian").Append("; "))
    

        /// The marker is traditional Hebrew numbering
        static member inline hebrew = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("hebrew").Append("; "))
    

        /// The marker is traditional Hiragana numbering
        static member inline hiragana = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("hiragana").Append("; "))
    

        /// The marker is traditional Hiragana iroha numbering
        static member inline hiraganaIroha = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("hiragana-iroha").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("initial").Append("; "))
    

        /// The marker is traditional Katakana numbering
        static member inline katakana = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("katakana").Append("; "))
    

        /// The marker is traditional Katakana iroha numbering
        static member inline katakanaIroha = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("katakana-iroha").Append("; "))
    

        /// The marker is lower-alpha (a, b, c, d, e, etc.)
        static member inline lowerAlpha = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("lower-alpha").Append("; "))
    

        /// The marker is lower-greek
        static member inline lowerGreek = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("lower-greek").Append("; "))
    

        /// The marker is lower-latin (a, b, c, d, e, etc.)
        static member inline lowerLatin = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("lower-latin").Append("; "))
    

        /// The marker is lower-roman (i, ii, iii, iv, v, etc.)
        static member inline lowerRoman = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("lower-roman").Append("; "))
    

        /// No marker is shown
        static member inline none = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("none").Append("; "))
    

        /// The marker is a square
        static member inline square = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("square").Append("; "))
    

        /// The marker is upper-alpha (A, B, C, D, E, etc.)
        static member inline upperAlpha = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("upper-alpha").Append("; "))
    

        /// The marker is upper-greek
        static member inline upperGreek = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("upper-greek").Append("; "))
    

        /// The marker is upper-latin (A, B, C, D, E, etc.)
        static member inline upperLatin = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("upper-latin").Append("; "))
    

        /// The marker is upper-roman (I, II, III, IV, V, etc.)
        static member inline upperRoman = CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("upper-roman").Append("; "))
    

/// The margin property sets the margins for an element, and is a shorthand property for the following properties:
[<RequireQualifiedAccess>]
module margin =

    /// The margin-block property specifies the margin at the start and end in the block direction, and is a shorthand property for the following properties:
    type block =

        /// Specifies margin-block in percent relative to size of parent element in the inline direction.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("margin-block: ").Append(string value + "%").Append("; "))
    

        /// Default. The element's default margin-block value.
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("margin-block: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("margin-block: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("margin-block: ").Append("initial").Append("; "))
    

        /// Specifies margin-block in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("margin-block: ").Append(string value + "px").Append("; "))
    

        /// Specifies margin-block in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("margin-block: ").Append(value).Append("; "))
    

    /// The margin-block-end property specifies the margin at the end in the block direction.
    type blockEnd =

        /// Specifies distance in percent relative to size of parent element in the inline direction.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("margin-block-end: ").Append(string value + "%").Append("; "))
    

        /// Default. The element's default margin.
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("margin-block-end: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("margin-block-end: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("margin-block-end: ").Append("initial").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("margin-block-end: ").Append(string value + "px").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("margin-block-end: ").Append(value).Append("; "))
    

    /// The margin-block-start property specifies the margin at the start in the block direction.
    type blockStart =

        /// Specifies distance in percent relative to size of parent element in the inline direction.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("margin-block-start: ").Append(string value + "%").Append("; "))
    

        /// Default. The element's default margin distance.
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("margin-block-start: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("margin-block-start: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("margin-block-start: ").Append("initial").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("margin-block-start: ").Append(string value + "px").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("margin-block-start: ").Append(value).Append("; "))
    

    /// The margin-bottom property sets the bottom margin of an element.
    type bottom =

        /// Specifies a bottom margin in percent of the width of the containing element
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("margin-bottom: ").Append(string value + "%").Append("; "))
    

        /// The browser calculates a bottom margin
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("margin-bottom: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("margin-bottom: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("margin-bottom: ").Append("initial").Append("; "))
    

        /// Specifies a fixed bottom margin in px, cm, em, etc. Default value is 0. Negative values are allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("margin-bottom: ").Append(string value + "px").Append("; "))
    

        /// Specifies a fixed bottom margin in px, cm, em, etc. Default value is 0. Negative values are allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("margin-bottom: ").Append(value).Append("; "))
    

    /// The margin-inline property specifies the margin at the start and end in the inline direction, and is a shorthand property for the following properties:
    type inline' =

        /// Specifies margin-inline in percent relative to size of parent element in the inline direction.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("margin-inline: ").Append(string value + "%").Append("; "))
    

        /// Default. The element's default margin-inline value.
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("margin-inline: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("margin-inline: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("margin-inline: ").Append("initial").Append("; "))
    

        /// Specifies margin-inline in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("margin-inline: ").Append(string value + "px").Append("; "))
    

        /// Specifies margin-inline in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("margin-inline: ").Append(value).Append("; "))
    

    /// The margin-inline-end property specifies the margin at the end in the inline direction.
    type inlineEnd =

        /// Specifies margin-inline-end in percent relative to size of parent element in the inline direction.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("margin-inline-end: ").Append(string value + "%").Append("; "))
    

        /// Default. The element's default margin-inline-end value.
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("margin-inline-end: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("margin-inline-end: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("margin-inline-end: ").Append("initial").Append("; "))
    

        /// Specifies margin-inline-end in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("margin-inline-end: ").Append(string value + "px").Append("; "))
    

        /// Specifies margin-inline-end in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("margin-inline-end: ").Append(value).Append("; "))
    

    /// The margin-inline-start property specifies the margin at the start in the inline direction.
    type inlineStart =

        /// Specifies margin-inline-start in percent relative to size of parent element in the inline direction.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("margin-inline-start: ").Append(string value + "%").Append("; "))
    

        /// Default. The element's default margin-inline-start value.
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("margin-inline-start: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("margin-inline-start: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("margin-inline-start: ").Append("initial").Append("; "))
    

        /// Specifies margin-inline-start in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("margin-inline-start: ").Append(string value + "px").Append("; "))
    

        /// Specifies margin-inline-start in px, pt, cm, etc. Negative values are allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("margin-inline-start: ").Append(value).Append("; "))
    

    /// The margin-left property sets the left margin of an element.
    type left =

        /// Specifies a left margin in percent of the width of the containing element
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("margin-left: ").Append(string value + "%").Append("; "))
    

        /// The browser calculates a left margin
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("margin-left: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("margin-left: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("margin-left: ").Append("initial").Append("; "))
    

        /// Specifies a fixed left margin in px, pt, cm, etc. Default value is 0px. Negative values are allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("margin-left: ").Append(string value + "px").Append("; "))
    

        /// Specifies a fixed left margin in px, pt, cm, etc. Default value is 0px. Negative values are allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("margin-left: ").Append(value).Append("; "))
    

    /// The margin-right property sets the right margin of an element.
    type right =

        /// Specifies a right margin in percent of the width of the containing element
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("margin-right: ").Append(string value + "%").Append("; "))
    

        /// The browser calculates a right margin
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("margin-right: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("margin-right: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("margin-right: ").Append("initial").Append("; "))
    

        /// Specifies a fixed right margin in px, pt, cm, etc. Default value is 0px. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("margin-right: ").Append(string value + "px").Append("; "))
    

        /// Specifies a fixed right margin in px, pt, cm, etc. Default value is 0px. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("margin-right: ").Append(value).Append("; "))
    

    /// The margin-top property sets the top margin of an element.
    type top =

        /// Specifies a top margin in percent of the width of the containing element
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("margin-top: ").Append(string value + "%").Append("; "))
    

        /// The browser calculates a top margin
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("margin-top: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("margin-top: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("margin-top: ").Append("initial").Append("; "))
    

        /// Specifies a fixed top margin in px, pt, cm, etc. Default value is 0px. Negative values are allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("margin-top: ").Append(string value + "px").Append("; "))
    

        /// Specifies a fixed top margin in px, pt, cm, etc. Default value is 0px. Negative values are allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("margin-top: ").Append(value).Append("; "))
    

/// The max-block-size property specifies the maximum size of an element in the block direction.
type maxBlockSize =

    /// Specifies max-block-size in percent relative to size of parent element on the corresponding axis.
    static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("max-block-size: ").Append(string value + "%").Append("; "))
    

    /// Default. The element's default max-block-size value.
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("max-block-size: ").Append("auto").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("max-block-size: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("max-block-size: ").Append("initial").Append("; "))
    

    /// Specifies max-block-size in px, pt, cm, etc. Read about length units
    static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("max-block-size: ").Append(string value + "px").Append("; "))
    

    /// Specifies max-block-size in px, pt, cm, etc. Read about length units
    static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("max-block-size: ").Append(value).Append("; "))
    

/// The max-inline-size property specifies the maximum size of an element in the inline direction.
type maxInlineSize =

    /// Specifies max-inline-size in percent relative to size of parent element on the corresponding axis.
    static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("max-inline-size: ").Append(string value + "%").Append("; "))
    

    /// Default. The element's default max-inline-size value.
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("max-inline-size: ").Append("auto").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("max-inline-size: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("max-inline-size: ").Append("initial").Append("; "))
    

    /// Specifies max-inline-size in px, pt, cm, etc. Read about length units
    static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("max-inline-size: ").Append(string value + "px").Append("; "))
    

    /// Specifies max-inline-size in px, pt, cm, etc. Read about length units
    static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("max-inline-size: ").Append(value).Append("; "))
    

/// The min-block-size property specifies the minimum size of an element in the block direction.
type minBlockSize =

    /// Specifies min-block-size in percent relative to size of parent element on the corresponding axis.
    static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("min-block-size: ").Append(string value + "%").Append("; "))
    

    /// Default. The element's default min-block-size value.
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("min-block-size: ").Append("auto").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("min-block-size: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("min-block-size: ").Append("initial").Append("; "))
    

    /// Specifies min-block-size in px, pt, cm, etc. Read about length units
    static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("min-block-size: ").Append(string value + "px").Append("; "))
    

    /// Specifies min-block-size in px, pt, cm, etc. Read about length units
    static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("min-block-size: ").Append(value).Append("; "))
    

/// The min-inline-size property specifies the minimum size of an element in the inline direction.
type minInlineSize =

    /// Specifies min-inline-size in percent relative to size of parent element on the corresponding axis.
    static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("min-inline-size: ").Append(string value + "%").Append("; "))
    

    /// Default. The element's default min-inline-size value.
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("min-inline-size: ").Append("auto").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("min-inline-size: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("min-inline-size: ").Append("initial").Append("; "))
    

    /// Specifies min-inline-size in px, pt, cm, etc. Read about length units
    static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("min-inline-size: ").Append(string value + "px").Append("; "))
    

    /// Specifies min-inline-size in px, pt, cm, etc. Read about length units
    static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("min-inline-size: ").Append(value).Append("; "))
    

/// The mix-blend-mode property specifies how an element's content should blend with its direct parent background.
type mixBlendMode =

    /// Sets the blending mode to color
    static member inline color(value: string) = CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append(value).Append("; "))
    

    /// Sets the blending mode to color-burn
    static member inline colorBurn(value: string) = CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append(value).Append("; "))
    

    /// Sets the blending mode to color-dodge
    static member inline colorDodge(value: string) = CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append(value).Append("; "))
    

    /// Sets the blending mode to darken
    static member inline darken = CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append("darken").Append("; "))
    

    /// Sets the blending mode to difference
    static member inline difference = CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append("difference").Append("; "))
    

    /// Sets the blending mode to exclusion
    static member inline exclusion = CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append("exclusion").Append("; "))
    

    /// Sets the blending mode to hue
    static member inline hue = CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append("hue").Append("; "))
    

    /// Sets the blending mode to lighten
    static member inline lighten = CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append("lighten").Append("; "))
    

    /// Sets the blending mode to luminosity
    static member inline luminosity = CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append("luminosity").Append("; "))
    

    /// Sets the blending mode to multiply
    static member inline multiply = CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append("multiply").Append("; "))
    

    /// This is default. Sets the blending mode to normal
    static member inline normal = CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append("normal").Append("; "))
    

    /// Sets the blending mode to overlay
    static member inline overlay = CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append("overlay").Append("; "))
    

    /// Sets the blending mode to saturation
    static member inline saturation = CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append("saturation").Append("; "))
    

    /// Sets the blending mode to screen
    static member inline screen = CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append("screen").Append("; "))
    

/// The object-fit property is used to specify how an  or  should be resized to fit its container.
type objectFit =

    /// The replaced content is scaled to maintain its aspect ratio while fitting within the element's content box
    static member inline contain = CombineKeyValue(fun sb -> sb.Append("object-fit: ").Append("contain").Append("; "))
    

    /// The replaced content is sized to maintain its aspect ratio while filling the element's entire content box. The object will be clipped to fit
    static member inline cover = CombineKeyValue(fun sb -> sb.Append("object-fit: ").Append("cover").Append("; "))
    

    /// This is default. The replaced content is sized to fill the element's content box. If necessary, the object will be stretched or squished to fit
    static member inline fill = CombineKeyValue(fun sb -> sb.Append("object-fit: ").Append("fill").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("object-fit: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("object-fit: ").Append("initial").Append("; "))
    

    /// The replaced content is not resized
    static member inline none = CombineKeyValue(fun sb -> sb.Append("object-fit: ").Append("none").Append("; "))
    

    /// The content is sized as if none or contain were specified (would result in a smaller concrete object size)
    static member inline scaleDown = CombineKeyValue(fun sb -> sb.Append("object-fit: ").Append("scale-down").Append("; "))
    

/// The object-position property is used together with object-fit to specify how an  or  should be positioned with x/y coordinates inside its "own content box".
type objectPosition =

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("object-position: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("object-position: ").Append("initial").Append("; "))
    

    /// Specifies the position of the image or video inside its content box. First value controls the x-axis and the second value controls the y-axis. Can be a string (left, center or right), or a number (in px or %). Negative values are allowed
    static member inline position = CombineKeyValue(fun sb -> sb.Append("object-position: ").Append("position").Append("; "))
    

/// The order property specifies the order of a flexible item relative to the rest of the flexible items inside the same container.
type order =

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("order: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("order: ").Append("initial").Append("; "))
    

    /// Default value 0. Specifies the order for the flexible item
    static member inline number(value: float) = CombineKeyValue(fun sb -> sb.Append("order: ").Append(value).Append("; "))
    

/// 
[<RequireQualifiedAccess>]
module outline =

    /// An outline is a line that is drawn around elements, outside the borders, to make the element "stand out".
    type color =

        /// Specifies the color of the outline. Look at CSS Color Values for a complete list of possible color values.
        static member inline color(value: string) = CombineKeyValue(fun sb -> sb.Append("outline-color: ").Append(value).Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("outline-color: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("outline-color: ").Append("initial").Append("; "))
    

    /// The outline-offset property adds space between the outline and the edge or border of an element.
    type offset =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("outline-offset: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("outline-offset: ").Append("initial").Append("; "))
    

        /// The distance the outline is outset from the border edge. Default value is 0
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("outline-offset: ").Append(string value + "px").Append("; "))
    

        /// The distance the outline is outset from the border edge. Default value is 0
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("outline-offset: ").Append(value).Append("; "))
    

    /// An outline is a line that is drawn around elements, outside the borders, to make the element "stand out".
    type style =

        /// Specifies a dashed outline
        static member inline dashed = CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append("dashed").Append("; "))
    

        /// Specifies a dotted outline
        static member inline dotted = CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append("dotted").Append("; "))
    

        /// Specifies a double outliner
        static member inline double = CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append("double").Append("; "))
    

        /// Specifies a 3D grooved outline. The effect depends on the outline-color value
        static member inline groove = CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append("groove").Append("; "))
    

        /// Specifies a hidden outline
        static member inline hidden = CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append("hidden").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append("initial").Append("; "))
    

        /// Specifies a 3D inset outline. The effect depends on the outline-color value
        static member inline inset = CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append("inset").Append("; "))
    

        /// Specifies no outline. This is default
        static member inline none = CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append("none").Append("; "))
    

        /// Specifies a 3D outset outline. The effect depends on the outline-color value
        static member inline outset = CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append("outset").Append("; "))
    

        /// Specifies a 3D ridged outline. The effect depends on the outline-color value
        static member inline ridge = CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append("ridge").Append("; "))
    

        /// Specifies a solid outline
        static member inline solid = CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append("solid").Append("; "))
    

    /// An outline is a line that is drawn around elements, outside the borders, to make the element "stand out".
    type width =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("outline-width: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("outline-width: ").Append("initial").Append("; "))
    

        /// Allows you to define the thickness of the outline. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("outline-width: ").Append(string value + "px").Append("; "))
    

        /// Allows you to define the thickness of the outline. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("outline-width: ").Append(value).Append("; "))
    

        /// Specifies a medium outline. This is default
        static member inline medium = CombineKeyValue(fun sb -> sb.Append("outline-width: ").Append("medium").Append("; "))
    

        /// Specifies a thick outline
        static member inline thick = CombineKeyValue(fun sb -> sb.Append("outline-width: ").Append("thick").Append("; "))
    

        /// Specifies a thin outline
        static member inline thin = CombineKeyValue(fun sb -> sb.Append("outline-width: ").Append("thin").Append("; "))
    

/// The overflow property specifies what should happen if content overflows an element's box.
[<RequireQualifiedAccess>]
module overflow =

    /// The overflow-wrap property specifies whether or not the browser can break lines with long words, if they overflow the container.
    type wrap =

        /// Long words will break if they overflow the container
        static member inline anywhere = CombineKeyValue(fun sb -> sb.Append("overflow-wrap: ").Append("anywhere").Append("; "))
    

        /// Long words will break if they overflow the container
        static member inline breakWord = CombineKeyValue(fun sb -> sb.Append("overflow-wrap: ").Append("break-word").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("overflow-wrap: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("overflow-wrap: ").Append("initial").Append("; "))
    

        /// Long words will not break, even if they overflow the container. This is default
        static member inline normal = CombineKeyValue(fun sb -> sb.Append("overflow-wrap: ").Append("normal").Append("; "))
    

    /// The overflow-x property specifies whether to clip the content, add a scroll bar, or display overflow content of a block-level element, when it overflows at the left and right edges.
    type x =

        /// Should cause a scrolling mechanism to be provided for overflowing boxes
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("overflow-x: ").Append("auto").Append("; "))
    

        /// The content is clipped - and no scrolling mechanism is provided
        static member inline hidden = CombineKeyValue(fun sb -> sb.Append("overflow-x: ").Append("hidden").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("overflow-x: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("overflow-x: ").Append("initial").Append("; "))
    

        /// The content is clipped and a scrolling mechanism is provided
        static member inline scroll = CombineKeyValue(fun sb -> sb.Append("overflow-x: ").Append("scroll").Append("; "))
    

        /// The content is not clipped, and it may be rendered outside the left and right edges. This is default
        static member inline visible = CombineKeyValue(fun sb -> sb.Append("overflow-x: ").Append("visible").Append("; "))
    

    /// The overflow-y property specifies whether to clip the content, add a scroll bar, or display overflow content of a block-level element, when it overflows at the top and bottom edges.
    type y =

        /// Should cause a scrolling mechanism to be provided for overflowing boxes
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("overflow-y: ").Append("auto").Append("; "))
    

        /// The content is clipped - and no scrolling mechanism is provided
        static member inline hidden = CombineKeyValue(fun sb -> sb.Append("overflow-y: ").Append("hidden").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("overflow-y: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("overflow-y: ").Append("initial").Append("; "))
    

        /// The content is clipped and a scrolling mechanism is provided
        static member inline scroll = CombineKeyValue(fun sb -> sb.Append("overflow-y: ").Append("scroll").Append("; "))
    

        /// The content is not clipped, and it may be rendered outside the content box. This is default
        static member inline visible = CombineKeyValue(fun sb -> sb.Append("overflow-y: ").Append("visible").Append("; "))
    

/// An element's padding is the space between its content and its border.
[<RequireQualifiedAccess>]
module padding =

    /// An element's padding-block is the space from its border to its content in the block direction, and it is a shorthand property for the following properties:
    type block =

        /// Specifies padding-block in percent relative to size of parent element in the inline direction.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("padding-block: ").Append(string value + "%").Append("; "))
    

        /// Default. The element's default padding-block value.
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("padding-block: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("padding-block: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("padding-block: ").Append("initial").Append("; "))
    

        /// Specifies padding-block in px, pt, cm, etc. Negative values are not allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("padding-block: ").Append(string value + "px").Append("; "))
    

        /// Specifies padding-block in px, pt, cm, etc. Negative values are not allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("padding-block: ").Append(value).Append("; "))
    

    /// An element's padding-block-end is the space from its border to its content, at the end in the block direction.
    type blockEnd =

        /// Specifies padding-block-end in percent relative to size of parent element in the inline direction.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("padding-block-end: ").Append(string value + "%").Append("; "))
    

        /// Default. The element's default padding-block-end value.
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("padding-block-end: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("padding-block-end: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("padding-block-end: ").Append("initial").Append("; "))
    

        /// Specifies padding-block-end in px, pt, cm, etc. Negative values are not allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("padding-block-end: ").Append(string value + "px").Append("; "))
    

        /// Specifies padding-block-end in px, pt, cm, etc. Negative values are not allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("padding-block-end: ").Append(value).Append("; "))
    

    /// An element's padding-block-start is the space from its border to its content, at the start in the block direction.
    type blockStart =

        /// Specifies padding-block-start in percent relative to size of parent element in the inline direction.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("padding-block-start: ").Append(string value + "%").Append("; "))
    

        /// Default. The element's default padding-block-start value.
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("padding-block-start: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("padding-block-start: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("padding-block-start: ").Append("initial").Append("; "))
    

        /// Specifies padding-block-start in px, pt, cm, etc. Negative values are not allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("padding-block-start: ").Append(string value + "px").Append("; "))
    

        /// Specifies padding-block-start in px, pt, cm, etc. Negative values are not allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("padding-block-start: ").Append(value).Append("; "))
    

    /// An element's padding is the space between its content and its border.
    type bottom =

        /// Specifies a bottom padding in percent of the width of the containing element
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("padding-bottom: ").Append(string value + "%").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("padding-bottom: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("padding-bottom: ").Append("initial").Append("; "))
    

        /// Specifies a fixed bottom padding in px, pt, cm, etc. Default value is 0. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("padding-bottom: ").Append(string value + "px").Append("; "))
    

        /// Specifies a fixed bottom padding in px, pt, cm, etc. Default value is 0. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("padding-bottom: ").Append(value).Append("; "))
    

    /// An element's padding-inline is the space from its border to its content in the inline direction, and it is a shorthand property for the following properties:
    type inline' =

        /// Specifies distance in percent relative to size of parent element in the inline direction.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("padding-inline: ").Append(string value + "%").Append("; "))
    

        /// Default. The element's default padding-inline distance.
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("padding-inline: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("padding-inline: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("padding-inline: ").Append("initial").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are not allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("padding-inline: ").Append(string value + "px").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are not allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("padding-inline: ").Append(value).Append("; "))
    

    /// An element's padding-inline-end is the space from its border to its content, at the end in the inline direction.
    type inlineEnd =

        /// Specifies distance in percent relative to size of parent element in the inline direction.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("padding-inline-end: ").Append(string value + "%").Append("; "))
    

        /// Default. The element's default padding-inline-end distance.
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("padding-inline-end: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("padding-inline-end: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("padding-inline-end: ").Append("initial").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are not allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("padding-inline-end: ").Append(string value + "px").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are not allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("padding-inline-end: ").Append(value).Append("; "))
    

    /// An element's padding-inline-start is the space from its border to its content, at the start in the inline direction.
    type inlineStart =

        /// Specifies distance in percent relative to size of parent element in the inline direction.
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("padding-inline-start: ").Append(string value + "%").Append("; "))
    

        /// Default. The element's default padding-inline-start distance.
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("padding-inline-start: ").Append("auto").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("padding-inline-start: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("padding-inline-start: ").Append("initial").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are not allowed. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("padding-inline-start: ").Append(string value + "px").Append("; "))
    

        /// Specifies distance in px, pt, cm, etc. Negative values are not allowed. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("padding-inline-start: ").Append(value).Append("; "))
    

    /// An element's padding is the space between its content and its border.
    type left =

        /// Specifies a left padding in percent of the width of the containing element
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("padding-left: ").Append(string value + "%").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("padding-left: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("padding-left: ").Append("initial").Append("; "))
    

        /// Specifies a fixed left padding in px, pt, cm, etc. Default value is 0. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("padding-left: ").Append(string value + "px").Append("; "))
    

        /// Specifies a fixed left padding in px, pt, cm, etc. Default value is 0. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("padding-left: ").Append(value).Append("; "))
    

    /// An element's padding is the space between its content and its border.
    type right =

        /// Specifies a right padding in percent of the width of the containing element
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("padding-right: ").Append(string value + "%").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("padding-right: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("padding-right: ").Append("initial").Append("; "))
    

        /// Specifies a fixed right padding in px, pt, cm, etc. Default value is 0. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("padding-right: ").Append(string value + "px").Append("; "))
    

        /// Specifies a fixed right padding in px, pt, cm, etc. Default value is 0. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("padding-right: ").Append(value).Append("; "))
    

    /// An element's padding is the space between its content and its border.
    type top =

        /// Specifies a top padding in percent of the width of the containing element
        static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("padding-top: ").Append(string value + "%").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("padding-top: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("padding-top: ").Append("initial").Append("; "))
    

        /// Specifies a fixed top padding in px, pt, cm, etc. Default value is 0. Read about length units
        static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("padding-top: ").Append(string value + "px").Append("; "))
    

        /// Specifies a fixed top padding in px, pt, cm, etc. Default value is 0. Read about length units
        static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("padding-top: ").Append(value).Append("; "))
    

/// The paint-order property specifies the order of how an SVG element or text is painted.
type paintOrder =

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("paint-order: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("paint-order: ").Append("initial").Append("; "))
    

    /// Default value. The paint order is fill, stroke, markers.
    static member inline normal = CombineKeyValue(fun sb -> sb.Append("paint-order: ").Append("normal").Append("; "))
    

    /// Painting will start with given value, then continue with the remaining painting in default order. If only "stroke" is given, the next painting activity is fill, then markers.
    static member inline one(value: string) = CombineKeyValue(fun sb -> sb.Append("paint-order: ").Append(value).Append("; "))
    

    /// Painting will be done according to given values.
    static member inline three(value: string) = CombineKeyValue(fun sb -> sb.Append("paint-order: ").Append(value).Append("; "))
    

    /// Painting will start with given values, then continue with the remaining painting in default order. If "stroke markers" are given, the next painting activity will be fill.
    static member inline two(value: string) = CombineKeyValue(fun sb -> sb.Append("paint-order: ").Append(value).Append("; "))
    

/// The perspective property is used to give a 3D-positioned element some perspective.
[<RequireQualifiedAccess>]
module perspective =

    /// The perspective-origin property defines at from which position the user is looking at the 3D-positioned element.
    type origin =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("perspective-origin: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("perspective-origin: ").Append("initial").Append("; "))
    

        /// Defining where the view is placed at the x-axisPossible values:leftcenterrightlength%Default value: 50%
        static member inline xAxis = CombineKeyValue(fun sb -> sb.Append("perspective-origin: ").Append("x-axis").Append("; "))
    

        /// Defining where the view is placed at the y-axisPossible values:topcenterbottomlength%Default value: 50%
        static member inline yAxis = CombineKeyValue(fun sb -> sb.Append("perspective-origin: ").Append("y-axis").Append("; "))
    

/// The place-content property is used in flexbox and grid layouts, and is a shorthand property for the following properties:
type placeContent =

    /// Align items to the center of the container
    static member inline center = CombineKeyValue(fun sb -> sb.Append("place-content: ").Append("center").Append("; "))
    

    /// Align items at the end of the container
    static member inline end' = CombineKeyValue(fun sb -> sb.Append("place-content: ").Append("end").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("place-content: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("place-content: ").Append("initial").Append("; "))
    

    /// Default value. Dependant on layout context. The same as setting no property value for align-content and justify-content.
    static member inline normal = CombineKeyValue(fun sb -> sb.Append("place-content: ").Append("normal").Append("; "))
    

    /// 'safe' sets alignment of the item to 'start' if the content overflows'unsafe' keeps the alignment value regardless of wether or not the item content overflows
    static member inline overflowAlignment = CombineKeyValue(fun sb -> sb.Append("place-content: ").Append("overflow-alignment").Append("; "))
    

    /// Distribute available extra space evenly around each element inside the container on both axis.
    static member inline spaceAround = CombineKeyValue(fun sb -> sb.Append("place-content: ").Append("space-around").Append("; "))
    

    /// Distribute available extra space evenly between the elements inside the container on both axis.
    static member inline spaceBetween = CombineKeyValue(fun sb -> sb.Append("place-content: ").Append("space-between").Append("; "))
    

    /// Distribute elements inside the container evenly on both axis.
    static member inline spaceEvenly = CombineKeyValue(fun sb -> sb.Append("place-content: ").Append("space-evenly").Append("; "))
    

    /// Align items at the start of the container
    static member inline start = CombineKeyValue(fun sb -> sb.Append("place-content: ").Append("start").Append("; "))
    

    /// Grid: Stretches grid items to fill the grid container if size is not set. Flexbox: Stretches flex items on the cross axis to fill the flex container if flex items have no specified size on the cross axis.
    static member inline stretch = CombineKeyValue(fun sb -> sb.Append("place-content: ").Append("stretch").Append("; "))
    

/// The place-items property is used in grid layout, and is a shorthand property for the following properties:
type placeItems =

    /// Items are positioned at the baseline of the container
    static member inline baseline = CombineKeyValue(fun sb -> sb.Append("place-items: ").Append("baseline").Append("; "))
    

    /// Align items to the center of the grid cell
    static member inline center = CombineKeyValue(fun sb -> sb.Append("place-items: ").Append("center").Append("; "))
    

    /// Align items at the end of the grid cell
    static member inline end' = CombineKeyValue(fun sb -> sb.Append("place-items: ").Append("end").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("place-items: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("place-items: ").Append("initial").Append("; "))
    

    /// Default. The element's default place-items value. The default value for align-items is 'normal', and the default value for justify-items is 'legacy'.
    static member inline normal(value: string) = CombineKeyValue(fun sb -> sb.Append("place-items: ").Append(value).Append("; "))
    

    /// Align items at the start of the grid cell
    static member inline start = CombineKeyValue(fun sb -> sb.Append("place-items: ").Append("start").Append("; "))
    

    /// Stretches grid items to fill the grid container if the grid item sizes are not set.
    static member inline stretch = CombineKeyValue(fun sb -> sb.Append("place-items: ").Append("stretch").Append("; "))
    

/// The place-self property is used to align individual grid items, and is a shorthand property for the following properties:
type placeSelf =

    /// Default. The element's default place-self value.
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("place-self: ").Append("auto").Append("; "))
    

    /// The element is aligned with the baseline of the parent.
    static member inline baseline(value: string) = CombineKeyValue(fun sb -> sb.Append("place-self: ").Append(value).Append("; "))
    

    /// Align items to the center
    static member inline center = CombineKeyValue(fun sb -> sb.Append("place-self: ").Append("center").Append("; "))
    

    /// Align items at the end in the inline and block directions
    static member inline end' = CombineKeyValue(fun sb -> sb.Append("place-self: ").Append("end").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("place-self: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("place-self: ").Append("initial").Append("; "))
    

    /// Align items to the left in the inline direction, as the justify-self property value.
    static member inline left = CombineKeyValue(fun sb -> sb.Append("place-self: ").Append("left").Append("; "))
    

    /// Dependant on layout context, but similar to 'stretch' for grid layout for grid items when size is not set. If size is set, the property value behaves lik 'start'.
    static member inline normal = CombineKeyValue(fun sb -> sb.Append("place-self: ").Append("normal").Append("; "))
    

    /// 'safe' sets alignment of the item to 'start' if the content overflows'unsafe' keeps the alignment value regardless of wether or not the item content overflows
    static member inline overflowAlignment = CombineKeyValue(fun sb -> sb.Append("place-self: ").Append("overflow-alignment").Append("; "))
    

    /// Align items to the right in the inline direction, as the justify-self property value.
    static member inline right = CombineKeyValue(fun sb -> sb.Append("place-self: ").Append("right").Append("; "))
    

    /// Align items at the start in the inline and block directions
    static member inline start = CombineKeyValue(fun sb -> sb.Append("place-self: ").Append("start").Append("; "))
    

    /// Stretches to fill the grid cell if size is not set.
    static member inline stretch = CombineKeyValue(fun sb -> sb.Append("place-self: ").Append("stretch").Append("; "))
    

/// The position property specifies the type of positioning method used for an element (static, relative, absolute, fixed, or sticky).
type position =

    /// The element is positioned relative to its first positioned (not static) ancestor element
    static member inline absolute = CombineKeyValue(fun sb -> sb.Append("position: ").Append("absolute").Append("; "))
    

    /// The element is positioned relative to the browser window
    static member inline fixed' = CombineKeyValue(fun sb -> sb.Append("position: ").Append("fixed").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("position: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("position: ").Append("initial").Append("; "))
    

    /// The element is positioned relative to its normal position, so "left:20px" adds 20 pixels to the element's LEFT position
    static member inline relative = CombineKeyValue(fun sb -> sb.Append("position: ").Append("relative").Append("; "))
    

    /// Default value. Elements render in order, as they appear in the document flow
    static member inline static' = CombineKeyValue(fun sb -> sb.Append("position: ").Append("static").Append("; "))
    

    /// The element is positioned based on the user's scroll position A sticky element toggles between relative and fixed, depending on the scroll position. It is positioned relative until a given offset position is met in the viewport - then it "sticks" in place (like position:fixed). Note: Not supported in IE/Edge 15 or earlier. Supported in Safari from version 6.1 with a -webkit- prefix.
    static member inline sticky = CombineKeyValue(fun sb -> sb.Append("position: ").Append("sticky").Append("; "))
    

/// The quotes property sets the type of quotation marks for quotations.
type quotes =

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("quotes: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("quotes: ").Append("initial").Append("; "))
    

    /// Specifies that the "open-quote" and "close-quote" values of the "content" property will not produce any quotation marks
    static member inline none = CombineKeyValue(fun sb -> sb.Append("quotes: ").Append("none").Append("; "))
    

    /// Specifies which quotation marks to use. The first two values specifies the first level of quotation embedding, the next two values specifies the next level of quote embedding, etc
    static member inline string(value: string) = CombineKeyValue(fun sb -> sb.Append("quotes: ").Append(value).Append("; "))
    

/// The resize property defines if (and how) an element is resizable by the user.
type resize =

    /// The user can resize both the height and width of the element
    static member inline both = CombineKeyValue(fun sb -> sb.Append("resize: ").Append("both").Append("; "))
    

    /// The user can resize the width of the element
    static member inline horizontal = CombineKeyValue(fun sb -> sb.Append("resize: ").Append("horizontal").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("resize: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("resize: ").Append("initial").Append("; "))
    

    /// Default value. The user cannot resize the element
    static member inline none = CombineKeyValue(fun sb -> sb.Append("resize: ").Append("none").Append("; "))
    

    /// The user can resize the height of the element
    static member inline vertical = CombineKeyValue(fun sb -> sb.Append("resize: ").Append("vertical").Append("; "))
    

/// The rotate property allows you to rotate elements.
type rotate =

    /// Defines how much an element is rotated. Possible units: degradturn
    static member inline angle = CombineKeyValue(fun sb -> sb.Append("rotate: ").Append("angle").Append("; "))
    

    /// Optional. If not set, z-axis is default. Defines axis to rotate element around. Possible values: xyz
    static member inline axis = CombineKeyValue(fun sb -> sb.Append("rotate: ").Append("axis").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("rotate: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("rotate: ").Append("initial").Append("; "))
    

    /// Three numbers define a vector for the element to be rotated around. The numbers are x-, y- and z-coordinates for the vector, respectively. The last value is the angle for how much to rotate. Possible values: number number number angle
    static member inline vector(value: string) = CombineKeyValue(fun sb -> sb.Append("rotate: ").Append(value).Append("; "))
    

/// The row-gap property specifies the gap between the rows in a flexbox or grid layout.
type rowGap =

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("row-gap: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("row-gap: ").Append("initial").Append("; "))
    

    /// A specified length or % that will set the gap between the rows
    static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("row-gap: ").Append(string value + "px").Append("; "))
    

    /// A specified length or % that will set the gap between the rows
    static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("row-gap: ").Append(value).Append("; "))
    

    /// Default value. Specifies a normal gap between the rows
    static member inline normal = CombineKeyValue(fun sb -> sb.Append("row-gap: ").Append("normal").Append("; "))
    

/// The scale property allows you to change the size of elements.
type scale =

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("scale: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("scale: ").Append("initial").Append("; "))
    

    /// Defines scale factor at the x-axis. Possible values: number%
    static member inline xAxis = CombineKeyValue(fun sb -> sb.Append("scale: ").Append("x-axis").Append("; "))
    

    /// Defines scale factor at the y-axis. Possible values: number%
    static member inline yAxis = CombineKeyValue(fun sb -> sb.Append("scale: ").Append("y-axis").Append("; "))
    

    /// Defines scale factor at the z-axis. Possible values: number%
    static member inline zAxis = CombineKeyValue(fun sb -> sb.Append("scale: ").Append("z-axis").Append("; "))
    

/// The tab-size property specifies the width of a tab character.
type tabSize =

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("tab-size: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("tab-size: ").Append("initial").Append("; "))
    

    /// The length of a tab-character. This property value is not supported in any of the major browsers
    static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("tab-size: ").Append(string value + "px").Append("; "))
    

    /// The length of a tab-character. This property value is not supported in any of the major browsers
    static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("tab-size: ").Append(value).Append("; "))
    

    /// The number of space-characters to be displayed for each tab-character. Default value is 8
    static member inline number(value: float) = CombineKeyValue(fun sb -> sb.Append("tab-size: ").Append(value).Append("; "))
    

/// The table-layout property defines the algorithm used to lay out table cells, rows, and columns.
type tableLayout =

    /// Browsers use an automatic table layout algorithm. The column width is set by the widest unbreakable content in the cells. The content will dictate the layout
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("table-layout: ").Append("auto").Append("; "))
    

    /// Sets a fixed table layout algorithm. The table and column widths are set by the widths of table and col or by the width of the first row of cells. Cells in other rows do not affect column widths. If no widths are present on the first row, the column widths are divided equally across the table, regardless of content inside the cells
    static member inline fixed' = CombineKeyValue(fun sb -> sb.Append("table-layout: ").Append("fixed").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("table-layout: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("table-layout: ").Append("initial").Append("; "))
    

/// The text-align property specifies the horizontal alignment of text in an element.
[<RequireQualifiedAccess>]
module textAlign =

    /// The text-align-last property specifies how to align the last line of a text.
    type last =

        /// Default value. The last line is justified and aligned left
        static member inline auto = CombineKeyValue(fun sb -> sb.Append("text-align-last: ").Append("auto").Append("; "))
    

        /// The last line is center-aligned
        static member inline center = CombineKeyValue(fun sb -> sb.Append("text-align-last: ").Append("center").Append("; "))
    

        /// The last line is aligned at the end of the line (right if the text-direction is left-to-right, and left is the text-direction is right-to-left)
        static member inline end' = CombineKeyValue(fun sb -> sb.Append("text-align-last: ").Append("end").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("text-align-last: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("text-align-last: ").Append("initial").Append("; "))
    

        /// The last line is justified as the rest of the lines
        static member inline justify = CombineKeyValue(fun sb -> sb.Append("text-align-last: ").Append("justify").Append("; "))
    

        /// The last line is aligned to the left
        static member inline left = CombineKeyValue(fun sb -> sb.Append("text-align-last: ").Append("left").Append("; "))
    

        /// The last line is aligned to the right
        static member inline right = CombineKeyValue(fun sb -> sb.Append("text-align-last: ").Append("right").Append("; "))
    

        /// The last line is aligned at the beginning of the line (left if the text-direction is left-to-right, and right is the text-direction is right-to-left)
        static member inline start = CombineKeyValue(fun sb -> sb.Append("text-align-last: ").Append("start").Append("; "))
    

/// 
[<RequireQualifiedAccess>]
module textDecoration =

    /// The text-decoration-color property specifies the color of the text-decoration (underlines, overlines, linethroughs).
    type color =

        /// Specifies the color of the text-decoration
        static member inline color(value: string) = CombineKeyValue(fun sb -> sb.Append("text-decoration-color: ").Append(value).Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("text-decoration-color: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("text-decoration-color: ").Append("initial").Append("; "))
    

    /// The text-decoration-line property sets the kind of text decoration to use (like underline, overline, line-through).
    type line =

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("text-decoration-line: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("text-decoration-line: ").Append("initial").Append("; "))
    

        /// Specifies that a line will be displayed through the text
        static member inline lineThrough = CombineKeyValue(fun sb -> sb.Append("text-decoration-line: ").Append("line-through").Append("; "))
    

        /// Default value. Specifies no line for the text-decoration
        static member inline none = CombineKeyValue(fun sb -> sb.Append("text-decoration-line: ").Append("none").Append("; "))
    

        /// Specifies that a line will be displayed over the text
        static member inline overline = CombineKeyValue(fun sb -> sb.Append("text-decoration-line: ").Append("overline").Append("; "))
    

        /// Specifies that a line will be displayed under the text
        static member inline underline = CombineKeyValue(fun sb -> sb.Append("text-decoration-line: ").Append("underline").Append("; "))
    

    /// The text-decoration-style property sets the style of the text decoration (like solid, wavy, dotted, dashed, double).
    type style =

        /// The line will display as a dashed line
        static member inline dashed = CombineKeyValue(fun sb -> sb.Append("text-decoration-style: ").Append("dashed").Append("; "))
    

        /// The line will display as a dotted line
        static member inline dotted = CombineKeyValue(fun sb -> sb.Append("text-decoration-style: ").Append("dotted").Append("; "))
    

        /// The line will display as a double line
        static member inline double = CombineKeyValue(fun sb -> sb.Append("text-decoration-style: ").Append("double").Append("; "))
    

        /// Inherits this property from its parent element. Read about inherit
        static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("text-decoration-style: ").Append("inherit").Append("; "))
    

        /// Sets this property to its default value. Read about initial
        static member inline initial = CombineKeyValue(fun sb -> sb.Append("text-decoration-style: ").Append("initial").Append("; "))
    

        /// Default value. The line will display as a single line
        static member inline solid = CombineKeyValue(fun sb -> sb.Append("text-decoration-style: ").Append("solid").Append("; "))
    

        /// The line will display as a wavy line
        static member inline wavy = CombineKeyValue(fun sb -> sb.Append("text-decoration-style: ").Append("wavy").Append("; "))
    

/// The text-indent property specifies the indentation of the first line in a text-block.
type textIndent =

    /// Defines the indentation in % of the width of the parent element
    static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("text-indent: ").Append(string value + "%").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("text-indent: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("text-indent: ").Append("initial").Append("; "))
    

    /// Defines a fixed indentation in px, pt, cm, em, etc. Default value is 0. Read about length units
    static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("text-indent: ").Append(string value + "px").Append("; "))
    

    /// Defines a fixed indentation in px, pt, cm, em, etc. Default value is 0. Read about length units
    static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("text-indent: ").Append(value).Append("; "))
    

/// The text-justify property specifies the justification method of text when text-align is set to "justify".
type textJustify =

    /// The browser determines the justification algorithm
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("text-justify: ").Append("auto").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("text-justify: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("text-justify: ").Append("initial").Append("; "))
    

    /// Increases/Decreases the space between characters
    static member inline interCharacter = CombineKeyValue(fun sb -> sb.Append("text-justify: ").Append("inter-character").Append("; "))
    

    /// Increases/Decreases the space between words
    static member inline interWord = CombineKeyValue(fun sb -> sb.Append("text-justify: ").Append("inter-word").Append("; "))
    

    /// Disables justification methods
    static member inline none = CombineKeyValue(fun sb -> sb.Append("text-justify: ").Append("none").Append("; "))
    

/// The text-orientation property specifies the orientation of characters.
type textOrientation =

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("text-orientation: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("text-orientation: ").Append("initial").Append("; "))
    

    /// Deafult value. Characters are rotated 90 degrees clockwise.
    static member inline mixed = CombineKeyValue(fun sb -> sb.Append("text-orientation: ").Append("mixed").Append("; "))
    

    /// Only supported in Firefox. Characters are orientated the same as the text lines are oriented with writing-mode vertical, 90 degrees clockwise.
    static member inline sideways = CombineKeyValue(fun sb -> sb.Append("text-orientation: ").Append("sideways").Append("; "))
    

    /// Equal to property value sideways. Kept for compatibility purposes.
    static member inline sidewaysRight = CombineKeyValue(fun sb -> sb.Append("text-orientation: ").Append("sideways-right").Append("; "))
    

    /// Characters are not rotated, but standing upright.
    static member inline upright = CombineKeyValue(fun sb -> sb.Append("text-orientation: ").Append("upright").Append("; "))
    

    /// For use in SVG elements, so that text inherits deprecated SVG properties glyph-orientation-vertical and glyph-orientation-horizontal.
    static member inline useGlyphOrientation = CombineKeyValue(fun sb -> sb.Append("text-orientation: ").Append("use-glyph-orientation").Append("; "))
    

/// The text-overflow property specifies how overflowed content that is not displayed should be signaled to the user. It can be clipped, display an ellipsis (...), or display a custom string.
type textOverflow =

    /// Default value. The text is clipped and not accessible
    static member inline clip = CombineKeyValue(fun sb -> sb.Append("text-overflow: ").Append("clip").Append("; "))
    

    /// Render an ellipsis ("...") to represent the clipped text
    static member inline ellipsis = CombineKeyValue(fun sb -> sb.Append("text-overflow: ").Append("ellipsis").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("text-overflow: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("text-overflow: ").Append("initial").Append("; "))
    

    /// Render the given string to represent the clipped text
    static member inline string = CombineKeyValue(fun sb -> sb.Append("text-overflow: ").Append("string").Append("; "))
    

/// The text-shadow property adds shadow to text.
type textShadow =

    /// Optional. The blur radius. Default value is 0
    static member inline blurRadius = CombineKeyValue(fun sb -> sb.Append("text-shadow: ").Append("blur-radius").Append("; "))
    

    /// Optional. The color of the shadow. Look at CSS Color Values for a complete list of possible color values
    static member inline color(value: string) = CombineKeyValue(fun sb -> sb.Append("text-shadow: ").Append(value).Append("; "))
    

    /// Required. The position of the horizontal shadow. Negative values are allowed
    static member inline hShadow = CombineKeyValue(fun sb -> sb.Append("text-shadow: ").Append("h-shadow").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("text-shadow: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("text-shadow: ").Append("initial").Append("; "))
    

    /// Default value. No shadow
    static member inline none = CombineKeyValue(fun sb -> sb.Append("text-shadow: ").Append("none").Append("; "))
    

    /// Required. The position of the vertical shadow. Negative values are allowed
    static member inline vShadow = CombineKeyValue(fun sb -> sb.Append("text-shadow: ").Append("v-shadow").Append("; "))
    

/// The text-transform property controls the capitalization of text.
type textTransform =

    /// Transforms the first character of each word to uppercase
    static member inline capitalize = CombineKeyValue(fun sb -> sb.Append("text-transform: ").Append("capitalize").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("text-transform: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("text-transform: ").Append("initial").Append("; "))
    

    /// Transforms all characters to lowercase
    static member inline lowercase = CombineKeyValue(fun sb -> sb.Append("text-transform: ").Append("lowercase").Append("; "))
    

    /// No capitalization. The text renders as it is. This is default
    static member inline none = CombineKeyValue(fun sb -> sb.Append("text-transform: ").Append("none").Append("; "))
    

    /// Transforms all characters to uppercase
    static member inline uppercase = CombineKeyValue(fun sb -> sb.Append("text-transform: ").Append("uppercase").Append("; "))
    

/// The text-underline-offset property specifies the offset distance of underline text decorations.
type textUnderlineOffset =

    /// Default value. The browser sets the appropriate offset for the underline
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("text-underline-offset: ").Append("auto").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("text-underline-offset: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("text-underline-offset: ").Append("initial").Append("; "))
    

    /// Specifies the offset as a length value
    static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("text-underline-offset: ").Append(string value + "px").Append("; "))
    

    /// Specifies the offset as a length value
    static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("text-underline-offset: ").Append(value).Append("; "))
    

    /// Specifies the offset as a percentage value
    static member inline percentage = CombineKeyValue(fun sb -> sb.Append("text-underline-offset: ").Append("percentage").Append("; "))
    

/// The text-underline-position property specifies the position of underline text decorations.
type textUnderlinePosition =

    /// Default value. The browser sets the position of the underline
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("text-underline-position: ").Append("auto").Append("; "))
    

    /// If the font file includes information about underline position, use that value. If not, use auto
    static member inline fromFont = CombineKeyValue(fun sb -> sb.Append("text-underline-position: ").Append("from-font").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("text-underline-position: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("text-underline-position: ").Append("initial").Append("; "))
    

    /// In vertical writing mode the underline will be placed to the left of the text. In horizontal writing mode the underline will be placed as auto
    static member inline left = CombineKeyValue(fun sb -> sb.Append("text-underline-position: ").Append("left").Append("; "))
    

    /// In vertical writing mode the underline will be placed to the right of the text. In horizontal writing mode the underline will be placed as auto
    static member inline right = CombineKeyValue(fun sb -> sb.Append("text-underline-position: ").Append("right").Append("; "))
    

    /// Sets the underline below the alphabetic baseline
    static member inline under = CombineKeyValue(fun sb -> sb.Append("text-underline-position: ").Append("under").Append("; "))
    

/// The translate property allows you to change the position of elements.
type translate =

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("translate: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("translate: ").Append("initial").Append("; "))
    

    /// Defines position at the x-axis. Possible values: length%
    static member inline xAxis = CombineKeyValue(fun sb -> sb.Append("translate: ").Append("x-axis").Append("; "))
    

    /// Defines position at the y-axis. Possible values: length%
    static member inline yAxis = CombineKeyValue(fun sb -> sb.Append("translate: ").Append("y-axis").Append("; "))
    

    /// Defines position at the z-axis. Possible values: length
    static member inline zAxis = CombineKeyValue(fun sb -> sb.Append("translate: ").Append("z-axis").Append("; "))
    

/// The unicode-bidi property is used together with the direction property to set or return whether the text should be overridden to support multiple languages in the same document.
type unicodeBidi =

    /// For inline elements, this creates an override. For block elements, this creates an override for inline-level descendants not within another block element
    static member inline bidiOverride = CombineKeyValue(fun sb -> sb.Append("unicode-bidi: ").Append("bidi-override").Append("; "))
    

    /// For inline elements, this value opens an additional level of embedding
    static member inline embed = CombineKeyValue(fun sb -> sb.Append("unicode-bidi: ").Append("embed").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("unicode-bidi: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("unicode-bidi: ").Append("initial").Append("; "))
    

    /// The element is isolated from its siblings
    static member inline isolate = CombineKeyValue(fun sb -> sb.Append("unicode-bidi: ").Append("isolate").Append("; "))
    

    /// 
    static member inline isolateOverride = CombineKeyValue(fun sb -> sb.Append("unicode-bidi: ").Append("isolate-override").Append("; "))
    

    /// The element does not open an additional level of embedding. This is default
    static member inline normal = CombineKeyValue(fun sb -> sb.Append("unicode-bidi: ").Append("normal").Append("; "))
    

    /// 
    static member inline plaintext = CombineKeyValue(fun sb -> sb.Append("unicode-bidi: ").Append("plaintext").Append("; "))
    

/// The user-select property specifies whether the text of an element can be selected.
type userSelect =

    /// Text selection is made with one click instead of a double-click
    static member inline all = CombineKeyValue(fun sb -> sb.Append("user-select: ").Append("all").Append("; "))
    

    /// Default. Text can be selected if the browser allows it
    static member inline auto = CombineKeyValue(fun sb -> sb.Append("user-select: ").Append("auto").Append("; "))
    

    /// Prevent text selection
    static member inline none = CombineKeyValue(fun sb -> sb.Append("user-select: ").Append("none").Append("; "))
    

    /// The text can be selected by the user
    static member inline text = CombineKeyValue(fun sb -> sb.Append("user-select: ").Append("text").Append("; "))
    

/// The vertical-align property sets the vertical alignment of an element.
type verticalAlign =

    /// Raises or lower an element by a percent of the "line-height" property. Negative values are allowed
    static member inline percentage(value: float) = CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append(string value + "%").Append("; "))
    

    /// The element is aligned with the baseline of the parent. This is default
    static member inline baseline = CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append("baseline").Append("; "))
    

    /// The element is aligned with the lowest element on the line
    static member inline bottom = CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append("bottom").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append("initial").Append("; "))
    

    /// Raises or lower an element by the specified length. Negative values are allowed. Read about length units
    static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append(string value + "px").Append("; "))
    

    /// Raises or lower an element by the specified length. Negative values are allowed. Read about length units
    static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append(value).Append("; "))
    

    /// The element is placed in the middle of the parent element
    static member inline middle = CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append("middle").Append("; "))
    

    /// The element is aligned with the subscript baseline of the parent
    static member inline sub = CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append("sub").Append("; "))
    

    /// The element is aligned with the superscript baseline of the parent
    static member inline super = CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append("super").Append("; "))
    

    /// The element is aligned with the bottom of the parent element's font
    static member inline textBottom = CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append("text-bottom").Append("; "))
    

    /// The element is aligned with the top of the parent element's font
    static member inline textTop = CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append("text-top").Append("; "))
    

    /// The element is aligned with the top of the tallest element on the line
    static member inline top = CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append("top").Append("; "))
    

/// The visibility property specifies whether or not an element is visible.
type visibility =

    /// Only for table rows (
    static member inline collapse = CombineKeyValue(fun sb -> sb.Append("visibility: ").Append("collapse").Append("; "))
    

    /// The element is hidden (but still takes up space)
    static member inline hidden = CombineKeyValue(fun sb -> sb.Append("visibility: ").Append("hidden").Append("; "))
    

    /// Default value. The element is visible
    static member inline visible = CombineKeyValue(fun sb -> sb.Append("visibility: ").Append("visible").Append("; "))
    

/// The white-space property specifies how white-space inside an element is handled.
type whiteSpace =

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("white-space: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("white-space: ").Append("initial").Append("; "))
    

    /// Sequences of whitespace will collapse into a single whitespace. Text will wrap when necessary. This is default
    static member inline normal = CombineKeyValue(fun sb -> sb.Append("white-space: ").Append("normal").Append("; "))
    

    /// Sequences of whitespace will collapse into a single whitespace. Text will never wrap to the next line. The text continues on the same line until a tag is encountered
    static member inline nowrap = CombineKeyValue(fun sb -> sb.Append("white-space: ").Append("nowrap").Append("; "))
    

    /// Whitespace is preserved by the browser. Text will only wrap on line breaks. Acts like the tag in HTML
    static member inline pre = CombineKeyValue(fun sb -> sb.Append("white-space: ").Append("pre").Append("; "))
    

    /// Sequences of whitespace will collapse into a single whitespace. Text will wrap when necessary, and on line breaks
    static member inline preLine = CombineKeyValue(fun sb -> sb.Append("white-space: ").Append("pre-line").Append("; "))
    

    /// Whitespace is preserved by the browser. Text will wrap when necessary, and on line breaks
    static member inline preWrap = CombineKeyValue(fun sb -> sb.Append("white-space: ").Append("pre-wrap").Append("; "))
    

/// The word-break property specifies how words should break when reaching the end of a line.
type wordBreak =

    /// To prevent overflow, word may be broken at any character
    static member inline breakAll = CombineKeyValue(fun sb -> sb.Append("word-break: ").Append("break-all").Append("; "))
    

    /// To prevent overflow, word may be broken at arbitrary points
    static member inline breakWord = CombineKeyValue(fun sb -> sb.Append("word-break: ").Append("break-word").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("word-break: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("word-break: ").Append("initial").Append("; "))
    

    /// Word breaks should not be used for Chinese/Japanese/Korean (CJK) text. Non-CJK text behavior is the same as value "normal"
    static member inline keepAll = CombineKeyValue(fun sb -> sb.Append("word-break: ").Append("keep-all").Append("; "))
    

    /// Default value. Uses default line break rules
    static member inline normal = CombineKeyValue(fun sb -> sb.Append("word-break: ").Append("normal").Append("; "))
    

/// The word-spacing property increases or decreases the white space between words.
type wordSpacing =

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("word-spacing: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("word-spacing: ").Append("initial").Append("; "))
    

    /// Defines an additional space between words (in px, pt, cm, em, etc). Negative values are allowed. Read about length units
    static member inline length(value: int) = CombineKeyValue(fun sb -> sb.Append("word-spacing: ").Append(string value + "px").Append("; "))
    

    /// Defines an additional space between words (in px, pt, cm, em, etc). Negative values are allowed. Read about length units
    static member inline length(value: string) = CombineKeyValue(fun sb -> sb.Append("word-spacing: ").Append(value).Append("; "))
    

    /// Defines normal space between words (0.25em) . This is default
    static member inline normal = CombineKeyValue(fun sb -> sb.Append("word-spacing: ").Append("normal").Append("; "))
    

/// The word-wrap property allows long words to be able to be broken and wrap onto the next line.
type wordWrap =

    /// Allows unbreakable words to be broken
    static member inline breakWord = CombineKeyValue(fun sb -> sb.Append("word-wrap: ").Append("break-word").Append("; "))
    

    /// Inherits this property from its parent element. Read about inherit
    static member inline inherit' = CombineKeyValue(fun sb -> sb.Append("word-wrap: ").Append("inherit").Append("; "))
    

    /// Sets this property to its default value. Read about initial
    static member inline initial = CombineKeyValue(fun sb -> sb.Append("word-wrap: ").Append("initial").Append("; "))
    

    /// Break words only at allowed break points. This is default
    static member inline normal = CombineKeyValue(fun sb -> sb.Append("word-wrap: ").Append("normal").Append("; "))
    

/// The writing-mode property specifies whether lines of text are laid out horizontally or vertically.
type writingMode =

    /// Let the content flow horizontally from left to right, vertically from top to bottom
    static member inline horizontalTb = CombineKeyValue(fun sb -> sb.Append("writing-mode: ").Append("horizontal-tb").Append("; "))
    

    /// Let the content flow vertically from top to bottom, horizontally from left to right
    static member inline verticalLr = CombineKeyValue(fun sb -> sb.Append("writing-mode: ").Append("vertical-lr").Append("; "))
    

    /// Let the content flow vertically from top to bottom, horizontally from right to left
    static member inline verticalRl = CombineKeyValue(fun sb -> sb.Append("writing-mode: ").Append("vertical-rl").Append("; "))
    

