using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Humanoid
{
    public float dashSpeed;
    public bool isDash;

    public void OnDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDash)
            isDash = true;
        
        if (isDash)
            Dashing();
    }

    void Dashing()
    {
        _rb.velocity = new Vector2(transform.localScale.x * Time.fixedDeltaTime * dashSpeed, _rb.velocity.y);
        _anim.SetBool("isDashing", true);
    }

    public void DisableDash()
    {
        isDash = false;
        _anim.SetBool("isDashing", isDash);
    }
}
