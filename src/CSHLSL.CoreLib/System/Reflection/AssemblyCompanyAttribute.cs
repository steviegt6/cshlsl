namespace System.Reflection;

[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
public sealed class AssemblyCompanyAttribute : Attribute {
    public AssemblyCompanyAttribute(object company) { }

    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public object Company { get; }
}
