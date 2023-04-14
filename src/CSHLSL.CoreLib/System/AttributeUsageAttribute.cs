namespace System;

[AttributeUsage(AttributeTargets.Class, Inherited = true)]
public sealed class AttributeUsageAttribute : Attribute {
#pragma warning disable IDE0060
    public AttributeUsageAttribute(AttributeTargets validOn) { }

    public AttributeUsageAttribute(AttributeTargets validOn, bool allowMultiple, bool inherited) { }
#pragma warning restore IDE0060

#pragma warning disable CA1822
    public bool AllowMultiple {
        get => false;
        set => _ = value;
    }

    public bool Inherited {
        get => false;
        set => _ = value;
    }
#pragma warning restore CA1822
}
