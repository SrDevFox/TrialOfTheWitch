using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Movement movement = new Movement();
    [SerializeField] Jump jump = new Jump();

    Rigidbody2D _rb;
    [SerializeField]
    Collider2D _collider;
    Animator _anim; 

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        movement.OnMove(_rb, _anim, this);
        jump.OnJump(_rb, _anim);

        movement.Slide(_rb, _anim, _collider, this);
    }
}
