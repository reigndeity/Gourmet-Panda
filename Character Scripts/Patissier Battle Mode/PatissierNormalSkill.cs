using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatissierNormalSkill : MonoBehaviour
{
    public Image m_ImageSkill;

    public Sprite[] m_IdleSkillSpriteArray;
    public Sprite[] m_NormalSkillSpriteArray;


    public float m_Speed = 0.13f;

    private Coroutine m_CoroutineAnim = null;

    public void Start()
    {
        m_ImageSkill.enabled = false;
        PlayIdleSkillSprite();
    }

    public void PlayIdleSkillSprite()
    {
        m_ImageSkill.enabled = false;
        if (m_CoroutineAnim != null)
        {
            StopCoroutine(m_CoroutineAnim);
        }
        StartSpriteAnimation(m_IdleSkillSpriteArray, m_Speed);
    }

    public void PlayNormalSkillAttackSprite(float customSpeed)
    {
        m_ImageSkill.enabled = true;
        if (m_CoroutineAnim != null)
        {
            StopCoroutine(m_CoroutineAnim);
        }
        StartSpriteAnimation(m_NormalSkillSpriteArray, customSpeed);

        Invoke("PlayIdleSkillSprite", 0.82f);
    }

    private void StartSpriteAnimation(Sprite[] spriteArray, float customSpeed)
    {
        m_CoroutineAnim = StartCoroutine(PlaySpriteAnimation(spriteArray, customSpeed));
    }

    private IEnumerator PlaySpriteAnimation(Sprite[] spriteArray, float customSpeed)
    {
        int index = 0;

        while (index < spriteArray.Length)
        {
            m_ImageSkill.sprite = spriteArray[index];
            index++;

            if (index >= spriteArray.Length)
            {
                index = 0;
            }

            yield return new WaitForSeconds(customSpeed);
        }

        // Switch back to idle sprite after the animation finishes.
        PlayIdleSkillSprite();
    }
}
