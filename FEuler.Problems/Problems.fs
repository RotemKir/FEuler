namespace FEuler.Problems
open FEuler.Core.Common

[<RequireQualifiedAccess>]
module Problems =
    
    let private problems = 
        Map.ofSeq <|
        Seq.map (fun p -> (string p.Number, p))
            [
                { Number = 1 ; Solver = Problems1To10.solve1 >> int64; Answer = Some 233168L }
                { Number = 2 ; Solver = Problems1To10.solve2 >> int64; Answer = Some 4613732L }
                { Number = 3 ; Solver = Problems1To10.solve3 >> int64; Answer = Some 6857L }
                { Number = 4 ; Solver = Problems1To10.solve4 >> int64; Answer = Some 906609L }
                { Number = 5 ; Solver = Problems1To10.solve5; Answer = Some 232792560L }
                { Number = 6 ; Solver = Problems1To10.solve6 >> int64; Answer = Some 25164150L }
                { Number = 7 ; Solver = Problems1To10.solve7 >> int64; Answer = Some 104743L }
                { Number = 8 ; Solver = Problems1To10.solve8 ; Answer = Some 23514624000L }
                { Number = 9 ; Solver = Problems1To10.solve9 >> int64; Answer = Some 31875000L }
                { Number = 10 ; Solver = Problems1To10.solve10 ; Answer = Some 142913828922L }
                { Number = 11 ; Solver = Problems11To20.solve11 >> int64; Answer = Some 70600674L }
            ]

    let getProblem problemNumber =
        if problems.ContainsKey problemNumber then Some (problems.Item problemNumber) else None

    let getAllproblems =
        problems 
        |> Seq.sortBy (fun k -> k.Value.Number)
        |> Seq.map (fun k -> k.Value) 

