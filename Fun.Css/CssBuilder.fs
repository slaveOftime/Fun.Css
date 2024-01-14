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

    ///  The animation property is a shorthand property for: 
    [<CustomOperation("animation")>]
    member inline _.animation([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("animation: ").Append(value).Append("; "))

    ///  The background property is a shorthand property for: 
    [<CustomOperation("background")>]
    member inline _.background([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("background: ").Append(value).Append("; "))

    ///  The border property is a shorthand property for: 
    [<CustomOperation("border")>]
    member inline _.border([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("border: ").Append(value).Append("; "))

    ///  The bottom property affects the vertical position of a positioned element. This property has no effect on non-positioned elements. 
    [<CustomOperation("bottom")>]
    member inline _.bottom([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("bottom: ").Append(value).Append("; "))

    ///  The bottom property affects the vertical position of a positioned element. This property has no effect on non-positioned elements. 
    [<CustomOperation("bottom")>]
    member inline _.bottom([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("bottom: ").Append(value).Append("px; "))

    ///  The color property specifies the color of text. 
    [<CustomOperation("color")>]
    member inline _.color([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("color: ").Append(value).Append("; "))

    ///  The display property specifies the display behavior (the type of rendering box) of an element. 
    [<CustomOperation("display")>]
    member inline _.display([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("display: ").Append(value).Append("; "))

    ///  The flex property is a shorthand property for: 
    [<CustomOperation("flex")>]
    member inline _.flex([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("flex: ").Append(value).Append("; "))

    ///  The gap property defines the size of the gap between the rows and between the columns in flexbox, grid or multi-column layout. It is a shorthand for the following properties: 
    [<CustomOperation("gap")>]
    member inline _.gap([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("gap: ").Append(value).Append("; "))

    ///  The gap property defines the size of the gap between the rows and between the columns in flexbox, grid or multi-column layout. It is a shorthand for the following properties: 
    [<CustomOperation("gap")>]
    member inline _.gap([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("gap: ").Append(value).Append("px; "))

    ///  The grid property is a shorthand property for: 
    [<CustomOperation("grid")>]
    member inline _.grid([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("grid: ").Append(value).Append("; "))

    ///  The height property sets the height of an element. 
    [<CustomOperation("height")>]
    member inline _.height([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("height: ").Append(value).Append("; "))

    ///  The height property sets the height of an element. 
    [<CustomOperation("height")>]
    member inline _.height([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("height: ").Append(value).Append("px; "))

    ///  The left property affects the horizontal position of a positioned element. This property has no effect on non-positioned elements. 
    [<CustomOperation("left")>]
    member inline _.left([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("left: ").Append(value).Append("; "))

    ///  The left property affects the horizontal position of a positioned element. This property has no effect on non-positioned elements. 
    [<CustomOperation("left")>]
    member inline _.left([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("left: ").Append(value).Append("px; "))

    ///  The margin property sets the margins for an element, and is a shorthand property for the following properties: 
    [<CustomOperation("margin")>]
    member inline _.margin([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin: ").Append(value).Append("; "))

    ///  The margin property sets the margins for an element, and is a shorthand property for the following properties: 
    [<CustomOperation("margin")>]
    member inline _.margin([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("margin: ").Append(value).Append("px; "))

    ///  The max-height property defines the maximum height of an element. 
    [<CustomOperation("maxHeight")>]
    member inline _.maxHeight([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-height: ").Append(value).Append("; "))

    ///  The max-height property defines the maximum height of an element. 
    [<CustomOperation("maxHeight")>]
    member inline _.maxHeight([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-height: ").Append(value).Append("px; "))

    ///  The max-width property defines the maximum width of an element. 
    [<CustomOperation("maxWidth")>]
    member inline _.maxWidth([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-width: ").Append(value).Append("; "))

    ///  The max-width property defines the maximum width of an element. 
    [<CustomOperation("maxWidth")>]
    member inline _.maxWidth([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("max-width: ").Append(value).Append("px; "))

    ///  The min-height property defines the minimum height of an element. 
    [<CustomOperation("minHeight")>]
    member inline _.minHeight([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-height: ").Append(value).Append("; "))

    ///  The min-height property defines the minimum height of an element. 
    [<CustomOperation("minHeight")>]
    member inline _.minHeight([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-height: ").Append(value).Append("px; "))

    ///  The min-width property defines the minimum width of an element. 
    [<CustomOperation("minWidth")>]
    member inline _.minWidth([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-width: ").Append(value).Append("; "))

    ///  The min-width property defines the minimum width of an element. 
    [<CustomOperation("minWidth")>]
    member inline _.minWidth([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("min-width: ").Append(value).Append("px; "))

    ///  The opacity property sets the opacity level for an element. 
    [<CustomOperation("opacity")>]
    member inline _.opacity([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("opacity: ").Append(value).Append("; "))

    /// An element's padding is the space between its content and its border.
    [<CustomOperation("padding")>]
    member inline _.padding([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding: ").Append(value).Append("; "))

    /// An element's padding is the space between its content and its border.
    [<CustomOperation("padding")>]
    member inline _.padding([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("padding: ").Append(value).Append("px; "))

    ///  The right property affects the horizontal position of a positioned element. This property has no effect on non-positioned elements. 
    [<CustomOperation("right")>]
    member inline _.right([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("right: ").Append(value).Append("; "))

    ///  The right property affects the horizontal position of a positioned element. This property has no effect on non-positioned elements. 
    [<CustomOperation("right")>]
    member inline _.right([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("right: ").Append(value).Append("px; "))

    ///  The top property affects the vertical position of a positioned element. This property has no effect on non-positioned elements. 
    [<CustomOperation("top")>]
    member inline _.top([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("top: ").Append(value).Append("; "))

    ///  The top property affects the vertical position of a positioned element. This property has no effect on non-positioned elements. 
    [<CustomOperation("top")>]
    member inline _.top([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("top: ").Append(value).Append("px; "))

    ///  The width property sets the width of an element. 
    [<CustomOperation("width")>]
    member inline _.width([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("width: ").Append(value).Append("; "))

    ///  The width property sets the width of an element. 
    [<CustomOperation("width")>]
    member inline _.width([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("width: ").Append(value).Append("px; "))

