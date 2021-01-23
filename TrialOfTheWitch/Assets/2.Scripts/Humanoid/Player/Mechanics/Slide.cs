using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Slide : Humanoid
{
    public float slideSpeed;
    public float timeSlideRef;
    public float timeSlide;
    public bool isSlide;

    public bool isSliding()
    {
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetAxisRaw("Horizontal") != 0 && timeSlide > 0f && _rb.velocity.y == 0)
            return true;
        else
            return false;
    }

    public void OnSlide( )
    {
        if(isSliding() == true)
        {
            Sliding();
        }
        
        else if (isSliding() == false)
            DisableSliding();

    }

    void Sliding()
    {
        _rb.gravityScale = 0;
        _collider.isTrigger = true;

        _rb.velocity = new Vector2(transform.localScale.x * Time.deltaTime * slideSpeed, _rb.velocity.y * 0);
        _anim.SetBool("isSliding", true); 

        timeSlide -= 0.1f;
    }

    void DisableSliding()
    {
        isSlide = false;

        _anim.SetBool("isSliding", false);
        _rb.gravityScale = 2;
        _collider.isTrigger = false;
        StartCoroutine(RestoreTime(timeSlide, timeSlideRef, 1f));
    }

    public IEnumerator RestoreTime(float time, float timeRef, float timeOfReturn)
    {
            yield return new WaitForSeconds(1f);
            timeSlide = timeSlideRef;
    }
}
