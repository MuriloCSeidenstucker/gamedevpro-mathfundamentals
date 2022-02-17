using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearInterpolation : MonoBehaviour
{
    [SerializeField] private Transform a;
    [SerializeField] private Transform b;
    [Range(-1, 2)]
    [SerializeField] private float t;

    private Vector2 CalculateLerp(float t)
    {
        var xt = a.position.x + (b.position.x - a.position.x) * t;
        var yt = a.position.y + (b.position.y - a.position.y) * t;

        return new Vector2(xt, yt);
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(a.position, new Vector2(a.position.x, b.position.y));
        Gizmos.DrawLine(a.position, new Vector2(b.position.x, a.position.y));
        Gizmos.DrawLine(a.position, CalculateLerp(-1));
        Gizmos.DrawLine(b.position, CalculateLerp(2));

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(a.position, 0.1f);
        Gizmos.DrawSphere(b.position, 0.1f);
        Gizmos.DrawLine(a.position, b.position);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(CalculateLerp(t), 0.1f);
    }
}
