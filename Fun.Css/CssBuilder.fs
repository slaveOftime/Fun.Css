namespace Fun.Css

open System.Text


module Internal =
    type CombineKeyValue = delegate of StringBuilder -> StringBuilder

    /// Merge two togeter
    let inline (&&&) ([<InlineIfLambda>] comb1: CombineKeyValue) ([<InlineIfLambda>] comb2: CombineKeyValue) =
        CombineKeyValue(fun sb -> comb2.Invoke(comb1.Invoke(sb)))

    /// Append key value pair
    let inline (&>>) ([<InlineIfLambda>] comb: CombineKeyValue) (x: string, value: string) =
        CombineKeyValue(fun sb -> comb.Invoke(sb).Append(x).Append(": ").Append(value).Append("; "))


    type Makers =
        static member inline mkPxWithKV(k: string, v: int) = CombineKeyValue(fun sb -> sb.Append(k).Append(": ").Append(v).Append("px; "))

        static member inline mkPxWithKV(k: string, v: float) = CombineKeyValue(fun sb -> sb.Append(k).Append(": ").Append(v).Append("px; "))

        static member inline mkWithKV(k: string, v: int) = CombineKeyValue(fun sb -> sb.Append(k).Append(": ").Append(v).Append("; "))

        static member inline mkWithKV(k: string, v: float) = CombineKeyValue(fun sb -> sb.Append(k).Append(": ").Append(v).Append("; "))


open Internal


/// Contains a list of HTML5 colors from https://htmlcolorcodes.com/color-names/
module color =
    /// Creates a color from components [hue](https://en.wikipedia.org/wiki/Hue), [saturation](https://en.wikipedia.org/wiki/Colorfulness) and [lightness](https://en.wikipedia.org/wiki/Lightness) where hue is a number that goes from 0 to 360 and both
    /// the `saturation` and `lightness` go from 0 to 100 as they are percentages.
    let inline hsl (hue: float, saturation: float, lightness: float) = $"hsl({hue},{saturation}%%,{lightness}%%)"

    let inline rgb (r: int, g: int, b: int) = $"rgb({r},{g},{b})"

    let inline rgba (r: int, g: int, b: int, a: float) = $"rgba({r},{g},{b},{a})"

    [<Literal>]
    let indianRed = "#CD5C5C"

    [<Literal>]
    let lightCoral = "#F08080"

    [<Literal>]
    let salmon = "#FA8072"

    [<Literal>]
    let darkSalmon = "#E9967A"

    [<Literal>]
    let lightSalmon = "#FFA07A"

    [<Literal>]
    let crimson = "#DC143C"

    [<Literal>]
    let red = "#FF0000"

    [<Literal>]
    let fireBrick = "#B22222"

    [<Literal>]
    let darkRed = "#8B0000"

    [<Literal>]
    let pink = "#FFC0CB"

    [<Literal>]
    let lightPink = "#FFB6C1"

    [<Literal>]
    let hotPink = "#FF69B4"

    [<Literal>]
    let deepPink = "#FF1493"

    [<Literal>]
    let mediumVioletRed = "#C71585"

    [<Literal>]
    let paleVioletRed = "#DB7093"

    [<Literal>]
    let coral = "#FF7F50"

    [<Literal>]
    let tomato = "#FF6347"

    [<Literal>]
    let orangeRed = "#FF4500"

    [<Literal>]
    let darkOrange = "#FF8C00"

    [<Literal>]
    let orange = "#FFA500"

    [<Literal>]
    let gold = "#FFD700"

    [<Literal>]
    let yellow = "#FFFF00"

    [<Literal>]
    let lightYellow = "#FFFFE0"

    [<Literal>]
    let limonChiffon = "#FFFACD"

    [<Literal>]
    let lightGoldenRodYellow = "#FAFAD2"

    [<Literal>]
    let papayaWhip = "#FFEFD5"

    [<Literal>]
    let moccasin = "#FFE4B5"

    [<Literal>]
    let peachPuff = "#FFDAB9"

    [<Literal>]
    let paleGoldenRod = "#EEE8AA"

    [<Literal>]
    let khaki = "#F0E68C"

    [<Literal>]
    let darkKhaki = "#BDB76B"

    [<Literal>]
    let lavender = "#E6E6FA"

    [<Literal>]
    let thistle = "#D8BFD8"

    [<Literal>]
    let plum = "#DDA0DD"

    [<Literal>]
    let violet = "#EE82EE"

    [<Literal>]
    let orchid = "#DA70D6"

    [<Literal>]
    let fuchsia = "#FF00FF"

    [<Literal>]
    let magenta = "#FF00FF"

    [<Literal>]
    let mediumOrchid = "#BA55D3"

    [<Literal>]
    let mediumPurple = "#9370DB"

    [<Literal>]
    let rebeccaPurple = "#663399"

    [<Literal>]
    let blueViolet = "#8A2BE2"

    [<Literal>]
    let darkViolet = "#9400D3"

    [<Literal>]
    let darkOrchid = "#9932CC"

    [<Literal>]
    let darkMagenta = "#8B008B"

    [<Literal>]
    let purple = "#800080"

    [<Literal>]
    let indigo = "#4B0082"

    [<Literal>]
    let slateBlue = "#6A5ACD"

    [<Literal>]
    let darkSlateBlue = "#483D8B"

    [<Literal>]
    let mediumSlateBlue = "#7B68EE"

    [<Literal>]
    let greenYellow = "#ADFF2F"

    [<Literal>]
    let chartreuse = "#7FFF00"

    [<Literal>]
    let lawnGreen = "#7CFC00"

    [<Literal>]
    let lime = "#00FF00"

    [<Literal>]
    let limeGreen = "#32CD32"

    [<Literal>]
    let paleGreen = "#98FB98"

    [<Literal>]
    let lightGreen = "#90EE90"

    [<Literal>]
    let mediumSpringGreen = "#00FA9A"

    [<Literal>]
    let springGreen = "#00FF7F"

    [<Literal>]
    let mediumSeaGreen = "#3CB371"

    [<Literal>]
    let seaGreen = "#2E8B57"

    [<Literal>]
    let forestGreen = "#228B22"

    [<Literal>]
    let green = "#008000"

    [<Literal>]
    let darkGreen = "#006400"

    [<Literal>]
    let yellowGreen = "#9ACD32"

    [<Literal>]
    let oliveDrab = "#6B8E23"

    [<Literal>]
    let olive = "#808000"

    [<Literal>]
    let darkOliveGreen = "#556B2F"

    [<Literal>]
    let mediumAquamarine = "#66CDAA"

    [<Literal>]
    let darkSeaGreen = "#8FBC8B"

    [<Literal>]
    let lightSeaGreen = "#20B2AA"

    [<Literal>]
    let darkCyan = "#008B8B"

    [<Literal>]
    let teal = "#008080"

    [<Literal>]
    let aqua = "#00FFFF"

    [<Literal>]
    let cyan = "#00FFFF"

    [<Literal>]
    let lightCyan = "#E0FFFF"

    [<Literal>]
    let paleTurqouise = "#AFEEEE"

    [<Literal>]
    let aquaMarine = "#7FFFD4"

    [<Literal>]
    let turqouise = "#AFEEEE"

    [<Literal>]
    let mediumTurqouise = "#48D1CC"

    [<Literal>]
    let darkTurqouise = "#00CED1"

    [<Literal>]
    let cadetBlue = "#5F9EA0"

    [<Literal>]
    let steelBlue = "#4682B4"

    [<Literal>]
    let lightSteelBlue = "#B0C4DE"

    [<Literal>]
    let powederBlue = "#B0E0E6"

    [<Literal>]
    let lightBlue = "#ADD8E6"

    [<Literal>]
    let skyBlue = "#87CEEB"

    [<Literal>]
    let lightSkyBlue = "#87CEFA"

    [<Literal>]
    let deepSkyBlue = "#00BFFF"

    [<Literal>]
    let dodgerBlue = "#1E90FF"

    [<Literal>]
    let cornFlowerBlue = "#6495ED"

    [<Literal>]
    let royalBlue = "#4169E1"

    [<Literal>]
    let blue = "#0000FF"

    [<Literal>]
    let mediumBlue = "#0000CD"

    [<Literal>]
    let darkBlue = "#00008B"

    [<Literal>]
    let navy = "#000080"

    [<Literal>]
    let midnightBlue = "#191970"

    [<Literal>]
    let cornSilk = "#FFF8DC"

    [<Literal>]
    let blanchedAlmond = "#FFEBCD"

    [<Literal>]
    let bisque = "#FFE4C4"

    [<Literal>]
    let navajoWhite = "#FFDEAD"

    [<Literal>]
    let wheat = "#F5DEB3"

    [<Literal>]
    let burlyWood = "#DEB887"

    [<Literal>]
    let tan = "#D2B48C"

    [<Literal>]
    let rosyBrown = "#BC8F8F"

    [<Literal>]
    let sandyBrown = "#F4A460"

    [<Literal>]
    let goldenRod = "#DAA520"

    [<Literal>]
    let darkGoldenRod = "#B8860B"

    [<Literal>]
    let peru = "#CD853F"

    [<Literal>]
    let chocolate = "#D2691E"

    [<Literal>]
    let saddleBrown = "#8B4513"

    [<Literal>]
    let sienna = "#A0522D"

    [<Literal>]
    let brown = "#A52A2A"

    [<Literal>]
    let maroon = "#A52A2A"

    [<Literal>]
    let white = "#FFFFFF"

    [<Literal>]
    let snow = "#FFFAFA"

    [<Literal>]
    let honeyDew = "#F0FFF0"

    [<Literal>]
    let mintCream = "#F5FFFA"

    [<Literal>]
    let azure = "#F0FFFF"

    [<Literal>]
    let aliceBlue = "#F0F8FF"

    [<Literal>]
    let ghostWhite = "#F8F8FF"

    [<Literal>]
    let whiteSmoke = "#F5F5F5"

    [<Literal>]
    let seaShell = "#FFF5EE"

    [<Literal>]
    let beige = "#F5F5DC"

    [<Literal>]
    let oldLace = "#FDF5E6"

    [<Literal>]
    let floralWhite = "#FFFAF0"

    [<Literal>]
    let ivory = "#FFFFF0"

    [<Literal>]
    let antiqueWhite = "#FAEBD7"

    [<Literal>]
    let linen = "#FAF0E6"

    [<Literal>]
    let lavenderBlush = "#FFF0F5"

    [<Literal>]
    let mistyRose = "#FFE4E1"

    [<Literal>]
    let gainsBoro = "#DCDCDC"

    [<Literal>]
    let lightGray = "#D3D3D3"

    [<Literal>]
    let silver = "#C0C0C0"

    [<Literal>]
    let darkGray = "#A9A9A9"

    [<Literal>]
    let gray = "#808080"

    [<Literal>]
    let dimGray = "#696969"

    [<Literal>]
    let lightSlateGray = "#778899"

    [<Literal>]
    let slateGray = "#708090"

    [<Literal>]
    let darkSlateGray = "#2F4F4F"

    [<Literal>]
    let black = "#000000"

    [<Literal>]
    let transparent = "transparent"

/// Contains a list of CSS Fonts from https://www.tutorialbrain.com/css_tutorial/css_font_family_list/
module font =
    [<Literal>]
    let abadiMTCondensedLight = "Abadi MT Condensed Light"

    [<Literal>]
    let aharoni = "Aharoni"

    [<Literal>]
    let aharoniBold = "Aharoni Bold"

    [<Literal>]
    let aldhabi = "Aldhabi"

    [<Literal>]
    let alternateGothic2BT = "AlternateGothic2 BT"

    [<Literal>]
    let andaleMono = "Andale Mono"

    [<Literal>]
    let andalus = "Andalus"

    [<Literal>]
    let angsanaNew = "Angsana New"

    [<Literal>]
    let angsanaUPC = "AngsanaUPC"

    [<Literal>]
    let aparajita = "Aparajita"

    [<Literal>]
    let appleChancery = "Apple Chancery"

    [<Literal>]
    let arabicTypesetting = "Arabic Typesetting"

    [<Literal>]
    let arial = "Arial"

    [<Literal>]
    let arialBlack = "Arial Black"

    [<Literal>]
    let arialNarrow = "Arial narrow"

    [<Literal>]
    let arialNova = "Arial Nova"

    [<Literal>]
    let arialRoundedMTBold = "Arial Rounded MT Bold"

    [<Literal>]
    let arnoldboecklin = "Arnoldboecklin"

    [<Literal>]
    let avantaGarde = "Avanta Garde"

    [<Literal>]
    let bahnschrift = "Bahnschrift"

    [<Literal>]
    let bahnschriftLight = "Bahnschrift Light"

    [<Literal>]
    let bahnschriftSemiBold = "Bahnschrift SemiBold"

    [<Literal>]
    let bahnschriftSemiLight = "Bahnschrift SemiLight"

    [<Literal>]
    let baskerville = "Baskerville"

    [<Literal>]
    let batang = "Batang"

    [<Literal>]
    let batangChe = "BatangChe"

    [<Literal>]
    let bigCaslon = "Big Caslon"

    [<Literal>]
    let bizUDGothic = "BIZ UDGothic"

    [<Literal>]
    let bizUDMinchoMedium = "BIZ UDMincho Medium"

    [<Literal>]
    let blippo = "Blippo"

    [<Literal>]
    let bodoniMT = "Bodoni MT"

    [<Literal>]
    let bookAntiqua = "Book Antiqua"

    [<Literal>]
    let Bookman = "Bookman"

    [<Literal>]
    let bradlyHand = "Bradley Hand"

    [<Literal>]
    let browalliaNew = "Browallia New"

    [<Literal>]
    let browalliaUPC = "BrowalliaUPC"

    [<Literal>]
    let brushScriptMT = "Brush Script MT"

    [<Literal>]
    let brushScriptStd = "Brush Script Std"

    [<Literal>]
    let brushStroke = "Brushstroke"

    [<Literal>]
    let calibri = "Calibri"

    [<Literal>]
    let calibriLight = "Calibri Light"

    [<Literal>]
    let calistoMT = "Calisto MT"

    [<Literal>]
    let cambodian = "Cambodian"

    [<Literal>]
    let cambria = "Cambria"

    [<Literal>]
    let cambriaMath = "Cambria Math"

    [<Literal>]
    let candara = "Candara"

    [<Literal>]
    let centuryGothic = "Century Gothic"

    [<Literal>]
    let chalkDuster = "Chalkduster"

    [<Literal>]
    let cherokee = "Cherokee"

    [<Literal>]
    let comicSans = "Comic Sans"

    [<Literal>]
    let comicSansMS = "Comic Sans MS"

    [<Literal>]
    let consolas = "Consolas"

    [<Literal>]
    let constantia = "Constantia"

    [<Literal>]
    let copperPlate = "Copperplate"

    [<Literal>]
    let copperPlateGothicLight = "Copperplate Gothic Light"

    [<Literal>]
    let copperPlateGothicBold = "Copperplate Gothic Bold"

    [<Literal>]
    let corbel = "Corbel"

    [<Literal>]
    let cordiaNew = "Cordia New"

    [<Literal>]
    let cordiaUPC = "CordiaUPC"

    [<Literal>]
    let coronetScript = "Coronet script"

    [<Literal>]
    let courier = "Courier"

    [<Literal>]
    let courierNew = "Courier New"

    [<Literal>]
    let daunPenh = "DaunPenh"

    [<Literal>]
    let david = "David"

    [<Literal>]
    let dengXian = "DengXian"

    [<Literal>]
    let dfKaiSB = "DFKai-SB"

    [<Literal>]
    let didot = "Didot"

    [<Literal>]
    let dilleniaUPC = "DilleniaUPC"

    [<Literal>]
    let dokChampa = "DokChampa"

    [<Literal>]
    let dotum = "Dotum"

    [<Literal>]
    let dotumChe = "DotumChe"

    [<Literal>]
    let ebrima = "Ebrima"

    [<Literal>]
    let estrangeloEdessa = "Estrangelo Edessa"

    [<Literal>]
    let eucrosiaUPC = "EucrosiaUPC"

    [<Literal>]
    let euphemia = "Euphemia"

    [<Literal>]
    let fangSong = "FangSong"

    [<Literal>]
    let florence = "Florence"

    [<Literal>]
    let franklinGothicMedium = "Franklin Gothic Medium"

    [<Literal>]
    let frankRuehl = "FrankRuehl"

    [<Literal>]
    let fressiaUPC = "FressiaUPC"

    [<Literal>]
    let futara = "Futara"

    [<Literal>]
    let gabriola = "Gabriola"

    [<Literal>]
    let garamond = "Garamond"

    [<Literal>]
    let gautami = "Gautami"

    [<Literal>]
    let geneva = "Geneva"

    [<Literal>]
    let georgia = "Georgia"

    [<Literal>]
    let georgiaPro = "Georgia Pro"

    [<Literal>]
    let gillSans = "Gill Sans"

    [<Literal>]
    let gillSansNova = "Gill Sans Nova"

    [<Literal>]
    let gisha = "Gisha"

    [<Literal>]
    let goudyOldStyle = "Goudy Old Style"

    [<Literal>]
    let gulim = "Gulim"

    [<Literal>]
    let gulimChe = "GulimChe"

    [<Literal>]
    let gungsuh = "Gungsuh"

    [<Literal>]
    let gungsuhChe = "GungsuhChe"

    [<Literal>]
    let hebrew = "Hebrew"

    [<Literal>]
    let helvetica = "Helvetica"

    [<Literal>]
    let hoeflerText = "Hoefler Text"

    [<Literal>]
    let holoLensMDL2Assets = "HoloLens MDL2 Assets"

    [<Literal>]
    let impact = "Impact"

    [<Literal>]
    let inkFree = "Ink Free"

    [<Literal>]
    let irisUPC = "IrisUPC"

    [<Literal>]
    let iskoolaPota = "Iskoola Pota"

    [<Literal>]
    let japanese = "Japanese"

    [<Literal>]
    let jasmineUPC = "JasmineUPC"

    [<Literal>]
    let javaneseText = "Javanese Text"

    [<Literal>]
    let jazzLET = "Jazz LET"

    [<Literal>]
    let kaiTi = "KaiTi"

    [<Literal>]
    let kalinga = "Kalinga"

    [<Literal>]
    let kartika = "Kartika"

    [<Literal>]
    let khmerUI = "Khmer UI"

    [<Literal>]
    let kodchiangUPC = "KodchiangUPC"

    [<Literal>]
    let kokila = "Kokila"

    [<Literal>]
    let korean = "Korean"

    [<Literal>]
    let lao = "Lao"

    [<Literal>]
    let laoUI = "Lao UI"

    [<Literal>]
    let latha = "Latha"

    [<Literal>]
    let leelawadee = "Leelawadee"

    [<Literal>]
    let leelawadeeUI = "Leelawadee UI"

    [<Literal>]
    let leelawadeeUISemilight = "Leelawadee UI Semilight"

    [<Literal>]
    let levenimMT = "Levenim MT"

    [<Literal>]
    let lilyUPC = "LilyUPC"

    [<Literal>]
    let lucidaBright = "Lucida Bright"

    [<Literal>]
    let lucidaConsole = "Lucida Console"

    [<Literal>]
    let lucidaHandwriting = "Lucida Handwriting"

    [<Literal>]
    let lucidaSans = "Lucida Sans"

    [<Literal>]
    let lucidaSansTypewriter = "Lucida Sans Typewriter"

    [<Literal>]
    let lucidaSansUnicode = "Lucida Sans Unicode"

    [<Literal>]
    let lucidaTypewriter = "Lucidatypewriter"

    [<Literal>]
    let luminari = "Luminari"

    [<Literal>]
    let malgunGothic = "Malgun Gothic"

    [<Literal>]
    let malgunGothicSemilight = "Malgun Gothic Semilight"

    [<Literal>]
    let mangal = "Mangal"

    [<Literal>]
    let markerFelt = "Marker Felt"

    [<Literal>]
    let marlett = "Marlett"

    [<Literal>]
    let meiryo = "Meiryo"

    [<Literal>]
    let meiryoUI = "Meiryo UI"

    [<Literal>]
    let microsoftHimalaya = "Microsoft Himalaya"

    [<Literal>]
    let microsoftJhengHei = "Microsoft JhengHei"

    [<Literal>]
    let microsoftJhengHeiUI = "Microsoft JhengHei UI"

    [<Literal>]
    let microsoftNewTaiLue = "Microsoft New Tai Lue"

    [<Literal>]
    let microsoftPhagsPa = "Microsoft PhagsPa"

    [<Literal>]
    let microsoftSansSerif = "Microsoft Sans Serif"

    [<Literal>]
    let microsoftTaiLe = "Microsoft Tai Le"

    [<Literal>]
    let microsoftUighur = "Microsoft Uighur"

    [<Literal>]
    let microsoftYaHei = "Microsoft YaHei"

    [<Literal>]
    let microsoftYaHeiUI = "Microsoft YaHei UI"

    [<Literal>]
    let microsoftYiBaiti = "Microsoft Yi Baiti"

    [<Literal>]
    let mingLiU = "MingLiU"

    [<Literal>]
    let mingLiUHKSCS = "MingLiU_HKSCS"

    [<Literal>]
    let mingLiUHKSCSExtB = "MingLiU_HKSCS-ExtB"

    [<Literal>]
    let mingLiUExtB = "MingLiU-ExtB"

    [<Literal>]
    let miriam = "Miriam"

    [<Literal>]
    let monaco = "Monaco"

    [<Literal>]
    let mongolianBaiti = "Mongolian Baiti"

    [<Literal>]
    let moolBoran = "MoolBoran"

    [<Literal>]
    let msGothic = "MS Gothic"

    [<Literal>]
    let msMincho = "MS Mincho"

    [<Literal>]
    let msPGothic = "MS PGothic"

    [<Literal>]
    let msPMincho = "MS PMincho"

    [<Literal>]
    let msUIGothic = "MS UI Gothic"

    [<Literal>]
    let mvBoli = "MV Boli"

    [<Literal>]
    let myanmarText = "Myanmar Text"

    [<Literal>]
    let narkisim = "Narkisim"

    [<Literal>]
    let neueHaasGroteskTextPro = "Neue Haas Grotesk Text Pro"

    [<Literal>]
    let newCenturySchoolbook = "New Century Schoolbook"

    [<Literal>]
    let newsGothicMT = "News Gothic MT"

    [<Literal>]
    let nirmalaUI = "Nirmala UI"

    [<Literal>]
    let noAutoLanguageAssoc = "No automatic language associations"

    [<Literal>]
    let noto = "Noto"

    [<Literal>]
    let nSimSun = "NSimSun"

    [<Literal>]
    let nyala = "Nyala"

    [<Literal>]
    let oldTown = "Oldtown"

    [<Literal>]
    let optima = "Optima"

    [<Literal>]
    let palatino = "Palatino"

    [<Literal>]
    let palatinoLinotype = "Palatino Linotype"

    [<Literal>]
    let papyrus = "papyrus"

    [<Literal>]
    let parkAvenue = "Parkavenue"

    [<Literal>]
    let perpetua = "Perpetua"

    [<Literal>]
    let plantagenetCherokee = "Plantagenet Cherokee"

    [<Literal>]
    let PMingLiU = "PMingLiU"

    [<Literal>]
    let raavi = "Raavi"

    [<Literal>]
    let rockwell = "Rockwell"

    [<Literal>]
    let rockwellExtraBold = "Rockwell Extra Bold"

    [<Literal>]
    let rockwellNova = "Rockwell Nova"

    [<Literal>]
    let rockwellNovaCond = "Rockwell Nova Cond"

    [<Literal>]
    let rockwellNovaExtraBold = "Rockwell Nova Extra Bold"

    [<Literal>]
    let rod = "Rod"

    [<Literal>]
    let sakkalMajalla = "Sakkal Majalla"

    [<Literal>]
    let sanskritText = "Sanskrit Text"

    [<Literal>]
    let segoeMDL2Assets = "segoeMDL2Assets"

    [<Literal>]
    let segoePrint = "Segoe Print"

    [<Literal>]
    let segoeScript = "Segoe Script"

    [<Literal>]
    let segoeUI = "Segoe UI"

    [<Literal>]
    let segoeUIEmoji = "Segoe UI Emoji"

    [<Literal>]
    let segoeUIHistoric = "Segoe UI Historic"

    [<Literal>]
    let segoeUISymbol = "Segoe UI Symbol"

    [<Literal>]
    let shonarBangla = "Shonar Bangla"

    [<Literal>]
    let shruti = "Shruti"

    [<Literal>]
    let simHei = "SimHei"

    [<Literal>]
    let simKai = "SimKai"

    [<Literal>]
    let simplifiedArabic = "Simplified Arabic"

    [<Literal>]
    let simplifiedChinese = "Simplified Chinese"

    [<Literal>]
    let simSun = "SimSun"

    [<Literal>]
    let simSunExtB = "SimSun-ExtB"

    [<Literal>]
    let sitka = "Sitka"

    [<Literal>]
    let snellRoundhan = "Snell Roundhan"

    [<Literal>]
    let stencilStd = "Stencil Std"

    [<Literal>]
    let sylfaen = "Sylfaen"

    [<Literal>]
    let symbol = "Symbol"

    [<Literal>]
    let tahoma = "Tahoma"

    [<Literal>]
    let thai = "Thai"

    [<Literal>]
    let timesNewRoman = "Times New Roman"

    [<Literal>]
    let traditionalArabic = "Traditional Arabic"

    [<Literal>]
    let traditionalChinese = "Traditional Chinese"

    [<Literal>]
    let trattatello = "Trattatello"

    [<Literal>]
    let trebuchetMS = "Trebuchet MS"

    [<Literal>]
    let udDigiKyokasho = "UD Digi Kyokasho"

    [<Literal>]
    let udDigiKyokashoNKR = "UD Digi Kyokasho NK-R"

    [<Literal>]
    let udDigiKyokashoNPR = "UD Digi Kyokasho NP-R"

    [<Literal>]
    let udDigiKyokashoNR = "UD Digi Kyokasho N-R"

    [<Literal>]
    let urduTypesetting = "Urdu Typesetting"

    [<Literal>]
    let urwChancery = "URW Chancery"

    [<Literal>]
    let utsaah = "Utsaah"

    [<Literal>]
    let vani = "Vani"

    [<Literal>]
    let verdana = "Verdana"

    [<Literal>]
    let verdanaPro = "Verdana Pro"

    [<Literal>]
    let vijaya = "Vijaya"

    [<Literal>]
    let vrinda = "Vrinda"

    [<Literal>]
    let Webdings = "Webdings"

    [<Literal>]
    let westminster = "Westminster"

    [<Literal>]
    let wingdings = "Wingdings"

    [<Literal>]
    let yuGothic = "Yu Gothic"

    [<Literal>]
    let yuGothicUI = "Yu Gothic UI"

    [<Literal>]
    let yuMincho = "Yu Mincho"

    [<Literal>]
    let zapfChancery = "Zapf Chancery"


type CssBuilder() =

    member inline _.Yield(_: unit) = CombineKeyValue(fun sb -> sb)
    member inline _.Yield([<InlineIfLambda>] x: CombineKeyValue) = x
    member inline _.Yield(keyValue: string) = CombineKeyValue(fun s -> s.Append(keyValue).Append("; "))

    member inline _.Yield((key, value): string * string) = CombineKeyValue(fun s -> s.Append(key).Append(": ").Append(value).Append("; "))
    member inline _.Yield((key, value): string * int) = CombineKeyValue(fun s -> s.Append(key).Append(": ").Append(value).Append("; "))
    member inline _.Yield((key, value): string * float) = CombineKeyValue(fun s -> s.Append(key).Append(": ").Append(value).Append("; "))
    member inline _.Yield((key, value): string * bool) = CombineKeyValue(fun s -> s.Append(key).Append(": ").Append(value).Append("; "))

    member inline _.Run([<InlineIfLambda>] combine: CombineKeyValue) = combine

    member inline _.For([<InlineIfLambda>] comb: CombineKeyValue, [<InlineIfLambda>] fn: unit -> CombineKeyValue) = comb &&& (fn ())

    member inline _.For(ls: 'T seq, [<InlineIfLambda>] fn: 'T -> CombineKeyValue) = ls |> Seq.map fn |> Seq.fold (&&&) (CombineKeyValue(fun x -> x))

    member inline _.Delay([<InlineIfLambda>] fn: unit -> CombineKeyValue) = CombineKeyValue(fun x -> fn().Invoke(x))

    member inline _.Zero() = CombineKeyValue(fun sb -> sb)

    member inline _.Combine([<InlineIfLambda>] render1: CombineKeyValue, [<InlineIfLambda>] render2: CombineKeyValue) = render1 &&& render2


    /// Define a custom property
    [<CustomOperation("custom")>]
    member inline _.custom([<InlineIfLambda>] comb: CombineKeyValue, key: string, value: string) = comb &>> (key, value)

    ///  The width property sets the width of an element. 
    [<CustomOperation("zIndex")>]
    member inline _.zIndex([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("z-index: ").Append(value).Append("; "))
    
    ///  The width property sets the width of an element. 
    [<CustomOperation("opacity")>]
    member inline _.opacity([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("opacity: ").Append(value).Append("; "))
    
    ///  The width property sets the width of an element. s
    [<CustomOperation("flex")>]
    member inline _.flex([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex: ").Append(value).Append("; "))
    
    
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top, padding-right, padding-bottom, and padding-left.
    [<CustomOperation("padding")>]
    member inline _.padding([<InlineIfLambda>] comb: CombineKeyValue, v1: string, v2: string, ?v3: string, ?v4: string) =
        CombineKeyValue(fun sb ->
            let sb = 
                comb
                    .Invoke(sb)
                    .Append("padding: ")
                    .Append(v1)
                    .Append(" ")
                    .Append(v2)
                
            match v3, v4 with
            | None, None -> ()
            | Some v3, None -> sb.Append(" ").Append(v3) |> ignore
            | Some v3, Some v4 -> sb.Append(" ").Append(v3).Append(" ").Append(v4) |> ignore
            | _, Some _ -> ()

            sb.Append("; ")
        )

    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top, padding-right, padding-bottom, and padding-left.
    [<CustomOperation("padding")>]
    member inline _.padding([<InlineIfLambda>] comb: CombineKeyValue, v1: int, v2: int, ?v3: int, ?v4: int) =
        CombineKeyValue(fun sb ->
            let sb = 
                comb
                    .Invoke(sb)
                    .Append("padding: ")
                    .Append(v1)
                    .Append("px ")
                    .Append(v2)
                    .Append("px")
                
            match v3, v4 with
            | None, None -> ()
            | Some v3, None -> sb.Append(" ").Append(v3).Append("px") |> ignore
            | Some v3, Some v4 -> sb.Append(" ").Append(v3).Append("px ").Append(v4).Append("px") |> ignore
            | _, Some _ -> ()

            sb.Append("; ")
        )

    
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right, margin-bottom, and margin-left.
    [<CustomOperation("margin")>]
    member inline _.margin([<InlineIfLambda>] comb: CombineKeyValue, v1: string, v2: string, ?v3: string, ?v4: string) =
        CombineKeyValue(fun sb ->
            let sb = 
                comb
                    .Invoke(sb)
                    .Append("margin: ")
                    .Append(v1)
                    .Append(" ")
                    .Append(v2)
                
            match v3, v4 with
            | None, None -> ()
            | Some v3, None -> sb.Append(" ").Append(v3) |> ignore
            | Some v3, Some v4 -> sb.Append(" ").Append(v3).Append(" ").Append(v4) |> ignore
            | _, Some _ -> ()

            sb.Append("; ")
        )

    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right, margin-bottom, and margin-left.
    [<CustomOperation("margin")>]
    member inline _.margin([<InlineIfLambda>] comb: CombineKeyValue, v1: int, v2: int, ?v3: int, ?v4: int) =
        CombineKeyValue(fun sb ->
            let sb = 
                comb
                    .Invoke(sb)
                    .Append("margin: ")
                    .Append(v1)
                    .Append("px ")
                    .Append(v2)
                    .Append("px")
                
            match v3, v4 with
            | None, None -> ()
            | Some v3, None -> sb.Append(" ").Append(v3).Append("px") |> ignore
            | Some v3, Some v4 -> sb.Append(" ").Append(v3).Append("px ").Append(v4).Append("px") |> ignore
            | _, Some _ -> ()

            sb.Append("; ")
        )


    // Auto generated

    ///  The @charset rule specifies the character encoding used in the style sheet. 
    [<CustomOperation("charset")>]
    member inline _.charset([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("@charset: ").Append(value).Append("; "))

    ///  With the @font-face rule, web designers do not have to use one of the "web-safe" fonts anymore. 
    [<CustomOperation("fontFace")>]
    member inline _.fontFace([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("@font-face: ").Append(value).Append("; "))

    ///  The @import rule allows you to import a style sheet into another style sheet. 
    [<CustomOperation("import")>]
    member inline _.import([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("@import: ").Append(value).Append("; "))

    /// The @import rule allows you to import a style sheet into another style sheet.
    [<CustomOperation("importListOfMediaqueries")>]
    member inline _.importListOfMediaqueries([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("@import: ").Append(defaultArg value "list-of-mediaqueries").Append("; "))

    /// The @import rule allows you to import a style sheet into another style sheet.
    [<CustomOperation("importUrl")>]
    member inline _.importUrl([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("@import: ").Append(value).Append("; "))

    ///  The @keyframes rule specifies the animation code. 
    [<CustomOperation("keyframes")>]
    member inline _.keyframes([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("@keyframes: ").Append(value).Append("; "))

    /// The @keyframes rule specifies the animation code.
    [<CustomOperation("keyframesAnimationname")>]
    member inline _.keyframesAnimationname([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("@keyframes: ").Append(defaultArg value "animationname").Append("; "))

    /// The @keyframes rule specifies the animation code.
    [<CustomOperation("keyframesCssStyles")>]
    member inline _.keyframesCssStyles([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("@keyframes: ").Append(defaultArg value "css-styles").Append("; "))

    /// The @keyframes rule specifies the animation code.
    [<CustomOperation("keyframesKeyframesSelector")>]
    member inline _.keyframesKeyframesSelector([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("@keyframes: ").Append(defaultArg value "keyframes-selector").Append("; "))

    ///  The @media rule is used in media queries to apply different styles for different media types/devices. 
    [<CustomOperation("media")>]
    member inline _.media([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("@media: ").Append(value).Append("; "))

    ///  The accent-color property specifies the accent color for user-interface controls like: , ,  and . 
    [<CustomOperation("accentColor")>]
    member inline _.accentColor([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("accent-color: ").Append(value).Append("; "))

    /// The accent-color property specifies the accent color for user-interface controls like: , ,  and .
    [<CustomOperation("accentColorAuto")>]
    member inline _.accentColorAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("accent-color: ").Append("auto").Append("; "))

    /// The accent-color property specifies the accent color for user-interface controls like: , ,  and .
    [<CustomOperation("accentColorColor")>]
    member inline _.accentColorColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("accent-color: ").Append(defaultArg value "color").Append("; "))

    /// The accent-color property specifies the accent color for user-interface controls like: , ,  and .
    [<CustomOperation("accentColorInherit")>]
    member inline _.accentColorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("accent-color: ").Append("inherit").Append("; "))

    /// The accent-color property specifies the accent color for user-interface controls like: , ,  and .
    [<CustomOperation("accentColorInitial")>]
    member inline _.accentColorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("accent-color: ").Append("initial").Append("; "))

    ///  The align-content property specifies how flex lines are distributed along the cross axis in a flexbox container. 
    [<CustomOperation("alignContent")>]
    member inline _.alignContent([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-content: ").Append(value).Append("; "))

    /// The align-content property specifies how flex lines are distributed along the cross axis in a flexbox container.
    [<CustomOperation("alignContentCenter")>]
    member inline _.alignContentCenter([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-content: ").Append(defaultArg value "center").Append("; "))

    /// The align-content property specifies how flex lines are distributed along the cross axis in a flexbox container.
    [<CustomOperation("alignContentFlexEnd")>]
    member inline _.alignContentFlexEnd([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-content: ").Append(defaultArg value "flex-end").Append("; "))

    /// The align-content property specifies how flex lines are distributed along the cross axis in a flexbox container.
    [<CustomOperation("alignContentFlexStart")>]
    member inline _.alignContentFlexStart([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-content: ").Append(defaultArg value "flex-start").Append("; "))

    /// The align-content property specifies how flex lines are distributed along the cross axis in a flexbox container.
    [<CustomOperation("alignContentInherit")>]
    member inline _.alignContentInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-content: ").Append("inherit").Append("; "))

    /// The align-content property specifies how flex lines are distributed along the cross axis in a flexbox container.
    [<CustomOperation("alignContentInitial")>]
    member inline _.alignContentInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-content: ").Append("initial").Append("; "))

    /// The align-content property specifies how flex lines are distributed along the cross axis in a flexbox container.
    [<CustomOperation("alignContentSpaceAround")>]
    member inline _.alignContentSpaceAround([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-content: ").Append(defaultArg value "space-around").Append("; "))

    /// The align-content property specifies how flex lines are distributed along the cross axis in a flexbox container.
    [<CustomOperation("alignContentSpaceBetween")>]
    member inline _.alignContentSpaceBetween([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-content: ").Append(defaultArg value "space-between").Append("; "))

    /// The align-content property specifies how flex lines are distributed along the cross axis in a flexbox container.
    [<CustomOperation("alignContentSpaceEvenly")>]
    member inline _.alignContentSpaceEvenly([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-content: ").Append(defaultArg value "space-evenly").Append("; "))

    /// The align-content property specifies how flex lines are distributed along the cross axis in a flexbox container.
    [<CustomOperation("alignContentStretch")>]
    member inline _.alignContentStretch([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-content: ").Append(defaultArg value "stretch").Append("; "))

    ///  The align-items property specifies the default alignment for items inside a flexbox or grid container. 
    [<CustomOperation("alignItems")>]
    member inline _.alignItems([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-items: ").Append(value).Append("; "))

    /// The align-items property specifies the default alignment for items inside a flexbox or grid container.
    [<CustomOperation("alignItemsBaseline")>]
    member inline _.alignItemsBaseline([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-items: ").Append(defaultArg value "baseline").Append("; "))

    /// The align-items property specifies the default alignment for items inside a flexbox or grid container.
    [<CustomOperation("alignItemsCenter")>]
    member inline _.alignItemsCenter([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-items: ").Append(defaultArg value "center").Append("; "))

    /// The align-items property specifies the default alignment for items inside a flexbox or grid container.
    [<CustomOperation("alignItemsEnd")>]
    member inline _.alignItemsEnd([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-items: ").Append(defaultArg value "end").Append("; "))

    /// The align-items property specifies the default alignment for items inside a flexbox or grid container.
    [<CustomOperation("alignItemsFlexEnd")>]
    member inline _.alignItemsFlexEnd([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-items: ").Append(defaultArg value "flex-end").Append("; "))

    /// The align-items property specifies the default alignment for items inside a flexbox or grid container.
    [<CustomOperation("alignItemsFlexStart")>]
    member inline _.alignItemsFlexStart([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-items: ").Append(defaultArg value "flex-start").Append("; "))

    /// The align-items property specifies the default alignment for items inside a flexbox or grid container.
    [<CustomOperation("alignItemsInherit")>]
    member inline _.alignItemsInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-items: ").Append("inherit").Append("; "))

    /// The align-items property specifies the default alignment for items inside a flexbox or grid container.
    [<CustomOperation("alignItemsInitial")>]
    member inline _.alignItemsInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-items: ").Append("initial").Append("; "))

    /// The align-items property specifies the default alignment for items inside a flexbox or grid container.
    [<CustomOperation("alignItemsNormal")>]
    member inline _.alignItemsNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-items: ").Append(defaultArg value "normal").Append("; "))

    /// The align-items property specifies the default alignment for items inside a flexbox or grid container.
    [<CustomOperation("alignItemsStart")>]
    member inline _.alignItemsStart([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-items: ").Append(defaultArg value "start").Append("; "))

    /// The align-items property specifies the default alignment for items inside a flexbox or grid container.
    [<CustomOperation("alignItemsStretch")>]
    member inline _.alignItemsStretch([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-items: ").Append(defaultArg value "stretch").Append("; "))

    ///  The align-self property specifies the alignment in the block direction for the selected item inside a flexbox or grid container. 
    [<CustomOperation("alignSelf")>]
    member inline _.alignSelf([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-self: ").Append(value).Append("; "))

    /// The align-self property specifies the alignment in the block direction for the selected item inside a flexbox or grid container.
    [<CustomOperation("alignSelfAuto")>]
    member inline _.alignSelfAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-self: ").Append("auto").Append("; "))

    /// The align-self property specifies the alignment in the block direction for the selected item inside a flexbox or grid container.
    [<CustomOperation("alignSelfBaseline")>]
    member inline _.alignSelfBaseline([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-self: ").Append(defaultArg value "baseline").Append("; "))

    /// The align-self property specifies the alignment in the block direction for the selected item inside a flexbox or grid container.
    [<CustomOperation("alignSelfCenter")>]
    member inline _.alignSelfCenter([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-self: ").Append(defaultArg value "center").Append("; "))

    /// The align-self property specifies the alignment in the block direction for the selected item inside a flexbox or grid container.
    [<CustomOperation("alignSelfFlexEnd")>]
    member inline _.alignSelfFlexEnd([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-self: ").Append(defaultArg value "flex-end").Append("; "))

    /// The align-self property specifies the alignment in the block direction for the selected item inside a flexbox or grid container.
    [<CustomOperation("alignSelfFlexStart")>]
    member inline _.alignSelfFlexStart([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-self: ").Append(defaultArg value "flex-start").Append("; "))

    /// The align-self property specifies the alignment in the block direction for the selected item inside a flexbox or grid container.
    [<CustomOperation("alignSelfInherit")>]
    member inline _.alignSelfInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-self: ").Append("inherit").Append("; "))

    /// The align-self property specifies the alignment in the block direction for the selected item inside a flexbox or grid container.
    [<CustomOperation("alignSelfInitial")>]
    member inline _.alignSelfInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-self: ").Append("initial").Append("; "))

    /// The align-self property specifies the alignment in the block direction for the selected item inside a flexbox or grid container.
    [<CustomOperation("alignSelfStretch")>]
    member inline _.alignSelfStretch([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("align-self: ").Append(defaultArg value "stretch").Append("; "))

    ///  The all property resets all properties, apart from unicode-bidi and direction, to their initial or inherited value. 
    [<CustomOperation("all")>]
    member inline _.all([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("all: ").Append(value).Append("; "))

    /// The all property resets all properties, apart from unicode-bidi and direction, to their initial or inherited value.
    [<CustomOperation("allInherit")>]
    member inline _.allInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("all: ").Append("inherit").Append("; "))

    /// The all property resets all properties, apart from unicode-bidi and direction, to their initial or inherited value.
    [<CustomOperation("allInitial")>]
    member inline _.allInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("all: ").Append("initial").Append("; "))

    /// The all property resets all properties, apart from unicode-bidi and direction, to their initial or inherited value.
    [<CustomOperation("allUnset")>]
    member inline _.allUnset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("all: ").Append(defaultArg value "unset").Append("; "))

    ///  The animation property is a shorthand property for: 
    [<CustomOperation("animation")>]
    member inline _.animation([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation: ").Append(value).Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("animationDelayInherit")>]
    member inline _.animationDelayInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-delay: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("animationDelayInitial")>]
    member inline _.animationDelayInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-delay: ").Append("initial").Append("; "))

    /// Optional. Defines the number of seconds (s) or milliseconds (ms) to wait before the animation will start. Default value is 0. Negative values are allowed. If you use negative values, the animation will start as if it had already been playing for N seconds/milliseconds.
    [<CustomOperation("animationDelayTime")>]
    member inline _.animationDelayTime([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-delay: ").Append(value).Append("; "))

    /// The animation is played forwards first, then backwards
    [<CustomOperation("animationDirectionAlternate")>]
    member inline _.animationDirectionAlternate([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-direction: ").Append(defaultArg value "alternate").Append("; "))

    /// The animation is played backwards first, then forwards
    [<CustomOperation("animationDirectionAlternateReverse")>]
    member inline _.animationDirectionAlternateReverse([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-direction: ").Append(defaultArg value "alternate-reverse").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("animationDirectionInherit")>]
    member inline _.animationDirectionInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-direction: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("animationDirectionInitial")>]
    member inline _.animationDirectionInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-direction: ").Append("initial").Append("; "))

    /// Default value. The animation is played as normal (forwards)
    [<CustomOperation("animationDirectionNormal")>]
    member inline _.animationDirectionNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-direction: ").Append(defaultArg value "normal").Append("; "))

    /// The animation is played in reverse direction (backwards)
    [<CustomOperation("animationDirectionReverse")>]
    member inline _.animationDirectionReverse([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-direction: ").Append(defaultArg value "reverse").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("animationDurationInherit")>]
    member inline _.animationDurationInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-duration: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("animationDurationInitial")>]
    member inline _.animationDurationInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-duration: ").Append("initial").Append("; "))

    /// Specifies the length of time an animation should take to complete one cycle. This can be specified in seconds or milliseconds. Default value is 0, which means that no animation will occur
    [<CustomOperation("animationDurationTime")>]
    member inline _.animationDurationTime([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-duration: ").Append(value).Append("; "))

    /// The element will get the style values that is set by the first keyframe (depends on animation-direction), and retain this during the animation-delay period
    [<CustomOperation("animationFillModeBackwards")>]
    member inline _.animationFillModeBackwards([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-fill-mode: ").Append(defaultArg value "backwards").Append("; "))

    /// The animation will follow the rules for both forwards and backwards, extending the animation properties in both directions
    [<CustomOperation("animationFillModeBoth")>]
    member inline _.animationFillModeBoth([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-fill-mode: ").Append(defaultArg value "both").Append("; "))

    /// The element will retain the style values that is set by the last keyframe (depends on animation-direction and animation-iteration-count)
    [<CustomOperation("animationFillModeForwards")>]
    member inline _.animationFillModeForwards([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-fill-mode: ").Append(defaultArg value "forwards").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("animationFillModeInherit")>]
    member inline _.animationFillModeInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-fill-mode: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("animationFillModeInitial")>]
    member inline _.animationFillModeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-fill-mode: ").Append("initial").Append("; "))

    /// Default value. Animation will not apply any styles to the element before or after it is executing
    [<CustomOperation("animationFillModeNone")>]
    member inline _.animationFillModeNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-fill-mode: ").Append(defaultArg value "none").Append("; "))

    /// Specifies that the animation should be played infinite times (for ever)
    [<CustomOperation("animationIterationCountInfinite")>]
    member inline _.animationIterationCountInfinite([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-iteration-count: ").Append(defaultArg value "infinite").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("animationIterationCountInherit")>]
    member inline _.animationIterationCountInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-iteration-count: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("animationIterationCountInitial")>]
    member inline _.animationIterationCountInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-iteration-count: ").Append("initial").Append("; "))

    /// A number that defines how many times an animation should be played. Default value is 1
    [<CustomOperation("animationIterationCountNumber")>]
    member inline _.animationIterationCountNumber([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-iteration-count: ").Append(value).Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("animationNameInherit")>]
    member inline _.animationNameInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-name: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("animationNameInitial")>]
    member inline _.animationNameInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-name: ").Append("initial").Append("; "))

    /// Specifies the name of the keyframe you want to bind to the selector
    [<CustomOperation("animationNameKeyframename")>]
    member inline _.animationNameKeyframename([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-name: ").Append(defaultArg value "keyframename").Append("; "))

    /// Default value. Specifies that there will be no animation (can be used to override animations coming from the cascade)
    [<CustomOperation("animationNameNone")>]
    member inline _.animationNameNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-name: ").Append(defaultArg value "none").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("animationPlayStateInherit")>]
    member inline _.animationPlayStateInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-play-state: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("animationPlayStateInitial")>]
    member inline _.animationPlayStateInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-play-state: ").Append("initial").Append("; "))

    /// Specifies that the animation is paused
    [<CustomOperation("animationPlayStatePaused")>]
    member inline _.animationPlayStatePaused([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-play-state: ").Append(defaultArg value "paused").Append("; "))

    /// Default value. Specifies that the animation is running
    [<CustomOperation("animationPlayStateRunning")>]
    member inline _.animationPlayStateRunning([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-play-state: ").Append(defaultArg value "running").Append("; "))

    /// Define your own values in the cubic-bezier function Possible values are numeric values from 0 to 1
    [<CustomOperation("animationTimingFunctionCubicBezier")>]
    member inline _.animationTimingFunctionCubicBezier([<InlineIfLambda>] comb: CombineKeyValue, n1: string, n2: string, n3: string, n4: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append(n1).Append(n2).Append(n3).Append(n4).Append("; "))

    /// Default value. The animation has a slow start, then fast, before it ends slowly
    [<CustomOperation("animationTimingFunctionEase")>]
    member inline _.animationTimingFunctionEase([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append(defaultArg value "ease").Append("; "))

    /// The animation has a slow start
    [<CustomOperation("animationTimingFunctionEaseIn")>]
    member inline _.animationTimingFunctionEaseIn([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append(defaultArg value "ease-in").Append("; "))

    /// The animation has both a slow start and a slow end
    [<CustomOperation("animationTimingFunctionEaseInOut")>]
    member inline _.animationTimingFunctionEaseInOut([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append(defaultArg value "ease-in-out").Append("; "))

    /// The animation has a slow end
    [<CustomOperation("animationTimingFunctionEaseOut")>]
    member inline _.animationTimingFunctionEaseOut([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append(defaultArg value "ease-out").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("animationTimingFunctionInherit")>]
    member inline _.animationTimingFunctionInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("animationTimingFunctionInitial")>]
    member inline _.animationTimingFunctionInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append("initial").Append("; "))

    /// The animation has the same speed from start to end
    [<CustomOperation("animationTimingFunctionLinear")>]
    member inline _.animationTimingFunctionLinear([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append(defaultArg value "linear").Append("; "))

    /// Equivalent to steps(1, end)
    [<CustomOperation("animationTimingFunctionStepEnd")>]
    member inline _.animationTimingFunctionStepEnd([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append(defaultArg value "step-end").Append("; "))

    /// Equivalent to steps(1, start)
    [<CustomOperation("animationTimingFunctionStepStart")>]
    member inline _.animationTimingFunctionStepStart([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append(defaultArg value "step-start").Append("; "))

    /// Specifies a stepping function, with two parameters. The first parameter specifies the number of intervals in the function. It must be a positive integer (greater than 0). The second parameter, which is optional, is either the value "start" or "end", and specifies the point at which the change of values occur within the interval. If the second parameter is omitted, it is given the value "end"
    [<CustomOperation("animationTimingFunctionSteps")>]
    member inline _.animationTimingFunctionSteps([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation-timing-function: ").Append($"steps({value})").Append("; "))

    /// The animation property is a shorthand property for:
    [<CustomOperation("animationAnimationIterationCount")>]
    member inline _.animationAnimationIterationCount([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation: ").Append(defaultArg value " animation-iteration-count").Append("; "))

    /// The animation property is a shorthand property for:
    [<CustomOperation("animationAnimationTimingFunction")>]
    member inline _.animationAnimationTimingFunction([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation: ").Append(defaultArg value " animation-timing-function").Append("; "))

    /// The animation property is a shorthand property for:
    [<CustomOperation("animationAnimationDelay")>]
    member inline _.animationAnimationDelay([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation: ").Append(defaultArg value "animation-delay").Append("; "))

    /// The animation property is a shorthand property for:
    [<CustomOperation("animationAnimationDirection")>]
    member inline _.animationAnimationDirection([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation: ").Append(defaultArg value "animation-direction").Append("; "))

    /// The animation property is a shorthand property for:
    [<CustomOperation("animationAnimationDuration")>]
    member inline _.animationAnimationDuration([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation: ").Append(defaultArg value "animation-duration").Append("; "))

    /// The animation property is a shorthand property for:
    [<CustomOperation("animationAnimationFillMode")>]
    member inline _.animationAnimationFillMode([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation: ").Append(defaultArg value "animation-fill-mode").Append("; "))

    /// The animation property is a shorthand property for:
    [<CustomOperation("animationAnimationName")>]
    member inline _.animationAnimationName([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation: ").Append(defaultArg value "animation-name").Append("; "))

    /// The animation property is a shorthand property for:
    [<CustomOperation("animationAnimationPlayState")>]
    member inline _.animationAnimationPlayState([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation: ").Append(defaultArg value "animation-play-state").Append("; "))

    ///  The aspect-ratio property allows you to define the ratio between width and height of an element. 
    [<CustomOperation("aspectRatio")>]
    member inline _.aspectRatio([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("aspect-ratio: ").Append(value).Append("; "))

    /// The aspect-ratio property allows you to define the ratio between width and height of an element.
    [<CustomOperation("aspectRatioInherit")>]
    member inline _.aspectRatioInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("aspect-ratio: ").Append("inherit").Append("; "))

    /// The aspect-ratio property allows you to define the ratio between width and height of an element.
    [<CustomOperation("aspectRatioInitial")>]
    member inline _.aspectRatioInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("aspect-ratio: ").Append("initial").Append("; "))

    /// The aspect-ratio property allows you to define the ratio between width and height of an element.
    [<CustomOperation("aspectRatioNumber")>]
    member inline _.aspectRatioNumber([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("aspect-ratio: ").Append(value).Append("; "))

    ///  The backdrop-filter property is used to apply a graphical effect to the area behind an element. 
    [<CustomOperation("backdropFilter")>]
    member inline _.backdropFilter([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("backdrop-filter: ").Append(value).Append("; "))

    /// The backdrop-filter property is used to apply a graphical effect to the area behind an element.
    [<CustomOperation("backdropFilterFilter")>]
    member inline _.backdropFilterFilter([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("backdrop-filter: ").Append(defaultArg value "filter").Append("; "))

    /// The backdrop-filter property is used to apply a graphical effect to the area behind an element.
    [<CustomOperation("backdropFilterInherit")>]
    member inline _.backdropFilterInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("backdrop-filter: ").Append("inherit").Append("; "))

    /// The backdrop-filter property is used to apply a graphical effect to the area behind an element.
    [<CustomOperation("backdropFilterInitial")>]
    member inline _.backdropFilterInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("backdrop-filter: ").Append("initial").Append("; "))

    /// The backdrop-filter property is used to apply a graphical effect to the area behind an element.
    [<CustomOperation("backdropFilterNone")>]
    member inline _.backdropFilterNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("backdrop-filter: ").Append(defaultArg value "none").Append("; "))

    ///  The backface-visibility property defines whether or not the back face of an element should be visible when facing the user. 
    [<CustomOperation("backfaceVisibility")>]
    member inline _.backfaceVisibility([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("backface-visibility: ").Append(value).Append("; "))

    /// The backface-visibility property defines whether or not the back face of an element should be visible when facing the user.
    [<CustomOperation("backfaceVisibilityHidden")>]
    member inline _.backfaceVisibilityHidden([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("backface-visibility: ").Append(defaultArg value "hidden").Append("; "))

    /// The backface-visibility property defines whether or not the back face of an element should be visible when facing the user.
    [<CustomOperation("backfaceVisibilityInherit")>]
    member inline _.backfaceVisibilityInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("backface-visibility: ").Append("inherit").Append("; "))

    /// The backface-visibility property defines whether or not the back face of an element should be visible when facing the user.
    [<CustomOperation("backfaceVisibilityInitial")>]
    member inline _.backfaceVisibilityInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("backface-visibility: ").Append("initial").Append("; "))

    /// The backface-visibility property defines whether or not the back face of an element should be visible when facing the user.
    [<CustomOperation("backfaceVisibilityVisible")>]
    member inline _.backfaceVisibilityVisible([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("backface-visibility: ").Append(defaultArg value "visible").Append("; "))

    ///  The background property is a shorthand property for: 
    [<CustomOperation("background")>]
    member inline _.background([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background: ").Append(value).Append("; "))

    /// The background image will not scroll with the page
    [<CustomOperation("backgroundAttachmentFixed")>]
    member inline _.backgroundAttachmentFixed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-attachment: ").Append(defaultArg value "fixed").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("backgroundAttachmentInherit")>]
    member inline _.backgroundAttachmentInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-attachment: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("backgroundAttachmentInitial")>]
    member inline _.backgroundAttachmentInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-attachment: ").Append("initial").Append("; "))

    /// The background image will scroll with the element's contents
    [<CustomOperation("backgroundAttachmentLocal")>]
    member inline _.backgroundAttachmentLocal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-attachment: ").Append(defaultArg value "local").Append("; "))

    /// The background image will scroll with the page. This is default
    [<CustomOperation("backgroundAttachmentScroll")>]
    member inline _.backgroundAttachmentScroll([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-attachment: ").Append(defaultArg value "scroll").Append("; "))

    /// Sets the blending mode to color
    [<CustomOperation("backgroundBlendModeColor")>]
    member inline _.backgroundBlendModeColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-blend-mode: ").Append(defaultArg value "color").Append("; "))

    /// Sets the blending mode to color-dodge
    [<CustomOperation("backgroundBlendModeColorDodge")>]
    member inline _.backgroundBlendModeColorDodge([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-blend-mode: ").Append(defaultArg value "color-dodge").Append("; "))

    /// Sets the blending mode to darken
    [<CustomOperation("backgroundBlendModeDarken")>]
    member inline _.backgroundBlendModeDarken([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-blend-mode: ").Append(defaultArg value "darken").Append("; "))

    /// Sets the blending mode to lighten
    [<CustomOperation("backgroundBlendModeLighten")>]
    member inline _.backgroundBlendModeLighten([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-blend-mode: ").Append(defaultArg value "lighten").Append("; "))

    /// Sets the blending mode to luminosity
    [<CustomOperation("backgroundBlendModeLuminosity")>]
    member inline _.backgroundBlendModeLuminosity([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-blend-mode: ").Append(defaultArg value "luminosity").Append("; "))

    /// Sets the blending mode to multiply
    [<CustomOperation("backgroundBlendModeMultiply")>]
    member inline _.backgroundBlendModeMultiply([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-blend-mode: ").Append(defaultArg value "multiply").Append("; "))

    /// This is default. Sets the blending mode to normal
    [<CustomOperation("backgroundBlendModeNormal")>]
    member inline _.backgroundBlendModeNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-blend-mode: ").Append(defaultArg value "normal").Append("; "))

    /// Sets the blending mode to overlay
    [<CustomOperation("backgroundBlendModeOverlay")>]
    member inline _.backgroundBlendModeOverlay([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-blend-mode: ").Append(defaultArg value "overlay").Append("; "))

    /// Sets the blending mode to saturation
    [<CustomOperation("backgroundBlendModeSaturation")>]
    member inline _.backgroundBlendModeSaturation([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-blend-mode: ").Append(defaultArg value "saturation").Append("; "))

    /// Sets the blending mode to screen
    [<CustomOperation("backgroundBlendModeScreen")>]
    member inline _.backgroundBlendModeScreen([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-blend-mode: ").Append(defaultArg value "screen").Append("; "))

    /// Default value. The background extends behind the border
    [<CustomOperation("backgroundClipBorderBox")>]
    member inline _.backgroundClipBorderBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-clip: ").Append(defaultArg value "border-box").Append("; "))

    /// The background extends to the edge of the content box
    [<CustomOperation("backgroundClipContentBox")>]
    member inline _.backgroundClipContentBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-clip: ").Append(defaultArg value "content-box").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("backgroundClipInherit")>]
    member inline _.backgroundClipInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-clip: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("backgroundClipInitial")>]
    member inline _.backgroundClipInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-clip: ").Append("initial").Append("; "))

    /// The background extends to the inside edge of the border
    [<CustomOperation("backgroundClipPaddingBox")>]
    member inline _.backgroundClipPaddingBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-clip: ").Append(defaultArg value "padding-box").Append("; "))

    /// Specifies the background color. Look at  CSS Color Values for a complete list of possible color values.
    [<CustomOperation("backgroundColorColor")>]
    member inline _.backgroundColorColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-color: ").Append(defaultArg value "color").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("backgroundColorInherit")>]
    member inline _.backgroundColorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-color: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("backgroundColorInitial")>]
    member inline _.backgroundColorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-color: ").Append("initial").Append("; "))

    /// Specifies that the background color should be transparent. This is default
    [<CustomOperation("backgroundColorTransparent")>]
    member inline _.backgroundColorTransparent([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-color: ").Append(defaultArg value "transparent").Append("; "))

    /// The URL to the image. To specify more than one image, separate the URLs with a comma
    [<CustomOperation("backgroundImageUrl")>]
    member inline _.backgroundImageUrl([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-image: ").Append($" url({value})").Append("; "))

    /// Sets a conic gradient as the background image. Define at least two colors
    [<CustomOperation("backgroundImageConicGradient")>]
    member inline _.backgroundImageConicGradient([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-image: ").Append($"conic-gradient({value})").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("backgroundImageInherit")>]
    member inline _.backgroundImageInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-image: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("backgroundImageInitial")>]
    member inline _.backgroundImageInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-image: ").Append("initial").Append("; "))

    /// Sets a linear gradient as the background image. Define at least two colors (top to bottom)
    [<CustomOperation("backgroundImageLinearGradient")>]
    member inline _.backgroundImageLinearGradient([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-image: ").Append($"linear-gradient({value})").Append("; "))

    /// No background image will be displayed. This is default
    [<CustomOperation("backgroundImageNone")>]
    member inline _.backgroundImageNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-image: ").Append(defaultArg value "none").Append("; "))

    /// Sets a radial gradient as the background image. Define at least two colors (center to edges)
    [<CustomOperation("backgroundImageRadialGradient")>]
    member inline _.backgroundImageRadialGradient([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-image: ").Append($"radial-gradient({value})").Append("; "))

    /// Repeats a conic gradient
    [<CustomOperation("backgroundImageRepeatingConicGradient")>]
    member inline _.backgroundImageRepeatingConicGradient([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-image: ").Append($"repeating-conic-gradient({value})").Append("; "))

    /// Repeats a linear gradient
    [<CustomOperation("backgroundImageRepeatingLinearGradient")>]
    member inline _.backgroundImageRepeatingLinearGradient([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-image: ").Append($"repeating-linear-gradient({value})").Append("; "))

    /// Repeats a radial gradient
    [<CustomOperation("backgroundImageRepeatingRadialGradient")>]
    member inline _.backgroundImageRepeatingRadialGradient([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-image: ").Append($"repeating-radial-gradient({value})").Append("; "))

    /// The background image starts from the upper left corner of the border
    [<CustomOperation("backgroundOriginBorderBox")>]
    member inline _.backgroundOriginBorderBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-origin: ").Append(defaultArg value "border-box").Append("; "))

    /// The background image starts from the upper left corner of the content
    [<CustomOperation("backgroundOriginContentBox")>]
    member inline _.backgroundOriginContentBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-origin: ").Append(defaultArg value "content-box").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("backgroundOriginInherit")>]
    member inline _.backgroundOriginInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-origin: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("backgroundOriginInitial")>]
    member inline _.backgroundOriginInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-origin: ").Append("initial").Append("; "))

    /// Default value. The background image starts from the upper left corner of the padding edge
    [<CustomOperation("backgroundOriginPaddingBox")>]
    member inline _.backgroundOriginPaddingBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-origin: ").Append(defaultArg value "padding-box").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("backgroundPositionInherit")>]
    member inline _.backgroundPositionInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("backgroundPositionInitial")>]
    member inline _.backgroundPositionInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position: ").Append("initial").Append("; "))

    /// If you only specify one keyword, the other value will be "center"
    [<CustomOperation("backgroundPositionLeftTopLeftCenterLeftBottomRightTopRightCenterRightBottomCenterTopCenterCenterCenterBottom")>]
    member inline _.backgroundPositionLeftTopLeftCenterLeftBottomRightTopRightCenterRightBottomCenterTopCenterCenterCenterBottom([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position: ").Append(defaultArg value "left top left center left bottom right top right center right bottom center top center center center bottom").Append("; "))

    /// The first value is the horizontal position and the second value is the vertical. The top left corner is 0% 0%. The right bottom corner is 100% 100%. If you only specify one value, the other value will be 50%. Default value is: 0% 0%
    [<CustomOperation("backgroundPositionXY")>]
    member inline _.backgroundPositionXY([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position: ").Append(defaultArg value "x% y%").Append("; "))

    /// The first value is the horizontal position and the second value is the vertical. The top left corner is 0 0. Units can be pixels (0px 0px) or any other CSS units. If you only specify one value, the other value will be 50%. You can mix % and positions
    [<CustomOperation("backgroundPositionXposYpos")>]
    member inline _.backgroundPositionXposYpos([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position: ").Append(defaultArg value "xpos ypos").Append("; "))

    /// Positions background center on x-axis.
    [<CustomOperation("backgroundPositionXCenter")>]
    member inline _.backgroundPositionXCenter([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position-x: ").Append(defaultArg value "center").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("backgroundPositionXInherit")>]
    member inline _.backgroundPositionXInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position-x: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("backgroundPositionXInitial")>]
    member inline _.backgroundPositionXInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position-x: ").Append("initial").Append("; "))

    /// Positions background left side on x-axis.
    [<CustomOperation("backgroundPositionXLeft")>]
    member inline _.backgroundPositionXLeft([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position-x: ").Append(defaultArg value "left").Append("; "))

    /// Positions background right side on x-axis.
    [<CustomOperation("backgroundPositionXRight")>]
    member inline _.backgroundPositionXRight([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position-x: ").Append(defaultArg value "right").Append("; "))

    /// Left side is 0% on x-axis, and right side is 100%. Percentage value refers to width of background positioning area minus width of background image.
    [<CustomOperation("backgroundPositionX")>]
    member inline _.backgroundPositionX([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position-x: ").Append(string value + "%").Append("; "))

    /// Horizontal distance from left side. Units can be pixels (0px) or any other CSS units.
    [<CustomOperation("backgroundPositionXXpos")>]
    member inline _.backgroundPositionXXpos([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position-x: ").Append(defaultArg value "xpos").Append("; "))

    /// Two value syntax, only supported in Firefox and Safari. - xpos is set either to "left" or "right". - offset is horizontal distance from background image and "left" or "right" side set with xpos. Units can be pixels or any other CSS units.
    [<CustomOperation("backgroundPositionXXposOffset")>]
    member inline _.backgroundPositionXXposOffset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position-x: ").Append(defaultArg value "xpos offset").Append("; "))

    /// Positions background bottom on y-axis.
    [<CustomOperation("backgroundPositionYBottom")>]
    member inline _.backgroundPositionYBottom([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position-y: ").Append(defaultArg value "bottom").Append("; "))

    /// Positions background center on y-axis.
    [<CustomOperation("backgroundPositionYCenter")>]
    member inline _.backgroundPositionYCenter([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position-y: ").Append(defaultArg value "center").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("backgroundPositionYInherit")>]
    member inline _.backgroundPositionYInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position-y: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("backgroundPositionYInitial")>]
    member inline _.backgroundPositionYInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position-y: ").Append("initial").Append("; "))

    /// Positions background top on y-axis.
    [<CustomOperation("backgroundPositionYTop")>]
    member inline _.backgroundPositionYTop([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position-y: ").Append(defaultArg value "top").Append("; "))

    /// Top side is 0% on y-axis, and bottom side is 100%. Percentage value refers to height of background positioning area minus height of background image.
    [<CustomOperation("backgroundPositionY")>]
    member inline _.backgroundPositionY([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position-y: ").Append(string value + "%").Append("; "))

    /// Vertical distance from top side. Units can be pixels (0px) or any other CSS units.
    [<CustomOperation("backgroundPositionYYpos")>]
    member inline _.backgroundPositionYYpos([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position-y: ").Append(defaultArg value "ypos").Append("; "))

    /// Two value syntax, only supported in Firefox and Safari. - ypos is set either to "top" or "bottom". - offset is vertical distance from background image and "top" or "bottom" side set with ypos. Units can be pixels or any other CSS units.
    [<CustomOperation("backgroundPositionYYposOffset")>]
    member inline _.backgroundPositionYYposOffset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-position-y: ").Append(defaultArg value "ypos offset").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("backgroundRepeatInherit")>]
    member inline _.backgroundRepeatInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-repeat: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("backgroundRepeatInitial")>]
    member inline _.backgroundRepeatInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-repeat: ").Append("initial").Append("; "))

    /// The background-image is not repeated. The image will only be shown once
    [<CustomOperation("backgroundRepeatNoRepeat")>]
    member inline _.backgroundRepeatNoRepeat([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-repeat: ").Append(defaultArg value "no-repeat").Append("; "))

    /// The background image is repeated both vertically and horizontally. The last image will be clipped if it does not fit. This is default
    [<CustomOperation("backgroundRepeatRepeat")>]
    member inline _.backgroundRepeatRepeat([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-repeat: ").Append(defaultArg value "repeat").Append("; "))

    /// The background image is repeated only horizontally
    [<CustomOperation("backgroundRepeatRepeatX")>]
    member inline _.backgroundRepeatRepeatX([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-repeat: ").Append(defaultArg value "repeat-x").Append("; "))

    /// The background image is repeated only vertically
    [<CustomOperation("backgroundRepeatRepeatY")>]
    member inline _.backgroundRepeatRepeatY([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-repeat: ").Append(defaultArg value "repeat-y").Append("; "))

    /// The background-image is repeated and squished or stretched to fill the space (no gaps)
    [<CustomOperation("backgroundRepeatRound")>]
    member inline _.backgroundRepeatRound([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-repeat: ").Append(defaultArg value "round").Append("; "))

    /// The background-image is repeated as much as possible without clipping. The first and last image is pinned to either side of the element, and whitespace is distributed evenly between the images
    [<CustomOperation("backgroundRepeatSpace")>]
    member inline _.backgroundRepeatSpace([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-repeat: ").Append(defaultArg value "space").Append("; "))

    /// Resize the background image to make sure the image is fully visible
    [<CustomOperation("backgroundSizeContain")>]
    member inline _.backgroundSizeContain([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-size: ").Append(defaultArg value " contain").Append("; "))

    /// Resize the background image to cover the entire container, even if it has to stretch the image or cut a little bit off one of the edges
    [<CustomOperation("backgroundSizeCover")>]
    member inline _.backgroundSizeCover([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-size: ").Append(defaultArg value " cover").Append("; "))

    /// Default value. The background image is displayed in its original size
    [<CustomOperation("backgroundSizeAuto")>]
    member inline _.backgroundSizeAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-size: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("backgroundSizeInherit")>]
    member inline _.backgroundSizeInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-size: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("backgroundSizeInitial")>]
    member inline _.backgroundSizeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-size: ").Append("initial").Append("; "))

    /// Sets the width and height of the background image. The first value sets the width, the second value sets the height. If only one value is given, the second is set to "auto". Read about length units
    [<CustomOperation("backgroundSizeLength")>]
    member inline _.backgroundSizeLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-size: ").Append(string value + "px").Append("; "))

    /// Sets the width and height of the background image in percent of the parent element. The first value sets the width, the second value sets the height. If only one value is given, the second is set to "auto"
    [<CustomOperation("backgroundSizePercentage")>]
    member inline _.backgroundSizePercentage([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background-size: ").Append(defaultArg value "percentage").Append("; "))

    /// The background property is a shorthand property for:
    [<CustomOperation("backgroundBackgroundAttachment")>]
    member inline _.backgroundBackgroundAttachment([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background: ").Append(defaultArg value "background-attachment").Append("; "))

    /// The background property is a shorthand property for:
    [<CustomOperation("backgroundBackgroundClip")>]
    member inline _.backgroundBackgroundClip([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background: ").Append(defaultArg value "background-clip").Append("; "))

    /// The background property is a shorthand property for:
    [<CustomOperation("backgroundBackgroundColor")>]
    member inline _.backgroundBackgroundColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background: ").Append(defaultArg value "background-color").Append("; "))

    /// The background property is a shorthand property for:
    [<CustomOperation("backgroundBackgroundImage")>]
    member inline _.backgroundBackgroundImage([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background: ").Append(defaultArg value "background-image").Append("; "))

    /// The background property is a shorthand property for:
    [<CustomOperation("backgroundBackgroundOrigin")>]
    member inline _.backgroundBackgroundOrigin([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background: ").Append(defaultArg value "background-origin").Append("; "))

    /// The background property is a shorthand property for:
    [<CustomOperation("backgroundBackgroundPosition")>]
    member inline _.backgroundBackgroundPosition([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background: ").Append(defaultArg value "background-position").Append("; "))

    /// The background property is a shorthand property for:
    [<CustomOperation("backgroundBackgroundRepeat")>]
    member inline _.backgroundBackgroundRepeat([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background: ").Append(defaultArg value "background-repeat").Append("; "))

    /// The background property is a shorthand property for:
    [<CustomOperation("backgroundBackgroundSize")>]
    member inline _.backgroundBackgroundSize([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background: ").Append(defaultArg value "background-size").Append("; "))

    ///  The block-size property specifies the size of an element in the block direction. 
    [<CustomOperation("blockSize")>]
    member inline _.blockSize([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("block-size: ").Append(value).Append("; "))

    /// The block-size property specifies the size of an element in the block direction.
    [<CustomOperation("blockSize")>]
    member inline _.blockSize([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("block-size: ").Append(string value + "%").Append("; "))

    /// The block-size property specifies the size of an element in the block direction.
    [<CustomOperation("blockSizeAuto")>]
    member inline _.blockSizeAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("block-size: ").Append("auto").Append("; "))

    /// The block-size property specifies the size of an element in the block direction.
    [<CustomOperation("blockSizeInherit")>]
    member inline _.blockSizeInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("block-size: ").Append("inherit").Append("; "))

    /// The block-size property specifies the size of an element in the block direction.
    [<CustomOperation("blockSizeInitial")>]
    member inline _.blockSizeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("block-size: ").Append("initial").Append("; "))

    /// The block-size property specifies the size of an element in the block direction.
    [<CustomOperation("blockSizeLength")>]
    member inline _.blockSizeLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("block-size: ").Append(string value + "px").Append("; "))

    ///  The border property is a shorthand property for: 
    [<CustomOperation("border")>]
    member inline _.border([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border: ").Append(value).Append("; "))

    /// Specifies the color of the border in the block direction. Default value is the color of the text
    [<CustomOperation("borderBlockBorderBlockColor")>]
    member inline _.borderBlockBorderBlockColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block: ").Append(defaultArg value "border-block-color").Append("; "))

    /// Specifies the style of the border in the block direction. Default value is "none"
    [<CustomOperation("borderBlockBorderBlockStyle")>]
    member inline _.borderBlockBorderBlockStyle([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block: ").Append(defaultArg value "border-block-style").Append("; "))

    /// Specifies the width of the border in the block direction. Default value is "medium"
    [<CustomOperation("borderBlockBorderBlockWidth")>]
    member inline _.borderBlockBorderBlockWidth([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block: ").Append(defaultArg value "border-block-width").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderBlockInherit")>]
    member inline _.borderBlockInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderBlockInitial")>]
    member inline _.borderBlockInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block: ").Append("initial").Append("; "))

    /// Specifies the border color. Look at  CSS Color Values for a complete list of possible color values. Default color is the current color of the element
    [<CustomOperation("borderBlockColorColor")>]
    member inline _.borderBlockColorColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-color: ").Append(defaultArg value "color").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderBlockColorInherit")>]
    member inline _.borderBlockColorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-color: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderBlockColorInitial")>]
    member inline _.borderBlockColorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-color: ").Append("initial").Append("; "))

    /// Specifies that the border color should be transparent
    [<CustomOperation("borderBlockColorTransparent")>]
    member inline _.borderBlockColorTransparent([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-color: ").Append(defaultArg value "transparent").Append("; "))

    /// Specifies the color of an element's border at the end in the block direction. Default value is the current color of the border
    [<CustomOperation("borderBlockEndBorderBlockEndColor")>]
    member inline _.borderBlockEndBorderBlockEndColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end: ").Append(defaultArg value "border-block-end-color").Append("; "))

    /// Specifies the style of an element's border at the end in the block direction. Default value is "none"
    [<CustomOperation("borderBlockEndBorderBlockEndStyle")>]
    member inline _.borderBlockEndBorderBlockEndStyle([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end: ").Append(defaultArg value "border-block-end-style").Append("; "))

    /// Specifies the width of an element's border at the end in the block direction. Default value is "medium"
    [<CustomOperation("borderBlockEndBorderBlockEndWidth")>]
    member inline _.borderBlockEndBorderBlockEndWidth([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end: ").Append(defaultArg value "border-block-end-width").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderBlockEndInherit")>]
    member inline _.borderBlockEndInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderBlockEndInitial")>]
    member inline _.borderBlockEndInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end: ").Append("initial").Append("; "))

    /// Specifies the border color. Look at  CSS Color Values for a complete list of possible color values. Default color is the current color of the element
    [<CustomOperation("borderBlockEndColorColor")>]
    member inline _.borderBlockEndColorColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-color: ").Append(defaultArg value "color").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderBlockEndColorInherit")>]
    member inline _.borderBlockEndColorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-color: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderBlockEndColorInitial")>]
    member inline _.borderBlockEndColorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-color: ").Append("initial").Append("; "))

    /// Specifies that the border color should be transparent
    [<CustomOperation("borderBlockEndColorTransparent")>]
    member inline _.borderBlockEndColorTransparent([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-color: ").Append(defaultArg value "transparent").Append("; "))

    /// Specifies a dashed border
    [<CustomOperation("borderBlockEndStyleDashed")>]
    member inline _.borderBlockEndStyleDashed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append(defaultArg value "dashed").Append("; "))

    /// Specifies a dotted border
    [<CustomOperation("borderBlockEndStyleDotted")>]
    member inline _.borderBlockEndStyleDotted([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append(defaultArg value "dotted").Append("; "))

    /// Specifies a double border
    [<CustomOperation("borderBlockEndStyleDouble")>]
    member inline _.borderBlockEndStyleDouble([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append(defaultArg value "double").Append("; "))

    /// Specifies a 3D grooved border. The effect depends on the border-color value
    [<CustomOperation("borderBlockEndStyleGroove")>]
    member inline _.borderBlockEndStyleGroove([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append(defaultArg value "groove").Append("; "))

    /// The same as "none", except in border conflict resolution for table elements
    [<CustomOperation("borderBlockEndStyleHidden")>]
    member inline _.borderBlockEndStyleHidden([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append(defaultArg value "hidden").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderBlockEndStyleInherit")>]
    member inline _.borderBlockEndStyleInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderBlockEndStyleInitial")>]
    member inline _.borderBlockEndStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append("initial").Append("; "))

    /// Specifies a 3D inset border. The effect depends on the border-color value
    [<CustomOperation("borderBlockEndStyleInset")>]
    member inline _.borderBlockEndStyleInset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append(defaultArg value "inset").Append("; "))

    /// Default value. Specifies no border
    [<CustomOperation("borderBlockEndStyleNone")>]
    member inline _.borderBlockEndStyleNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append(defaultArg value "none").Append("; "))

    /// Specifies a 3D outset border. The effect depends on the border-color value
    [<CustomOperation("borderBlockEndStyleOutset")>]
    member inline _.borderBlockEndStyleOutset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append(defaultArg value "outset").Append("; "))

    /// Specifies a 3D ridged border. The effect depends on the border-color value
    [<CustomOperation("borderBlockEndStyleRigde")>]
    member inline _.borderBlockEndStyleRigde([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append(defaultArg value "rigde").Append("; "))

    /// Specifies a solid border
    [<CustomOperation("borderBlockEndStyleSolid")>]
    member inline _.borderBlockEndStyleSolid([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-style: ").Append(defaultArg value "solid").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderBlockEndWidthInherit")>]
    member inline _.borderBlockEndWidthInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-width: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderBlockEndWidthInitial")>]
    member inline _.borderBlockEndWidthInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-width: ").Append("initial").Append("; "))

    /// Allows you to define the thickness of the border. Read about length units
    [<CustomOperation("borderBlockEndWidthLength")>]
    member inline _.borderBlockEndWidthLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-width: ").Append(string value + "px").Append("; "))

    /// Specifies a medium border. This is default
    [<CustomOperation("borderBlockEndWidthMedium")>]
    member inline _.borderBlockEndWidthMedium([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-width: ").Append(defaultArg value "medium").Append("; "))

    /// Specifies a thick border
    [<CustomOperation("borderBlockEndWidthThick")>]
    member inline _.borderBlockEndWidthThick([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-width: ").Append(defaultArg value "thick").Append("; "))

    /// Specifies a thin border
    [<CustomOperation("borderBlockEndWidthThin")>]
    member inline _.borderBlockEndWidthThin([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-end-width: ").Append(defaultArg value "thin").Append("; "))

    /// Specifies the color of an element's border at the end in the block direction. Default value is the current color of the border
    [<CustomOperation("borderBlockStartBorderBlockStartColor")>]
    member inline _.borderBlockStartBorderBlockStartColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start: ").Append(defaultArg value "border-block-start-color").Append("; "))

    /// Specifies the style of an element's border at the end in the block direction. Default value is "none"
    [<CustomOperation("borderBlockStartBorderBlockStartStyle")>]
    member inline _.borderBlockStartBorderBlockStartStyle([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start: ").Append(defaultArg value "border-block-start-style").Append("; "))

    /// Specifies the width of an element's border at the end in the block direction. Default value is "medium"
    [<CustomOperation("borderBlockStartBorderBlockStartWidth")>]
    member inline _.borderBlockStartBorderBlockStartWidth([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start: ").Append(defaultArg value "border-block-start-width").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderBlockStartInherit")>]
    member inline _.borderBlockStartInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderBlockStartInitial")>]
    member inline _.borderBlockStartInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start: ").Append("initial").Append("; "))

    /// Specifies the border color. Look at  CSS Color Values for a complete list of possible color values. Default color is the current color of the element
    [<CustomOperation("borderBlockStartColorColor")>]
    member inline _.borderBlockStartColorColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-color: ").Append(defaultArg value "color").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderBlockStartColorInherit")>]
    member inline _.borderBlockStartColorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-color: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderBlockStartColorInitial")>]
    member inline _.borderBlockStartColorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-color: ").Append("initial").Append("; "))

    /// Specifies that the border color should be transparent
    [<CustomOperation("borderBlockStartColorTransparent")>]
    member inline _.borderBlockStartColorTransparent([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-color: ").Append(defaultArg value "transparent").Append("; "))

    /// Specifies a dashed border
    [<CustomOperation("borderBlockStartStyleDashed")>]
    member inline _.borderBlockStartStyleDashed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append(defaultArg value "dashed").Append("; "))

    /// Specifies a dotted border
    [<CustomOperation("borderBlockStartStyleDotted")>]
    member inline _.borderBlockStartStyleDotted([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append(defaultArg value "dotted").Append("; "))

    /// Specifies a double border
    [<CustomOperation("borderBlockStartStyleDouble")>]
    member inline _.borderBlockStartStyleDouble([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append(defaultArg value "double").Append("; "))

    /// Specifies a 3D grooved border. The effect depends on the border-color value
    [<CustomOperation("borderBlockStartStyleGroove")>]
    member inline _.borderBlockStartStyleGroove([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append(defaultArg value "groove").Append("; "))

    /// The same as "none", except in border conflict resolution for table elements
    [<CustomOperation("borderBlockStartStyleHidden")>]
    member inline _.borderBlockStartStyleHidden([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append(defaultArg value "hidden").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderBlockStartStyleInherit")>]
    member inline _.borderBlockStartStyleInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderBlockStartStyleInitial")>]
    member inline _.borderBlockStartStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append("initial").Append("; "))

    /// Specifies a 3D inset border. The effect depends on the border-color value
    [<CustomOperation("borderBlockStartStyleInset")>]
    member inline _.borderBlockStartStyleInset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append(defaultArg value "inset").Append("; "))

    /// Default value. Specifies no border
    [<CustomOperation("borderBlockStartStyleNone")>]
    member inline _.borderBlockStartStyleNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append(defaultArg value "none").Append("; "))

    /// Specifies a 3D outset border. The effect depends on the border-color value
    [<CustomOperation("borderBlockStartStyleOutset")>]
    member inline _.borderBlockStartStyleOutset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append(defaultArg value "outset").Append("; "))

    /// Specifies a 3D ridged border. The effect depends on the border-color value
    [<CustomOperation("borderBlockStartStyleRigde")>]
    member inline _.borderBlockStartStyleRigde([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append(defaultArg value "rigde").Append("; "))

    /// Specifies a solid border
    [<CustomOperation("borderBlockStartStyleSolid")>]
    member inline _.borderBlockStartStyleSolid([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-style: ").Append(defaultArg value "solid").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderBlockStartWidthInherit")>]
    member inline _.borderBlockStartWidthInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-width: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderBlockStartWidthInitial")>]
    member inline _.borderBlockStartWidthInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-width: ").Append("initial").Append("; "))

    /// Allows you to define the thickness of the border. Read about length units
    [<CustomOperation("borderBlockStartWidthLength")>]
    member inline _.borderBlockStartWidthLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-width: ").Append(string value + "px").Append("; "))

    /// Specifies a medium border. This is default
    [<CustomOperation("borderBlockStartWidthMedium")>]
    member inline _.borderBlockStartWidthMedium([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-width: ").Append(defaultArg value "medium").Append("; "))

    /// Specifies a thick border
    [<CustomOperation("borderBlockStartWidthThick")>]
    member inline _.borderBlockStartWidthThick([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-width: ").Append(defaultArg value "thick").Append("; "))

    /// Specifies a thin border
    [<CustomOperation("borderBlockStartWidthThin")>]
    member inline _.borderBlockStartWidthThin([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-start-width: ").Append(defaultArg value "thin").Append("; "))

    /// Specifies a dashed border
    [<CustomOperation("borderBlockStyleDashed")>]
    member inline _.borderBlockStyleDashed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append(defaultArg value "dashed").Append("; "))

    /// Specifies a dotted border
    [<CustomOperation("borderBlockStyleDotted")>]
    member inline _.borderBlockStyleDotted([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append(defaultArg value "dotted").Append("; "))

    /// Specifies a double border
    [<CustomOperation("borderBlockStyleDouble")>]
    member inline _.borderBlockStyleDouble([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append(defaultArg value "double").Append("; "))

    /// Specifies a 3D grooved border. The effect depends on the border-color value
    [<CustomOperation("borderBlockStyleGroove")>]
    member inline _.borderBlockStyleGroove([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append(defaultArg value "groove").Append("; "))

    /// The same as "none", except in border conflict resolution for table elements
    [<CustomOperation("borderBlockStyleHidden")>]
    member inline _.borderBlockStyleHidden([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append(defaultArg value "hidden").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderBlockStyleInherit")>]
    member inline _.borderBlockStyleInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderBlockStyleInitial")>]
    member inline _.borderBlockStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append("initial").Append("; "))

    /// Specifies a 3D inset border. The effect depends on the border-color value
    [<CustomOperation("borderBlockStyleInset")>]
    member inline _.borderBlockStyleInset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append(defaultArg value "inset").Append("; "))

    /// Default value. Specifies no border
    [<CustomOperation("borderBlockStyleNone")>]
    member inline _.borderBlockStyleNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append(defaultArg value "none").Append("; "))

    /// Specifies a 3D outset border. The effect depends on the border-color value
    [<CustomOperation("borderBlockStyleOutset")>]
    member inline _.borderBlockStyleOutset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append(defaultArg value "outset").Append("; "))

    /// Specifies a 3D ridged border. The effect depends on the border-color value
    [<CustomOperation("borderBlockStyleRigde")>]
    member inline _.borderBlockStyleRigde([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append(defaultArg value "rigde").Append("; "))

    /// Specifies a solid border
    [<CustomOperation("borderBlockStyleSolid")>]
    member inline _.borderBlockStyleSolid([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-style: ").Append(defaultArg value "solid").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderBlockWidthInherit")>]
    member inline _.borderBlockWidthInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-width: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderBlockWidthInitial")>]
    member inline _.borderBlockWidthInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-width: ").Append("initial").Append("; "))

    /// Allows you to define the thickness of the border. Read about length units
    [<CustomOperation("borderBlockWidthLength")>]
    member inline _.borderBlockWidthLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-width: ").Append(string value + "px").Append("; "))

    /// Specifies a medium border. This is default
    [<CustomOperation("borderBlockWidthMedium")>]
    member inline _.borderBlockWidthMedium([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-width: ").Append(defaultArg value "medium").Append("; "))

    /// Specifies a thick border
    [<CustomOperation("borderBlockWidthThick")>]
    member inline _.borderBlockWidthThick([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-width: ").Append(defaultArg value "thick").Append("; "))

    /// Specifies a thin border
    [<CustomOperation("borderBlockWidthThin")>]
    member inline _.borderBlockWidthThin([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-block-width: ").Append(defaultArg value "thin").Append("; "))

    /// Optional. Specifies the color of the bottom border. Default value is the color of the text
    [<CustomOperation("borderBottomBorderBottomColor")>]
    member inline _.borderBottomBorderBottomColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom: ").Append(defaultArg value "border-bottom-color").Append("; "))

    /// Required. Specifies the style of the bottom border. Default value is "none"
    [<CustomOperation("borderBottomBorderBottomStyle")>]
    member inline _.borderBottomBorderBottomStyle([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom: ").Append(defaultArg value "border-bottom-style").Append("; "))

    /// Required. Specifies the width of the bottom border. Default value is "medium"
    [<CustomOperation("borderBottomBorderBottomWidth")>]
    member inline _.borderBottomBorderBottomWidth([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom: ").Append(defaultArg value "border-bottom-width").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderBottomInherit")>]
    member inline _.borderBottomInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderBottomInitial")>]
    member inline _.borderBottomInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom: ").Append("initial").Append("; "))

    /// Specifies the color of the bottom border. Look at  CSS Color Values for a complete list of possible color values. Default color is the current color of the element
    [<CustomOperation("borderBottomColorColor")>]
    member inline _.borderBottomColorColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-color: ").Append(defaultArg value "color").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderBottomColorInherit")>]
    member inline _.borderBottomColorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-color: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderBottomColorInitial")>]
    member inline _.borderBottomColorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-color: ").Append("initial").Append("; "))

    /// Specifies that the border color should be transparent
    [<CustomOperation("borderBottomColorTransparent")>]
    member inline _.borderBottomColorTransparent([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-color: ").Append(defaultArg value "transparent").Append("; "))

    /// Defines the shape of the bottom-left corner in %
    [<CustomOperation("borderBottomLeftRadius")>]
    member inline _.borderBottomLeftRadius([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-left-radius: ").Append(string value + "%").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderBottomLeftRadiusInherit")>]
    member inline _.borderBottomLeftRadiusInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-left-radius: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderBottomLeftRadiusInitial")>]
    member inline _.borderBottomLeftRadiusInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-left-radius: ").Append("initial").Append("; "))

    /// Defines the shape of the bottom-left corner. Default value is 0. Read about length units
    [<CustomOperation("borderBottomLeftRadiusLength")>]
    member inline _.borderBottomLeftRadiusLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-left-radius: ").Append(string value + "px").Append("; "))

    /// Defines the shape of the bottom-right corner in %
    [<CustomOperation("borderBottomRightRadius")>]
    member inline _.borderBottomRightRadius([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-right-radius: ").Append(string value + "%").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderBottomRightRadiusInherit")>]
    member inline _.borderBottomRightRadiusInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-right-radius: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderBottomRightRadiusInitial")>]
    member inline _.borderBottomRightRadiusInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-right-radius: ").Append("initial").Append("; "))

    /// Defines the shape of the bottom-right corner. Default value is 0. Read about length units
    [<CustomOperation("borderBottomRightRadiusLength")>]
    member inline _.borderBottomRightRadiusLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-right-radius: ").Append(string value + "px").Append("; "))

    /// Specifies a dashed border
    [<CustomOperation("borderBottomStyleDashed")>]
    member inline _.borderBottomStyleDashed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append(defaultArg value "dashed").Append("; "))

    /// Specifies a dotted border
    [<CustomOperation("borderBottomStyleDotted")>]
    member inline _.borderBottomStyleDotted([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append(defaultArg value "dotted").Append("; "))

    /// Specifies a double border
    [<CustomOperation("borderBottomStyleDouble")>]
    member inline _.borderBottomStyleDouble([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append(defaultArg value "double").Append("; "))

    /// Specifies a 3D grooved border. The effect depends on the border-color value
    [<CustomOperation("borderBottomStyleGroove")>]
    member inline _.borderBottomStyleGroove([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append(defaultArg value "groove").Append("; "))

    /// The same as "none", except in border conflict resolution for table elements
    [<CustomOperation("borderBottomStyleHidden")>]
    member inline _.borderBottomStyleHidden([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append(defaultArg value "hidden").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderBottomStyleInherit")>]
    member inline _.borderBottomStyleInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderBottomStyleInitial")>]
    member inline _.borderBottomStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append("initial").Append("; "))

    /// Specifies a 3D inset border. The effect depends on the border-color value
    [<CustomOperation("borderBottomStyleInset")>]
    member inline _.borderBottomStyleInset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append(defaultArg value "inset").Append("; "))

    /// Specifies no border. This is default
    [<CustomOperation("borderBottomStyleNone")>]
    member inline _.borderBottomStyleNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append(defaultArg value "none").Append("; "))

    /// Specifies a 3D outset border. The effect depends on the border-color value
    [<CustomOperation("borderBottomStyleOutset")>]
    member inline _.borderBottomStyleOutset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append(defaultArg value "outset").Append("; "))

    /// Specifies a 3D ridged border. The effect depends on the border-color value
    [<CustomOperation("borderBottomStyleRidge")>]
    member inline _.borderBottomStyleRidge([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append(defaultArg value "ridge").Append("; "))

    /// Specifies a solid border
    [<CustomOperation("borderBottomStyleSolid")>]
    member inline _.borderBottomStyleSolid([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-style: ").Append(defaultArg value "solid").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderBottomWidthInherit")>]
    member inline _.borderBottomWidthInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-width: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderBottomWidthInitial")>]
    member inline _.borderBottomWidthInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-width: ").Append("initial").Append("; "))

    /// Allows you to define the thickness of the bottom border. Read about length units
    [<CustomOperation("borderBottomWidthLength")>]
    member inline _.borderBottomWidthLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-width: ").Append(string value + "px").Append("; "))

    /// Specifies a medium bottom border. This is default
    [<CustomOperation("borderBottomWidthMedium")>]
    member inline _.borderBottomWidthMedium([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-width: ").Append(defaultArg value "medium").Append("; "))

    /// Specifies a thick bottom border
    [<CustomOperation("borderBottomWidthThick")>]
    member inline _.borderBottomWidthThick([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-width: ").Append(defaultArg value "thick").Append("; "))

    /// Specifies a thin bottom border
    [<CustomOperation("borderBottomWidthThin")>]
    member inline _.borderBottomWidthThin([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-bottom-width: ").Append(defaultArg value "thin").Append("; "))

    /// Borders are collapsed into a single border when possible (border-spacing and empty-cells properties have no effect)
    [<CustomOperation("borderCollapseCollapse")>]
    member inline _.borderCollapseCollapse([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-collapse: ").Append(defaultArg value "collapse").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderCollapseInherit")>]
    member inline _.borderCollapseInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-collapse: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderCollapseInitial")>]
    member inline _.borderCollapseInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-collapse: ").Append("initial").Append("; "))

    /// Borders are separated; each cell will display its own borders. This is default.
    [<CustomOperation("borderCollapseSeparate")>]
    member inline _.borderCollapseSeparate([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-collapse: ").Append(defaultArg value "separate").Append("; "))

    /// Specifies the border color. Look at  CSS Color Values for a complete list of possible color values. Default color is the current color of the element
    [<CustomOperation("borderColorColor")>]
    member inline _.borderColorColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-color: ").Append(defaultArg value "color").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderColorInherit")>]
    member inline _.borderColorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-color: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderColorInitial")>]
    member inline _.borderColorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-color: ").Append("initial").Append("; "))

    /// Specifies that the border color should be transparent
    [<CustomOperation("borderColorTransparent")>]
    member inline _.borderColorTransparent([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-color: ").Append(defaultArg value "transparent").Append("; "))

    /// Defines the shape of the corner at block-end and inline-end in percentange of length of element on corresponding axis.
    [<CustomOperation("borderEndEndRadius")>]
    member inline _.borderEndEndRadius([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-end-end-radius: ").Append(string value + "%").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderEndEndRadiusInherit")>]
    member inline _.borderEndEndRadiusInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-end-end-radius: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderEndEndRadiusInitial")>]
    member inline _.borderEndEndRadiusInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-end-end-radius: ").Append("initial").Append("; "))

    /// Defines the shape of the corner at block-end and inline-end. Read about length units
    [<CustomOperation("borderEndEndRadiusLength")>]
    member inline _.borderEndEndRadiusLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-end-end-radius: ").Append(string value + "px").Append("; "))

    /// Defines the shape of the corner at block-end and inline-start in percentange of length of element on corresponding axis.
    [<CustomOperation("borderEndStartRadius")>]
    member inline _.borderEndStartRadius([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-end-start-radius: ").Append(string value + "%").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderEndStartRadiusInherit")>]
    member inline _.borderEndStartRadiusInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-end-start-radius: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderEndStartRadiusInitial")>]
    member inline _.borderEndStartRadiusInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-end-start-radius: ").Append("initial").Append("; "))

    /// Defines the shape of the corner at block-end and inline-start. Read about length units
    [<CustomOperation("borderEndStartRadiusLength")>]
    member inline _.borderEndStartRadiusLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-end-start-radius: ").Append(string value + "px").Append("; "))

    /// The amount by which the border image area extends beyond the border box
    [<CustomOperation("borderImageBorderImageOutset")>]
    member inline _.borderImageBorderImageOutset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image: ").Append(defaultArg value "border-image-outset").Append("; "))

    /// Whether the border image should be repeated, rounded or stretched
    [<CustomOperation("borderImageBorderImageRepeat")>]
    member inline _.borderImageBorderImageRepeat([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image: ").Append(defaultArg value "border-image-repeat").Append("; "))

    /// How to slice the border image
    [<CustomOperation("borderImageBorderImageSlice")>]
    member inline _.borderImageBorderImageSlice([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image: ").Append(defaultArg value "border-image-slice").Append("; "))

    /// The path to the image to be used as a border
    [<CustomOperation("borderImageBorderImageSource")>]
    member inline _.borderImageBorderImageSource([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image: ").Append(defaultArg value "border-image-source").Append("; "))

    /// The width of the border image
    [<CustomOperation("borderImageBorderImageWidth")>]
    member inline _.borderImageBorderImageWidth([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image: ").Append(defaultArg value "border-image-width").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderImageInherit")>]
    member inline _.borderImageInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderImageInitial")>]
    member inline _.borderImageInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image: ").Append("initial").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderImageOutsetInherit")>]
    member inline _.borderImageOutsetInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-outset: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderImageOutsetInitial")>]
    member inline _.borderImageOutsetInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-outset: ").Append("initial").Append("; "))

    /// A length unit specifying how far from the edges the border-image will appear. Default value is 0
    [<CustomOperation("borderImageOutsetLength")>]
    member inline _.borderImageOutsetLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-outset: ").Append(string value + "px").Append("; "))

    /// Represent multiples of the corresponding border-width
    [<CustomOperation("borderImageOutsetNumber")>]
    member inline _.borderImageOutsetNumber([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-outset: ").Append(value).Append("; "))

    /// The image is tiled (repeated) to fill the area
    [<CustomOperation("borderImageRepeatRepeat")>]
    member inline _.borderImageRepeatRepeat([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-repeat: ").Append(defaultArg value " repeat").Append("; "))

    /// The image is tiled (repeated) to fill the area. If it does not fill the area with a whole number of tiles, the image is rescaled so it fits
    [<CustomOperation("borderImageRepeatRound")>]
    member inline _.borderImageRepeatRound([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-repeat: ").Append(defaultArg value " round").Append("; "))

    /// Default value. The image is stretched to fill the area
    [<CustomOperation("borderImageRepeatStretch")>]
    member inline _.borderImageRepeatStretch([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-repeat: ").Append(defaultArg value " stretch").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderImageRepeatInherit")>]
    member inline _.borderImageRepeatInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-repeat: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderImageRepeatInitial")>]
    member inline _.borderImageRepeatInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-repeat: ").Append("initial").Append("; "))

    /// The image is tiled (repeated) to fill the area. If it does not fill the area with a whole number of tiles, the extra space is distributed around the tiles
    [<CustomOperation("borderImageRepeatSpace")>]
    member inline _.borderImageRepeatSpace([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-repeat: ").Append(defaultArg value "space").Append("; "))

    /// Causes the middle part of the image to be displayed
    [<CustomOperation("borderImageSliceFill")>]
    member inline _.borderImageSliceFill([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-slice: ").Append(defaultArg value " fill").Append("; "))

    /// Percentages are relative to the height or width of the image
    [<CustomOperation("borderImageSlice")>]
    member inline _.borderImageSlice([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-slice: ").Append(string value + "%").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderImageSliceInherit")>]
    member inline _.borderImageSliceInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-slice: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderImageSliceInitial")>]
    member inline _.borderImageSliceInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-slice: ").Append("initial").Append("; "))

    /// The number(s) represent pixels for raster images or coordinates for vector images
    [<CustomOperation("borderImageSliceNumber")>]
    member inline _.borderImageSliceNumber([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-slice: ").Append(value).Append("; "))

    /// No image will be used
    [<CustomOperation("borderImageSourceNone")>]
    member inline _.borderImageSourceNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-source: ").Append(defaultArg value " none").Append("; "))

    /// The path to the image to be used as a border
    [<CustomOperation("borderImageSourceImage")>]
    member inline _.borderImageSourceImage([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-source: ").Append(defaultArg value "image").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderImageSourceInherit")>]
    member inline _.borderImageSourceInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-source: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderImageSourceInitial")>]
    member inline _.borderImageSourceInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-source: ").Append("initial").Append("; "))

    /// Refers to the size of the border image area: the width of the area for horizontal offsets, the height for vertical offsets
    [<CustomOperation("borderImageWidth")>]
    member inline _.borderImageWidth([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-width: ").Append(string value + "%").Append("; "))

    /// If specified, the width is the intrinsic width or height of the corresponding image slice
    [<CustomOperation("borderImageWidthAuto")>]
    member inline _.borderImageWidthAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-width: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderImageWidthInherit")>]
    member inline _.borderImageWidthInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-width: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderImageWidthInitial")>]
    member inline _.borderImageWidthInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-width: ").Append("initial").Append("; "))

    /// A length unit (px) specifying the size of the border-width
    [<CustomOperation("borderImageWidthLength")>]
    member inline _.borderImageWidthLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-width: ").Append(string value + "px").Append("; "))

    /// Default value 1. Represents multiples of the corresponding border-width
    [<CustomOperation("borderImageWidthNumber")>]
    member inline _.borderImageWidthNumber([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-image-width: ").Append(value).Append("; "))

    /// Specifies the color of the borders in the inline direction. Default value is the color of the text
    [<CustomOperation("borderInlineBorderInlineColor")>]
    member inline _.borderInlineBorderInlineColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline: ").Append(defaultArg value "border-inline-color").Append("; "))

    /// Specifies the style of the borders in the inline direction. Default value is "none"
    [<CustomOperation("borderInlineBorderInlineStyle")>]
    member inline _.borderInlineBorderInlineStyle([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline: ").Append(defaultArg value "border-inline-style").Append("; "))

    /// Specifies the width of the borders in the inline direction. Default value is "medium"
    [<CustomOperation("borderInlineBorderInlineWidth")>]
    member inline _.borderInlineBorderInlineWidth([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline: ").Append(defaultArg value "border-inline-width").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderInlineInherit")>]
    member inline _.borderInlineInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderInlineInitial")>]
    member inline _.borderInlineInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline: ").Append("initial").Append("; "))

    /// Specifies the border color. Look at  CSS Color Values for a complete list of possible color values. Default color is the current color of the element
    [<CustomOperation("borderInlineColorColor")>]
    member inline _.borderInlineColorColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-color: ").Append(defaultArg value "color").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderInlineColorInherit")>]
    member inline _.borderInlineColorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-color: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderInlineColorInitial")>]
    member inline _.borderInlineColorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-color: ").Append("initial").Append("; "))

    /// Specifies that the border color should be transparent
    [<CustomOperation("borderInlineColorTransparent")>]
    member inline _.borderInlineColorTransparent([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-color: ").Append(defaultArg value "transparent").Append("; "))

    /// Specifies the color of an element's border at the end of the inline direction. Default value is the current color of the border
    [<CustomOperation("borderInlineEndBorderInlineEndColor")>]
    member inline _.borderInlineEndBorderInlineEndColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end: ").Append(defaultArg value "border-inline-end-color").Append("; "))

    /// Specifies the style of an element's border at the end of the inline direction. Default value is "none"
    [<CustomOperation("borderInlineEndBorderInlineEndStyle")>]
    member inline _.borderInlineEndBorderInlineEndStyle([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end: ").Append(defaultArg value "border-inline-end-style").Append("; "))

    /// Specifies the width of an element's border at the end of the inline direction. Default value is "medium"
    [<CustomOperation("borderInlineEndBorderInlineEndWidth")>]
    member inline _.borderInlineEndBorderInlineEndWidth([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end: ").Append(defaultArg value "border-inline-end-width").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderInlineEndInherit")>]
    member inline _.borderInlineEndInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderInlineEndInitial")>]
    member inline _.borderInlineEndInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end: ").Append("initial").Append("; "))

    /// Specifies the border color. Look at  CSS Color Values for a complete list of possible color values. Default color is the current color of the element
    [<CustomOperation("borderInlineEndColorColor")>]
    member inline _.borderInlineEndColorColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-color: ").Append(defaultArg value "color").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderInlineEndColorInherit")>]
    member inline _.borderInlineEndColorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-color: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderInlineEndColorInitial")>]
    member inline _.borderInlineEndColorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-color: ").Append("initial").Append("; "))

    /// Specifies that the border color should be transparent
    [<CustomOperation("borderInlineEndColorTransparent")>]
    member inline _.borderInlineEndColorTransparent([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-color: ").Append(defaultArg value "transparent").Append("; "))

    /// Specifies a dashed border
    [<CustomOperation("borderInlineEndStyleDashed")>]
    member inline _.borderInlineEndStyleDashed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append(defaultArg value "dashed").Append("; "))

    /// Specifies a dotted border
    [<CustomOperation("borderInlineEndStyleDotted")>]
    member inline _.borderInlineEndStyleDotted([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append(defaultArg value "dotted").Append("; "))

    /// Specifies a double border
    [<CustomOperation("borderInlineEndStyleDouble")>]
    member inline _.borderInlineEndStyleDouble([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append(defaultArg value "double").Append("; "))

    /// Specifies a 3D grooved border. The effect depends on the border-color value
    [<CustomOperation("borderInlineEndStyleGroove")>]
    member inline _.borderInlineEndStyleGroove([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append(defaultArg value "groove").Append("; "))

    /// The same as "none", except in border conflict resolution for table elements
    [<CustomOperation("borderInlineEndStyleHidden")>]
    member inline _.borderInlineEndStyleHidden([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append(defaultArg value "hidden").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderInlineEndStyleInherit")>]
    member inline _.borderInlineEndStyleInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderInlineEndStyleInitial")>]
    member inline _.borderInlineEndStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append("initial").Append("; "))

    /// Specifies a 3D inset border. The effect depends on the border-color value
    [<CustomOperation("borderInlineEndStyleInset")>]
    member inline _.borderInlineEndStyleInset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append(defaultArg value "inset").Append("; "))

    /// Default value. Specifies no border
    [<CustomOperation("borderInlineEndStyleNone")>]
    member inline _.borderInlineEndStyleNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append(defaultArg value "none").Append("; "))

    /// Specifies a 3D outset border. The effect depends on the border-color value
    [<CustomOperation("borderInlineEndStyleOutset")>]
    member inline _.borderInlineEndStyleOutset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append(defaultArg value "outset").Append("; "))

    /// Specifies a 3D ridged border. The effect depends on the border-color value
    [<CustomOperation("borderInlineEndStyleRigde")>]
    member inline _.borderInlineEndStyleRigde([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append(defaultArg value "rigde").Append("; "))

    /// Specifies a solid border
    [<CustomOperation("borderInlineEndStyleSolid")>]
    member inline _.borderInlineEndStyleSolid([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-style: ").Append(defaultArg value "solid").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderInlineEndWidthInherit")>]
    member inline _.borderInlineEndWidthInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-width: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderInlineEndWidthInitial")>]
    member inline _.borderInlineEndWidthInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-width: ").Append("initial").Append("; "))

    /// Allows you to define the thickness of the border. Read about length units
    [<CustomOperation("borderInlineEndWidthLength")>]
    member inline _.borderInlineEndWidthLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-width: ").Append(string value + "px").Append("; "))

    /// Specifies a medium border. This is default
    [<CustomOperation("borderInlineEndWidthMedium")>]
    member inline _.borderInlineEndWidthMedium([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-width: ").Append(defaultArg value "medium").Append("; "))

    /// Specifies a thick border
    [<CustomOperation("borderInlineEndWidthThick")>]
    member inline _.borderInlineEndWidthThick([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-width: ").Append(defaultArg value "thick").Append("; "))

    /// Specifies a thin border
    [<CustomOperation("borderInlineEndWidthThin")>]
    member inline _.borderInlineEndWidthThin([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-end-width: ").Append(defaultArg value "thin").Append("; "))

    /// Specifies the color of an element's border at the end of the inline direction. Default value is the current color of the border
    [<CustomOperation("borderInlineStartBorderInlineStartColor")>]
    member inline _.borderInlineStartBorderInlineStartColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start: ").Append(defaultArg value "border-inline-start-color").Append("; "))

    /// Specifies the style of an element's border at the end of the inline direction. Default value is "none"
    [<CustomOperation("borderInlineStartBorderInlineStartStyle")>]
    member inline _.borderInlineStartBorderInlineStartStyle([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start: ").Append(defaultArg value "border-inline-start-style").Append("; "))

    /// Specifies the width of an element's border at the end of the inline direction. Default value is "medium"
    [<CustomOperation("borderInlineStartBorderInlineStartWidth")>]
    member inline _.borderInlineStartBorderInlineStartWidth([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start: ").Append(defaultArg value "border-inline-start-width").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderInlineStartInherit")>]
    member inline _.borderInlineStartInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderInlineStartInitial")>]
    member inline _.borderInlineStartInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start: ").Append("initial").Append("; "))

    /// Specifies the border color. Look at  CSS Color Values for a complete list of possible color values. Default color is the current color of the element
    [<CustomOperation("borderInlineStartColorColor")>]
    member inline _.borderInlineStartColorColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-color: ").Append(defaultArg value "color").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderInlineStartColorInherit")>]
    member inline _.borderInlineStartColorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-color: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderInlineStartColorInitial")>]
    member inline _.borderInlineStartColorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-color: ").Append("initial").Append("; "))

    /// Specifies that the border color should be transparent
    [<CustomOperation("borderInlineStartColorTransparent")>]
    member inline _.borderInlineStartColorTransparent([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-color: ").Append(defaultArg value "transparent").Append("; "))

    /// Specifies a dashed border
    [<CustomOperation("borderInlineStartStyleDashed")>]
    member inline _.borderInlineStartStyleDashed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append(defaultArg value "dashed").Append("; "))

    /// Specifies a dotted border
    [<CustomOperation("borderInlineStartStyleDotted")>]
    member inline _.borderInlineStartStyleDotted([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append(defaultArg value "dotted").Append("; "))

    /// Specifies a double border
    [<CustomOperation("borderInlineStartStyleDouble")>]
    member inline _.borderInlineStartStyleDouble([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append(defaultArg value "double").Append("; "))

    /// Specifies a 3D grooved border. The effect depends on the border-color value
    [<CustomOperation("borderInlineStartStyleGroove")>]
    member inline _.borderInlineStartStyleGroove([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append(defaultArg value "groove").Append("; "))

    /// The same as "none", except in border conflict resolution for table elements
    [<CustomOperation("borderInlineStartStyleHidden")>]
    member inline _.borderInlineStartStyleHidden([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append(defaultArg value "hidden").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderInlineStartStyleInherit")>]
    member inline _.borderInlineStartStyleInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderInlineStartStyleInitial")>]
    member inline _.borderInlineStartStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append("initial").Append("; "))

    /// Specifies a 3D inset border. The effect depends on the border-color value
    [<CustomOperation("borderInlineStartStyleInset")>]
    member inline _.borderInlineStartStyleInset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append(defaultArg value "inset").Append("; "))

    /// Default value. Specifies no border
    [<CustomOperation("borderInlineStartStyleNone")>]
    member inline _.borderInlineStartStyleNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append(defaultArg value "none").Append("; "))

    /// Specifies a 3D outset border. The effect depends on the border-color value
    [<CustomOperation("borderInlineStartStyleOutset")>]
    member inline _.borderInlineStartStyleOutset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append(defaultArg value "outset").Append("; "))

    /// Specifies a 3D ridged border. The effect depends on the border-color value
    [<CustomOperation("borderInlineStartStyleRigde")>]
    member inline _.borderInlineStartStyleRigde([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append(defaultArg value "rigde").Append("; "))

    /// Specifies a solid border
    [<CustomOperation("borderInlineStartStyleSolid")>]
    member inline _.borderInlineStartStyleSolid([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-style: ").Append(defaultArg value "solid").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderInlineStartWidthInherit")>]
    member inline _.borderInlineStartWidthInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-width: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderInlineStartWidthInitial")>]
    member inline _.borderInlineStartWidthInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-width: ").Append("initial").Append("; "))

    /// Allows you to define the thickness of the border. Read about length units
    [<CustomOperation("borderInlineStartWidthLength")>]
    member inline _.borderInlineStartWidthLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-width: ").Append(string value + "px").Append("; "))

    /// Specifies a medium border. This is default
    [<CustomOperation("borderInlineStartWidthMedium")>]
    member inline _.borderInlineStartWidthMedium([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-width: ").Append(defaultArg value "medium").Append("; "))

    /// Specifies a thick border
    [<CustomOperation("borderInlineStartWidthThick")>]
    member inline _.borderInlineStartWidthThick([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-width: ").Append(defaultArg value "thick").Append("; "))

    /// Specifies a thin border
    [<CustomOperation("borderInlineStartWidthThin")>]
    member inline _.borderInlineStartWidthThin([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-start-width: ").Append(defaultArg value "thin").Append("; "))

    /// Specifies a dashed border
    [<CustomOperation("borderInlineStyleDashed")>]
    member inline _.borderInlineStyleDashed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append(defaultArg value "dashed").Append("; "))

    /// Specifies a dotted border
    [<CustomOperation("borderInlineStyleDotted")>]
    member inline _.borderInlineStyleDotted([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append(defaultArg value "dotted").Append("; "))

    /// Specifies a double border
    [<CustomOperation("borderInlineStyleDouble")>]
    member inline _.borderInlineStyleDouble([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append(defaultArg value "double").Append("; "))

    /// Specifies a 3D grooved border. The effect depends on the border-color value
    [<CustomOperation("borderInlineStyleGroove")>]
    member inline _.borderInlineStyleGroove([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append(defaultArg value "groove").Append("; "))

    /// The same as "none", except in border conflict resolution for table elements
    [<CustomOperation("borderInlineStyleHidden")>]
    member inline _.borderInlineStyleHidden([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append(defaultArg value "hidden").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderInlineStyleInherit")>]
    member inline _.borderInlineStyleInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderInlineStyleInitial")>]
    member inline _.borderInlineStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append("initial").Append("; "))

    /// Specifies a 3D inset border. The effect depends on the border-color value
    [<CustomOperation("borderInlineStyleInset")>]
    member inline _.borderInlineStyleInset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append(defaultArg value "inset").Append("; "))

    /// Default value. Specifies no border
    [<CustomOperation("borderInlineStyleNone")>]
    member inline _.borderInlineStyleNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append(defaultArg value "none").Append("; "))

    /// Specifies a 3D outset border. The effect depends on the border-color value
    [<CustomOperation("borderInlineStyleOutset")>]
    member inline _.borderInlineStyleOutset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append(defaultArg value "outset").Append("; "))

    /// Specifies a 3D ridged border. The effect depends on the border-color value
    [<CustomOperation("borderInlineStyleRigde")>]
    member inline _.borderInlineStyleRigde([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append(defaultArg value "rigde").Append("; "))

    /// Specifies a solid border
    [<CustomOperation("borderInlineStyleSolid")>]
    member inline _.borderInlineStyleSolid([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-style: ").Append(defaultArg value "solid").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderInlineWidthInherit")>]
    member inline _.borderInlineWidthInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-width: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderInlineWidthInitial")>]
    member inline _.borderInlineWidthInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-width: ").Append("initial").Append("; "))

    /// Allows you to define the thickness of the border. Read about length units
    [<CustomOperation("borderInlineWidthLength")>]
    member inline _.borderInlineWidthLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-width: ").Append(string value + "px").Append("; "))

    /// Specifies a medium border. This is default
    [<CustomOperation("borderInlineWidthMedium")>]
    member inline _.borderInlineWidthMedium([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-width: ").Append(defaultArg value "medium").Append("; "))

    /// Specifies a thick border
    [<CustomOperation("borderInlineWidthThick")>]
    member inline _.borderInlineWidthThick([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-width: ").Append(defaultArg value "thick").Append("; "))

    /// Specifies a thin border
    [<CustomOperation("borderInlineWidthThin")>]
    member inline _.borderInlineWidthThin([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-inline-width: ").Append(defaultArg value "thin").Append("; "))

    /// Optional. Specifies the color of the left border. Default value is the color of the text
    [<CustomOperation("borderLeftBorderLeftColor")>]
    member inline _.borderLeftBorderLeftColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left: ").Append(defaultArg value "border-left-color").Append("; "))

    /// Required. Specifies the style of the left border. Default value is "none"
    [<CustomOperation("borderLeftBorderLeftStyle")>]
    member inline _.borderLeftBorderLeftStyle([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left: ").Append(defaultArg value "border-left-style").Append("; "))

    /// Optional. Specifies the width of the left border. Default value is "medium"
    [<CustomOperation("borderLeftBorderLeftWidth")>]
    member inline _.borderLeftBorderLeftWidth([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left: ").Append(defaultArg value "border-left-width").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderLeftInherit")>]
    member inline _.borderLeftInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderLeftInitial")>]
    member inline _.borderLeftInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left: ").Append("initial").Append("; "))

    /// Specifies the color of the left border. Look at CSS Color Values for a complete list of possible color values. Default color is the current color of the element
    [<CustomOperation("borderLeftColorColor")>]
    member inline _.borderLeftColorColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-color: ").Append(defaultArg value "color").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderLeftColorInherit")>]
    member inline _.borderLeftColorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-color: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderLeftColorInitial")>]
    member inline _.borderLeftColorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-color: ").Append("initial").Append("; "))

    /// Specifies that the border color should be transparent
    [<CustomOperation("borderLeftColorTransparent")>]
    member inline _.borderLeftColorTransparent([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-color: ").Append(defaultArg value "transparent").Append("; "))

    /// Specifies a dashed border
    [<CustomOperation("borderLeftStyleDashed")>]
    member inline _.borderLeftStyleDashed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append(defaultArg value "dashed").Append("; "))

    /// Specifies a dotted border
    [<CustomOperation("borderLeftStyleDotted")>]
    member inline _.borderLeftStyleDotted([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append(defaultArg value "dotted").Append("; "))

    /// Specifies a double border
    [<CustomOperation("borderLeftStyleDouble")>]
    member inline _.borderLeftStyleDouble([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append(defaultArg value "double").Append("; "))

    /// Specifies a 3D grooved border. The effect depends on the border-color value
    [<CustomOperation("borderLeftStyleGroove")>]
    member inline _.borderLeftStyleGroove([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append(defaultArg value "groove").Append("; "))

    /// The same as "none", except in border conflict resolution for table elements
    [<CustomOperation("borderLeftStyleHidden")>]
    member inline _.borderLeftStyleHidden([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append(defaultArg value "hidden").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderLeftStyleInherit")>]
    member inline _.borderLeftStyleInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderLeftStyleInitial")>]
    member inline _.borderLeftStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append("initial").Append("; "))

    /// Specifies a 3D inset border. The effect depends on the border-color value
    [<CustomOperation("borderLeftStyleInset")>]
    member inline _.borderLeftStyleInset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append(defaultArg value "inset").Append("; "))

    /// Specifies no border. This is default
    [<CustomOperation("borderLeftStyleNone")>]
    member inline _.borderLeftStyleNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append(defaultArg value "none").Append("; "))

    /// Specifies a 3D outset border. The effect depends on the border-color value
    [<CustomOperation("borderLeftStyleOutset")>]
    member inline _.borderLeftStyleOutset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append(defaultArg value "outset").Append("; "))

    /// Specifies a 3D ridged border. The effect depends on the border-color value
    [<CustomOperation("borderLeftStyleRidge")>]
    member inline _.borderLeftStyleRidge([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append(defaultArg value "ridge").Append("; "))

    /// Specifies a solid border
    [<CustomOperation("borderLeftStyleSolid")>]
    member inline _.borderLeftStyleSolid([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-style: ").Append(defaultArg value "solid").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderLeftWidthInherit")>]
    member inline _.borderLeftWidthInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-width: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderLeftWidthInitial")>]
    member inline _.borderLeftWidthInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-width: ").Append("initial").Append("; "))

    /// Allows you to define the thickness of the left border. Read about length units
    [<CustomOperation("borderLeftWidthLength")>]
    member inline _.borderLeftWidthLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-width: ").Append(string value + "px").Append("; "))

    /// Specifies a medium left border. This is default
    [<CustomOperation("borderLeftWidthMedium")>]
    member inline _.borderLeftWidthMedium([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-width: ").Append(defaultArg value "medium").Append("; "))

    /// Specifies a thick left border
    [<CustomOperation("borderLeftWidthThick")>]
    member inline _.borderLeftWidthThick([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-width: ").Append(defaultArg value "thick").Append("; "))

    /// Specifies a thin left border
    [<CustomOperation("borderLeftWidthThin")>]
    member inline _.borderLeftWidthThin([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-left-width: ").Append(defaultArg value "thin").Append("; "))

    /// Defines the shape of the corners in %
    [<CustomOperation("borderRadius")>]
    member inline _.borderRadius([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-radius: ").Append(string value + "%").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderRadiusInherit")>]
    member inline _.borderRadiusInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-radius: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderRadiusInitial")>]
    member inline _.borderRadiusInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-radius: ").Append("initial").Append("; "))

    /// Defines the shape of the corners. Default value is 0. Read about length units
    [<CustomOperation("borderRadiusLength")>]
    member inline _.borderRadiusLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-radius: ").Append(string value + "px").Append("; "))

    /// Optional. Specifies the color of the right border. Default value is the color of the text
    [<CustomOperation("borderRightBorderRightColor")>]
    member inline _.borderRightBorderRightColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right: ").Append(defaultArg value "border-right-color").Append("; "))

    /// Required. Specifies the style of the right border. Default value is "none"
    [<CustomOperation("borderRightBorderRightStyle")>]
    member inline _.borderRightBorderRightStyle([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right: ").Append(defaultArg value "border-right-style").Append("; "))

    /// Required. Specifies the width of the right border. Default value is "medium"
    [<CustomOperation("borderRightBorderRightWidth")>]
    member inline _.borderRightBorderRightWidth([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right: ").Append(defaultArg value "border-right-width").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderRightInherit")>]
    member inline _.borderRightInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderRightInitial")>]
    member inline _.borderRightInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right: ").Append("initial").Append("; "))

    /// Specifies the color of the right border. Look at CSS Color Values for a complete list of possible color values. Default color is the current color of the element
    [<CustomOperation("borderRightColorColor")>]
    member inline _.borderRightColorColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-color: ").Append(defaultArg value "color").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderRightColorInherit")>]
    member inline _.borderRightColorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-color: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderRightColorInitial")>]
    member inline _.borderRightColorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-color: ").Append("initial").Append("; "))

    /// Specifies that the border color should be transparent
    [<CustomOperation("borderRightColorTransparent")>]
    member inline _.borderRightColorTransparent([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-color: ").Append(defaultArg value "transparent").Append("; "))

    /// Specifies a dashed border
    [<CustomOperation("borderRightStyleDashed")>]
    member inline _.borderRightStyleDashed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append(defaultArg value "dashed").Append("; "))

    /// Specifies a dotted border
    [<CustomOperation("borderRightStyleDotted")>]
    member inline _.borderRightStyleDotted([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append(defaultArg value "dotted").Append("; "))

    /// Specifies a double border
    [<CustomOperation("borderRightStyleDouble")>]
    member inline _.borderRightStyleDouble([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append(defaultArg value "double").Append("; "))

    /// Specifies a 3D grooved border. The effect depends on the border-color value
    [<CustomOperation("borderRightStyleGroove")>]
    member inline _.borderRightStyleGroove([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append(defaultArg value "groove").Append("; "))

    /// The same as "none", except in border conflict resolution for table elements
    [<CustomOperation("borderRightStyleHidden")>]
    member inline _.borderRightStyleHidden([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append(defaultArg value "hidden").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderRightStyleInherit")>]
    member inline _.borderRightStyleInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderRightStyleInitial")>]
    member inline _.borderRightStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append("initial").Append("; "))

    /// Specifies a 3D inset border. The effect depends on the border-color value
    [<CustomOperation("borderRightStyleInset")>]
    member inline _.borderRightStyleInset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append(defaultArg value "inset").Append("; "))

    /// Specifies no border. This is default
    [<CustomOperation("borderRightStyleNone")>]
    member inline _.borderRightStyleNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append(defaultArg value "none").Append("; "))

    /// Specifies a 3D outset border. The effect depends on the border-color value
    [<CustomOperation("borderRightStyleOutset")>]
    member inline _.borderRightStyleOutset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append(defaultArg value "outset").Append("; "))

    /// Specifies a 3D ridged border. The effect depends on the border-color value
    [<CustomOperation("borderRightStyleRidge")>]
    member inline _.borderRightStyleRidge([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append(defaultArg value "ridge").Append("; "))

    /// Specifies a solid border
    [<CustomOperation("borderRightStyleSolid")>]
    member inline _.borderRightStyleSolid([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-style: ").Append(defaultArg value "solid").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderRightWidthInherit")>]
    member inline _.borderRightWidthInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-width: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderRightWidthInitial")>]
    member inline _.borderRightWidthInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-width: ").Append("initial").Append("; "))

    /// Allows you to define the thickness of the right border. Read about length units
    [<CustomOperation("borderRightWidthLength")>]
    member inline _.borderRightWidthLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-width: ").Append(string value + "px").Append("; "))

    /// Specifies a medium right border. This is default
    [<CustomOperation("borderRightWidthMedium")>]
    member inline _.borderRightWidthMedium([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-width: ").Append(defaultArg value "medium").Append("; "))

    /// Specifies a thick right border
    [<CustomOperation("borderRightWidthThick")>]
    member inline _.borderRightWidthThick([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-width: ").Append(defaultArg value "thick").Append("; "))

    /// Specifies a thin right border
    [<CustomOperation("borderRightWidthThin")>]
    member inline _.borderRightWidthThin([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-right-width: ").Append(defaultArg value "thin").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderSpacingInherit")>]
    member inline _.borderSpacingInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-spacing: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderSpacingInitial")>]
    member inline _.borderSpacingInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-spacing: ").Append("initial").Append("; "))

    /// Specifies the distance between the borders of adjacent cells in px, cm, etc. Negative values are not allowed. If one value is specified, it defines both the horizontal and vertical spacing between cellsIf two values are specified, the first sets the horizontal spacing and the second sets the vertical spacing
    [<CustomOperation("borderSpacingLengthLength")>]
    member inline _.borderSpacingLengthLength([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-spacing: ").Append(defaultArg value "length length").Append("; "))

    /// Defines the shape of the corner at block-start and inline-end in percentange of length of element on corresponding axis.
    [<CustomOperation("borderStartEndRadius")>]
    member inline _.borderStartEndRadius([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-start-end-radius: ").Append(string value + "%").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderStartEndRadiusInherit")>]
    member inline _.borderStartEndRadiusInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-start-end-radius: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderStartEndRadiusInitial")>]
    member inline _.borderStartEndRadiusInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-start-end-radius: ").Append("initial").Append("; "))

    /// Defines the shape of the corner at block-start and inline-end. Read about length units
    [<CustomOperation("borderStartEndRadiusLength")>]
    member inline _.borderStartEndRadiusLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-start-end-radius: ").Append(string value + "px").Append("; "))

    /// Defines the shape of the corner at block-start and inline-start in percentange of length of element on corresponding axis.
    [<CustomOperation("borderStartStartRadius")>]
    member inline _.borderStartStartRadius([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-start-start-radius: ").Append(string value + "%").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderStartStartRadiusInherit")>]
    member inline _.borderStartStartRadiusInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-start-start-radius: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderStartStartRadiusInitial")>]
    member inline _.borderStartStartRadiusInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-start-start-radius: ").Append("initial").Append("; "))

    /// Defines the shape of the corner at block-start and inline-start. Read about length units
    [<CustomOperation("borderStartStartRadiusLength")>]
    member inline _.borderStartStartRadiusLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-start-start-radius: ").Append(string value + "px").Append("; "))

    /// Specifies a dashed border
    [<CustomOperation("borderStyleDashed")>]
    member inline _.borderStyleDashed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-style: ").Append(defaultArg value "dashed").Append("; "))

    /// Specifies a dotted border
    [<CustomOperation("borderStyleDotted")>]
    member inline _.borderStyleDotted([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-style: ").Append(defaultArg value "dotted").Append("; "))

    /// Specifies a double border
    [<CustomOperation("borderStyleDouble")>]
    member inline _.borderStyleDouble([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-style: ").Append(defaultArg value "double").Append("; "))

    /// Specifies a 3D grooved border. The effect depends on the border-color value
    [<CustomOperation("borderStyleGroove")>]
    member inline _.borderStyleGroove([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-style: ").Append(defaultArg value "groove").Append("; "))

    /// The same as "none", except in border conflict resolution for table elements
    [<CustomOperation("borderStyleHidden")>]
    member inline _.borderStyleHidden([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-style: ").Append(defaultArg value "hidden").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderStyleInherit")>]
    member inline _.borderStyleInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-style: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderStyleInitial")>]
    member inline _.borderStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-style: ").Append("initial").Append("; "))

    /// Specifies a 3D inset border. The effect depends on the border-color value
    [<CustomOperation("borderStyleInset")>]
    member inline _.borderStyleInset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-style: ").Append(defaultArg value "inset").Append("; "))

    /// Default value. Specifies no border
    [<CustomOperation("borderStyleNone")>]
    member inline _.borderStyleNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-style: ").Append(defaultArg value "none").Append("; "))

    /// Specifies a 3D outset border. The effect depends on the border-color value
    [<CustomOperation("borderStyleOutset")>]
    member inline _.borderStyleOutset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-style: ").Append(defaultArg value "outset").Append("; "))

    /// Specifies a 3D ridged border. The effect depends on the border-color value
    [<CustomOperation("borderStyleRidge")>]
    member inline _.borderStyleRidge([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-style: ").Append(defaultArg value "ridge").Append("; "))

    /// Specifies a solid border
    [<CustomOperation("borderStyleSolid")>]
    member inline _.borderStyleSolid([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-style: ").Append(defaultArg value "solid").Append("; "))

    /// Optional. Specifies the color of the top border. Default value is the color of the text
    [<CustomOperation("borderTopBorderTopColor")>]
    member inline _.borderTopBorderTopColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top: ").Append(defaultArg value "border-top-color").Append("; "))

    /// Required. Specifies the style of the top border. Default value is "none"
    [<CustomOperation("borderTopBorderTopStyle")>]
    member inline _.borderTopBorderTopStyle([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top: ").Append(defaultArg value "border-top-style").Append("; "))

    /// Required. Specifies the width of the top border. Default value is "medium"
    [<CustomOperation("borderTopBorderTopWidth")>]
    member inline _.borderTopBorderTopWidth([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top: ").Append(defaultArg value "border-top-width").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderTopInherit")>]
    member inline _.borderTopInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderTopInitial")>]
    member inline _.borderTopInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top: ").Append("initial").Append("; "))

    /// Specifies the color of the top border. Look at CSS Color Values for a complete list of possible color values. Default color is the current color of the element
    [<CustomOperation("borderTopColorColor")>]
    member inline _.borderTopColorColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-color: ").Append(defaultArg value "color").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderTopColorInherit")>]
    member inline _.borderTopColorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-color: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderTopColorInitial")>]
    member inline _.borderTopColorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-color: ").Append("initial").Append("; "))

    /// Specifies that the border color should be transparent
    [<CustomOperation("borderTopColorTransparent")>]
    member inline _.borderTopColorTransparent([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-color: ").Append(defaultArg value "transparent").Append("; "))

    /// Defines the shape of the top-left corner in %
    [<CustomOperation("borderTopLeftRadius")>]
    member inline _.borderTopLeftRadius([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-left-radius: ").Append(string value + "%").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderTopLeftRadiusInherit")>]
    member inline _.borderTopLeftRadiusInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-left-radius: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderTopLeftRadiusInitial")>]
    member inline _.borderTopLeftRadiusInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-left-radius: ").Append("initial").Append("; "))

    /// Defines the shape of the top-left corner. Read about length units
    [<CustomOperation("borderTopLeftRadiusLength")>]
    member inline _.borderTopLeftRadiusLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-left-radius: ").Append(string value + "px").Append("; "))

    /// Defines the shape of the top-right corner in %
    [<CustomOperation("borderTopRightRadius")>]
    member inline _.borderTopRightRadius([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-right-radius: ").Append(string value + "%").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderTopRightRadiusInherit")>]
    member inline _.borderTopRightRadiusInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-right-radius: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderTopRightRadiusInitial")>]
    member inline _.borderTopRightRadiusInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-right-radius: ").Append("initial").Append("; "))

    /// Defines the shape of the top-right corner. Read about length units
    [<CustomOperation("borderTopRightRadiusLength")>]
    member inline _.borderTopRightRadiusLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-right-radius: ").Append(string value + "px").Append("; "))

    /// Specifies a dashed border
    [<CustomOperation("borderTopStyleDashed")>]
    member inline _.borderTopStyleDashed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append(defaultArg value "dashed").Append("; "))

    /// Specifies a dotted border
    [<CustomOperation("borderTopStyleDotted")>]
    member inline _.borderTopStyleDotted([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append(defaultArg value "dotted").Append("; "))

    /// Specifies a double border
    [<CustomOperation("borderTopStyleDouble")>]
    member inline _.borderTopStyleDouble([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append(defaultArg value "double").Append("; "))

    /// Specifies a 3D grooved border. The effect depends on the border-color value
    [<CustomOperation("borderTopStyleGroove")>]
    member inline _.borderTopStyleGroove([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append(defaultArg value "groove").Append("; "))

    /// The same as "none", except in border conflict resolution for table elements
    [<CustomOperation("borderTopStyleHidden")>]
    member inline _.borderTopStyleHidden([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append(defaultArg value "hidden").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderTopStyleInherit")>]
    member inline _.borderTopStyleInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderTopStyleInitial")>]
    member inline _.borderTopStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append("initial").Append("; "))

    /// Specifies a 3D inset border. The effect depends on the border-color value
    [<CustomOperation("borderTopStyleInset")>]
    member inline _.borderTopStyleInset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append(defaultArg value "inset").Append("; "))

    /// Specifies no border. This is default
    [<CustomOperation("borderTopStyleNone")>]
    member inline _.borderTopStyleNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append(defaultArg value "none").Append("; "))

    /// Specifies a 3D outset border. The effect depends on the border-color value
    [<CustomOperation("borderTopStyleOutset")>]
    member inline _.borderTopStyleOutset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append(defaultArg value "outset").Append("; "))

    /// Specifies a 3D ridged border. The effect depends on the border-color value
    [<CustomOperation("borderTopStyleRidge")>]
    member inline _.borderTopStyleRidge([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append(defaultArg value "ridge").Append("; "))

    /// Specifies a solid border
    [<CustomOperation("borderTopStyleSolid")>]
    member inline _.borderTopStyleSolid([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-style: ").Append(defaultArg value "solid").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderTopWidthInherit")>]
    member inline _.borderTopWidthInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-width: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderTopWidthInitial")>]
    member inline _.borderTopWidthInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-width: ").Append("initial").Append("; "))

    /// Allows you to define the thickness of the top border. Read about length units
    [<CustomOperation("borderTopWidthLength")>]
    member inline _.borderTopWidthLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-width: ").Append(string value + "px").Append("; "))

    /// Specifies a medium top border. This is default
    [<CustomOperation("borderTopWidthMedium")>]
    member inline _.borderTopWidthMedium([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-width: ").Append(defaultArg value "medium").Append("; "))

    /// Specifies a thick top border
    [<CustomOperation("borderTopWidthThick")>]
    member inline _.borderTopWidthThick([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-width: ").Append(defaultArg value "thick").Append("; "))

    /// Specifies a thin top border
    [<CustomOperation("borderTopWidthThin")>]
    member inline _.borderTopWidthThin([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-top-width: ").Append(defaultArg value "thin").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("borderWidthInherit")>]
    member inline _.borderWidthInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-width: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("borderWidthInitial")>]
    member inline _.borderWidthInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-width: ").Append("initial").Append("; "))

    /// Allows you to define the thickness of the border. Read about length units
    [<CustomOperation("borderWidthLength")>]
    member inline _.borderWidthLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-width: ").Append(string value + "px").Append("; "))

    /// Specifies a medium border. This is default
    [<CustomOperation("borderWidthMedium")>]
    member inline _.borderWidthMedium([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-width: ").Append(defaultArg value "medium").Append("; "))

    /// Specifies a thick border
    [<CustomOperation("borderWidthThick")>]
    member inline _.borderWidthThick([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-width: ").Append(defaultArg value "thick").Append("; "))

    /// Specifies a thin border
    [<CustomOperation("borderWidthThin")>]
    member inline _.borderWidthThin([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border-width: ").Append(defaultArg value "thin").Append("; "))

    /// The border property is a shorthand property for:
    [<CustomOperation("borderBorderColor")>]
    member inline _.borderBorderColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border: ").Append(defaultArg value "border-color").Append("; "))

    /// The border property is a shorthand property for:
    [<CustomOperation("borderBorderStyle")>]
    member inline _.borderBorderStyle([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border: ").Append(defaultArg value "border-style").Append("; "))

    /// The border property is a shorthand property for:
    [<CustomOperation("borderBorderWidth")>]
    member inline _.borderBorderWidth([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border: ").Append(defaultArg value "border-width").Append("; "))

    ///  The bottom property affects the vertical position of a positioned element. This property has no effect on non-positioned elements. 
    [<CustomOperation("bottom")>]
    member inline _.bottom([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("bottom: ").Append(value).Append("; "))

    /// The bottom property affects the vertical position of a positioned element. This property has no effect on non-positioned elements.
    [<CustomOperation("bottom")>]
    member inline _.bottom([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("bottom: ").Append(string value + "%").Append("; "))

    /// The bottom property affects the vertical position of a positioned element. This property has no effect on non-positioned elements.
    [<CustomOperation("bottomAuto")>]
    member inline _.bottomAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("bottom: ").Append("auto").Append("; "))

    /// The bottom property affects the vertical position of a positioned element. This property has no effect on non-positioned elements.
    [<CustomOperation("bottomInherit")>]
    member inline _.bottomInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("bottom: ").Append("inherit").Append("; "))

    /// The bottom property affects the vertical position of a positioned element. This property has no effect on non-positioned elements.
    [<CustomOperation("bottomInitial")>]
    member inline _.bottomInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("bottom: ").Append("initial").Append("; "))

    /// The bottom property affects the vertical position of a positioned element. This property has no effect on non-positioned elements.
    [<CustomOperation("bottomLength")>]
    member inline _.bottomLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("bottom: ").Append(string value + "px").Append("; "))

    ///  The box-decoration-break property specifies how the background, padding, border, border-image, box-shadow, margin, and clip-path of an element is applied when the box for the element is fragmented. 
    [<CustomOperation("boxDecorationBreak")>]
    member inline _.boxDecorationBreak([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-decoration-break: ").Append(value).Append("; "))

    /// The box-decoration-break property specifies how the background, padding, border, border-image, box-shadow, margin, and clip-path of an element is applied when the box for the element is fragmented.
    [<CustomOperation("boxDecorationBreakClone")>]
    member inline _.boxDecorationBreakClone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-decoration-break: ").Append(defaultArg value " clone").Append("; "))

    /// The box-decoration-break property specifies how the background, padding, border, border-image, box-shadow, margin, and clip-path of an element is applied when the box for the element is fragmented.
    [<CustomOperation("boxDecorationBreakSlice")>]
    member inline _.boxDecorationBreakSlice([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-decoration-break: ").Append(defaultArg value " slice").Append("; "))

    /// The box-decoration-break property specifies how the background, padding, border, border-image, box-shadow, margin, and clip-path of an element is applied when the box for the element is fragmented.
    [<CustomOperation("boxDecorationBreakInherit")>]
    member inline _.boxDecorationBreakInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-decoration-break: ").Append("inherit").Append("; "))

    /// The box-decoration-break property specifies how the background, padding, border, border-image, box-shadow, margin, and clip-path of an element is applied when the box for the element is fragmented.
    [<CustomOperation("boxDecorationBreakInitial")>]
    member inline _.boxDecorationBreakInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-decoration-break: ").Append("initial").Append("; "))

    ///  The box-reflect property is used to create a reflection of an element. 
    [<CustomOperation("boxReflect")>]
    member inline _.boxReflect([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-reflect: ").Append(value).Append("; "))

    /// The box-reflect property is used to create a reflection of an element.
    [<CustomOperation("boxReflectAbove")>]
    member inline _.boxReflectAbove([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-reflect: ").Append(defaultArg value "above").Append("; "))

    /// The box-reflect property is used to create a reflection of an element.
    [<CustomOperation("boxReflectBelow")>]
    member inline _.boxReflectBelow([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-reflect: ").Append(defaultArg value "below").Append("; "))

    /// The box-reflect property is used to create a reflection of an element.
    [<CustomOperation("boxReflectInherit")>]
    member inline _.boxReflectInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-reflect: ").Append("inherit").Append("; "))

    /// The box-reflect property is used to create a reflection of an element.
    [<CustomOperation("boxReflectInitial")>]
    member inline _.boxReflectInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-reflect: ").Append("initial").Append("; "))

    /// The box-reflect property is used to create a reflection of an element.
    [<CustomOperation("boxReflectLeft")>]
    member inline _.boxReflectLeft([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-reflect: ").Append(defaultArg value "left").Append("; "))

    /// The box-reflect property is used to create a reflection of an element.
    [<CustomOperation("boxReflectNone")>]
    member inline _.boxReflectNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-reflect: ").Append(defaultArg value "none").Append("; "))

    /// The box-reflect property is used to create a reflection of an element.
    [<CustomOperation("boxReflectPositionOffset")>]
    member inline _.boxReflectPositionOffset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-reflect: ").Append(defaultArg value "position offset").Append("; "))

    /// The box-reflect property is used to create a reflection of an element.
    [<CustomOperation("boxReflectPositionOffsetGradient")>]
    member inline _.boxReflectPositionOffsetGradient([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-reflect: ").Append(defaultArg value "position offset gradient").Append("; "))

    /// The box-reflect property is used to create a reflection of an element.
    [<CustomOperation("boxReflectRight")>]
    member inline _.boxReflectRight([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-reflect: ").Append(defaultArg value "right").Append("; "))

    ///  The box-shadow property attaches one or more shadows to an element. 
    [<CustomOperation("boxShadow")>]
    member inline _.boxShadow([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-shadow: ").Append(value).Append("; "))

    /// The box-shadow property attaches one or more shadows to an element.
    [<CustomOperation("boxShadowBlur")>]
    member inline _.boxShadowBlur([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-shadow: ").Append(defaultArg value "blur").Append("; "))

    /// The box-shadow property attaches one or more shadows to an element.
    [<CustomOperation("boxShadowColor")>]
    member inline _.boxShadowColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-shadow: ").Append(defaultArg value "color").Append("; "))

    /// The box-shadow property attaches one or more shadows to an element.
    [<CustomOperation("boxShadowHOffset")>]
    member inline _.boxShadowHOffset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-shadow: ").Append(defaultArg value "h-offset").Append("; "))

    /// The box-shadow property attaches one or more shadows to an element.
    [<CustomOperation("boxShadowInherit")>]
    member inline _.boxShadowInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-shadow: ").Append("inherit").Append("; "))

    /// The box-shadow property attaches one or more shadows to an element.
    [<CustomOperation("boxShadowInitial")>]
    member inline _.boxShadowInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-shadow: ").Append("initial").Append("; "))

    /// The box-shadow property attaches one or more shadows to an element.
    [<CustomOperation("boxShadowInset")>]
    member inline _.boxShadowInset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-shadow: ").Append(defaultArg value "inset").Append("; "))

    /// The box-shadow property attaches one or more shadows to an element.
    [<CustomOperation("boxShadowNone")>]
    member inline _.boxShadowNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-shadow: ").Append(defaultArg value "none").Append("; "))

    /// The box-shadow property attaches one or more shadows to an element.
    [<CustomOperation("boxShadowSpread")>]
    member inline _.boxShadowSpread([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-shadow: ").Append(defaultArg value "spread").Append("; "))

    /// The box-shadow property attaches one or more shadows to an element.
    [<CustomOperation("boxShadowVOffset")>]
    member inline _.boxShadowVOffset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-shadow: ").Append(defaultArg value "v-offset").Append("; "))

    ///  The box-sizing property defines how the width and height of an element are calculated: should they include padding and borders, or not. 
    [<CustomOperation("boxSizing")>]
    member inline _.boxSizing([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-sizing: ").Append(value).Append("; "))

    /// The box-sizing property defines how the width and height of an element are calculated: should they include padding and borders, or not.
    [<CustomOperation("boxSizingBorderBox")>]
    member inline _.boxSizingBorderBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-sizing: ").Append(defaultArg value " border-box").Append("; "))

    /// The box-sizing property defines how the width and height of an element are calculated: should they include padding and borders, or not.
    [<CustomOperation("boxSizingContentBox")>]
    member inline _.boxSizingContentBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-sizing: ").Append(defaultArg value " content-box").Append("; "))

    /// The box-sizing property defines how the width and height of an element are calculated: should they include padding and borders, or not.
    [<CustomOperation("boxSizingInherit")>]
    member inline _.boxSizingInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-sizing: ").Append("inherit").Append("; "))

    /// The box-sizing property defines how the width and height of an element are calculated: should they include padding and borders, or not.
    [<CustomOperation("boxSizingInitial")>]
    member inline _.boxSizingInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("box-sizing: ").Append("initial").Append("; "))

    ///  The break-after property specifies whether or not a page break, column break, or region break should occur after the specified element. 
    [<CustomOperation("breakAfter")>]
    member inline _.breakAfter([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-after: ").Append(value).Append("; "))

    /// The break-after property specifies whether or not a page break, column break, or region break should occur after the specified element.
    [<CustomOperation("breakAfterAll")>]
    member inline _.breakAfterAll([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-after: ").Append(defaultArg value "all").Append("; "))

    /// The break-after property specifies whether or not a page break, column break, or region break should occur after the specified element.
    [<CustomOperation("breakAfterAlways")>]
    member inline _.breakAfterAlways([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-after: ").Append(defaultArg value "always").Append("; "))

    /// The break-after property specifies whether or not a page break, column break, or region break should occur after the specified element.
    [<CustomOperation("breakAfterAuto")>]
    member inline _.breakAfterAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-after: ").Append("auto").Append("; "))

    /// The break-after property specifies whether or not a page break, column break, or region break should occur after the specified element.
    [<CustomOperation("breakAfterAvoid")>]
    member inline _.breakAfterAvoid([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-after: ").Append(defaultArg value "avoid").Append("; "))

    /// The break-after property specifies whether or not a page break, column break, or region break should occur after the specified element.
    [<CustomOperation("breakAfterAvoidColumn")>]
    member inline _.breakAfterAvoidColumn([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-after: ").Append(defaultArg value "avoid-column").Append("; "))

    /// The break-after property specifies whether or not a page break, column break, or region break should occur after the specified element.
    [<CustomOperation("breakAfterAvoidPage")>]
    member inline _.breakAfterAvoidPage([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-after: ").Append(defaultArg value "avoid-page").Append("; "))

    /// The break-after property specifies whether or not a page break, column break, or region break should occur after the specified element.
    [<CustomOperation("breakAfterAvoidRegion")>]
    member inline _.breakAfterAvoidRegion([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-after: ").Append(defaultArg value "avoid-region").Append("; "))

    /// The break-after property specifies whether or not a page break, column break, or region break should occur after the specified element.
    [<CustomOperation("breakAfterColumn")>]
    member inline _.breakAfterColumn([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-after: ").Append(defaultArg value "column").Append("; "))

    /// The break-after property specifies whether or not a page break, column break, or region break should occur after the specified element.
    [<CustomOperation("breakAfterInherit")>]
    member inline _.breakAfterInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-after: ").Append("inherit").Append("; "))

    /// The break-after property specifies whether or not a page break, column break, or region break should occur after the specified element.
    [<CustomOperation("breakAfterInitial")>]
    member inline _.breakAfterInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-after: ").Append("initial").Append("; "))

    /// The break-after property specifies whether or not a page break, column break, or region break should occur after the specified element.
    [<CustomOperation("breakAfterLeft")>]
    member inline _.breakAfterLeft([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-after: ").Append(defaultArg value "left").Append("; "))

    /// The break-after property specifies whether or not a page break, column break, or region break should occur after the specified element.
    [<CustomOperation("breakAfterPage")>]
    member inline _.breakAfterPage([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-after: ").Append(defaultArg value "page").Append("; "))

    /// The break-after property specifies whether or not a page break, column break, or region break should occur after the specified element.
    [<CustomOperation("breakAfterRecto")>]
    member inline _.breakAfterRecto([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-after: ").Append(defaultArg value "recto").Append("; "))

    /// The break-after property specifies whether or not a page break, column break, or region break should occur after the specified element.
    [<CustomOperation("breakAfterRegion")>]
    member inline _.breakAfterRegion([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-after: ").Append(defaultArg value "region").Append("; "))

    /// The break-after property specifies whether or not a page break, column break, or region break should occur after the specified element.
    [<CustomOperation("breakAfterRight")>]
    member inline _.breakAfterRight([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-after: ").Append(defaultArg value "right").Append("; "))

    /// The break-after property specifies whether or not a page break, column break, or region break should occur after the specified element.
    [<CustomOperation("breakAfterVerso")>]
    member inline _.breakAfterVerso([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-after: ").Append(defaultArg value "verso").Append("; "))

    ///  The break-before property specifies whether or not a page break, column break, or region break should occur before the specified element. 
    [<CustomOperation("breakBefore")>]
    member inline _.breakBefore([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-before: ").Append(value).Append("; "))

    /// The break-before property specifies whether or not a page break, column break, or region break should occur before the specified element.
    [<CustomOperation("breakBeforeAll")>]
    member inline _.breakBeforeAll([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-before: ").Append(defaultArg value "all").Append("; "))

    /// The break-before property specifies whether or not a page break, column break, or region break should occur before the specified element.
    [<CustomOperation("breakBeforeAlways")>]
    member inline _.breakBeforeAlways([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-before: ").Append(defaultArg value "always").Append("; "))

    /// The break-before property specifies whether or not a page break, column break, or region break should occur before the specified element.
    [<CustomOperation("breakBeforeAuto")>]
    member inline _.breakBeforeAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-before: ").Append("auto").Append("; "))

    /// The break-before property specifies whether or not a page break, column break, or region break should occur before the specified element.
    [<CustomOperation("breakBeforeAvoid")>]
    member inline _.breakBeforeAvoid([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-before: ").Append(defaultArg value "avoid").Append("; "))

    /// The break-before property specifies whether or not a page break, column break, or region break should occur before the specified element.
    [<CustomOperation("breakBeforeAvoidColumn")>]
    member inline _.breakBeforeAvoidColumn([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-before: ").Append(defaultArg value "avoid-column").Append("; "))

    /// The break-before property specifies whether or not a page break, column break, or region break should occur before the specified element.
    [<CustomOperation("breakBeforeAvoidPage")>]
    member inline _.breakBeforeAvoidPage([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-before: ").Append(defaultArg value "avoid-page").Append("; "))

    /// The break-before property specifies whether or not a page break, column break, or region break should occur before the specified element.
    [<CustomOperation("breakBeforeAvoidRegion")>]
    member inline _.breakBeforeAvoidRegion([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-before: ").Append(defaultArg value "avoid-region").Append("; "))

    /// The break-before property specifies whether or not a page break, column break, or region break should occur before the specified element.
    [<CustomOperation("breakBeforeColumn")>]
    member inline _.breakBeforeColumn([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-before: ").Append(defaultArg value "column").Append("; "))

    /// The break-before property specifies whether or not a page break, column break, or region break should occur before the specified element.
    [<CustomOperation("breakBeforeInherit")>]
    member inline _.breakBeforeInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-before: ").Append("inherit").Append("; "))

    /// The break-before property specifies whether or not a page break, column break, or region break should occur before the specified element.
    [<CustomOperation("breakBeforeInitial")>]
    member inline _.breakBeforeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-before: ").Append("initial").Append("; "))

    /// The break-before property specifies whether or not a page break, column break, or region break should occur before the specified element.
    [<CustomOperation("breakBeforeLeft")>]
    member inline _.breakBeforeLeft([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-before: ").Append(defaultArg value "left").Append("; "))

    /// The break-before property specifies whether or not a page break, column break, or region break should occur before the specified element.
    [<CustomOperation("breakBeforePage")>]
    member inline _.breakBeforePage([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-before: ").Append(defaultArg value "page").Append("; "))

    /// The break-before property specifies whether or not a page break, column break, or region break should occur before the specified element.
    [<CustomOperation("breakBeforeRecto")>]
    member inline _.breakBeforeRecto([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-before: ").Append(defaultArg value "recto").Append("; "))

    /// The break-before property specifies whether or not a page break, column break, or region break should occur before the specified element.
    [<CustomOperation("breakBeforeRegion")>]
    member inline _.breakBeforeRegion([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-before: ").Append(defaultArg value "region").Append("; "))

    /// The break-before property specifies whether or not a page break, column break, or region break should occur before the specified element.
    [<CustomOperation("breakBeforeRight")>]
    member inline _.breakBeforeRight([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-before: ").Append(defaultArg value "right").Append("; "))

    /// The break-before property specifies whether or not a page break, column break, or region break should occur before the specified element.
    [<CustomOperation("breakBeforeVerso")>]
    member inline _.breakBeforeVerso([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-before: ").Append(defaultArg value "verso").Append("; "))

    ///  The break-inside property specifies whether or not a page break, column break, or region break should occur inside the specified element. 
    [<CustomOperation("breakInside")>]
    member inline _.breakInside([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-inside: ").Append(value).Append("; "))

    /// The break-inside property specifies whether or not a page break, column break, or region break should occur inside the specified element.
    [<CustomOperation("breakInsideAuto")>]
    member inline _.breakInsideAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-inside: ").Append("auto").Append("; "))

    /// The break-inside property specifies whether or not a page break, column break, or region break should occur inside the specified element.
    [<CustomOperation("breakInsideAvoid")>]
    member inline _.breakInsideAvoid([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-inside: ").Append(defaultArg value "avoid").Append("; "))

    /// The break-inside property specifies whether or not a page break, column break, or region break should occur inside the specified element.
    [<CustomOperation("breakInsideAvoidColumn")>]
    member inline _.breakInsideAvoidColumn([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-inside: ").Append(defaultArg value "avoid-column").Append("; "))

    /// The break-inside property specifies whether or not a page break, column break, or region break should occur inside the specified element.
    [<CustomOperation("breakInsideAvoidPage")>]
    member inline _.breakInsideAvoidPage([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-inside: ").Append(defaultArg value "avoid-page").Append("; "))

    /// The break-inside property specifies whether or not a page break, column break, or region break should occur inside the specified element.
    [<CustomOperation("breakInsideAvoidRegion")>]
    member inline _.breakInsideAvoidRegion([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-inside: ").Append(defaultArg value "avoid-region").Append("; "))

    /// The break-inside property specifies whether or not a page break, column break, or region break should occur inside the specified element.
    [<CustomOperation("breakInsideInherit")>]
    member inline _.breakInsideInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-inside: ").Append("inherit").Append("; "))

    /// The break-inside property specifies whether or not a page break, column break, or region break should occur inside the specified element.
    [<CustomOperation("breakInsideInitial")>]
    member inline _.breakInsideInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("break-inside: ").Append("initial").Append("; "))

    ///  The caption-side property specifies the placement of a table caption. 
    [<CustomOperation("captionSide")>]
    member inline _.captionSide([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("caption-side: ").Append(value).Append("; "))

    /// The caption-side property specifies the placement of a table caption.
    [<CustomOperation("captionSideBottom")>]
    member inline _.captionSideBottom([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("caption-side: ").Append(defaultArg value "bottom").Append("; "))

    /// The caption-side property specifies the placement of a table caption.
    [<CustomOperation("captionSideInherit")>]
    member inline _.captionSideInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("caption-side: ").Append("inherit").Append("; "))

    /// The caption-side property specifies the placement of a table caption.
    [<CustomOperation("captionSideInitial")>]
    member inline _.captionSideInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("caption-side: ").Append("initial").Append("; "))

    /// The caption-side property specifies the placement of a table caption.
    [<CustomOperation("captionSideTop")>]
    member inline _.captionSideTop([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("caption-side: ").Append(defaultArg value "top").Append("; "))

    ///  The caret-color property specifies the color of the cursor (caret) in inputs, textareas, or any element that is editable. 
    [<CustomOperation("caretColor")>]
    member inline _.caretColor([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("caret-color: ").Append(value).Append("; "))

    /// The caret-color property specifies the color of the cursor (caret) in inputs, textareas, or any element that is editable.
    [<CustomOperation("caretColorAuto")>]
    member inline _.caretColorAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("caret-color: ").Append("auto").Append("; "))

    /// The caret-color property specifies the color of the cursor (caret) in inputs, textareas, or any element that is editable.
    [<CustomOperation("caretColorColor")>]
    member inline _.caretColorColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("caret-color: ").Append(defaultArg value "color").Append("; "))

    /// The caret-color property specifies the color of the cursor (caret) in inputs, textareas, or any element that is editable.
    [<CustomOperation("caretColorInherit")>]
    member inline _.caretColorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("caret-color: ").Append("inherit").Append("; "))

    /// The caret-color property specifies the color of the cursor (caret) in inputs, textareas, or any element that is editable.
    [<CustomOperation("caretColorInitial")>]
    member inline _.caretColorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("caret-color: ").Append("initial").Append("; "))

    /// 
    [<CustomOperation("clear")>]
    member inline _.clear([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("clear: ").Append(value).Append("; "))

    /// Note: The clip property is deprecated and is replaced by the clip-path property. 
    [<CustomOperation("clip")>]
    member inline _.clip([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("clip: ").Append(value).Append("; "))

    /// Clips an element to a basic shape: circle, ellipse, polygon or inset
    [<CustomOperation("clipPathBasicShape")>]
    member inline _.clipPathBasicShape([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append(defaultArg value "basic-shape").Append("; "))

    /// Uses the border box as the reference box
    [<CustomOperation("clipPathBorderBox")>]
    member inline _.clipPathBorderBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append(defaultArg value "border-box").Append("; "))

    /// Defines a URL to an SVG  element
    [<CustomOperation("clipPathClipSource")>]
    member inline _.clipPathClipSource([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append(defaultArg value "clip-source").Append("; "))

    /// Uses the content box as the reference box
    [<CustomOperation("clipPathContentBox")>]
    member inline _.clipPathContentBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append(defaultArg value "content-box").Append("; "))

    /// Uses the object bounding box as reference box
    [<CustomOperation("clipPathFillBox")>]
    member inline _.clipPathFillBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append(defaultArg value "fill-box").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("clipPathInherit")>]
    member inline _.clipPathInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("clipPathInitial")>]
    member inline _.clipPathInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append("initial").Append("; "))

    /// Uses the margin box as the reference box
    [<CustomOperation("clipPathMarginBox")>]
    member inline _.clipPathMarginBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append(defaultArg value "margin-box").Append("; "))

    /// This is default. No clipping is done
    [<CustomOperation("clipPathNone")>]
    member inline _.clipPathNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append(defaultArg value "none").Append("; "))

    /// Uses the padding box as the reference box
    [<CustomOperation("clipPathPaddingBox")>]
    member inline _.clipPathPaddingBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append(defaultArg value "padding-box").Append("; "))

    /// Uses the stroke bounding box as reference box
    [<CustomOperation("clipPathStrokeBox")>]
    member inline _.clipPathStrokeBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append(defaultArg value "stroke-box").Append("; "))

    /// Uses the SVG viewport as reference box
    [<CustomOperation("clipPathViewBox")>]
    member inline _.clipPathViewBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("clip-path: ").Append(defaultArg value "view-box").Append("; "))

    /// Note: The clip property is deprecated and is replaced by the clip-path property.
    [<CustomOperation("clipAuto")>]
    member inline _.clipAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("clip: ").Append("auto").Append("; "))

    /// Note: The clip property is deprecated and is replaced by the clip-path property.
    [<CustomOperation("clipShape")>]
    member inline _.clipShape([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("clip: ").Append(defaultArg value "shape").Append("; "))

    ///  The color property specifies the color of text. 
    [<CustomOperation("color")>]
    member inline _.color([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("color: ").Append(value).Append("; "))

    /// The color property specifies the color of text.
    [<CustomOperation("colorColor")>]
    member inline _.colorColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("color: ").Append(defaultArg value "color").Append("; "))

    /// The color property specifies the color of text.
    [<CustomOperation("colorInherit")>]
    member inline _.colorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("color: ").Append("inherit").Append("; "))

    /// The color property specifies the color of text.
    [<CustomOperation("colorInitial")>]
    member inline _.colorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("color: ").Append("initial").Append("; "))

    ///  The column-count property specifies the number of columns an element should be divided into. 
    [<CustomOperation("columnCount")>]
    member inline _.columnCount([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-count: ").Append(value).Append("; "))

    /// The column-count property specifies the number of columns an element should be divided into.
    [<CustomOperation("columnCountAuto")>]
    member inline _.columnCountAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-count: ").Append("auto").Append("; "))

    /// The column-count property specifies the number of columns an element should be divided into.
    [<CustomOperation("columnCountInherit")>]
    member inline _.columnCountInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-count: ").Append("inherit").Append("; "))

    /// The column-count property specifies the number of columns an element should be divided into.
    [<CustomOperation("columnCountInitial")>]
    member inline _.columnCountInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-count: ").Append("initial").Append("; "))

    /// The column-count property specifies the number of columns an element should be divided into.
    [<CustomOperation("columnCountNumber")>]
    member inline _.columnCountNumber([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-count: ").Append(value).Append("; "))

    ///  The column-fill property specifies how to fill columns, balanced or not. 
    [<CustomOperation("columnFill")>]
    member inline _.columnFill([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-fill: ").Append(value).Append("; "))

    /// The column-fill property specifies how to fill columns, balanced or not.
    [<CustomOperation("columnFillAuto")>]
    member inline _.columnFillAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-fill: ").Append("auto").Append("; "))

    /// The column-fill property specifies how to fill columns, balanced or not.
    [<CustomOperation("columnFillBalance")>]
    member inline _.columnFillBalance([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-fill: ").Append(defaultArg value "balance").Append("; "))

    /// The column-fill property specifies how to fill columns, balanced or not.
    [<CustomOperation("columnFillInherit")>]
    member inline _.columnFillInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-fill: ").Append("inherit").Append("; "))

    /// The column-fill property specifies how to fill columns, balanced or not.
    [<CustomOperation("columnFillInitial")>]
    member inline _.columnFillInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-fill: ").Append("initial").Append("; "))

    ///  The column-gap property specifies the gap between the columns in grid, flexbox or multi-column layout. 
    [<CustomOperation("columnGap")>]
    member inline _.columnGap([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-gap: ").Append(value).Append("; "))

    /// The column-gap property specifies the gap between the columns in grid, flexbox or multi-column layout.
    [<CustomOperation("columnGapInherit")>]
    member inline _.columnGapInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-gap: ").Append("inherit").Append("; "))

    /// The column-gap property specifies the gap between the columns in grid, flexbox or multi-column layout.
    [<CustomOperation("columnGapInitial")>]
    member inline _.columnGapInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-gap: ").Append("initial").Append("; "))

    /// The column-gap property specifies the gap between the columns in grid, flexbox or multi-column layout.
    [<CustomOperation("columnGapLength")>]
    member inline _.columnGapLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-gap: ").Append(string value + "px").Append("; "))

    /// The column-gap property specifies the gap between the columns in grid, flexbox or multi-column layout.
    [<CustomOperation("columnGapNormal")>]
    member inline _.columnGapNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-gap: ").Append(defaultArg value "normal").Append("; "))

    ///  The column-rule property sets the width, style, and color of the rule between columns. 
    [<CustomOperation("columnRule")>]
    member inline _.columnRule([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule: ").Append(value).Append("; "))

    /// Specifies the color of the rule. Look at CSS Color Values for a complete list of possible color values
    [<CustomOperation("columnRuleColorColor")>]
    member inline _.columnRuleColorColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-color: ").Append(defaultArg value "color").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("columnRuleColorInherit")>]
    member inline _.columnRuleColorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-color: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("columnRuleColorInitial")>]
    member inline _.columnRuleColorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-color: ").Append("initial").Append("; "))

    /// Defines a dashed rule
    [<CustomOperation("columnRuleStyleDashed")>]
    member inline _.columnRuleStyleDashed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append(defaultArg value " dashed").Append("; "))

    /// Defines a dotted rule
    [<CustomOperation("columnRuleStyleDotted")>]
    member inline _.columnRuleStyleDotted([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append(defaultArg value " dotted").Append("; "))

    /// Defines a double rule
    [<CustomOperation("columnRuleStyleDouble")>]
    member inline _.columnRuleStyleDouble([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append(defaultArg value " double").Append("; "))

    /// Specifies a 3D grooved rule. The effect depends on the width and color values
    [<CustomOperation("columnRuleStyleGroove")>]
    member inline _.columnRuleStyleGroove([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append(defaultArg value " groove").Append("; "))

    /// Defines a hidden rule
    [<CustomOperation("columnRuleStyleHidden")>]
    member inline _.columnRuleStyleHidden([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append(defaultArg value " hidden").Append("; "))

    /// Specifies a 3D inset rule. The effect depends on the width and color values
    [<CustomOperation("columnRuleStyleInset")>]
    member inline _.columnRuleStyleInset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append(defaultArg value " inset").Append("; "))

    /// Default value. Defines no rule
    [<CustomOperation("columnRuleStyleNone")>]
    member inline _.columnRuleStyleNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append(defaultArg value " none").Append("; "))

    /// Specifies a 3D outset rule. The effect depends on the width and color values
    [<CustomOperation("columnRuleStyleOutset")>]
    member inline _.columnRuleStyleOutset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append(defaultArg value " outset").Append("; "))

    /// Specifies a 3D ridged rule. The effect depends on the width and color values
    [<CustomOperation("columnRuleStyleRidge")>]
    member inline _.columnRuleStyleRidge([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append(defaultArg value " ridge").Append("; "))

    /// Defines a solid rule
    [<CustomOperation("columnRuleStyleSolid")>]
    member inline _.columnRuleStyleSolid([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append(defaultArg value " solid").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("columnRuleStyleInherit")>]
    member inline _.columnRuleStyleInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("columnRuleStyleInitial")>]
    member inline _.columnRuleStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-style: ").Append("initial").Append("; "))

    /// Default value. Defines a medium rule
    [<CustomOperation("columnRuleWidthMedium")>]
    member inline _.columnRuleWidthMedium([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-width: ").Append(defaultArg value " medium").Append("; "))

    /// Defines a thick rule
    [<CustomOperation("columnRuleWidthThick")>]
    member inline _.columnRuleWidthThick([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-width: ").Append(defaultArg value " thick").Append("; "))

    /// Defines a thin rule
    [<CustomOperation("columnRuleWidthThin")>]
    member inline _.columnRuleWidthThin([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-width: ").Append(defaultArg value " thin").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("columnRuleWidthInherit")>]
    member inline _.columnRuleWidthInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-width: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("columnRuleWidthInitial")>]
    member inline _.columnRuleWidthInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-width: ").Append("initial").Append("; "))

    /// Specifies the width of the rule
    [<CustomOperation("columnRuleWidthLength")>]
    member inline _.columnRuleWidthLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule-width: ").Append(string value + "px").Append("; "))

    /// The column-rule property sets the width, style, and color of the rule between columns.
    [<CustomOperation("columnRuleColumnRuleColor")>]
    member inline _.columnRuleColumnRuleColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule: ").Append(defaultArg value "column-rule-color").Append("; "))

    /// The column-rule property sets the width, style, and color of the rule between columns.
    [<CustomOperation("columnRuleColumnRuleStyle")>]
    member inline _.columnRuleColumnRuleStyle([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule: ").Append(defaultArg value "column-rule-style").Append("; "))

    /// The column-rule property sets the width, style, and color of the rule between columns.
    [<CustomOperation("columnRuleColumnRuleWidth")>]
    member inline _.columnRuleColumnRuleWidth([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-rule: ").Append(defaultArg value "column-rule-width").Append("; "))

    ///  The column-span property specifies how many columns an element should span across. 
    [<CustomOperation("columnSpan")>]
    member inline _.columnSpan([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-span: ").Append(value).Append("; "))

    /// The column-span property specifies how many columns an element should span across.
    [<CustomOperation("columnSpanAll")>]
    member inline _.columnSpanAll([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-span: ").Append(defaultArg value "all").Append("; "))

    /// The column-span property specifies how many columns an element should span across.
    [<CustomOperation("columnSpanInherit")>]
    member inline _.columnSpanInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-span: ").Append("inherit").Append("; "))

    /// The column-span property specifies how many columns an element should span across.
    [<CustomOperation("columnSpanInitial")>]
    member inline _.columnSpanInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-span: ").Append("initial").Append("; "))

    /// The column-span property specifies how many columns an element should span across.
    [<CustomOperation("columnSpanNone")>]
    member inline _.columnSpanNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-span: ").Append(defaultArg value "none").Append("; "))

    ///  The column-width property specifies the column width. 
    [<CustomOperation("columnWidth")>]
    member inline _.columnWidth([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-width: ").Append(value).Append("; "))

    /// The column-width property specifies the column width.
    [<CustomOperation("columnWidthAuto")>]
    member inline _.columnWidthAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-width: ").Append("auto").Append("; "))

    /// The column-width property specifies the column width.
    [<CustomOperation("columnWidthInherit")>]
    member inline _.columnWidthInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-width: ").Append("inherit").Append("; "))

    /// The column-width property specifies the column width.
    [<CustomOperation("columnWidthInitial")>]
    member inline _.columnWidthInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-width: ").Append("initial").Append("; "))

    /// The column-width property specifies the column width.
    [<CustomOperation("columnWidthLength")>]
    member inline _.columnWidthLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("column-width: ").Append(string value + "px").Append("; "))

    ///  The columns property is a shorthand property for: 
    [<CustomOperation("columns")>]
    member inline _.columns([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("columns: ").Append(value).Append("; "))

    /// The columns property is a shorthand property for:
    [<CustomOperation("columnsAuto")>]
    member inline _.columnsAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("columns: ").Append("auto").Append("; "))

    /// The columns property is a shorthand property for:
    [<CustomOperation("columnsColumnCount")>]
    member inline _.columnsColumnCount([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("columns: ").Append(defaultArg value "column-count").Append("; "))

    /// The columns property is a shorthand property for:
    [<CustomOperation("columnsColumnWidth")>]
    member inline _.columnsColumnWidth([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("columns: ").Append(defaultArg value "column-width").Append("; "))

    /// The columns property is a shorthand property for:
    [<CustomOperation("columnsInherit")>]
    member inline _.columnsInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("columns: ").Append("inherit").Append("; "))

    /// The columns property is a shorthand property for:
    [<CustomOperation("columnsInitial")>]
    member inline _.columnsInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("columns: ").Append("initial").Append("; "))

    ///  The content property is used with the ::before and ::after pseudo-elements, to insert generated content. 
    [<CustomOperation("content")>]
    member inline _.content([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("content: ").Append(value).Append("; "))

    /// The content property is used with the ::before and ::after pseudo-elements, to insert generated content.
    [<CustomOperation("contentAttr")>]
    member inline _.contentAttr([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("content: ").Append($" attr({value})").Append("; "))

    /// The content property is used with the ::before and ::after pseudo-elements, to insert generated content.
    [<CustomOperation("contentUrl")>]
    member inline _.contentUrl([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("content: ").Append($" url({value})").Append("; "))

    /// The content property is used with the ::before and ::after pseudo-elements, to insert generated content.
    [<CustomOperation("contentCloseQuote")>]
    member inline _.contentCloseQuote([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("content: ").Append(defaultArg value "close-quote").Append("; "))

    /// The content property is used with the ::before and ::after pseudo-elements, to insert generated content.
    [<CustomOperation("contentCounter")>]
    member inline _.contentCounter([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("content: ").Append(defaultArg value "counter").Append("; "))

    /// The content property is used with the ::before and ::after pseudo-elements, to insert generated content.
    [<CustomOperation("contentInherit")>]
    member inline _.contentInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("content: ").Append("inherit").Append("; "))

    /// The content property is used with the ::before and ::after pseudo-elements, to insert generated content.
    [<CustomOperation("contentInitial")>]
    member inline _.contentInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("content: ").Append("initial").Append("; "))

    /// The content property is used with the ::before and ::after pseudo-elements, to insert generated content.
    [<CustomOperation("contentNoCloseQuote")>]
    member inline _.contentNoCloseQuote([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("content: ").Append(defaultArg value "no-close-quote").Append("; "))

    /// The content property is used with the ::before and ::after pseudo-elements, to insert generated content.
    [<CustomOperation("contentNoOpenQuote")>]
    member inline _.contentNoOpenQuote([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("content: ").Append(defaultArg value "no-open-quote").Append("; "))

    /// The content property is used with the ::before and ::after pseudo-elements, to insert generated content.
    [<CustomOperation("contentNone")>]
    member inline _.contentNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("content: ").Append(defaultArg value "none").Append("; "))

    /// The content property is used with the ::before and ::after pseudo-elements, to insert generated content.
    [<CustomOperation("contentNormal")>]
    member inline _.contentNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("content: ").Append(defaultArg value "normal").Append("; "))

    /// The content property is used with the ::before and ::after pseudo-elements, to insert generated content.
    [<CustomOperation("contentOpenQuote")>]
    member inline _.contentOpenQuote([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("content: ").Append(defaultArg value "open-quote").Append("; "))

    /// The content property is used with the ::before and ::after pseudo-elements, to insert generated content.
    [<CustomOperation("contentString")>]
    member inline _.contentString([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("content: ").Append(defaultArg value "string").Append("; "))

    ///  The counter-increment property increases or decreases the value of one or more CSS counters. 
    [<CustomOperation("counterIncrement")>]
    member inline _.counterIncrement([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("counter-increment: ").Append(value).Append("; "))

    /// The counter-increment property increases or decreases the value of one or more CSS counters.
    [<CustomOperation("counterIncrementIdNumber")>]
    member inline _.counterIncrementIdNumber([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("counter-increment: ").Append(value).Append("; "))

    /// The counter-increment property increases or decreases the value of one or more CSS counters.
    [<CustomOperation("counterIncrementInherit")>]
    member inline _.counterIncrementInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("counter-increment: ").Append("inherit").Append("; "))

    /// The counter-increment property increases or decreases the value of one or more CSS counters.
    [<CustomOperation("counterIncrementInitial")>]
    member inline _.counterIncrementInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("counter-increment: ").Append("initial").Append("; "))

    /// The counter-increment property increases or decreases the value of one or more CSS counters.
    [<CustomOperation("counterIncrementNone")>]
    member inline _.counterIncrementNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("counter-increment: ").Append(defaultArg value "none").Append("; "))

    ///  The counter-reset property creates or resets one or more CSS counters. 
    [<CustomOperation("counterReset")>]
    member inline _.counterReset([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("counter-reset: ").Append(value).Append("; "))

    /// The counter-reset property creates or resets one or more CSS counters.
    [<CustomOperation("counterResetIdNumber")>]
    member inline _.counterResetIdNumber([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("counter-reset: ").Append(value).Append("; "))

    /// The counter-reset property creates or resets one or more CSS counters.
    [<CustomOperation("counterResetInherit")>]
    member inline _.counterResetInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("counter-reset: ").Append("inherit").Append("; "))

    /// The counter-reset property creates or resets one or more CSS counters.
    [<CustomOperation("counterResetInitial")>]
    member inline _.counterResetInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("counter-reset: ").Append("initial").Append("; "))

    /// The counter-reset property creates or resets one or more CSS counters.
    [<CustomOperation("counterResetNone")>]
    member inline _.counterResetNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("counter-reset: ").Append(defaultArg value "none").Append("; "))

    ///  The counter-set property creates and sets a CSS counter to a specific value. 
    [<CustomOperation("counterSet")>]
    member inline _.counterSet([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("counter-set: ").Append(value).Append("; "))

    /// The counter-set property creates and sets a CSS counter to a specific value.
    [<CustomOperation("counterSetCounterNameNumber")>]
    member inline _.counterSetCounterNameNumber([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("counter-set: ").Append(value).Append("; "))

    /// The counter-set property creates and sets a CSS counter to a specific value.
    [<CustomOperation("counterSetInherit")>]
    member inline _.counterSetInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("counter-set: ").Append("inherit").Append("; "))

    /// The counter-set property creates and sets a CSS counter to a specific value.
    [<CustomOperation("counterSetInitial")>]
    member inline _.counterSetInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("counter-set: ").Append("initial").Append("; "))

    /// The counter-set property creates and sets a CSS counter to a specific value.
    [<CustomOperation("counterSetNone")>]
    member inline _.counterSetNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("counter-set: ").Append(defaultArg value "none").Append("; "))

    ///  The cursor property specifies the mouse cursor to be displayed when pointing over an element. 
    [<CustomOperation("cursor")>]
    member inline _.cursor([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(value).Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorURL")>]
    member inline _.cursorURL([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "URL").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorAlias")>]
    member inline _.cursorAlias([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "alias").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorAllScroll")>]
    member inline _.cursorAllScroll([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "all-scroll").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorAuto")>]
    member inline _.cursorAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("auto").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorCell")>]
    member inline _.cursorCell([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "cell").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorColResize")>]
    member inline _.cursorColResize([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "col-resize").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorContextMenu")>]
    member inline _.cursorContextMenu([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "context-menu").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorCopy")>]
    member inline _.cursorCopy([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "copy").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorCrosshair")>]
    member inline _.cursorCrosshair([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "crosshair").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorDefault")>]
    member inline _.cursorDefault([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "default").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorEResize")>]
    member inline _.cursorEResize([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "e-resize").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorEwResize")>]
    member inline _.cursorEwResize([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "ew-resize").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorGrab")>]
    member inline _.cursorGrab([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "grab").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorGrabbing")>]
    member inline _.cursorGrabbing([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "grabbing").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorHelp")>]
    member inline _.cursorHelp([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "help").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorInherit")>]
    member inline _.cursorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("inherit").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorInitial")>]
    member inline _.cursorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append("initial").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorMove")>]
    member inline _.cursorMove([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "move").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorNResize")>]
    member inline _.cursorNResize([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "n-resize").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorNeResize")>]
    member inline _.cursorNeResize([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "ne-resize").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorNeswResize")>]
    member inline _.cursorNeswResize([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "nesw-resize").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorNoDrop")>]
    member inline _.cursorNoDrop([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "no-drop").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorNone")>]
    member inline _.cursorNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "none").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorNotAllowed")>]
    member inline _.cursorNotAllowed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "not-allowed").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorNsResize")>]
    member inline _.cursorNsResize([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "ns-resize").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorNwResize")>]
    member inline _.cursorNwResize([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "nw-resize").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorNwseResize")>]
    member inline _.cursorNwseResize([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "nwse-resize").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorPointer")>]
    member inline _.cursorPointer([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "pointer").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorProgress")>]
    member inline _.cursorProgress([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "progress").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorRowResize")>]
    member inline _.cursorRowResize([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "row-resize").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorSResize")>]
    member inline _.cursorSResize([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "s-resize").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorSeResize")>]
    member inline _.cursorSeResize([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "se-resize").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorSwResize")>]
    member inline _.cursorSwResize([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "sw-resize").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorText")>]
    member inline _.cursorText([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "text").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorVerticalText")>]
    member inline _.cursorVerticalText([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "vertical-text").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorWResize")>]
    member inline _.cursorWResize([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "w-resize").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorWait")>]
    member inline _.cursorWait([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "wait").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorZoomIn")>]
    member inline _.cursorZoomIn([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "zoom-in").Append("; "))

    /// The cursor property specifies the mouse cursor to be displayed when pointing over an element.
    [<CustomOperation("cursorZoomOut")>]
    member inline _.cursorZoomOut([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("cursor: ").Append(defaultArg value "zoom-out").Append("; "))

    ///  The direction property specifies the text direction/writing direction within a block-level element. 
    [<CustomOperation("direction")>]
    member inline _.direction([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("direction: ").Append(value).Append("; "))

    /// The direction property specifies the text direction/writing direction within a block-level element.
    [<CustomOperation("directionInherit")>]
    member inline _.directionInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("direction: ").Append("inherit").Append("; "))

    /// The direction property specifies the text direction/writing direction within a block-level element.
    [<CustomOperation("directionInitial")>]
    member inline _.directionInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("direction: ").Append("initial").Append("; "))

    /// The direction property specifies the text direction/writing direction within a block-level element.
    [<CustomOperation("directionLtr")>]
    member inline _.directionLtr([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("direction: ").Append(defaultArg value "ltr").Append("; "))

    /// The direction property specifies the text direction/writing direction within a block-level element.
    [<CustomOperation("directionRtl")>]
    member inline _.directionRtl([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("direction: ").Append(defaultArg value "rtl").Append("; "))

    ///  The display property specifies the display behavior (the type of rendering box) of an element. 
    [<CustomOperation("display")>]
    member inline _.display([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("display: ").Append(value).Append("; "))

    ///  The empty-cells property sets whether or not to display borders on empty cells in a table. 
    [<CustomOperation("emptyCells")>]
    member inline _.emptyCells([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("empty-cells: ").Append(value).Append("; "))

    /// The empty-cells property sets whether or not to display borders on empty cells in a table.
    [<CustomOperation("emptyCellsHide")>]
    member inline _.emptyCellsHide([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("empty-cells: ").Append(defaultArg value "hide").Append("; "))

    /// The empty-cells property sets whether or not to display borders on empty cells in a table.
    [<CustomOperation("emptyCellsInherit")>]
    member inline _.emptyCellsInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("empty-cells: ").Append("inherit").Append("; "))

    /// The empty-cells property sets whether or not to display borders on empty cells in a table.
    [<CustomOperation("emptyCellsInitial")>]
    member inline _.emptyCellsInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("empty-cells: ").Append("initial").Append("; "))

    /// The empty-cells property sets whether or not to display borders on empty cells in a table.
    [<CustomOperation("emptyCellsShow")>]
    member inline _.emptyCellsShow([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("empty-cells: ").Append(defaultArg value "show").Append("; "))

    ///  The filter property defines visual effects (like blur and saturation) to an element (often ). 
    [<CustomOperation("filter")>]
    member inline _.filter([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("filter: ").Append(value).Append("; "))

    ///  The flex property is a shorthand property for: 
    [<CustomOperation("flex")>]
    member inline _.flex([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex: ").Append(value).Append("; "))

    /// Default value. The length is equal to the length of the flexible item. If the item has no length specified, the length will be according to its content
    [<CustomOperation("flexBasisAuto")>]
    member inline _.flexBasisAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-basis: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("flexBasisInherit")>]
    member inline _.flexBasisInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-basis: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("flexBasisInitial")>]
    member inline _.flexBasisInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-basis: ").Append("initial").Append("; "))

    /// A length unit, or percentage, specifying the initial length of the flexible item(s)
    [<CustomOperation("flexBasisNumber")>]
    member inline _.flexBasisNumber([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-basis: ").Append(value).Append("; "))

    /// The flexible items are displayed vertically, as a column
    [<CustomOperation("flexDirectionColumn")>]
    member inline _.flexDirectionColumn([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-direction: ").Append(defaultArg value "column").Append("; "))

    /// Same as column, but in reverse order
    [<CustomOperation("flexDirectionColumnReverse")>]
    member inline _.flexDirectionColumnReverse([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-direction: ").Append(defaultArg value "column-reverse").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("flexDirectionInherit")>]
    member inline _.flexDirectionInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-direction: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("flexDirectionInitial")>]
    member inline _.flexDirectionInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-direction: ").Append("initial").Append("; "))

    /// Default value. The flexible items are displayed horizontally, as a row
    [<CustomOperation("flexDirectionRow")>]
    member inline _.flexDirectionRow([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-direction: ").Append(defaultArg value "row").Append("; "))

    /// Same as row, but in reverse order
    [<CustomOperation("flexDirectionRowReverse")>]
    member inline _.flexDirectionRowReverse([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-direction: ").Append(defaultArg value "row-reverse").Append("; "))

    /// Possible values: row row-reverse column column-reverse initial inherit Default value is "row".Specifying the direction of the flexible items
    [<CustomOperation("flexFlowFlexDirection")>]
    member inline _.flexFlowFlexDirection([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-flow: ").Append(defaultArg value "flex-direction").Append("; "))

    /// Possible values: nowrap wrap wrap-reverse initial inherit Default value is "nowrap".Specifying whether the flexible items should wrap or not
    [<CustomOperation("flexFlowFlexWrap")>]
    member inline _.flexFlowFlexWrap([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-flow: ").Append(defaultArg value "flex-wrap").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("flexFlowInherit")>]
    member inline _.flexFlowInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-flow: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("flexFlowInitial")>]
    member inline _.flexFlowInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-flow: ").Append("initial").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("flexGrowInherit")>]
    member inline _.flexGrowInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-grow: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("flexGrowInitial")>]
    member inline _.flexGrowInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-grow: ").Append("initial").Append("; "))

    /// A number specifying how much the item will grow relative to the rest of the flexible items. Default value is 0
    [<CustomOperation("flexGrowNumber")>]
    member inline _.flexGrowNumber([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-grow: ").Append(value).Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("flexShrinkInherit")>]
    member inline _.flexShrinkInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-shrink: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("flexShrinkInitial")>]
    member inline _.flexShrinkInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-shrink: ").Append("initial").Append("; "))

    /// A number specifying how much the item will shrink relative to the rest of the flexible items. Default value is 1
    [<CustomOperation("flexShrinkNumber")>]
    member inline _.flexShrinkNumber([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-shrink: ").Append(value).Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("flexWrapInherit")>]
    member inline _.flexWrapInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-wrap: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("flexWrapInitial")>]
    member inline _.flexWrapInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-wrap: ").Append("initial").Append("; "))

    /// Default value. Specifies that the flexible items will not wrap
    [<CustomOperation("flexWrapNowrap")>]
    member inline _.flexWrapNowrap([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-wrap: ").Append(defaultArg value "nowrap").Append("; "))

    /// Specifies that the flexible items will wrap if necessary
    [<CustomOperation("flexWrapWrap")>]
    member inline _.flexWrapWrap([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-wrap: ").Append(defaultArg value "wrap").Append("; "))

    /// Specifies that the flexible items will wrap, if necessary, in reverse order
    [<CustomOperation("flexWrapWrapReverse")>]
    member inline _.flexWrapWrapReverse([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex-wrap: ").Append(defaultArg value "wrap-reverse").Append("; "))

    /// The flex property is a shorthand property for:
    [<CustomOperation("flexFlexBasis")>]
    member inline _.flexFlexBasis([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex: ").Append(defaultArg value "flex-basis").Append("; "))

    /// The flex property is a shorthand property for:
    [<CustomOperation("flexFlexGrow")>]
    member inline _.flexFlexGrow([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex: ").Append(defaultArg value "flex-grow").Append("; "))

    /// The flex property is a shorthand property for:
    [<CustomOperation("flexFlexShrink")>]
    member inline _.flexFlexShrink([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex: ").Append(defaultArg value "flex-shrink").Append("; "))

    /// The flex property is a shorthand property for:
    [<CustomOperation("flexNone")>]
    member inline _.flexNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex: ").Append(defaultArg value "none").Append("; "))

    ///  The float property specifies whether an element should float to the left, right, or not at all. 
    [<CustomOperation("float'")>]
    member inline _.float'([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("float: ").Append(value).Append("; "))

    /// The float property specifies whether an element should float to the left, right, or not at all.
    [<CustomOperation("floatInherit")>]
    member inline _.floatInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("float: ").Append("inherit").Append("; "))

    /// The float property specifies whether an element should float to the left, right, or not at all.
    [<CustomOperation("floatInitial")>]
    member inline _.floatInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("float: ").Append("initial").Append("; "))

    /// The float property specifies whether an element should float to the left, right, or not at all.
    [<CustomOperation("floatLeft")>]
    member inline _.floatLeft([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("float: ").Append(defaultArg value "left").Append("; "))

    /// The float property specifies whether an element should float to the left, right, or not at all.
    [<CustomOperation("floatNone")>]
    member inline _.floatNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("float: ").Append(defaultArg value "none").Append("; "))

    /// The float property specifies whether an element should float to the left, right, or not at all.
    [<CustomOperation("floatRight")>]
    member inline _.floatRight([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("float: ").Append(defaultArg value "right").Append("; "))

    ///  The font property is a shorthand property for: 
    [<CustomOperation("font")>]
    member inline _.font([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font: ").Append(value).Append("; "))

    /// A prioritized list of font family names and/or generic family names
    [<CustomOperation("fontFamily")>]
    member inline _.fontFamily([<InlineIfLambda>] comb: CombineKeyValue, familyName: string, genericFamily: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-family: ").Append(familyName).Append(genericFamily).Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("fontFamilyInherit")>]
    member inline _.fontFamilyInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-family: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("fontFamilyInitial")>]
    member inline _.fontFamilyInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-family: ").Append("initial").Append("; "))

    /// Default. Use the default settings to lay out text
    [<CustomOperation("fontFeatureSettingsNormal")>]
    member inline _.fontFeatureSettingsNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-feature-settings: ").Append(defaultArg value " normal").Append("; "))

    /// Format: string [1|0|on|off] Always a string of 4 ASCII characters.
    [<CustomOperation("fontFeatureSettingsFeatureValue")>]
    member inline _.fontFeatureSettingsFeatureValue([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-feature-settings: ").Append(defaultArg value "feature-value").Append("; "))

    /// Default. The browser determines whether font kerning should be applied or not
    [<CustomOperation("fontKerningAuto")>]
    member inline _.fontKerningAuto([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-kerning: ").Append(defaultArg value " auto").Append("; "))

    /// Specifies that font kerning is not applied
    [<CustomOperation("fontKerningNone")>]
    member inline _.fontKerningNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-kerning: ").Append(defaultArg value " none").Append("; "))

    /// Specifies that font kerning is applied
    [<CustomOperation("fontKerningNormal")>]
    member inline _.fontKerningNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-kerning: ").Append(defaultArg value " normal").Append("; "))

    /// Sets the font-size to a percent of the parent element's font size
    [<CustomOperation("fontSize")>]
    member inline _.fontSize([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-size: ").Append(string value + "%").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("fontSizeInherit")>]
    member inline _.fontSizeInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-size: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("fontSizeInitial")>]
    member inline _.fontSizeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-size: ").Append("initial").Append("; "))

    /// Sets the font-size to a large size
    [<CustomOperation("fontSizeLarge")>]
    member inline _.fontSizeLarge([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-size: ").Append(defaultArg value "large").Append("; "))

    /// Sets the font-size to a larger size than the parent element
    [<CustomOperation("fontSizeLarger")>]
    member inline _.fontSizeLarger([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-size: ").Append(defaultArg value "larger").Append("; "))

    /// Sets the font-size to a fixed size in px, cm, etc. Read about length units
    [<CustomOperation("fontSizeLength")>]
    member inline _.fontSizeLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-size: ").Append(string value + "px").Append("; "))

    /// Sets the font-size to a medium size. This is default
    [<CustomOperation("fontSizeMedium")>]
    member inline _.fontSizeMedium([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-size: ").Append(defaultArg value "medium").Append("; "))

    /// Sets the font-size to a small size
    [<CustomOperation("fontSizeSmall")>]
    member inline _.fontSizeSmall([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-size: ").Append(defaultArg value "small").Append("; "))

    /// Sets the font-size to a smaller size than the parent element
    [<CustomOperation("fontSizeSmaller")>]
    member inline _.fontSizeSmaller([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-size: ").Append(defaultArg value "smaller").Append("; "))

    /// Sets the font-size to an extra large size
    [<CustomOperation("fontSizeXLarge")>]
    member inline _.fontSizeXLarge([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-size: ").Append(defaultArg value "x-large").Append("; "))

    /// Sets the font-size to an extra small size
    [<CustomOperation("fontSizeXSmall")>]
    member inline _.fontSizeXSmall([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-size: ").Append(defaultArg value "x-small").Append("; "))

    /// Sets the font-size to an xx-large size
    [<CustomOperation("fontSizeXxLarge")>]
    member inline _.fontSizeXxLarge([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-size: ").Append(defaultArg value "xx-large").Append("; "))

    /// Sets the font-size to an xx-small size
    [<CustomOperation("fontSizeXxSmall")>]
    member inline _.fontSizeXxSmall([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-size: ").Append(defaultArg value "xx-small").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("fontSizeAdjustInherit")>]
    member inline _.fontSizeAdjustInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-size-adjust: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("fontSizeAdjustInitial")>]
    member inline _.fontSizeAdjustInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-size-adjust: ").Append("initial").Append("; "))

    /// Default value. No font size adjustment
    [<CustomOperation("fontSizeAdjustNone")>]
    member inline _.fontSizeAdjustNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-size-adjust: ").Append(defaultArg value "none").Append("; "))

    /// Defines the aspect value to use
    [<CustomOperation("fontSizeAdjustNumber")>]
    member inline _.fontSizeAdjustNumber([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-size-adjust: ").Append(value).Append("; "))

    /// Makes the text narrower than semi-condensed, but not as narrow as extra-condensed
    [<CustomOperation("fontStretchCondensed")>]
    member inline _.fontStretchCondensed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-stretch: ").Append(defaultArg value "condensed").Append("; "))

    /// Makes the text wider than semi-expanded, but not as wide as extra-expanded
    [<CustomOperation("fontStretchExpanded")>]
    member inline _.fontStretchExpanded([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-stretch: ").Append(defaultArg value "expanded").Append("; "))

    /// Makes the text narrower than condensed, but not as narrow as ultra-condensed
    [<CustomOperation("fontStretchExtraCondensed")>]
    member inline _.fontStretchExtraCondensed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-stretch: ").Append(defaultArg value "extra-condensed").Append("; "))

    /// Makes the text wider than expanded, but not as wide as ultra-expanded
    [<CustomOperation("fontStretchExtraExpanded")>]
    member inline _.fontStretchExtraExpanded([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-stretch: ").Append(defaultArg value "extra-expanded").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("fontStretchInherit")>]
    member inline _.fontStretchInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-stretch: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("fontStretchInitial")>]
    member inline _.fontStretchInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-stretch: ").Append("initial").Append("; "))

    /// Default value. No font stretching
    [<CustomOperation("fontStretchNormal")>]
    member inline _.fontStretchNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-stretch: ").Append(defaultArg value "normal").Append("; "))

    /// Makes the text narrower than normal, but not as narrow as condensed
    [<CustomOperation("fontStretchSemiCondensed")>]
    member inline _.fontStretchSemiCondensed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-stretch: ").Append(defaultArg value "semi-condensed").Append("; "))

    /// Makes the text wider than normal, but not as wide as expanded
    [<CustomOperation("fontStretchSemiExpanded")>]
    member inline _.fontStretchSemiExpanded([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-stretch: ").Append(defaultArg value "semi-expanded").Append("; "))

    /// Makes the text as narrow as it gets
    [<CustomOperation("fontStretchUltraCondensed")>]
    member inline _.fontStretchUltraCondensed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-stretch: ").Append(defaultArg value "ultra-condensed").Append("; "))

    /// Makes the text as wide as it gets
    [<CustomOperation("fontStretchUltraExpanded")>]
    member inline _.fontStretchUltraExpanded([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-stretch: ").Append(defaultArg value "ultra-expanded").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("fontStyleInherit")>]
    member inline _.fontStyleInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-style: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("fontStyleInitial")>]
    member inline _.fontStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-style: ").Append("initial").Append("; "))

    /// The browser displays an italic font style
    [<CustomOperation("fontStyleItalic")>]
    member inline _.fontStyleItalic([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-style: ").Append(defaultArg value "italic").Append("; "))

    /// The browser displays a normal font style. This is default
    [<CustomOperation("fontStyleNormal")>]
    member inline _.fontStyleNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-style: ").Append(defaultArg value "normal").Append("; "))

    /// The browser displays an oblique font style
    [<CustomOperation("fontStyleOblique")>]
    member inline _.fontStyleOblique([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-style: ").Append(defaultArg value "oblique").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("fontVariantInherit")>]
    member inline _.fontVariantInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-variant: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("fontVariantInitial")>]
    member inline _.fontVariantInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-variant: ").Append("initial").Append("; "))

    /// The browser displays a normal font. This is default
    [<CustomOperation("fontVariantNormal")>]
    member inline _.fontVariantNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-variant: ").Append(defaultArg value "normal").Append("; "))

    /// The browser displays a small-caps font
    [<CustomOperation("fontVariantSmallCaps")>]
    member inline _.fontVariantSmallCaps([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-variant: ").Append(defaultArg value "small-caps").Append("; "))

    /// Displays petite capitals for both upper and lowercase letters
    [<CustomOperation("fontVariantCapsAllPetiteCaps")>]
    member inline _.fontVariantCapsAllPetiteCaps([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-variant-caps: ").Append(defaultArg value "all-petite-caps").Append("; "))

    /// Displays small capitals for both upper and lowercase letters
    [<CustomOperation("fontVariantCapsAllSmallCaps")>]
    member inline _.fontVariantCapsAllSmallCaps([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-variant-caps: ").Append(defaultArg value "all-small-caps").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("fontVariantCapsInherit")>]
    member inline _.fontVariantCapsInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-variant-caps: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("fontVariantCapsInitial")>]
    member inline _.fontVariantCapsInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-variant-caps: ").Append("initial").Append("; "))

    /// Deactivates the use of alternate glyphs
    [<CustomOperation("fontVariantCapsNormal")>]
    member inline _.fontVariantCapsNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-variant-caps: ").Append(defaultArg value "normal").Append("; "))

    /// Displays petite capitals
    [<CustomOperation("fontVariantCapsPetiteCaps")>]
    member inline _.fontVariantCapsPetiteCaps([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-variant-caps: ").Append(defaultArg value "petite-caps").Append("; "))

    /// Displays small capitals
    [<CustomOperation("fontVariantCapsSmallCaps")>]
    member inline _.fontVariantCapsSmallCaps([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-variant-caps: ").Append(defaultArg value "small-caps").Append("; "))

    /// Displays titling capitals
    [<CustomOperation("fontVariantCapsTitlingCaps")>]
    member inline _.fontVariantCapsTitlingCaps([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-variant-caps: ").Append(defaultArg value "titling-caps").Append("; "))

    /// Displays a mix of small capitals for uppercase letters with normal lowercase letters
    [<CustomOperation("fontVariantCapsUnicase")>]
    member inline _.fontVariantCapsUnicase([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-variant-caps: ").Append(defaultArg value "unicase").Append("; "))

    /// 
    [<CustomOperation("fontVariantCapsUnset")>]
    member inline _.fontVariantCapsUnset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-variant-caps: ").Append(defaultArg value "unset").Append("; "))

    /// Defines from thin to thick characters. 400 is the same as normal, and 700 is the same as bold
    [<CustomOperation("fontWeight100200300400500600700800900")>]
    member inline _.fontWeight100200300400500600700800900([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-weight: ").Append(defaultArg value "100 200 300 400 500 600 700 800 900").Append("; "))

    /// Defines thick characters
    [<CustomOperation("fontWeightBold")>]
    member inline _.fontWeightBold([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-weight: ").Append(defaultArg value "bold").Append("; "))

    /// Defines thicker characters
    [<CustomOperation("fontWeightBolder")>]
    member inline _.fontWeightBolder([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-weight: ").Append(defaultArg value "bolder").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("fontWeightInherit")>]
    member inline _.fontWeightInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-weight: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("fontWeightInitial")>]
    member inline _.fontWeightInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-weight: ").Append("initial").Append("; "))

    /// Defines lighter characters
    [<CustomOperation("fontWeightLighter")>]
    member inline _.fontWeightLighter([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-weight: ").Append(defaultArg value "lighter").Append("; "))

    /// Defines normal characters. This is default
    [<CustomOperation("fontWeightNormal")>]
    member inline _.fontWeightNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font-weight: ").Append(defaultArg value "normal").Append("; "))

    /// The font property is a shorthand property for:
    [<CustomOperation("fontCaption")>]
    member inline _.fontCaption([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font: ").Append(defaultArg value "caption").Append("; "))

    /// The font property is a shorthand property for:
    [<CustomOperation("fontFontFamily")>]
    member inline _.fontFontFamily([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font: ").Append(defaultArg value "font-family").Append("; "))

    /// The font property is a shorthand property for:
    [<CustomOperation("font")>]
    member inline _.font([<InlineIfLambda>] comb: CombineKeyValue, fontSize: string, lineHeight: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font: ").Append(fontSize).Append(lineHeight).Append("; "))

    /// The font property is a shorthand property for:
    [<CustomOperation("fontFontStyle")>]
    member inline _.fontFontStyle([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font: ").Append(defaultArg value "font-style").Append("; "))

    /// The font property is a shorthand property for:
    [<CustomOperation("fontFontVariant")>]
    member inline _.fontFontVariant([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font: ").Append(defaultArg value "font-variant").Append("; "))

    /// The font property is a shorthand property for:
    [<CustomOperation("fontFontWeight")>]
    member inline _.fontFontWeight([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font: ").Append(defaultArg value "font-weight").Append("; "))

    /// The font property is a shorthand property for:
    [<CustomOperation("fontIcon")>]
    member inline _.fontIcon([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font: ").Append(defaultArg value "icon").Append("; "))

    /// The font property is a shorthand property for:
    [<CustomOperation("fontMenu")>]
    member inline _.fontMenu([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font: ").Append(defaultArg value "menu").Append("; "))

    /// The font property is a shorthand property for:
    [<CustomOperation("fontMessageBox")>]
    member inline _.fontMessageBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font: ").Append(defaultArg value "message-box").Append("; "))

    /// The font property is a shorthand property for:
    [<CustomOperation("fontSmallCaption")>]
    member inline _.fontSmallCaption([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font: ").Append(defaultArg value "small-caption").Append("; "))

    /// The font property is a shorthand property for:
    [<CustomOperation("fontStatusBar")>]
    member inline _.fontStatusBar([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("font: ").Append(defaultArg value "status-bar").Append("; "))

    ///  The gap property defines the size of the gap between the rows and between the columns in flexbox, grid or multi-column layout. It is a shorthand for the following properties: 
    [<CustomOperation("gap")>]
    member inline _.gap([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("gap: ").Append(value).Append("; "))

    /// The gap property defines the size of the gap between the rows and between the columns in flexbox, grid or multi-column layout. It is a shorthand for the following properties:
    [<CustomOperation("gapColumnGap")>]
    member inline _.gapColumnGap([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("gap: ").Append(defaultArg value "column-gap").Append("; "))

    /// The gap property defines the size of the gap between the rows and between the columns in flexbox, grid or multi-column layout. It is a shorthand for the following properties:
    [<CustomOperation("gapInherit")>]
    member inline _.gapInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("gap: ").Append("inherit").Append("; "))

    /// The gap property defines the size of the gap between the rows and between the columns in flexbox, grid or multi-column layout. It is a shorthand for the following properties:
    [<CustomOperation("gapInitial")>]
    member inline _.gapInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("gap: ").Append("initial").Append("; "))

    /// The gap property defines the size of the gap between the rows and between the columns in flexbox, grid or multi-column layout. It is a shorthand for the following properties:
    [<CustomOperation("gapRowGap")>]
    member inline _.gapRowGap([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("gap: ").Append(defaultArg value "row-gap").Append("; "))

    ///  The grid property is a shorthand property for: 
    [<CustomOperation("grid")>]
    member inline _.grid([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid: ").Append(value).Append("; "))

    /// Specifies on which column-line to stop displaying the item, or how many columns to span.
    [<CustomOperation("gridAreaGridColumnEnd")>]
    member inline _.gridAreaGridColumnEnd([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-area: ").Append(defaultArg value "grid-column-end").Append("; "))

    /// Specifies on which column to start displaying the item.
    [<CustomOperation("gridAreaGridColumnStart")>]
    member inline _.gridAreaGridColumnStart([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-area: ").Append(defaultArg value "grid-column-start").Append("; "))

    /// Specifies on which row-line to stop displaying the item, or how many rows to span.
    [<CustomOperation("gridAreaGridRowEnd")>]
    member inline _.gridAreaGridRowEnd([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-area: ").Append(defaultArg value "grid-row-end").Append("; "))

    /// Specifies on which row to start displaying the item.
    [<CustomOperation("gridAreaGridRowStart")>]
    member inline _.gridAreaGridRowStart([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-area: ").Append(defaultArg value "grid-row-start").Append("; "))

    /// Specifies a name for the grid item
    [<CustomOperation("gridAreaItemname")>]
    member inline _.gridAreaItemname([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-area: ").Append(defaultArg value "itemname").Append("; "))

    /// Sets the size of the columns, by using a percent value
    [<CustomOperation("gridAutoColumns")>]
    member inline _.gridAutoColumns([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-auto-columns: ").Append(string value + "%").Append("; "))

    /// Default value. The size of the columns is determined by the size of the container
    [<CustomOperation("gridAutoColumnsAuto")>]
    member inline _.gridAutoColumnsAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-auto-columns: ").Append("auto").Append("; "))

    /// 
    [<CustomOperation("gridAutoColumnsFitContent")>]
    member inline _.gridAutoColumnsFitContent([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-auto-columns: ").Append($"fit-content({value})").Append("; "))

    /// Sets the size of the columns, by using a legal length value. Read about length units
    [<CustomOperation("gridAutoColumnsLength")>]
    member inline _.gridAutoColumnsLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-auto-columns: ").Append(string value + "px").Append("; "))

    /// Sets the size of each column depending on the largest item in the column
    [<CustomOperation("gridAutoColumnsMaxContent")>]
    member inline _.gridAutoColumnsMaxContent([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-auto-columns: ").Append(defaultArg value "max-content").Append("; "))

    /// Sets the size of each column depending on the smallest item in the column
    [<CustomOperation("gridAutoColumnsMinContent")>]
    member inline _.gridAutoColumnsMinContent([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-auto-columns: ").Append(defaultArg value "min-content").Append("; "))

    /// Sets a size range greater than or equal to min and less than or equal to max
    [<CustomOperation("gridAutoColumnsMinmax")>]
    member inline _.gridAutoColumnsMinmax([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-auto-columns: ").Append($"minmax({value})").Append("; "))

    /// Places items by filling each column
    [<CustomOperation("gridAutoFlowColumn")>]
    member inline _.gridAutoFlowColumn([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-auto-flow: ").Append(defaultArg value "column").Append("; "))

    /// Places items by filling each column, and fill any holes in the grid
    [<CustomOperation("gridAutoFlowColumnDense")>]
    member inline _.gridAutoFlowColumnDense([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-auto-flow: ").Append(defaultArg value "column dense").Append("; "))

    /// Place items to fill any holes in the grid
    [<CustomOperation("gridAutoFlowDense")>]
    member inline _.gridAutoFlowDense([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-auto-flow: ").Append(defaultArg value "dense").Append("; "))

    /// Default value. Places items by filling each row
    [<CustomOperation("gridAutoFlowRow")>]
    member inline _.gridAutoFlowRow([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-auto-flow: ").Append(defaultArg value "row").Append("; "))

    /// Places items by filling each row, and fill any holes in the grid
    [<CustomOperation("gridAutoFlowRowDense")>]
    member inline _.gridAutoFlowRowDense([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-auto-flow: ").Append(defaultArg value "row dense").Append("; "))

    /// Default value. The size of the rows is determined by the size of the largest item in the row
    [<CustomOperation("gridAutoRowsAuto")>]
    member inline _.gridAutoRowsAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-auto-rows: ").Append("auto").Append("; "))

    /// Sets the size of the rows, by using a legal length value. Read about length units
    [<CustomOperation("gridAutoRowsLength")>]
    member inline _.gridAutoRowsLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-auto-rows: ").Append(string value + "px").Append("; "))

    /// Sets the size of each row to depend on the largest item in the row
    [<CustomOperation("gridAutoRowsMaxContent")>]
    member inline _.gridAutoRowsMaxContent([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-auto-rows: ").Append(defaultArg value "max-content").Append("; "))

    /// Sets the size of each row to depend on the smallest item in the row
    [<CustomOperation("gridAutoRowsMinContent")>]
    member inline _.gridAutoRowsMinContent([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-auto-rows: ").Append(defaultArg value "min-content").Append("; "))

    /// Specifies on which column-line to stop displaying the item, or how many columns to span.
    [<CustomOperation("gridColumnGridColumnEnd")>]
    member inline _.gridColumnGridColumnEnd([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-column: ").Append(defaultArg value "grid-column-end").Append("; "))

    /// Specifies on which column to start displaying the item.
    [<CustomOperation("gridColumnGridColumnStart")>]
    member inline _.gridColumnGridColumnStart([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-column: ").Append(defaultArg value "grid-column-start").Append("; "))

    /// Specifies the number of columns the item will span
    [<CustomOperation("gridColumnEndSpanN")>]
    member inline _.gridColumnEndSpanN([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-column-end: ").Append(defaultArg value " span n").Append("; "))

    /// Default value. The item will span one column
    [<CustomOperation("gridColumnEndAuto")>]
    member inline _.gridColumnEndAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-column-end: ").Append("auto").Append("; "))

    /// Specifies on which column to end the display of the item
    [<CustomOperation("gridColumnEndColumnLine")>]
    member inline _.gridColumnEndColumnLine([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-column-end: ").Append(defaultArg value "column-line").Append("; "))

    /// Any legal length value, like px or %. 0 is the default value. Read about length units
    [<CustomOperation("gridColumnGapLength")>]
    member inline _.gridColumnGapLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-column-gap: ").Append(string value + "px").Append("; "))

    /// Specifies the number of columns the item will span
    [<CustomOperation("gridColumnStartSpanN")>]
    member inline _.gridColumnStartSpanN([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-column-start: ").Append(defaultArg value " span n").Append("; "))

    /// Default value. The item will be placed following the flow
    [<CustomOperation("gridColumnStartAuto")>]
    member inline _.gridColumnStartAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-column-start: ").Append("auto").Append("; "))

    /// Specifies on which column to start the display of the item
    [<CustomOperation("gridColumnStartColumnLine")>]
    member inline _.gridColumnStartColumnLine([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-column-start: ").Append(defaultArg value "column-line").Append("; "))

    /// Sets the size of the gap between the columns in a grid layout. 0 is the default value
    [<CustomOperation("gridGapGridColumnGap")>]
    member inline _.gridGapGridColumnGap([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-gap: ").Append(defaultArg value "grid-column-gap").Append("; "))

    /// Sets the size of the gap between the rows in a grid layout. 0 is the default value
    [<CustomOperation("gridGapGridRowGap")>]
    member inline _.gridGapGridRowGap([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-gap: ").Append(defaultArg value "grid-row-gap").Append("; "))

    /// Specifies on which row-line to stop displaying the item, or how many rows to span.
    [<CustomOperation("gridRowGridRowEnd")>]
    member inline _.gridRowGridRowEnd([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-row: ").Append(defaultArg value "grid-row-end").Append("; "))

    /// Specifies on which row to start displaying the item.
    [<CustomOperation("gridRowGridRowStart")>]
    member inline _.gridRowGridRowStart([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-row: ").Append(defaultArg value "grid-row-start").Append("; "))

    /// Specifies the number of rows the item will span.
    [<CustomOperation("gridRowEndSpanN")>]
    member inline _.gridRowEndSpanN([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-row-end: ").Append(defaultArg value " span n").Append("; "))

    /// Default value. The item will span one row.
    [<CustomOperation("gridRowEndAuto")>]
    member inline _.gridRowEndAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-row-end: ").Append("auto").Append("; "))

    /// Specifies on which row to end the display of the item.
    [<CustomOperation("gridRowEndRowLine")>]
    member inline _.gridRowEndRowLine([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-row-end: ").Append(defaultArg value "row-line").Append("; "))

    /// Any legal length value, like px or %. 0 is the default value
    [<CustomOperation("gridRowGapLength")>]
    member inline _.gridRowGapLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-row-gap: ").Append(string value + "px").Append("; "))

    /// Default value. The item will be placed by following the flow.
    [<CustomOperation("gridRowStartAuto")>]
    member inline _.gridRowStartAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-row-start: ").Append("auto").Append("; "))

    /// Specifies on which row to start the display of the item.
    [<CustomOperation("gridRowStartRowLine")>]
    member inline _.gridRowStartRowLine([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-row-start: ").Append(defaultArg value "row-line").Append("; "))

    /// Specifies the size(s) of the columns and rows
    [<CustomOperation("gridTemplate")>]
    member inline _.gridTemplate([<InlineIfLambda>] comb: CombineKeyValue, gridTemplateRows: string, gridTemplateColumns: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-template: ").Append(gridTemplateRows).Append(gridTemplateColumns).Append("; "))

    /// Specifies the grid layout using named items
    [<CustomOperation("gridTemplateGridTemplateAreas")>]
    member inline _.gridTemplateGridTemplateAreas([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-template: ").Append(defaultArg value "grid-template-areas").Append("; "))

    /// Inherits this property from its parent element. Read about inherit
    [<CustomOperation("gridTemplateInherit")>]
    member inline _.gridTemplateInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-template: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("gridTemplateInitial")>]
    member inline _.gridTemplateInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-template: ").Append("initial").Append("; "))

    /// Default value. No specific sizing of the columns or rows
    [<CustomOperation("gridTemplateNone")>]
    member inline _.gridTemplateNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-template: ").Append(defaultArg value "none").Append("; "))

    /// A sequence that specifies how each columns and row should display
    [<CustomOperation("gridTemplateAreasItemnames")>]
    member inline _.gridTemplateAreasItemnames([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-template-areas: ").Append(defaultArg value "itemnames").Append("; "))

    /// Default value. No named grid areas
    [<CustomOperation("gridTemplateAreasNone")>]
    member inline _.gridTemplateAreasNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-template-areas: ").Append(defaultArg value "none").Append("; "))

    /// The size of the columns is determined by the size of the container and on the size of the content of the items in the column
    [<CustomOperation("gridTemplateColumnsAuto")>]
    member inline _.gridTemplateColumnsAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-template-columns: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("gridTemplateColumnsInherit")>]
    member inline _.gridTemplateColumnsInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-template-columns: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("gridTemplateColumnsInitial")>]
    member inline _.gridTemplateColumnsInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-template-columns: ").Append("initial").Append("; "))

    /// Sets the size of the columns, by using a legal length value. Read about length units
    [<CustomOperation("gridTemplateColumnsLength")>]
    member inline _.gridTemplateColumnsLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-template-columns: ").Append(string value + "px").Append("; "))

    /// Sets the size of each column to depend on the largest item in the column
    [<CustomOperation("gridTemplateColumnsMaxContent")>]
    member inline _.gridTemplateColumnsMaxContent([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-template-columns: ").Append(defaultArg value "max-content").Append("; "))

    /// Sets the size of each column to depend on the smallest item in the column
    [<CustomOperation("gridTemplateColumnsMinContent")>]
    member inline _.gridTemplateColumnsMinContent([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-template-columns: ").Append(defaultArg value "min-content").Append("; "))

    /// Default value. Columns are created if needed
    [<CustomOperation("gridTemplateColumnsNone")>]
    member inline _.gridTemplateColumnsNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-template-columns: ").Append(defaultArg value "none").Append("; "))

    /// The size of the rows is determined by the size of the container, and on the size of the content of the items in the row
    [<CustomOperation("gridTemplateRowsAuto")>]
    member inline _.gridTemplateRowsAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-template-rows: ").Append("auto").Append("; "))

    /// Sets the size of the rows, by using a legal length value. Read about length units
    [<CustomOperation("gridTemplateRowsLength")>]
    member inline _.gridTemplateRowsLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-template-rows: ").Append(string value + "px").Append("; "))

    /// Sets the size of each row to depend on the largest item in the row
    [<CustomOperation("gridTemplateRowsMaxContent")>]
    member inline _.gridTemplateRowsMaxContent([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-template-rows: ").Append(defaultArg value "max-content").Append("; "))

    /// Sets the size of each row to depend on the smallest item in the row
    [<CustomOperation("gridTemplateRowsMinContent")>]
    member inline _.gridTemplateRowsMinContent([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-template-rows: ").Append(defaultArg value "min-content").Append("; "))

    /// No size is set. Rows are created if needed
    [<CustomOperation("gridTemplateRowsNone")>]
    member inline _.gridTemplateRowsNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid-template-rows: ").Append(defaultArg value "none").Append("; "))

    /// The grid property is a shorthand property for:
    [<CustomOperation("grid")>]
    member inline _.grid([<InlineIfLambda>] comb: CombineKeyValue, gridAutoFlowGridAutoRows: string, gridTemplateColumns: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid: ").Append(gridAutoFlowGridAutoRows).Append(gridTemplateColumns).Append("; "))

    /// The grid property is a shorthand property for:
    [<CustomOperation("grid")>]
    member inline _.grid([<InlineIfLambda>] comb: CombineKeyValue, gridAutoRows: string, gridTemplateColumns: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid: ").Append(gridAutoRows).Append(gridTemplateColumns).Append("; "))

    /// The grid property is a shorthand property for:
    [<CustomOperation("grid")>]
    member inline _.grid([<InlineIfLambda>] comb: CombineKeyValue, gridTemplateRows: string, gridAutoColumns: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid: ").Append(gridTemplateRows).Append(gridAutoColumns).Append("; "))

    /// The grid property is a shorthand property for:
    [<CustomOperation("grid")>]
    member inline _.grid([<InlineIfLambda>] comb: CombineKeyValue, gridTemplateRows: string, gridAutoFlowGridAutoColumns: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid: ").Append(gridTemplateRows).Append(gridAutoFlowGridAutoColumns).Append("; "))

    /// The grid property is a shorthand property for:
    [<CustomOperation("grid")>]
    member inline _.grid([<InlineIfLambda>] comb: CombineKeyValue, gridTemplateRows: string, gridTemplateColumns: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid: ").Append(gridTemplateRows).Append(gridTemplateColumns).Append("; "))

    ///  The hanging-punctuation property specifies whether a punctuation mark may be placed outside the line box at the start or at the end of a full line of text. 
    [<CustomOperation("hangingPunctuation")>]
    member inline _.hangingPunctuation([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("hanging-punctuation: ").Append(value).Append("; "))

    /// The hanging-punctuation property specifies whether a punctuation mark may be placed outside the line box at the start or at the end of a full line of text.
    [<CustomOperation("hangingPunctuationAllowEnd")>]
    member inline _.hangingPunctuationAllowEnd([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("hanging-punctuation: ").Append(defaultArg value "allow-end").Append("; "))

    /// The hanging-punctuation property specifies whether a punctuation mark may be placed outside the line box at the start or at the end of a full line of text.
    [<CustomOperation("hangingPunctuationFirst")>]
    member inline _.hangingPunctuationFirst([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("hanging-punctuation: ").Append(defaultArg value "first").Append("; "))

    /// The hanging-punctuation property specifies whether a punctuation mark may be placed outside the line box at the start or at the end of a full line of text.
    [<CustomOperation("hangingPunctuationForceEnd")>]
    member inline _.hangingPunctuationForceEnd([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("hanging-punctuation: ").Append(defaultArg value "force-end").Append("; "))

    /// The hanging-punctuation property specifies whether a punctuation mark may be placed outside the line box at the start or at the end of a full line of text.
    [<CustomOperation("hangingPunctuationInherit")>]
    member inline _.hangingPunctuationInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("hanging-punctuation: ").Append("inherit").Append("; "))

    /// The hanging-punctuation property specifies whether a punctuation mark may be placed outside the line box at the start or at the end of a full line of text.
    [<CustomOperation("hangingPunctuationInitial")>]
    member inline _.hangingPunctuationInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("hanging-punctuation: ").Append("initial").Append("; "))

    /// The hanging-punctuation property specifies whether a punctuation mark may be placed outside the line box at the start or at the end of a full line of text.
    [<CustomOperation("hangingPunctuationLast")>]
    member inline _.hangingPunctuationLast([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("hanging-punctuation: ").Append(defaultArg value "last").Append("; "))

    /// The hanging-punctuation property specifies whether a punctuation mark may be placed outside the line box at the start or at the end of a full line of text.
    [<CustomOperation("hangingPunctuationNone")>]
    member inline _.hangingPunctuationNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("hanging-punctuation: ").Append(defaultArg value "none").Append("; "))

    ///  The height property sets the height of an element. 
    [<CustomOperation("height")>]
    member inline _.height([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("height: ").Append(value).Append("; "))

    /// The height property sets the height of an element.
    [<CustomOperation("height")>]
    member inline _.height([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("height: ").Append(string value + "%").Append("; "))

    /// The height property sets the height of an element.
    [<CustomOperation("heightAuto")>]
    member inline _.heightAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("height: ").Append("auto").Append("; "))

    /// The height property sets the height of an element.
    [<CustomOperation("heightInherit")>]
    member inline _.heightInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("height: ").Append("inherit").Append("; "))

    /// The height property sets the height of an element.
    [<CustomOperation("heightInitial")>]
    member inline _.heightInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("height: ").Append("initial").Append("; "))

    /// The height property sets the height of an element.
    [<CustomOperation("heightLength")>]
    member inline _.heightLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("height: ").Append(string value + "px").Append("; "))

    ///  The hyphenate-character property defines the character used at the end of line, before a hyphenation break. 
    [<CustomOperation("hyphenateCharacter")>]
    member inline _.hyphenateCharacter([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("hyphenate-character: ").Append(value).Append("; "))

    /// The hyphenate-character property defines the character used at the end of line, before a hyphenation break.
    [<CustomOperation("hyphenateCharacterAuto")>]
    member inline _.hyphenateCharacterAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("hyphenate-character: ").Append("auto").Append("; "))

    /// The hyphenate-character property defines the character used at the end of line, before a hyphenation break.
    [<CustomOperation("hyphenateCharacterInherit")>]
    member inline _.hyphenateCharacterInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("hyphenate-character: ").Append("inherit").Append("; "))

    /// The hyphenate-character property defines the character used at the end of line, before a hyphenation break.
    [<CustomOperation("hyphenateCharacterInitial")>]
    member inline _.hyphenateCharacterInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("hyphenate-character: ").Append("initial").Append("; "))

    /// The hyphenate-character property defines the character used at the end of line, before a hyphenation break.
    [<CustomOperation("hyphenateCharacterString")>]
    member inline _.hyphenateCharacterString([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("hyphenate-character: ").Append(defaultArg value "string").Append("; "))

    ///  The hyphens property defines whether hyphenation is allowed to create more soft wrap opportunities within a line of text. 
    [<CustomOperation("hyphens")>]
    member inline _.hyphens([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("hyphens: ").Append(value).Append("; "))

    /// The hyphens property defines whether hyphenation is allowed to create more soft wrap opportunities within a line of text.
    [<CustomOperation("hyphensAuto")>]
    member inline _.hyphensAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("hyphens: ").Append("auto").Append("; "))

    /// The hyphens property defines whether hyphenation is allowed to create more soft wrap opportunities within a line of text.
    [<CustomOperation("hyphensInherit")>]
    member inline _.hyphensInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("hyphens: ").Append("inherit").Append("; "))

    /// The hyphens property defines whether hyphenation is allowed to create more soft wrap opportunities within a line of text.
    [<CustomOperation("hyphensInitial")>]
    member inline _.hyphensInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("hyphens: ").Append("initial").Append("; "))

    /// The hyphens property defines whether hyphenation is allowed to create more soft wrap opportunities within a line of text.
    [<CustomOperation("hyphensManual")>]
    member inline _.hyphensManual([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("hyphens: ").Append(defaultArg value "manual").Append("; "))

    /// The hyphens property defines whether hyphenation is allowed to create more soft wrap opportunities within a line of text.
    [<CustomOperation("hyphensNone")>]
    member inline _.hyphensNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("hyphens: ").Append(defaultArg value "none").Append("; "))

    ///  The image-rendering property specifies the type of algorithm to be used for image scaling. 
    [<CustomOperation("imageRendering")>]
    member inline _.imageRendering([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("image-rendering: ").Append(value).Append("; "))

    /// The image-rendering property specifies the type of algorithm to be used for image scaling.
    [<CustomOperation("imageRenderingAuto")>]
    member inline _.imageRenderingAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("image-rendering: ").Append("auto").Append("; "))

    /// The image-rendering property specifies the type of algorithm to be used for image scaling.
    [<CustomOperation("imageRenderingCrispEdges")>]
    member inline _.imageRenderingCrispEdges([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("image-rendering: ").Append(defaultArg value "crisp-edges").Append("; "))

    /// The image-rendering property specifies the type of algorithm to be used for image scaling.
    [<CustomOperation("imageRenderingHighQuality")>]
    member inline _.imageRenderingHighQuality([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("image-rendering: ").Append(defaultArg value "high-quality").Append("; "))

    /// The image-rendering property specifies the type of algorithm to be used for image scaling.
    [<CustomOperation("imageRenderingInherit")>]
    member inline _.imageRenderingInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("image-rendering: ").Append("inherit").Append("; "))

    /// The image-rendering property specifies the type of algorithm to be used for image scaling.
    [<CustomOperation("imageRenderingInitial")>]
    member inline _.imageRenderingInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("image-rendering: ").Append("initial").Append("; "))

    /// The image-rendering property specifies the type of algorithm to be used for image scaling.
    [<CustomOperation("imageRenderingPixelated")>]
    member inline _.imageRenderingPixelated([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("image-rendering: ").Append(defaultArg value "pixelated").Append("; "))

    /// The image-rendering property specifies the type of algorithm to be used for image scaling.
    [<CustomOperation("imageRenderingSmooth")>]
    member inline _.imageRenderingSmooth([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("image-rendering: ").Append(defaultArg value "smooth").Append("; "))

    ///  The inline-size property specifies the size of an element in the inline direction. 
    [<CustomOperation("inlineSize")>]
    member inline _.inlineSize([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("inline-size: ").Append(value).Append("; "))

    /// The inline-size property specifies the size of an element in the inline direction.
    [<CustomOperation("inlineSize")>]
    member inline _.inlineSize([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("inline-size: ").Append(string value + "%").Append("; "))

    /// The inline-size property specifies the size of an element in the inline direction.
    [<CustomOperation("inlineSizeAuto")>]
    member inline _.inlineSizeAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inline-size: ").Append("auto").Append("; "))

    /// The inline-size property specifies the size of an element in the inline direction.
    [<CustomOperation("inlineSizeInherit")>]
    member inline _.inlineSizeInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inline-size: ").Append("inherit").Append("; "))

    /// The inline-size property specifies the size of an element in the inline direction.
    [<CustomOperation("inlineSizeInitial")>]
    member inline _.inlineSizeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inline-size: ").Append("initial").Append("; "))

    /// The inline-size property specifies the size of an element in the inline direction.
    [<CustomOperation("inlineSizeLength")>]
    member inline _.inlineSizeLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("inline-size: ").Append(string value + "px").Append("; "))

    ///  The inset property sets the distance between an element and the parent element. 
    [<CustomOperation("inset")>]
    member inline _.inset([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset: ").Append(value).Append("; "))

    /// Specifies distance in percent relative to size of parent element on the corresponding axis.
    [<CustomOperation("insetBlock")>]
    member inline _.insetBlock([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-block: ").Append(string value + "%").Append("; "))

    /// Default. The element's default inset-block value.
    [<CustomOperation("insetBlockAuto")>]
    member inline _.insetBlockAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-block: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("insetBlockInherit")>]
    member inline _.insetBlockInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-block: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("insetBlockInitial")>]
    member inline _.insetBlockInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-block: ").Append("initial").Append("; "))

    /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
    [<CustomOperation("insetBlockLength")>]
    member inline _.insetBlockLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-block: ").Append(string value + "px").Append("; "))

    /// Specifies distance in percent relative to size of parent element on the corresponding axis.
    [<CustomOperation("insetBlockEnd")>]
    member inline _.insetBlockEnd([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-block-end: ").Append(string value + "%").Append("; "))

    /// Default. The element's default inset distance.
    [<CustomOperation("insetBlockEndAuto")>]
    member inline _.insetBlockEndAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-block-end: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("insetBlockEndInherit")>]
    member inline _.insetBlockEndInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-block-end: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("insetBlockEndInitial")>]
    member inline _.insetBlockEndInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-block-end: ").Append("initial").Append("; "))

    /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
    [<CustomOperation("insetBlockEndLength")>]
    member inline _.insetBlockEndLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-block-end: ").Append(string value + "px").Append("; "))

    /// Specifies distance in percent relative to size of parent element on the corresponding axis.
    [<CustomOperation("insetBlockStart")>]
    member inline _.insetBlockStart([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-block-start: ").Append(string value + "%").Append("; "))

    /// Default. The element's default inset distance.
    [<CustomOperation("insetBlockStartAuto")>]
    member inline _.insetBlockStartAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-block-start: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("insetBlockStartInherit")>]
    member inline _.insetBlockStartInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-block-start: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("insetBlockStartInitial")>]
    member inline _.insetBlockStartInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-block-start: ").Append("initial").Append("; "))

    /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
    [<CustomOperation("insetBlockStartLength")>]
    member inline _.insetBlockStartLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-block-start: ").Append(string value + "px").Append("; "))

    /// Specifies distance in percent relative to size of parent element on the corresponding axis.
    [<CustomOperation("insetInline")>]
    member inline _.insetInline([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-inline: ").Append(string value + "%").Append("; "))

    /// Default. The element's default inset-inline distance.
    [<CustomOperation("insetInlineAuto")>]
    member inline _.insetInlineAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-inline: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("insetInlineInherit")>]
    member inline _.insetInlineInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-inline: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("insetInlineInitial")>]
    member inline _.insetInlineInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-inline: ").Append("initial").Append("; "))

    /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
    [<CustomOperation("insetInlineLength")>]
    member inline _.insetInlineLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-inline: ").Append(string value + "px").Append("; "))

    /// Specifies distance in percent relative to size of parent element on the corresponding axis.
    [<CustomOperation("insetInlineEnd")>]
    member inline _.insetInlineEnd([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-inline-end: ").Append(string value + "%").Append("; "))

    /// Default. The element's default inset distance.
    [<CustomOperation("insetInlineEndAuto")>]
    member inline _.insetInlineEndAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-inline-end: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("insetInlineEndInherit")>]
    member inline _.insetInlineEndInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-inline-end: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("insetInlineEndInitial")>]
    member inline _.insetInlineEndInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-inline-end: ").Append("initial").Append("; "))

    /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
    [<CustomOperation("insetInlineEndLength")>]
    member inline _.insetInlineEndLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-inline-end: ").Append(string value + "px").Append("; "))

    /// Specifies distance in percent relative to size of parent element on the corresponding axis.
    [<CustomOperation("insetInlineStart")>]
    member inline _.insetInlineStart([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-inline-start: ").Append(string value + "%").Append("; "))

    /// Default. The element's default inset distance.
    [<CustomOperation("insetInlineStartAuto")>]
    member inline _.insetInlineStartAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-inline-start: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("insetInlineStartInherit")>]
    member inline _.insetInlineStartInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-inline-start: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("insetInlineStartInitial")>]
    member inline _.insetInlineStartInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-inline-start: ").Append("initial").Append("; "))

    /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
    [<CustomOperation("insetInlineStartLength")>]
    member inline _.insetInlineStartLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("inset-inline-start: ").Append(string value + "px").Append("; "))

    ///  The isolation property defines whether an element must create a new stacking content. 
    [<CustomOperation("isolation")>]
    member inline _.isolation([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("isolation: ").Append(value).Append("; "))

    /// The isolation property defines whether an element must create a new stacking content.
    [<CustomOperation("isolationAuto")>]
    member inline _.isolationAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("isolation: ").Append("auto").Append("; "))

    /// The isolation property defines whether an element must create a new stacking content.
    [<CustomOperation("isolationInherit")>]
    member inline _.isolationInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("isolation: ").Append("inherit").Append("; "))

    /// The isolation property defines whether an element must create a new stacking content.
    [<CustomOperation("isolationInitial")>]
    member inline _.isolationInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("isolation: ").Append("initial").Append("; "))

    /// The isolation property defines whether an element must create a new stacking content.
    [<CustomOperation("isolationIsolate")>]
    member inline _.isolationIsolate([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("isolation: ").Append(defaultArg value "isolate").Append("; "))

    ///  The justify-content property aligns the flexible container's items when the items do not use all available space on the main-axis (horizontally). 
    [<CustomOperation("justifyContent")>]
    member inline _.justifyContent([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-content: ").Append(value).Append("; "))

    /// The justify-content property aligns the flexible container's items when the items do not use all available space on the main-axis (horizontally).
    [<CustomOperation("justifyContentCenter")>]
    member inline _.justifyContentCenter([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-content: ").Append(defaultArg value "center").Append("; "))

    /// The justify-content property aligns the flexible container's items when the items do not use all available space on the main-axis (horizontally).
    [<CustomOperation("justifyContentFlexEnd")>]
    member inline _.justifyContentFlexEnd([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-content: ").Append(defaultArg value "flex-end").Append("; "))

    /// The justify-content property aligns the flexible container's items when the items do not use all available space on the main-axis (horizontally).
    [<CustomOperation("justifyContentFlexStart")>]
    member inline _.justifyContentFlexStart([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-content: ").Append(defaultArg value "flex-start").Append("; "))

    /// The justify-content property aligns the flexible container's items when the items do not use all available space on the main-axis (horizontally).
    [<CustomOperation("justifyContentInherit")>]
    member inline _.justifyContentInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-content: ").Append("inherit").Append("; "))

    /// The justify-content property aligns the flexible container's items when the items do not use all available space on the main-axis (horizontally).
    [<CustomOperation("justifyContentInitial")>]
    member inline _.justifyContentInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-content: ").Append("initial").Append("; "))

    /// The justify-content property aligns the flexible container's items when the items do not use all available space on the main-axis (horizontally).
    [<CustomOperation("justifyContentSpaceAround")>]
    member inline _.justifyContentSpaceAround([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-content: ").Append(defaultArg value "space-around").Append("; "))

    /// The justify-content property aligns the flexible container's items when the items do not use all available space on the main-axis (horizontally).
    [<CustomOperation("justifyContentSpaceBetween")>]
    member inline _.justifyContentSpaceBetween([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-content: ").Append(defaultArg value "space-between").Append("; "))

    /// The justify-content property aligns the flexible container's items when the items do not use all available space on the main-axis (horizontally).
    [<CustomOperation("justifyContentSpaceEvenly")>]
    member inline _.justifyContentSpaceEvenly([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-content: ").Append(defaultArg value "space-evenly").Append("; "))

    ///  The justify-items property is set on the grid container to give child elements (grid items) alignment in the inline direction. 
    [<CustomOperation("justifyItems")>]
    member inline _.justifyItems([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append(value).Append("; "))

    /// The justify-items property is set on the grid container to give child elements (grid items) alignment in the inline direction.
    [<CustomOperation("justifyItemsBaselineAlignment")>]
    member inline _.justifyItemsBaselineAlignment([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append(defaultArg value "baseline alignment").Append("; "))

    /// The justify-items property is set on the grid container to give child elements (grid items) alignment in the inline direction.
    [<CustomOperation("justifyItemsCenter")>]
    member inline _.justifyItemsCenter([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append(defaultArg value "center").Append("; "))

    /// The justify-items property is set on the grid container to give child elements (grid items) alignment in the inline direction.
    [<CustomOperation("justifyItemsEnd")>]
    member inline _.justifyItemsEnd([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append(defaultArg value "end").Append("; "))

    /// The justify-items property is set on the grid container to give child elements (grid items) alignment in the inline direction.
    [<CustomOperation("justifyItemsInherit")>]
    member inline _.justifyItemsInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append("inherit").Append("; "))

    /// The justify-items property is set on the grid container to give child elements (grid items) alignment in the inline direction.
    [<CustomOperation("justifyItemsInitial")>]
    member inline _.justifyItemsInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append("initial").Append("; "))

    /// The justify-items property is set on the grid container to give child elements (grid items) alignment in the inline direction.
    [<CustomOperation("justifyItemsLeft")>]
    member inline _.justifyItemsLeft([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append(defaultArg value "left").Append("; "))

    /// The justify-items property is set on the grid container to give child elements (grid items) alignment in the inline direction.
    [<CustomOperation("justifyItemsLegacy")>]
    member inline _.justifyItemsLegacy([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append(defaultArg value "legacy").Append("; "))

    /// The justify-items property is set on the grid container to give child elements (grid items) alignment in the inline direction.
    [<CustomOperation("justifyItemsNormal")>]
    member inline _.justifyItemsNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append(defaultArg value "normal").Append("; "))

    /// The justify-items property is set on the grid container to give child elements (grid items) alignment in the inline direction.
    [<CustomOperation("justifyItemsOverflowAlignment")>]
    member inline _.justifyItemsOverflowAlignment([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append(defaultArg value "overflow-alignment").Append("; "))

    /// The justify-items property is set on the grid container to give child elements (grid items) alignment in the inline direction.
    [<CustomOperation("justifyItemsRight")>]
    member inline _.justifyItemsRight([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append(defaultArg value "right").Append("; "))

    /// The justify-items property is set on the grid container to give child elements (grid items) alignment in the inline direction.
    [<CustomOperation("justifyItemsStart")>]
    member inline _.justifyItemsStart([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append(defaultArg value "start").Append("; "))

    /// The justify-items property is set on the grid container to give child elements (grid items) alignment in the inline direction.
    [<CustomOperation("justifyItemsStretch")>]
    member inline _.justifyItemsStretch([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-items: ").Append(defaultArg value "stretch").Append("; "))

    ///  The justify-self property aligns a grid item within its grid cell in the inline direction. 
    [<CustomOperation("justifySelf")>]
    member inline _.justifySelf([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append(value).Append("; "))

    /// The justify-self property aligns a grid item within its grid cell in the inline direction.
    [<CustomOperation("justifySelfAuto")>]
    member inline _.justifySelfAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append("auto").Append("; "))

    /// The justify-self property aligns a grid item within its grid cell in the inline direction.
    [<CustomOperation("justifySelfBaselineAlignment")>]
    member inline _.justifySelfBaselineAlignment([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append(defaultArg value "baseline alignment").Append("; "))

    /// The justify-self property aligns a grid item within its grid cell in the inline direction.
    [<CustomOperation("justifySelfCenter")>]
    member inline _.justifySelfCenter([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append(defaultArg value "center").Append("; "))

    /// The justify-self property aligns a grid item within its grid cell in the inline direction.
    [<CustomOperation("justifySelfEnd")>]
    member inline _.justifySelfEnd([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append(defaultArg value "end").Append("; "))

    /// The justify-self property aligns a grid item within its grid cell in the inline direction.
    [<CustomOperation("justifySelfInherit")>]
    member inline _.justifySelfInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append("inherit").Append("; "))

    /// The justify-self property aligns a grid item within its grid cell in the inline direction.
    [<CustomOperation("justifySelfInitial")>]
    member inline _.justifySelfInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append("initial").Append("; "))

    /// The justify-self property aligns a grid item within its grid cell in the inline direction.
    [<CustomOperation("justifySelfLeft")>]
    member inline _.justifySelfLeft([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append(defaultArg value "left").Append("; "))

    /// The justify-self property aligns a grid item within its grid cell in the inline direction.
    [<CustomOperation("justifySelfNormal")>]
    member inline _.justifySelfNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append(defaultArg value "normal").Append("; "))

    /// The justify-self property aligns a grid item within its grid cell in the inline direction.
    [<CustomOperation("justifySelfOverflowAlignment")>]
    member inline _.justifySelfOverflowAlignment([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append(defaultArg value "overflow-alignment").Append("; "))

    /// The justify-self property aligns a grid item within its grid cell in the inline direction.
    [<CustomOperation("justifySelfRight")>]
    member inline _.justifySelfRight([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append(defaultArg value "right").Append("; "))

    /// The justify-self property aligns a grid item within its grid cell in the inline direction.
    [<CustomOperation("justifySelfStart")>]
    member inline _.justifySelfStart([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append(defaultArg value "start").Append("; "))

    /// The justify-self property aligns a grid item within its grid cell in the inline direction.
    [<CustomOperation("justifySelfStretch")>]
    member inline _.justifySelfStretch([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("justify-self: ").Append(defaultArg value "stretch").Append("; "))

    ///  The left property affects the horizontal position of a positioned element. This property has no effect on non-positioned elements. 
    [<CustomOperation("left")>]
    member inline _.left([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("left: ").Append(value).Append("; "))

    /// The left property affects the horizontal position of a positioned element. This property has no effect on non-positioned elements.
    [<CustomOperation("left")>]
    member inline _.left([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("left: ").Append(string value + "%").Append("; "))

    /// The left property affects the horizontal position of a positioned element. This property has no effect on non-positioned elements.
    [<CustomOperation("leftAuto")>]
    member inline _.leftAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("left: ").Append("auto").Append("; "))

    /// The left property affects the horizontal position of a positioned element. This property has no effect on non-positioned elements.
    [<CustomOperation("leftInherit")>]
    member inline _.leftInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("left: ").Append("inherit").Append("; "))

    /// The left property affects the horizontal position of a positioned element. This property has no effect on non-positioned elements.
    [<CustomOperation("leftInitial")>]
    member inline _.leftInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("left: ").Append("initial").Append("; "))

    /// The left property affects the horizontal position of a positioned element. This property has no effect on non-positioned elements.
    [<CustomOperation("leftLength")>]
    member inline _.leftLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("left: ").Append(string value + "px").Append("; "))

    /// 
    [<CustomOperation("letterSpacing")>]
    member inline _.letterSpacing([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("letter-spacing: ").Append(value).Append("; "))

    ///  The line-height property specifies the height of a line. 
    [<CustomOperation("lineHeight")>]
    member inline _.lineHeight([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("line-height: ").Append(value).Append("; "))

    /// The line-height property specifies the height of a line.
    [<CustomOperation("lineHeight")>]
    member inline _.lineHeight([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("line-height: ").Append(string value + "%").Append("; "))

    /// The line-height property specifies the height of a line.
    [<CustomOperation("lineHeightInherit")>]
    member inline _.lineHeightInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("line-height: ").Append("inherit").Append("; "))

    /// The line-height property specifies the height of a line.
    [<CustomOperation("lineHeightInitial")>]
    member inline _.lineHeightInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("line-height: ").Append("initial").Append("; "))

    /// The line-height property specifies the height of a line.
    [<CustomOperation("lineHeightLength")>]
    member inline _.lineHeightLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("line-height: ").Append(string value + "px").Append("; "))

    /// The line-height property specifies the height of a line.
    [<CustomOperation("lineHeightNormal")>]
    member inline _.lineHeightNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("line-height: ").Append(defaultArg value "normal").Append("; "))

    /// The line-height property specifies the height of a line.
    [<CustomOperation("lineHeightNumber")>]
    member inline _.lineHeightNumber([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("line-height: ").Append(value).Append("; "))

    ///  The list-style property is a shorthand for the following properties: 
    [<CustomOperation("listStyle")>]
    member inline _.listStyle([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style: ").Append(value).Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("listStyleImageInherit")>]
    member inline _.listStyleImageInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-image: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("listStyleImageInitial")>]
    member inline _.listStyleImageInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-image: ").Append("initial").Append("; "))

    /// No image will be displayed. Instead, the list-style-type property will define what type of list marker will be rendered. This is default
    [<CustomOperation("listStyleImageNone")>]
    member inline _.listStyleImageNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-image: ").Append(defaultArg value "none").Append("; "))

    /// The path to the image to be used as a list-item marker
    [<CustomOperation("listStyleImageUrl")>]
    member inline _.listStyleImageUrl([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-image: ").Append(defaultArg value "url").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("listStylePositionInherit")>]
    member inline _.listStylePositionInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-position: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("listStylePositionInitial")>]
    member inline _.listStylePositionInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-position: ").Append("initial").Append("; "))

    /// The bullet points will be inside the list item
    [<CustomOperation("listStylePositionInside")>]
    member inline _.listStylePositionInside([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-position: ").Append(defaultArg value "inside").Append("; "))

    /// The bullet points will be outside the list item. This is default
    [<CustomOperation("listStylePositionOutside")>]
    member inline _.listStylePositionOutside([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-position: ").Append(defaultArg value "outside").Append("; "))

    /// The marker is traditional Armenian numbering
    [<CustomOperation("listStyleTypeArmenian")>]
    member inline _.listStyleTypeArmenian([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "armenian").Append("; "))

    /// The marker is a circle
    [<CustomOperation("listStyleTypeCircle")>]
    member inline _.listStyleTypeCircle([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "circle").Append("; "))

    /// The marker is plain ideographic numbers
    [<CustomOperation("listStyleTypeCjkIdeographic")>]
    member inline _.listStyleTypeCjkIdeographic([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "cjk-ideographic").Append("; "))

    /// The marker is a number
    [<CustomOperation("listStyleTypeDecimal")>]
    member inline _.listStyleTypeDecimal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "decimal").Append("; "))

    /// The marker is a number with leading zeros (01, 02, 03, etc.)
    [<CustomOperation("listStyleTypeDecimalLeadingZero")>]
    member inline _.listStyleTypeDecimalLeadingZero([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "decimal-leading-zero").Append("; "))

    /// Default value. The marker is a filled circle
    [<CustomOperation("listStyleTypeDisc")>]
    member inline _.listStyleTypeDisc([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "disc").Append("; "))

    /// The marker is traditional Georgian numbering
    [<CustomOperation("listStyleTypeGeorgian")>]
    member inline _.listStyleTypeGeorgian([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "georgian").Append("; "))

    /// The marker is traditional Hebrew numbering
    [<CustomOperation("listStyleTypeHebrew")>]
    member inline _.listStyleTypeHebrew([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "hebrew").Append("; "))

    /// The marker is traditional Hiragana numbering
    [<CustomOperation("listStyleTypeHiragana")>]
    member inline _.listStyleTypeHiragana([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "hiragana").Append("; "))

    /// The marker is traditional Hiragana iroha numbering
    [<CustomOperation("listStyleTypeHiraganaIroha")>]
    member inline _.listStyleTypeHiraganaIroha([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "hiragana-iroha").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("listStyleTypeInherit")>]
    member inline _.listStyleTypeInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("listStyleTypeInitial")>]
    member inline _.listStyleTypeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append("initial").Append("; "))

    /// The marker is traditional Katakana numbering
    [<CustomOperation("listStyleTypeKatakana")>]
    member inline _.listStyleTypeKatakana([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "katakana").Append("; "))

    /// The marker is traditional Katakana iroha numbering
    [<CustomOperation("listStyleTypeKatakanaIroha")>]
    member inline _.listStyleTypeKatakanaIroha([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "katakana-iroha").Append("; "))

    /// The marker is lower-alpha (a, b, c, d, e, etc.)
    [<CustomOperation("listStyleTypeLowerAlpha")>]
    member inline _.listStyleTypeLowerAlpha([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "lower-alpha").Append("; "))

    /// The marker is lower-greek
    [<CustomOperation("listStyleTypeLowerGreek")>]
    member inline _.listStyleTypeLowerGreek([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "lower-greek").Append("; "))

    /// The marker is lower-latin (a, b, c, d, e, etc.)
    [<CustomOperation("listStyleTypeLowerLatin")>]
    member inline _.listStyleTypeLowerLatin([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "lower-latin").Append("; "))

    /// The marker is lower-roman (i, ii, iii, iv, v, etc.)
    [<CustomOperation("listStyleTypeLowerRoman")>]
    member inline _.listStyleTypeLowerRoman([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "lower-roman").Append("; "))

    /// No marker is shown
    [<CustomOperation("listStyleTypeNone")>]
    member inline _.listStyleTypeNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "none").Append("; "))

    /// The marker is a square
    [<CustomOperation("listStyleTypeSquare")>]
    member inline _.listStyleTypeSquare([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "square").Append("; "))

    /// The marker is upper-alpha (A, B, C, D, E, etc.)
    [<CustomOperation("listStyleTypeUpperAlpha")>]
    member inline _.listStyleTypeUpperAlpha([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "upper-alpha").Append("; "))

    /// The marker is upper-greek
    [<CustomOperation("listStyleTypeUpperGreek")>]
    member inline _.listStyleTypeUpperGreek([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "upper-greek").Append("; "))

    /// The marker is upper-latin (A, B, C, D, E, etc.)
    [<CustomOperation("listStyleTypeUpperLatin")>]
    member inline _.listStyleTypeUpperLatin([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "upper-latin").Append("; "))

    /// The marker is upper-roman (I, II, III, IV, V, etc.)
    [<CustomOperation("listStyleTypeUpperRoman")>]
    member inline _.listStyleTypeUpperRoman([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style-type: ").Append(defaultArg value "upper-roman").Append("; "))

    /// The list-style property is a shorthand for the following properties:
    [<CustomOperation("listStyleListStyleImage")>]
    member inline _.listStyleListStyleImage([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style: ").Append(defaultArg value "list-style-image").Append("; "))

    /// The list-style property is a shorthand for the following properties:
    [<CustomOperation("listStyleListStylePosition")>]
    member inline _.listStyleListStylePosition([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style: ").Append(defaultArg value "list-style-position").Append("; "))

    /// The list-style property is a shorthand for the following properties:
    [<CustomOperation("listStyleListStyleType")>]
    member inline _.listStyleListStyleType([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("list-style: ").Append(defaultArg value "list-style-type").Append("; "))

    ///  The margin property sets the margins for an element, and is a shorthand property for the following properties: 
    [<CustomOperation("margin")>]
    member inline _.margin([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin: ").Append(value).Append("; "))

    /// Specifies margin-block in percent relative to size of parent element in the inline direction.
    [<CustomOperation("marginBlock")>]
    member inline _.marginBlock([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-block: ").Append(string value + "%").Append("; "))

    /// Default. The element's default margin-block value.
    [<CustomOperation("marginBlockAuto")>]
    member inline _.marginBlockAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-block: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("marginBlockInherit")>]
    member inline _.marginBlockInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-block: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("marginBlockInitial")>]
    member inline _.marginBlockInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-block: ").Append("initial").Append("; "))

    /// Specifies margin-block in px, pt, cm, etc. Negative values are allowed. Read about length units
    [<CustomOperation("marginBlockLength")>]
    member inline _.marginBlockLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-block: ").Append(string value + "px").Append("; "))

    /// Specifies distance in percent relative to size of parent element in the inline direction.
    [<CustomOperation("marginBlockEnd")>]
    member inline _.marginBlockEnd([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-block-end: ").Append(string value + "%").Append("; "))

    /// Default. The element's default margin.
    [<CustomOperation("marginBlockEndAuto")>]
    member inline _.marginBlockEndAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-block-end: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("marginBlockEndInherit")>]
    member inline _.marginBlockEndInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-block-end: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("marginBlockEndInitial")>]
    member inline _.marginBlockEndInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-block-end: ").Append("initial").Append("; "))

    /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
    [<CustomOperation("marginBlockEndLength")>]
    member inline _.marginBlockEndLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-block-end: ").Append(string value + "px").Append("; "))

    /// Specifies distance in percent relative to size of parent element in the inline direction.
    [<CustomOperation("marginBlockStart")>]
    member inline _.marginBlockStart([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-block-start: ").Append(string value + "%").Append("; "))

    /// Default. The element's default margin distance.
    [<CustomOperation("marginBlockStartAuto")>]
    member inline _.marginBlockStartAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-block-start: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("marginBlockStartInherit")>]
    member inline _.marginBlockStartInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-block-start: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("marginBlockStartInitial")>]
    member inline _.marginBlockStartInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-block-start: ").Append("initial").Append("; "))

    /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
    [<CustomOperation("marginBlockStartLength")>]
    member inline _.marginBlockStartLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-block-start: ").Append(string value + "px").Append("; "))

    /// Specifies a bottom margin in percent of the width of the containing element
    [<CustomOperation("marginBottom")>]
    member inline _.marginBottom([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-bottom: ").Append(string value + "%").Append("; "))

    /// The browser calculates a bottom margin
    [<CustomOperation("marginBottomAuto")>]
    member inline _.marginBottomAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-bottom: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("marginBottomInherit")>]
    member inline _.marginBottomInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-bottom: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("marginBottomInitial")>]
    member inline _.marginBottomInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-bottom: ").Append("initial").Append("; "))

    /// Specifies a fixed bottom margin in px, cm, em, etc. Default value is 0. Negative values are allowed. Read about length units
    [<CustomOperation("marginBottomLength")>]
    member inline _.marginBottomLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-bottom: ").Append(string value + "px").Append("; "))

    /// Specifies margin-inline in percent relative to size of parent element in the inline direction.
    [<CustomOperation("marginInline")>]
    member inline _.marginInline([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-inline: ").Append(string value + "%").Append("; "))

    /// Default. The element's default margin-inline value.
    [<CustomOperation("marginInlineAuto")>]
    member inline _.marginInlineAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-inline: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("marginInlineInherit")>]
    member inline _.marginInlineInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-inline: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("marginInlineInitial")>]
    member inline _.marginInlineInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-inline: ").Append("initial").Append("; "))

    /// Specifies margin-inline in px, pt, cm, etc. Negative values are allowed. Read about length units
    [<CustomOperation("marginInlineLength")>]
    member inline _.marginInlineLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-inline: ").Append(string value + "px").Append("; "))

    /// Specifies margin-inline-end in percent relative to size of parent element in the inline direction.
    [<CustomOperation("marginInlineEnd")>]
    member inline _.marginInlineEnd([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-inline-end: ").Append(string value + "%").Append("; "))

    /// Default. The element's default margin-inline-end value.
    [<CustomOperation("marginInlineEndAuto")>]
    member inline _.marginInlineEndAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-inline-end: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("marginInlineEndInherit")>]
    member inline _.marginInlineEndInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-inline-end: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("marginInlineEndInitial")>]
    member inline _.marginInlineEndInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-inline-end: ").Append("initial").Append("; "))

    /// Specifies margin-inline-end in px, pt, cm, etc. Negative values are allowed. Read about length units
    [<CustomOperation("marginInlineEndLength")>]
    member inline _.marginInlineEndLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-inline-end: ").Append(string value + "px").Append("; "))

    /// Specifies margin-inline-start in percent relative to size of parent element in the inline direction.
    [<CustomOperation("marginInlineStart")>]
    member inline _.marginInlineStart([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-inline-start: ").Append(string value + "%").Append("; "))

    /// Default. The element's default margin-inline-start value.
    [<CustomOperation("marginInlineStartAuto")>]
    member inline _.marginInlineStartAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-inline-start: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("marginInlineStartInherit")>]
    member inline _.marginInlineStartInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-inline-start: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("marginInlineStartInitial")>]
    member inline _.marginInlineStartInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-inline-start: ").Append("initial").Append("; "))

    /// Specifies margin-inline-start in px, pt, cm, etc. Negative values are allowed. Read about length units
    [<CustomOperation("marginInlineStartLength")>]
    member inline _.marginInlineStartLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-inline-start: ").Append(string value + "px").Append("; "))

    /// Specifies a left margin in percent of the width of the containing element
    [<CustomOperation("marginLeft")>]
    member inline _.marginLeft([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-left: ").Append(string value + "%").Append("; "))

    /// The browser calculates a left margin
    [<CustomOperation("marginLeftAuto")>]
    member inline _.marginLeftAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-left: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("marginLeftInherit")>]
    member inline _.marginLeftInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-left: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("marginLeftInitial")>]
    member inline _.marginLeftInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-left: ").Append("initial").Append("; "))

    /// Specifies a fixed left margin in px, pt, cm, etc. Default value is 0px. Negative values are allowed. Read about length units
    [<CustomOperation("marginLeftLength")>]
    member inline _.marginLeftLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-left: ").Append(string value + "px").Append("; "))

    /// Specifies a right margin in percent of the width of the containing element
    [<CustomOperation("marginRight")>]
    member inline _.marginRight([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-right: ").Append(string value + "%").Append("; "))

    /// The browser calculates a right margin
    [<CustomOperation("marginRightAuto")>]
    member inline _.marginRightAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-right: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("marginRightInherit")>]
    member inline _.marginRightInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-right: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("marginRightInitial")>]
    member inline _.marginRightInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-right: ").Append("initial").Append("; "))

    /// Specifies a fixed right margin in px, pt, cm, etc. Default value is 0px. Read about length units
    [<CustomOperation("marginRightLength")>]
    member inline _.marginRightLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-right: ").Append(string value + "px").Append("; "))

    /// Specifies a top margin in percent of the width of the containing element
    [<CustomOperation("marginTop")>]
    member inline _.marginTop([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-top: ").Append(string value + "%").Append("; "))

    /// The browser calculates a top margin
    [<CustomOperation("marginTopAuto")>]
    member inline _.marginTopAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-top: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("marginTopInherit")>]
    member inline _.marginTopInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-top: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("marginTopInitial")>]
    member inline _.marginTopInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-top: ").Append("initial").Append("; "))

    /// Specifies a fixed top margin in px, pt, cm, etc. Default value is 0px. Negative values are allowed. Read about length units
    [<CustomOperation("marginTopLength")>]
    member inline _.marginTopLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin-top: ").Append(string value + "px").Append("; "))

    ///  The mask-image property specifies an image to be used as a mask layer for an element. 
    [<CustomOperation("maskImage")>]
    member inline _.maskImage([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-image: ").Append(value).Append("; "))

    /// The mask-image property specifies an image to be used as a mask layer for an element.
    [<CustomOperation("maskImageImage")>]
    member inline _.maskImageImage([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-image: ").Append(defaultArg value "image").Append("; "))

    /// The mask-image property specifies an image to be used as a mask layer for an element.
    [<CustomOperation("maskImageInherit")>]
    member inline _.maskImageInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-image: ").Append("inherit").Append("; "))

    /// The mask-image property specifies an image to be used as a mask layer for an element.
    [<CustomOperation("maskImageInitial")>]
    member inline _.maskImageInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-image: ").Append("initial").Append("; "))

    /// The mask-image property specifies an image to be used as a mask layer for an element.
    [<CustomOperation("maskImageNone")>]
    member inline _.maskImageNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-image: ").Append(defaultArg value "none").Append("; "))

    /// The mask-image property specifies an image to be used as a mask layer for an element.
    [<CustomOperation("maskImageUrl")>]
    member inline _.maskImageUrl([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-image: ").Append(defaultArg value "url").Append("; "))

    ///  The mask-mode property specifies whether the mask layer image should be treated as a luminance mask or as an alpha mask. 
    [<CustomOperation("maskMode")>]
    member inline _.maskMode([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-mode: ").Append(value).Append("; "))

    /// The mask-mode property specifies whether the mask layer image should be treated as a luminance mask or as an alpha mask.
    [<CustomOperation("maskModeAlpha")>]
    member inline _.maskModeAlpha([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-mode: ").Append(defaultArg value "alpha").Append("; "))

    /// The mask-mode property specifies whether the mask layer image should be treated as a luminance mask or as an alpha mask.
    [<CustomOperation("maskModeInherit")>]
    member inline _.maskModeInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-mode: ").Append("inherit").Append("; "))

    /// The mask-mode property specifies whether the mask layer image should be treated as a luminance mask or as an alpha mask.
    [<CustomOperation("maskModeInitial")>]
    member inline _.maskModeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-mode: ").Append("initial").Append("; "))

    /// The mask-mode property specifies whether the mask layer image should be treated as a luminance mask or as an alpha mask.
    [<CustomOperation("maskModeLuminance")>]
    member inline _.maskModeLuminance([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-mode: ").Append(defaultArg value "luminance").Append("; "))

    /// The mask-mode property specifies whether the mask layer image should be treated as a luminance mask or as an alpha mask.
    [<CustomOperation("maskModeMatchSource")>]
    member inline _.maskModeMatchSource([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-mode: ").Append(defaultArg value "match-source").Append("; "))

    ///  The mask-origin property specifies the origin position (the mask position area) of a mask layer image. 
    [<CustomOperation("maskOrigin")>]
    member inline _.maskOrigin([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-origin: ").Append(value).Append("; "))

    /// The mask-origin property specifies the origin position (the mask position area) of a mask layer image.
    [<CustomOperation("maskOriginBorderBox")>]
    member inline _.maskOriginBorderBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-origin: ").Append(defaultArg value "border-box").Append("; "))

    /// The mask-origin property specifies the origin position (the mask position area) of a mask layer image.
    [<CustomOperation("maskOriginContentBox")>]
    member inline _.maskOriginContentBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-origin: ").Append(defaultArg value "content-box").Append("; "))

    /// The mask-origin property specifies the origin position (the mask position area) of a mask layer image.
    [<CustomOperation("maskOriginFillBox")>]
    member inline _.maskOriginFillBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-origin: ").Append(defaultArg value "fill-box").Append("; "))

    /// The mask-origin property specifies the origin position (the mask position area) of a mask layer image.
    [<CustomOperation("maskOriginInherit")>]
    member inline _.maskOriginInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-origin: ").Append("inherit").Append("; "))

    /// The mask-origin property specifies the origin position (the mask position area) of a mask layer image.
    [<CustomOperation("maskOriginInitial")>]
    member inline _.maskOriginInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-origin: ").Append("initial").Append("; "))

    /// The mask-origin property specifies the origin position (the mask position area) of a mask layer image.
    [<CustomOperation("maskOriginMarginBox")>]
    member inline _.maskOriginMarginBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-origin: ").Append(defaultArg value "margin-box").Append("; "))

    /// The mask-origin property specifies the origin position (the mask position area) of a mask layer image.
    [<CustomOperation("maskOriginPaddingBox")>]
    member inline _.maskOriginPaddingBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-origin: ").Append(defaultArg value "padding-box").Append("; "))

    /// The mask-origin property specifies the origin position (the mask position area) of a mask layer image.
    [<CustomOperation("maskOriginStrokeBox")>]
    member inline _.maskOriginStrokeBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-origin: ").Append(defaultArg value "stroke-box").Append("; "))

    /// The mask-origin property specifies the origin position (the mask position area) of a mask layer image.
    [<CustomOperation("maskOriginViewBox")>]
    member inline _.maskOriginViewBox([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-origin: ").Append(defaultArg value "view-box").Append("; "))

    ///  The mask-position property sets the starting position of a mask image (relative to the mask position area). 
    [<CustomOperation("maskPosition")>]
    member inline _.maskPosition([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-position: ").Append(value).Append("; "))

    /// The mask-position property sets the starting position of a mask image (relative to the mask position area).
    [<CustomOperation("maskPositionInherit")>]
    member inline _.maskPositionInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-position: ").Append("inherit").Append("; "))

    /// The mask-position property sets the starting position of a mask image (relative to the mask position area).
    [<CustomOperation("maskPositionInitial")>]
    member inline _.maskPositionInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-position: ").Append("initial").Append("; "))

    /// The mask-position property sets the starting position of a mask image (relative to the mask position area).
    [<CustomOperation("maskPositionLeftTopLeftCenterLeftBottomRightTopRightCenterRightBottomCenterTopCenterCenterCenterBottom")>]
    member inline _.maskPositionLeftTopLeftCenterLeftBottomRightTopRightCenterRightBottomCenterTopCenterCenterCenterBottom([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-position: ").Append(defaultArg value "left top left center left bottom right top right center right bottom center top center center center bottom").Append("; "))

    /// The mask-position property sets the starting position of a mask image (relative to the mask position area).
    [<CustomOperation("maskPositionXY")>]
    member inline _.maskPositionXY([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-position: ").Append(defaultArg value "x% y%").Append("; "))

    /// The mask-position property sets the starting position of a mask image (relative to the mask position area).
    [<CustomOperation("maskPositionXposYpos")>]
    member inline _.maskPositionXposYpos([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-position: ").Append(defaultArg value "xpos ypos").Append("; "))

    ///  The mask-repeat property sets if/how a mask image will be repeated. 
    [<CustomOperation("maskRepeat")>]
    member inline _.maskRepeat([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-repeat: ").Append(value).Append("; "))

    /// The mask-repeat property sets if/how a mask image will be repeated.
    [<CustomOperation("maskRepeatInherit")>]
    member inline _.maskRepeatInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-repeat: ").Append("inherit").Append("; "))

    /// The mask-repeat property sets if/how a mask image will be repeated.
    [<CustomOperation("maskRepeatInitial")>]
    member inline _.maskRepeatInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-repeat: ").Append("initial").Append("; "))

    /// The mask-repeat property sets if/how a mask image will be repeated.
    [<CustomOperation("maskRepeatNoRepeat")>]
    member inline _.maskRepeatNoRepeat([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-repeat: ").Append(defaultArg value "no-repeat").Append("; "))

    /// The mask-repeat property sets if/how a mask image will be repeated.
    [<CustomOperation("maskRepeatRepeat")>]
    member inline _.maskRepeatRepeat([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-repeat: ").Append(defaultArg value "repeat").Append("; "))

    /// The mask-repeat property sets if/how a mask image will be repeated.
    [<CustomOperation("maskRepeatRepeatX")>]
    member inline _.maskRepeatRepeatX([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-repeat: ").Append(defaultArg value "repeat-x").Append("; "))

    /// The mask-repeat property sets if/how a mask image will be repeated.
    [<CustomOperation("maskRepeatRepeatY")>]
    member inline _.maskRepeatRepeatY([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-repeat: ").Append(defaultArg value "repeat-y").Append("; "))

    /// The mask-repeat property sets if/how a mask image will be repeated.
    [<CustomOperation("maskRepeatRound")>]
    member inline _.maskRepeatRound([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-repeat: ").Append(defaultArg value "round").Append("; "))

    /// The mask-repeat property sets if/how a mask image will be repeated.
    [<CustomOperation("maskRepeatSpace")>]
    member inline _.maskRepeatSpace([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-repeat: ").Append(defaultArg value "space").Append("; "))

    ///  The mask-size property specifies the size of the mask layer image. 
    [<CustomOperation("maskSize")>]
    member inline _.maskSize([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-size: ").Append(value).Append("; "))

    /// The mask-size property specifies the size of the mask layer image.
    [<CustomOperation("maskSizeAuto")>]
    member inline _.maskSizeAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-size: ").Append("auto").Append("; "))

    /// The mask-size property specifies the size of the mask layer image.
    [<CustomOperation("maskSizeContain")>]
    member inline _.maskSizeContain([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-size: ").Append(defaultArg value "contain").Append("; "))

    /// The mask-size property specifies the size of the mask layer image.
    [<CustomOperation("maskSizeCover")>]
    member inline _.maskSizeCover([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-size: ").Append(defaultArg value "cover").Append("; "))

    /// The mask-size property specifies the size of the mask layer image.
    [<CustomOperation("maskSizeInherit")>]
    member inline _.maskSizeInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-size: ").Append("inherit").Append("; "))

    /// The mask-size property specifies the size of the mask layer image.
    [<CustomOperation("maskSizeInitial")>]
    member inline _.maskSizeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-size: ").Append("initial").Append("; "))

    /// The mask-size property specifies the size of the mask layer image.
    [<CustomOperation("maskSizeSize")>]
    member inline _.maskSizeSize([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mask-size: ").Append(defaultArg value "size").Append("; "))

    ///  The max-block-size property specifies the maximum size of an element in the block direction. 
    [<CustomOperation("maxBlockSize")>]
    member inline _.maxBlockSize([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-block-size: ").Append(value).Append("; "))

    /// The max-block-size property specifies the maximum size of an element in the block direction.
    [<CustomOperation("maxBlockSize")>]
    member inline _.maxBlockSize([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-block-size: ").Append(string value + "%").Append("; "))

    /// The max-block-size property specifies the maximum size of an element in the block direction.
    [<CustomOperation("maxBlockSizeAuto")>]
    member inline _.maxBlockSizeAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-block-size: ").Append("auto").Append("; "))

    /// The max-block-size property specifies the maximum size of an element in the block direction.
    [<CustomOperation("maxBlockSizeInherit")>]
    member inline _.maxBlockSizeInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-block-size: ").Append("inherit").Append("; "))

    /// The max-block-size property specifies the maximum size of an element in the block direction.
    [<CustomOperation("maxBlockSizeInitial")>]
    member inline _.maxBlockSizeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-block-size: ").Append("initial").Append("; "))

    /// The max-block-size property specifies the maximum size of an element in the block direction.
    [<CustomOperation("maxBlockSizeLength")>]
    member inline _.maxBlockSizeLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-block-size: ").Append(string value + "px").Append("; "))

    ///  The max-height property defines the maximum height of an element. 
    [<CustomOperation("maxHeight")>]
    member inline _.maxHeight([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-height: ").Append(value).Append("; "))

    /// The max-height property defines the maximum height of an element.
    [<CustomOperation("maxHeight")>]
    member inline _.maxHeight([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-height: ").Append(string value + "%").Append("; "))

    /// The max-height property defines the maximum height of an element.
    [<CustomOperation("maxHeightInherit")>]
    member inline _.maxHeightInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-height: ").Append("inherit").Append("; "))

    /// The max-height property defines the maximum height of an element.
    [<CustomOperation("maxHeightInitial")>]
    member inline _.maxHeightInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-height: ").Append("initial").Append("; "))

    /// The max-height property defines the maximum height of an element.
    [<CustomOperation("maxHeightLength")>]
    member inline _.maxHeightLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-height: ").Append(string value + "px").Append("; "))

    /// The max-height property defines the maximum height of an element.
    [<CustomOperation("maxHeightNone")>]
    member inline _.maxHeightNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-height: ").Append(defaultArg value "none").Append("; "))

    ///  The max-inline-size property specifies the maximum size of an element in the inline direction. 
    [<CustomOperation("maxInlineSize")>]
    member inline _.maxInlineSize([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-inline-size: ").Append(value).Append("; "))

    /// The max-inline-size property specifies the maximum size of an element in the inline direction.
    [<CustomOperation("maxInlineSize")>]
    member inline _.maxInlineSize([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-inline-size: ").Append(string value + "%").Append("; "))

    /// The max-inline-size property specifies the maximum size of an element in the inline direction.
    [<CustomOperation("maxInlineSizeAuto")>]
    member inline _.maxInlineSizeAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-inline-size: ").Append("auto").Append("; "))

    /// The max-inline-size property specifies the maximum size of an element in the inline direction.
    [<CustomOperation("maxInlineSizeInherit")>]
    member inline _.maxInlineSizeInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-inline-size: ").Append("inherit").Append("; "))

    /// The max-inline-size property specifies the maximum size of an element in the inline direction.
    [<CustomOperation("maxInlineSizeInitial")>]
    member inline _.maxInlineSizeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-inline-size: ").Append("initial").Append("; "))

    /// The max-inline-size property specifies the maximum size of an element in the inline direction.
    [<CustomOperation("maxInlineSizeLength")>]
    member inline _.maxInlineSizeLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-inline-size: ").Append(string value + "px").Append("; "))

    ///  The max-width property defines the maximum width of an element. 
    [<CustomOperation("maxWidth")>]
    member inline _.maxWidth([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-width: ").Append(value).Append("; "))

    /// The max-width property defines the maximum width of an element.
    [<CustomOperation("maxWidth")>]
    member inline _.maxWidth([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-width: ").Append(string value + "%").Append("; "))

    /// The max-width property defines the maximum width of an element.
    [<CustomOperation("maxWidthInherit")>]
    member inline _.maxWidthInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-width: ").Append("inherit").Append("; "))

    /// The max-width property defines the maximum width of an element.
    [<CustomOperation("maxWidthInitial")>]
    member inline _.maxWidthInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-width: ").Append("initial").Append("; "))

    /// The max-width property defines the maximum width of an element.
    [<CustomOperation("maxWidthLength")>]
    member inline _.maxWidthLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-width: ").Append(string value + "px").Append("; "))

    /// The max-width property defines the maximum width of an element.
    [<CustomOperation("maxWidthNone")>]
    member inline _.maxWidthNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-width: ").Append(defaultArg value "none").Append("; "))

    ///  The min-block-size property specifies the minimum size of an element in the block direction. 
    [<CustomOperation("minBlockSize")>]
    member inline _.minBlockSize([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-block-size: ").Append(value).Append("; "))

    /// The min-block-size property specifies the minimum size of an element in the block direction.
    [<CustomOperation("minBlockSize")>]
    member inline _.minBlockSize([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-block-size: ").Append(string value + "%").Append("; "))

    /// The min-block-size property specifies the minimum size of an element in the block direction.
    [<CustomOperation("minBlockSizeAuto")>]
    member inline _.minBlockSizeAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-block-size: ").Append("auto").Append("; "))

    /// The min-block-size property specifies the minimum size of an element in the block direction.
    [<CustomOperation("minBlockSizeInherit")>]
    member inline _.minBlockSizeInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-block-size: ").Append("inherit").Append("; "))

    /// The min-block-size property specifies the minimum size of an element in the block direction.
    [<CustomOperation("minBlockSizeInitial")>]
    member inline _.minBlockSizeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-block-size: ").Append("initial").Append("; "))

    /// The min-block-size property specifies the minimum size of an element in the block direction.
    [<CustomOperation("minBlockSizeLength")>]
    member inline _.minBlockSizeLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-block-size: ").Append(string value + "px").Append("; "))

    ///  The min-height property defines the minimum height of an element. 
    [<CustomOperation("minHeight")>]
    member inline _.minHeight([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-height: ").Append(value).Append("; "))

    /// The min-height property defines the minimum height of an element.
    [<CustomOperation("minHeight")>]
    member inline _.minHeight([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-height: ").Append(string value + "%").Append("; "))

    /// The min-height property defines the minimum height of an element.
    [<CustomOperation("minHeightInherit")>]
    member inline _.minHeightInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-height: ").Append("inherit").Append("; "))

    /// The min-height property defines the minimum height of an element.
    [<CustomOperation("minHeightInitial")>]
    member inline _.minHeightInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-height: ").Append("initial").Append("; "))

    /// The min-height property defines the minimum height of an element.
    [<CustomOperation("minHeightLength")>]
    member inline _.minHeightLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-height: ").Append(string value + "px").Append("; "))

    ///  The min-inline-size property specifies the minimum size of an element in the inline direction. 
    [<CustomOperation("minInlineSize")>]
    member inline _.minInlineSize([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-inline-size: ").Append(value).Append("; "))

    /// The min-inline-size property specifies the minimum size of an element in the inline direction.
    [<CustomOperation("minInlineSize")>]
    member inline _.minInlineSize([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-inline-size: ").Append(string value + "%").Append("; "))

    /// The min-inline-size property specifies the minimum size of an element in the inline direction.
    [<CustomOperation("minInlineSizeAuto")>]
    member inline _.minInlineSizeAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-inline-size: ").Append("auto").Append("; "))

    /// The min-inline-size property specifies the minimum size of an element in the inline direction.
    [<CustomOperation("minInlineSizeInherit")>]
    member inline _.minInlineSizeInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-inline-size: ").Append("inherit").Append("; "))

    /// The min-inline-size property specifies the minimum size of an element in the inline direction.
    [<CustomOperation("minInlineSizeInitial")>]
    member inline _.minInlineSizeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-inline-size: ").Append("initial").Append("; "))

    /// The min-inline-size property specifies the minimum size of an element in the inline direction.
    [<CustomOperation("minInlineSizeLength")>]
    member inline _.minInlineSizeLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-inline-size: ").Append(string value + "px").Append("; "))

    ///  The min-width property defines the minimum width of an element. 
    [<CustomOperation("minWidth")>]
    member inline _.minWidth([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-width: ").Append(value).Append("; "))

    /// The min-width property defines the minimum width of an element.
    [<CustomOperation("minWidth")>]
    member inline _.minWidth([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-width: ").Append(string value + "%").Append("; "))

    /// The min-width property defines the minimum width of an element.
    [<CustomOperation("minWidthInherit")>]
    member inline _.minWidthInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-width: ").Append("inherit").Append("; "))

    /// The min-width property defines the minimum width of an element.
    [<CustomOperation("minWidthInitial")>]
    member inline _.minWidthInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-width: ").Append("initial").Append("; "))

    /// The min-width property defines the minimum width of an element.
    [<CustomOperation("minWidthLength")>]
    member inline _.minWidthLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-width: ").Append(string value + "px").Append("; "))

    ///  The mix-blend-mode property specifies how an element's content should blend with its direct parent background. 
    [<CustomOperation("mixBlendMode")>]
    member inline _.mixBlendMode([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append(value).Append("; "))

    /// The mix-blend-mode property specifies how an element's content should blend with its direct parent background.
    [<CustomOperation("mixBlendModeColor")>]
    member inline _.mixBlendModeColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append(defaultArg value "color").Append("; "))

    /// The mix-blend-mode property specifies how an element's content should blend with its direct parent background.
    [<CustomOperation("mixBlendModeColorBurn")>]
    member inline _.mixBlendModeColorBurn([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append(defaultArg value "color-burn").Append("; "))

    /// The mix-blend-mode property specifies how an element's content should blend with its direct parent background.
    [<CustomOperation("mixBlendModeColorDodge")>]
    member inline _.mixBlendModeColorDodge([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append(defaultArg value "color-dodge").Append("; "))

    /// The mix-blend-mode property specifies how an element's content should blend with its direct parent background.
    [<CustomOperation("mixBlendModeDarken")>]
    member inline _.mixBlendModeDarken([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append(defaultArg value "darken").Append("; "))

    /// The mix-blend-mode property specifies how an element's content should blend with its direct parent background.
    [<CustomOperation("mixBlendModeDifference")>]
    member inline _.mixBlendModeDifference([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append(defaultArg value "difference").Append("; "))

    /// The mix-blend-mode property specifies how an element's content should blend with its direct parent background.
    [<CustomOperation("mixBlendModeExclusion")>]
    member inline _.mixBlendModeExclusion([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append(defaultArg value "exclusion").Append("; "))

    /// The mix-blend-mode property specifies how an element's content should blend with its direct parent background.
    [<CustomOperation("mixBlendModeHue")>]
    member inline _.mixBlendModeHue([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append(defaultArg value "hue").Append("; "))

    /// The mix-blend-mode property specifies how an element's content should blend with its direct parent background.
    [<CustomOperation("mixBlendModeLighten")>]
    member inline _.mixBlendModeLighten([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append(defaultArg value "lighten").Append("; "))

    /// The mix-blend-mode property specifies how an element's content should blend with its direct parent background.
    [<CustomOperation("mixBlendModeLuminosity")>]
    member inline _.mixBlendModeLuminosity([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append(defaultArg value "luminosity").Append("; "))

    /// The mix-blend-mode property specifies how an element's content should blend with its direct parent background.
    [<CustomOperation("mixBlendModeMultiply")>]
    member inline _.mixBlendModeMultiply([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append(defaultArg value "multiply").Append("; "))

    /// The mix-blend-mode property specifies how an element's content should blend with its direct parent background.
    [<CustomOperation("mixBlendModeNormal")>]
    member inline _.mixBlendModeNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append(defaultArg value "normal").Append("; "))

    /// The mix-blend-mode property specifies how an element's content should blend with its direct parent background.
    [<CustomOperation("mixBlendModeOverlay")>]
    member inline _.mixBlendModeOverlay([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append(defaultArg value "overlay").Append("; "))

    /// The mix-blend-mode property specifies how an element's content should blend with its direct parent background.
    [<CustomOperation("mixBlendModeSaturation")>]
    member inline _.mixBlendModeSaturation([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append(defaultArg value "saturation").Append("; "))

    /// The mix-blend-mode property specifies how an element's content should blend with its direct parent background.
    [<CustomOperation("mixBlendModeScreen")>]
    member inline _.mixBlendModeScreen([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("mix-blend-mode: ").Append(defaultArg value "screen").Append("; "))

    ///  The object-fit property is used to specify how an  or  should be resized to fit its container. 
    [<CustomOperation("objectFit")>]
    member inline _.objectFit([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("object-fit: ").Append(value).Append("; "))

    /// The object-fit property is used to specify how an  or  should be resized to fit its container.
    [<CustomOperation("objectFitContain")>]
    member inline _.objectFitContain([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("object-fit: ").Append(defaultArg value "contain").Append("; "))

    /// The object-fit property is used to specify how an  or  should be resized to fit its container.
    [<CustomOperation("objectFitCover")>]
    member inline _.objectFitCover([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("object-fit: ").Append(defaultArg value "cover").Append("; "))

    /// The object-fit property is used to specify how an  or  should be resized to fit its container.
    [<CustomOperation("objectFitFill")>]
    member inline _.objectFitFill([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("object-fit: ").Append(defaultArg value "fill").Append("; "))

    /// The object-fit property is used to specify how an  or  should be resized to fit its container.
    [<CustomOperation("objectFitInherit")>]
    member inline _.objectFitInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("object-fit: ").Append("inherit").Append("; "))

    /// The object-fit property is used to specify how an  or  should be resized to fit its container.
    [<CustomOperation("objectFitInitial")>]
    member inline _.objectFitInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("object-fit: ").Append("initial").Append("; "))

    /// The object-fit property is used to specify how an  or  should be resized to fit its container.
    [<CustomOperation("objectFitNone")>]
    member inline _.objectFitNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("object-fit: ").Append(defaultArg value "none").Append("; "))

    /// The object-fit property is used to specify how an  or  should be resized to fit its container.
    [<CustomOperation("objectFitScaleDown")>]
    member inline _.objectFitScaleDown([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("object-fit: ").Append(defaultArg value "scale-down").Append("; "))

    ///  The object-position property is used together with object-fit to specify how an  or  should be positioned with x/y coordinates inside its "own content box". 
    [<CustomOperation("objectPosition")>]
    member inline _.objectPosition([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("object-position: ").Append(value).Append("; "))

    /// The object-position property is used together with object-fit to specify how an  or  should be positioned with x/y coordinates inside its "own content box".
    [<CustomOperation("objectPositionInherit")>]
    member inline _.objectPositionInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("object-position: ").Append("inherit").Append("; "))

    /// The object-position property is used together with object-fit to specify how an  or  should be positioned with x/y coordinates inside its "own content box".
    [<CustomOperation("objectPositionInitial")>]
    member inline _.objectPositionInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("object-position: ").Append("initial").Append("; "))

    /// The object-position property is used together with object-fit to specify how an  or  should be positioned with x/y coordinates inside its "own content box".
    [<CustomOperation("objectPositionPosition")>]
    member inline _.objectPositionPosition([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("object-position: ").Append(defaultArg value "position").Append("; "))

    ///  The offset property is used when animating an element along a path, and is a shorthand property for the following properties: 
    [<CustomOperation("offset")>]
    member inline _.offset([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset: ").Append(value).Append("; "))

    /// Default. The achored point will be in the center of the element, same as property value '50% 50%'.
    [<CustomOperation("offsetAnchorAuto")>]
    member inline _.offsetAnchorAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-anchor: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("offsetAnchorInherit")>]
    member inline _.offsetAnchorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-anchor: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("offsetAnchorInitial")>]
    member inline _.offsetAnchorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-anchor: ").Append("initial").Append("; "))

    /// If you only specify one keyword, the other value will be "center"
    [<CustomOperation("offsetAnchorLeftTopLeftCenterLeftBottomRightTopRightCenterRightBottomCenterTopCenterCenterCenterBottom")>]
    member inline _.offsetAnchorLeftTopLeftCenterLeftBottomRightTopRightCenterRightBottomCenterTopCenterCenterCenterBottom([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-anchor: ").Append(defaultArg value "left top left center left bottom right top right center right bottom center top center center center bottom").Append("; "))

    /// The first value is the horizontal position and the second value is the vertical. The top left corner is 0% 0%. The right bottom corner is 100% 100%. If you only specify one value, the other value will be 50%. Default value is: 50% 50%
    [<CustomOperation("offsetAnchorXY")>]
    member inline _.offsetAnchorXY([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-anchor: ").Append(defaultArg value "x% y%").Append("; "))

    /// The first value is the horizontal position and the second value is the vertical. The top left corner is 0 0. Units can be pixels (0px 0px) or any other CSS units. If you only specify one value, the other value will be 50%. You can mix % and positions
    [<CustomOperation("offsetAnchorXposYpos")>]
    member inline _.offsetAnchorXposYpos([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-anchor: ").Append(defaultArg value "xpos ypos").Append("; "))

    /// Specifies the distance in percent relative to the lenth of the path.
    [<CustomOperation("offsetDistance")>]
    member inline _.offsetDistance([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-distance: ").Append(string value + "%").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("offsetDistanceInherit")>]
    member inline _.offsetDistanceInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-distance: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("offsetDistanceInitial")>]
    member inline _.offsetDistanceInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-distance: ").Append("initial").Append("; "))

    /// Specifies the elements distance from the start of its path in px, pt, cm, etc. Negative values are not allowed. Read about length units
    [<CustomOperation("offsetDistanceLength")>]
    member inline _.offsetDistanceLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-distance: ").Append(string value + "px").Append("; "))

    /// Currently not supported. Specify a path by defining a basic shape using CSS functions like inset(), circle(), ellipse() or polygon().
    [<CustomOperation("offsetPath")>]
    member inline _.offsetPath([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-path: ").Append(defaultArg value "").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("offsetPathInherit")>]
    member inline _.offsetPathInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-path: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("offsetPathInitial")>]
    member inline _.offsetPathInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-path: ").Append("initial").Append("; "))

    /// Default. The element's default offset-path property value.
    [<CustomOperation("offsetPathNone")>]
    member inline _.offsetPathNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-path: ").Append(defaultArg value "none").Append("; "))

    /// Specify a path in SVG syntax. Learn about SVG paths
    [<CustomOperation("offsetPathPath")>]
    member inline _.offsetPathPath([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-path: ").Append($"path({value})").Append("; "))

    /// Currently not supported. Specify a path with the CSS ray() function.
    [<CustomOperation("offsetPathRay")>]
    member inline _.offsetPathRay([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-path: ").Append($"ray({value})").Append("; "))

    /// Currently not supported. Specify a path by using the URL to an SVG file.
    [<CustomOperation("offsetPathUrl")>]
    member inline _.offsetPathUrl([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-path: ").Append($"url({value})").Append("; "))

    /// Specifies how much to rotate an element with an constant angle.
    [<CustomOperation("offsetRotate")>]
    member inline _.offsetRotate([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-rotate: ").Append(defaultArg value "").Append("; "))

    /// The element is facing the direction it moving along a path. This is default.
    [<CustomOperation("offsetRotateAuto")>]
    member inline _.offsetRotateAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-rotate: ").Append("auto").Append("; "))

    /// With both auto and  given, the angle is added to the default rotation, in the clockwise direction.
    [<CustomOperation("offsetRotateAuto")>]
    member inline _.offsetRotateAuto([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-rotate: ").Append(defaultArg value "auto ").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("offsetRotateInherit")>]
    member inline _.offsetRotateInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-rotate: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("offsetRotateInitial")>]
    member inline _.offsetRotateInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-rotate: ").Append("initial").Append("; "))

    /// The element is rotated in the opposite direction of the default rotation.
    [<CustomOperation("offsetRotateReverse")>]
    member inline _.offsetRotateReverse([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("offset-rotate: ").Append(defaultArg value "reverse").Append("; "))

    ///  The opacity property sets the opacity level for an element. 
    [<CustomOperation("opacity")>]
    member inline _.opacity([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("opacity: ").Append(value).Append("; "))

    /// The opacity property sets the opacity level for an element.
    [<CustomOperation("opacityInherit")>]
    member inline _.opacityInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("opacity: ").Append("inherit").Append("; "))

    /// The opacity property sets the opacity level for an element.
    [<CustomOperation("opacityInitial")>]
    member inline _.opacityInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("opacity: ").Append("initial").Append("; "))

    /// The opacity property sets the opacity level for an element.
    [<CustomOperation("opacityNumber")>]
    member inline _.opacityNumber([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("opacity: ").Append(value).Append("; "))

    ///  The order property specifies the order of a flexible item relative to the rest of the flexible items inside the same container. 
    [<CustomOperation("order")>]
    member inline _.order([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("order: ").Append(value).Append("; "))

    /// The order property specifies the order of a flexible item relative to the rest of the flexible items inside the same container.
    [<CustomOperation("orderInherit")>]
    member inline _.orderInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("order: ").Append("inherit").Append("; "))

    /// The order property specifies the order of a flexible item relative to the rest of the flexible items inside the same container.
    [<CustomOperation("orderInitial")>]
    member inline _.orderInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("order: ").Append("initial").Append("; "))

    /// The order property specifies the order of a flexible item relative to the rest of the flexible items inside the same container.
    [<CustomOperation("orderNumber")>]
    member inline _.orderNumber([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("order: ").Append(value).Append("; "))

    ///  The orphans property specifies the minimum number of lines that must be left at the bottom of a page or column. 
    [<CustomOperation("orphans")>]
    member inline _.orphans([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("orphans: ").Append(value).Append("; "))

    /// The orphans property specifies the minimum number of lines that must be left at the bottom of a page or column.
    [<CustomOperation("orphansInherit")>]
    member inline _.orphansInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("orphans: ").Append("inherit").Append("; "))

    /// The orphans property specifies the minimum number of lines that must be left at the bottom of a page or column.
    [<CustomOperation("orphansInitial")>]
    member inline _.orphansInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("orphans: ").Append("initial").Append("; "))

    /// The orphans property specifies the minimum number of lines that must be left at the bottom of a page or column.
    [<CustomOperation("orphansInteger")>]
    member inline _.orphansInteger([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("orphans: ").Append(defaultArg value "integer").Append("; "))

    /// 
    [<CustomOperation("outline")>]
    member inline _.outline([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline: ").Append(value).Append("; "))

    /// Specifies the color of the outline. Look at CSS Color Values for a complete list of possible color values.
    [<CustomOperation("outlineColorColor")>]
    member inline _.outlineColorColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-color: ").Append(defaultArg value "color").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("outlineColorInherit")>]
    member inline _.outlineColorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-color: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("outlineColorInitial")>]
    member inline _.outlineColorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-color: ").Append("initial").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("outlineOffsetInherit")>]
    member inline _.outlineOffsetInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-offset: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("outlineOffsetInitial")>]
    member inline _.outlineOffsetInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-offset: ").Append("initial").Append("; "))

    /// The distance the outline is outset from the border edge. Default value is 0
    [<CustomOperation("outlineOffsetLength")>]
    member inline _.outlineOffsetLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-offset: ").Append(string value + "px").Append("; "))

    /// Specifies a dashed outline
    [<CustomOperation("outlineStyleDashed")>]
    member inline _.outlineStyleDashed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append(defaultArg value "dashed").Append("; "))

    /// Specifies a dotted outline
    [<CustomOperation("outlineStyleDotted")>]
    member inline _.outlineStyleDotted([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append(defaultArg value "dotted").Append("; "))

    /// Specifies a double outliner
    [<CustomOperation("outlineStyleDouble")>]
    member inline _.outlineStyleDouble([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append(defaultArg value "double").Append("; "))

    /// Specifies a 3D grooved outline. The effect depends on the outline-color value
    [<CustomOperation("outlineStyleGroove")>]
    member inline _.outlineStyleGroove([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append(defaultArg value "groove").Append("; "))

    /// Specifies a hidden outline
    [<CustomOperation("outlineStyleHidden")>]
    member inline _.outlineStyleHidden([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append(defaultArg value "hidden").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("outlineStyleInherit")>]
    member inline _.outlineStyleInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("outlineStyleInitial")>]
    member inline _.outlineStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append("initial").Append("; "))

    /// Specifies a 3D inset outline. The effect depends on the outline-color value
    [<CustomOperation("outlineStyleInset")>]
    member inline _.outlineStyleInset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append(defaultArg value "inset").Append("; "))

    /// Specifies no outline. This is default
    [<CustomOperation("outlineStyleNone")>]
    member inline _.outlineStyleNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append(defaultArg value "none").Append("; "))

    /// Specifies a 3D outset outline. The effect depends on the outline-color value
    [<CustomOperation("outlineStyleOutset")>]
    member inline _.outlineStyleOutset([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append(defaultArg value "outset").Append("; "))

    /// Specifies a 3D ridged outline. The effect depends on the outline-color value
    [<CustomOperation("outlineStyleRidge")>]
    member inline _.outlineStyleRidge([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append(defaultArg value "ridge").Append("; "))

    /// Specifies a solid outline
    [<CustomOperation("outlineStyleSolid")>]
    member inline _.outlineStyleSolid([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-style: ").Append(defaultArg value "solid").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("outlineWidthInherit")>]
    member inline _.outlineWidthInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-width: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("outlineWidthInitial")>]
    member inline _.outlineWidthInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-width: ").Append("initial").Append("; "))

    /// Allows you to define the thickness of the outline. Read about length units
    [<CustomOperation("outlineWidthLength")>]
    member inline _.outlineWidthLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-width: ").Append(string value + "px").Append("; "))

    /// Specifies a medium outline. This is default
    [<CustomOperation("outlineWidthMedium")>]
    member inline _.outlineWidthMedium([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-width: ").Append(defaultArg value "medium").Append("; "))

    /// Specifies a thick outline
    [<CustomOperation("outlineWidthThick")>]
    member inline _.outlineWidthThick([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-width: ").Append(defaultArg value "thick").Append("; "))

    /// Specifies a thin outline
    [<CustomOperation("outlineWidthThin")>]
    member inline _.outlineWidthThin([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("outline-width: ").Append(defaultArg value "thin").Append("; "))

    ///  The overflow property specifies what should happen if content overflows an element's box. 
    [<CustomOperation("overflow")>]
    member inline _.overflow([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow: ").Append(value).Append("; "))

    /// Default value. Scroll anchoring is enabled
    [<CustomOperation("overflowAnchorAuto")>]
    member inline _.overflowAnchorAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-anchor: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("overflowAnchorInherit")>]
    member inline _.overflowAnchorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-anchor: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("overflowAnchorInitial")>]
    member inline _.overflowAnchorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-anchor: ").Append("initial").Append("; "))

    /// Scroll anchoring is disabled
    [<CustomOperation("overflowAnchorNone")>]
    member inline _.overflowAnchorNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-anchor: ").Append(defaultArg value "none").Append("; "))

    /// Long words will break if they overflow the container
    [<CustomOperation("overflowWrapAnywhere")>]
    member inline _.overflowWrapAnywhere([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-wrap: ").Append(defaultArg value "anywhere").Append("; "))

    /// Long words will break if they overflow the container
    [<CustomOperation("overflowWrapBreakWord")>]
    member inline _.overflowWrapBreakWord([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-wrap: ").Append(defaultArg value "break-word").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("overflowWrapInherit")>]
    member inline _.overflowWrapInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-wrap: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("overflowWrapInitial")>]
    member inline _.overflowWrapInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-wrap: ").Append("initial").Append("; "))

    /// Long words will not break, even if they overflow the container. This is default
    [<CustomOperation("overflowWrapNormal")>]
    member inline _.overflowWrapNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-wrap: ").Append(defaultArg value "normal").Append("; "))

    /// Should cause a scrolling mechanism to be provided for overflowing boxes
    [<CustomOperation("overflowXAuto")>]
    member inline _.overflowXAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-x: ").Append("auto").Append("; "))

    /// The content is clipped - and no scrolling mechanism is provided
    [<CustomOperation("overflowXHidden")>]
    member inline _.overflowXHidden([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-x: ").Append(defaultArg value "hidden").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("overflowXInherit")>]
    member inline _.overflowXInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-x: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("overflowXInitial")>]
    member inline _.overflowXInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-x: ").Append("initial").Append("; "))

    /// The content is clipped and a scrolling mechanism is provided
    [<CustomOperation("overflowXScroll")>]
    member inline _.overflowXScroll([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-x: ").Append(defaultArg value "scroll").Append("; "))

    /// The content is not clipped, and it may be rendered outside the left and right edges. This is default
    [<CustomOperation("overflowXVisible")>]
    member inline _.overflowXVisible([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-x: ").Append(defaultArg value "visible").Append("; "))

    /// Should cause a scrolling mechanism to be provided for overflowing boxes
    [<CustomOperation("overflowYAuto")>]
    member inline _.overflowYAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-y: ").Append("auto").Append("; "))

    /// The content is clipped - and no scrolling mechanism is provided
    [<CustomOperation("overflowYHidden")>]
    member inline _.overflowYHidden([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-y: ").Append(defaultArg value "hidden").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("overflowYInherit")>]
    member inline _.overflowYInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-y: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("overflowYInitial")>]
    member inline _.overflowYInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-y: ").Append("initial").Append("; "))

    /// The content is clipped and a scrolling mechanism is provided
    [<CustomOperation("overflowYScroll")>]
    member inline _.overflowYScroll([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-y: ").Append(defaultArg value "scroll").Append("; "))

    /// The content is not clipped, and it may be rendered outside the content box. This is default
    [<CustomOperation("overflowYVisible")>]
    member inline _.overflowYVisible([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow-y: ").Append(defaultArg value "visible").Append("; "))

    /// The overflow property specifies what should happen if content overflows an element's box.
    [<CustomOperation("overflowClip")>]
    member inline _.overflowClip([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overflow: ").Append(defaultArg value "clip").Append("; "))

    ///  The overscroll-behavior property is used to turn off scroll chaining or overscroll affordance on an element when you try to scroll past the scroll boundary. 
    [<CustomOperation("overscrollBehavior")>]
    member inline _.overscrollBehavior([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior: ").Append(value).Append("; "))

    /// Allows scroll chaining and overscroll affordance behavior. This is default
    [<CustomOperation("overscrollBehaviorBlockAuto")>]
    member inline _.overscrollBehaviorBlockAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior-block: ").Append("auto").Append("; "))

    /// Allows overscroll affordance behavior, but not scroll chaining.
    [<CustomOperation("overscrollBehaviorBlockContain")>]
    member inline _.overscrollBehaviorBlockContain([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior-block: ").Append(defaultArg value "contain").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("overscrollBehaviorBlockInherit")>]
    member inline _.overscrollBehaviorBlockInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior-block: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("overscrollBehaviorBlockInitial")>]
    member inline _.overscrollBehaviorBlockInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior-block: ").Append("initial").Append("; "))

    /// Does not allow overscroll affordance or scroll chaining behavior.
    [<CustomOperation("overscrollBehaviorBlockNone")>]
    member inline _.overscrollBehaviorBlockNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior-block: ").Append(defaultArg value "none").Append("; "))

    /// Allows scroll chaining and overscroll affordance behavior. This is default
    [<CustomOperation("overscrollBehaviorInlineAuto")>]
    member inline _.overscrollBehaviorInlineAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior-inline: ").Append("auto").Append("; "))

    /// Allows overscroll affordance behavior, but not scroll chaining.
    [<CustomOperation("overscrollBehaviorInlineContain")>]
    member inline _.overscrollBehaviorInlineContain([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior-inline: ").Append(defaultArg value "contain").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("overscrollBehaviorInlineInherit")>]
    member inline _.overscrollBehaviorInlineInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior-inline: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("overscrollBehaviorInlineInitial")>]
    member inline _.overscrollBehaviorInlineInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior-inline: ").Append("initial").Append("; "))

    /// Does not allow overscroll affordance or scroll chaining behavior.
    [<CustomOperation("overscrollBehaviorInlineNone")>]
    member inline _.overscrollBehaviorInlineNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior-inline: ").Append(defaultArg value "none").Append("; "))

    /// Allows scroll chaining and overscroll affordance behavior. This is default
    [<CustomOperation("overscrollBehaviorXAuto")>]
    member inline _.overscrollBehaviorXAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior-x: ").Append("auto").Append("; "))

    /// Allows overscroll affordance behavior, but not scroll chaining.
    [<CustomOperation("overscrollBehaviorXContain")>]
    member inline _.overscrollBehaviorXContain([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior-x: ").Append(defaultArg value "contain").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("overscrollBehaviorXInherit")>]
    member inline _.overscrollBehaviorXInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior-x: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("overscrollBehaviorXInitial")>]
    member inline _.overscrollBehaviorXInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior-x: ").Append("initial").Append("; "))

    /// Does not allow overscroll affordance or scroll chaining behavior.
    [<CustomOperation("overscrollBehaviorXNone")>]
    member inline _.overscrollBehaviorXNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior-x: ").Append(defaultArg value "none").Append("; "))

    /// Allows scroll chaining and overscroll affordance behavior. This is default
    [<CustomOperation("overscrollBehaviorYAuto")>]
    member inline _.overscrollBehaviorYAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior-y: ").Append("auto").Append("; "))

    /// Allows overscroll affordance behavior, but not scroll chaining.
    [<CustomOperation("overscrollBehaviorYContain")>]
    member inline _.overscrollBehaviorYContain([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior-y: ").Append(defaultArg value "contain").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("overscrollBehaviorYInherit")>]
    member inline _.overscrollBehaviorYInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior-y: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("overscrollBehaviorYInitial")>]
    member inline _.overscrollBehaviorYInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior-y: ").Append("initial").Append("; "))

    /// Does not allow overscroll affordance or scroll chaining behavior.
    [<CustomOperation("overscrollBehaviorYNone")>]
    member inline _.overscrollBehaviorYNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("overscroll-behavior-y: ").Append(defaultArg value "none").Append("; "))

    /// An element's padding is the space between its content and its border.
    [<CustomOperation("padding")>]
    member inline _.padding([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding: ").Append(value).Append("; "))

    /// Specifies padding-block in percent relative to size of parent element in the inline direction.
    [<CustomOperation("paddingBlock")>]
    member inline _.paddingBlock([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-block: ").Append(string value + "%").Append("; "))

    /// Default. The element's default padding-block value.
    [<CustomOperation("paddingBlockAuto")>]
    member inline _.paddingBlockAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-block: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("paddingBlockInherit")>]
    member inline _.paddingBlockInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-block: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("paddingBlockInitial")>]
    member inline _.paddingBlockInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-block: ").Append("initial").Append("; "))

    /// Specifies padding-block in px, pt, cm, etc. Negative values are not allowed. Read about length units
    [<CustomOperation("paddingBlockLength")>]
    member inline _.paddingBlockLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-block: ").Append(string value + "px").Append("; "))

    /// Specifies padding-block-end in percent relative to size of parent element in the inline direction.
    [<CustomOperation("paddingBlockEnd")>]
    member inline _.paddingBlockEnd([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-block-end: ").Append(string value + "%").Append("; "))

    /// Default. The element's default padding-block-end value.
    [<CustomOperation("paddingBlockEndAuto")>]
    member inline _.paddingBlockEndAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-block-end: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("paddingBlockEndInherit")>]
    member inline _.paddingBlockEndInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-block-end: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("paddingBlockEndInitial")>]
    member inline _.paddingBlockEndInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-block-end: ").Append("initial").Append("; "))

    /// Specifies padding-block-end in px, pt, cm, etc. Negative values are not allowed. Read about length units
    [<CustomOperation("paddingBlockEndLength")>]
    member inline _.paddingBlockEndLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-block-end: ").Append(string value + "px").Append("; "))

    /// Specifies padding-block-start in percent relative to size of parent element in the inline direction.
    [<CustomOperation("paddingBlockStart")>]
    member inline _.paddingBlockStart([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-block-start: ").Append(string value + "%").Append("; "))

    /// Default. The element's default padding-block-start value.
    [<CustomOperation("paddingBlockStartAuto")>]
    member inline _.paddingBlockStartAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-block-start: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("paddingBlockStartInherit")>]
    member inline _.paddingBlockStartInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-block-start: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("paddingBlockStartInitial")>]
    member inline _.paddingBlockStartInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-block-start: ").Append("initial").Append("; "))

    /// Specifies padding-block-start in px, pt, cm, etc. Negative values are not allowed. Read about length units
    [<CustomOperation("paddingBlockStartLength")>]
    member inline _.paddingBlockStartLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-block-start: ").Append(string value + "px").Append("; "))

    /// Specifies a bottom padding in percent of the width of the containing element
    [<CustomOperation("paddingBottom")>]
    member inline _.paddingBottom([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-bottom: ").Append(string value + "%").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("paddingBottomInherit")>]
    member inline _.paddingBottomInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-bottom: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("paddingBottomInitial")>]
    member inline _.paddingBottomInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-bottom: ").Append("initial").Append("; "))

    /// Specifies a fixed bottom padding in px, pt, cm, etc. Default value is 0. Read about length units
    [<CustomOperation("paddingBottomLength")>]
    member inline _.paddingBottomLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-bottom: ").Append(string value + "px").Append("; "))

    /// Specifies distance in percent relative to size of parent element in the inline direction.
    [<CustomOperation("paddingInline")>]
    member inline _.paddingInline([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-inline: ").Append(string value + "%").Append("; "))

    /// Default. The element's default padding-inline distance.
    [<CustomOperation("paddingInlineAuto")>]
    member inline _.paddingInlineAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-inline: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("paddingInlineInherit")>]
    member inline _.paddingInlineInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-inline: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("paddingInlineInitial")>]
    member inline _.paddingInlineInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-inline: ").Append("initial").Append("; "))

    /// Specifies distance in px, pt, cm, etc. Negative values are not allowed. Read about length units
    [<CustomOperation("paddingInlineLength")>]
    member inline _.paddingInlineLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-inline: ").Append(string value + "px").Append("; "))

    /// Specifies distance in percent relative to size of parent element in the inline direction.
    [<CustomOperation("paddingInlineEnd")>]
    member inline _.paddingInlineEnd([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-inline-end: ").Append(string value + "%").Append("; "))

    /// Default. The element's default padding-inline-end distance.
    [<CustomOperation("paddingInlineEndAuto")>]
    member inline _.paddingInlineEndAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-inline-end: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("paddingInlineEndInherit")>]
    member inline _.paddingInlineEndInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-inline-end: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("paddingInlineEndInitial")>]
    member inline _.paddingInlineEndInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-inline-end: ").Append("initial").Append("; "))

    /// Specifies distance in px, pt, cm, etc. Negative values are not allowed. Read about length units
    [<CustomOperation("paddingInlineEndLength")>]
    member inline _.paddingInlineEndLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-inline-end: ").Append(string value + "px").Append("; "))

    /// Specifies distance in percent relative to size of parent element in the inline direction.
    [<CustomOperation("paddingInlineStart")>]
    member inline _.paddingInlineStart([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-inline-start: ").Append(string value + "%").Append("; "))

    /// Default. The element's default padding-inline-start distance.
    [<CustomOperation("paddingInlineStartAuto")>]
    member inline _.paddingInlineStartAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-inline-start: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("paddingInlineStartInherit")>]
    member inline _.paddingInlineStartInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-inline-start: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("paddingInlineStartInitial")>]
    member inline _.paddingInlineStartInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-inline-start: ").Append("initial").Append("; "))

    /// Specifies distance in px, pt, cm, etc. Negative values are not allowed. Read about length units
    [<CustomOperation("paddingInlineStartLength")>]
    member inline _.paddingInlineStartLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-inline-start: ").Append(string value + "px").Append("; "))

    /// Specifies a left padding in percent of the width of the containing element
    [<CustomOperation("paddingLeft")>]
    member inline _.paddingLeft([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-left: ").Append(string value + "%").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("paddingLeftInherit")>]
    member inline _.paddingLeftInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-left: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("paddingLeftInitial")>]
    member inline _.paddingLeftInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-left: ").Append("initial").Append("; "))

    /// Specifies a fixed left padding in px, pt, cm, etc. Default value is 0. Read about length units
    [<CustomOperation("paddingLeftLength")>]
    member inline _.paddingLeftLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-left: ").Append(string value + "px").Append("; "))

    /// Specifies a right padding in percent of the width of the containing element
    [<CustomOperation("paddingRight")>]
    member inline _.paddingRight([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-right: ").Append(string value + "%").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("paddingRightInherit")>]
    member inline _.paddingRightInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-right: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("paddingRightInitial")>]
    member inline _.paddingRightInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-right: ").Append("initial").Append("; "))

    /// Specifies a fixed right padding in px, pt, cm, etc. Default value is 0. Read about length units
    [<CustomOperation("paddingRightLength")>]
    member inline _.paddingRightLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-right: ").Append(string value + "px").Append("; "))

    /// Specifies a top padding in percent of the width of the containing element
    [<CustomOperation("paddingTop")>]
    member inline _.paddingTop([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-top: ").Append(string value + "%").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("paddingTopInherit")>]
    member inline _.paddingTopInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-top: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("paddingTopInitial")>]
    member inline _.paddingTopInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-top: ").Append("initial").Append("; "))

    /// Specifies a fixed top padding in px, pt, cm, etc. Default value is 0. Read about length units
    [<CustomOperation("paddingTopLength")>]
    member inline _.paddingTopLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding-top: ").Append(string value + "px").Append("; "))

    ///  The page-break-after property adds a page-break after a specified element. 
    [<CustomOperation("pageBreakAfter")>]
    member inline _.pageBreakAfter([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("page-break-after: ").Append(value).Append("; "))

    /// The page-break-after property adds a page-break after a specified element.
    [<CustomOperation("pageBreakAfterAlways")>]
    member inline _.pageBreakAfterAlways([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("page-break-after: ").Append(defaultArg value "always").Append("; "))

    /// The page-break-after property adds a page-break after a specified element.
    [<CustomOperation("pageBreakAfterAuto")>]
    member inline _.pageBreakAfterAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("page-break-after: ").Append("auto").Append("; "))

    /// The page-break-after property adds a page-break after a specified element.
    [<CustomOperation("pageBreakAfterAvoid")>]
    member inline _.pageBreakAfterAvoid([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("page-break-after: ").Append(defaultArg value "avoid").Append("; "))

    /// The page-break-after property adds a page-break after a specified element.
    [<CustomOperation("pageBreakAfterInherit")>]
    member inline _.pageBreakAfterInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("page-break-after: ").Append("inherit").Append("; "))

    /// The page-break-after property adds a page-break after a specified element.
    [<CustomOperation("pageBreakAfterInitial")>]
    member inline _.pageBreakAfterInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("page-break-after: ").Append("initial").Append("; "))

    /// The page-break-after property adds a page-break after a specified element.
    [<CustomOperation("pageBreakAfterLeft")>]
    member inline _.pageBreakAfterLeft([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("page-break-after: ").Append(defaultArg value "left").Append("; "))

    /// The page-break-after property adds a page-break after a specified element.
    [<CustomOperation("pageBreakAfterRight")>]
    member inline _.pageBreakAfterRight([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("page-break-after: ").Append(defaultArg value "right").Append("; "))

    ///  The page-break-before property adds a page-break before a specified element.. 
    [<CustomOperation("pageBreakBefore")>]
    member inline _.pageBreakBefore([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("page-break-before: ").Append(value).Append("; "))

    /// The page-break-before property adds a page-break before a specified element..
    [<CustomOperation("pageBreakBeforeAlways")>]
    member inline _.pageBreakBeforeAlways([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("page-break-before: ").Append(defaultArg value "always").Append("; "))

    /// The page-break-before property adds a page-break before a specified element..
    [<CustomOperation("pageBreakBeforeAuto")>]
    member inline _.pageBreakBeforeAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("page-break-before: ").Append("auto").Append("; "))

    /// The page-break-before property adds a page-break before a specified element..
    [<CustomOperation("pageBreakBeforeAvoid")>]
    member inline _.pageBreakBeforeAvoid([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("page-break-before: ").Append(defaultArg value "avoid").Append("; "))

    /// The page-break-before property adds a page-break before a specified element..
    [<CustomOperation("pageBreakBeforeInherit")>]
    member inline _.pageBreakBeforeInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("page-break-before: ").Append("inherit").Append("; "))

    /// The page-break-before property adds a page-break before a specified element..
    [<CustomOperation("pageBreakBeforeInitial")>]
    member inline _.pageBreakBeforeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("page-break-before: ").Append("initial").Append("; "))

    /// The page-break-before property adds a page-break before a specified element..
    [<CustomOperation("pageBreakBeforeLeft")>]
    member inline _.pageBreakBeforeLeft([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("page-break-before: ").Append(defaultArg value "left").Append("; "))

    /// The page-break-before property adds a page-break before a specified element..
    [<CustomOperation("pageBreakBeforeRight")>]
    member inline _.pageBreakBeforeRight([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("page-break-before: ").Append(defaultArg value "right").Append("; "))

    /// 
    [<CustomOperation("pageBreakInside")>]
    member inline _.pageBreakInside([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("page-break-inside: ").Append(value).Append("; "))

    ///  The paint-order property specifies the order of how an SVG element or text is painted. 
    [<CustomOperation("paintOrder")>]
    member inline _.paintOrder([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("paint-order: ").Append(value).Append("; "))

    /// The paint-order property specifies the order of how an SVG element or text is painted.
    [<CustomOperation("paintOrderInherit")>]
    member inline _.paintOrderInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("paint-order: ").Append("inherit").Append("; "))

    /// The paint-order property specifies the order of how an SVG element or text is painted.
    [<CustomOperation("paintOrderInitial")>]
    member inline _.paintOrderInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("paint-order: ").Append("initial").Append("; "))

    /// The paint-order property specifies the order of how an SVG element or text is painted.
    [<CustomOperation("paintOrderNormal")>]
    member inline _.paintOrderNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("paint-order: ").Append(defaultArg value "normal").Append("; "))

    /// The paint-order property specifies the order of how an SVG element or text is painted.
    [<CustomOperation("paintOrderOneValue")>]
    member inline _.paintOrderOneValue([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("paint-order: ").Append(defaultArg value "one value").Append("; "))

    /// The paint-order property specifies the order of how an SVG element or text is painted.
    [<CustomOperation("paintOrderThreeValues")>]
    member inline _.paintOrderThreeValues([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("paint-order: ").Append(defaultArg value "three values").Append("; "))

    /// The paint-order property specifies the order of how an SVG element or text is painted.
    [<CustomOperation("paintOrderTwoValues")>]
    member inline _.paintOrderTwoValues([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("paint-order: ").Append(defaultArg value "two values").Append("; "))

    ///  The perspective property is used to give a 3D-positioned element some perspective. 
    [<CustomOperation("perspective")>]
    member inline _.perspective([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("perspective: ").Append(value).Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("perspectiveOriginInherit")>]
    member inline _.perspectiveOriginInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("perspective-origin: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("perspectiveOriginInitial")>]
    member inline _.perspectiveOriginInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("perspective-origin: ").Append("initial").Append("; "))

    /// Defining where the view is placed at the x-axisPossible values:leftcenterrightlength%Default value: 50%
    [<CustomOperation("perspectiveOriginXAxis")>]
    member inline _.perspectiveOriginXAxis([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("perspective-origin: ").Append(defaultArg value "x-axis").Append("; "))

    /// Defining where the view is placed at the y-axisPossible values:topcenterbottomlength%Default value: 50%
    [<CustomOperation("perspectiveOriginYAxis")>]
    member inline _.perspectiveOriginYAxis([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("perspective-origin: ").Append(defaultArg value "y-axis").Append("; "))

    /// The perspective property is used to give a 3D-positioned element some perspective.
    [<CustomOperation("perspectiveLength")>]
    member inline _.perspectiveLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("perspective: ").Append(string value + "px").Append("; "))

    /// The perspective property is used to give a 3D-positioned element some perspective.
    [<CustomOperation("perspectiveNone")>]
    member inline _.perspectiveNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("perspective: ").Append(defaultArg value "none").Append("; "))

    ///  The place-content property is used in flexbox and grid layouts, and is a shorthand property for the following properties: 
    [<CustomOperation("placeContent")>]
    member inline _.placeContent([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-content: ").Append(value).Append("; "))

    /// The place-content property is used in flexbox and grid layouts, and is a shorthand property for the following properties:
    [<CustomOperation("placeContentCenter")>]
    member inline _.placeContentCenter([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-content: ").Append(defaultArg value "center").Append("; "))

    /// The place-content property is used in flexbox and grid layouts, and is a shorthand property for the following properties:
    [<CustomOperation("placeContentEnd")>]
    member inline _.placeContentEnd([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-content: ").Append(defaultArg value "end").Append("; "))

    /// The place-content property is used in flexbox and grid layouts, and is a shorthand property for the following properties:
    [<CustomOperation("placeContentInherit")>]
    member inline _.placeContentInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-content: ").Append("inherit").Append("; "))

    /// The place-content property is used in flexbox and grid layouts, and is a shorthand property for the following properties:
    [<CustomOperation("placeContentInitial")>]
    member inline _.placeContentInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-content: ").Append("initial").Append("; "))

    /// The place-content property is used in flexbox and grid layouts, and is a shorthand property for the following properties:
    [<CustomOperation("placeContentNormal")>]
    member inline _.placeContentNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-content: ").Append(defaultArg value "normal").Append("; "))

    /// The place-content property is used in flexbox and grid layouts, and is a shorthand property for the following properties:
    [<CustomOperation("placeContentOverflowAlignment")>]
    member inline _.placeContentOverflowAlignment([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-content: ").Append(defaultArg value "overflow-alignment").Append("; "))

    /// The place-content property is used in flexbox and grid layouts, and is a shorthand property for the following properties:
    [<CustomOperation("placeContentSpaceAround")>]
    member inline _.placeContentSpaceAround([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-content: ").Append(defaultArg value "space-around").Append("; "))

    /// The place-content property is used in flexbox and grid layouts, and is a shorthand property for the following properties:
    [<CustomOperation("placeContentSpaceBetween")>]
    member inline _.placeContentSpaceBetween([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-content: ").Append(defaultArg value "space-between").Append("; "))

    /// The place-content property is used in flexbox and grid layouts, and is a shorthand property for the following properties:
    [<CustomOperation("placeContentSpaceEvenly")>]
    member inline _.placeContentSpaceEvenly([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-content: ").Append(defaultArg value "space-evenly").Append("; "))

    /// The place-content property is used in flexbox and grid layouts, and is a shorthand property for the following properties:
    [<CustomOperation("placeContentStart")>]
    member inline _.placeContentStart([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-content: ").Append(defaultArg value "start").Append("; "))

    /// The place-content property is used in flexbox and grid layouts, and is a shorthand property for the following properties:
    [<CustomOperation("placeContentStretch")>]
    member inline _.placeContentStretch([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-content: ").Append(defaultArg value "stretch").Append("; "))

    ///  The place-items property is used in grid layout, and is a shorthand property for the following properties: 
    [<CustomOperation("placeItems")>]
    member inline _.placeItems([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-items: ").Append(value).Append("; "))

    /// The place-items property is used in grid layout, and is a shorthand property for the following properties:
    [<CustomOperation("placeItemsBaseline")>]
    member inline _.placeItemsBaseline([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-items: ").Append(defaultArg value "baseline").Append("; "))

    /// The place-items property is used in grid layout, and is a shorthand property for the following properties:
    [<CustomOperation("placeItemsCenter")>]
    member inline _.placeItemsCenter([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-items: ").Append(defaultArg value "center").Append("; "))

    /// The place-items property is used in grid layout, and is a shorthand property for the following properties:
    [<CustomOperation("placeItemsEnd")>]
    member inline _.placeItemsEnd([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-items: ").Append(defaultArg value "end").Append("; "))

    /// The place-items property is used in grid layout, and is a shorthand property for the following properties:
    [<CustomOperation("placeItemsInherit")>]
    member inline _.placeItemsInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-items: ").Append("inherit").Append("; "))

    /// The place-items property is used in grid layout, and is a shorthand property for the following properties:
    [<CustomOperation("placeItemsInitial")>]
    member inline _.placeItemsInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-items: ").Append("initial").Append("; "))

    /// The place-items property is used in grid layout, and is a shorthand property for the following properties:
    [<CustomOperation("placeItemsNormalLegacy")>]
    member inline _.placeItemsNormalLegacy([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-items: ").Append(defaultArg value "normal legacy").Append("; "))

    /// The place-items property is used in grid layout, and is a shorthand property for the following properties:
    [<CustomOperation("placeItemsStart")>]
    member inline _.placeItemsStart([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-items: ").Append(defaultArg value "start").Append("; "))

    /// The place-items property is used in grid layout, and is a shorthand property for the following properties:
    [<CustomOperation("placeItemsStretch")>]
    member inline _.placeItemsStretch([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-items: ").Append(defaultArg value "stretch").Append("; "))

    ///  The place-self property is used to align individual grid items, and is a shorthand property for the following properties: 
    [<CustomOperation("placeSelf")>]
    member inline _.placeSelf([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-self: ").Append(value).Append("; "))

    /// The place-self property is used to align individual grid items, and is a shorthand property for the following properties:
    [<CustomOperation("placeSelfAuto")>]
    member inline _.placeSelfAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-self: ").Append("auto").Append("; "))

    /// The place-self property is used to align individual grid items, and is a shorthand property for the following properties:
    [<CustomOperation("placeSelfBaselineAlignment")>]
    member inline _.placeSelfBaselineAlignment([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-self: ").Append(defaultArg value "baseline alignment").Append("; "))

    /// The place-self property is used to align individual grid items, and is a shorthand property for the following properties:
    [<CustomOperation("placeSelfCenter")>]
    member inline _.placeSelfCenter([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-self: ").Append(defaultArg value "center").Append("; "))

    /// The place-self property is used to align individual grid items, and is a shorthand property for the following properties:
    [<CustomOperation("placeSelfEnd")>]
    member inline _.placeSelfEnd([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-self: ").Append(defaultArg value "end").Append("; "))

    /// The place-self property is used to align individual grid items, and is a shorthand property for the following properties:
    [<CustomOperation("placeSelfInherit")>]
    member inline _.placeSelfInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-self: ").Append("inherit").Append("; "))

    /// The place-self property is used to align individual grid items, and is a shorthand property for the following properties:
    [<CustomOperation("placeSelfInitial")>]
    member inline _.placeSelfInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-self: ").Append("initial").Append("; "))

    /// The place-self property is used to align individual grid items, and is a shorthand property for the following properties:
    [<CustomOperation("placeSelfLeft")>]
    member inline _.placeSelfLeft([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-self: ").Append(defaultArg value "left").Append("; "))

    /// The place-self property is used to align individual grid items, and is a shorthand property for the following properties:
    [<CustomOperation("placeSelfNormal")>]
    member inline _.placeSelfNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-self: ").Append(defaultArg value "normal").Append("; "))

    /// The place-self property is used to align individual grid items, and is a shorthand property for the following properties:
    [<CustomOperation("placeSelfOverflowAlignment")>]
    member inline _.placeSelfOverflowAlignment([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-self: ").Append(defaultArg value "overflow-alignment").Append("; "))

    /// The place-self property is used to align individual grid items, and is a shorthand property for the following properties:
    [<CustomOperation("placeSelfRight")>]
    member inline _.placeSelfRight([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-self: ").Append(defaultArg value "right").Append("; "))

    /// The place-self property is used to align individual grid items, and is a shorthand property for the following properties:
    [<CustomOperation("placeSelfStart")>]
    member inline _.placeSelfStart([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-self: ").Append(defaultArg value "start").Append("; "))

    /// The place-self property is used to align individual grid items, and is a shorthand property for the following properties:
    [<CustomOperation("placeSelfStretch")>]
    member inline _.placeSelfStretch([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("place-self: ").Append(defaultArg value "stretch").Append("; "))

    ///  The pointer-events property defines whether or not an element reacts to pointer events. 
    [<CustomOperation("pointerEvents")>]
    member inline _.pointerEvents([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("pointer-events: ").Append(value).Append("; "))

    /// The pointer-events property defines whether or not an element reacts to pointer events.
    [<CustomOperation("pointerEventsAuto")>]
    member inline _.pointerEventsAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("pointer-events: ").Append("auto").Append("; "))

    /// The pointer-events property defines whether or not an element reacts to pointer events.
    [<CustomOperation("pointerEventsInherit")>]
    member inline _.pointerEventsInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("pointer-events: ").Append("inherit").Append("; "))

    /// The pointer-events property defines whether or not an element reacts to pointer events.
    [<CustomOperation("pointerEventsInitial")>]
    member inline _.pointerEventsInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("pointer-events: ").Append("initial").Append("; "))

    /// The pointer-events property defines whether or not an element reacts to pointer events.
    [<CustomOperation("pointerEventsNone")>]
    member inline _.pointerEventsNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("pointer-events: ").Append(defaultArg value "none").Append("; "))

    ///  The position property specifies the type of positioning method used for an element (static, relative, absolute, fixed, or sticky). 
    [<CustomOperation("position")>]
    member inline _.position([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("position: ").Append(value).Append("; "))

    /// The position property specifies the type of positioning method used for an element (static, relative, absolute, fixed, or sticky).
    [<CustomOperation("positionAbsolute")>]
    member inline _.positionAbsolute([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("position: ").Append(defaultArg value "absolute").Append("; "))

    /// The position property specifies the type of positioning method used for an element (static, relative, absolute, fixed, or sticky).
    [<CustomOperation("positionFixed")>]
    member inline _.positionFixed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("position: ").Append(defaultArg value "fixed").Append("; "))

    /// The position property specifies the type of positioning method used for an element (static, relative, absolute, fixed, or sticky).
    [<CustomOperation("positionInherit")>]
    member inline _.positionInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("position: ").Append("inherit").Append("; "))

    /// The position property specifies the type of positioning method used for an element (static, relative, absolute, fixed, or sticky).
    [<CustomOperation("positionInitial")>]
    member inline _.positionInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("position: ").Append("initial").Append("; "))

    /// The position property specifies the type of positioning method used for an element (static, relative, absolute, fixed, or sticky).
    [<CustomOperation("positionRelative")>]
    member inline _.positionRelative([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("position: ").Append(defaultArg value "relative").Append("; "))

    /// The position property specifies the type of positioning method used for an element (static, relative, absolute, fixed, or sticky).
    [<CustomOperation("positionStatic")>]
    member inline _.positionStatic([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("position: ").Append(defaultArg value "static").Append("; "))

    /// The position property specifies the type of positioning method used for an element (static, relative, absolute, fixed, or sticky).
    [<CustomOperation("positionSticky")>]
    member inline _.positionSticky([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("position: ").Append(defaultArg value "sticky").Append("; "))

    ///  The quotes property sets the type of quotation marks for quotations. 
    [<CustomOperation("quotes")>]
    member inline _.quotes([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("quotes: ").Append(value).Append("; "))

    /// The quotes property sets the type of quotation marks for quotations.
    [<CustomOperation("quotesInherit")>]
    member inline _.quotesInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("quotes: ").Append("inherit").Append("; "))

    /// The quotes property sets the type of quotation marks for quotations.
    [<CustomOperation("quotesInitial")>]
    member inline _.quotesInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("quotes: ").Append("initial").Append("; "))

    /// The quotes property sets the type of quotation marks for quotations.
    [<CustomOperation("quotesNone")>]
    member inline _.quotesNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("quotes: ").Append(defaultArg value "none").Append("; "))

    /// The quotes property sets the type of quotation marks for quotations.
    [<CustomOperation("quotesStringStringStringString")>]
    member inline _.quotesStringStringStringString([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("quotes: ").Append(defaultArg value "string string string string").Append("; "))

    ///  The resize property defines if (and how) an element is resizable by the user. 
    [<CustomOperation("resize")>]
    member inline _.resize([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("resize: ").Append(value).Append("; "))

    /// The resize property defines if (and how) an element is resizable by the user.
    [<CustomOperation("resizeBoth")>]
    member inline _.resizeBoth([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("resize: ").Append(defaultArg value " both").Append("; "))

    /// The resize property defines if (and how) an element is resizable by the user.
    [<CustomOperation("resizeHorizontal")>]
    member inline _.resizeHorizontal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("resize: ").Append(defaultArg value " horizontal").Append("; "))

    /// The resize property defines if (and how) an element is resizable by the user.
    [<CustomOperation("resizeNone")>]
    member inline _.resizeNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("resize: ").Append(defaultArg value " none").Append("; "))

    /// The resize property defines if (and how) an element is resizable by the user.
    [<CustomOperation("resizeVertical")>]
    member inline _.resizeVertical([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("resize: ").Append(defaultArg value " vertical").Append("; "))

    /// The resize property defines if (and how) an element is resizable by the user.
    [<CustomOperation("resizeInherit")>]
    member inline _.resizeInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("resize: ").Append("inherit").Append("; "))

    /// The resize property defines if (and how) an element is resizable by the user.
    [<CustomOperation("resizeInitial")>]
    member inline _.resizeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("resize: ").Append("initial").Append("; "))

    ///  The right property affects the horizontal position of a positioned element. This property has no effect on non-positioned elements. 
    [<CustomOperation("right")>]
    member inline _.right([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("right: ").Append(value).Append("; "))

    /// The right property affects the horizontal position of a positioned element. This property has no effect on non-positioned elements.
    [<CustomOperation("right")>]
    member inline _.right([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("right: ").Append(string value + "%").Append("; "))

    /// The right property affects the horizontal position of a positioned element. This property has no effect on non-positioned elements.
    [<CustomOperation("rightAuto")>]
    member inline _.rightAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("right: ").Append("auto").Append("; "))

    /// The right property affects the horizontal position of a positioned element. This property has no effect on non-positioned elements.
    [<CustomOperation("rightInherit")>]
    member inline _.rightInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("right: ").Append("inherit").Append("; "))

    /// The right property affects the horizontal position of a positioned element. This property has no effect on non-positioned elements.
    [<CustomOperation("rightInitial")>]
    member inline _.rightInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("right: ").Append("initial").Append("; "))

    /// The right property affects the horizontal position of a positioned element. This property has no effect on non-positioned elements.
    [<CustomOperation("rightLength")>]
    member inline _.rightLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("right: ").Append(string value + "px").Append("; "))

    ///  The rotate property allows you to rotate elements. 
    [<CustomOperation("rotate")>]
    member inline _.rotate([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("rotate: ").Append(value).Append("; "))

    /// The rotate property allows you to rotate elements.
    [<CustomOperation("rotateAngle")>]
    member inline _.rotateAngle([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("rotate: ").Append(defaultArg value "angle").Append("; "))

    /// The rotate property allows you to rotate elements.
    [<CustomOperation("rotateAxis")>]
    member inline _.rotateAxis([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("rotate: ").Append(defaultArg value "axis").Append("; "))

    /// The rotate property allows you to rotate elements.
    [<CustomOperation("rotateInherit")>]
    member inline _.rotateInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("rotate: ").Append("inherit").Append("; "))

    /// The rotate property allows you to rotate elements.
    [<CustomOperation("rotateInitial")>]
    member inline _.rotateInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("rotate: ").Append("initial").Append("; "))

    /// The rotate property allows you to rotate elements.
    [<CustomOperation("rotateVectorAngle")>]
    member inline _.rotateVectorAngle([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("rotate: ").Append(defaultArg value "vector angle").Append("; "))

    ///  The row-gap property specifies the gap between the rows in a flexbox or grid layout. 
    [<CustomOperation("rowGap")>]
    member inline _.rowGap([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("row-gap: ").Append(value).Append("; "))

    /// The row-gap property specifies the gap between the rows in a flexbox or grid layout.
    [<CustomOperation("rowGapInherit")>]
    member inline _.rowGapInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("row-gap: ").Append("inherit").Append("; "))

    /// The row-gap property specifies the gap between the rows in a flexbox or grid layout.
    [<CustomOperation("rowGapInitial")>]
    member inline _.rowGapInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("row-gap: ").Append("initial").Append("; "))

    /// The row-gap property specifies the gap between the rows in a flexbox or grid layout.
    [<CustomOperation("rowGapLength")>]
    member inline _.rowGapLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("row-gap: ").Append(string value + "px").Append("; "))

    /// The row-gap property specifies the gap between the rows in a flexbox or grid layout.
    [<CustomOperation("rowGapNormal")>]
    member inline _.rowGapNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("row-gap: ").Append(defaultArg value "normal").Append("; "))

    ///  The scale property allows you to change the size of elements. 
    [<CustomOperation("scale")>]
    member inline _.scale([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scale: ").Append(value).Append("; "))

    /// The scale property allows you to change the size of elements.
    [<CustomOperation("scaleInherit")>]
    member inline _.scaleInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scale: ").Append("inherit").Append("; "))

    /// The scale property allows you to change the size of elements.
    [<CustomOperation("scaleInitial")>]
    member inline _.scaleInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scale: ").Append("initial").Append("; "))

    /// The scale property allows you to change the size of elements.
    [<CustomOperation("scaleXAxis")>]
    member inline _.scaleXAxis([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scale: ").Append(defaultArg value "x-axis").Append("; "))

    /// The scale property allows you to change the size of elements.
    [<CustomOperation("scaleYAxis")>]
    member inline _.scaleYAxis([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scale: ").Append(defaultArg value "y-axis").Append("; "))

    /// The scale property allows you to change the size of elements.
    [<CustomOperation("scaleZAxis")>]
    member inline _.scaleZAxis([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scale: ").Append(defaultArg value "z-axis").Append("; "))

    ///  The scroll-behavior property specifies whether to smoothly animate the scroll position, instead of a straight jump, when the user clicks on a link within a scrollable box. 
    [<CustomOperation("scrollBehavior")>]
    member inline _.scrollBehavior([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-behavior: ").Append(value).Append("; "))

    /// The scroll-behavior property specifies whether to smoothly animate the scroll position, instead of a straight jump, when the user clicks on a link within a scrollable box.
    [<CustomOperation("scrollBehaviorAuto")>]
    member inline _.scrollBehaviorAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-behavior: ").Append("auto").Append("; "))

    /// The scroll-behavior property specifies whether to smoothly animate the scroll position, instead of a straight jump, when the user clicks on a link within a scrollable box.
    [<CustomOperation("scrollBehaviorInherit")>]
    member inline _.scrollBehaviorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-behavior: ").Append("inherit").Append("; "))

    /// The scroll-behavior property specifies whether to smoothly animate the scroll position, instead of a straight jump, when the user clicks on a link within a scrollable box.
    [<CustomOperation("scrollBehaviorInitial")>]
    member inline _.scrollBehaviorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-behavior: ").Append("initial").Append("; "))

    /// The scroll-behavior property specifies whether to smoothly animate the scroll position, instead of a straight jump, when the user clicks on a link within a scrollable box.
    [<CustomOperation("scrollBehaviorSmooth")>]
    member inline _.scrollBehaviorSmooth([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-behavior: ").Append(defaultArg value "smooth").Append("; "))

    ///  The scroll-margin property specifies the distance between the snap position and the container. 
    [<CustomOperation("scrollMargin")>]
    member inline _.scrollMargin([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin: ").Append(value).Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("scrollMarginBlockInherit")>]
    member inline _.scrollMarginBlockInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-block: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("scrollMarginBlockInitial")>]
    member inline _.scrollMarginBlockInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-block: ").Append("initial").Append("; "))

    /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
    [<CustomOperation("scrollMarginBlockLength")>]
    member inline _.scrollMarginBlockLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-block: ").Append(string value + "px").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("scrollMarginBlockEndInherit")>]
    member inline _.scrollMarginBlockEndInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-block-end: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("scrollMarginBlockEndInitial")>]
    member inline _.scrollMarginBlockEndInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-block-end: ").Append("initial").Append("; "))

    /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
    [<CustomOperation("scrollMarginBlockEndLength")>]
    member inline _.scrollMarginBlockEndLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-block-end: ").Append(string value + "px").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("scrollMarginBlockStartInherit")>]
    member inline _.scrollMarginBlockStartInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-block-start: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("scrollMarginBlockStartInitial")>]
    member inline _.scrollMarginBlockStartInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-block-start: ").Append("initial").Append("; "))

    /// Specifies distance in px, pt, cm, etc. Negative values are allowed. Read about length units
    [<CustomOperation("scrollMarginBlockStartLength")>]
    member inline _.scrollMarginBlockStartLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-block-start: ").Append(string value + "px").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("scrollMarginBottomInherit")>]
    member inline _.scrollMarginBottomInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-bottom: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("scrollMarginBottomInitial")>]
    member inline _.scrollMarginBottomInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-bottom: ").Append("initial").Append("; "))

    /// Specifies scroll-margin-bottom in px, pt, cm, etc. Negative values are allowed. Read about length units
    [<CustomOperation("scrollMarginBottomLength")>]
    member inline _.scrollMarginBottomLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-bottom: ").Append(string value + "px").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("scrollMarginLeftInherit")>]
    member inline _.scrollMarginLeftInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-left: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("scrollMarginLeftInitial")>]
    member inline _.scrollMarginLeftInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-left: ").Append("initial").Append("; "))

    /// Specifies scroll-margin-left in px, pt, cm, etc. Negative values are allowed. Read about length units
    [<CustomOperation("scrollMarginLeftLength")>]
    member inline _.scrollMarginLeftLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-left: ").Append(string value + "px").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("scrollMarginRightInherit")>]
    member inline _.scrollMarginRightInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-right: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("scrollMarginRightInitial")>]
    member inline _.scrollMarginRightInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-right: ").Append("initial").Append("; "))

    /// Specifies scroll-margin-right in px, pt, cm, etc. Negative values are allowed. Read about length units
    [<CustomOperation("scrollMarginRightLength")>]
    member inline _.scrollMarginRightLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-right: ").Append(string value + "px").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("scrollMarginTopInherit")>]
    member inline _.scrollMarginTopInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-top: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("scrollMarginTopInitial")>]
    member inline _.scrollMarginTopInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-top: ").Append("initial").Append("; "))

    /// Specifies scroll-margin-top in px, pt, cm, etc. Negative values are allowed. Read about length units
    [<CustomOperation("scrollMarginTopLength")>]
    member inline _.scrollMarginTopLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-margin-top: ").Append(string value + "px").Append("; "))

    ///  The scroll-padding property specifies the distance from the container to the snap position of child elements. 
    [<CustomOperation("scrollPadding")>]
    member inline _.scrollPadding([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding: ").Append(value).Append("; "))

    /// Specifies the padding in percent of the width of the containing element
    [<CustomOperation("scrollPaddingBlock")>]
    member inline _.scrollPaddingBlock([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-block: ").Append(string value + "%").Append("; "))

    /// Default value. The browser calculates the padding
    [<CustomOperation("scrollPaddingBlockAuto")>]
    member inline _.scrollPaddingBlockAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-block: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("scrollPaddingBlockInherit")>]
    member inline _.scrollPaddingBlockInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-block: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("scrollPaddingBlockInitial")>]
    member inline _.scrollPaddingBlockInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-block: ").Append("initial").Append("; "))

    /// Specifies scroll-padding-block in px, pt, cm, etc. Negative values are not allowed. Read about length units
    [<CustomOperation("scrollPaddingBlockLength")>]
    member inline _.scrollPaddingBlockLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-block: ").Append(string value + "px").Append("; "))

    /// Specifies the padding in percent of the width of the containing element
    [<CustomOperation("scrollPaddingBlockEnd")>]
    member inline _.scrollPaddingBlockEnd([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-block-end: ").Append(string value + "%").Append("; "))

    /// Default value. The browser calculates the padding
    [<CustomOperation("scrollPaddingBlockEndAuto")>]
    member inline _.scrollPaddingBlockEndAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-block-end: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("scrollPaddingBlockEndInherit")>]
    member inline _.scrollPaddingBlockEndInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-block-end: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("scrollPaddingBlockEndInitial")>]
    member inline _.scrollPaddingBlockEndInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-block-end: ").Append("initial").Append("; "))

    /// Specifies scroll-padding-block-end in px, pt, cm, etc. Negative values are not allowed. Read about length units
    [<CustomOperation("scrollPaddingBlockEndLength")>]
    member inline _.scrollPaddingBlockEndLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-block-end: ").Append(string value + "px").Append("; "))

    /// Specifies the padding in percent of the width of the containing element
    [<CustomOperation("scrollPaddingBlockStart")>]
    member inline _.scrollPaddingBlockStart([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-block-start: ").Append(string value + "%").Append("; "))

    /// Default value. The browser calculates the padding
    [<CustomOperation("scrollPaddingBlockStartAuto")>]
    member inline _.scrollPaddingBlockStartAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-block-start: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("scrollPaddingBlockStartInherit")>]
    member inline _.scrollPaddingBlockStartInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-block-start: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("scrollPaddingBlockStartInitial")>]
    member inline _.scrollPaddingBlockStartInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-block-start: ").Append("initial").Append("; "))

    /// Specifies scroll-padding-block-start in px, pt, cm, etc. Negative values are not allowed. Read about length units
    [<CustomOperation("scrollPaddingBlockStartLength")>]
    member inline _.scrollPaddingBlockStartLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-block-start: ").Append(string value + "px").Append("; "))

    /// Specifies the padding in percent of the width of the containing element
    [<CustomOperation("scrollPaddingBottom")>]
    member inline _.scrollPaddingBottom([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-bottom: ").Append(string value + "%").Append("; "))

    /// Default value. The browser calculates the padding
    [<CustomOperation("scrollPaddingBottomAuto")>]
    member inline _.scrollPaddingBottomAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-bottom: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("scrollPaddingBottomInherit")>]
    member inline _.scrollPaddingBottomInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-bottom: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("scrollPaddingBottomInitial")>]
    member inline _.scrollPaddingBottomInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-bottom: ").Append("initial").Append("; "))

    /// Specifies scroll-padding-bottom in px, pt, cm, etc. Negative values are not allowed. Read about length units
    [<CustomOperation("scrollPaddingBottomLength")>]
    member inline _.scrollPaddingBottomLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-bottom: ").Append(string value + "px").Append("; "))

    /// Specifies the padding in percent of the width of the containing element
    [<CustomOperation("scrollPaddingLeft")>]
    member inline _.scrollPaddingLeft([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-left: ").Append(string value + "%").Append("; "))

    /// Default value. The browser calculates the padding
    [<CustomOperation("scrollPaddingLeftAuto")>]
    member inline _.scrollPaddingLeftAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-left: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("scrollPaddingLeftInherit")>]
    member inline _.scrollPaddingLeftInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-left: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("scrollPaddingLeftInitial")>]
    member inline _.scrollPaddingLeftInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-left: ").Append("initial").Append("; "))

    /// Specifies scroll-padding-left in px, pt, cm, etc. Negative values are not allowed. Read about length units
    [<CustomOperation("scrollPaddingLeftLength")>]
    member inline _.scrollPaddingLeftLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-left: ").Append(string value + "px").Append("; "))

    /// Specifies the padding in percent of the width of the containing element
    [<CustomOperation("scrollPaddingRight")>]
    member inline _.scrollPaddingRight([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-right: ").Append(string value + "%").Append("; "))

    /// Default value. The browser calculates the padding
    [<CustomOperation("scrollPaddingRightAuto")>]
    member inline _.scrollPaddingRightAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-right: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("scrollPaddingRightInherit")>]
    member inline _.scrollPaddingRightInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-right: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("scrollPaddingRightInitial")>]
    member inline _.scrollPaddingRightInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-right: ").Append("initial").Append("; "))

    /// Specifies scroll-padding-right in px, pt, cm, etc. Negative values are not allowed. Read about length units
    [<CustomOperation("scrollPaddingRightLength")>]
    member inline _.scrollPaddingRightLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-right: ").Append(string value + "px").Append("; "))

    /// Specifies the padding in percent of the width of the containing element
    [<CustomOperation("scrollPaddingTop")>]
    member inline _.scrollPaddingTop([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-top: ").Append(string value + "%").Append("; "))

    /// Default value. The browser calculates the padding
    [<CustomOperation("scrollPaddingTopAuto")>]
    member inline _.scrollPaddingTopAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-top: ").Append("auto").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("scrollPaddingTopInherit")>]
    member inline _.scrollPaddingTopInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-top: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("scrollPaddingTopInitial")>]
    member inline _.scrollPaddingTopInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-top: ").Append("initial").Append("; "))

    /// Specifies scroll-padding-top in px, pt, cm, etc. Negative values are not allowed. Read about length units
    [<CustomOperation("scrollPaddingTopLength")>]
    member inline _.scrollPaddingTopLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-padding-top: ").Append(string value + "px").Append("; "))

    ///  The scroll-snap-align property specifies where elements will snap into focus when you stop scrolling. 
    [<CustomOperation("scrollSnapAlign")>]
    member inline _.scrollSnapAlign([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-align: ").Append(value).Append("; "))

    /// The scroll-snap-align property specifies where elements will snap into focus when you stop scrolling.
    [<CustomOperation("scrollSnapAlignBlockInline")>]
    member inline _.scrollSnapAlignBlockInline([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-align: ").Append(defaultArg value "block inline").Append("; "))

    /// The scroll-snap-align property specifies where elements will snap into focus when you stop scrolling.
    [<CustomOperation("scrollSnapAlignCenter")>]
    member inline _.scrollSnapAlignCenter([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-align: ").Append(defaultArg value "center").Append("; "))

    /// The scroll-snap-align property specifies where elements will snap into focus when you stop scrolling.
    [<CustomOperation("scrollSnapAlignEnd")>]
    member inline _.scrollSnapAlignEnd([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-align: ").Append(defaultArg value "end").Append("; "))

    /// The scroll-snap-align property specifies where elements will snap into focus when you stop scrolling.
    [<CustomOperation("scrollSnapAlignInherit")>]
    member inline _.scrollSnapAlignInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-align: ").Append("inherit").Append("; "))

    /// The scroll-snap-align property specifies where elements will snap into focus when you stop scrolling.
    [<CustomOperation("scrollSnapAlignInitial")>]
    member inline _.scrollSnapAlignInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-align: ").Append("initial").Append("; "))

    /// The scroll-snap-align property specifies where elements will snap into focus when you stop scrolling.
    [<CustomOperation("scrollSnapAlignNone")>]
    member inline _.scrollSnapAlignNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-align: ").Append(defaultArg value "none").Append("; "))

    /// The scroll-snap-align property specifies where elements will snap into focus when you stop scrolling.
    [<CustomOperation("scrollSnapAlignStart")>]
    member inline _.scrollSnapAlignStart([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-align: ").Append(defaultArg value "start").Append("; "))

    ///  When swiping fast on a trackpad or a touch screen, the scroll-snap-stop property specifies whether to scroll past elements or to stop and snap on the next element. 
    [<CustomOperation("scrollSnapStop")>]
    member inline _.scrollSnapStop([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-stop: ").Append(value).Append("; "))

    /// When swiping fast on a trackpad or a touch screen, the scroll-snap-stop property specifies whether to scroll past elements or to stop and snap on the next element.
    [<CustomOperation("scrollSnapStopAlways")>]
    member inline _.scrollSnapStopAlways([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-stop: ").Append(defaultArg value "always").Append("; "))

    /// When swiping fast on a trackpad or a touch screen, the scroll-snap-stop property specifies whether to scroll past elements or to stop and snap on the next element.
    [<CustomOperation("scrollSnapStopInherit")>]
    member inline _.scrollSnapStopInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-stop: ").Append("inherit").Append("; "))

    /// When swiping fast on a trackpad or a touch screen, the scroll-snap-stop property specifies whether to scroll past elements or to stop and snap on the next element.
    [<CustomOperation("scrollSnapStopInitial")>]
    member inline _.scrollSnapStopInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-stop: ").Append("initial").Append("; "))

    /// When swiping fast on a trackpad or a touch screen, the scroll-snap-stop property specifies whether to scroll past elements or to stop and snap on the next element.
    [<CustomOperation("scrollSnapStopNormal")>]
    member inline _.scrollSnapStopNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-stop: ").Append(defaultArg value "normal").Append("; "))

    ///  The scroll-snap-type specifies how the elements will snap into focus when you stop scrolling, and in what direction. 
    [<CustomOperation("scrollSnapType")>]
    member inline _.scrollSnapType([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-type: ").Append(value).Append("; "))

    /// The scroll-snap-type specifies how the elements will snap into focus when you stop scrolling, and in what direction.
    [<CustomOperation("scrollSnapTypeBlock")>]
    member inline _.scrollSnapTypeBlock([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-type: ").Append(defaultArg value "block").Append("; "))

    /// The scroll-snap-type specifies how the elements will snap into focus when you stop scrolling, and in what direction.
    [<CustomOperation("scrollSnapTypeBoth")>]
    member inline _.scrollSnapTypeBoth([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-type: ").Append(defaultArg value "both").Append("; "))

    /// The scroll-snap-type specifies how the elements will snap into focus when you stop scrolling, and in what direction.
    [<CustomOperation("scrollSnapTypeInherit")>]
    member inline _.scrollSnapTypeInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-type: ").Append("inherit").Append("; "))

    /// The scroll-snap-type specifies how the elements will snap into focus when you stop scrolling, and in what direction.
    [<CustomOperation("scrollSnapTypeInitial")>]
    member inline _.scrollSnapTypeInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-type: ").Append("initial").Append("; "))

    /// The scroll-snap-type specifies how the elements will snap into focus when you stop scrolling, and in what direction.
    [<CustomOperation("scrollSnapTypeInline")>]
    member inline _.scrollSnapTypeInline([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-type: ").Append(defaultArg value "inline").Append("; "))

    /// The scroll-snap-type specifies how the elements will snap into focus when you stop scrolling, and in what direction.
    [<CustomOperation("scrollSnapTypeMandatory")>]
    member inline _.scrollSnapTypeMandatory([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-type: ").Append(defaultArg value "mandatory").Append("; "))

    /// The scroll-snap-type specifies how the elements will snap into focus when you stop scrolling, and in what direction.
    [<CustomOperation("scrollSnapTypeNone")>]
    member inline _.scrollSnapTypeNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-type: ").Append(defaultArg value "none").Append("; "))

    /// The scroll-snap-type specifies how the elements will snap into focus when you stop scrolling, and in what direction.
    [<CustomOperation("scrollSnapTypeProximity")>]
    member inline _.scrollSnapTypeProximity([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-type: ").Append(defaultArg value "proximity").Append("; "))

    /// The scroll-snap-type specifies how the elements will snap into focus when you stop scrolling, and in what direction.
    [<CustomOperation("scrollSnapTypeX")>]
    member inline _.scrollSnapTypeX([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-type: ").Append(defaultArg value "x").Append("; "))

    /// The scroll-snap-type specifies how the elements will snap into focus when you stop scrolling, and in what direction.
    [<CustomOperation("scrollSnapTypeY")>]
    member inline _.scrollSnapTypeY([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scroll-snap-type: ").Append(defaultArg value "y").Append("; "))

    ///  The scrollbar-color property specifies the color of the scrollbar track (background) and thumb (the scroller). 
    [<CustomOperation("scrollbarColor")>]
    member inline _.scrollbarColor([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scrollbar-color: ").Append(value).Append("; "))

    /// The scrollbar-color property specifies the color of the scrollbar track (background) and thumb (the scroller).
    [<CustomOperation("scrollbarColorAuto")>]
    member inline _.scrollbarColorAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scrollbar-color: ").Append("auto").Append("; "))

    /// The scrollbar-color property specifies the color of the scrollbar track (background) and thumb (the scroller).
    [<CustomOperation("scrollbarColorColorColor")>]
    member inline _.scrollbarColorColorColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("scrollbar-color: ").Append(defaultArg value "color color").Append("; "))

    /// The scrollbar-color property specifies the color of the scrollbar track (background) and thumb (the scroller).
    [<CustomOperation("scrollbarColorInherit")>]
    member inline _.scrollbarColorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scrollbar-color: ").Append("inherit").Append("; "))

    /// The scrollbar-color property specifies the color of the scrollbar track (background) and thumb (the scroller).
    [<CustomOperation("scrollbarColorInitial")>]
    member inline _.scrollbarColorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("scrollbar-color: ").Append("initial").Append("; "))

    ///  The tab-size property specifies the width of a tab character. 
    [<CustomOperation("tabSize")>]
    member inline _.tabSize([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("tab-size: ").Append(value).Append("; "))

    ///  The table-layout property defines the algorithm used to lay out table cells, rows, and columns. 
    [<CustomOperation("tableLayout")>]
    member inline _.tableLayout([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("table-layout: ").Append(value).Append("; "))

    /// The table-layout property defines the algorithm used to lay out table cells, rows, and columns.
    [<CustomOperation("tableLayoutAuto")>]
    member inline _.tableLayoutAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("table-layout: ").Append("auto").Append("; "))

    /// The table-layout property defines the algorithm used to lay out table cells, rows, and columns.
    [<CustomOperation("tableLayoutFixed")>]
    member inline _.tableLayoutFixed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("table-layout: ").Append(defaultArg value "fixed").Append("; "))

    /// The table-layout property defines the algorithm used to lay out table cells, rows, and columns.
    [<CustomOperation("tableLayoutInherit")>]
    member inline _.tableLayoutInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("table-layout: ").Append("inherit").Append("; "))

    /// The table-layout property defines the algorithm used to lay out table cells, rows, and columns.
    [<CustomOperation("tableLayoutInitial")>]
    member inline _.tableLayoutInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("table-layout: ").Append("initial").Append("; "))

    ///  The text-align property specifies the horizontal alignment of text in an element. 
    [<CustomOperation("textAlign")>]
    member inline _.textAlign([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-align: ").Append(value).Append("; "))

    /// Default value. The last line is justified and aligned left
    [<CustomOperation("textAlignLastAuto")>]
    member inline _.textAlignLastAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-align-last: ").Append("auto").Append("; "))

    /// The last line is center-aligned
    [<CustomOperation("textAlignLastCenter")>]
    member inline _.textAlignLastCenter([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-align-last: ").Append(defaultArg value "center").Append("; "))

    /// The last line is aligned at the end of the line (right if the text-direction is left-to-right, and left is the text-direction is right-to-left)
    [<CustomOperation("textAlignLastEnd")>]
    member inline _.textAlignLastEnd([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-align-last: ").Append(defaultArg value "end").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("textAlignLastInherit")>]
    member inline _.textAlignLastInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-align-last: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("textAlignLastInitial")>]
    member inline _.textAlignLastInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-align-last: ").Append("initial").Append("; "))

    /// The last line is justified as the rest of the lines
    [<CustomOperation("textAlignLastJustify")>]
    member inline _.textAlignLastJustify([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-align-last: ").Append(defaultArg value "justify").Append("; "))

    /// The last line is aligned to the left
    [<CustomOperation("textAlignLastLeft")>]
    member inline _.textAlignLastLeft([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-align-last: ").Append(defaultArg value "left").Append("; "))

    /// The last line is aligned to the right
    [<CustomOperation("textAlignLastRight")>]
    member inline _.textAlignLastRight([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-align-last: ").Append(defaultArg value "right").Append("; "))

    /// The last line is aligned at the beginning of the line (left if the text-direction is left-to-right, and right is the text-direction is right-to-left)
    [<CustomOperation("textAlignLastStart")>]
    member inline _.textAlignLastStart([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-align-last: ").Append(defaultArg value "start").Append("; "))

    /// 
    [<CustomOperation("textDecoration")>]
    member inline _.textDecoration([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-decoration: ").Append(value).Append("; "))

    /// Specifies the color of the text-decoration
    [<CustomOperation("textDecorationColorColor")>]
    member inline _.textDecorationColorColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-decoration-color: ").Append(defaultArg value "color").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("textDecorationColorInherit")>]
    member inline _.textDecorationColorInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-decoration-color: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("textDecorationColorInitial")>]
    member inline _.textDecorationColorInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-decoration-color: ").Append("initial").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("textDecorationLineInherit")>]
    member inline _.textDecorationLineInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-decoration-line: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("textDecorationLineInitial")>]
    member inline _.textDecorationLineInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-decoration-line: ").Append("initial").Append("; "))

    /// Specifies that a line will be displayed through the text
    [<CustomOperation("textDecorationLineLineThrough")>]
    member inline _.textDecorationLineLineThrough([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-decoration-line: ").Append(defaultArg value "line-through").Append("; "))

    /// Default value. Specifies no line for the text-decoration
    [<CustomOperation("textDecorationLineNone")>]
    member inline _.textDecorationLineNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-decoration-line: ").Append(defaultArg value "none").Append("; "))

    /// Specifies that a line will be displayed over the text
    [<CustomOperation("textDecorationLineOverline")>]
    member inline _.textDecorationLineOverline([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-decoration-line: ").Append(defaultArg value "overline").Append("; "))

    /// Specifies that a line will be displayed under the text
    [<CustomOperation("textDecorationLineUnderline")>]
    member inline _.textDecorationLineUnderline([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-decoration-line: ").Append(defaultArg value "underline").Append("; "))

    /// The line will display as a dashed line
    [<CustomOperation("textDecorationStyleDashed")>]
    member inline _.textDecorationStyleDashed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-decoration-style: ").Append(defaultArg value "dashed").Append("; "))

    /// The line will display as a dotted line
    [<CustomOperation("textDecorationStyleDotted")>]
    member inline _.textDecorationStyleDotted([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-decoration-style: ").Append(defaultArg value "dotted").Append("; "))

    /// The line will display as a double line
    [<CustomOperation("textDecorationStyleDouble")>]
    member inline _.textDecorationStyleDouble([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-decoration-style: ").Append(defaultArg value "double").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("textDecorationStyleInherit")>]
    member inline _.textDecorationStyleInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-decoration-style: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("textDecorationStyleInitial")>]
    member inline _.textDecorationStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-decoration-style: ").Append("initial").Append("; "))

    /// Default value. The line will display as a single line
    [<CustomOperation("textDecorationStyleSolid")>]
    member inline _.textDecorationStyleSolid([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-decoration-style: ").Append(defaultArg value "solid").Append("; "))

    /// The line will display as a wavy line
    [<CustomOperation("textDecorationStyleWavy")>]
    member inline _.textDecorationStyleWavy([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-decoration-style: ").Append(defaultArg value "wavy").Append("; "))

    ///  The text-emphasis property is used to apply emphasis marks to text. 
    [<CustomOperation("textEmphasis")>]
    member inline _.textEmphasis([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-emphasis: ").Append(value).Append("; "))

    ///  The text-indent property specifies the indentation of the first line in a text-block. 
    [<CustomOperation("textIndent")>]
    member inline _.textIndent([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-indent: ").Append(value).Append("; "))

    /// The text-indent property specifies the indentation of the first line in a text-block.
    [<CustomOperation("textIndent")>]
    member inline _.textIndent([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-indent: ").Append(string value + "%").Append("; "))

    /// The text-indent property specifies the indentation of the first line in a text-block.
    [<CustomOperation("textIndentInherit")>]
    member inline _.textIndentInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-indent: ").Append("inherit").Append("; "))

    /// The text-indent property specifies the indentation of the first line in a text-block.
    [<CustomOperation("textIndentInitial")>]
    member inline _.textIndentInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-indent: ").Append("initial").Append("; "))

    /// The text-indent property specifies the indentation of the first line in a text-block.
    [<CustomOperation("textIndentLength")>]
    member inline _.textIndentLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-indent: ").Append(string value + "px").Append("; "))

    ///  The text-justify property specifies the justification method of text when text-align is set to "justify". 
    [<CustomOperation("textJustify")>]
    member inline _.textJustify([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-justify: ").Append(value).Append("; "))

    /// The text-justify property specifies the justification method of text when text-align is set to "justify".
    [<CustomOperation("textJustifyAuto")>]
    member inline _.textJustifyAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-justify: ").Append("auto").Append("; "))

    /// The text-justify property specifies the justification method of text when text-align is set to "justify".
    [<CustomOperation("textJustifyInherit")>]
    member inline _.textJustifyInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-justify: ").Append("inherit").Append("; "))

    /// The text-justify property specifies the justification method of text when text-align is set to "justify".
    [<CustomOperation("textJustifyInitial")>]
    member inline _.textJustifyInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-justify: ").Append("initial").Append("; "))

    /// The text-justify property specifies the justification method of text when text-align is set to "justify".
    [<CustomOperation("textJustifyInterCharacter")>]
    member inline _.textJustifyInterCharacter([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-justify: ").Append(defaultArg value "inter-character").Append("; "))

    /// The text-justify property specifies the justification method of text when text-align is set to "justify".
    [<CustomOperation("textJustifyInterWord")>]
    member inline _.textJustifyInterWord([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-justify: ").Append(defaultArg value "inter-word").Append("; "))

    /// The text-justify property specifies the justification method of text when text-align is set to "justify".
    [<CustomOperation("textJustifyNone")>]
    member inline _.textJustifyNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-justify: ").Append(defaultArg value "none").Append("; "))

    ///  The text-orientation property specifies the orientation of characters. 
    [<CustomOperation("textOrientation")>]
    member inline _.textOrientation([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-orientation: ").Append(value).Append("; "))

    /// The text-orientation property specifies the orientation of characters.
    [<CustomOperation("textOrientationInherit")>]
    member inline _.textOrientationInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-orientation: ").Append("inherit").Append("; "))

    /// The text-orientation property specifies the orientation of characters.
    [<CustomOperation("textOrientationInitial")>]
    member inline _.textOrientationInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-orientation: ").Append("initial").Append("; "))

    /// The text-orientation property specifies the orientation of characters.
    [<CustomOperation("textOrientationMixed")>]
    member inline _.textOrientationMixed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-orientation: ").Append(defaultArg value "mixed").Append("; "))

    /// The text-orientation property specifies the orientation of characters.
    [<CustomOperation("textOrientationSideways")>]
    member inline _.textOrientationSideways([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-orientation: ").Append(defaultArg value "sideways").Append("; "))

    /// The text-orientation property specifies the orientation of characters.
    [<CustomOperation("textOrientationSidewaysRight")>]
    member inline _.textOrientationSidewaysRight([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-orientation: ").Append(defaultArg value "sideways-right").Append("; "))

    /// The text-orientation property specifies the orientation of characters.
    [<CustomOperation("textOrientationUpright")>]
    member inline _.textOrientationUpright([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-orientation: ").Append(defaultArg value "upright").Append("; "))

    /// The text-orientation property specifies the orientation of characters.
    [<CustomOperation("textOrientationUseGlyphOrientation")>]
    member inline _.textOrientationUseGlyphOrientation([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-orientation: ").Append(defaultArg value "use-glyph-orientation").Append("; "))

    ///  The text-overflow property specifies how overflowed content that is not displayed should be signaled to the user. It can be clipped, display an ellipsis (...), or display a custom string. 
    [<CustomOperation("textOverflow")>]
    member inline _.textOverflow([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-overflow: ").Append(value).Append("; "))

    /// The text-overflow property specifies how overflowed content that is not displayed should be signaled to the user. It can be clipped, display an ellipsis (...), or display a custom string.
    [<CustomOperation("textOverflowClip")>]
    member inline _.textOverflowClip([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-overflow: ").Append(defaultArg value "clip").Append("; "))

    /// The text-overflow property specifies how overflowed content that is not displayed should be signaled to the user. It can be clipped, display an ellipsis (...), or display a custom string.
    [<CustomOperation("textOverflowEllipsis")>]
    member inline _.textOverflowEllipsis([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-overflow: ").Append(defaultArg value "ellipsis").Append("; "))

    /// The text-overflow property specifies how overflowed content that is not displayed should be signaled to the user. It can be clipped, display an ellipsis (...), or display a custom string.
    [<CustomOperation("textOverflowInherit")>]
    member inline _.textOverflowInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-overflow: ").Append("inherit").Append("; "))

    /// The text-overflow property specifies how overflowed content that is not displayed should be signaled to the user. It can be clipped, display an ellipsis (...), or display a custom string.
    [<CustomOperation("textOverflowInitial")>]
    member inline _.textOverflowInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-overflow: ").Append("initial").Append("; "))

    /// The text-overflow property specifies how overflowed content that is not displayed should be signaled to the user. It can be clipped, display an ellipsis (...), or display a custom string.
    [<CustomOperation("textOverflowString")>]
    member inline _.textOverflowString([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-overflow: ").Append(defaultArg value "string").Append("; "))

    ///  The text-shadow property adds shadow to text. 
    [<CustomOperation("textShadow")>]
    member inline _.textShadow([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-shadow: ").Append(value).Append("; "))

    /// The text-shadow property adds shadow to text.
    [<CustomOperation("textShadowBlurRadius")>]
    member inline _.textShadowBlurRadius([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-shadow: ").Append(defaultArg value "blur-radius").Append("; "))

    /// The text-shadow property adds shadow to text.
    [<CustomOperation("textShadowColor")>]
    member inline _.textShadowColor([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-shadow: ").Append(defaultArg value "color").Append("; "))

    /// The text-shadow property adds shadow to text.
    [<CustomOperation("textShadowHShadow")>]
    member inline _.textShadowHShadow([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-shadow: ").Append(defaultArg value "h-shadow").Append("; "))

    /// The text-shadow property adds shadow to text.
    [<CustomOperation("textShadowInherit")>]
    member inline _.textShadowInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-shadow: ").Append("inherit").Append("; "))

    /// The text-shadow property adds shadow to text.
    [<CustomOperation("textShadowInitial")>]
    member inline _.textShadowInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-shadow: ").Append("initial").Append("; "))

    /// The text-shadow property adds shadow to text.
    [<CustomOperation("textShadowNone")>]
    member inline _.textShadowNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-shadow: ").Append(defaultArg value "none").Append("; "))

    /// The text-shadow property adds shadow to text.
    [<CustomOperation("textShadowVShadow")>]
    member inline _.textShadowVShadow([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-shadow: ").Append(defaultArg value "v-shadow").Append("; "))

    ///  The text-transform property controls the capitalization of text. 
    [<CustomOperation("textTransform")>]
    member inline _.textTransform([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-transform: ").Append(value).Append("; "))

    /// The text-transform property controls the capitalization of text.
    [<CustomOperation("textTransformCapitalize")>]
    member inline _.textTransformCapitalize([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-transform: ").Append(defaultArg value "capitalize").Append("; "))

    /// The text-transform property controls the capitalization of text.
    [<CustomOperation("textTransformInherit")>]
    member inline _.textTransformInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-transform: ").Append("inherit").Append("; "))

    /// The text-transform property controls the capitalization of text.
    [<CustomOperation("textTransformInitial")>]
    member inline _.textTransformInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-transform: ").Append("initial").Append("; "))

    /// The text-transform property controls the capitalization of text.
    [<CustomOperation("textTransformLowercase")>]
    member inline _.textTransformLowercase([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-transform: ").Append(defaultArg value "lowercase").Append("; "))

    /// The text-transform property controls the capitalization of text.
    [<CustomOperation("textTransformNone")>]
    member inline _.textTransformNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-transform: ").Append(defaultArg value "none").Append("; "))

    /// The text-transform property controls the capitalization of text.
    [<CustomOperation("textTransformUppercase")>]
    member inline _.textTransformUppercase([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-transform: ").Append(defaultArg value "uppercase").Append("; "))

    ///  The text-underline-offset property specifies the offset distance of underline text decorations. 
    [<CustomOperation("textUnderlineOffset")>]
    member inline _.textUnderlineOffset([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-underline-offset: ").Append(value).Append("; "))

    /// The text-underline-offset property specifies the offset distance of underline text decorations.
    [<CustomOperation("textUnderlineOffsetAuto")>]
    member inline _.textUnderlineOffsetAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-underline-offset: ").Append("auto").Append("; "))

    /// The text-underline-offset property specifies the offset distance of underline text decorations.
    [<CustomOperation("textUnderlineOffsetInherit")>]
    member inline _.textUnderlineOffsetInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-underline-offset: ").Append("inherit").Append("; "))

    /// The text-underline-offset property specifies the offset distance of underline text decorations.
    [<CustomOperation("textUnderlineOffsetInitial")>]
    member inline _.textUnderlineOffsetInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-underline-offset: ").Append("initial").Append("; "))

    /// The text-underline-offset property specifies the offset distance of underline text decorations.
    [<CustomOperation("textUnderlineOffsetLength")>]
    member inline _.textUnderlineOffsetLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-underline-offset: ").Append(string value + "px").Append("; "))

    /// The text-underline-offset property specifies the offset distance of underline text decorations.
    [<CustomOperation("textUnderlineOffsetPercentage")>]
    member inline _.textUnderlineOffsetPercentage([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-underline-offset: ").Append(defaultArg value "percentage").Append("; "))

    ///  The text-underline-position property specifies the position of underline text decorations. 
    [<CustomOperation("textUnderlinePosition")>]
    member inline _.textUnderlinePosition([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-underline-position: ").Append(value).Append("; "))

    /// The text-underline-position property specifies the position of underline text decorations.
    [<CustomOperation("textUnderlinePositionAuto")>]
    member inline _.textUnderlinePositionAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-underline-position: ").Append("auto").Append("; "))

    /// The text-underline-position property specifies the position of underline text decorations.
    [<CustomOperation("textUnderlinePositionFromFont")>]
    member inline _.textUnderlinePositionFromFont([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-underline-position: ").Append(defaultArg value "from-font").Append("; "))

    /// The text-underline-position property specifies the position of underline text decorations.
    [<CustomOperation("textUnderlinePositionInherit")>]
    member inline _.textUnderlinePositionInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-underline-position: ").Append("inherit").Append("; "))

    /// The text-underline-position property specifies the position of underline text decorations.
    [<CustomOperation("textUnderlinePositionInitial")>]
    member inline _.textUnderlinePositionInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-underline-position: ").Append("initial").Append("; "))

    /// The text-underline-position property specifies the position of underline text decorations.
    [<CustomOperation("textUnderlinePositionLeft")>]
    member inline _.textUnderlinePositionLeft([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-underline-position: ").Append(defaultArg value "left").Append("; "))

    /// The text-underline-position property specifies the position of underline text decorations.
    [<CustomOperation("textUnderlinePositionRight")>]
    member inline _.textUnderlinePositionRight([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-underline-position: ").Append(defaultArg value "right").Append("; "))

    /// The text-underline-position property specifies the position of underline text decorations.
    [<CustomOperation("textUnderlinePositionUnder")>]
    member inline _.textUnderlinePositionUnder([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("text-underline-position: ").Append(defaultArg value "under").Append("; "))

    ///  The top property affects the vertical position of a positioned element. This property has no effect on non-positioned elements. 
    [<CustomOperation("top")>]
    member inline _.top([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("top: ").Append(value).Append("; "))

    /// The top property affects the vertical position of a positioned element. This property has no effect on non-positioned elements.
    [<CustomOperation("top")>]
    member inline _.top([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("top: ").Append(string value + "%").Append("; "))

    /// The top property affects the vertical position of a positioned element. This property has no effect on non-positioned elements.
    [<CustomOperation("topAuto")>]
    member inline _.topAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("top: ").Append("auto").Append("; "))

    /// The top property affects the vertical position of a positioned element. This property has no effect on non-positioned elements.
    [<CustomOperation("topInherit")>]
    member inline _.topInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("top: ").Append("inherit").Append("; "))

    /// The top property affects the vertical position of a positioned element. This property has no effect on non-positioned elements.
    [<CustomOperation("topInitial")>]
    member inline _.topInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("top: ").Append("initial").Append("; "))

    /// The top property affects the vertical position of a positioned element. This property has no effect on non-positioned elements.
    [<CustomOperation("topLength")>]
    member inline _.topLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("top: ").Append(string value + "px").Append("; "))

    ///  The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements. 
    [<CustomOperation("transform")>]
    member inline _.transform([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append(value).Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("transformOriginInherit")>]
    member inline _.transformOriginInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform-origin: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("transformOriginInitial")>]
    member inline _.transformOriginInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform-origin: ").Append("initial").Append("; "))

    /// Defines where the view is placed at the x-axis. Possible values: leftcenterrightlength%
    [<CustomOperation("transformOriginXAxis")>]
    member inline _.transformOriginXAxis([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform-origin: ").Append(defaultArg value "x-axis").Append("; "))

    /// Defines where the view is placed at the y-axis. Possible values: topcenterbottomlength%
    [<CustomOperation("transformOriginYAxis")>]
    member inline _.transformOriginYAxis([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform-origin: ").Append(defaultArg value "y-axis").Append("; "))

    /// Defines where the view is placed at the z-axis (for 3D transformations). Possible values: length
    [<CustomOperation("transformOriginZAxis")>]
    member inline _.transformOriginZAxis([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform-origin: ").Append(defaultArg value "z-axis").Append("; "))

    /// Specifies that child elements will NOT preserve its 3D position. This is default
    [<CustomOperation("transformStyleFlat")>]
    member inline _.transformStyleFlat([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform-style: ").Append(defaultArg value "flat").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("transformStyleInherit")>]
    member inline _.transformStyleInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform-style: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("transformStyleInitial")>]
    member inline _.transformStyleInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform-style: ").Append("initial").Append("; "))

    /// Specifies that child elements will preserve its 3D position
    [<CustomOperation("transformStylePreserve3d")>]
    member inline _.transformStylePreserve3d([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform-style: ").Append(defaultArg value "preserve-3d").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformMatrix")>]
    member inline _.transformMatrix([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" matrix({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformMatrix3d")>]
    member inline _.transformMatrix3d([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" matrix3d ({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformPerspective")>]
    member inline _.transformPerspective([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" perspective({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformRotate")>]
    member inline _.transformRotate([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" rotate({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformRotate3d")>]
    member inline _.transformRotate3d([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" rotate3d({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformRotateX")>]
    member inline _.transformRotateX([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" rotateX({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformRotateY")>]
    member inline _.transformRotateY([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" rotateY({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformRotateZ")>]
    member inline _.transformRotateZ([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" rotateZ({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformScale")>]
    member inline _.transformScale([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" scale({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformScale3d")>]
    member inline _.transformScale3d([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" scale3d({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformScaleX")>]
    member inline _.transformScaleX([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" scaleX({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformScaleY")>]
    member inline _.transformScaleY([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" scaleY({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformScaleZ")>]
    member inline _.transformScaleZ([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" scaleZ({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformSkew")>]
    member inline _.transformSkew([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" skew({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformSkewX")>]
    member inline _.transformSkewX([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" skewX({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformSkewY")>]
    member inline _.transformSkewY([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" skewY({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformTranslate")>]
    member inline _.transformTranslate([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" translate({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformTranslate3d")>]
    member inline _.transformTranslate3d([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" translate3d({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformTranslateX")>]
    member inline _.transformTranslateX([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" translateX({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformTranslateY")>]
    member inline _.transformTranslateY([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" translateY({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformTranslateZ")>]
    member inline _.transformTranslateZ([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append($" translateZ({value})").Append("; "))

    /// The transform property applies a 2D or 3D transformation to an element. This property allows you to rotate, scale, move, skew, etc., elements.
    [<CustomOperation("transformNone")>]
    member inline _.transformNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transform: ").Append(defaultArg value "none").Append("; "))

    ///  The transition property is a shorthand property for: 
    [<CustomOperation("transition")>]
    member inline _.transition([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition: ").Append(value).Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("transitionDelayInherit")>]
    member inline _.transitionDelayInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-delay: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("transitionDelayInitial")>]
    member inline _.transitionDelayInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-delay: ").Append("initial").Append("; "))

    /// Specifies the number of seconds or milliseconds to wait before the transition effect will start
    [<CustomOperation("transitionDelayTime")>]
    member inline _.transitionDelayTime([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-delay: ").Append(value).Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("transitionDurationInherit")>]
    member inline _.transitionDurationInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-duration: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("transitionDurationInitial")>]
    member inline _.transitionDurationInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-duration: ").Append("initial").Append("; "))

    /// Specifies how many seconds or milliseconds a transition effect takes to complete. Default value is 0s, meaning there will be no effect
    [<CustomOperation("transitionDurationTime")>]
    member inline _.transitionDurationTime([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-duration: ").Append(value).Append("; "))

    /// Default value. All properties will get a transition effect
    [<CustomOperation("transitionPropertyAll")>]
    member inline _.transitionPropertyAll([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-property: ").Append(defaultArg value "all").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("transitionPropertyInherit")>]
    member inline _.transitionPropertyInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-property: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("transitionPropertyInitial")>]
    member inline _.transitionPropertyInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-property: ").Append("initial").Append("; "))

    /// No property will get a transition effect
    [<CustomOperation("transitionPropertyNone")>]
    member inline _.transitionPropertyNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-property: ").Append(defaultArg value "none").Append("; "))

    /// Defines a comma separated list of CSS property names the transition effect is for
    [<CustomOperation("transitionPropertyProperty")>]
    member inline _.transitionPropertyProperty([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-property: ").Append(defaultArg value "property").Append("; "))

    /// Define your own values in the cubic-bezier function. Possible values are numeric values from 0 to 1
    [<CustomOperation("transitionTimingFunctionCubicBezier")>]
    member inline _.transitionTimingFunctionCubicBezier([<InlineIfLambda>] comb: CombineKeyValue, n1: string, n2: string, n3: string, n4: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-timing-function: ").Append(n1).Append(n2).Append(n3).Append(n4).Append("; "))

    /// Default value. Specifies a transition effect with a slow start, then fast, then end slowly (equivalent to cubic-bezier(0.25,0.1,0.25,1))
    [<CustomOperation("transitionTimingFunctionEase")>]
    member inline _.transitionTimingFunctionEase([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-timing-function: ").Append(defaultArg value "ease").Append("; "))

    /// Specifies a transition effect with a slow start (equivalent to cubic-bezier(0.42,0,1,1))
    [<CustomOperation("transitionTimingFunctionEaseIn")>]
    member inline _.transitionTimingFunctionEaseIn([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-timing-function: ").Append(defaultArg value "ease-in").Append("; "))

    /// Specifies a transition effect with a slow start and end (equivalent to cubic-bezier(0.42,0,0.58,1))
    [<CustomOperation("transitionTimingFunctionEaseInOut")>]
    member inline _.transitionTimingFunctionEaseInOut([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-timing-function: ").Append(defaultArg value "ease-in-out").Append("; "))

    /// Specifies a transition effect with a slow end (equivalent to cubic-bezier(0,0,0.58,1))
    [<CustomOperation("transitionTimingFunctionEaseOut")>]
    member inline _.transitionTimingFunctionEaseOut([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-timing-function: ").Append(defaultArg value "ease-out").Append("; "))

    /// Inherits this property from its parent element.  Read about inherit
    [<CustomOperation("transitionTimingFunctionInherit")>]
    member inline _.transitionTimingFunctionInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-timing-function: ").Append("inherit").Append("; "))

    /// Sets this property to its default value.  Read about initial
    [<CustomOperation("transitionTimingFunctionInitial")>]
    member inline _.transitionTimingFunctionInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-timing-function: ").Append("initial").Append("; "))

    /// Specifies a transition effect with the same speed from start to end (equivalent to cubic-bezier(0,0,1,1))
    [<CustomOperation("transitionTimingFunctionLinear")>]
    member inline _.transitionTimingFunctionLinear([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-timing-function: ").Append(defaultArg value "linear").Append("; "))

    /// Equivalent to steps(1, end)
    [<CustomOperation("transitionTimingFunctionStepEnd")>]
    member inline _.transitionTimingFunctionStepEnd([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-timing-function: ").Append(defaultArg value "step-end").Append("; "))

    /// Equivalent to steps(1, start)
    [<CustomOperation("transitionTimingFunctionStepStart")>]
    member inline _.transitionTimingFunctionStepStart([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-timing-function: ").Append(defaultArg value "step-start").Append("; "))

    /// Specifies a stepping function, with two parameters. The first parameter specifies the number of intervals in the function. It must be a positive integer (greater than 0). The second parameter, which is optional, is either the value "start" or "end", and specifies the point at which the change of values occur within the interval. If the second parameter is omitted, it is given the value "end"
    [<CustomOperation("transitionTimingFunctionSteps")>]
    member inline _.transitionTimingFunctionSteps([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition-timing-function: ").Append($"steps({value})").Append("; "))

    /// The transition property is a shorthand property for:
    [<CustomOperation("transitionTransitionDelay")>]
    member inline _.transitionTransitionDelay([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition: ").Append(defaultArg value "transition-delay").Append("; "))

    /// The transition property is a shorthand property for:
    [<CustomOperation("transitionTransitionDuration")>]
    member inline _.transitionTransitionDuration([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition: ").Append(defaultArg value "transition-duration").Append("; "))

    /// The transition property is a shorthand property for:
    [<CustomOperation("transitionTransitionProperty")>]
    member inline _.transitionTransitionProperty([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition: ").Append(defaultArg value "transition-property").Append("; "))

    /// The transition property is a shorthand property for:
    [<CustomOperation("transitionTransitionTimingFunction")>]
    member inline _.transitionTransitionTimingFunction([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("transition: ").Append(defaultArg value "transition-timing-function").Append("; "))

    ///  The translate property allows you to change the position of elements. 
    [<CustomOperation("translate")>]
    member inline _.translate([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("translate: ").Append(value).Append("; "))

    /// The translate property allows you to change the position of elements.
    [<CustomOperation("translateInherit")>]
    member inline _.translateInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("translate: ").Append("inherit").Append("; "))

    /// The translate property allows you to change the position of elements.
    [<CustomOperation("translateInitial")>]
    member inline _.translateInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("translate: ").Append("initial").Append("; "))

    /// The translate property allows you to change the position of elements.
    [<CustomOperation("translateXAxis")>]
    member inline _.translateXAxis([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("translate: ").Append(defaultArg value "x-axis").Append("; "))

    /// The translate property allows you to change the position of elements.
    [<CustomOperation("translateYAxis")>]
    member inline _.translateYAxis([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("translate: ").Append(defaultArg value "y-axis").Append("; "))

    /// The translate property allows you to change the position of elements.
    [<CustomOperation("translateZAxis")>]
    member inline _.translateZAxis([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("translate: ").Append(defaultArg value "z-axis").Append("; "))

    ///  The unicode-bidi property is used together with the direction property to set or return whether the text should be overridden to support multiple languages in the same document. 
    [<CustomOperation("unicodeBidi")>]
    member inline _.unicodeBidi([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("unicode-bidi: ").Append(value).Append("; "))

    /// The unicode-bidi property is used together with the direction property to set or return whether the text should be overridden to support multiple languages in the same document.
    [<CustomOperation("unicodeBidiBidiOverride")>]
    member inline _.unicodeBidiBidiOverride([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("unicode-bidi: ").Append(defaultArg value "bidi-override").Append("; "))

    /// The unicode-bidi property is used together with the direction property to set or return whether the text should be overridden to support multiple languages in the same document.
    [<CustomOperation("unicodeBidiEmbed")>]
    member inline _.unicodeBidiEmbed([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("unicode-bidi: ").Append(defaultArg value "embed").Append("; "))

    /// The unicode-bidi property is used together with the direction property to set or return whether the text should be overridden to support multiple languages in the same document.
    [<CustomOperation("unicodeBidiInherit")>]
    member inline _.unicodeBidiInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("unicode-bidi: ").Append("inherit").Append("; "))

    /// The unicode-bidi property is used together with the direction property to set or return whether the text should be overridden to support multiple languages in the same document.
    [<CustomOperation("unicodeBidiInitial")>]
    member inline _.unicodeBidiInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("unicode-bidi: ").Append("initial").Append("; "))

    /// The unicode-bidi property is used together with the direction property to set or return whether the text should be overridden to support multiple languages in the same document.
    [<CustomOperation("unicodeBidiIsolate")>]
    member inline _.unicodeBidiIsolate([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("unicode-bidi: ").Append(defaultArg value "isolate").Append("; "))

    /// The unicode-bidi property is used together with the direction property to set or return whether the text should be overridden to support multiple languages in the same document.
    [<CustomOperation("unicodeBidiIsolateOverride")>]
    member inline _.unicodeBidiIsolateOverride([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("unicode-bidi: ").Append(defaultArg value "isolate-override").Append("; "))

    /// The unicode-bidi property is used together with the direction property to set or return whether the text should be overridden to support multiple languages in the same document.
    [<CustomOperation("unicodeBidiNormal")>]
    member inline _.unicodeBidiNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("unicode-bidi: ").Append(defaultArg value "normal").Append("; "))

    /// The unicode-bidi property is used together with the direction property to set or return whether the text should be overridden to support multiple languages in the same document.
    [<CustomOperation("unicodeBidiPlaintext")>]
    member inline _.unicodeBidiPlaintext([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("unicode-bidi: ").Append(defaultArg value "plaintext").Append("; "))

    ///  The user-select property specifies whether the text of an element can be selected. 
    [<CustomOperation("userSelect")>]
    member inline _.userSelect([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("user-select: ").Append(value).Append("; "))

    /// The user-select property specifies whether the text of an element can be selected.
    [<CustomOperation("userSelectAll")>]
    member inline _.userSelectAll([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("user-select: ").Append(defaultArg value "all").Append("; "))

    /// The user-select property specifies whether the text of an element can be selected.
    [<CustomOperation("userSelectAuto")>]
    member inline _.userSelectAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("user-select: ").Append("auto").Append("; "))

    /// The user-select property specifies whether the text of an element can be selected.
    [<CustomOperation("userSelectNone")>]
    member inline _.userSelectNone([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("user-select: ").Append(defaultArg value "none").Append("; "))

    /// The user-select property specifies whether the text of an element can be selected.
    [<CustomOperation("userSelectText")>]
    member inline _.userSelectText([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("user-select: ").Append(defaultArg value "text").Append("; "))

    ///  The vertical-align property sets the vertical alignment of an element. 
    [<CustomOperation("verticalAlign")>]
    member inline _.verticalAlign([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append(value).Append("; "))

    /// The vertical-align property sets the vertical alignment of an element.
    [<CustomOperation("verticalAlign")>]
    member inline _.verticalAlign([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append(string value + "%").Append("; "))

    /// The vertical-align property sets the vertical alignment of an element.
    [<CustomOperation("verticalAlignBaseline")>]
    member inline _.verticalAlignBaseline([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append(defaultArg value "baseline").Append("; "))

    /// The vertical-align property sets the vertical alignment of an element.
    [<CustomOperation("verticalAlignBottom")>]
    member inline _.verticalAlignBottom([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append(defaultArg value "bottom").Append("; "))

    /// The vertical-align property sets the vertical alignment of an element.
    [<CustomOperation("verticalAlignInherit")>]
    member inline _.verticalAlignInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append("inherit").Append("; "))

    /// The vertical-align property sets the vertical alignment of an element.
    [<CustomOperation("verticalAlignInitial")>]
    member inline _.verticalAlignInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append("initial").Append("; "))

    /// The vertical-align property sets the vertical alignment of an element.
    [<CustomOperation("verticalAlignLength")>]
    member inline _.verticalAlignLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append(string value + "px").Append("; "))

    /// The vertical-align property sets the vertical alignment of an element.
    [<CustomOperation("verticalAlignMiddle")>]
    member inline _.verticalAlignMiddle([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append(defaultArg value "middle").Append("; "))

    /// The vertical-align property sets the vertical alignment of an element.
    [<CustomOperation("verticalAlignSub")>]
    member inline _.verticalAlignSub([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append(defaultArg value "sub").Append("; "))

    /// The vertical-align property sets the vertical alignment of an element.
    [<CustomOperation("verticalAlignSuper")>]
    member inline _.verticalAlignSuper([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append(defaultArg value "super").Append("; "))

    /// The vertical-align property sets the vertical alignment of an element.
    [<CustomOperation("verticalAlignTextBottom")>]
    member inline _.verticalAlignTextBottom([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append(defaultArg value "text-bottom").Append("; "))

    /// The vertical-align property sets the vertical alignment of an element.
    [<CustomOperation("verticalAlignTextTop")>]
    member inline _.verticalAlignTextTop([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append(defaultArg value "text-top").Append("; "))

    /// The vertical-align property sets the vertical alignment of an element.
    [<CustomOperation("verticalAlignTop")>]
    member inline _.verticalAlignTop([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("vertical-align: ").Append(defaultArg value "top").Append("; "))

    ///  The visibility property specifies whether or not an element is visible. 
    [<CustomOperation("visibility")>]
    member inline _.visibility([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("visibility: ").Append(value).Append("; "))

    /// The visibility property specifies whether or not an element is visible.
    [<CustomOperation("visibility")>]
    member inline _.visibility([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("visibility: ").Append(defaultArg value "").Append("; "))

    /// The visibility property specifies whether or not an element is visible.
    [<CustomOperation("visibilityCollapse")>]
    member inline _.visibilityCollapse([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("visibility: ").Append(defaultArg value "collapse").Append("; "))

    /// The visibility property specifies whether or not an element is visible.
    [<CustomOperation("visibilityHidden")>]
    member inline _.visibilityHidden([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("visibility: ").Append(defaultArg value "hidden").Append("; "))

    /// The visibility property specifies whether or not an element is visible.
    [<CustomOperation("visibilityInherit")>]
    member inline _.visibilityInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("visibility: ").Append("inherit").Append("; "))

    /// The visibility property specifies whether or not an element is visible.
    [<CustomOperation("visibilityInitial")>]
    member inline _.visibilityInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("visibility: ").Append("initial").Append("; "))

    /// The visibility property specifies whether or not an element is visible.
    [<CustomOperation("visibilityVisible")>]
    member inline _.visibilityVisible([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("visibility: ").Append(defaultArg value "visible").Append("; "))

    ///  The white-space property specifies how white-space inside an element is handled. 
    [<CustomOperation("whiteSpace")>]
    member inline _.whiteSpace([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("white-space: ").Append(value).Append("; "))

    /// The white-space property specifies how white-space inside an element is handled.
    [<CustomOperation("whiteSpaceInherit")>]
    member inline _.whiteSpaceInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("white-space: ").Append("inherit").Append("; "))

    /// The white-space property specifies how white-space inside an element is handled.
    [<CustomOperation("whiteSpaceInitial")>]
    member inline _.whiteSpaceInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("white-space: ").Append("initial").Append("; "))

    /// The white-space property specifies how white-space inside an element is handled.
    [<CustomOperation("whiteSpaceNormal")>]
    member inline _.whiteSpaceNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("white-space: ").Append(defaultArg value "normal").Append("; "))

    /// The white-space property specifies how white-space inside an element is handled.
    [<CustomOperation("whiteSpaceNowrap")>]
    member inline _.whiteSpaceNowrap([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("white-space: ").Append(defaultArg value "nowrap").Append("; "))

    /// The white-space property specifies how white-space inside an element is handled.
    [<CustomOperation("whiteSpacePre")>]
    member inline _.whiteSpacePre([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("white-space: ").Append(defaultArg value "pre").Append("; "))

    /// The white-space property specifies how white-space inside an element is handled.
    [<CustomOperation("whiteSpacePreLine")>]
    member inline _.whiteSpacePreLine([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("white-space: ").Append(defaultArg value "pre-line").Append("; "))

    /// The white-space property specifies how white-space inside an element is handled.
    [<CustomOperation("whiteSpacePreWrap")>]
    member inline _.whiteSpacePreWrap([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("white-space: ").Append(defaultArg value "pre-wrap").Append("; "))

    ///  The widows property specifies the minimum number of lines that must be left at the top of a page or column. 
    [<CustomOperation("widows")>]
    member inline _.widows([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("widows: ").Append(value).Append("; "))

    /// The widows property specifies the minimum number of lines that must be left at the top of a page or column.
    [<CustomOperation("widowsInherit")>]
    member inline _.widowsInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("widows: ").Append("inherit").Append("; "))

    /// The widows property specifies the minimum number of lines that must be left at the top of a page or column.
    [<CustomOperation("widowsInitial")>]
    member inline _.widowsInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("widows: ").Append("initial").Append("; "))

    /// The widows property specifies the minimum number of lines that must be left at the top of a page or column.
    [<CustomOperation("widowsInteger")>]
    member inline _.widowsInteger([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("widows: ").Append(defaultArg value "integer").Append("; "))

    ///  The width property sets the width of an element. 
    [<CustomOperation("width")>]
    member inline _.width([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("width: ").Append(value).Append("; "))

    /// The width property sets the width of an element.
    [<CustomOperation("width")>]
    member inline _.width([<InlineIfLambda>] comb: CombineKeyValue, value: float) = comb &&& CombineKeyValue(fun sb -> sb.Append("width: ").Append(string value + "%").Append("; "))

    /// The width property sets the width of an element.
    [<CustomOperation("widthAuto")>]
    member inline _.widthAuto([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("width: ").Append("auto").Append("; "))

    /// The width property sets the width of an element.
    [<CustomOperation("widthInherit")>]
    member inline _.widthInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("width: ").Append("inherit").Append("; "))

    /// The width property sets the width of an element.
    [<CustomOperation("widthInitial")>]
    member inline _.widthInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("width: ").Append("initial").Append("; "))

    /// The width property sets the width of an element.
    [<CustomOperation("widthLength")>]
    member inline _.widthLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("width: ").Append(string value + "px").Append("; "))

    ///  The word-break property specifies how words should break when reaching the end of a line. 
    [<CustomOperation("wordBreak")>]
    member inline _.wordBreak([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("word-break: ").Append(value).Append("; "))

    /// The word-break property specifies how words should break when reaching the end of a line.
    [<CustomOperation("wordBreakBreakAll")>]
    member inline _.wordBreakBreakAll([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("word-break: ").Append(defaultArg value "break-all").Append("; "))

    /// The word-break property specifies how words should break when reaching the end of a line.
    [<CustomOperation("wordBreakBreakWord")>]
    member inline _.wordBreakBreakWord([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("word-break: ").Append(defaultArg value "break-word").Append("; "))

    /// The word-break property specifies how words should break when reaching the end of a line.
    [<CustomOperation("wordBreakInherit")>]
    member inline _.wordBreakInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("word-break: ").Append("inherit").Append("; "))

    /// The word-break property specifies how words should break when reaching the end of a line.
    [<CustomOperation("wordBreakInitial")>]
    member inline _.wordBreakInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("word-break: ").Append("initial").Append("; "))

    /// The word-break property specifies how words should break when reaching the end of a line.
    [<CustomOperation("wordBreakKeepAll")>]
    member inline _.wordBreakKeepAll([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("word-break: ").Append(defaultArg value "keep-all ").Append("; "))

    /// The word-break property specifies how words should break when reaching the end of a line.
    [<CustomOperation("wordBreakNormal")>]
    member inline _.wordBreakNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("word-break: ").Append(defaultArg value "normal").Append("; "))

    ///  The word-spacing property increases or decreases the white space between words. 
    [<CustomOperation("wordSpacing")>]
    member inline _.wordSpacing([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("word-spacing: ").Append(value).Append("; "))

    /// The word-spacing property increases or decreases the white space between words.
    [<CustomOperation("wordSpacingInherit")>]
    member inline _.wordSpacingInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("word-spacing: ").Append("inherit").Append("; "))

    /// The word-spacing property increases or decreases the white space between words.
    [<CustomOperation("wordSpacingInitial")>]
    member inline _.wordSpacingInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("word-spacing: ").Append("initial").Append("; "))

    /// The word-spacing property increases or decreases the white space between words.
    [<CustomOperation("wordSpacingLength")>]
    member inline _.wordSpacingLength([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("word-spacing: ").Append(string value + "px").Append("; "))

    /// The word-spacing property increases or decreases the white space between words.
    [<CustomOperation("wordSpacingNormal")>]
    member inline _.wordSpacingNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("word-spacing: ").Append(defaultArg value "normal").Append("; "))

    ///  The word-wrap property allows long words to be able to be broken and wrap onto the next line. 
    [<CustomOperation("wordWrap")>]
    member inline _.wordWrap([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("word-wrap: ").Append(value).Append("; "))

    /// The word-wrap property allows long words to be able to be broken and wrap onto the next line.
    [<CustomOperation("wordWrapBreakWord")>]
    member inline _.wordWrapBreakWord([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("word-wrap: ").Append(defaultArg value "break-word").Append("; "))

    /// The word-wrap property allows long words to be able to be broken and wrap onto the next line.
    [<CustomOperation("wordWrapInherit")>]
    member inline _.wordWrapInherit([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("word-wrap: ").Append("inherit").Append("; "))

    /// The word-wrap property allows long words to be able to be broken and wrap onto the next line.
    [<CustomOperation("wordWrapInitial")>]
    member inline _.wordWrapInitial([<InlineIfLambda>] comb: CombineKeyValue) = comb &&& CombineKeyValue(fun sb -> sb.Append("word-wrap: ").Append("initial").Append("; "))

    /// The word-wrap property allows long words to be able to be broken and wrap onto the next line.
    [<CustomOperation("wordWrapNormal")>]
    member inline _.wordWrapNormal([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("word-wrap: ").Append(defaultArg value "normal").Append("; "))

    ///  The writing-mode property specifies whether lines of text are laid out horizontally or vertically. 
    [<CustomOperation("writingMode")>]
    member inline _.writingMode([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("writing-mode: ").Append(value).Append("; "))

    /// The writing-mode property specifies whether lines of text are laid out horizontally or vertically.
    [<CustomOperation("writingModeHorizontalTb")>]
    member inline _.writingModeHorizontalTb([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("writing-mode: ").Append(defaultArg value "horizontal-tb").Append("; "))

    /// The writing-mode property specifies whether lines of text are laid out horizontally or vertically.
    [<CustomOperation("writingModeVerticalLr")>]
    member inline _.writingModeVerticalLr([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("writing-mode: ").Append(defaultArg value "vertical-lr").Append("; "))

    /// The writing-mode property specifies whether lines of text are laid out horizontally or vertically.
    [<CustomOperation("writingModeVerticalRl")>]
    member inline _.writingModeVerticalRl([<InlineIfLambda>] comb: CombineKeyValue, ?value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("writing-mode: ").Append(defaultArg value "vertical-rl").Append("; "))

