#r "nuget:FSharp.Data"

open System
open System.IO
open FSharp.Data

type CSSProperties = HtmlProvider<"https://www.w3schools.com/cssref/pr_background-blend-mode.php">

type PropertyInfo = { Name: string; Url: string }
type PropertyValue = { Value: string; Description: string }

[<RequireQualifiedAccess>]
type ValueType =
    | String
    | Int
    | Float
    | Tuple of int
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

let getPropertyValues (doc: HtmlDocument) =
    try
        let items = doc.CssSelect("#main") |> Seq.item 0 |> (fun x -> x.Elements())
        let index =
            items
            |> Seq.findIndex (fun x -> x.Name() = "h2" && x.InnerText() = "Property Values" || x.InnerText() = "Filter Functions")
        if index > 0 then
            let ps = items |> Seq.item (index + 1) |> (fun x -> x.CssSelect("table tr"))
            [
                for p in ps do
                    let tds = p.CssSelect("td")
                    if tds.Length > 0 then
                        {
                            Value = tds[0].InnerText()
                            Description = tds[1].InnerText()
                        }
            ]
        else
            []
    with ex ->
        printfn "Get property values failed %A" ex
        []

let normalizeName (name: string) =
    let name = name.Trim()
    let name =
        if name.Contains '-' || name.Contains ' ' then
            let sb = Text.StringBuilder()
            let mutable i = 0
            while i < name.Length do
                if name[i] = '-' || name[i] = ' ' then
                    if i < name.Length - 1 then
                        sb.Append(name[i + 1] |> Char.ToUpper) |> ignore
                        i <- i + 2
                    else
                        i <- i + 1
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

let processPropertyValues (propertyValues: PropertyValue seq) =
    [
        for propertyValue in propertyValues |> Seq.sortBy (fun x -> x.Value) do
            if propertyValue.Value.Contains("cubic-bezier") then
                {|
                    pv = propertyValue
                    name = "cubic-bezier"
                    value = "n1).Append(n2).Append(n3).Append(n4"
                    valueArgs = ", n1: string, n2: string, n3: string, n4: string"
                |}

            else if propertyValue.Value.Contains "(" then
                let value = propertyValue.Value.Substring(0, propertyValue.Value.IndexOf("("))
                {|
                    pv = propertyValue
                    name = value.Trim()
                    value = "$\"" + value + "({value})\""
                    valueArgs = ", value: string"
                |}

            else if propertyValue.Value |> Seq.filter ((=) '%') |> Seq.length = 1 then
                {|
                    pv = propertyValue
                    name = ""
                    value = "string value + \"%\""
                    valueArgs = ", value: float"
                |}

            else if (propertyValue.Value.Split("color") |> Seq.filter ((=) "color") |> Seq.length) = 1 then
                {|
                    pv = propertyValue
                    name = propertyValue.Value
                    value = "color"
                    valueArgs = ", color: string"
                |}

            else if (propertyValue.Value.Split("color") |> Seq.filter ((=) "color") |> Seq.length) = 2 then
                {|
                    pv = propertyValue
                    name = ""
                    value = "color"
                    valueArgs = ", color: string"
                |}

            else if propertyValue.Value = "width" || propertyValue.Value = "height" || propertyValue.Value = "length" then
                {|
                    pv = propertyValue
                    name = propertyValue.Value
                    value = "string value + \"px\""
                    valueArgs = ", value: int"
                |}

            else if propertyValue.Value.Contains "time" || propertyValue.Value.Contains "number" then
                {|
                    pv = propertyValue
                    name = propertyValue.Value
                    value = "value"
                    valueArgs = ", value: float"
                |}

            else if propertyValue.Value.Contains("ListOf") then
                let valueArgs = normalizeName propertyValue.Value
                {|
                    pv = propertyValue
                    name = propertyValue.Value
                    value = valueArgs
                    valueArgs = valueArgs
                |}

            else if propertyValue.Value = "0" then
                ()

            else if propertyValue.Value.Contains("/") then
                let names = propertyValue.Value.Split("/") |> Seq.map normalizeName |> Seq.toList
                let valueArgs = names |> String.concat ": string, "
                let value = names |> String.concat ").Append("
                {|
                    pv = propertyValue
                    name = ""
                    value = value
                    valueArgs = ", " + valueArgs + ": string"
                |}

            else if propertyValue.Value.Contains("|") then
                let values =
                    propertyValue.Value.Split("|") |> Seq.filter (String.IsNullOrEmpty >> not) |> Seq.map (fun x -> x.Trim()) |> Seq.toList

                match values with
                | [ name; "string" ] -> {|
                    pv = propertyValue
                    name = name
                    value = "value"
                    valueArgs = ", value: string"
                  |}
                | _ -> printfn "Unhandled values %s" propertyValue.Value

            else if Seq.contains propertyValue.Value [ "auto"; "initial"; "inherit" ] then
                {|
                    pv = propertyValue
                    name = propertyValue.Value
                    value = "\"" + propertyValue.Value + "\""
                    valueArgs = ""
                |}

            else
                {|
                    pv = propertyValue
                    name = propertyValue.Value.Replace("%", "")
                    value = "defaultArg value \"" + propertyValue.Value + "\""
                    valueArgs = ", ?value: string"
                |}
    ]
    |> Seq.map (fun x -> {| x with name = x.name.Trim() |})
    |> Seq.distinctBy (fun x -> x.name, x.valueArgs)
    |> Seq.toList



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

    appendForAutoOpen
        $"""    /// {mainDescription}
    [<CustomOperation("{normalizeName mainName}")>]
    member inline _.{normalizeName mainName}([<InlineIfLambda>] comb: CombineKeyValue, value: string) = comb &&& CombineKeyValue(fun sb -> sb.Append("{property.Name}: ").Append(value).Append("; "))
"""
    //     if isPxValue then
    //         appendForAutoOpen
    //             $"""    /// {mainDescription}
    //     [<CustomOperation("{normalizeName mainName}")>]
    //     member inline _.{normalizeName mainName}([<InlineIfLambda>] comb: CombineKeyValue, value: int) = comb &&& CombineKeyValue(fun sb -> sb.Append("{property.Name}: ").Append(value).Append("px; "))
    // """

    let mutable addedSubPropertyNames = Collections.Generic.List<string>()
    if autoOpenSubProperties.ContainsKey property.Name && autoOpenSubProperties[property.Name].Count > 0 then
        for property in autoOpenSubProperties[property.Name] |> Seq.sortBy (fun x -> x.Name) do
            printfn "%A" property.Name
            let subName = property.Name.Substring(mainName.Length + 1)
            let subDetail = loadDetail false property.Url
            let propertyValues = getPropertyValues subDetail.Html

            if propertyValues.Length > 0 then
                for pv in propertyValues |> processPropertyValues do
                    addedSubPropertyNames.Add pv.pv.Value
                    let name = mainName + "-" + subName + "-" + pv.name |> normalizeName
                    appendForAutoOpen
                        $"""    /// {pv.pv.Description.Trim()}
    [<CustomOperation("{name}")>]
    member inline _.{name}([<InlineIfLambda>] comb: CombineKeyValue{pv.valueArgs}) = comb &&& CombineKeyValue(fun sb -> sb.Append("{property.Name}: ").Append({pv.value}).Append("; "))
"""

    let mainPropertyValues = getPropertyValues mainDetail.Html
    if mainPropertyValues.Length > 0 then
        let description = getDescription mainDetail.Html
        for pv in mainPropertyValues |> processPropertyValues do
            if addedSubPropertyNames.Contains pv.pv.Value |> not then
                let name = mainName + "-" + pv.name |> normalizeName
                appendForAutoOpen
                    $"""    /// {description.Trim()}
    [<CustomOperation("{name}")>]
    member inline _.{name}([<InlineIfLambda>] comb: CombineKeyValue{pv.valueArgs}) = comb &&& CombineKeyValue(fun sb -> sb.Append("{property.Name}: ").Append({pv.value}).Append("; "))
"""
)

let cssBuilderFile = "Fun.Css/CssBuilder.fs"

File.ReadAllLines cssBuilderFile
|> Seq.toList
|> Seq.takeWhile ((<>) "    // Auto generated")
|> (fun ls -> File.WriteAllLines(cssBuilderFile, ls))

File.AppendAllLines(cssBuilderFile, [ "    // Auto generated"; "" ])

File.AppendAllText(cssBuilderFile, autoOpenContent.ToString())
