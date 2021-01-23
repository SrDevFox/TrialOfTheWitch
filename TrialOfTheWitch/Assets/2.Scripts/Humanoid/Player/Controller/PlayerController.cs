using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Humanoid
{
    [SerializeField] Movement movement = new Movement();
    [SerializeField] Jump jump = new Jump();
    [SerializeField] Slide slide = new Slide();
    [SerializeField] Dash dash = new Dash();

    void Update()
    {
        if(slide.isSliding() == false)
            movement.OnMove();
        if(!dash.isDash)
            jump.OnJump();
        dash.OnDash();
        slide.OnSlide();
    }
}
