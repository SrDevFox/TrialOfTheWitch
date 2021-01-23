using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanoid : MonoBehaviour
{
    protected Rigidbody2D _rb;
    protected Animator _anim;
    protected Collider2D _collider;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
    }

    public virtual void OnMove()
    {

    }
}
