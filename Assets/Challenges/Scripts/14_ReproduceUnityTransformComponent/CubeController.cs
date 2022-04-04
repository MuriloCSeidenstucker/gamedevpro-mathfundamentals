using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TransformComponent))]
public class CubeController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float acceleration;

    private TransformComponent transf;
    private Vector3 Velocity;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";

    private void Awake()
    {
        transf =  GetComponent<TransformComponent>();
    }

    private void Update()
    {
        var xAxis = Input.GetAxisRaw(horizontal);
        var zAxis = Input.GetAxisRaw(vertical);

        var targetVelocity = new Vector3(xAxis, 0, zAxis) * moveSpeed;

        Velocity = Vector3.Lerp(Velocity, targetVelocity, acceleration * Time.deltaTime);

        var frameMovement = Velocity * Time.deltaTime;
        transf.Position += frameMovement;
        if (Velocity != Vector3.zero)
        {
            transf.Rotation = Quaternion.LookRotation(Velocity, transf.Up);
        }
    }
}
