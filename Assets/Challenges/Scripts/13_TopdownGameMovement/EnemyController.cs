using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(TopdownFOV))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    private CharacterMovement charMovement;
    private TopdownFOV fov;

    private void Awake()
    {
        charMovement = GetComponent<CharacterMovement>();
        fov = GetComponent<TopdownFOV>();
    }

    private void Update()
    {
        var newDir = player.position - transform.position;
        var direction = fov.CanSeeTarget(player.position) ? newDir : Vector3.zero;
        charMovement.MoveCharacter(direction);
    }
}
