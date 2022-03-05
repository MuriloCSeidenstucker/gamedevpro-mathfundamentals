using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateSystemVisualizer : MonoBehaviour
{
    [SerializeField] private Vector3 v;
    [SerializeField] private Vector3 w;

    private Vector3 Origin => transform.position;

    private const float vectorThickness = 2.0f;

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVector(Origin, v, vectorThickness);
        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVector(Origin, w, vectorThickness);
    }
}
