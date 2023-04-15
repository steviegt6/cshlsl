namespace System; 

/// <summary>
///     A matrix is a special data type that contains between one and sixteen
///     components. Every component of a matrix must be of the same type.
/// </summary>
public interface IMatrix<T, TRow> where TRow : IMatrixRow<T> {
    // T this[int row, int column] { get; set; }

    ref TRow this[int row] { get; }
}
