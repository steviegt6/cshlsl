using System;

namespace CSHLSL.TestShader;

public static class Matrix {
    // https://gist.github.com/mattatz/86fff4b32d198d0928d0fa4ff32cf6fa#file-matrix-hlsl-L6
    public static float4x4 Inverse(float4x4 m) {
        float n11 = m[0][0],
              n12 = m[1][0],
              n13 = m[2][0],
              n14 = m[3][0];
        float n21 = m[0][1],
              n22 = m[1][1],
              n23 = m[2][1],
              n24 = m[3][1];
        float n31 = m[0][2],
              n32 = m[1][2],
              n33 = m[2][2],
              n34 = m[3][2];
        float n41 = m[0][3],
              n42 = m[1][3],
              n43 = m[2][3],
              n44 = m[3][3];

        var t11 = n23 * n34 * n42 - n24 * n33 * n42 + n24 * n32 * n43 - n22 * n34 * n43 - n23 * n32 * n44 + n22 * n33 * n44;
        var t12 = n14 * n33 * n42 - n13 * n34 * n42 - n14 * n32 * n43 + n12 * n34 * n43 + n13 * n32 * n44 - n12 * n33 * n44;
        var t13 = n13 * n24 * n42 - n14 * n23 * n42 + n14 * n22 * n43 - n12 * n24 * n43 - n13 * n22 * n44 + n12 * n23 * n44;
        var t14 = n14 * n23 * n32 - n13 * n24 * n32 - n14 * n22 * n33 + n12 * n24 * n33 + n13 * n22 * n34 - n12 * n23 * n34;

        var det = n11 * t11 + n21 * t12 + n31 * t13 + n41 * t14;
        var iDet = 1.0f / det;

        var ret = new float4x4();

        ret[0][0] = t11 * iDet;
        ret[0][1] = (n24 * n33 * n41 - n23 * n34 * n41 - n24 * n31 * n43 + n21 * n34 * n43 + n23 * n31 * n44 - n21 * n33 * n44) * iDet;
        ret[0][2] = (n22 * n34 * n41 - n24 * n32 * n41 + n24 * n31 * n42 - n21 * n34 * n42 - n22 * n31 * n44 + n21 * n32 * n44) * iDet;
        ret[0][3] = (n23 * n32 * n41 - n22 * n33 * n41 - n23 * n31 * n42 + n21 * n33 * n42 + n22 * n31 * n43 - n21 * n32 * n43) * iDet;

        ret[1][0] = t12 * iDet;
        ret[1][1] = (n13 * n34 * n41 - n14 * n33 * n41 + n14 * n31 * n43 - n11 * n34 * n43 - n13 * n31 * n44 + n11 * n33 * n44) * iDet;
        ret[1][2] = (n14 * n32 * n41 - n12 * n34 * n41 - n14 * n31 * n42 + n11 * n34 * n42 + n12 * n31 * n44 - n11 * n32 * n44) * iDet;
        ret[1][3] = (n12 * n33 * n41 - n13 * n32 * n41 + n13 * n31 * n42 - n11 * n33 * n42 - n12 * n31 * n43 + n11 * n32 * n43) * iDet;

        ret[2][0] = t13 * iDet;
        ret[2][1] = (n14 * n23 * n41 - n13 * n24 * n41 - n14 * n21 * n43 + n11 * n24 * n43 + n13 * n21 * n44 - n11 * n23 * n44) * iDet;
        ret[2][2] = (n12 * n24 * n41 - n14 * n22 * n41 + n14 * n21 * n42 - n11 * n24 * n42 - n12 * n21 * n44 + n11 * n22 * n44) * iDet;
        ret[2][3] = (n13 * n22 * n41 - n12 * n23 * n41 - n13 * n21 * n42 + n11 * n23 * n42 + n12 * n21 * n43 - n11 * n22 * n43) * iDet;

        ret[3][0] = t14 * iDet;
        ret[3][1] = (n13 * n24 * n31 - n14 * n23 * n31 + n14 * n21 * n33 - n11 * n24 * n33 - n13 * n21 * n34 + n11 * n23 * n34) * iDet;
        ret[3][2] = (n14 * n22 * n31 - n12 * n24 * n31 - n14 * n21 * n32 + n11 * n24 * n32 + n12 * n21 * n34 - n11 * n22 * n34) * iDet;
        ret[3][3] = (n12 * n23 * n31 - n13 * n22 * n31 + n13 * n21 * n32 - n11 * n23 * n32 - n12 * n21 * n33 + n11 * n22 * n33) * iDet;

        return ret;
    }

    // https://gist.github.com/mattatz/86fff4b32d198d0928d0fa4ff32cf6fa#file-matrix-hlsl-L46
    public static float4 MatrixToQuaternion(float4x4 m) {
        var tr = m[0][0] + m[1][1] + m[2][2];
        var q = new float4(0, 0, 0, 0);

        if (tr > 0) {
            var s = Sqrt(tr + 1.0f) * 2; // S=4*qw 
            q.W = 0.25f * s;
            q.X = (m[2][1] - m[1][2]) / s;
            q.Y = (m[0][2] - m[2][0]) / s;
            q.Z = (m[1][0] - m[0][1]) / s;
        }
        else if ((m[0][0] > m[1][1]) && (m[0][0] > m[2][2])) {
            var s = Sqrt(1.0f + m[0][0] - m[1][1] - m[2][2]) * 2; // S=4*qx 
            q.W = (m[2][1] - m[1][2]) / s;
            q.X = 0.25f * s;
            q.Y = (m[0][1] + m[1][0]) / s;
            q.Z = (m[0][2] + m[2][0]) / s;
        }
        else if (m[1][1] > m[2][2]) {
            var s = Sqrt(1.0f + m[1][1] - m[0][0] - m[2][2]) * 2; // S=4*qy
            q.W = (m[0][2] - m[2][0]) / s;
            q.X = (m[0][1] + m[1][0]) / s;
            q.Y = 0.25f * s;
            q.Z = (m[1][2] + m[2][1]) / s;
        }
        else {
            var s = Sqrt(1.0f + m[2][2] - m[0][0] - m[1][1]) * 2; // S=4*qz
            q.W = (m[1][0] - m[0][1]) / s;
            q.X = (m[0][2] + m[2][0]) / s;
            q.Y = (m[1][2] + m[2][1]) / s;
            q.Z = 0.25f * s;
        }

        return q;
    }

    // https://gist.github.com/mattatz/86fff4b32d198d0928d0fa4ff32cf6fa#file-matrix-hlsl-L87
    public static float4x4 MScale(float4x4 m, float3 v) {
        float x = v.X,
              y = v.Y,
              z = v.Z;

        m[0][0] *= x;
        m[1][0] *= y;
        m[2][0] *= z;
        m[0][1] *= x;
        m[1][1] *= y;
        m[2][1] *= z;
        m[0][2] *= x;
        m[1][2] *= y;
        m[2][2] *= z;
        m[0][3] *= x;
        m[1][3] *= y;
        m[2][3] *= z;

        return m;
    }

    // https://gist.github.com/mattatz/86fff4b32d198d0928d0fa4ff32cf6fa#file-matrix-hlsl-L99
    public static float4x4 QuaternionToMatrix(float4 quat) {
        var m = new float4x4(new float4(0, 0, 0, 0), new float4(0, 0, 0, 0), new float4(0, 0, 0, 0), new float4(0, 0, 0, 0));

        float x = quat.X,
              y = quat.Y,
              z = quat.Z,
              w = quat.W;
        float x2 = x + x,
              y2 = y + y,
              z2 = z + z;
        float xx = x * x2,
              xy = x * y2,
              xz = x * z2;
        float yy = y * y2,
              yz = y * z2,
              zz = z * z2;
        float wx = w * x2,
              wy = w * y2,
              wz = w * z2;

        m[0][0] = 1.0f - (yy + zz);
        m[0][1] = xy - wz;
        m[0][2] = xz + wy;

        m[1][0] = xy + wz;
        m[1][1] = 1.0f - (xx + zz);
        m[1][2] = yz - wx;

        m[2][0] = xz - wy;
        m[2][1] = yz + wx;
        m[2][2] = 1.0f - (xx + yy);

        m[3][3] = 1.0f;

        return m;
    }

    // https://gist.github.com/mattatz/86fff4b32d198d0928d0fa4ff32cf6fa#file-matrix-hlsl-L126
    public static float4x4 MTranslate(float4x4 m, float3 v) {
        float x = v.X,
              y = v.Y,
              z = v.Z;
        m[0][3] = x;
        m[1][3] = y;
        m[2][3] = z;
        return m;
    }

    // https://gist.github.com/mattatz/86fff4b32d198d0928d0fa4ff32cf6fa#file-matrix-hlsl-L135
    public static float4x4 Compose(float3 position, float4 quat, float3 scale) {
        var m = QuaternionToMatrix(quat);
        m = MScale(m, scale);
        m = MTranslate(m, position);
        return m;
    }

    // https://gist.github.com/mattatz/86fff4b32d198d0928d0fa4ff32cf6fa#file-matrix-hlsl-L143
    public static void Decompose(in float4x4 m, out float3 position, out float4 rotation, out float3 scale) {
        position = default;
        scale = default;

        var sx = Length(new float3(m[0][0], m[0][1], m[0][2]));
        var sy = Length(new float3(m[1][0], m[1][1], m[1][2]));
        var sz = Length(new float3(m[2][0], m[2][1], m[2][2]));

        // if determine is negative, we need to invert one scale
        var det = Determinant(m);
        if (det < 0)
            sx = -sx;

        position.X = m[3][0];
        position.Y = m[3][1];
        position.Z = m[3][2];

        // scale the rotation part

        var invSX = 1.0f / sx;
        var invSY = 1.0f / sy;
        var invSZ = 1.0f / sz;

        m[0][0] *= invSX;
        m[0][1] *= invSX;
        m[0][2] *= invSX;

        m[1][0] *= invSY;
        m[1][1] *= invSY;
        m[1][2] *= invSY;

        m[2][0] *= invSZ;
        m[2][1] *= invSZ;
        m[2][2] *= invSZ;

        rotation = MatrixToQuaternion(m);

        scale.X = sx;
        scale.Y = sy;
        scale.Z = sz;
    }
}
