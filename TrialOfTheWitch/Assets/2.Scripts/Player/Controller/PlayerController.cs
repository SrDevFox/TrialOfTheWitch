using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Movement movement = new Movement();
    [SerializeField] Jump jump = new Jump();

    Rigidbody2D _rb;
    Animator _anim;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        movement.OnMove(_rb, _anim, this);
        jump.OnJump(_rb, _anim);
    }
}
