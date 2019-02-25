using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BSPlayerManager : MonoBehaviour
{
    private int reward = 3;
    public int playersLeft = 0;
    private int totalPlayers = 0;

    public SceneFader sceneFader;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    private PlayerScore p1Score;
    private PlayerScore p2Score;
    private PlayerScore p3Score;
    private PlayerScore p4Score;

    public BSGameManager p1BSGM;
    public BSGameManager p2BSGM;
    public BSGameManager p3BSGM;
    public BSGameManager p4BSGM;

    public Dictionary<string, int> myDictionary = new Dictionary<string, int>();
    private List<KeyValuePair<string, int>> mySortedList;
    private Dictionary<string, PlayerScore> playerStringMap = new Dictionary<string, PlayerScore>();
    private bool hasAwardedScore = false;

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
            playerStringMap.Add("p1Score", p1Score);
        }
        if (GameStats.Player2)
        {
            player2.SetActive(true);
            p2Score = player2.GetComponent<PlayerScore>();
            playersLeft++;
            playerStringMap.Add("p2Score", p2Score);
        }
        if (GameStats.Player3)
        {
            player3.SetActive(true);
            p3Score = player3.GetComponent<PlayerScore>();
            playersLeft++;
            playerStringMap.Add("p3Score", p3Score);
        }
        if (GameStats.Player4)
        {
            player4.SetActive(true);
            p4Score = player4.GetComponent<PlayerScore>();
            playersLeft++;
            playerStringMap.Add("p4Score", p4Score);
        }

        reward = playersLeft - 1;           // set reward equal to players in game
        totalPlayers = playersLeft;

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

    private void LateUpdate()
    {
        

        if (playersLeft <= 0 && !hasAwardedScore)
        {
            hasAwardedScore = true;

            Sort();
            for (int i = 0; i < mySortedList.Count; i++)
            {
                //SendMessage("UpdatePlayerScore", mySortedList[i - 1].Key);
                UpdatePlayerScore(playerStringMap[mySortedList[i].Key]);
            }
            

            if (GameStats.Player1) { p1Score.UpdateScore(); }
            if (GameStats.Player2) { p2Score.UpdateScore(); }
            if (GameStats.Player3) { p3Score.UpdateScore(); }
            if (GameStats.Player4) { p4Score.UpdateScore(); }

            StartCoroutine(EndScene());
        }

        
    }

    void UpdatePlayerScore(PlayerScore ps)
    {
        Debug.Log(ps + " : " + ps.score);
        ps.score -= reward;
        Debug.Log(ps + " : " + ps.score);
        ps.UpdateScore();
        reward--;
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

    void Sort()
    {
        mySortedList = myDictionary.OrderBy(d => d.Value).ToList();
    }

}
