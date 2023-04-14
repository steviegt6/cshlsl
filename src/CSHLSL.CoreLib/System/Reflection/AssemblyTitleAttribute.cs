namespace System.Reflection;

[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
public sealed class AssemblyTitleAttribute : Attribute {
    public AssemblyTitleAttribute(string title) { }

    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public string Title { get; }
}
