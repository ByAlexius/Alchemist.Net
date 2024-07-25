namespace Alchemist.Net.Math;

public class Quaternion(float x, float y, float z, float w)
{
    public float X { get; set; } = x;
    public float Y { get; set; } = y;
    public float Z { get; set; } = z;
    public float W { get; set; } = w;

        public static Quaternion operator +(Quaternion q1, Quaternion q2)
    {
        return new Quaternion(q1.X + q2.X, q1.Y + q2.Y, q1.Z + q2.Z, q1.W + q2.W);
    }

    public static Quaternion operator *(Quaternion q, float scalar)
    {
        return new Quaternion(q.X * scalar, q.Y * scalar, q.Z * scalar, q.W * scalar);
    }

    public static Quaternion operator *(Quaternion q1, Quaternion q2)
    {
        return new Quaternion(
            q1.W * q2.X + q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y,
            q1.W * q2.Y - q1.X * q2.Z + q1.Y * q2.W + q1.Z * q2.X,
            q1.W * q2.Z + q1.X * q2.Y - q1.Y * q2.X + q1.Z * q2.W,
            q1.W * q2.W - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z
        );
    }

    public static Quaternion FromEulerAngles(float pitch, float yaw, float roll)
    {
        float c1 = (float)System.Math.Cos(yaw / 2);
        float c2 = (float)System.Math.Cos(pitch / 2);
        float c3 = (float)System.Math.Cos(roll / 2);

        float s1 = (float)System.Math.Sin(yaw / 2);
        float s2 = (float)System.Math.Sin(pitch / 2);
        float s3 = (float)System.Math.Sin(roll / 2);

        return new Quaternion(
            s1 * c2 * c3 + c1 * s2 * s3,
            c1 * s2 * c3 - s1 * c2 * s3,
            c1 * c2 * s3 + s1 * s2 * c3,
            c1 * c2 * c3 - s1 * s2 * s3
        );
    }

    public static Quaternion Slerp(Quaternion q1, Quaternion q2, float t)
    {
        float dot = q1.X * q2.X + q1.Y * q2.Y + q1.Z * q2.Z + q1.W * q2.W;

        if (dot < 0.0f)
        {
            q2 = q2 * -1.0f;
            dot = -dot;
        }

        const float epsilon = 1e-6f;

        if (dot > 1.0f - epsilon)
        {
            return new Quaternion(
                q1.X + t * (q2.X - q1.X),
                q1.Y + t * (q2.Y - q1.Y),
                q1.Z + t * (q2.Z - q1.Z),
                q1.W + t * (q2.W - q1.W)
            ).Normalize();
        }

        float theta0 = (float)System.Math.Acos(dot);
        float theta = theta0 * t;

        float sinTheta = (float)System.Math.Sin(theta);
        float sinTheta0 = (float)System.Math.Sin(theta0);

        float s0 = (float)System.Math.Cos(theta) - dot * sinTheta / sinTheta0;
        float s1 = sinTheta / sinTheta0;

        return (q1 * s0) + (q2 * s1);
    }

    public float Magnitude()
    {
        return (float)System.Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
    }

    public Quaternion Normalize()
    {
        float magnitude = Magnitude();
        if (magnitude == 0)
            throw new InvalidOperationException("Cannot normalize a zero quaternion");

        return this * (1.0f / magnitude);
    }

    public Matrix4x4 ToRotationMatrix()
    {
        float xx = X * X;
        float xy = X * Y;
        float xz = X * Z;
        float xw = X * W;

        float yy = Y * Y;
        float yz = Y * Z;
        float yw = Y * W;

        float zz = Z * Z;
        float zw = Z * W;

        return new Matrix4x4(
            1 - 2 * (yy + zz), 2 * (xy - zw), 2 * (xz + yw), 0,
            2 * (xy + zw), 1 - 2 * (xx + zz), 2 * (yz - xw), 0,
            2 * (xz - yw), 2 * (yz + xw), 1 - 2 * (xx + yy), 0,
            0, 0, 0, 1
        );
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z}, {W})";
    }
}