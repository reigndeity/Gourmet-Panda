using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptDOL : MonoBehaviour
{
    public static GameObject scriptInstance;
    private void Awake()
    {
        if (scriptInstance == null)
        {
            scriptInstance = this.gameObject;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
