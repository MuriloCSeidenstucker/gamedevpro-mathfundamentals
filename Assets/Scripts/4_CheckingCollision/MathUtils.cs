using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathUtils
{
    public static Vector2 LerpUnclamped(Vector2 start, Vector2 end, float t)
    {
        return start + (end - start) * t;
    }

    public static float InverseLerp(Vector2 start, Vector2 end, Vector2 point)
    {
        return (point.x - start.x) / (end.x - start.x);
    }

    public static bool TwoLinesIntersection(Vector2 s1, Vector2 e1, Vector2 s2, Vector2 e2, out Vector2 intersection)
    {
        var m1 = (e1.y - s1.y) / (e1.x - s1.x);
        var m2 = (e2.y - s2.y) / (e2.x - s2.x);

        if (Mathf.Approximately(m1, m2))
        {
            intersection = Vector2.zero;
            return false;
        }

        var c1 = -m1 * s1.x + s1.y;
        var c2 = -m2 * s2.x  + s2.y;

        var intersectX = (c2 - c1) / (m1 - m2);
        var intersectY = m1 * intersectX + c1;

        intersection = new Vector2(intersectX, intersectY);
        return true;
    }
}
