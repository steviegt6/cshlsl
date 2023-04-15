namespace System.Reflection;

[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
public sealed class AssemblyVersionAttribute : Attribute {
    public AssemblyVersionAttribute(object version) { }

    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public object Version { get; }
}
