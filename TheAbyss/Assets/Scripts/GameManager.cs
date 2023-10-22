using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    private static int _deaths;
    private float timer;
    public static string timerText;
    public static bool timerActive = false;
    private Stack<GameObject> stack = new Stack<GameObject>();
    public void Push(GameObject go)
    {
        stack.Push(go);
    }
    public void Pop()
    {
        stack.Pop().SetActive(true);
    }
    public void Peek()
    {
        stack.Peek().SetActive(false);
    }
    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameManager);
    }
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        _deaths = 0;
    }
    public static void StartTimer()
    {
        timerActive = true;
    }
    public static void StopTime()
    {
        timerActive= false;
    }
    // Update is called once per frame
    void Update()
    {
        if (timerActive == true)
        {
            timer += Time.deltaTime;
        }
        else
        {
            TimeSpan time = TimeSpan.FromSeconds(timer);
            timerText = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        }
    }
    public static void AddDeath()
    {
        _deaths++;
    }
    public static int GetDeaths()
    {
        return _deaths;
    }
}
