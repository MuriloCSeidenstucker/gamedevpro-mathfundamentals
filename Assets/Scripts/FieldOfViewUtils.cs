using UnityEngine;

public static class FieldOfViewUtils
{
    public static bool IsInsideFieldOfView(Vector2 fovOrigin, Vector2 target, float viewDistance, float viewAngle)
    {
        if (target.y < fovOrigin.y)
        {
            return false;
        }

        var xAxisSide = fovOrigin.x - target.x;
        var yAxisSide = fovOrigin.y - target.y;
        var targetDist = Mathf.Sqrt(xAxisSide * xAxisSide + yAxisSide * yAxisSide);

        if (targetDist > viewDistance)
        {
            return false;
        }

        var oppositeSideTargetAngle = Mathf.Abs(target.x - fovOrigin.x);
        var sinTargetAngle = oppositeSideTargetAngle / targetDist;
        var sinHalfViewAngle = Mathf.Sin(Mathf.Deg2Rad * viewAngle * 0.5f);

        return sinTargetAngle <= sinHalfViewAngle;
    }
}
