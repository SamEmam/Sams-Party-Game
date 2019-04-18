﻿using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad = "MainMenu";

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

        sceneFader.FadeTo(16);
        return;
        //int index = Random.Range(16, 21);

        if (GameStats.LevelPointer > GameStats.LevelList.Count - 1)
        {
            int index = Random.Range(3, 29);
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

        BonusLevel();

    }

    public void BonusLevel()
    {
        int random = 0;
        int range = 5;
        bool bonusSceneCanOccur = false;

        
        
        switch (XCI.GetNumPluggedCtrlrs())
        {
            case 1:
                break;
            case 2:
                if (GameStats.Player1Score > 9 && GameStats.Player2Score > 9)
                {
                    bonusSceneCanOccur = true;
                }
                break;
            case 3:
                if (GameStats.Player1Score > 9 && GameStats.Player2Score > 9 && GameStats.Player3Score > 9)
                {
                    bonusSceneCanOccur = true;
                }
                break;
            case 4:
                if (GameStats.Player1Score > 9 && GameStats.Player2Score > 9 && GameStats.Player3Score > 9 && GameStats.Player4Score > 9)
                {
                    bonusSceneCanOccur = true;
                }
                break;
            default:
                break;
        }

        if (bonusSceneCanOccur)
        {
            range = (GameStats.LevelsWithoutBonusScene * 10) + 10;
            range -= GameStats.BonusScenesPlayed * 20;
            

            random = Random.Range(0, 100);
            
            if (random <= range)
            {
                sceneFader.FadeTo(2);
                GameStats.LevelPointer--;
                GameStats.BonusScenesPlayed++;
                GameStats.LevelsWithoutBonusScene = 0;
            }
            else
            {
                GameStats.LevelsWithoutBonusScene++;
            }

        }
    }
}
