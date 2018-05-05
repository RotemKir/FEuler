namespace FEuler.Core
open System

module Common =
    open System.Collections.Generic

    // Types
    
    type TimedResult<'a> = 
        {
            Runtime : TimeSpan
            Result : 'a
        }

    type Solver = unit -> int64

    type Problem =
        {
            Number : int
            Solver : Solver
            Answer : int64 option 
        }

    // Public functions

    let runWithTime action =
        let startTime = DateTime.Now
        let result = action()
        let endTime = DateTime.Now
        
        {
            Runtime = endTime - startTime 
            Result = result
        }

    let memoize f =
        let cache = new Dictionary<_,_>()
        fun n -> 
            match cache.TryGetValue(n) with
            | true, v -> v
            | _ -> 
                let temp = f n
                cache.Add(n, temp)
                temp

    let digitCharToLong (c : char) =
        Int64.Parse(string c)