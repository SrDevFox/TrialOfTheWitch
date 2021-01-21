using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Movement
{
    float horizontal;
    public float speed;

    public bool isLookingLeft;

    public void OnMove(Rigidbody2D _rb, Animator _anim, PlayerController player)
    {
        horizontal = Input.GetAxis("Horizontal");

        _rb.velocity = new Vector2(horizontal * Time.fixedDeltaTime * speed, _rb.velocity.y);
        _anim.SetInteger("Speed", (int)_rb.velocity.x);
        Flip(player);
    }

    void Flip(PlayerController player)
    {
        isLookingLeft = !isLookingLeft;
        if (horizontal > 0 && isLookingLeft)
            player.transform.localScale = new Vector2(1,1);
        else if (horizontal < 0 && isLookingLeft)
            player.transform.localScale = new Vector2(-1, 1);
    }
}
