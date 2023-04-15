namespace System.Reflection;

[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
public sealed class AssemblyConfigurationAttribute : Attribute {
    public AssemblyConfigurationAttribute(object configuration) { }

    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public object Configuration { get; }
}
