using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject go;
    public AudioSource audios;
    public static bool JuegoPausado = false;
    [Header("Start")]
    [SerializeField] private GameObject startMenu;
    [Header("Pause")]
    [SerializeField] private GameObject pauseMenu;
    [Header("Final")]
    [SerializeField] private GameObject finalMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeInHierarchy)
            {
                PauseGame(true);
                Reanudar();
            }
            else
            {
                PauseGame(false);
                Pausa();
            }
        }
    }
    public void DisableStart()
    {
        startMenu.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif

    }
    public void StartMusic()
    {
        audios.mute = false;
    }
    public void EndGame()
    {
        finalMenu.SetActive(true);
    }
    #region Pause
    private void PauseGame(bool status)
    {
        pauseMenu.SetActive(status);    
    }

    public void Reanudar()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        JuegoPausado = false;
    }
    public void Pausa()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        JuegoPausado = true;
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene("The Abyss");
    }
    #endregion
}
