using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBoom : MonoBehaviour
{
    [DoNotSerialize] private static Transform spawn;
    public float secondsWait;
    //public int maxBombs;
    public GameObject bomb;
    private static ProyectilMovement bomb1;
    public static Transform bombTr;
    //public Rigidbody2D bombPos;
    private static Stack<GameObject> stack = new Stack<GameObject>();

    
    // Start is called before the first frame update
    private void Start()
    {
        GameObject bomb = GameObject.Find("boom");
        //bombPos = GetComponent<Rigidbody2D>();
        StartCoroutine(CreateBombs());
    }
    private void Awake()
    {
        spawn = GetComponent<Transform>();
        GameObject bombInstance = Instantiate(bomb, transform.position, Quaternion.identity);
        bombInstance.name = "Bomb_1";
        Push(bombInstance);
    }
    // Update is called once per frame
    IEnumerator CreateBombs()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsWait);
            Pop();
            bomb1 = GetComponent<ProyectilMovement>();
            bomb1.Activate();
        }
    }
    private void Update()
    {
        Debug.Log(stack.Count);
    }
    #region pool

    public static void Push(GameObject go)
    {
        bomb1 = go.GetComponent<ProyectilMovement>();
        bomb1.Desactivate();
        bombTr = go.GetComponent<Transform>();
        bombTr.position = spawn.position;
        stack.Push(go);
    }
    public static void Pop()
    {
        stack.Pop().SetActive(true);
    }
    #endregion
}
