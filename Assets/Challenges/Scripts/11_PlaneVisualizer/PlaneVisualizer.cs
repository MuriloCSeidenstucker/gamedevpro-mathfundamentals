using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlaneOperations
{
    None, IsInFront, ProjectPoint, ProjectVector
}

public class PlaneVisualizer : MonoBehaviour
{
    [SerializeField] private Vector3 p1;
    [SerializeField] private Vector3 p2;
    [SerializeField] private Vector3 p3;
    [SerializeField] private Vector3 point;
    [SerializeField] private PlaneOperations operations;

    private Vector3 Origin => transform.position;
    private MyPlane myPlane;

    private const float radiusSphere = 0.1f;
    private const float vectorThickness = 1.0f;

    private void OnDrawGizmos() 
    {
        myPlane = new MyPlane(p1, p2, p3);
        var n = myPlane.Normal;

        var projectP1N = (Vector3.Dot(myPlane.P1, n) * n);

        switch (operations)
        {
            case PlaneOperations.IsInFront:
                Gizmos.color = myPlane.IsInFront(point) ? Color.green : Color.red;
                Gizmos.DrawSphere(point, radiusSphere);
                break;
            case PlaneOperations.ProjectPoint:
                ProjectPoint();
                break;
            case PlaneOperations.ProjectVector:
                ProjectVector();
                break;
            default:
                break;
        }

        Gizmos.color = Color.magenta;
        GizmosUtils.DrawVector(p1, n, vectorThickness);

        Gizmos.color = Color.white;
        Gizmos.DrawSphere(p1, radiusSphere);
        Gizmos.DrawSphere(p2, radiusSphere);
        Gizmos.DrawSphere(p3, radiusSphere);
        GizmosUtils.DrawVector(Origin, projectP1N, vectorThickness);

        GizmosUtils.DrawPlane(n, projectP1N, Vector2.one*10);
        DrawCoordinates();
    }

    private void ProjectPoint()
    {
        var q = myPlane.ProjectPoint(point, p1, out var projectVN);
        Gizmos.color = Color.white;
        Gizmos.DrawRay(point, -projectVN);
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(point, radiusSphere);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(q, radiusSphere);
        GizmosUtils.DrawVector(Origin, q, vectorThickness);
    }

    private void ProjectVector()
    {
        var projectV = myPlane.ProjectVector(point, out var projectVN);
        Gizmos.color = Color.white;
        Gizmos.DrawRay(point + p1, -projectVN);
        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVector(p1, point, vectorThickness);
        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVector(p1, projectV, vectorThickness);
    }

    private void DrawCoordinates()
    {
        Gizmos.color = Color.red;
        GizmosUtils.DrawVector(Origin, Vector3.right);
        Gizmos.color = Color.green;
        GizmosUtils.DrawVector(Origin, Vector3.up);
        Gizmos.color = Color.blue;
        GizmosUtils.DrawVector(Origin, Vector3.forward);
    }
}
