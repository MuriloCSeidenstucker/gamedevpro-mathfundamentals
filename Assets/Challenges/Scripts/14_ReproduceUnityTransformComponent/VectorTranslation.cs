using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTranslation : MeshTransformation
{
    [SerializeField] private Vector3 position;

    public override void TransformPoints(Vector3[] points)
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i] += position;
        }
    }
}
