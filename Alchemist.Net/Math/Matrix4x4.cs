namespace Alchemist.Net.Math;

public class Matrix4x4(
    float m11,
    float m12,
    float m13,
    float m14,
    float m21,
    float m22,
    float m23,
    float m24,
    float m31,
    float m32,
    float m33,
    float m34,
    float m41,
    float m42,
    float m43,
    float m44)
{
    public float M11 = m11, M12 = m12, M13 = m13, M14 = m14;
    public float M21 = m21, M22 = m22, M23 = m23, M24 = m24;
    public float M31 = m31, M32 = m32, M33 = m33, M34 = m34;
    public float M41 = m41, M42 = m42, M43 = m43, M44 = m44;

    public static Matrix4x4 Identity => new Matrix4x4(
        1, 0, 0, 0,
        0, 1, 0, 0,
        0, 0, 1, 0,
        0, 0, 0, 1
    );

    public static Matrix4x4 operator +(Matrix4x4 a, Matrix4x4 b)
    {
        return new Matrix4x4(
            a.M11 + b.M11, a.M12 + b.M12, a.M13 + b.M13, a.M14 + b.M14,
            a.M21 + b.M21, a.M22 + b.M22, a.M23 + b.M23, a.M24 + b.M24,
            a.M31 + b.M31, a.M32 + b.M32, a.M33 + b.M33, a.M34 + b.M34,
            a.M41 + b.M41, a.M42 + b.M42, a.M43 + b.M43, a.M44 + b.M44
        );
    }

    public static Matrix4x4 operator *(Matrix4x4 a, Matrix4x4 b)
    {
        return new Matrix4x4(
            a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41,
            a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42,
            a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43,
            a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44,

            a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41,
            a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42,
            a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43,
            a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44,

            a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41,
            a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42,
            a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43,
            a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44,

            a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41,
            a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42,
            a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43,
            a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34 + a.M44 * b.M44
        );
    }
    
    public static Vector4 operator *(Matrix4x4 m, Vector4 v)
    {
        return new Vector4(
            m.M11 * v.X + m.M12 * v.Y + m.M13 * v.Z + m.M14 * v.W,
            m.M21 * v.X + m.M22 * v.Y + m.M23 * v.Z + m.M24 * v.W,
            m.M31 * v.X + m.M32 * v.Y + m.M33 * v.Z + m.M34 * v.W,
            m.M41 * v.X + m.M42 * v.Y + m.M43 * v.Z + m.M44 * v.W
        );
    }

    public override string ToString()
    {
        return $"[{M11}, {M12}, {M13}, {M14}]\n[{M21}, {M22}, {M23}, {M24}]\n[{M31}, {M32}, {M33}, {M34}]\n[{M41}, {M42}, {M43}, {M44}]";
    }
}