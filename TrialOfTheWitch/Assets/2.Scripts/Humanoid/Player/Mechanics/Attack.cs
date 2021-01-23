using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Humanoid
{
    public bool isAttacking;
    bool canAttack = true;

    public void OnAttack()
    {
        StartCoroutine(Attacking());
    }
    
    IEnumerator Attacking()
    {
        if (Input.GetMouseButtonDown(0) && canAttack && _rb.velocity.y == 0)
        {
            _anim.SetBool("isAttacking", true);
            isAttacking = true;
            canAttack = false;
            _rb.velocity = new Vector2(_rb.velocity.x * 0, _rb.velocity.y);
            yield return new WaitForSeconds(1f);
            canAttack = true;
        }
    }

    void DisableAttack(string paramName)
    {
        isAttacking = false;
        _anim.SetBool(paramName, false);
    }

}