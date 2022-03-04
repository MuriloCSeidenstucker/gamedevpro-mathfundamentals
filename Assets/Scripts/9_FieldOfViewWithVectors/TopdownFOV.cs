using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopdownFOV : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float angle;

    private void OnDrawGizmos() 
    {
        var leftDir = Quaternion.Euler(0, -angle * 0.5f, 0) * transform.forward;
        var rightDir = Quaternion.Euler(0, angle * 0.5f, 0) * transform.forward;

        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawRay(transform.position, leftDir * radius);
        Gizmos.DrawRay(transform.position, rightDir * radius);
    }
}
