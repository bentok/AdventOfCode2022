module Tests

open System
open System.IO
open System.Reflection
open Xunit
open FsUnit
open Day1

[<Fact>]
let ``Day 1 test data`` () =
    let assembly =
        Assembly.GetExecutingAssembly()

    let stream =
        assembly.GetManifestResourceStream("AdventOfCodeTests.Day1TestInput.txt")
        
    let expected = 45000
    let result = calcMostCalories (streamToText stream)
    
    printfn "%A" (streamToText stream)
    
    result |> should equal expected