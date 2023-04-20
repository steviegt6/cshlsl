using System.Casting;

namespace System;

// TODO: Define minimum-precision scalar data types.
// TODO: snorm/unorm scalar data types.
/// <summary>
///     Indicates that the type is a scalar.
///     <br />
///     One-component scalar.
/// </summary>
public interface IScalar { }

public interface IScalar<in T> { }

/// <summary>
///     <see langword="true"/> or <see langword="false"/>.
/// </summary>
public struct Boolean : IScalar<bool>, IFloatCastable { }

/// <summary>
///     32-bit signed integer.
/// </summary>
public struct Int32 : IScalar<int>, IFloatCastable { }

/// <summary>
///     32-bit unsigned integer.
/// </summary>
public struct UInt32 : IScalar<uint>, IFloatCastable { }

/// <summary>
///     16-bit floating point value. This data type is provided only for
///     language compatibility. Direct3D 10 shader targets maps all half data
///     types to float data types. A half data type cannot be used on a uniform
///     global value.
/// </summary>
public struct Half : IScalar<Half>, IFloatCastable { }

/// <summary>
///     32-bit floating point value.
/// </summary>
public struct Single : IScalar<float>, IFloatCastable { }

// TODO: These docs describe functions for shader models past 3... yawn.
/// <summary>
///     64-bit floating point value. You cannot use double precision values as
///     inputs and outputs for a stream. To pass double precision values between
///     shaders, declare each <see cref="double"/> as a pair of
///     <see cref="uint"/> data types. Then, use the asuint function to pack
///     each <see cref="double"/> into the pair of <see cref="uint"/>s and the
///     asdouble function to unpack the pair of <see cref="uint"/>s back into
///     the <see cref="double"/>.
/// </summary>
public struct Double : IScalar<double>, IFloatCastable { }

/// <summary>
///     In HLSL, a <see cref="string"/> is actually just an ASCII
///     <see cref="string"/>. There are no operations or states that accept
///     strings, but effects can query <see cref="string"/> parameters and
///     annotations.
/// </summary>
public sealed class String : IScalar<string> { }
