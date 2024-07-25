namespace Alchemist.Net.Math;

public class Matrix3x3(
    float m11,
    float m12,
    float m13,
    float m21,
    float m22,
    float m23,
    float m31,
    float m32,
    float m33)
{
    public float M11 = m11, M12 = m12, M13 = m13;
    public float M21 = m21, M22 = m22, M23 = m23;
    public float M31 = m31, M32 = m32, M33 = m33;

    public static Matrix3x3 Identity => new Matrix3x3(
        1, 0, 0,
        0, 1, 0,
        0, 0, 1
    );

    public static Matrix3x3 operator +(Matrix3x3 a, Matrix3x3 b)
    {
        return new Matrix3x3(
            a.M11 + b.M11, a.M12 + b.M12, a.M13 + b.M13,
            a.M21 + b.M21, a.M22 + b.M22, a.M23 + b.M23,
            a.M31 + b.M31, a.M32 + b.M32, a.M33 + b.M33
        );
    }

    public static Matrix3x3 operator *(Matrix3x3 a, Matrix3x3 b)
    {
        return new Matrix3x3(
            a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31,
            a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32,
            a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33,

            a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31,
            a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32,
            a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33,

            a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31,
            a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32,
            a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33
        );
    }

    public static Vector3 operator *(Matrix3x3 m, Vector3 v)
    {
        return new Vector3(
            m.M11 * v.X + m.M12 * v.Y + m.M13 * v.Z,
            m.M21 * v.X + m.M22 * v.Y + m.M23 * v.Z,
            m.M31 * v.X + m.M32 * v.Y + m.M33 * v.Z
        );
    }

    public override string ToString()
    {
        return $"[{M11}, {M12}, {M13}]\n[{M21}, {M22}, {M23}]\n[{M31}, {M32}, {M33}]";
    }
}