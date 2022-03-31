using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixRotation : MeshTransformation
{
    [SerializeField] private Vector3 rotation;

    public override void TransformPoints(Vector3[] points)
    {
        var rotY = RotateMatrixY();
        var rotX = RotateMatrixX();
        var rotZ = RotateMatrixZ();
        var matrixRot = rotY * rotX * rotZ;

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = matrixRot * points[i];
        }
    }

    private Matrix3x3 RotateMatrixY()
    {
        var sin = Mathf.Sin(rotation.y * Mathf.Deg2Rad);
        var cos = Mathf.Cos(rotation.y * Mathf.Deg2Rad);
        var matrix = new Matrix3x3(
            cos, 0, sin,
            0, 1, 0,
            -sin, 0, cos
        );
        return matrix;
    }

    private Matrix3x3 RotateMatrixX()
    {
        var sin = Mathf.Sin(rotation.x * Mathf.Deg2Rad);
        var cos = Mathf.Cos(rotation.x * Mathf.Deg2Rad);
        Matrix3x3 matrix = new Matrix3x3(
            1, 0, 0,
            0, cos, -sin,
            0, sin, cos
        );
        return matrix;
    }

    private Matrix3x3 RotateMatrixZ()
    {
        var sin = Mathf.Sin(rotation.z * Mathf.Deg2Rad);
        var cos = Mathf.Cos(rotation.z * Mathf.Deg2Rad);
        Matrix3x3 matrix = new Matrix3x3(
            cos, -sin, 0,
            sin, cos, 0,
            0, 0, 1
        );
        return matrix;
    }
}
