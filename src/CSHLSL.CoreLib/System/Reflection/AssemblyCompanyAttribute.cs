namespace System.Reflection; 

[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
public sealed class AssemblyCompanyAttribute : Attribute {
    public AssemblyCompanyAttribute(string company) { }

    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public string Company { get; }
}
