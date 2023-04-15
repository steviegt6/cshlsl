namespace System; 

public interface IMatrixRow<T> {
    public T this[int column] { get; set; }
}
