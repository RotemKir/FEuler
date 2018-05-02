namespace FEuler.Problems
open FEuler.Core.Common

[<RequireQualifiedAccess>]
module Problems =
    
    let private problems = 
        [
            ("1", { Solver = Problem1.solve ; Answer = Some 233168 })
            ("2", { Solver = Problem2.solve ; Answer = Some 4613732 })
            ("3", { Solver = Problem3.solve ; Answer = Some 6857 })
            ("4", { Solver = Problem4.solve ; Answer = Some 906609 })
            ("5", { Solver = Problem5.solve ; Answer = Some 232792560 })
        ]
        |> Map.ofList

    let getProblem problemNumber =
        if problems.ContainsKey problemNumber then Some (problems.Item problemNumber) else None


