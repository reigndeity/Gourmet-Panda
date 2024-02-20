using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMainDOL : MonoBehaviour
{
    public static GameObject cameraMainInstance;
    private void Awake()
    {
        if (cameraMainInstance == null)
        {
            cameraMainInstance = this.gameObject;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
