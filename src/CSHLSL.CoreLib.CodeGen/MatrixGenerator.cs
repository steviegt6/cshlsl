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
        for (var row = 0; row < matrix_row_count; row++)
        for (var column = 0; column < matrix_column_count; column++) {
            var name = $"{matrix_name}{row + 1}x{column + 1}";
            var sb = new StringBuilder();

            sb.AppendLine($"namespace {namespace_name};");
            sb.AppendLine();
            sb.AppendLine($"public class {name}<T> {{");

            sb.AppendLine("    public extern T this[int row, int column] { get; set; }");

            sb.AppendLine("}");

            context.AddSource($"{name}.g.cs", sb.ToString());
        }
    }
}
