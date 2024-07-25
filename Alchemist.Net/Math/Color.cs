namespace Alchemist.Net.Math;

public class Color(byte r, byte g, byte b, byte a = 255)
{
    public byte R { get; set; } = r;
    public byte G { get; set; } = g;
    public byte B { get; set; } = b;
    public byte A { get; set; } = a;

    public static Color operator +(Color c1, Color c2)
    {
        return new Color(
            (byte)System.Math.Clamp(c1.R + c2.R, 0, 255),
            (byte)System.Math.Clamp(c1.G + c2.G, 0, 255),
            (byte)System.Math.Clamp(c1.B + c2.B, 0, 255),
            (byte)System.Math.Clamp(c1.A + c2.A, 0, 255)
        );
    }

    public static Color operator *(Color c, float scalar)
    {
        return new Color(
            (byte)System.Math.Clamp(c.R * scalar, 0, 255),
            (byte)System.Math.Clamp(c.G * scalar, 0, 255),
            (byte)System.Math.Clamp(c.B * scalar, 0, 255),
            (byte)System.Math.Clamp(c.A * scalar, 0, 255)
        );
    }

    public static Color Lerp(Color c1, Color c2, float t)
    {
        return new Color(
            (byte)(c1.R + (c2.R - c1.R) * t),
            (byte)(c1.G + (c2.G - c1.G) * t),
            (byte)(c1.B + (c2.B - c1.B) * t),
            (byte)(c1.A + (c2.A - c1.A) * t)
        );
    }

    public override string ToString()
    {
        return $"RGBA({R}, {G}, {B}, {A})";
    }
}