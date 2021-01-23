using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Movement : Humanoid
{
    float horizontal;
    public float speed;

    public bool isLookingLeft;

    public override void OnMove()
    {
        horizontal = Input.GetAxis("Horizontal");

        _rb.velocity = new Vector2(horizontal * Time.fixedDeltaTime * speed, _rb.velocity.y);
        _anim.SetInteger("Speed", (int)_rb.velocity.x);
        Flip();
    }


    void Flip()
    {
        isLookingLeft = !isLookingLeft;
        if (horizontal > 0 && isLookingLeft)
            transform.localScale = new Vector2(1,1);
        else if (horizontal < 0 && isLookingLeft)
            transform.localScale = new Vector2(-1, 1);
    }
}
