/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;

namespace CSHLSL.CoreLib.CodeGen;

// TODO: Size support? idk.,.,,.,..,.,,,,,,,,,,,,,.,.

[Flags]
public enum TemplateType {
    Scalar,
    Vector,
    Matrix,
    SameAsInput,
}

[Flags]
public enum ComponentType {
    Float,
}

public interface IResolver {
    Parameters Parameters { get; set; }

    Parameter ReturnType { get; set; }
}

public interface ITemplateTypeResolver : IResolver {
    TemplateType Resolve();
}

public interface IComponentTypeResolver : IResolver {
    ComponentType Resolve();
}

public class TemplateTypeResolverFromEnum : ITemplateTypeResolver {
    public Parameters Parameters { get; set; } = null!;

    public Parameter ReturnType { get; set; } = null!;

    private readonly TemplateType templateType;

    public TemplateTypeResolverFromEnum(TemplateType templateType) {
        this.templateType = templateType;
    }

    public TemplateType Resolve() {
        return templateType;
    }
}

public class TemplateTypeResolverFromInput : ITemplateTypeResolver {
    public Parameters Parameters { get; set; } = null!;

    public Parameter ReturnType { get; set; } = null!;

    private readonly int inputIndex;

    public TemplateTypeResolverFromInput(int inputIndex) {
        this.inputIndex = inputIndex;
    }

    public TemplateType Resolve() {
        return Parameters[inputIndex].TemplateType;
    }
}

public class ComponentTypeResolverFromEnum : IComponentTypeResolver {
    public Parameters Parameters { get; set; } = null!;

    public Parameter ReturnType { get; set; } = null!;

    private readonly ComponentType componentType;

    public ComponentTypeResolverFromEnum(ComponentType componentType) {
        this.componentType = componentType;
    }

    public ComponentType Resolve() {
        return componentType;
    }
}

public sealed class Parameter {
    private readonly ITemplateTypeResolver templateTypeResolver;
    private readonly IComponentTypeResolver componentTypeResolver;

    public string Name { get; }

    public TemplateType TemplateType => templateTypeResolver.Resolve();

    public ComponentType ComponentType => componentTypeResolver.Resolve();

    public Parameter(string name, ITemplateTypeResolver templateTypeResolver, IComponentTypeResolver componentTypeResolver) {
        Name = name;
        this.templateTypeResolver = templateTypeResolver;
        this.componentTypeResolver = componentTypeResolver;
    }

    public void SetParameters(Parameters parameters) {
        templateTypeResolver.Parameters = parameters;
        componentTypeResolver.Parameters = parameters;
    }

    public void SetReturnType(Parameter returnType) {
        templateTypeResolver.ReturnType = returnType;
        componentTypeResolver.ReturnType = returnType;
    }
}

public sealed class Parameters {
    private readonly Parameter[] parameters;

    public Parameter this[int index] => parameters[index];

    public int Length => parameters.Length;

    public Parameters(params Parameter[] parameters) {
        this.parameters = parameters;
    }
}

public sealed class Function {
    private readonly string name;
    private readonly Parameters parameters;
    private readonly Parameter returnType;

    public Function(string name, Parameters parameters, Parameter returnType) {
        this.name = name;
        this.parameters = parameters;
        this.returnType = returnType;

        for (var i = 0; i < parameters.Length; i++) {
            parameters[i].SetParameters(parameters);
            parameters[i].SetReturnType(returnType);
        }

        returnType.SetParameters(parameters);
        returnType.SetReturnType(returnType);
    }

    public override IEnumerable<string> MakeStrings() {
        var sb = new StringBuilder();

        var definitions = ApplyTemplate()
    }

    private static string[] ApplyTemplate(TemplateType templateType, ComponentType componentType) {
        static string[] applyTemplateVector(ComponentType componentType) {
            const int max_vector_size = 4;

            var compatible = CompatibleWith(componentType);
            var result = new string[max_vector_size * compatible.Length];

            for (var i = 0; i < max_vector_size; i++)
            for (var j = 0; j < compatible.Length; j++)
                result[i * compatible.Length + j] = $"{compatible[j]}{i + 1}";

            return result;
        }

        static string[] applyTemplateMatrix(ComponentType componentType) {
            const int max_matrix_rows = 4;
            const int max_matrix_columns = 4;
            const int max_matrices = max_matrix_rows * max_matrix_columns;

            var compatible = CompatibleWith(componentType);
            var result = new string[max_matrices * compatible.Length];

            for (var i = 0; i < max_matrix_rows; i++)
            for (var j = 0; j < max_matrix_columns; j++)
            for (var k = 0; k < compatible.Length; k++)
                result[(i * max_matrix_columns + j) * compatible.Length + k] = $"{compatible[k]}{i + 1}x{j + 1}";

            return result;
        }

        return templateType switch {
            TemplateType.Scalar => CompatibleWith(componentType),
            TemplateType.Vector => applyTemplateVector(componentType),
            TemplateType.Matrix => applyTemplateMatrix(componentType),
            TemplateType.SameAsInput => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    private static string[] CompatibleWith(ComponentType componentType) {
        return componentType switch {
            ComponentType.Float => new[] { "bool", "int", "uint", "half", "float", "double" },
            _ => throw new NotImplementedException(),
        };
    }
}

[Generator]
public sealed class IntrinsicFunctionGenerator : ISourceGenerator {
    private readonly Dictionary<string, List<Function>> functions = new();

    void ISourceGenerator.Initialize(GeneratorInitializationContext context) { }

    void ISourceGenerator.Execute(GeneratorExecutionContext context) {
        BeginFunctions();

        DefineFunction(
            "Sqrt",
            new Parameters(
                new Parameter(
                    "x",
                    new TemplateTypeResolverFromEnum(TemplateType.Scalar | TemplateType.Vector | TemplateType.Matrix),
                    new ComponentTypeResolverFromEnum(ComponentType.Float)
                )
            ),
            new Parameter(
                null,
                new TemplateTypeResolverFromInput(0),
                new ComponentTypeResolverFromEnum(ComponentType.Float)
            )
        );

        WriteFunctions(context);
    }

    private void BeginFunctions() {
        functions.Clear();
    }

    private void DefineFunction(string name, Parameters parameters, Parameter returnType) {
        if (!functions.TryGetValue(name, out var overloads))
            functions[name] = overloads = new List<Function>();

        overloads.Add(new Function(name, parameters, returnType));
    }

    private void WriteFunctions(GeneratorExecutionContext context) {
        var sb = new StringBuilder();

        sb.AppendLine("namespace System;");
        sb.AppendLine();
        sb.AppendLine("public static partial class IntrinsicFunctions {");

        foreach (var funcName in functions.Keys) {
            sb.AppendLine($"#region {funcName}");

            for (var i = 0; i < functions[funcName].Count; i++) {
                if (i > 0)
                    sb.AppendLine();

                var funcStrings = functions[funcName][i].MakeStrings().ToList();

                for (var j = 0; j < funcStrings.Count; j++) {
                    if (j > 0)
                        sb.AppendLine();

                    sb.Append(funcStrings[j]);
                }
            }

            sb.AppendLine("#endregion");
        }

        sb.AppendLine("}");
    }
}*/


