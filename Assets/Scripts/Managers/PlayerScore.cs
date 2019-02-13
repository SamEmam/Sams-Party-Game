using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int playerNum;
    public int score = 0;
    public int laps = 0;

    private void Awake()
    {
        //SetScore();
    }

    void SetScore()
    {
        switch (playerNum)
        {
            case 1:
                score = GameStats.Player1Score;
                break;
            case 2:
                score = GameStats.Player2Score;
                break;
            case 3:
                score = GameStats.Player3Score;
                break;
            case 4:
                score = GameStats.Player4Score;
                break;
            default:
                break;
        }
    }

    public void UpdateScore()
    {
        switch (playerNum)
        {
            case 1:
                GameStats.Player1Score += score;
                score = 0;
                break;
            case 2:
                GameStats.Player2Score += score;
                score = 0;
                break;
            case 3:
                GameStats.Player3Score += score;
                score = 0;
                break;
            case 4:
                GameStats.Player4Score += score;
                score = 0;
                break;
            default:
                break;
        }
    }
}
