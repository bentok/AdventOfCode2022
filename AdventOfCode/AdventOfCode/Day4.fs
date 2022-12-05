module Day4

open Helpers

let expandAssignments (assignments: string[]) =
    [| int assignments.[0] .. int assignments.[1] |]

let pairContains someOrAll (pair: int[][]) =
    pair[0]
    |> someOrAll (fun a -> pair[1] |> Array.contains a)
    || pair[1]
       |> someOrAll (fun a -> pair[0] |> Array.contains a)
       
let solve someOrAll input =
    input
    |> makeLines
    |> Array.map (splitOn ",")
    |> Array.map (Array.map (splitOn "-"))
    |> Array.map (Array.map expandAssignments)
    |> Array.filter (pairContains someOrAll)
    |> Array.length

let part1 (input: string) =
    solve Array.forall input

let part2 (input: string) =
    solve Array.exists input

printfn "Part 1: %d" (part1 (loadInputData "Day4Input.txt"))
printfn "Part 2: %d" (part2 (loadInputData "Day4Input.txt"))
