namespace System;

// MatrixRxC classes are entirely generated with a source generator, not
// explicitly defined.

/// <summary>
///     A matrix is a special data type that contains between one and sixteen
///     components. Every component of a matrix must be of the same type.
/// </summary>
public interface IMatrix { }

public interface IMatrix<in T> : IMatrix { }

public interface IMatrixRow<T> {
    public T this[int column] { get; set; }
}
