namespace FEuler.Problems
open FEuler.Core
(* 
The sum of the squares of the first ten natural numbers is,
1^2 + 2^2 + ... + 10^2 = 385

By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

What is the 10,001st prime number?
*)

[<RequireQualifiedAccess>]
module Problem7 =

    // Public functions

    let solve() =
        Seq.initInfinite (fun i -> 10.0 ** float i |> int)
        |> Seq.skipWhile (fun i -> i <= 10000)
        |> Seq.map Primes.primesSequence
        |> Seq.find (fun primes -> Seq.length primes >= 10001)
        |> Seq.item 10000