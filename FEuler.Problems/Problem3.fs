namespace FEuler.Problems
open FEuler.Core
(* 
The prime factors of 13195 are 5, 7, 13 and 29.

What is the largest prime factor of the number 600851475143 ?
*)

[<RequireQualifiedAccess>]
module Problem3 =

    // Public functions

    let solve() =
        600851475143.0
        |> sqrt         
        |> int
        |> Primes.primesSequence
        |> Seq.findBack (fun n -> 600851475143L % (int64 n) = 0L)