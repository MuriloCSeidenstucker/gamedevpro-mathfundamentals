using UnityEngine;

public class TransformComponent : MonoBehaviour
{
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private Vector3 scale = Vector3.one;

    [Space]
    [Space]
    [SerializeField]
    private Quaternion quaternionRotation;
    
    private Matrix4x4 modelMatrix;

    public Vector3 Position
    {
        get => position;
        set
        {
            position = value;
            UpdateModelMatrix();
        }
    }

    public Quaternion Rotation
    {
        get => quaternionRotation;
        set
        {
            quaternionRotation = value;
            rotation = quaternionRotation.eulerAngles;
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

    public Vector3 Right => quaternionRotation * Vector3.right;
    public Vector3 Up => quaternionRotation * Vector3.up;
    public Vector3 Forward => quaternionRotation * Vector3.forward;

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
        GizmosUtils.DrawVector(position, Right, 1);
        Gizmos.color = Color.green;
        GizmosUtils.DrawVector(position, Up, 1);
        Gizmos.color = Color.blue;
        GizmosUtils.DrawVector(position, Forward, 1);
    }

    private void UpdateModelMatrix()
    {
        var scaleMatrix = new Matrix4x4(
            new Vector4(scale.x, 0, 0, 0),
            new Vector4(0, scale.y, 0, 0),
            new Vector4(0, 0, scale.z, 0),
            new Vector4(0, 0, 0, 1));

        quaternionRotation = Quaternion.Euler(rotation);
        var rotationMatrix = Matrix4x4.Rotate(quaternionRotation);

        var translationMatrix = new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(position.x, position.y, position.z, 1));

        modelMatrix = translationMatrix * rotationMatrix * scaleMatrix;
    }

    private void OnValidate()
    {
        UpdateModelMatrix();
    }
}
