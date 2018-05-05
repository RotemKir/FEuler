namespace FEuler.Problems
open FEuler.Core.Common

[<RequireQualifiedAccess>]
module Problems =
    
    let private problems = 
        Map.ofSeq <|
        Seq.map (fun p -> (string p.Number, p))
            [
                { Number = 1 ; Solver = Problem1.solve >> int64; Answer = Some 233168L }
                { Number = 2 ; Solver = Problem2.solve >> int64; Answer = Some 4613732L }
                { Number = 3 ; Solver = Problem3.solve >> int64; Answer = Some 6857L }
                { Number = 4 ; Solver = Problem4.solve >> int64; Answer = Some 906609L }
                { Number = 5 ; Solver = Problem5.solve >> int64; Answer = Some 232792560L }
                { Number = 6 ; Solver = Problem6.solve >> int64; Answer = Some 25164150L }
                { Number = 7 ; Solver = Problem7.solve >> int64; Answer = Some 104743L }
                { Number = 8 ; Solver = Problem8.solve ; Answer = Some 23514624000L }
            ]

    let getProblem problemNumber =
        if problems.ContainsKey problemNumber then Some (problems.Item problemNumber) else None

    let getAllproblems =
        problems |> Seq.map (fun k -> k.Value) 

