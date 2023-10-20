using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameObject activeCheckpoint;
    public static Vector3 activeCheckpointPosition;
    public static void RespawnPoint(GameObject newCheckpoint)
    {
        if(activeCheckpoint)
        {
            activeCheckpoint = null;
        }

        activeCheckpoint = newCheckpoint;
        activeCheckpoint.GetComponent<Checkpoint>().Activate();
        activeCheckpointPosition = new Vector3 (0,0,0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
