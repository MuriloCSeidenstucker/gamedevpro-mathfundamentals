using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class LineEquation : MonoBehaviour
{
    [SerializeField] private Transform a;
    [SerializeField] private Transform b;
    [SerializeField] private Text equationLine;

    private float tangent;
    private float c;
    private float angle;

    private void Update() 
    {
        CalculateEquationOfLine();
    }

    private void LateUpdate() 
    {
        equationLine.text = $"y = {tangent}x + {c} (Angle => {angle})";
    }

    private void CalculateEquationOfLine()
    {
        var oppositeSide = b.position.y - a.position.y;
        var adjacentSide = b.position.x - a.position.x;
        tangent = oppositeSide / adjacentSide;
        c = -tangent * a.position.x + a.position.y;

        CalculateAngle(oppositeSide, adjacentSide);
    }

    private void CalculateAngle(float oppositeSide, float adjacentSide)
    {
        var hypotenuse = Mathf.Sqrt(oppositeSide * oppositeSide + adjacentSide * adjacentSide);
        var sinAngle = oppositeSide / hypotenuse;
        angle = Mathf.Asin(sinAngle) * Mathf.Rad2Deg;
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(a.position, 0.1f);
        Gizmos.DrawSphere(b.position, 0.1f);

        Gizmos.DrawLine(a.position, b.position);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(a.position, new Vector2(b.position.x, a.position.y));
    }
}
