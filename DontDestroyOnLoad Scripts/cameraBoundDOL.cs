using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBoundDOL : MonoBehaviour
{
    public static GameObject cameraBoundInstance;
    private void Awake()
    {
        if (cameraBoundInstance == null)
        {
            cameraBoundInstance = this.gameObject;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
