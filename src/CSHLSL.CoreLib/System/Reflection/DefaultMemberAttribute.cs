namespace System.Reflection;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface)]
public sealed class DefaultMemberAttribute : Attribute {
    public DefaultMemberAttribute(string memberName) { }
}
