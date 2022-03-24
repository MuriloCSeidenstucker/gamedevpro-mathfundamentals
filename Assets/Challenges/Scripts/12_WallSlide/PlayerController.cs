using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class PlayerController : MonoBehaviour
{
    private CharacterMovement characterMovement;

    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        characterMovement.MoveCharacter(DirectionInput());
    }

    private Vector3 DirectionInput()
    {
        var horizontal = Input.GetAxisRaw(Horizontal);
        var vertical = Input.GetAxisRaw(Vertical);
        return new Vector3(horizontal, 0, vertical);
    }
}
