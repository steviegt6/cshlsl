using System.Casting;
using System.Compatibility;

namespace System;

/// <summary>
///     Intrinsic functions built into HLSL.
/// </summary>
public static class IntrinsicFunctions {
#region Sqrt
    /// <summary>
    ///     Returns the square root of the specified floating-point value, per
    ///     component.
    /// </summary>
    /// <param name="x">The specified floating-point value.</param>
    [HlslMinimumVersion(1, 1)]
    public static extern T Sqrt<T>(IScalar<T> x) where T : IFloatCastable;

    /// <summary>
    ///     Returns the square root of the specified floating-point value, per
    ///     component.
    /// </summary>
    /// <param name="x">The specified floating-point value.</param>
    [HlslMinimumVersion(1, 1)]
    public static extern T Sqrt<T>(IVector<T> x) where T : IFloatCastable;

    /// <summary>
    ///     Returns the square root of the specified floating-point value, per
    ///     component.
    /// </summary>
    /// <param name="x">The specified floating-point value.</param>
    [HlslMinimumVersion(1, 1)]
    public static extern T Sqrt<T>(IMatrix<T> x) where T : IFloatCastable;
#endregion

#region Determinant
    /*/// <summary>
    ///     Returns the determinant of the specified floating-point, square
    ///     matrix.
    /// </summary>
    /// <param name="m">The specified value.</param>
    [HlslMinimumVersion(1, 1)]
    public static extern float Determinant<T>(IMatrix<T> m) where T : IFloatCastable;*/

    // Not the cleanest possible solution, but here's reliable compile-time
    // checking for square-only matrices.

    /// <summary>
    ///     Returns the determinant of the specified floating-point, square
    ///     matrix.
    /// </summary>
    /// <param name="m">The specified value.</param>
    [HlslMinimumVersion(1, 1)]
    public static extern float Determinant<T>(Matrix1x1<T> m) where T : IFloatCastable;

    /// <summary>
    ///     Returns the determinant of the specified floating-point, square
    ///     matrix.
    /// </summary>
    /// <param name="m">The specified value.</param>
    [HlslMinimumVersion(1, 1)]
    public static extern float Determinant<T>(Matrix2x2<T> m) where T : IFloatCastable;

    /// <summary>
    ///     Returns the determinant of the specified floating-point, square
    ///     matrix.
    /// </summary>
    /// <param name="m">The specified value.</param>
    [HlslMinimumVersion(1, 1)]
    public static extern float Determinant<T>(Matrix3x3<T> m) where T : IFloatCastable;

    /// <summary>
    ///     Returns the determinant of the specified floating-point, square
    ///     matrix.
    /// </summary>
    /// <param name="m">The specified value.</param>
    [HlslMinimumVersion(1, 1)]
    public static extern float Determinant<T>(Matrix4x4<T> m) where T : IFloatCastable;
#endregion

#region Length
    /// <summary>
    ///     Returns the length of the specified floating-point vector.
    /// </summary>
    /// <param name="x">The specified floating-point vector.</param>
    [HlslMinimumVersion(1, 1)]
    public static extern float Length<T>(IVector<T> x) where T : IFloatCastable;
#endregion
}
