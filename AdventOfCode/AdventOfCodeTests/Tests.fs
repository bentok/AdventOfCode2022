module Tests
open Helpers

open System
open System.IO
open System.Reflection
open Xunit
open FsUnit
open Day1
open Day2

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

[<Fact>]
let ``Day 2 part 1`` () =

    let data =
        loadInputData "Day2TestInput.txt"
        
    let result = part1 data
    let expected = 15
        
    result |> should equal expected