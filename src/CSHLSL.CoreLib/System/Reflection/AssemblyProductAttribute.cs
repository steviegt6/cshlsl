namespace System.Reflection;

[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
public sealed class AssemblyProductAttribute : Attribute {
    public AssemblyProductAttribute(object product) { }

    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public object Product { get; }
}
