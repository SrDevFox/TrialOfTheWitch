using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Slide : Humanoid
{
    public float slideSpeed;
    public float timeSlide;
    public bool isSliding;
    public bool isSlide;
    [SerializeField]bool canSlide = true;

    public void OnSlide()
    {
        if (Input.GetButton("Horizontal") && Input.GetKeyDown(KeyCode.S) && canSlide)
        {
            isSliding = true;
            canSlide = false;
        }

        if (isSliding)
            Sliding();
    }

    void Sliding()
    {
        _anim.SetBool("isSliding", true);
        _rb.velocity = new Vector2(transform.localScale.x * Time.fixedDeltaTime * slideSpeed, _rb.velocity.y * 0);

        StartCoroutine(OffSlide());
    }

    IEnumerator OffSlide()
    {
        yield return new WaitForSeconds(timeSlide);
        isSliding = false;

        canSlide = true;
        _anim.SetBool("isSliding", false);
    }
}
