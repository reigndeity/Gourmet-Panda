using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class MSGBossBattleMode : MonoBehaviour
{
  public Image m_Image;
  public Sprite[] m_IdleSpriteArray;
  public Sprite[] m_BasicAttackSpriteArray;
  public Sprite[] m_NormalSkillSpriteArray;
  public Sprite[] m_UltimateSkillSpriteArray;
  public Sprite[] m_HurtSpriteArray;
  public float m_Speed = 0.15f;
  private Coroutine m_CoroutineAnim;

  public void Start() => this.PlayIdleSprite();

  public void PlayIdleSprite()
  {
    if (this.m_CoroutineAnim != null)
      this.StopCoroutine(this.m_CoroutineAnim);
    this.StartSpriteAnimation(this.m_IdleSpriteArray, this.m_Speed);
  }

  public void PlayBasicAttackSprite(float customSpeed)
  {
    customSpeed = 0.1f;
    if (this.m_CoroutineAnim != null)
      this.StopCoroutine(this.m_CoroutineAnim);
    this.StartSpriteAnimation(this.m_BasicAttackSpriteArray, customSpeed);
    this.Invoke("PlayIdleSprite", 0.81f);
  }

  public void PlayNormalSkillSprite(float customSpeed)
  {
    customSpeed = 0.1f;
    if (this.m_CoroutineAnim != null)
      this.StopCoroutine(this.m_CoroutineAnim);
    this.StartSpriteAnimation(this.m_NormalSkillSpriteArray, customSpeed);
    this.Invoke("PlayIdleSprite", 0.91f);
  }

  public void PlayUltimateSkillSprite(float customSpeed)
  {
    customSpeed = 0.1f;
    if (this.m_CoroutineAnim != null)
      this.StopCoroutine(this.m_CoroutineAnim);
    this.StartSpriteAnimation(this.m_UltimateSkillSpriteArray, customSpeed);
    this.Invoke("PlayIdleSprite", 1.01f);
  }

  public void PlayHurtSprite(float customHurtSpeed)
  {
    customHurtSpeed = 0.1f;
    if (this.m_CoroutineAnim != null)
      this.StopCoroutine(this.m_CoroutineAnim);
    this.StartSpriteAnimation(this.m_HurtSpriteArray, customHurtSpeed);
    this.Invoke("PlayIdleSprite", 0.33f);
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
    this.PlayIdleSprite();
  }
}