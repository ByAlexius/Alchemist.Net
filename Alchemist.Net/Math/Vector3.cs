namespace Alchemist.Net.Math;

public class Vector3(float x, float y, float z)
{
    // Values
    public float X { get; set; } = x;
    public float Y { get; set; } = y;
    public float Z { get; set; } = z;

    public static Vector3 operator +(Vector3 vector1, Vector3 vector2)
    {
        return new Vector3(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z);
    }
    
    public static Vector3 operator -(Vector3 vector1, Vector3 vector2)
    {
        return new Vector3(vector1.X - vector2.X, vector1.Y - vector2.Y, vector1.Z - vector2.Z);
    }
    
    public static Vector3 operator *(Vector3 vector1, Vector3 vector2)
    {
        return new Vector3(vector1.X * vector2.X, vector1.Y * vector2.Y, vector1.Z * vector2.Z);
    }
    
    public static Vector3 operator *(Vector3 vector1, float scalar)
    {
        return new Vector3(vector1.X * scalar, vector1.Y * scalar, vector1.Z * scalar);
    }
    
    public static Vector3 operator /(Vector3 vector1, Vector3 vector2)
    {
        if (vector2.X == 0 || vector2.Y == 0 || vector2.Z == 0)
            throw new DivideByZeroException("Division by zero is not allowed");
        
        return new Vector3(vector1.X / vector2.X, vector1.Y / vector2.Y, vector1.Z / vector2.Z);
    }
    
    public static Vector3 operator /(Vector3 vector1, float scalar)
    {
        if (scalar == 0)
            throw new DivideByZeroException("Division by zero is not allowed");
        
        return new Vector3(vector1.X / scalar, vector1.Y / scalar, vector1.Z / scalar);
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }

    public static float Dot(Vector3 vector1, Vector3 vector2)
    {
        return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
    }

    public static Vector3 Cross(Vector3 vector1, Vector3 vector2)
    {
        return new Vector3(
            vector1.Y * vector2.Z - vector1.Z * vector2.Y,
            vector1.Z * vector2.X - vector1.X * vector2.Z,
            vector1.X * vector2.Y - vector1.Y * vector2.X
        );
    }

    public float Magnitude()
    {
        return (float)System.Math.Sqrt(X * X + Y * Y + Z * Z);
    }

    public Vector3 Normalize()
    {
        float magnitude = Magnitude();
        if (magnitude == 0)
            throw new InvalidOperationException("Cannot normalize a zero vector");
        
        return this / magnitude;
    }
}