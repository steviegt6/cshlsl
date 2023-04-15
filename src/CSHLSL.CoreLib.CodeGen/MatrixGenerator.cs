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
        for (var row = 0; row < matrix_row_count; row++) {
            var name = $"{matrix_name}Row{row + 1}";
            var sb = new StringBuilder();
            
            sb.AppendLine($"namespace {namespace_name};");
            sb.AppendLine();
            sb.AppendLine($"public struct {name}<T> : IMatrixRow<T> {{");
            
            sb.AppendLine("    public extern T this[int column] { get; set; }");
            
            for (var column = 0; column < matrix_column_count; column++)
                sb.AppendLine($"    public T Row{column + 1};");
            
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
            sb.AppendLine($"public struct {name}<T> : IMatrix<T, {rowName}> {{");

            sb.AppendLine("    public extern T this[int row, int column] { get; set; }");
            sb.AppendLine();
            sb.AppendLine($"    public extern {rowName} this[int row] {{ get; set; }}");
            sb.AppendLine();
            
            for (var i = 0; i < matrix_row_count; i++)
                sb.AppendLine($"    public {rowName} Row{i + 1};");

            sb.AppendLine("}");

            context.AddSource($"{name}.g.cs", sb.ToString());
        }
    }
}
