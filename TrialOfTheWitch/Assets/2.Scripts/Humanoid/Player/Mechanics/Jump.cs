﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Jump : Humanoid
{
    public float jumpForce;
    public float groundCheckDistance;

    public float coyotteTimeRef;
    float coyotteTime;

    public bool isGround;
    bool isJumping;

    public void OnJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping || coyotteTime > 0f && !isGround)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, Time.fixedDeltaTime * jumpForce);
            }
        }
        CoyotteTime();
        FlexibleJump();

        _anim.SetInteger("Jump", (int)_rb.velocity.y);
        _anim.SetBool("isJumping", isJumping);

        GroundCheck();
    }

    void FlexibleJump()
    {
        if (Input.GetButtonUp("Jump") && _rb.velocity.y > 0)
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.25f);
    }

    void CoyotteTime()
    {
        coyotteTime -= 0.1f;
        if (isGround)
            coyotteTime = coyotteTimeRef;
    }


    void GroundCheck()
    {
        RaycastHit2D raycast = Physics2D.Raycast(_rb.worldCenterOfMass, Vector2.down, groundCheckDistance, 1 << 8);
        Debug.DrawRay(_rb.worldCenterOfMass, Vector2.down * groundCheckDistance, Color.cyan);

        if (raycast.collider != null)
        {
            isJumping = false;
            isGround = true;
        }
        else
        {
            isJumping = true;
            isGround = false;
        }
    }
}
