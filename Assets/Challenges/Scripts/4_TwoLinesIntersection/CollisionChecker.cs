using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform player;
    [Range(-0.5f, 1.5f)]
    [SerializeField] private float t;

    [Header("Path")]
    [SerializeField] private Transform pathStart;
    [SerializeField] private Transform pathEnd;

    [Header("Wall")]
    [SerializeField] private Transform wallStart;
    [SerializeField] private Transform wallEnd;

    private Vector2 Player => player.position;
    private Vector2 PathStart => pathStart.position;
    private Vector2 PathEnd => pathEnd.position;
    private Vector2 WallStart => wallStart.position;
    private Vector2 WallEnd => wallEnd.position;

    private const float sphereSize = 0.1f;



    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(PathStart, PathEnd);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(WallStart, WallEnd);

        var playerColor = Color.green;
        if (MathUtils.TwoLinesIntersection(PathStart, PathEnd, WallStart, WallEnd, out var intersectionPoint))
        {
            var intersectT = MathUtils.InverseLerp(PathStart, PathEnd, intersectionPoint);
            if (t >= intersectT)
            {
                t = intersectT;
                playerColor = Color.red;
            }
        }

        Gizmos.color = playerColor;
        player.position = MathUtils.LerpUnclamped(PathStart, PathEnd, t);
        Gizmos.DrawSphere(Player, sphereSize);
    }
}
