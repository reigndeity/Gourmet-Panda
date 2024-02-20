using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PatissierBattleMode : MonoBehaviour
{
    public Image m_Image;

    public Sprite[] m_IdleSpriteArray;
    public Sprite[] m_BasicAttackSpriteArray;
    public Sprite[] m_UltimateSkillSpriteArray;
    public Sprite[] m_HurtSpriteArray;

    public float m_Speed = 0.13f;

    private Coroutine m_CoroutineAnim = null;

    public void Start()
    {
        PlayIdleSprite();
    }

    public void PlayIdleSprite()
    {
        if (m_CoroutineAnim != null)
        {
            StopCoroutine(m_CoroutineAnim);
        }
        StartSpriteAnimation(m_IdleSpriteArray, m_Speed);
    }

    public void PlayBasicAttackSprite(float customSpeed)
    {
        if (m_CoroutineAnim != null)
        {
            StopCoroutine(m_CoroutineAnim);
        }
        StartSpriteAnimation(m_BasicAttackSpriteArray, customSpeed);

        GameObject.FindObjectOfType<PatissierSkillEffects>().BasicAttackOverlaySpriteArray(customSpeed);

        Invoke("PlayIdleSprite", 0.30f);
    }

    public void PlayUltimateSkillSprite(float customSpeed)
    {
        if (m_CoroutineAnim != null)
        {
            StopCoroutine(m_CoroutineAnim);
        }
        StartSpriteAnimation(m_UltimateSkillSpriteArray, customSpeed);

        GameObject.FindObjectOfType<PatissierSkillEffects>().UltimateSkillOverlaySpriteArray(customSpeed);

        Invoke("PlayIdleSprite", 0.37f);
    }

    public void PlayHurtSprite(float hurtSpeed)
    {
        hurtSpeed = 0.10f;
        if (m_CoroutineAnim != null)
        {
            StopCoroutine(m_CoroutineAnim);
        }
        StartSpriteAnimation(m_HurtSpriteArray, hurtSpeed);

        Invoke("PlayIdleSprite", 0.51f);
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
            m_Image.sprite = spriteArray[index];
            index++;

            if (index >= spriteArray.Length)
            {
                index = 0;
            }

            yield return new WaitForSeconds(customSpeed);
        }

        // Switch back to idle sprite after the animation finishes.
        PlayIdleSprite();
    }
}
