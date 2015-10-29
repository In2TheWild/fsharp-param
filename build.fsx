
#I "packages/FAKE/tools/"
#r "packages/FAKE/tools/FakeLib.dll"

open Fake.FscHelper
open Fake
open Fake.FileHelper
open Fake.CscHelper

CreateDir "release"
"packages/FAKE/tools/FSharp.Core.dll" |> CopyFile "release/FSharp.Core.dll"

Target "cc" (fun _ ->
        ["src/cs/Program.cs"]
        |> Csc(fun p ->
            { p with
                Output = "release/program.exe"
                //OtherParams = ["/reference:release/lib.dll"]
                Target = CscTarget.Exe })
)

Target "cf" (fun _ ->
        ["src/Param.fsx"]
        |> Fsc( fun p ->
            { p with
                Output = "release/lib.dll"
                FscTarget = FscTarget.Library} )
    )

RunTargetOrDefault fsi.CommandLineArgs.[1]

(*
[<EntryPoint>]
let go args =
    RunTargetOrDefault args.[1]
    0
*)