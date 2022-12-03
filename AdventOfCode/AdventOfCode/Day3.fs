module Day3

open System
open Helpers

let priority (letter: string) =
    let alphabet = "abcdefghijklmnopqrstuvwxyz"

    $"{alphabet}{alphabet.ToUpperInvariant()}".IndexOf(letter)
    + 1

let makeCompartments rucksack =
    rucksack |> List.splitAt (rucksack.Length / 2)

let compartmentsToSet (x, y) = x |> Set.ofList, y |> Set.ofList

let getContents (x, y) = Set.intersect x y

let getGroupContents (group: Set<char> list) =
    let firstIntersect =
        Set.intersect group[0] group[1]

    Set.intersect firstIntersect group.[2]

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

let part2 (input: string) =
    input
    |> makeLines
    |> Array.toList
    |> List.map Seq.toList
    |> List.chunkBySize 3
    |> List.map (List.map Set.ofList)
    |> List.map getGroupContents
    |> List.map Set.maxElement
    |> List.map string
    |> List.map priority
    |> List.sum

printfn "Part 1: %d" (part1 (loadInputData "Day3Input.txt"))
printfn "Part 2: %d" (part2 (loadInputData "Day3Input.txt"))
