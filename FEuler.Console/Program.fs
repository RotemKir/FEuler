open System
open FEuler.Core
open FEuler.Problems
open FEuler.Core.Common

let private showSolveResult problem timedResult =
    printf "Problem %i: " problem.Number 
    
    match problem with
    | {Solver = _ ; Answer = None} -> printfn "Answer is %i." timedResult.Result
    | {Solver = _ ; Answer = Some answer} -> 
        printf "Answer %i is " timedResult.Result
        printf "%s" (if answer = timedResult.Result then "correct" else "incorrect")

    printfn " (%.3f ms)" timedResult.Runtime.TotalMilliseconds

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
