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
        var horizontal = Input.GetAxisRaw(Horizontal);
        var vertical = Input.GetAxisRaw(Vertical);
        characterMovement.SetInput(horizontal, vertical);
    }
}
