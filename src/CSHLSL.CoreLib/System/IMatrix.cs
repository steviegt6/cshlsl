namespace System; 

/// <summary>
///     A matrix is a special data type that contains between one and sixteen
///     components. Every component of a matrix must be of the same type.
/// </summary>
public interface IMatrix<T> {
    T this[int row, int column] { get; set; }
}
