namespace Alchemist.Net.Math;

public class Transform(Vector3 position, Quaternion rotation, Vector3 scale)
{
    public Vector3 Position { get; set; } = position;
    public Quaternion Rotation { get; set; } = rotation;
    public Vector3 Scale { get; set; } = scale;

    public Matrix4x4 GetTransformationMatrix()
    {
        var translationMatrix = new Matrix4x4(
            1, 0, 0, Position.X,
            0, 1, 0, Position.Y,
            0, 0, 1, Position.Z,
            0, 0, 0, 1
        );

        var rotationMatrix = Rotation.ToRotationMatrix();

        var scaleMatrix = new Matrix4x4(
            Scale.X, 0, 0, 0,
            0, Scale.Y, 0, 0,
            0, 0, Scale.Z, 0,
            0, 0, 0, 1
        );

        return translationMatrix * rotationMatrix * scaleMatrix;
    }

    public override string ToString()
    {
        return $"Position: {Position}, Rotation: {Rotation}, Scale: {Scale}";
    }
}