using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopdownFOV : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float angle;
    [SerializeField] private Transform player;

    private Vector3 Player => player.position;
    private Vector3 Origin => transform.position;

    private void OnDrawGizmos() 
    {
        var leftDir = Quaternion.Euler(0, -angle * 0.5f, 0) * transform.forward;
        var rightDir = Quaternion.Euler(0, angle * 0.5f, 0) * transform.forward;

        Gizmos.color = CanSeeTarget(Player) ? Color.green : Color.white;
        Gizmos.DrawWireSphere(Origin, radius);
        Gizmos.DrawRay(Origin, leftDir.normalized * radius);
        Gizmos.DrawRay(Origin, rightDir.normalized * radius);
    }

    private bool CanSeeTarget(Vector3 target)
    {
        var toTarget = target - Origin;

        if (toTarget.sqrMagnitude > radius * radius)
        {
            return false;
        }

        var dot = Vector3.Dot(toTarget, transform.forward);
        if (dot <  0)
        {
            return false;
        }

        var cos = dot / (toTarget.magnitude * transform.forward.magnitude);
        var angleToTarget = Mathf.Acos(cos) * Mathf.Rad2Deg;

        return angleToTarget <= (angle * 0.5f);
    }
}
