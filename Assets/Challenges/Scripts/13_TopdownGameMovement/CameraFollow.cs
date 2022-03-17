using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 arm;

    private void LateUpdate()
    {
        var targetPos = target.position + arm;
        transform.position = targetPos;
    }
}
