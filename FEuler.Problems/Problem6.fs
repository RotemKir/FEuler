namespace FEuler.Problems
open FEuler.Core
(* 
The sum of the squares of the first ten natural numbers is,
1^2 + 2^2 + ... + 10^2 = 385

The square of the sum of the first ten natural numbers is,
(1 + 2 + ... + 10)^2 = 552 = 3025

Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.

Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
*)

[<RequireQualifiedAccess>]
module Problem6 =

    // Public functions

    let solve() =
        let squareOfSum = (float <| Math.arithmeticSeriesSum 1 100 100) ** 2.0 |> int
        let sumOfSquares = [1..100] |> Seq.sumBy (fun n -> n * n)
        squareOfSum - sumOfSquares