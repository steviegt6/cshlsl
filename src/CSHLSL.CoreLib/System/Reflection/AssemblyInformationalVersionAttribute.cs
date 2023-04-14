namespace System.Reflection;

[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
public sealed class AssemblyInformationalVersionAttribute : Attribute {
    public AssemblyInformationalVersionAttribute(string informationalVersion) { }

    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public string InformationalVersion { get; }
}
