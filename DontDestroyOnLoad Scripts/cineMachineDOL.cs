using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cineMachineDOL : MonoBehaviour
{
    public static GameObject cineMachineInstance;
    private void Awake()
    {
        if (cineMachineInstance == null)
        {
            cineMachineInstance = this.gameObject;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
