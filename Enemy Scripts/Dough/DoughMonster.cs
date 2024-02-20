using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoughMonster : MonoBehaviour
{
    public int currentMonster = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Stop the player from moving when encountering the monster
            SpriteMovement playerMovement = other.GetComponent<SpriteMovement>();
            if (playerMovement != null)
            {
                playerMovement.SetCanMove(false);
            }

            PlayerPrefs.SetInt("CurrentEnemy", currentMonster);
            GameObject.FindObjectOfType<BattleManager>().ActivateBattleSelectedPlayer();
            GameObject.FindObjectOfType<BattleManager>().ActivateBattleSelectedEnemy();
        }
    }

}
