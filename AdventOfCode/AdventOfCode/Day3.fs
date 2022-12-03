module Day3

open System
open Helpers

let priority (letter: string) =
    let alphabet = "abcdefghijklmnopqrstuvwxyz"
    $"{alphabet}{alphabet.ToUpperInvariant()}".IndexOf(letter) + 1
    
let makeCompartments rucksack =
    rucksack
    |> List.splitAt (rucksack.Length / 2)

let compartmentsToSet (x, y) =
    x |> Set.ofList, y |> Set.ofList

let getContents (x, y) =
    Set.intersect x y

let part1 (input: string) =
    input
    |> makeLines
    |> Array.toList
    |> List.map Seq.toList
    |> List.map makeCompartments
    |> List.map compartmentsToSet
    |> List.map getContents
    |> List.map Set.maxElement
    |> List.map string
    |> List.map priority
    |> List.sum
    
printfn "Part 1: %d" (part1 (loadInputData "Day3Input.txt"))
