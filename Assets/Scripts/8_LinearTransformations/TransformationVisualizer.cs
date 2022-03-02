using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformationVisualizer : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Text infoText;

    [Space]
    [SerializeField] private Vector2 v;
    [SerializeField] private Matrix2x2[] matrices;

    private const float vectorThickness = 5.0f;

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, Vector3.right*10);
        Gizmos.DrawLine(transform.position, Vector3.up*10);

        var r = Matrix2x2.MatrixMultiplier(matrices, v, out var mR);

        Gizmos.color = Color.red;
        GizmosUtils.DrawVector(transform.position, new Vector2(mR.IX, mR.IY));
        Gizmos.color = Color.green;
        GizmosUtils.DrawVector(transform.position, new Vector2(mR.JX, mR.JY));
        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVector(transform.position, r, vectorThickness, false);

        infoText.text = $"v = ({r.x}, {r.y})\n{mR.IX} {mR.JX}\n{mR.IY} {mR.JY}";
    }
}
