using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject go;
    public AudioSource audios;
    
    public void DisableUI()
    {
        go.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void StartMusic()
    {
        audios.mute = false;
    }

}
