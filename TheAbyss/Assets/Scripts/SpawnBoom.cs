using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBoom : MonoBehaviour
{
    [DoNotSerialize] private Transform spawn;
    public int maxBombs;
    public float interval = 3f;
    public GameObject bomb;
    public Transform bombPos;
    private static Stack<GameObject> stack = new Stack<GameObject>();

    private void Awake()
    {
        for (int i = 1; i <= maxBombs; i++)
        {
            GameObject BOMBA = Instantiate(bomb, transform.position, Quaternion.identity);
            BOMBA.name = "Bomb_"+i.ToString();
            Push(BOMBA);
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        bomb = GetComponent<GameObject>();
        StartCoroutine(GenerarBombasConRetraso());
    }

    // Update is called once per frame
    IEnumerator GenerarBombasConRetraso()
    {
        while (true)
        {
            Pop();
            yield return new WaitForSeconds(interval);
        }
    }
    private void Update()
    {
        Debug.Log(stack.Count);
    }
    #region pool

    public static void Push(GameObject go)
    {
        stack.Push(go);
    }
    public static void Pop()
    {
        stack.Pop().SetActive(true);
    }
    #endregion
}
