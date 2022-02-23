using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleLineIntersection : MonoBehaviour
{
    [Header("Circle")]
    [SerializeField] private Transform circle;
    [SerializeField] private float radius;

    [Header("Line")]
    [SerializeField] private Transform startLine;
    [SerializeField] private Transform endLine;

    private Vector2 Circle => circle.position;
    private Vector2 StartLine => startLine.position;
    private Vector2 EndLine => endLine.position;

    private const float radiusCircle = 0.1f;

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(Circle, radius);

        var lineColor = Color.red;

        if (MathUtils.CircleLineIntersection(Circle, radius, StartLine, EndLine, out var p1, out var p2))
        {
            Gizmos.color = Color.blue;
            var isP1Valid = MathUtils.IsPointInFiniteLine(StartLine, EndLine, p1);
            var isP2Valid = MathUtils.IsPointInFiniteLine(StartLine, EndLine, p2);
            DrawSphere(p1, isP1Valid);
            DrawSphere(p2, isP2Valid);
            lineColor = isP1Valid || isP2Valid ? Color.green : Color.red;
        }

        Gizmos.color = lineColor;
        Gizmos.DrawLine(StartLine, EndLine);
    }

    private void DrawSphere(Vector3 center, bool isValid)
    {
        if (isValid)
        {
            Gizmos.DrawSphere(center, radiusCircle);
        }
    }
}
