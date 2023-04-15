namespace System;

// FIXME: Various attributes require strings and we cannot get rid of them as
// the compiler is dependent on them. References to strings are replaced with
// references to objects, which works fine but means their signatures are
// different than .NET's. That's mostly fine, but fixing that one day would be
// kind of neat.

[Obsolete("This class is not supported in CSHLSL; HLSL has no concept of strings.", true)]
public sealed class String { }
