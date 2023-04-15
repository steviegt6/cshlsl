namespace System;

[Flags]
public enum AttributeTargets {
    Assembly         = 0b000000000000001,
    Module           = 0b000000000000010,
    Class            = 0b000000000000100,
    Struct           = 0b000000000001000,
    Enum             = 0b000000000010000,
    Constructor      = 0b000000000100000,
    Method           = 0b000000001000000,
    Property         = 0b000000010000000,
    Field            = 0b000000100000000,
    Event            = 0b000001000000000,
    Interface        = 0b000010000000000,
    Parameter        = 0b000100000000000,
    Delegate         = 0b001000000000000,
    ReturnValue      = 0b010000000000000,
    GenericParameter = 0b100000000000000,

    All = Assembly
        | Module
        | Class
        | Struct
        | Enum
        | Constructor
        | Method
        | Property
        | Field
        | Event
        | Interface
        | Parameter
        | Delegate
        | ReturnValue
        | GenericParameter,
}
