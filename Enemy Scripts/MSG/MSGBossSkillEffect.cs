using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class MSGBossSkillEffect : MonoBehaviour
{
  public Image m_Image;
  public Sprite[] m_IdleSkillSetSpriteArray;
  public Sprite[] m_BasicAttackOverlaySpriteArray;
  public Sprite[] m_UltimateSkillOverlaySpriteArray;
  public float m_Speed = 0.13f;
  private Coroutine m_CoroutineAnim;

  public void Start()
  {
    this.m_Image.enabled = false;
    this.PlayIdleSkillSetSprite();
  }

  public void PlayIdleSkillSetSprite()
  {
    this.m_Image.enabled = false;
    if (this.m_CoroutineAnim != null)
      this.StopCoroutine(this.m_CoroutineAnim);
    this.StartSpriteAnimation(this.m_IdleSkillSetSpriteArray, this.m_Speed);
  }

  public void BasicAttackOverlaySpriteArray(float customSpeed)
  {
    customSpeed = 0.1f;
    this.m_Image.enabled = true;
    if (this.m_CoroutineAnim != null)
      this.StopCoroutine(this.m_CoroutineAnim);
    this.StartSpriteAnimation(this.m_BasicAttackOverlaySpriteArray, customSpeed);
    this.Invoke("PlayIdleSkillSetSprite", 0.91f);
  }

  public void UltimateSkillOverlaySpriteArray(float ultSpeed)
  {
    ultSpeed = 0.08f;
    this.m_Image.enabled = true;
    if (this.m_CoroutineAnim != null)
      this.StopCoroutine(this.m_CoroutineAnim);
    this.StartSpriteAnimation(this.m_UltimateSkillOverlaySpriteArray, ultSpeed);
    this.Invoke("PlayIdleSkillSetSprite", 1.69f);
  }

  private void StartSpriteAnimation(Sprite[] spriteArray, float customSpeed)
  {
    this.m_CoroutineAnim = this.StartCoroutine(this.PlaySpriteAnimation(spriteArray, customSpeed));
  }

  private IEnumerator PlaySpriteAnimation(Sprite[] spriteArray, float customSpeed)
  {
    int index = 0;
    while (index < spriteArray.Length)
    {
      this.m_Image.sprite = spriteArray[index];
      ++index;
      if (index >= spriteArray.Length)
        index = 0;
      yield return (object) new WaitForSeconds(customSpeed);
    }
    this.PlayIdleSkillSetSprite();
  }
}

