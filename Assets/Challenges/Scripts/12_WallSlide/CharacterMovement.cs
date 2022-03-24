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
    private Vector3 ColliderHorizontalExtents => new Vector3(ColliderExtents.x, ColliderExtents.y * 0.5f, ColliderExtents.z);

    private RaycastHit[] hits = new RaycastHit[10];
    private float rayLength => Velocity.magnitude * Time.fixedDeltaTime;
    private int hitCount;
    private RaycastHit hit;
    private Vector3 projectedVelocity;

    private void FixedUpdate()
    {
        Velocity = Vector3.MoveTowards(Velocity, targetVelocity, Time.fixedDeltaTime * acceleration);
        CheckCollisionHorizontal();
        var targetPos = transform.position + Velocity * Time.fixedDeltaTime;
        CheckCollisionVertical(ref targetPos);

        transform.position = targetPos;
    }

    public void MoveCharacter(in Vector3 movement)
    {
        targetVelocity = movement * moveSpeed;
    }

    private void CheckCollisionHorizontal()
    {
        hitCount = Physics.BoxCastNonAlloc(
            transform.position + Vector3.up * ColliderExtents.y,
            ColliderHorizontalExtents,
            Velocity.normalized,
            hits,
            transform.rotation,
            rayLength);

        for (int i = 0; i < hitCount; i++)
        {
            hit = hits[i];
            projectedVelocity = Vector3.ProjectOnPlane(Velocity, hit.normal);
            if (projectedVelocity != Vector3.zero)
            {
                var finalVeloc = new Vector3(projectedVelocity.x, 0, projectedVelocity.z);
                Velocity = finalVeloc.normalized * Velocity.magnitude;
                break;
            }

            var rightAmount = CheckMinorDirection(iterations: 5, angle: 15.0f);
            var leftAmount = CheckMinorDirection(iterations: 5, angle: -15.0f);

            if (rightAmount <= leftAmount)
            {
                var rightVeloc = Quaternion.Euler(0, 1, 0) * Velocity.normalized;
                projectedVelocity = Vector3.ProjectOnPlane(rightVeloc, hit.normal);
                if (projectedVelocity != Vector3.zero)
                {
                    var finalVeloc = new Vector3(projectedVelocity.x, 0, projectedVelocity.z);
                    Velocity = finalVeloc.normalized * Velocity.magnitude;
                    break;
                }
            }
            var leftVeloc = Quaternion.Euler(0, -1, 0) * Velocity.normalized;
            projectedVelocity = Vector3.ProjectOnPlane(leftVeloc, hit.normal);
            if (projectedVelocity != Vector3.zero)
            {
                var finalVeloc = new Vector3(projectedVelocity.x, 0, projectedVelocity.z);
                Velocity = finalVeloc.normalized * Velocity.magnitude;
                break;
            }
        }
    }

    private float CheckMinorDirection(in int iterations, in float angle)
    {
        float amount = 0.0f;
        float newAngle = angle;
        for (int i = 0; i < iterations; i++)
        {
            var newDir = Quaternion.Euler(0, newAngle, 0) * Velocity.normalized;

            Physics.Raycast(transform.position + Vector3.up * ColliderExtents.y,
            newDir,
            out var hitInfo,
            ColliderExtents.magnitude);

            amount += hitInfo.distance;
            newAngle += angle;
        }
        return amount;
    }

    private void CheckCollisionVertical(ref Vector3 targetPos)
    {
        RaycastHit[] vHits = new RaycastHit[10];
        var vHitCount = Physics.RaycastNonAlloc(
            transform.position + Vector3.up * ColliderExtents.y,
            Vector3.down,
            vHits,
            ColliderExtents.magnitude);

        for (int i = 0; i < vHitCount; i++)
        {
            var vHit = vHits[i];
            targetPos.y = vHit.point.y;
            break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position + Vector3.up * ColliderExtents.y, colliderSize);

        if (Velocity.magnitude == 0)
        {
            return;
        }
        GizmosUtils.DrawVector(transform.position, Velocity.normalized, 1);

        Gizmos.color = hitCount != 0 ? Color.green : Color.red;
        Gizmos.DrawWireCube(transform.position + Vector3.up * ColliderExtents.y, ColliderHorizontalExtents*2);


        if (hitCount != 0)
        {
            Gizmos.color = Color.magenta;
            GizmosUtils.DrawVector(hit.point, hit.normal, 1);
            Gizmos.color = Color.cyan;
            GizmosUtils.DrawVector(hit.point, projectedVelocity.normalized, 1);
        }
    }
}
