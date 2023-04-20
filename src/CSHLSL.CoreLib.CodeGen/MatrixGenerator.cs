using System.Text;
using Microsoft.CodeAnalysis;

namespace CSHLSL.CoreLib.CodeGen;

[Generator]
public sealed class MatrixGenerator : ISourceGenerator {
    private const string namespace_name = "System";
    private const string matrix_name = "Matrix";
    private const int matrix_row_count = 4;
    private const int matrix_column_count = 4;

    void ISourceGenerator.Initialize(GeneratorInitializationContext context) { }

    void ISourceGenerator.Execute(GeneratorExecutionContext context) {
        for (var column = 0; column < matrix_column_count; column++) {
            var name = $"{matrix_name}Row{column + 1}";
            var sb = new StringBuilder();

            sb.AppendLine($"namespace {namespace_name};");
            sb.AppendLine();
            sb.AppendLine($"public struct {name}<T> : IMatrixRow<T> {{");
            sb.AppendLine("    public extern T this[int column] { get; set; }");
            sb.AppendLine();

            for (var i = 0; i < column + 1; i++)
                sb.AppendLine($"    public T Column{i + 1};");

            sb.AppendLine();
            sb.AppendLine($"    public static extern implicit operator Vector{column + 1}<T>({name}<T> row);");
            sb.AppendLine();
            sb.AppendLine($"    public static extern implicit operator {name}<T>(Vector{column + 1}<T> row);");

            sb.AppendLine("}");

            context.AddSource($"{name}.g.cs", sb.ToString());
        }

        for (var row = 0; row < matrix_row_count; row++)
        for (var column = 0; column < matrix_column_count; column++) {
            var name = $"{matrix_name}{row + 1}x{column + 1}";
            var rowName = $"{matrix_name}Row{row + 1}<T>";
            var sb = new StringBuilder();

            sb.AppendLine($"namespace {namespace_name};");
            sb.AppendLine();
            sb.AppendLine($"public struct {name}<T> : IMatrix<T> {{");

            sb.AppendLine("    public extern T this[int row, int column] { get; set; }");
            sb.AppendLine();
            sb.AppendLine($"    public extern ref {rowName} this[int row] {{ get; }}");
            sb.AppendLine();

            for (var i = 0; i < row + 1; i++)
                sb.AppendLine($"    public {rowName} Row{i + 1};");

            sb.AppendLine();

            var rowParams = new StringBuilder();
            // var vecParams = new StringBuilder();

            for (var i = 0; i < row + 1; i++) {
                rowParams.Append($"{rowName} row{i + 1}");
                // vecParams.Append($"Vector{row + 1}<T> vec{i + 1}");

                if (i >= row)
                    continue;

                rowParams.Append(", ");
                // vecParams.Append(", ");
            }

            sb.AppendLine($"    public extern {name}({rowParams});");
            // sb.AppendLine();
            // sb.AppendLine($"    public extern {name}({vecParams});");

            sb.AppendLine("}");

            context.AddSource($"{name}.g.cs", sb.ToString());
        }
    }
}
