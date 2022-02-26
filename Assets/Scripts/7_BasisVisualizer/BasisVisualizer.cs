using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasisVisualizer : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Text infoText;

    [Header("Basis")]
    [SerializeField] private Vector2 i;
    [SerializeField] private Vector2 j;
    [SerializeField] private float x;
    [SerializeField] private float y;

    private Vector2 origin => transform.position;
    private const float vectorThickness = 5.0f;

    private void OnDrawGizmos() 
    {
        var v = (x*i) + (y*j);
        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVector(origin, v, vectorThickness);

        Gizmos.color = Color.red;
        GizmosUtils.DrawVector(origin, i);
        Gizmos.color = Color.green;
        GizmosUtils.DrawVector(origin, j);

        infoText.text = $"v = ({v.x}, {v.y})\ni = ({i.x}, {i.y})\nj = ({j.x}, {j.y})\nLD = {AreLinearDependent()}";
    }

    private bool AreLinearDependent()
    {
        var isI = j == i*(i.y/j.y);
        var isJ = i == j*(i.x/j.x);
        return isI || isJ;
    }
}
