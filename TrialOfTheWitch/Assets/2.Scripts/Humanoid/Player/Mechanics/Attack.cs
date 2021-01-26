using System.Collections;
using System.Collections.Generic;
using CameraMechanic;
using UnityEngine;

public class Attack : Humanoid
{
    public bool isAttacking;
    bool canAttack = true;

    public float dashAttackSpeed;
    public bool isDashingAttack;
    bool canDashingAttack = true;

    public void OnAttack()
    {
        StartCoroutine(Attacking());
        StartCoroutine(dashingAttack());
    }
    
    IEnumerator Attacking()
    {
        if (Input.GetMouseButtonDown(0) && canAttack  && !isDashingAttack && _rb.velocity.y == 0)
        {
            _anim.SetBool("isAttacking", true);
            isAttacking = true;
            canAttack = false;
            _rb.velocity = new Vector2(_rb.velocity.x * 0, _rb.velocity.y);
            CameraMechanics.CameraShake();
            yield return new WaitForSeconds(1f);
            canAttack = true;
        }
    }

    IEnumerator dashingAttack()
    {
        if (Input.GetMouseButton(1) && canDashingAttack)
        {
            _rb.AddForce(new Vector2(transform.localScale.x * Time.fixedDeltaTime * dashAttackSpeed, _rb.velocity.y), ForceMode2D.Impulse);
            _anim.SetBool("isDashingAttack", true);
            isDashingAttack = true;
            canDashingAttack = false;
            CameraMechanics.CameraShake();
            yield return new WaitForSeconds(1f);
            canDashingAttack = true;
        }
    }
}   