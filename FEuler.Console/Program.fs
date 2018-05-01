open System
open FEuler.Core
open FEuler.Problems
open FEuler.Core.Common

let private showSolveResult problem timedResult =
    match problem with
    | {Solver = _ ; Answer = None} -> printfn "Answer is %i." timedResult.Result
    | {Solver = _ ; Answer = Some answer} -> 
        printf "Answer %i is " timedResult.Result
        printfn "%s" (if answer = timedResult.Result then "correct" else "incorrect")

    printfn "Ran in %.3f milliseconds" timedResult.Runtime.TotalMilliseconds

let private runSolver problem =
    match problem with
    | None -> printfn "Problem doesn't exist."
    | Some p -> runWithTime p.Solver |> showSolveResult p
    
[<EntryPoint>]
let main _ = 
    printfn "Enter problem number:"
    Console.ReadLine() |> Problems.getProblem |> runSolver

    Console.ReadLine() |> ignore
    
    0 // return an integer exit code
