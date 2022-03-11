using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterMovement movement;

    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private void Awake()
    {
        movement = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        movement.MoveCharacter(GetDirectionInput());
    }

    private Vector3 GetDirectionInput()
    {
        var xAxis = Input.GetAxisRaw(Horizontal);
        var zAxis = Input.GetAxisRaw(Vertical);
        return new Vector3(xAxis, 0, zAxis);
    }
}
