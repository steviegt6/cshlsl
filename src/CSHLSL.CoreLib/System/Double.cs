namespace System;

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
public struct Double : IScalar { }
