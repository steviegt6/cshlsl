namespace System.Reflection; 

[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
public sealed class AssemblyFileVersionAttribute : Attribute {
    public AssemblyFileVersionAttribute(object version) { }
    
    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public object Version { get; }
}
