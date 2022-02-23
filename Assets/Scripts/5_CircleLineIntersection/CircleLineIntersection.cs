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

    private void OnDrawGizmos() 
    {
        var lineColor = Color.red;

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(Circle, radius);

        Gizmos.color = lineColor;
        Gizmos.DrawLine(StartLine, EndLine);
    }
}
