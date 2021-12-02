namespace AOC2

open System.IO
open FSharpx.Text.Strings

module Domain =
    type Position = { X: int; Y: int }
    type PositionWithAim = { X: int; Y: int; Aim: int }

    type Direction =
        | Up
        | Down
        | Forward
        | Backward
        | Nothing

    type Command = { Direction: Direction; Distance: int }

open Domain

module FileHelper =
    let readFile path =
        seq {
            use reader = new StreamReader(File.OpenRead(path))

            while not reader.EndOfStream do
                reader.ReadLine()
        }

module Part1 =
    let parseToCommand (data: string * int) =
        match data with
        | "up", distance -> { Direction = Up; Distance = distance }
        | "down", distance ->
            { Direction = Down
              Distance = distance }
        | "forward", distance ->
            { Direction = Forward
              Distance = distance }
        | "backward", distance ->
            { Direction = Backward
              Distance = distance }
        | _, _ -> { Direction = Nothing; Distance = 0 }


    let parse (data: seq<string>) =
        data
        |> Seq.map toWords
        |> Seq.map Seq.toList
        |> Seq.map (fun x -> (x.Item 0, x.Item 1 |> int))
        |> Seq.map parseToCommand

    let printPosition (position: Position) =
        printfn $"{position}"
        position

    let doCommand command position =
        printPosition position |> ignore

        match command.Direction with
        | Up ->
            { position with
                  Y = position.Y - command.Distance }
        | Down ->
            { position with
                  Y = position.Y + command.Distance }
        | Forward ->
            { position with
                  X = position.X + command.Distance }
        | Backward ->
            { position with
                  X = position.X - command.Distance }
        | Nothing -> position




module Part2 =
    let parseToCommand (data: string * int) =
        match data with
        | "up", distance -> { Direction = Up; Distance = distance }
        | "down", distance ->
            { Direction = Down
              Distance = distance }
        | "forward", distance ->
            { Direction = Forward
              Distance = distance }
        | "backward", distance ->
            { Direction = Backward
              Distance = distance }
        | _, _ -> { Direction = Nothing; Distance = 0 }


    let parse (data: seq<string>) =
        data
        |> Seq.map toWords
        |> Seq.map Seq.toList
        |> Seq.map (fun x -> (x.Item 0, x.Item 1 |> int))
        |> Seq.map parseToCommand

    let printPosition (position: PositionWithAim) =
        printfn $"{position}"
        position

    let doCommand command position =
        printPosition position |> ignore

        match command.Direction with
        | Up ->
            { position with
                  Aim = position.Aim - command.Distance }
        | Down ->
            { position with
                  Aim = position.Aim + command.Distance }
        | Forward ->
            { position with
                  X = position.X + command.Distance
                  Y = position.Y + (position.Aim * command.Distance) }
        | Backward -> position
        | Nothing -> position
