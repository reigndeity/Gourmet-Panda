using UnityEngine;

public class HealingPotion : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (!other.CompareTag("Player"))
      return;
    Object.FindObjectOfType<BattleManager>().HealingPotion(50f);
    Object.Destroy((Object) this.gameObject);
  }
}
