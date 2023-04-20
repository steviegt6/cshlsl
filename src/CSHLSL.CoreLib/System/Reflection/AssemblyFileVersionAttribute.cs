namespace System.Reflection; 

[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
public sealed class AssemblyFileVersionAttribute : Attribute {
    public AssemblyFileVersionAttribute(string version) { }
}
