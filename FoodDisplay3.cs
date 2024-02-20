using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class FoodDisplay3 : MonoBehaviour
{
  public Image m_ImageSkill;
  public Sprite[] m_Food3Sprite;
  public float m_Speed = 0.13f;
  private Coroutine m_CoroutineAnim;

  public void Start()
  {
    this.m_ImageSkill.enabled = false;
    this.Food3Display();
  }

  public void Food3Display()
  {
    this.m_ImageSkill.enabled = true;
    if (this.m_CoroutineAnim != null)
      this.StopCoroutine(this.m_CoroutineAnim);
    this.StartSpriteAnimation(this.m_Food3Sprite, this.m_Speed);
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
    this.Food3Display();
  }
}