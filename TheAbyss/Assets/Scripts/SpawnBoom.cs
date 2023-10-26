using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBoom : MonoBehaviour
{
    [DoNotSerialize] public static Transform spawn;
    public float secondsWait;
    //public int maxBombs;
    public GameObject bomb;
    //public static Transform bombTr;
    //public Rigidbody2D bombPos;
    //private static Stack<GameObject> stack = new Stack<GameObject>();

    private void Awake()
    {
        spawn = GetComponent<Transform>();
        StartCoroutine(CreateBomb());
    }
    IEnumerator CreateBomb()
    {
        yield return new WaitForSeconds(secondsWait);
        GameObject bombInstance = Instantiate(bomb, transform.position, Quaternion.identity);
        bombInstance.name = "Bomb";
    }
}
