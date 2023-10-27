using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public static int sceneNum = 0;
    public Transform player;
    public Rigidbody2D playerRb;
    [NonSerialized]public static Vector3 checkpoint;
    public UIManager _canvasManager;
    public SoundManagerScript _soundManager;
    void FixedUpdate()
    {
        checkpoint = GetCheckpoint();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 position;
        switch (collision.gameObject.name)
        {
            case "NextLevel":
                sceneNum++;
                SceneManager.LoadScene(sceneNum);
                position = GetLoadPJ();
                player.position = new Vector3(position.x, player.position.y, player.position.z);
                break;
            case "ReturnLevel":
                sceneNum--;
                SceneManager.LoadScene(sceneNum);
                position = GetLoadPJ();
                player.position = new Vector3(-position.x, player.position.y, player.position.z);
                break;
            case "NextLevelUp":
                sceneNum++;
                SceneManager.LoadScene(sceneNum);
                position = GetLoadPJ();
                player.position = new Vector3(player.position.x, position.y, player.position.z);
                break;
            case "ReturnLevelDown":
                sceneNum--;
                SceneManager.LoadScene(sceneNum);
                position = GetLoadPJ();
                player.position = new Vector3(player.position.x, position.y + 7, player.position.z);
                break;
            case "Final":
                _soundManager.PlayFinalSong();
                _canvasManager.EndGame();
                break;
        }
    }
    public void PlayAgain()
    {
        if (UIManager.uiManager.resetGame == true)
        {
            sceneNum = 0;
            SceneManager.LoadScene(sceneNum);
            StartCoroutine(ResetGame());
        }
    }
    IEnumerator ResetGame()
    {
        yield return null;
        player.position = GetCheckpoint();
    }
    Vector3 GetLoadPJ()
    {
        GameObject newCheckpoint = GameObject.Find("LoadPj");
        if (newCheckpoint != null) return newCheckpoint.transform.position;
        else
        {
            return checkpoint;
        }
    }
    public static Vector3 GetCheckpoint()
    {
        GameObject newCheckpoint = GameObject.Find("Checkpoint");
        if (newCheckpoint != null) return newCheckpoint.transform.position; 
        else
        {
            return checkpoint;

        }
    }
}
