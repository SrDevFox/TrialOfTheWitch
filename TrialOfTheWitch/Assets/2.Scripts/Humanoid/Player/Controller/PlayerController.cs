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
        if(!slide.isSliding && !attack.isAttacking && !attack.isDashingAttack)
            movement.OnMove();
        if(!dash.isDash)
            jump.OnJump();
        if(!attack.isDashingAttack && !attack.isAttacking)
            dash.OnDash();
        if(jump.isGround)
            slide.OnSlide();
        attack.OnAttack();
    }
}
