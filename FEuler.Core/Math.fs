namespace FEuler.Core

[<RequireQualifiedAccess>]
module Math =
    open System

    // Private functions

    let private fibonacciSequenceGenerator (prev1, prev2) = 
        Some (prev1 + prev2, (prev2, prev1 + prev2))

    let private numberToLastDigitConverter =
        Option.bind (fun n -> Some (n % 10, if n < 10 then None else Some (n / 10)))

    let rec private isPalindromeHelper indexStart indexEnd isPalindrome array =
        if indexStart >= indexEnd || isPalindrome = false then 
            isPalindrome
        else
            let valuesAtIndexesAreEqual = Array.item indexStart array = Array.item indexEnd array
            isPalindromeHelper (indexStart + 1) (indexEnd - 1) (isPalindrome && valuesAtIndexesAreEqual) array

    // Public functions

    let floor (number : float) = Math.Floor(number)
    
    let log number newBase = Math.Log(number, newBase)

    let fibonacciSequence =
        seq {
            yield 1
            yield 1
            yield! Seq.unfold fibonacciSequenceGenerator (1,1)
        }

    let convertNumberToSequence number =
        Seq.unfold numberToLastDigitConverter <| Some number
            
    let isSequencePalindrome sequence =
        let array = Seq.toArray sequence
        isPalindromeHelper 0 ((Array.length array) - 1) true array 

    let isNumberPalindrome = convertNumberToSequence >> isSequencePalindrome

    let productBy f =
        Seq.fold (fun product value -> product * (f value )) 1.0