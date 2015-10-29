
module A =
    open System
    let link ([<ParamArray>]p: string array) = String.Join(",", p)

module B =
    open System
    type T() =
        static member Link([<ParamArray>] p: string array) = String.Join(",", p)

module Test =
    open B
    T.Link("a", "b", "c") |> ignore