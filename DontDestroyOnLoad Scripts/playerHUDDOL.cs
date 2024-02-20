using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHUDDOL : MonoBehaviour
{
    public static GameObject playerHUDInstance;
    private void Awake()
    {
        if (playerHUDInstance == null)
        {
            playerHUDInstance = this.gameObject;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
