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
    private Vector3 LeftDir => Quaternion.Euler(0, -angle * 0.5f, 0) * transform.forward;
    private Vector3 RightDir => Quaternion.Euler(0, angle * 0.5f, 0) * transform.forward;

    private void OnDrawGizmos() 
    {
        Gizmos.color = CanSeeTarget(Player) ? Color.green : Color.white;
        Gizmos.DrawWireSphere(Origin, radius);
        Gizmos.DrawRay(Origin, LeftDir * radius);
        Gizmos.DrawRay(Origin, RightDir * radius);

    }

    private bool CanSeeTarget(Vector3 target)
    {
        var v = Origin + RightDir * radius;
        var w = Origin + LeftDir * radius;

        if (target.magnitude > v.magnitude)
        {
            return false;
        }

        var dotTV = DotProduct(target, v);
        var dotTW = DotProduct(target, w);
        if (dotTV < 0 && dotTW < 0)
        {
            return false;
        }

        var cosPV = FindCosine(target, v);
        var cosPW = FindCosine(target, w);
        var cosVW = FindCosine(v, w);

        return cosPV >= cosVW && cosPW >= cosVW;
    }

    private float DotProduct(Vector3 v, Vector3 w)
    {
        return (v.x * w.x) + (v.y * w.y) + (v.z * w.z);
    }

    private float FindCosine(Vector3 v, Vector3 w)
    {
        var dotVW = DotProduct(v, w);
        return dotVW / (v.magnitude * w.magnitude);
    }
}
