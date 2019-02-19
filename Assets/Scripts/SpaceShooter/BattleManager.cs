using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private int reward = 3;
    public int playersLeft = 0;
    public ParticleSystem deathEffect;

    public SceneFader sceneFader;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    private PlayerScore p1Score;
    private PlayerScore p2Score;
    private PlayerScore p3Score;
    private PlayerScore p4Score;

    private void Awake()
    {
        
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);

        if (GameStats.Player1)
        {
            player1.SetActive(true);
            p1Score = player1.GetComponent<PlayerScore>();
            playersLeft++;
        }
        if (GameStats.Player2)
        {
            player2.SetActive(true);
            p2Score = player2.GetComponent<PlayerScore>();
            playersLeft++;
        }
        if (GameStats.Player3)
        {
            player3.SetActive(true);
            p3Score = player3.GetComponent<PlayerScore>();
            playersLeft++;
        }
        if (GameStats.Player4)
        {
            player4.SetActive(true);
            p4Score = player4.GetComponent<PlayerScore>();
            playersLeft++;
        }

        reward = playersLeft - 1;           // set reward equal to players in game

        if (GameStats.Player1)
        {
            p1Score.score = reward;
        }
        if (GameStats.Player2)
        {
            p2Score.score = reward;
        }
        if (GameStats.Player3)
        {
            p3Score.score = reward;
        }
        if (GameStats.Player4)
        {
            p4Score.score = reward;
        }
    }

    private void Update()
    {
        if (playersLeft <= 1)
        {

            if (GameStats.Player1) { p1Score.UpdateScore(); }
            if (GameStats.Player2) { p2Score.UpdateScore(); }
            if (GameStats.Player3) { p3Score.UpdateScore(); }
            if (GameStats.Player4) { p4Score.UpdateScore(); }

            StartCoroutine(EndScene());
        }
    }

    IEnumerator EndScene()
    {
        yield return new WaitForSeconds(3);
        if (!GameStats.Player1 && !GameStats.Player2 && !GameStats.Player3 && !GameStats.Player4)
        {
            sceneFader.FadeTo("MainMenu");
        }
        sceneFader.FadeTo("ScoreScene");
    }
    
}

