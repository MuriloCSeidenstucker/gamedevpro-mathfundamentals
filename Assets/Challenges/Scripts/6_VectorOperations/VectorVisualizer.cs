using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum Operations
{
    None,
    Add,
    Scale,
    Normalize
}

public class VectorVisualizer : MonoBehaviour
{
    [Header("UI Text")]
    [SerializeField] private Text valuesText;

    [Header("Values")]
    [SerializeField] private MyVector3 v;
    [SerializeField] private MyVector3 w;
    [SerializeField] private float a;
    
    [Space]
    [SerializeField] private Operations operation;

    private MyVector3 origin => (MyVector3)transform.position;
    private const float vectorThickness = 5.0f;

    private void OnDrawGizmos()
    {
        DrawVector(origin, v, Color.yellow);

        switch (operation)
        {
            case Operations.None:
                DrawVectorsMontage();
                break;
            case Operations.Add:
                DrawVectorSum();
                break;
            case Operations.Scale:
                DrawVectorScale();
                break;
            case Operations.Normalize:
                DrawVectorNormalized();
                break;
            default:
                Debug.LogError($"Operação {operation} escolhida é inválida!");
                break;
        }

        DrawCoordinates();
    }

    private void DrawVectorsMontage()
    {
        var projX = new MyVector3(v.X, 0, 0);
        var projY = new MyVector3(0, v.Y, 0);
        var projZ = new MyVector3(0, 0, v.Z);

        Gizmos.color = Color.blue;
        GizmosUtils.DrawVector(projX, projZ, 1, false);
        Gizmos.color = Color.red;
        GizmosUtils.DrawVector(projZ, projX, 1, false);
        Gizmos.color = Color.green;
        GizmosUtils.DrawVector(projX + projZ, projY, 1, false);
        valuesText.text = $"{v.Magnitude}";
    }

    private void DrawVectorSum()
    {
        var r = v + w;
        DrawVector(v, w, Color.gray);
        DrawVector(origin, r, Color.cyan);
        valuesText.text = $"Result (x: {r.X}, y: {r.Y}, z: {r.Z})";
    }

    private void DrawVectorScale()
    {
        var r = v * a;
        DrawVector(origin, r, Color.cyan);
        valuesText.text = $"Scaled Magnitude: {r.Magnitude}";
    }

    private void DrawVectorNormalized()
    {
        var r = v.Normalize;
        DrawVector(origin, r, Color.cyan);
        valuesText.text = $"Normalize Magnitude: {r.Magnitude}";
    }

    private void DrawVector(MyVector3 from, MyVector3 to, Color color)
    {
        Gizmos.color = color;
        GizmosUtils.DrawVector(from, to, vectorThickness);
    }

    private void DrawCoordinates()
    {
        var lineScale = 5;
        float sizeCube = 0.1f;

        Gizmos.color = Color.white;
        Gizmos.DrawLine(origin, MyVector3.Right * lineScale*2);
        Gizmos.DrawLine(origin, MyVector3.Up * lineScale*2);
        Gizmos.DrawLine(origin, MyVector3.Forward * lineScale*2);

        Gizmos.color = Color.red;
        GizmosUtils.DrawVector(origin, MyVector3.Right * lineScale);
        Gizmos.color = Color.green;
        GizmosUtils.DrawVector(origin, MyVector3.Up * lineScale);
        Gizmos.color = Color.blue;
        GizmosUtils.DrawVector(origin, MyVector3.Forward * lineScale);
        Gizmos.color = Color.gray;
        Gizmos.DrawCube(origin, MyVector3.One * sizeCube);
    }
}
