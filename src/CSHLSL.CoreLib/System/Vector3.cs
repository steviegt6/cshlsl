// ReSharper disable InconsistentNaming

namespace System;

/// <summary>
///     A 3-dimensional vector.
/// </summary>
public partial struct Vector3<T> : IVector<T> {
    public extern Vector3(T x, T y, T z);
}
