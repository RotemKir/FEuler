namespace FEuler.Problems

(* 
If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
Find the sum of all the multiples of 3 or 5 below 1000.
*)

[<RequireQualifiedAccess>]
module Problem1 =

    // Public functions

    let solve() =
        seq {1..999}  
        |> Seq.filter (fun n -> n % 3 = 0 || n % 5 = 0) 
        |> Seq.sum
