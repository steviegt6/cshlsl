namespace System.Reflection;

[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
public sealed class AssemblyProductAttribute : Attribute {
    public AssemblyProductAttribute(string product) { }

    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public string Product { get; }
}
