using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineEquation : MonoBehaviour
{
    [SerializeField] private Transform a;
    [SerializeField] private Transform b;
    [SerializeField] private Text equationLine;
    private Vector2 A => a.position;
    private Vector2 B => b.position;
    private const float pointSize = 0.1f;

    private void CalculateEquationOfLine(out float m, out float c)
    {
        m = (B.y - A.y) / (B.x - A.x);
        c = -m * A.x + A.y;
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(A, pointSize);
        Gizmos.DrawSphere(B, pointSize);
        Gizmos.DrawLine(A, B);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(A, new Vector2(B.x, A.y));

        CalculateEquationOfLine(out var m, out var c);
        var angle = Mathf.Atan(m) * Mathf.Rad2Deg;
        equationLine.text = $"y = {m}x + {c} (Angle => {angle})";
    }
}
