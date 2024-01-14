#r "nuget:FSharp.Data"

open System
open System.IO
open FSharp.Data

type CSSProperties = HtmlProvider<"https://www.w3schools.com/cssref/pr_background-blend-mode.php">

type PropertyInfo = { Name: string; Url: string }

[<RequireQualifiedAccess>]
type ValueType =
    | String
    | Int
    | Float
    | None


let samples = CSSProperties.GetSample()

let properties = samples.Html.CssSelect("#leftmenuinnerinner div a")


let getDescription (doc: HtmlDocument) =
    try
        let items = doc.CssSelect("#main") |> Seq.item 0 |> (fun x -> x.Elements())
        let index = items |> Seq.findIndex (fun x -> x.Name() = "h2" && x.InnerText() = "Definition and Usage")
        if index > 0 then
            items |> Seq.item (index + 1) |> (fun x -> x.InnerText())
        else
            ""
    with ex ->
        // printfn "Get description failed %A" ex
        ""


let normalizeName (name: string) =
    let name =
        if name.Contains '-' || name.Contains ' ' then
            let sb = Text.StringBuilder()
            let mutable i = 0
            while i < name.Length do
                if name[i] = '-' || name[i] = ' ' then
                    sb.Append(name[i + 1] |> Char.ToUpper) |> ignore
                    i <- i + 2
                else if name[i] = '@' then
                    i <- i + 1
                else
                    sb.Append(name[i]) |> ignore
                    i <- i + 1
            sb.ToString()
        else
            name.Replace("@", "")

    if List.contains name [ "inherit"; "end"; "inline"; "default"; "type"; "static"; "fixed"; "float" ] then
        name + "'"
    else
        name

let makeProp (prop: HtmlNode) = {
    Name = prop.InnerText()
    Url = prop.Attribute("href").Value()
}

let loadDetail reload url =
    let dir = "Cache"
    let file = Path.Combine(dir, url + ".html")
    if Directory.Exists dir |> not then
        System.IO.Directory.CreateDirectory dir |> ignore
    if File.Exists file && not reload then
        File.ReadAllText(file) |> CSSProperties.Parse
    else
        let content = CSSProperties.Load("https://www.w3schools.com/cssref/" + url)
        File.WriteAllText(file, content.Html.ToString())
        content

let processPropertyValues (propertyValues: CSSProperties.PropertyValues.Row seq) =
    [
        for propertyValue in propertyValues |> Seq.sortBy (fun x -> x.Value) do
            let name, values =
                if propertyValue.Value.Contains "(" then
                    let value = propertyValue.Value.Substring(0, propertyValue.Value.IndexOf("("))
                    value, [ ValueType.String, "$\"" + value + "({value})\"" ]
                else if propertyValue.Value.EndsWith "%" then
                    "percentage", [ ValueType.Float, "string value + \"%\"" ]
                else if propertyValue.Value.Contains "color" then
                    propertyValue.Value, [ ValueType.String, "value" ]
                else if propertyValue.Value = "width" || propertyValue.Value = "height" || propertyValue.Value = "length" then
                    propertyValue.Value, [ ValueType.Int, "string value + \"px\""; ValueType.String, "value" ]
                else if propertyValue.Value.Contains "time" || propertyValue.Value.Contains "number" then
                    propertyValue.Value, [ ValueType.Float, "value" ]
                else if propertyValue.Value = "0" then
                    "", []
                else if propertyValue.Value = "/" then
                    propertyValue.Value.Split("/")[0], [ ValueType.String, "value" ]
                else if propertyValue.Value.Split(" ").Length > 1 then
                    let value = propertyValue.Value.Split(" ")[0]
                    (if Char.IsDigit(value[0]) then "value" else value), [ ValueType.String, "value" ]
                else
                    propertyValue.Value, [ ValueType.None, "\"" + propertyValue.Value + "\"" ]
            for vt, v in values do
                let vstr =
                    match vt with
                    | ValueType.None -> ""
                    | ValueType.Int -> "(value: int)"
                    | ValueType.Float -> "(value: float)"
                    | ValueType.String -> "(value: string)"
                if String.IsNullOrEmpty(normalizeName name) |> not then
                    propertyValue, name, v, vstr
    ]
    |> List.distinctBy (fun (_, name, _, vstr) -> name, vstr)



let autoOpenProperties = Collections.Generic.HashSet<PropertyInfo>()
let autoOpenSubProperties = Collections.Generic.Dictionary<string, Collections.Generic.HashSet<PropertyInfo>>()

let rec groupProperties (gpBy: HtmlNode -> string option) (properties: HtmlNode seq) : unit =
    properties
    |> Seq.groupBy gpBy
    |> Seq.iter (fun (g, values) ->
        let mutable shouldLoopValues = false
        match g with
        | Some name ->
            let shortHandProperty = values |> Seq.tryFind (fun x -> x.InnerText() = name)
            match shortHandProperty with
            | Some prop ->
                autoOpenProperties.Add(makeProp prop) |> ignore
                autoOpenSubProperties[name] <-
                    values |> Seq.filter (fun x -> x.InnerText() <> name) |> Seq.map makeProp |> Collections.Generic.HashSet
            | None -> shouldLoopValues <- true
        | None -> shouldLoopValues <- true

        if shouldLoopValues then
            values
            |> Seq.sortBy (fun x -> x.InnerText())
            |> Seq.toList
            |> function
                | [] -> ()
                | [ node ] -> autoOpenProperties.Add(makeProp node) |> ignore
                | node :: rest ->
                    let name = node.InnerText()
                    groupProperties (fun x -> if x.InnerText().StartsWith(name) then Some name else None) rest
    )

properties
|> Seq.filter (fun x -> x.InnerText().Contains(" ") |> not)
|> groupProperties (fun x -> x.InnerText().Split("-") |> Seq.tryHead)



let autoOpenContent = Text.StringBuilder()
let manualOpenContent = Text.StringBuilder()
let helpersContent = Text.StringBuilder()

let appendForAutoOpen (x: string) = autoOpenContent.AppendLine x |> ignore
let appendForManualOpen (x: string) = manualOpenContent.AppendLine x |> ignore
let appendForHelpers (x: string) = helpersContent.AppendLine x |> ignore

appendForManualOpen
    "/// Some properties are not used very often which will need to open this module to access them for better ce build performance
module Fun.Css.Extensions

open Internal

/// Some top level properties are not  very common which will need to manually open
type CssBuilder with
"

appendForHelpers
    "[<AutoOpen>]
module Fun.Css.Helpers

open Internal

"

let autoOpenPropertyNames = [
    "color"
    "background"
    "animation"

    "border"
    "top"
    "right"
    "bottom"
    "left"

    "gap"

    "display"
    "flex"
    "grid"

    "height"
    "width"
    "max-height"
    "max-width"
    "min-height"
    "min-width"

    "margin"
    "padding"

    "opacity"
]


autoOpenProperties
|> Seq.filter (fun x -> Seq.contains x.Name [ "z-index" ] |> not)
|> Seq.sortBy (fun x -> x.Name)
|> Seq.iter (fun property ->
    printfn "%A" property.Name

    let mainName = property.Name
    let mainDetail = loadDetail false property.Url
    let mainDescription = getDescription mainDetail.Html

    let isPxValue =
        List.contains mainName [
            "width"
            "height"
            "left"
            "right"
            "top"
            "bottom"
            "gap"
            "margin"
            "padding"
            "max-height"
            "max-width"
            "min-height"
            "min-width"
        ]

    if List.contains mainName autoOpenPropertyNames then
        appendForAutoOpen
            $"""    /// {mainDescription}
    [<CustomOperation("{normalizeName mainName}")>]
    member inline _.{normalizeName mainName}([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("{property.Name}: ").Append(value).Append("; "))
"""
        if isPxValue then
            appendForAutoOpen
                $"""    /// {mainDescription}
    [<CustomOperation("{normalizeName mainName}")>]
    member inline _.{normalizeName mainName}([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("{property.Name}: ").Append(value).Append("px; "))
"""
    else
        appendForManualOpen
            $"""    /// {mainDescription}
    [<CustomOperation("{normalizeName mainName}")>]
    member inline _.{normalizeName mainName}([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("{property.Name}: ").Append(value).Append("; "))
"""
        if isPxValue then
            appendForManualOpen
                $"""    /// {mainDescription}
    [<CustomOperation("{normalizeName mainName}")>]
    member inline _.{normalizeName mainName}([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("{property.Name}: ").Append(value).Append("px; ")) 
"""

    if autoOpenSubProperties.ContainsKey property.Name && autoOpenSubProperties[property.Name].Count > 0 then
        let mutable isModuleCreated = false
        for property in autoOpenSubProperties[property.Name] |> Seq.sortBy (fun x -> x.Name) do
            printfn "%A" property.Name
            let name = property.Name.Substring(mainName.Length + 1)
            let detail = loadDetail false property.Url
            let propertyValues =
                try
                    detail.Tables.``Property Values``.Rows
                with ex ->
                    printfn "Retry failed for get property values %A" ex
                    [||]

            if propertyValues.Length > 0 then
                if not isModuleCreated then
                    isModuleCreated <- true
                    appendForHelpers
                        $"""/// {mainDescription.Trim()}
[<RequireQualifiedAccess>]
module {normalizeName mainName} =
"""

                let description = getDescription detail.Html
                appendForHelpers
                    $"""    /// {description.Trim()}
    type {normalizeName name} =
"""
                for pv, name, v, vstr in propertyValues |> processPropertyValues do
                    appendForHelpers
                        $"""        /// {pv.Description.Trim()}
        static member inline {normalizeName name}{vstr} = CombineKeyValue(fun sb -> sb.Append("{property.Name}: ").Append({v}).Append("; "))
    
"""

    else if
        List.contains mainName [
            "color"

            "height"
            "width"
            "max-height"
            "max-width"
            "min-height"
            "min-width"

            "opacity"

            "top"
            "right"
            "bottom"
            "left"

            "gap"
        ]
        |> not
    then
        let propertyValues =
            try
                mainDetail.Tables.``Property Values``.Rows
            with ex ->
                printfn "Retry failed for get property values %A" ex
                [||]

        if propertyValues.Length > 0 then
            appendForHelpers
                $"""/// {mainDescription.Trim()}
type {normalizeName mainName} =
"""
            for pv, name, v, vstr in propertyValues |> processPropertyValues do
                appendForHelpers
                    $"""    /// {pv.Description.Trim()}
    static member inline {normalizeName name}{vstr} = CombineKeyValue(fun sb -> sb.Append("{property.Name}: ").Append({v}).Append("; "))
    
"""
)

let cssBuilderFile = "Fun.Css/CssBuilder.fs"

File.ReadAllLines cssBuilderFile
|> Seq.toList
|> Seq.takeWhile ((<>) "    // Auto generated")
|> (fun ls -> File.WriteAllLines(cssBuilderFile, ls))

File.AppendAllLines(cssBuilderFile, [ "    // Auto generated"; "" ])

File.AppendAllText(cssBuilderFile, autoOpenContent.ToString())


// System.IO.File.WriteAllText("Fun.Css/CssExtensions.fs", manualOpenContent.ToString())
System.IO.File.WriteAllText("Fun.Css/CssHelpers.fs", helpersContent.ToString())
