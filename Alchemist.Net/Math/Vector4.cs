namespace Alchemist.Net.Math;

public class Vector4(float x, float y, float z, float w)
{
    // Values
    public float X { get; set; } = x;
    public float Y { get; set; } = y;
    public float Z { get; set; } = z;
    public float W { get; set; } = w;
    
    public static Vector4 operator +(Vector4 vector1, Vector4 vector2)
    {
        return new Vector4(
            vector1.X + vector2.X,
            vector1.Y + vector2.Y,
            vector1.Z + vector2.Z,
            vector1.W + vector2.W
        );
    }

    public static Vector4 operator -(Vector4 vector1, Vector4 vector2)
    {
        return new Vector4(
            vector1.X - vector2.X,
            vector1.Y - vector2.Y,
            vector1.Z - vector2.Z,
            vector1.W - vector2.W
        );
    }

    public static Vector4 operator *(Vector4 vector1, Vector4 vector2)
    {
        return new Vector4(
            vector1.X * vector2.X,
            vector1.Y * vector2.Y,
            vector1.Z * vector2.Z,
            vector1.W * vector2.W
        );
    }

    public static Vector4 operator *(Vector4 vector1, float scalar)
    {
        return new Vector4(
            vector1.X * scalar,
            vector1.Y * scalar,
            vector1.Z * scalar,
            vector1.W * scalar
        );
    }

    public static Vector4 operator /(Vector4 vector1, Vector4 vector2)
    {
        if (vector2.X == 0 || vector2.Y == 0 || vector2.Z == 0 || vector2.W == 0)
            throw new DivideByZeroException("Division by zero is not allowed");

        return new Vector4(
            vector1.X / vector2.X,
            vector1.Y / vector2.Y,
            vector1.Z / vector2.Z,
            vector1.W / vector2.W
        );
    }

    public static Vector4 operator /(Vector4 vector1, float scalar)
    {
        if (scalar == 0)
            throw new DivideByZeroException("Division by zero is not allowed");

        return new Vector4(
            vector1.X / scalar,
            vector1.Y / scalar,
            vector1.Z / scalar,
            vector1.W / scalar
        );
    }
    
    public override string ToString()
    {
        return $"({X}, {Y}, {Z}, {W})";
    }

    public static float Dot(Vector4 vector1, Vector4 vector2)
    {
        return
            vector1.X * vector2.X +
            vector1.Y * vector2.Y +
            vector1.Z * vector2.Z +
            vector1.W * vector2.W;
    }

    public float Magnitude()
    {
        return (float)System.Math.Sqrt(
            X * X + Y * Y + Z * Z + W * W
        );
    }

    public Vector4 Normalize()
    {
        float magnitude = Magnitude();
        if (magnitude == 0)
            throw new InvalidOperationException("Cannot normalize a zero vector");

        return this / magnitude;
    }
    
    public static Vector4 Cross(Vector4 vector1, Vector4 vector2, Vector4 vector3)
    {
        return new Vector4(
            vector1.Y * (vector2.Z * vector3.W - vector3.Z * vector2.W) -
            vector1.Z * (vector2.Y * vector3.W - vector3.Y * vector2.W) +
            vector1.W * (vector2.Y * vector3.Z - vector3.Y * vector2.Z),

            -(vector1.X * (vector2.Z * vector3.W - vector3.Z * vector2.W) -
              vector1.Z * (vector2.X * vector3.W - vector3.X * vector2.W) +
              vector1.W * (vector2.X * vector3.Z - vector3.X * vector2.Z)),

            vector1.X * (vector2.Y * vector3.W - vector3.Y * vector2.W) -
            vector1.Y * (vector2.X * vector3.W - vector3.X * vector2.W) +
            vector1.W * (vector2.X * vector3.Y - vector3.X * vector2.Y),

            -(vector1.X * (vector2.Y * vector3.Z - vector3.Y * vector2.Z) -
              vector1.Y * (vector2.X * vector3.Z - vector3.X * vector2.Z) +
              vector1.Z * (vector2.X * vector3.Y - vector3.X * vector2.Y))
        );
    }
}