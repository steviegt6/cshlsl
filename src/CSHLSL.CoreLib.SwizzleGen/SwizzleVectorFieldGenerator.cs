using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;

namespace CSHLSL.CoreLib.SwizzleGen;

[Generator]
public sealed class SwizzleVectorFieldGenerator : ISourceGenerator {
    private const string namespace_name = "System";
    private const string vector_name = "Vector";
    private const int vector_count = 4;
    private static readonly char[] coordinate_names = { 'x', 'y', 'z', 'w' };
    private static readonly char[] color_names = { 'r', 'g', 'b', 'a' };

    void ISourceGenerator.Initialize(GeneratorInitializationContext context) { }

    void ISourceGenerator.Execute(GeneratorExecutionContext context) {
        for (var i = 1; i < vector_count + 1; i++) {
            var sb = new StringBuilder();

            sb.AppendLine($"namespace {namespace_name};");
            sb.AppendLine();
            sb.AppendLine($"partial class {vector_name}{i}<T> {{");

            var coordSwizzles = new HashSet<string>();
            var colorSwizzles = new HashSet<string>();
            var validCoords = coordinate_names.Take(i).ToArray();
            var validColors = color_names.Take(i).ToArray();
            GenerateCombinations(validCoords, coordSwizzles);
            GenerateCombinations(validColors, colorSwizzles);

            foreach (var set in coordSwizzles)
                sb.AppendLine($"    public Swizzle{set.Length}<T> {set};");

            sb.AppendLine();

            foreach (var set in colorSwizzles)
                sb.AppendLine($"    public Swizzle{set.Length}<T> {set};");

            sb.AppendLine("}");

            context.AddSource($"{vector_name}{i}.g.cs", sb.ToString());
        }
    }

    private static void GenerateCombinations(char[] validChars, HashSet<string> combinations) {
        var validLength = validChars.Length;

        for (var length = 1; length <= validLength; length++) {
            var combo = new char[length];
            for (var i = 0; i < length; i++)
                combo[i] = validChars[0];

            while (true) {
                combinations.Add(new string(combo));

                var j = length - 1;
                while (j >= 0 && combo[j] == validChars[validLength - 1])
                    j--;

                if (j < 0)
                    break;
                
                combo[j] = validChars[Array.IndexOf(validChars, combo[j]) + 1];
                for (var k = j + 1; k < length; k++)
                    combo[k] = validChars[0];
            }
        }
    }
}
