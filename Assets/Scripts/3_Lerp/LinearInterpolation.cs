using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearInterpolation : MonoBehaviour
{
    [SerializeField] private Transform a;
    [SerializeField] private Transform b;
    [Range(-1, 2)]
    [SerializeField] private float t;
    private Vector2 A => a.position;
    private Vector2 B => b.position;
    private float xt;
    private float yt;
    private const float pointSize = 0.1f;

    private Vector2 CalculateLerp(float t)
    {
        xt = A.x + (B.x - A.x) * t;
        yt = A.y + (B.y - A.y) * t;

        return new Vector2(xt, yt);
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(A, new Vector2(A.x, B.y));
        Gizmos.DrawLine(A, new Vector2(B.x, A.y));
        Gizmos.DrawLine(A, CalculateLerp(-1));
        Gizmos.DrawLine(B, CalculateLerp(2));

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(A, pointSize);
        Gizmos.DrawSphere(B, pointSize);
        Gizmos.DrawLine(A, B);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(CalculateLerp(t), pointSize);

        Gizmos.color = Color.gray;
        Gizmos.DrawSphere(new Vector2(xt, A.y), pointSize);
        Gizmos.DrawSphere(new Vector2(A.x, yt), pointSize);
    }
}
