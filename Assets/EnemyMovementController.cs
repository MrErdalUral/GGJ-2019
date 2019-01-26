using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement2D))]
public class EnemyMovementController : MonoBehaviour
{
    private Movement2D _movement;
    public EnemyMovementType MovementType = EnemyMovementType.chase;

    void Awake()
    {
        _movement = GetComponent<Movement2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var dir = (player.transform.position-transform.position).normalized;
        if (MovementType == EnemyMovementType.avoid)
            dir = -dir;
        _movement.SetDirection(dir);
    }
}

public enum EnemyMovementType
{
    chase,avoid
}