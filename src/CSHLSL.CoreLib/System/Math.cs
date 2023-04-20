namespace System; 

public static class Math {
#region Sqrt
    public static extern T SqrtScalar<T>(T value) where T : IScalar;

    public static extern T SqrtVector<T>(T value) where T : IVector;
    
    public static extern T SqrtMatrix<T>(T value) where T : IMatrix;
#endregion

#region Determinant
    // TODO: Restrict to floating-point types.
    public static extern float Determinant<T>(T value) where T : IMatrix;
#endregion
}
