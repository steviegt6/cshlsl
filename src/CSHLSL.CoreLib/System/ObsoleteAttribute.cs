namespace System;

[AttributeUsage(
    AttributeTargets.Class
  | AttributeTargets.Struct
  | AttributeTargets.Enum
  | AttributeTargets.Interface
  | AttributeTargets.Constructor
  | AttributeTargets.Method
  | AttributeTargets.Property
  | AttributeTargets.Field
  | AttributeTargets.Event
  | AttributeTargets.Delegate,
    Inherited = false
)]
internal sealed class ObsoleteAttribute : Attribute {
    public ObsoleteAttribute() { }
    
    // FIXME: These signatures do not match .NET; changed to objects instead of
    // strings to avoid compilation errors since we have marked string as both
    // obsolete and an error. Property types have also been modified. Not too
    // important, ObsoleteAttribute is internal here (maybe another FIXME?).

    public ObsoleteAttribute(object message) {
        Message = message;
    }

    public ObsoleteAttribute(object message, bool error) {
        Message = message;
        IsError = error;
    }

    public object Message { get; set; }

    public bool IsError { get; set; }

    public object DiagnosticId { get; set; }

    public object UrlFormat { get; set; }
}
