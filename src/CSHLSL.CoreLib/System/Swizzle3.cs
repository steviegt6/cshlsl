namespace System;

/// <summary>
///     A 3-component swizzle.
/// </summary>
public sealed class Swizzle3<T> : ISwizzle<T> {
    public static extern implicit operator Swizzle4<T>(Swizzle3<T> swizzle);
}
