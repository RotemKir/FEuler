namespace FEuler.Problems
(* 
A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
a^2 + b^2 = c^2

For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.

There exists exactly one Pythagorean triplet for which a + b + c = 1000.
Find the product abc.
*)

[<RequireQualifiedAccess>]
module Problem9 =
    
    // Public functions

    let solve() =
        let (a, b, c) = 
            seq { for a in 1 .. 332 do 
                    for b in a + 1 .. 1000 - 2 * a - 1 do 
                        yield (a, b, 1000 - a - b) }
            |> Seq.find (fun (a, b, c) -> a*a + b*b = c*c)
            
        a * b * c