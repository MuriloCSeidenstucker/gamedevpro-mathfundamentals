using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopdownFOV : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float angle;
    [SerializeField] private Transform player;
    [SerializeField] private Transform sprite;

    private Vector3 Player => player.position;
    private Vector3 Origin => transform.position;

    public bool CanSeeTarget(Vector3 target)
    {
        var toTarget = target - Origin;

        if (toTarget.sqrMagnitude > radius * radius)
        {
            return false;
        }

        var dot = Vector3.Dot(toTarget, sprite.forward);
        if (dot <  0)
        {
            return false;
        }

        var cos = dot / (toTarget.magnitude * sprite.forward.magnitude);
        var angleToTarget = Mathf.Acos(cos) * Mathf.Rad2Deg;

        return angleToTarget <= (angle * 0.5f);
    }

    private void OnDrawGizmos() 
    {
        var leftDir = Quaternion.Euler(0, -angle * 0.5f, 0) * sprite.forward;
        var rightDir = Quaternion.Euler(0, angle * 0.5f, 0) * sprite.forward;

        Gizmos.color = CanSeeTarget(Player) ? Color.red : Color.white;
        Gizmos.DrawWireSphere(Origin, radius);
        Gizmos.DrawRay(Origin, leftDir.normalized * radius);
        Gizmos.DrawRay(Origin, rightDir.normalized * radius);
    }
}
