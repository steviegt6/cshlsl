namespace System.Reflection;

[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
public sealed class AssemblyVersionAttribute : Attribute {
    public AssemblyVersionAttribute(string version) { }

    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public string Version { get; }
}
