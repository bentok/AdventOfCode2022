module Helpers

open System
open System.IO
open System.Reflection

let loadFile (filePath: string) = 
    let assembly =
        Assembly.GetExecutingAssembly()
    
    assembly.GetManifestResourceStream($"AdventOfCode.Input.{filePath}")
    
let streamToText (input: Stream) =
    input
    |> fun input -> new StreamReader(input)
    |> fun reader -> reader.ReadToEnd()
    
let loadInputData =
    streamToText << loadFile

let makeLines (input: string) =
    input.Split(new string (Environment.NewLine))
    
let splitOn (splitter: string) (input: string) =
    input.Split([| splitter |], StringSplitOptions.None)