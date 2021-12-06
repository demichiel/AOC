open System.IO
open AOC1
open FileHelper

[<EntryPoint>]
let main _ =
    let path =
        Path.Combine(__SOURCE_DIRECTORY__, "input.txt")
        
    let data = FileHelper.readFile path |> Seq.map int

    printfn "Part 1: "
    Part1.calculateAndPrint data

    printfn "Part 2: "
    Part2.calculateAndPrint data
    0
