open System
open System.IO
open AOC3
open FileHelper

[<EntryPoint>]
let main _ =
    let path =
        Path.Combine(__SOURCE_DIRECTORY__, "input.txt")
    let data = FileHelper.readFile path
    
    let parsed = Part1.parse data
    
    let gammaRateBinary = Part1.getGammaRateInBinary parsed
    let gammaRate = Convert.ToInt64 (gammaRateBinary, 2)
    
    printfn $"Gamma rate in binary: {gammaRateBinary}"
    printfn $"Gamma rate: {gammaRate}"
    
    let epsilonRateBinary = Part1.getEpsilonRateInBinary parsed
    let epsilonRate = Convert.ToInt64 (epsilonRateBinary, 2)
    
    printfn $"Epsilon rate in binary: {epsilonRateBinary}"
    printfn $"Epsilon rate: {epsilonRate}"
    
    printfn $"{gammaRate} * {epsilonRate} = {gammaRate * epsilonRate}"
    
    0
