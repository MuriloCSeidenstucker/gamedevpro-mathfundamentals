using UnityEngine;

public class TransformComponent : MonoBehaviour
{
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private Vector3 scale = Vector3.one;
    
    private Matrix4x4 modelMatrix;
    private Matrix4x4 rotationMatrix;

    public Vector3 Position
    {
        get => position;
        set
        {
            position = value;
            UpdateModelMatrix();
        }
    }

    public Vector3 Rotation
    {
        get => rotation;
        set
        {
            rotation = value;
            UpdateModelMatrix();
        }
    }

    public Vector3 Scale
    {
        get => scale;
        set
        {
            scale = value;
            UpdateModelMatrix();
        }
    }

    public Vector3 Right => rotationMatrix * Vector3.right;
    public Vector3 Up => rotationMatrix * Vector3.up;
    public Vector3 Forward => rotationMatrix * Vector3.forward;

    private void Awake()
    {
        UpdateModelMatrix();
    }

    public Vector3 TransformPoint(in Vector3 point)
    {
        return modelMatrix.MultiplyPoint(point);
    }

    public void DrawBaseVectors()
    {
        Gizmos.color = Color.red;
        GizmosUtils.DrawVector(Position, Right, 1);
        Gizmos.color = Color.green;
        GizmosUtils.DrawVector(Position, Up, 1);
        Gizmos.color = Color.blue;
        GizmosUtils.DrawVector(Position, Forward, 1);
    }

    private void UpdateModelMatrix()
    {
        var scaleMatrix = new Matrix4x4(
            new Vector4(scale.x, 0, 0, 0),
            new Vector4(0, scale.y, 0, 0),
            new Vector4(0, 0, scale.z, 0),
            new Vector4(0, 0, 0, 1));

        var rotY = RotateMatrixY();
        var rotX = RotateMatrixX();
        var rotZ = RotateMatrixZ();
        rotationMatrix = rotY * rotX * rotZ;

        var translationMatrix = new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(position.x, position.y, position.z, 1));

        modelMatrix = translationMatrix * rotationMatrix * scaleMatrix;
    }

    private Matrix4x4 RotateMatrixY()
    {
        var sinY = Mathf.Sin(rotation.y * Mathf.Deg2Rad);
        var cosY = Mathf.Cos(rotation.y * Mathf.Deg2Rad);

        var matrix = new Matrix4x4(
            new Vector4(cosY, 0, -sinY, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(sinY, 0, cosY, 0),
            new Vector4(0, 0, 0, 1));

        return matrix;
    }

    private Matrix4x4 RotateMatrixX()
    {
        var sinX = Mathf.Sin(rotation.x * Mathf.Deg2Rad);
        var cosX = Mathf.Cos(rotation.x * Mathf.Deg2Rad);

        Matrix4x4 matrix = new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, cosX, sinX, 0),
            new Vector4(0, -sinX, cosX, 0),
            new Vector4(0, 0, 0, 1));

        return matrix;
    }

    private Matrix4x4 RotateMatrixZ()
    {
        var sinZ = Mathf.Sin(rotation.z * Mathf.Deg2Rad);
        var cosZ = Mathf.Cos(rotation.z * Mathf.Deg2Rad);

        Matrix4x4 matrix = new  Matrix4x4(
            new Vector4(cosZ, sinZ, 0, 0),
            new Vector4(-sinZ, cosZ, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(0, 0, 0, 1));

        return matrix;
    }

    private void OnValidate()
    {
        UpdateModelMatrix();
    }
}
