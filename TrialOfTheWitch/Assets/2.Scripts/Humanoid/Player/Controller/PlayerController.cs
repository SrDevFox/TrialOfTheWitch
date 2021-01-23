using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Humanoid
{
    [SerializeField] Movement movement = new Movement();
    [SerializeField] Jump jump = new Jump();
    [SerializeField] Slide slide = new Slide();
    [SerializeField] Dash dash = new Dash();
    [SerializeField] Attack attack = new Attack();

    void Update()
    {
        if(slide.isSliding() == false && !attack.isAttacking)
            movement.OnMove();
        if(!dash.isDash)
            jump.OnJump();
        dash.OnDash();
        slide.OnSlide();
        attack.OnAttack();
    }
}
