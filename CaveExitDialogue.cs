using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveExitDialogue : MonoBehaviour
{
    public GameObject caveExitDialogue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            caveExitDialogue.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            caveExitDialogue.SetActive(false);
        }
    }

}
