namespace System;

/// <summary>
///     A swizzle.
/// </summary>
public interface ISwizzle<in T> { }

/// <summary>
///     A 1-component swizzle.
/// </summary>
public sealed class Swizzle1<T> : ISwizzle<T> {
    public static extern implicit operator Swizzle1<T>(T swizzle);
    
    public static extern implicit operator T(Swizzle1<T> swizzle);

    public static extern implicit operator Swizzle2<T>(Swizzle1<T> swizzle);

    public static extern implicit operator Swizzle3<T>(Swizzle1<T> swizzle);

    public static extern implicit operator Swizzle4<T>(Swizzle1<T> swizzle);
}

/// <summary>
///     A 2-component swizzle.
/// </summary>
public sealed class Swizzle2<T> : ISwizzle<T> {
    public static extern implicit operator Swizzle3<T>(Swizzle2<T> swizzle);

    public static extern implicit operator Swizzle4<T>(Swizzle2<T> swizzle);
}

/// <summary>
///     A 3-component swizzle.
/// </summary>
public sealed class Swizzle3<T> : ISwizzle<T> {
    public static extern implicit operator Swizzle4<T>(Swizzle3<T> swizzle);
}

/// <summary>
///     A 4-component swizzle.
/// </summary>
public sealed class Swizzle4<T> : ISwizzle<T> { }
