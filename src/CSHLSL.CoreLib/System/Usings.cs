#pragma warning disable CS8981

// Scalar aliases.
global using dword = System.UInt32;
global using half = System.Half;

// Vector aliases.
global using bool1 = System.Vector1<bool>;
global using bool2 = System.Vector2<bool>;
global using bool3 = System.Vector3<bool>;
global using bool4 = System.Vector4<bool>;

global using int1 = System.Vector1<int>;
global using int2 = System.Vector2<int>;
global using int3 = System.Vector3<int>;
global using int4 = System.Vector4<int>;

global using uint1 = System.Vector1<uint>;
global using uint2 = System.Vector2<uint>;
global using uint3 = System.Vector3<uint>;
global using uint4 = System.Vector4<uint>;

global using dword1 = System.Vector1<uint>;
global using dword2 = System.Vector2<uint>;
global using dword3 = System.Vector3<uint>;
global using dword4 = System.Vector4<uint>;

global using half1 = System.Vector1<System.Half>;
global using half2 = System.Vector2<System.Half>;
global using half3 = System.Vector3<System.Half>;
global using half4 = System.Vector4<System.Half>;

global using float1 = System.Vector1<float>;
global using float2 = System.Vector2<float>;
global using float3 = System.Vector3<float>;
global using float4 = System.Vector4<float>;

global using double1 = System.Vector1<double>;
global using double2 = System.Vector2<double>;
global using double3 = System.Vector3<double>;
global using double4 = System.Vector4<double>;

// Matrix aliases.
global using bool1x1 = System.Matrix1x1<bool>;
global using bool1x2 = System.Matrix1x2<bool>;
global using bool1x3 = System.Matrix1x3<bool>;
global using bool1x4 = System.Matrix1x4<bool>;
global using bool2x1 = System.Matrix2x1<bool>;
global using bool2x2 = System.Matrix2x2<bool>;
global using bool2x3 = System.Matrix2x3<bool>;
global using bool2x4 = System.Matrix2x4<bool>;
global using bool3x1 = System.Matrix3x1<bool>;
global using bool3x2 = System.Matrix3x2<bool>;
global using bool3x3 = System.Matrix3x3<bool>;
global using bool3x4 = System.Matrix3x4<bool>;
global using bool4x1 = System.Matrix4x1<bool>;
global using bool4x2 = System.Matrix4x2<bool>;
global using bool4x3 = System.Matrix4x3<bool>;
global using bool4x4 = System.Matrix4x4<bool>;

global using int1x1 = System.Matrix1x1<int>;
global using int1x2 = System.Matrix1x2<int>;
global using int1x3 = System.Matrix1x3<int>;
global using int1x4 = System.Matrix1x4<int>;
global using int2x1 = System.Matrix2x1<int>;
global using int2x2 = System.Matrix2x2<int>;
global using int2x3 = System.Matrix2x3<int>;
global using int2x4 = System.Matrix2x4<int>;
global using int3x1 = System.Matrix3x1<int>;
global using int3x2 = System.Matrix3x2<int>;
global using int3x3 = System.Matrix3x3<int>;
global using int3x4 = System.Matrix3x4<int>;
global using int4x1 = System.Matrix4x1<int>;
global using int4x2 = System.Matrix4x2<int>;
global using int4x3 = System.Matrix4x3<int>;
global using int4x4 = System.Matrix4x4<int>;

global using uint1x1 = System.Matrix1x1<uint>;
global using uint1x2 = System.Matrix1x2<uint>;
global using uint1x3 = System.Matrix1x3<uint>;
global using uint1x4 = System.Matrix1x4<uint>;
global using uint2x1 = System.Matrix2x1<uint>;
global using uint2x2 = System.Matrix2x2<uint>;
global using uint2x3 = System.Matrix2x3<uint>;
global using uint2x4 = System.Matrix2x4<uint>;
global using uint3x1 = System.Matrix3x1<uint>;
global using uint3x2 = System.Matrix3x2<uint>;
global using uint3x3 = System.Matrix3x3<uint>;
global using uint3x4 = System.Matrix3x4<uint>;
global using uint4x1 = System.Matrix4x1<uint>;
global using uint4x2 = System.Matrix4x2<uint>;
global using uint4x3 = System.Matrix4x3<uint>;
global using uint4x4 = System.Matrix4x4<uint>;

global using dword1x1 = System.Matrix1x1<uint>;
global using dword1x2 = System.Matrix1x2<uint>;
global using dword1x3 = System.Matrix1x3<uint>;
global using dword1x4 = System.Matrix1x4<uint>;
global using dword2x1 = System.Matrix2x1<uint>;
global using dword2x2 = System.Matrix2x2<uint>;
global using dword2x3 = System.Matrix2x3<uint>;
global using dword2x4 = System.Matrix2x4<uint>;
global using dword3x1 = System.Matrix3x1<uint>;
global using dword3x2 = System.Matrix3x2<uint>;
global using dword3x3 = System.Matrix3x3<uint>;
global using dword3x4 = System.Matrix3x4<uint>;
global using dword4x1 = System.Matrix4x1<uint>;
global using dword4x2 = System.Matrix4x2<uint>;
global using dword4x3 = System.Matrix4x3<uint>;
global using dword4x4 = System.Matrix4x4<uint>;

global using half1x1 = System.Matrix1x1<System.Half>;
global using half1x2 = System.Matrix1x2<System.Half>;
global using half1x3 = System.Matrix1x3<System.Half>;
global using half1x4 = System.Matrix1x4<System.Half>;
global using half2x1 = System.Matrix2x1<System.Half>;
global using half2x2 = System.Matrix2x2<System.Half>;
global using half2x3 = System.Matrix2x3<System.Half>;
global using half2x4 = System.Matrix2x4<System.Half>;
global using half3x1 = System.Matrix3x1<System.Half>;
global using half3x2 = System.Matrix3x2<System.Half>;
global using half3x3 = System.Matrix3x3<System.Half>;
global using half3x4 = System.Matrix3x4<System.Half>;
global using half4x1 = System.Matrix4x1<System.Half>;
global using half4x2 = System.Matrix4x2<System.Half>;
global using half4x3 = System.Matrix4x3<System.Half>;
global using half4x4 = System.Matrix4x4<System.Half>;

global using float1x1 = System.Matrix1x1<float>;
global using float1x2 = System.Matrix1x2<float>;
global using float1x3 = System.Matrix1x3<float>;
global using float1x4 = System.Matrix1x4<float>;
global using float2x1 = System.Matrix2x1<float>;
global using float2x2 = System.Matrix2x2<float>;
global using float2x3 = System.Matrix2x3<float>;
global using float2x4 = System.Matrix2x4<float>;
global using float3x1 = System.Matrix3x1<float>;
global using float3x2 = System.Matrix3x2<float>;
global using float3x3 = System.Matrix3x3<float>;
global using float3x4 = System.Matrix3x4<float>;
global using float4x1 = System.Matrix4x1<float>;
global using float4x2 = System.Matrix4x2<float>;
global using float4x3 = System.Matrix4x3<float>;
global using float4x4 = System.Matrix4x4<float>;

global using double1x1 = System.Matrix1x1<double>;
global using double1x2 = System.Matrix1x2<double>;
global using double1x3 = System.Matrix1x3<double>;
global using double1x4 = System.Matrix1x4<double>;
global using double2x1 = System.Matrix2x1<double>;
global using double2x2 = System.Matrix2x2<double>;
global using double2x3 = System.Matrix2x3<double>;
global using double2x4 = System.Matrix2x4<double>;
global using double3x1 = System.Matrix3x1<double>;
global using double3x2 = System.Matrix3x2<double>;
global using double3x3 = System.Matrix3x3<double>;
global using double3x4 = System.Matrix3x4<double>;
global using double4x1 = System.Matrix4x1<double>;
global using double4x2 = System.Matrix4x2<double>;
global using double4x3 = System.Matrix4x3<double>;
global using double4x4 = System.Matrix4x4<double>;

#pragma warning restore CS8981
