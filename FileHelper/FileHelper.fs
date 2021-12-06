namespace FileHelper

open System.IO

module FileHelper =
    let readFile path =
        seq {
            use reader = new StreamReader(File.OpenRead(path))

            while not reader.EndOfStream do
                reader.ReadLine()
        }