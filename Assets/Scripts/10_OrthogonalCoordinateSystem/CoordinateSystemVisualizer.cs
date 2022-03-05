using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Handedness
{
    left, right
}

public class CoordinateSystemVisualizer : MonoBehaviour
{
    [SerializeField] private Vector3 v;
    [SerializeField] private Vector3 w;

    [SerializeField] private Handedness handedness;
    [SerializeField] private bool forceOrthogonalSystem;

    private Vector3 Origin => transform.position;
    private Vector3 n;
    private const float vectorThickness = 2.0f;

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.yellow;
        var forcedV = forceOrthogonalSystem ? v.normalized : v;
        GizmosUtils.DrawVector(Origin, forcedV, vectorThickness);
        Gizmos.color = Color.cyan;
        var forcedW = forceOrthogonalSystem ? w.normalized : w;
        GizmosUtils.DrawVector(Origin, forcedW, vectorThickness);

        switch (handedness)
        {
            case Handedness.left:
                n = Vector3.Cross(v, w);
                break;
            case Handedness.right:
                n = Vector3.Cross(w, v);
                break;
            default:
                Debug.LogError($"Opção {handedness} inválida!");
                break;
        }

        Gizmos.color =  Color.magenta;
        var forcedN = forceOrthogonalSystem ? n.normalized : n;
        GizmosUtils.DrawVector(Origin, forcedN, vectorThickness);
    }
}
