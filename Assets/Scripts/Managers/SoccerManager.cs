using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerManager : MonoBehaviour
{
    //public string levelToLoad = "MainMenu";

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    //public Soccer soccer;

    private void Start()
    {
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);

        Debug.Log("P1: " + GameStats.Player1);
        Debug.Log("P2: " + GameStats.Player2);
        Debug.Log("P3: " + GameStats.Player3);
        Debug.Log("P4: " + GameStats.Player4);

        //soccer.playersLeft = 0;

        if (GameStats.Player1)
        {
            player1.SetActive(true);
            //soccer.playersLeft++;

        }
        if (GameStats.Player2)
        {
            player2.SetActive(true);
            //soccer.playersLeft++;
        }
        if (GameStats.Player3)
        {
            player3.SetActive(true);
            //soccer.playersLeft++;
        }
        if (GameStats.Player4)
        {
            player4.SetActive(true);
            //soccer.playersLeft++;
        }
        //Debug.Log("Players left: " + soccer.playersLeft);
    }
}
