namespace FEuler.Problems
open FEuler.Core
(* 
A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.

Find the largest palindrome made from the product of two 3-digit numbers.
*)

[<RequireQualifiedAccess>]
module Problem4 =

    // Public functions

    let solve() =
        seq {for i in 100 .. 999 do
                for j in 100 .. 999 do
                    yield i * j}
        |> Seq.filter Math.isNumberPalindrome
        |> Seq.max