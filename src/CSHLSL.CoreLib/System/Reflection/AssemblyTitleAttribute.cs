namespace System.Reflection;

[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
public sealed class AssemblyTitleAttribute : Attribute {
    public AssemblyTitleAttribute(object title) { }

    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public object Title { get; }
}
