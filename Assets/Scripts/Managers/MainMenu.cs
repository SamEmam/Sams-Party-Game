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
        
        //sceneFader.FadeTo(32);
        //return;
        //int index = Random.Range(16, 21);

        if (GameStats.LevelPointer > GameStats.LevelList.Count)
        {
            int index = Random.Range(2, 33);
            if (index == GameStats.PreviousLevel || index == GameStats.PreviousPreviousLevel)
            {
                RandomLevel();
            }
            else
            {
                GameStats.PreviousPreviousLevel = GameStats.PreviousLevel;
                GameStats.PreviousLevel = index;
                sceneFader.FadeTo(index);
            }
        }

        else
        {
            int index = GameStats.LevelList[GameStats.LevelPointer];
            GameStats.PreviousPreviousLevel = GameStats.PreviousLevel;
            GameStats.PreviousLevel = index;
            GameStats.LevelPointer++;
            sceneFader.FadeTo(index);
        }

    }
}
