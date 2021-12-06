namespace AOC3

module Part1 =
    let charToInt c = int c - int '0'

    let toIntArray (chars: char list) = chars |> List.map charToInt

    let mapToIntList (data: seq<string>) =
        data |> Seq.map Seq.toList |> Seq.map toIntArray


    let mapTo2DArray (numbers: seq<int list>) = array2D numbers

    let parse (data: seq<string>) = data |> mapToIntList |> mapTo2DArray
    
    let mostCommonItem list =
        list
        |> Seq.countBy id
        |> Seq.maxBy snd
        |> fst

    
    let leastCommonItem list =
        list
        |> Seq.countBy id
        |> Seq.minBy snd
        |> fst
    
    let getGammaRateInBinary (data: int[,]) =
        seq {for columnIndex = 0 to data.GetLength(1) - 1 do
                let column = data[*, columnIndex]
                yield mostCommonItem column
        }
        |> Seq.map string
        |> String.concat ""
    
    let getEpsilonRateInBinary (data: int[,]) =
        seq {for columnIndex = 0 to data.GetLength(1) - 1 do
                let column = data[*, columnIndex]
                yield leastCommonItem column
        }
        |> Seq.map string
        |> String.concat ""
               
            
