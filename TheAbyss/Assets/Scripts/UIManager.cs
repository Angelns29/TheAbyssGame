using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManager;
    public GameObject go;
    private GameObject audioObject;
    public AudioSource audios;
    public bool firstTime = true;
    public bool JuegoPausado = false;
    public bool resetGame = false;
    public ChangeLevel changeLevel;

    [DoNotSerialize] private GameObject _player;
    [DoNotSerialize] private GameObject _background;

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

        if (firstTime)
        {
            startMenu.SetActive(true);
            firstTime = false;
        }
        else if (firstTime == false)
        {
            startMenu.SetActive(false);
        }

        audioObject = GameObject.Find("Music");
        audios = audioObject.GetComponent<AudioSource>();
        _player = GameObject.Find("Character");
        _background = GameObject.Find("Background");
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
        yield return null;
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
        resetGame = true;
        firstTime = true;
        pauseMenu.SetActive(false);
        finalMenu.SetActive(false);
        deathText.text = "Deaths: ";
        timeText.text = "Time: ";
        SoundManagerScript.soundManagerScript.Start();
        changeLevel.PlayAgain();


    }
    #endregion 
}
