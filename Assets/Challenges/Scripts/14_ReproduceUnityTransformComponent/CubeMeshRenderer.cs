using UnityEngine;

[RequireComponent(typeof(CubeMesh), typeof(TransformComponent))]
public class CubeMeshRenderer : MonoBehaviour
{
    private CubeMesh mesh;
    private CubeMesh Mesh => mesh == null ? (mesh = GetComponent<CubeMesh>()) : mesh;

    private TransformComponent transformComponent;
    private TransformComponent TransformComponent => transformComponent == null ? (transformComponent = GetComponent<TransformComponent>()) : transformComponent;

    private Vector3[] transformedMeshPoints = new Vector3[8];

    private void OnDrawGizmos()
    {
        TransformComponent.DrawBaseVectors();

        System.Array.Copy(Mesh.Points, transformedMeshPoints, Mesh.Points.Length);
        for (int i = 0; i < transformedMeshPoints.Length; i++)
        {
            transformedMeshPoints[i] = TransformComponent.TransformPoint(transformedMeshPoints[i]);
        }
        
        Gizmos.color = Mesh.Color;
        SimpleRenderer.DrawCube(transformedMeshPoints);
    }
}
