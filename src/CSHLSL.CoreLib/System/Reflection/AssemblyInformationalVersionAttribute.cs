namespace System.Reflection;

[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
public sealed class AssemblyInformationalVersionAttribute : Attribute {
    public AssemblyInformationalVersionAttribute(string informationalVersion) { }
}
