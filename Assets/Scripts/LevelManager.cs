using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int currLevel = 1;

    public static LevelManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        currLevel++;
        if (currLevel > 3) Application.Quit();
        SceneManager.LoadScene("Level" + currLevel);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
