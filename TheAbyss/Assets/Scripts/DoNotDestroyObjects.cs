using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyObjects : MonoBehaviour
{
    public static DoNotDestroyObjects instance;
   // public Vector3 SpawnLocation = new Vector3(-10,-15,0);
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
