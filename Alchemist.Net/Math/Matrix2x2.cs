namespace Alchemist.Net.Math;

public class Matrix2x2(float m11, float m12, float m21, float m22)
{
    public float M11 { get; set; } = m11;
    public float M12 { get; set; } = m12;
    public float M21 { get; set; } = m21;
    public float M22 { get; set; } = m22;

    public static Matrix2x2 Identity => new Matrix2x2(1, 0, 0, 1);

    public static Matrix2x2 operator +(Matrix2x2 a, Matrix2x2 b)
    {
        return new Matrix2x2(
            a.M11 + b.M11, a.M12 + b.M12,
            a.M21 + b.M21, a.M22 + b.M22
        );
    }

    public static Matrix2x2 operator *(Matrix2x2 a, Matrix2x2 b)
    {
        return new Matrix2x2(
            a.M11 * b.M11 + a.M12 * b.M21, a.M11 * b.M12 + a.M12 * b.M22,
            a.M21 * b.M11 + a.M22 * b.M21, a.M21 * b.M12 + a.M22 * b.M22
        );
    }

    public static Vector2 operator *(Matrix2x2 m, Vector2 v)
    {
        return new Vector2(
            m.M11 * v.X + m.M12 * v.Y,
            m.M21 * v.X + m.M22 * v.Y
        );
    }

    public override string ToString()
    {
        return $"[{M11}, {M12}]\n[{M21}, {M22}]";
    }}