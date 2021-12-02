open System
open System.IO

module Domain =
    type Depth = { CurrentDepth: int; Increased: bool }

module FileHelper =
    let readFile path =
        seq {
            use reader = new StreamReader(File.OpenRead(path))

            while not reader.EndOfStream do
                reader.ReadLine() |> int
        }

module Part1 =
    open Domain

    let parse (data: seq<int>) =
        data
        |> Seq.pairwise
        |> Seq.map (fun (prev, curr) ->
            { CurrentDepth = curr
              Increased = curr > prev })

    let countIncreased (data: seq<Depth>) =
        data
        |> Seq.filter (fun x -> x.Increased)
        |> Seq.length

    let calculateAndPrint data =
        data |> parse |> countIncreased |> printfn "%i"

module Part2 =
    open Domain

    let parseWindowsOfThree (data: seq<int>) =
        data
        |> Seq.windowed 3
        |> Seq.map (fun x -> Seq.sum x)

    let parse (data: seq<int>) =
        data
        |> parseWindowsOfThree
        |> Seq.pairwise
        |> Seq.map (fun (prev, curr) ->
            { CurrentDepth = curr
              Increased = curr > prev })

    let countIncreased (data: seq<Depth>) =
        data
        |> Seq.filter (fun x -> x.Increased)
        |> Seq.length

    let calculateAndPrint data =
        data |> parse |> countIncreased |> printfn "%i"


[<EntryPoint>]
let main argv =
    let path =
        Path.Combine(__SOURCE_DIRECTORY__, "input.txt")

    let data = FileHelper.readFile path

    printfn "Part 1: "
    Part1.calculateAndPrint data

    printfn "Part 2: "
    Part2.calculateAndPrint data
    0
