
### ArrayParam

[![Build status](https://ci.appveyor.com/api/projects/status/kjijdhhjnuyl2mkl/branch/master?svg=true)](https://ci.appveyor.com/project/wearetherock/fsharp-param/branch/master)

### Build

```./build.sh```

### F#

```fsharp
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
```


### C#

```csharp
using <StartupCode$lib>;
using Microsoft.FSharp.Core;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: AssemblyVersion("0.0.0.0")]
[assembly: FSharpInterfaceDataVersion(2, 0, 0)]
[CompilationMapping(SourceConstructFlags.Module)]
public static class Param
{
	[CompilationMapping(SourceConstructFlags.Module)]
	public static class Test
	{
		[CompilationMapping(SourceConstructFlags.Value)]
		internal static string x@1
		{
			get
			{
				return $Param$fsx.x@1;
			}
		}
	}

	[CompilationMapping(SourceConstructFlags.Module)]
	public static class B
	{
		[CompilationMapping(SourceConstructFlags.ObjectType)]
		[Serializable]
		public class T
		{
			public T() : this()
			{
			}

			public static string Link(params string[] p)
			{
				return string.Join(",", p);
			}
		}
	}

	[CompilationMapping(SourceConstructFlags.Module)]
	public static class A
	{
		public static string link(params string[] p)
		{
			return string.Join(",", p);
		}
	}
}
namespace <StartupCode$lib>
{
	internal static class $Param$fsx
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal static readonly string x@1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never), DebuggerNonUserCode, CompilerGenerated]
		internal static int init@;

		static $Param$fsx()
		{
			$Param$fsx.x@1 = string.Join(",", new string[]
			{
				"a",
				"b",
				"c"
			});
		}
	}
}
```