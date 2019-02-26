using UnityEngine;
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
        //int index = Random.Range(16, 21);

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
}
