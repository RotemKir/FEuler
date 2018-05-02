namespace FEuler.Problems
open FEuler.Core
(* 
2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
*)

[<RequireQualifiedAccess>]
module Problem5 =
    open System

    // Private functions

    let private log20AndFloor = Math.floor << Math.log 20.0

    let private getMaxProductForPrime prime =
        prime ** log20AndFloor prime

    // Public functions

    let solve() =
        Primes.primesSequence 20
        |> Seq.map float
        |> Math.productBy getMaxProductForPrime
        |> int