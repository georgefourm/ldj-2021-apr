using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public string StartLevel = "MainScene";

    public void PlayGame()
    {
        SceneManager.LoadScene(StartLevel);
    }

    public void Credits()
    {
        // TODO
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
