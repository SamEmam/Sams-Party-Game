﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KOTHManager : MonoBehaviour
{
    private BoxCollider killFloor;
    private int deathCount;
    public int reward = 3;
    private int playersLeft;
    public ParticleSystem fireworks;
    public Vector3 particlePos = new Vector3(0, 30, 0);
    private bool fireworksLaunched = false;

    public Text message;

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
        killFloor = GetComponent<BoxCollider>();

        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);

        if (GameStats.Player1)
        {
            player1.SetActive(true);
            p1Score = player1.GetComponent<PlayerScore>();
            p1Score.PlayerColor();
            //p1Score.score = reward;
            playersLeft++;
        }
        if (GameStats.Player2)
        {
            player2.SetActive(true);
            p2Score = player2.GetComponent<PlayerScore>();
            p2Score.PlayerColor();
            //p2Score.score = reward;
            playersLeft++;
        }
        if (GameStats.Player3)
        {
            player3.SetActive(true);
            p3Score = player3.GetComponent<PlayerScore>();
            p3Score.PlayerColor();
            //p3Score.score = reward;
            playersLeft++;
        }
        if (GameStats.Player4)
        {
            player4.SetActive(true);
            p4Score = player4.GetComponent<PlayerScore>();
            p4Score.PlayerColor();
            //p4Score.score = reward;
            playersLeft++;
        }

        reward = playersLeft -1;           // set reward equal to players in game

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
            if (!fireworksLaunched)
            {
                Instantiate(fireworks, particlePos, Quaternion.LookRotation(Vector3.up));
                fireworksLaunched = true;
                if (GameStats.Player1) { message.text += p1Score.playerColorText + ": " + p1Score.score + " points\n"; p1Score.UpdateScore(); }
                if (GameStats.Player2) { message.text += p2Score.playerColorText + ": " + p2Score.score + " points\n"; p2Score.UpdateScore(); }
                if (GameStats.Player3) { message.text += p3Score.playerColorText + ": " + p3Score.score + " points\n"; p3Score.UpdateScore(); }
                if (GameStats.Player4) { message.text += p4Score.playerColorText + ": " + p4Score.score + " points\n"; p4Score.UpdateScore(); }
            }

            

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerScore ps = other.GetComponent<PlayerScore>();
            ps.score -= playersLeft -1;
            //ps.UpdateScore();
            playersLeft--;
            Instantiate(ps.finishParticles, other.transform.position, Quaternion.LookRotation(Vector3.up));
            Destroy(other.gameObject);
        }
    }
}

