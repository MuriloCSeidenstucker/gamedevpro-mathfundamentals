using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MyPlane
{
    public Vector3 P1;
    public Vector3 P2;
    public Vector3 P3;
    public Vector3 V;
    public Vector3 W;

    public MyPlane(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        P1 = p1;
        P2 = p2;
        P3 = p3;

        V = P2 - P1;
        W = P3 - P1;
    }

    public Vector3 Normal => Vector3.Cross(V, W).normalized;
    public float distFromOrigin => Vector3.Dot(Normal, P1);

    public bool IsInFront(Vector3 point)
    {
        var dot = Vector3.Dot(point, Normal);
        return (dot - distFromOrigin) > 0;
    }

    public Vector3 ProjectPoint(Vector3 anyPoint, Vector3 pointInPlane, out Vector3 projVN)
    {
        var v = anyPoint - pointInPlane;
        var projectVector = ProjectVector(v, out var projectVN);
        projVN = projectVN;
        return pointInPlane + projectVector;
    }

    public Vector3 ProjectVector(Vector3 v, out Vector3 projectVN)
    {
        projectVN = (Vector3.Dot(Normal, v) * Normal);
        return v - projectVN;
    }
}
