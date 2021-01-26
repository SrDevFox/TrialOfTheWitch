using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CameraMechanic;

[System.Serializable]
public class Movement : Humanoid
{
    float horizontal;
    public float speed;

    public float timeToIdle;
    public bool isLookingLeft;

    public override void OnMove()
    {
        horizontal = Input.GetAxis("Horizontal");

        _rb.velocity = new Vector2(horizontal * Time.fixedDeltaTime * speed, _rb.velocity.y);
        _anim.SetInteger("Speed", (int)_rb.velocity.x);

        if (horizontal != 0)
        {
            CameraMechanics.CameraSize(6f, 0.03f);
            timeToIdle = 1f;
        }
        else
        {
            isIdle();
            void isIdle()
            {
                timeToIdle -= 0.1f;

                if(timeToIdle <= 0)
                    CameraMechanics.CameraSize(5f, 0.04f);   
            }
        }
        
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
