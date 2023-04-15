// ReSharper disable InconsistentNaming

namespace System;

/// <summary>
///     A 4-dimensional vector.
/// </summary>
public partial struct Vector4<T> : IVector<T> {
    public extern Vector4(T x, T y, T z, T w);
}
