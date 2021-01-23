using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Movement
{
    float horizontal;
    public float speed;

    public float slideSpeed;
    public float timeSlideRef;
    public float timeSlide;
    public bool isSlide;

    public bool isLookingLeft;

    public void OnMove(Rigidbody2D _rb, Animator _anim, PlayerController player)
    {
        if(!isSlide)
            horizontal = Input.GetAxis("Horizontal");

        _rb.velocity = new Vector2(horizontal * Time.fixedDeltaTime * speed, _rb.velocity.y);
        _anim.SetInteger("Speed", (int)_rb.velocity.x);
        Flip(player);
    }

    public void Slide(Rigidbody2D _rb, Animator _anim, Collider2D _collider,PlayerController player)
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetAxisRaw("Horizontal") != 0 && timeSlide > 0f)
            isSlide = true;
        else if (Input.GetKeyUp(KeyCode.LeftShift) || timeSlide <= 0)
        {
            isSlide = false;
            _anim.SetBool("isSliding", false);
            _rb.gravityScale = 2;
            _collider.isTrigger = false;
            player.StartCoroutine(RestoreTime());
        }
        if(isSlide)
            OnSlide(_rb, _anim, _collider,player);

    }

    IEnumerator RestoreTime()
    {
        yield return new WaitForSeconds(1f);
        timeSlide = timeSlideRef;
    }

    void OnSlide(Rigidbody2D _rb, Animator _anim, Collider2D _collider,PlayerController player)
    {
        float directional = player.transform.localScale.x;

        _rb.gravityScale = 0;
        _collider.isTrigger = true;
        _rb.velocity = new Vector2(directional * Time.deltaTime * slideSpeed, _rb.velocity.y * 0);
        _anim.SetBool("isSliding", true); 

        timeSlide -= 0.1f;
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
