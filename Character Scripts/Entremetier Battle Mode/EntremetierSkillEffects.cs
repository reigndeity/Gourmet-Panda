using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntremetierSkillEffects : MonoBehaviour
{
    public Image m_Image;
    public Sprite[] m_IdleSkillSetSpriteArray;
    public Sprite[] m_BasicAttackOverlaySpriteArray;
    public Sprite[] m_UltimateSkillOverlaySpriteArray;

    public float m_Speed = 0.13f;

    private Coroutine m_CoroutineAnim = null;
    public void Start()
    {
        m_Image.enabled = false;
        PlayIdleSkillSetSprite();
    }

    public void PlayIdleSkillSetSprite()
    {
        m_Image.enabled = false;
        if (m_CoroutineAnim != null)
        {
            StopCoroutine(m_CoroutineAnim);
        }
        StartSpriteAnimation(m_IdleSkillSetSpriteArray, m_Speed);
    }

    public void BasicAttackOverlaySpriteArray(float customSpeed)
    {
        customSpeed = 0.10f;
        m_Image.enabled = true;
        if (m_CoroutineAnim != null)
        {
            StopCoroutine(m_CoroutineAnim);
        }
        StartSpriteAnimation(m_BasicAttackOverlaySpriteArray, customSpeed);
        Invoke("PlayIdleSkillSetSprite", 0.61f);
    }

    public void UltimateSkillOverlaySpriteArray(float customSpeed)
    {
        customSpeed = 0.10f;
        m_Image.enabled = true;
        if (m_CoroutineAnim != null)
        {
            StopCoroutine(m_CoroutineAnim);
        }
        StartSpriteAnimation(m_UltimateSkillOverlaySpriteArray, customSpeed);
        Invoke("PlayIdleSkillSetSprite", 0.81f);

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

        PlayIdleSkillSetSprite();
    }
}
