using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScoreManager : MonoBehaviour
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
        
        if (GameStats.Player1)
        {
            playersLeft++;
        }
        if (GameStats.Player2)
        {
            playersLeft++;
        }
        if (GameStats.Player3)
        {
            playersLeft++;
        }
        if (GameStats.Player4)
        {
            playersLeft++;
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
