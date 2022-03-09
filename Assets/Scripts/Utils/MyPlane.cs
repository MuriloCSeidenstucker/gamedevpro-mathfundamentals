using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MyPlane
{
    public Vector3 P1;
    public Vector3 P2;
    public Vector3 P3;

    public MyPlane(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        P1 = p1;
        P2 = p2;
        P3 = p3;
    }
}
