module Day1

open System
open System.IO
open System.Reflection

let assembly =
    Assembly.GetExecutingAssembly()

let stream =
    assembly.GetManifestResourceStream("AdventOfCode.Day1Input.txt")
    
let streamToText (input: Stream) =
    input
    |> fun input -> new StreamReader(input)
    |> fun reader -> reader.ReadToEnd()

let calcMostCalories (text: string) =
    text
    |> fun str -> str.Split(new string (Environment.NewLine))
    |> Array.toList
    |> fun snacks -> ([ [] ], snacks)
    ||> List.fold (fun acc current ->
        match current with
        | snack when snack = "" -> (acc @ [ [] ])
        | snack ->
            acc
            |> List.rev
            |> fun a ->
                let head = a |> List.head
                let tail = a |> List.tail
                [ (head |> List.append [ snack ]) ] @ tail
            |> List.rev)
    |> List.map (List.map int)
    |> List.map List.sum
    |> List.max

stream
|> streamToText
|> calcMostCalories
|> printfn "%d"