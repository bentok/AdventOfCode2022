module Helpers

open System.IO
open System.Reflection

let loadFile (filePath: string) = 
    let assembly =
        Assembly.GetExecutingAssembly()
    
    assembly.GetManifestResourceStream($"{filePath}")
    
let streamToText (input: Stream) =
    input
    |> fun input -> new StreamReader(input)
    |> fun reader -> reader.ReadToEnd()
    
let loadInputData =
    streamToText << loadFile