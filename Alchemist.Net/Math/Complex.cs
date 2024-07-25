namespace Alchemist.Net.Math;

public class Complex(float real, float imaginary)
{
    public float Real { get; set; } = real;
    public float Imaginary { get; set; } = imaginary;

    public static Complex operator +(Complex c1, Complex c2)
    {
        return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
    }

    public static Complex operator -(Complex c1, Complex c2)
    {
        return new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
    }

    public static Complex operator *(Complex c1, Complex c2)
    {
        return new Complex(
            c1.Real * c2.Real - c1.Imaginary * c2.Imaginary,
            c1.Real * c2.Imaginary + c1.Imaginary * c2.Real
        );
    }

    public float Magnitude()
    {
        return (float)System.Math.Sqrt(Real * Real + Imaginary * Imaginary);
    }

    public Complex Conjugate()
    {
        return new Complex(Real, -Imaginary);
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}