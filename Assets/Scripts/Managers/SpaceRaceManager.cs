using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRaceManager : MonoBehaviour
{
    public string levelToLoad = "MainMenu";
    public SceneFader sceneFader;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public FinishLine finishLine;

    private void Start()
    {
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);

        finishLine.playersLeft = 0;

        if (GameStats.Player1)
        {
            player1.SetActive(true);
            finishLine.playersLeft++;

        }
        if (GameStats.Player2)
        {
            player2.SetActive(true);
            finishLine.playersLeft++;
        }
        if (GameStats.Player3)
        {
            player3.SetActive(true);
            finishLine.playersLeft++;
        }
        if (GameStats.Player4)
        {
            player4.SetActive(true);
            finishLine.playersLeft++;
        }
        finishLine.rewardScore = finishLine.playersLeft;
    }

    private void Update()
    {
        if (finishLine.playersLeft <= 0)
        {
            if (!GameStats.Player1 && !GameStats.Player2 && !GameStats.Player3 && !GameStats.Player4)
            {
                sceneFader.FadeTo("MainMenu");
            }
            sceneFader.FadeTo("ScoreScene");
        }
    }
}
