using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Jump
{
    public float jumpForce;
    public float groundCheckDistance;

    bool isJumping;
    bool isGround;

    public void OnJump(Rigidbody2D _rb, Animator _anim)
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
                _rb.velocity = new Vector2(_rb.velocity.x, Time.fixedDeltaTime * jumpForce);
        }
        _anim.SetInteger("Jump", (int)_rb.velocity.y);
        _anim.SetBool("isJumping", isJumping);
        GroundCheck(_rb);
    }


    void GroundCheck(Rigidbody2D _rb)
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
