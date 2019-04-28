using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class ESVehicleSize : MonoBehaviour
{
    public GameObject player1, player2, player3, player4;
    private PlayerScore p1Score, p2Score, p3Score, p4Score;

    public int playerCount = 0, totalPlayers, sizeMult = 3;

    private Dictionary<string, int> playerGameStats = new Dictionary<string, int>();
    private List<KeyValuePair<string, int>> mySortedList;
    private Dictionary<string, GameObject> gameObjectList = new Dictionary<string, GameObject>();
    private Dictionary<string, PlayerScore> playerScoresList = new Dictionary<string, PlayerScore>();

    public string[] winnerMessages;

    private bool hasChosenWinner = false;
    public Text message;
    private bool hasRunOnce = false;
    private int curMessage, prevMessage;

    private void Awake()
    {
        if (GameStats.Player1)
        {
            p1Score = player1.GetComponent<PlayerScore>();
            p1Score.PlayerColor();
            playerCount++;
            playerGameStats.Add("player1", GameStats.Player1Score);
            gameObjectList.Add("player1", player1);
            playerScoresList.Add("player1", p1Score);

        }
        if (GameStats.Player2)
        {
            p2Score = player2.GetComponent<PlayerScore>();
            p2Score.PlayerColor();
            playerCount++;
            playerGameStats.Add("player2", GameStats.Player2Score);
            gameObjectList.Add("player2", player2);
            playerScoresList.Add("player2", p2Score);
        }
        if (GameStats.Player3)
        {
            p3Score = player3.GetComponent<PlayerScore>();
            p3Score.PlayerColor();
            playerCount++;
            playerGameStats.Add("player3", GameStats.Player3Score);
            gameObjectList.Add("player3", player3);
            playerScoresList.Add("player3", p3Score);
        }
        if (GameStats.Player4)
        {
            p4Score = player4.GetComponent<PlayerScore>();
            p4Score.PlayerColor();
            playerCount++;
            playerGameStats.Add("player4", GameStats.Player4Score);
            gameObjectList.Add("player4", player4);
            playerScoresList.Add("player4", p4Score);
        }

        totalPlayers = playerCount;
    }
    

    private void Start()
    {
        Sort();
        for (int i = mySortedList.Count - 1; i >= 0; i--)
        {
            UpdateTransformSize(gameObjectList[mySortedList[i].Key], i, playerScoresList[mySortedList[i].Key]);
        } 
    }

    void Sort()
    {
        mySortedList = playerGameStats.OrderBy(d => d.Value).ToList();
    }

    void UpdateTransformSize(GameObject go, int counter, PlayerScore ps)
    {
        if (!hasChosenWinner)
        {
            hasChosenWinner = true;
            StartCoroutine(WinnerText(ps.playerColorText));
        }


        if (counter == totalPlayers - 1)
        {
            go.transform.localScale *= 3;
            if (go.GetComponent<VehicleRandomizer>().GetGameObject().GetComponent<CarController>())
            {
                go.GetComponent<VehicleRandomizer>().GetGameObject().GetComponent<CarController>().m_FullTorqueOverAllWheels *= 2;
            }
            
        }
        else if (counter == 0)
        {
            go.transform.localScale *= 0.5f;
        }
    }

    IEnumerator WinnerText(string player)
    {
        WaitForSeconds waitTime = new WaitForSeconds(2);
        while (true)
        {
            message.text = player + " " + RandomMessage();
            yield return waitTime;
        }
    }

    string RandomMessage()
    {
        int rng = Random.Range(0, winnerMessages.Length);

            if (hasRunOnce)
            {
                prevMessage = curMessage;
                while (rng == prevMessage)
                {
                    rng = Random.Range(0, winnerMessages.Length);
                }
            }
            
            curMessage = rng;
            hasRunOnce = true;
        return winnerMessages[rng];
    }

}
