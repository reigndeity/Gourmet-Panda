using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class WinScreen : MonoBehaviour
{
  public Image m_ImageSkill;
  public Sprite[] m_MsgWinSprite;
  public float m_Speed = 0.13f;
  private Coroutine m_CoroutineAnim;

  public void Start()
  {
    this.m_ImageSkill.enabled = false;
    this.PlayMsgWinSprite();
  }

  public void PlayMsgWinSprite()
  {
    this.m_ImageSkill.enabled = true;
    if (this.m_CoroutineAnim != null)
      this.StopCoroutine(this.m_CoroutineAnim);
    this.StartSpriteAnimation(this.m_MsgWinSprite, this.m_Speed);
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
      this.m_ImageSkill.sprite = spriteArray[index];
      ++index;
      if (index >= spriteArray.Length)
        index = 0;
      yield return (object) new WaitForSeconds(customSpeed);
    }
    this.PlayMsgWinSprite();
  }
}
