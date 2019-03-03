using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceRaceManager : MonoBehaviour
{
    public string levelToLoad = "MainMenu";
    public SceneFader sceneFader;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    private PlayerScore p1Score;
    private PlayerScore p2Score;
    private PlayerScore p3Score;
    private PlayerScore p4Score;

    public FinishLine finishLine;
    private bool hasUpdatedScore;
    public Text message;

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
            p1Score = player1.GetComponent<PlayerScore>();
            p1Score.PlayerColor();
            finishLine.playersLeft++;

        }
        if (GameStats.Player2)
        {
            player2.SetActive(true);
            p2Score = player2.GetComponent<PlayerScore>();
            p2Score.PlayerColor();
            finishLine.playersLeft++;
        }
        if (GameStats.Player3)
        {
            player3.SetActive(true);
            p3Score = player3.GetComponent<PlayerScore>();
            p3Score.PlayerColor();
            finishLine.playersLeft++;
        }
        if (GameStats.Player4)
        {
            player4.SetActive(true);
            p4Score = player4.GetComponent<PlayerScore>();
            p4Score.PlayerColor();
            finishLine.playersLeft++;
        }
        finishLine.rewardScore = finishLine.playersLeft;
    }

    private void Update()
    {
        if (finishLine.playersLeft <= 0 && !hasUpdatedScore)
        {
            hasUpdatedScore = true;
            message.text = "";
            message.enabled = true;
            if (GameStats.Player1) { message.text += p1Score.playerColorText + ": " + p1Score.score + " points\n"; p1Score.UpdateScore(); }
            if (GameStats.Player2) { message.text += p2Score.playerColorText + ": " + p2Score.score + " points\n"; p2Score.UpdateScore(); }
            if (GameStats.Player3) { message.text += p3Score.playerColorText + ": " + p3Score.score + " points\n"; p3Score.UpdateScore(); }
            if (GameStats.Player4) { message.text += p4Score.playerColorText + ": " + p4Score.score + " points\n"; p4Score.UpdateScore(); }

            StartCoroutine(EndScene());
        }
    }

    IEnumerator EndScene()
    {
        yield return new WaitForSeconds(5);
        if (!GameStats.Player1 && !GameStats.Player2 && !GameStats.Player3 && !GameStats.Player4)
        {
            sceneFader.FadeTo("MainMenu");
        }
        sceneFader.FadeTo("ScoreScene");
    }
}
