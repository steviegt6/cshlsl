namespace System.Reflection;

[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
public sealed class AssemblyConfigurationAttribute : Attribute {
    public AssemblyConfigurationAttribute(string configuration) { }

    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public string Configuration { get; }
}
