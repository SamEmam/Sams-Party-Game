﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad = "MainScene";

    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exciting...");
        Application.Quit();
    }

    public void RandomLevel()
    {
        //sceneFader.FadeTo(20);

        int index = Random.Range(2, 22);
        if (index == GameStats.PreviousLevel)
        {
            RandomLevel();
        }
        else
        {
            GameStats.PreviousLevel = index;
            sceneFader.FadeTo(index);
        }
    }
}
