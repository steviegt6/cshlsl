namespace System.Reflection;

[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
public sealed class AssemblyInformationalVersionAttribute : Attribute {
    public AssemblyInformationalVersionAttribute(object informationalVersion) { }

    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public object InformationalVersion { get; }
}
