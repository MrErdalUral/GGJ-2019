﻿using System.Collections;
using System.Collections.Generic;
using Anima2D;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject DamageObjectPrefab;
    public float AttackTime = 0.25f;
    public float AttackMovementSpeed = 5;
    public Animator Animator;
    private Vector2 _direction;
    private GameObject _attackObject;
    private Rigidbody2D _body;


    public Vector2 Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    private Vector2 _startPos;
    private Vector2 _endPos;

    void Start()
    {
        Direction = Vector2.right;
        _body = GetComponent<Rigidbody2D>();
    }

    

    public void SetDirection(Vector2 dir)
    {
        if(dir == Vector2.zero) return;
        Direction = dir.normalized;
    }

    public void MeleeAttack(bool attack)
    {
        if (!attack || this._attackObject) return;
        _startPos = -Vector2.Perpendicular(Direction);
        _endPos = -_startPos;
        Debug.Log("Attack Direction" + Direction);
        Animator.SetTrigger("Attack");
        _attackObject = Instantiate(DamageObjectPrefab, transform.position + (Vector3)_startPos, Quaternion.identity,transform);
        var circularMovement = _attackObject.AddComponent<CircularMovement>();
        circularMovement.EndPos = _endPos;
        circularMovement.PivotPos = transform;
        Destroy(_attackObject, AttackTime);
        _body.velocity += _direction * AttackMovementSpeed;
    }

}