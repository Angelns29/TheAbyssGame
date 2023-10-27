using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepBackground : MonoBehaviour
{
    public static KeepBackground instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }

    }
}
