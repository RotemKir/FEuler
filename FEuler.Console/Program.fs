open System
open FEuler.Problems
open FEuler.Core.Common

let private showSolveResult problem timedResult =
    printf "Problem %i: " problem.Number 
    
    match problem with
    | {Solver = _ ; Answer = None} -> 
        Console.ForegroundColor <- ConsoleColor.Yellow
        printf "Answer is %i." timedResult.Result
    | {Solver = _ ; Answer = Some answer} -> 
        if answer = timedResult.Result then
            Console.ForegroundColor <- ConsoleColor.Green
            printf "Answer %i is correct" timedResult.Result
        else
            Console.ForegroundColor <- ConsoleColor.Red
            printf "Answer %i is incorrect, should be %i" timedResult.Result answer

    printfn " (%.3f ms)" timedResult.Runtime.TotalMilliseconds
    Console.ResetColor()

let private runSolver problem =
    match problem with
    | None -> printfn "Problem doesn't exist."
    | Some p -> runWithTime p.Solver |> showSolveResult p
    
[<EntryPoint>]
let main _ = 
    printfn "Enter problem number:"
    let problemNumber = Console.ReadLine()
    
    match problemNumber with
    | "" -> Problems.getAllproblems |> Seq.iter (fun p -> Some p |> runSolver)
    | _ -> Problems.getProblem problemNumber |> runSolver

    Console.ReadLine() |> ignore
    
    0 // return an integer exit code
