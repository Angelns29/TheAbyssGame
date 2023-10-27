using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBoom : MonoBehaviour
{
    public Transform spawn;
    public float secondsWait;
    public ProyectilMovement bomb;

    private void Awake()
    {
        spawn = GetComponent<Transform>();
        StartCoroutine(ActivateeBomb());
    }
    IEnumerator ActivateeBomb()
    {
        yield return new WaitForSeconds(secondsWait);
        bomb.Move();
        
    }
}
