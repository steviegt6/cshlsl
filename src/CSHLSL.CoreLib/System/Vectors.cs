namespace System;

/// <summary>
///     Indicates that a type is a vector.
///     <br />
///     A vector contains between one and four scalar components; every
///     component of a vector must be of the same type.
/// </summary>
public interface IVector { }

public interface IVector<in T> : IVector { }

/// <summary>
///     A 1-dimensional vector.
/// </summary>
public partial struct Vector1<T> : IVector<T> {
    public extern Vector1(T x);
}

/// <summary>
///     A 2-dimensional vector.
/// </summary>
public partial struct Vector2<T> : IVector<T> {
    public extern Vector2(T x, T y);
}

/// <summary>
///     A 3-dimensional vector.
/// </summary>
public partial struct Vector3<T> : IVector<T> {
    public extern Vector3(T x, T y, T z);
}

/// <summary>
///     A 4-dimensional vector.
/// </summary>
public partial struct Vector4<T> : IVector<T> {
    public extern Vector4(T x, T y, T z, T w);
}
