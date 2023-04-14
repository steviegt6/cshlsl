namespace System;

/// <summary>
///     A 2-component swizzle.
/// </summary>
public sealed class Swizzle2<T> : ISwizzle<T> {
    public static extern implicit operator Swizzle3<T>(Swizzle2<T> swizzle);
    
    public static extern implicit operator Swizzle4<T>(Swizzle2<T> swizzle);
}
