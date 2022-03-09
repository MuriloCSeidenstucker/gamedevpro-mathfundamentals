using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneVisualizer : MonoBehaviour
{
    [SerializeField] private MyPlane myPlane;

    private Vector3 v => myPlane.P3 - myPlane.P1;
    private Vector3 w => myPlane.P2 - myPlane.P1;
    private Vector3 Origin => transform.position;

    private const float radiusSphere = 0.1f;
    private const float vectorThickness = 1.0f;

    private void OnDrawGizmos() 
    {
        var n = Vector3.Cross(v, w).normalized;

        var projectP1N = (Vector3.Dot(myPlane.P1, n) * n);


        Gizmos.color = Color.magenta;
        GizmosUtils.DrawVector(myPlane.P1, n, vectorThickness);

        Gizmos.color = Color.white;
        Gizmos.DrawSphere(myPlane.P1, radiusSphere);
        Gizmos.DrawSphere(myPlane.P2, radiusSphere);
        Gizmos.DrawSphere(myPlane.P3, radiusSphere);
        GizmosUtils.DrawVector(Origin, projectP1N, vectorThickness);

        GizmosUtils.DrawPlane(n, projectP1N, Vector2.one*10);
        DrawBase();
    }

    private void DrawBase()
    {
        Gizmos.color = Color.red;
        GizmosUtils.DrawVector(Origin, Vector3.right);
        Gizmos.color = Color.green;
        GizmosUtils.DrawVector(Origin, Vector3.up);
        Gizmos.color = Color.blue;
        GizmosUtils.DrawVector(Origin, Vector3.forward);
    }
}
