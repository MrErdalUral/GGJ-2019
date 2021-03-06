﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement2D))]
public class EnemyMovementController : MonoBehaviour
{
    private Movement2D _movement;
    public EnemyMovementType MovementType = EnemyMovementType.chase;
    private float _cooldown;
    public float AvoidDistance = 10f;

    void Awake()
    {
        _movement = GetComponent<Movement2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _cooldown -= Time.deltaTime;
        if (_cooldown >= 0)
            return;
        var player = GameObject.FindGameObjectWithTag("Player");
        if(!player) return;
        var dir = (player.transform.position-transform.position).normalized;
        transform.localScale = new Vector3(-Mathf.Sign(dir.x),1,1);
        if (MovementType == EnemyMovementType.avoid && AvoidDistance > (GameObject.FindGameObjectWithTag("Player").transform.position-transform.position).magnitude)
        {
            dir = -dir;
        }
        _movement.SetDirection(dir);
    }

    public void StopMovement()
    {
        _movement.SetDirection(Vector2.zero);

        _cooldown = 1f;
    }

    public void TimedStopMovement()
    {
        _movement.SetDirection(Vector2.zero);

        _cooldown = 1f;
    }
}

public enum EnemyMovementType
{
    chase,avoid
}
