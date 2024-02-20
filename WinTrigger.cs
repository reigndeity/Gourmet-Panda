using UnityEngine;

#nullable disable
public class winTrigger : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (!other.CompareTag("Player"))
      return;
    Object.FindObjectOfType<BattleManager>().WinnerDinner();
    Object.Destroy((Object) this.gameObject);
  }
}

