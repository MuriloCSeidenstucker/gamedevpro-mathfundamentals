using UnityEngine;

public static class FieldOfViewUtils
{
    public static bool IsInsideFieldOfView(Vector2 fovOrigin, Vector2 target, float viewDistance, float viewAngle)
    {
        var adjacent = fovOrigin.x - target.x;
        var opposite = fovOrigin.y - target.y;

        var distAB = Mathf.Sqrt(Mathf.Pow(adjacent, 2) + Mathf.Pow(opposite, 2));

        var isInsideRadiusOfView = distAB <= viewDistance;
        if (isInsideRadiusOfView)
        {
            return true;
        }

        return false;
    }
}
