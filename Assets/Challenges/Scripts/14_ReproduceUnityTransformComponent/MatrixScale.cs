using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixScale : MeshTransformation
{
    [SerializeField] private Vector3 scale = Vector3.one;

    public Matrix3x3 Scale => new Matrix3x3(
        scale.x, 0, 0,
        0, scale.y, 0,
        0, 0, scale.z
    );

    public override void TransformPoints(Vector3[] points)
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = Scale * points[i];
        }
    }
}
