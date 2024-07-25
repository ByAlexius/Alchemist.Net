namespace Alchemist.Net.Math;

public class Vector2(float x, float y)
{
    // Values
    public float X { get; set; } = x;
    public float Y { get; set; } = y;

    public static Vector2 operator +(Vector2 vector1, Vector2 vector2)
    {
        return new Vector2(vector1.X + vector2.X, vector1.Y + vector2.Y);
    }
    
    public static Vector2 operator -(Vector2 vector1, Vector2 vector2)
    {
        return new Vector2(vector1.X - vector2.X, vector1.Y - vector2.Y);
    }
    
    public static Vector2 operator *(Vector2 vector1, Vector2 vector2)
    {
        return new Vector2(vector1.X * vector2.X, vector1.Y * vector2.Y);
    }
    
    public static Vector2 operator *(Vector2 vector1, float scalar)
    {
        return new Vector2(vector1.X * scalar, vector1.Y * scalar);
    }
    
    public static Vector2 operator /(Vector2 vector1, Vector2 vector2)
    {
        if (vector2.X == 0 || vector2.Y == 0)
            throw new DivideByZeroException("Division by zero is not allowed");
        
        return new Vector2(vector1.X / vector2.X, vector1.Y / vector2.Y);
    }
    
    public static Vector2 operator /(Vector2 vector1, float scalar)
    {
        if (scalar == 0)
            throw new DivideByZeroException("Division by zero is not allowed");
        
        return new Vector2(vector1.X / scalar, vector1.Y / scalar);
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }

    public static float Dot(Vector2 vector1, Vector2 vector2)
    {
        return vector1.X * vector2.X + vector1.Y * vector2.Y;
    }

    public static float Cross(Vector2 vector1, Vector2 vector2)
    {
        return vector1.X * vector2.Y - vector1.Y * vector2.X;
    }

    public float Magnitude()
    {
        return (float)System.Math.Sqrt(X * X + Y * Y);
    }

    public Vector2 Normalize()
    {
        float magnitude = Magnitude();
        if (magnitude == 0)
            throw new InvalidOperationException("Cannot normalize a zero vector");
        
        return this / magnitude;
    }
}