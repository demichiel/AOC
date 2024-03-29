﻿namespace AOC1

module Domain =
    type Depth = { CurrentDepth: int; Increased: bool }
module Part1 =
    open Domain

    let parse (data: seq<int>) =
        data
        |> Seq.pairwise
        |> Seq.map
            (fun (prev, curr) ->
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
        data |> Seq.windowed 3 |> Seq.map Seq.sum

    let parse (data: seq<int>) =
        data
        |> parseWindowsOfThree
        |> Seq.pairwise
        |> Seq.map
            (fun (prev, curr) ->
                { CurrentDepth = curr
                  Increased = curr > prev })

    let countIncreased (data: seq<Depth>) =
        data
        |> Seq.filter (fun x -> x.Increased)
        |> Seq.length

    let calculateAndPrint data =
        data |> parse |> countIncreased |> printfn "%i"
