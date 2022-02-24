using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorVisualizer : MonoBehaviour
{
    private const float sizeCube = 0.1f;

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        GizmosUtils.DrawVector(transform.position, MyVector3.Right*2);
        Gizmos.color = Color.green;
        GizmosUtils.DrawVector(transform.position, MyVector3.Up*2);
        Gizmos.color = Color.blue;
        GizmosUtils.DrawVector(transform.position, MyVector3.Forward*2);

        Gizmos.color = Color.gray;
        Gizmos.DrawCube(transform.position, MyVector3.One*sizeCube);
    }
}
