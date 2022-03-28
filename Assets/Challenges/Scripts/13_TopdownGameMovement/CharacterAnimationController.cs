using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] private CharacterMovement charMovement;
    private Animator an;

    private void Awake()
    {
        an = GetComponent<Animator>();
    }

    private void Update()
    {
        an.SetFloat(CharacterConstants.Velocity, charMovement.Velocity.magnitude);
    }
}
