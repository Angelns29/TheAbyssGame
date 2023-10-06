using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool JuegoPausado = false;
    public GameObject pauseMenuIU;
    void Start()
    {
        //pauseMenuIU.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (JuegoPausado)
            {
                Reanudar();
                
            }
            else
            {
                Pausa();
            }
        }
    }
    public void Reanudar()
    {
        pauseMenuIU.SetActive(false);
        Time.timeScale = 1.0f;
        JuegoPausado = false;
    }
    public void Pausa()
    {
        pauseMenuIU.SetActive(true);
        Time.timeScale = 0f;
        JuegoPausado = true;
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene("The Abyss");
    }
}
