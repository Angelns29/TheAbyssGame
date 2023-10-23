using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [DoNotSerialize]public UIManager uiManager;
    public GameObject go;
    public AudioSource audios;
    public static bool JuegoPausado = false;
    [Header("Start")]
    [SerializeField] private GameObject startMenu;
    [Header("Pause")]
    [SerializeField] private GameObject pauseMenu;
    [Header("Final")]
    [SerializeField] private GameObject finalMenu;
    [SerializeField] private TMP_Text deathText;
    [SerializeField] private TMP_Text timeText;

    void Awake()
    {
        if (uiManager == null)
        {
            uiManager = this;
            DontDestroyOnLoad(gameObject);

        }
        else  Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button8))
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
        GameManager.StartTimer();
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
        GameManager.StopTime();
        StartCoroutine(ShowInfo());

        
    }
    IEnumerator ShowInfo()
    {
        yield return new WaitForSeconds(1);
        deathText.text += GameManager.GetDeaths();
        timeText.text += GameManager.timerText;
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
