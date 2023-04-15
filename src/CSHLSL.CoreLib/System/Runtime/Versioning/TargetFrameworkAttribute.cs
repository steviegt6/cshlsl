namespace System.Runtime.Versioning;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
public sealed class TargetFrameworkAttribute : Attribute {
    public TargetFrameworkAttribute(object frameworkName) { }

#pragma warning disable CA1822
    public object FrameworkDisplayName {
        get => "";
        set => _ = value;
    }
#pragma warning restore CA1822
}
