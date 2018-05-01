namespace FEuler.Core

[<RequireQualifiedAccess>]
module Primes =

    // Private functions

    let private markSieve sieve index =
       let indexSquared = index * index
       Array.set sieve indexSquared false

       Seq.unfold (fun value ->
            if (value + index < sieve.Length) 
            then Some (value + index, value + index) 
            else None) 
        indexSquared
       |> Seq.iter (fun i -> Array.set sieve i false)

    // Public functions

    let primesSequence limit =
        let sieve = Array.create (limit + 1) true
        Array.fill sieve 0 2 false
        let limitRoot = float limit |> sqrt |> int
        
        [2..limitRoot]
        |> Seq.iter (fun i -> if sieve.[i] = true then markSieve sieve i)

        seq { for i in 1..limit do if sieve.[i] = true then yield i}