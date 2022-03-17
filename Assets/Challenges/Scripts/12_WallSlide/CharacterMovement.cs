using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float acceleration = 100;

    [Header("Collision")]
    [SerializeField] private Vector3 colliderSize;

    private Vector3 targetVelocity;
    public Vector3 Velocity { get; private set; }

    private Vector3 ColliderExtents => colliderSize * 0.5f;

    private RaycastHit[] hits = new RaycastHit[10];

    public void SetInput(float horizontal, float vertical)
    {
        var input = new Vector3(horizontal, 0, vertical);
        targetVelocity = input * moveSpeed;
    }

    private void FixedUpdate()
    {
        Velocity = Vector3.Lerp(Velocity, targetVelocity, Time.fixedDeltaTime * acceleration);
        CheckCollisionHorizontal();
        var targetPos = transform.position + Velocity * Time.fixedDeltaTime;
        transform.position = targetPos;
    }

    private void CheckCollisionHorizontal()
    {
        var rayLength = Velocity.magnitude * Time.fixedDeltaTime;
        var hitCount = Physics.BoxCastNonAlloc(
            transform.position + Vector3.up * ColliderExtents.y,
            ColliderExtents,
            Velocity.normalized,
            hits,
            transform.rotation,
            rayLength);

        for (int i = 0; i < hitCount; i++)
        {
            var hit = hits[i];
            var projectedVelocity = Vector3.ProjectOnPlane(Velocity, hit.normal);
            if (projectedVelocity == Vector3.zero)
            {  
                projectedVelocity = SlideInXZAxis(projectedVelocity, hit.point, hit.collider.bounds);
            }
            Velocity = projectedVelocity.normalized * Velocity.magnitude;
            break;
        }
    }

    private Vector3 SlideInXZAxis(Vector3 velocity, Vector3 reference, Bounds bounds)
    {
        if (Velocity.z != 0)
        {
            if(bounds.max.x - reference.x < 
                reference.x - bounds.min.x)
            {
                return new Vector3(1, velocity.y, velocity.z);
            }
            return new Vector3(-1, velocity.y, velocity.z);
        }
        else
        {
            if (bounds.max.z - reference.z <
                reference.z - bounds.min.z)
            {
                return new Vector3(velocity.x, velocity.y, 1);
            }
            return new Vector3(velocity.x, velocity.y, -1);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + Vector3.up * ColliderExtents.y, colliderSize);
    }
}
