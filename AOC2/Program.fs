open System.IO
open AOC2

[<EntryPoint>]
let main argv =
    let path =
        Path.Combine(__SOURCE_DIRECTORY__, "input.txt")

    let origin: Domain.Position = { X = 0; Y = 0 }

    let data = FileHelper.readFile path

    let result =
        data
        |> Part1.parseToCommands
        |> Seq.fold (fun acc c -> Part1.doCommand c acc) origin

    printfn $"Result part 1: {result.X * result.Y}"

    let origin2: Domain.PositionWithAim = { X = 0; Y = 0; Aim = 0 }

    let result2 =
        data
        |> Part2.parseToCommands
        |> Seq.fold (fun acc c -> Part2.doCommand c acc) origin2

    printfn $"Result part 2: {result2.X * result2.Y}"
    0
