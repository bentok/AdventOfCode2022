module Day2

open System
open Helpers

type Play = | Rock | Paper | Scissors

type CheaterPlay = | ThrowMatch | DrawMatch | WinMatch

let stringToPlay str =
    match str with
    | "A" | "X" -> Rock
    | "B" | "Y" -> Paper
    | _ -> Scissors
    
let playerChoice str =
    match str with
    | "A" -> Rock
    | "B" -> Paper
    | _ -> Scissors

let cheaterChoice str =
    match str with
    | "X" -> ThrowMatch
    | "Y" -> DrawMatch
    | _ -> WinMatch
    
let (|Win|Lose|Draw|) play =
    match play with
    | [Rock; Paper] | [Paper; Scissors] | [Scissors; Rock] -> Win
    | [Paper; Rock] | [Scissors; Paper] | [Rock; Scissors] -> Lose
    | _ -> Draw
    
let score play result =
    [
        match play with
        | Rock -> 1
        | Paper -> 2
        | Scissors -> 3
        
        match result with
        | Win -> 6
        | Draw -> 3
        | Lose -> 0
    ]

let choosePlay (opponentChoice, strategy) =
    match strategy with
    | WinMatch  ->
        match opponentChoice with
        | Rock -> [Rock; Paper]
        | Paper -> [Paper; Scissors]
        | Scissors -> [Scissors; Rock]
    | DrawMatch ->
        match opponentChoice with
        | Rock -> [Rock; Rock]
        | Paper -> [Paper; Paper]
        | Scissors -> [Scissors; Scissors]
    | ThrowMatch ->
        match opponentChoice with
        | Rock -> [Rock; Scissors]
        | Paper -> [Paper; Rock]
        | Scissors -> [Scissors; Paper]

let makePairs (text: string) =
    text
    |> fun str -> str.Split(new string (Environment.NewLine))
    |> Array.toList
    |> List.map (fun str -> str.Split(' ') |> Array.toList)
    
let play (rounds: string) =
    rounds
    |> makePairs
    |> List.map (fun pair -> pair |> List.map stringToPlay)
    |> List.map (fun pair -> (pair[1], pair) ||> score)
    
let play' (rounds: string) =
    rounds
    |> makePairs
    |> List.map (fun pair -> (playerChoice pair.[0], cheaterChoice pair.[1]))
    |> List.map choosePlay
    |> List.map (fun pair -> (pair[1], pair) ||> score)
    
let part1 (rounds: string) =
    play rounds
    |> List.sumBy (fun scores -> scores |> List.sum)
    
let part2 (rounds: string) =
    play' rounds
    |> List.sumBy (fun scores -> scores |> List.sum)
    
printfn "Part 1: %d" (part1 (loadInputData "Day2Input.txt"))
printfn "Part 2: %d" (part2 (loadInputData "Day2Input.txt"))