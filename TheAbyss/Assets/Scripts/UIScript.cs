using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject go;

    public void DisableUI()
    {
        go.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
