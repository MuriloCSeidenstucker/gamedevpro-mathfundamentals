using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    public void MoveCharacter(in Vector3 direction)
    {
        var position = transform.position;
        position += direction * moveSpeed * Time.deltaTime;

        transform.position = position;
    }
}
