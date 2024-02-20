using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSprite : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnBasicAttackButtonClick()
    {
        // Reset all triggers
        animator.ResetTrigger("isBasicAttack");
        animator.ResetTrigger("isIdle");

        // Trigger the "isBasicAttack" animation
        animator.SetTrigger("isBasicAttack");

        // Start coroutine to transition back to idle
        StartCoroutine(OnAttackAnimationEndCoroutine());
    }

    IEnumerator OnAttackAnimationEndCoroutine()
    {
        // Wait for the attack animation to complete
        yield return new WaitForSeconds(0.30f);

        // Reset all triggers
        animator.ResetTrigger("isBasicAttack");
        animator.ResetTrigger("isIdle");

        // Set trigger for the "isIdle" animation
        animator.SetTrigger("isIdle");
    }

}
