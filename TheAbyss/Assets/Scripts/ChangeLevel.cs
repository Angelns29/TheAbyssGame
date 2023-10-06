using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public static int sceneNum = 0;
    public Transform player;

    /*private void OnTriggerEnter2D(Colider2D other)
    {
        if (other.CompareTag("Player")) {

            SceneManager.LoadScene(sceneNum++);
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "NextLevel")
        {
            sceneNum++;
            SceneManager.LoadScene(sceneNum);
            player.position = new Vector3(-10,-15,0);
            DontDestroyOnLoad(gameObject);  
        }
        else if (collision.gameObject.name == "ReturnLevel")
        {
            sceneNum--;
            SceneManager.LoadScene(sceneNum);
            player.position = new Vector3(10, -15, 0);
        }
    }
}
