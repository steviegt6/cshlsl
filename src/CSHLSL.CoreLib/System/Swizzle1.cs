namespace System;

/// <summary>
///     A 1-component swizzle.
/// </summary>
public sealed class Swizzle1<T> : ISwizzle<T> {
    public static extern implicit operator T(Swizzle1<T> swizzle);

    public static extern implicit operator Swizzle2<T>(Swizzle1<T> swizzle);

    public static extern implicit operator Swizzle3<T>(Swizzle1<T> swizzle);

    public static extern implicit operator Swizzle4<T>(Swizzle1<T> swizzle);
}
