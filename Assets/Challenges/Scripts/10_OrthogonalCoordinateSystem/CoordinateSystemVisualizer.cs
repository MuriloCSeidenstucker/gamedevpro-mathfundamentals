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
    private Vector3 copyV;
    private Vector3 copyW;
    private const float vectorThickness = 2.0f;

    private void OnDrawGizmos() 
    {
        copyV = v;
        copyW = w;

        switch (handedness)
        {
            case Handedness.left:
                n = Vector3.Cross(v, w);
                ForceOrthogonalSystem(handedness);
                break;
            case Handedness.right:
                n = Vector3.Cross(w, v);
                ForceOrthogonalSystem(handedness);
                break;
            default:
                Debug.LogError($"Opção {handedness} inválida!");
                break;
        }

        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVector(Origin, copyV, vectorThickness);
        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVector(Origin, copyW, vectorThickness);
        Gizmos.color =  Color.magenta;
        GizmosUtils.DrawVector(Origin, n, vectorThickness);
    }

    private void ForceOrthogonalSystem(Handedness handedness)
    {
        if (forceOrthogonalSystem)
        {
            copyV.Normalize();
            n.Normalize();
            copyW = handedness == Handedness.left ? Vector3.Cross(n, copyV).normalized : Vector3.Cross(copyV, n).normalized;
        }
    }
}
