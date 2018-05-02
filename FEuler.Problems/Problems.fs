namespace FEuler.Problems
open FEuler.Core.Common

[<RequireQualifiedAccess>]
module Problems =
    
    let private problems = 
        [
            { Number = 1 ; Solver = Problem1.solve ; Answer = Some 233168 }
            { Number = 2 ; Solver = Problem2.solve ; Answer = Some 4613732 }
            { Number = 3 ; Solver = Problem3.solve ; Answer = Some 6857 }
            { Number = 4 ; Solver = Problem4.solve ; Answer = Some 906609 }
            { Number = 5 ; Solver = Problem5.solve ; Answer = Some 232792560 }
            { Number = 6 ; Solver = Problem6.solve ; Answer = Some 25164150 }
        ]
        |> Seq.map (fun p -> (string p.Number, p))
        |> Map.ofSeq

    let getProblem problemNumber =
        if problems.ContainsKey problemNumber then Some (problems.Item problemNumber) else None

    let getAllproblems =
        problems |> Seq.map (fun k -> k.Value) 

