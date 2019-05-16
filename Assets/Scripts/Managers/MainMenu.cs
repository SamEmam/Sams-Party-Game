using UnityEngine;
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

        //sceneFader.FadeTo(29);
        //return;
        //int index = Random.Range(16, 21);

        if (GameStats.LevelPointer == GameStats.MaxRounds)
        {
            if (GameStats.EndlessGame)
            {
                EndlessGame();
            }
            else
            {
                EndGame();
            }
        }

        else if (GameStats.WreckedGame)
        {
            WreckedGame();
        }

        else
        {
            int index = GameStats.LevelList[GameStats.LevelPointer];
            GameStats.PreviousPreviousLevel = GameStats.PreviousLevel;
            GameStats.PreviousLevel = index;
            GameStats.LevelPointer++;
            sceneFader.FadeTo(index);
        }

        //run in SSEndGame.cs
        //BonusLevel();

    }

    public void EndGame()
    {
        sceneFader.FadeTo("EndScene");
    }

    void WreckedGame()
    {
        int index = Random.Range(0, GameStats.WreckedList.Count);
        index = GameStats.WreckedList[index];
        if (index == GameStats.PreviousLevel)
        {
            RandomLevel();
        }
        else
        {
            GameStats.PreviousLevel = index;
            GameStats.LevelPointer++;
            sceneFader.FadeTo(index);
        }
    }

    void EndlessGame()
    {
        int index = Random.Range(3, 30);
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
                
            }
            else
            {
                GameStats.LevelsWithoutBonusScene++;
            }

        }
    }
}
