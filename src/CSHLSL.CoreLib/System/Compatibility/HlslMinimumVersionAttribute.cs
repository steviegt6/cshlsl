namespace System.Compatibility; 

internal sealed class HlslMinimumVersionAttribute : Attribute {
    public int Major { get; }
    
    public int Minor { get; }
    
    public HlslMinimumVersionAttribute(int major, int minor = 0) {
        Major = major;
        Minor = minor;
    }
}
