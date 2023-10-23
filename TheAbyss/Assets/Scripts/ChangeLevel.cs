using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public static int sceneNum = 0;
    public Transform player;
    [NonSerialized]public Vector3 checkpoint;
    public UIManager _canvasManager;
    public SoundManagerScript _soundManager;
    void FixedUpdate()
    {
        checkpoint = GetCheckpoint();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 Position;
        switch (collision.gameObject.name)
        {
            case "NextLevel":
                sceneNum++;
                SceneManager.LoadScene(sceneNum);
                Position = GetLoadPJ();
                player.position = new Vector3(Position.x, player.position.y, player.position.z);
                //DontDestroyOnLoad(gameObject);
                break;
            case "ReturnLevel":
                sceneNum--;
                SceneManager.LoadScene(sceneNum);
                Position = GetLoadPJ();
                player.position = new Vector3(-Position.x, player.position.y, player.position.z);
                break;
            case "NextLevelUp":
                sceneNum++;
                SceneManager.LoadScene(sceneNum);
                Position = GetLoadPJ();
                player.position = new Vector3(player.position.x, Position.y, player.position.z);
                //DontDestroyOnLoad(gameObject);
                break;
            case "ReturnLevelDown":
                sceneNum--;
                SceneManager.LoadScene(sceneNum);
                Position = GetLoadPJ();
                player.position = new Vector3(player.position.x, Position.y + 7, player.position.z);
                break;
            case "Final":
                _soundManager.PlayFinalSong();
                _canvasManager.EndGame();
                break;
        }
    }
    Vector3 GetLoadPJ()
    {
        GameObject newCheckpoint = GameObject.Find("LoadPj");
        if (newCheckpoint != null)
        {
            return newCheckpoint.transform.position;
            //player.position = new Vector3(-10,-15,0);//GameController.activeCheckpoint.position;
        }
        else
        {
            Debug.LogError("No se encontro el empty LoadPj");
            return checkpoint;
        }
    }
    public Vector3 GetCheckpoint()
    {
        GameObject newCheckpoint = GameObject.Find("Checkpoint");
        if (newCheckpoint != null)
        {
            return newCheckpoint.transform.position;
            //player.position = new Vector3(-10,-15,0);//GameController.activeCheckpoint.position;
        }
        else
        {
            //Debug.LogError("No se encontro el Checkpoint");
            return checkpoint;

        }
    }
}
