using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScene : MonoBehaviour
{
    public float scoreScreenCounter = 10;

    public MainMenu mainMenu;

    public TextMeshProUGUI countdown;

    public TextMeshProUGUI roundsPlayed;

    public List<int> tempList;

    private bool newScene = false;

    private void Start()
    {
        roundsPlayed.text = "Matches played: " + GameStats.RoundsPlayed;
        GameStats.RoundsPlayed++;
    }

    private void Update()
    {
        if (scoreScreenCounter <= 0 && !newScene)
        {
            if (GameStats.LevelPointer > GameStats.LevelList.Count)
            {
                GameStats.LevelPointer = 0;
                for (int i = 0; i < tempList.Count - 1; i++)
                {
                    var r = Random.Range(i, tempList.Count);
                    var temp = tempList[i];
                    tempList[i] = tempList[r];
                    tempList[r] = temp;
                }

                GameStats.LevelList = tempList;
            }
            mainMenu.RandomLevel();
            newScene = true;
        }

        scoreScreenCounter -= Time.deltaTime;
        countdown.text = "Next match in: " + (int)scoreScreenCounter;
    }


}
