using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KOTHManager : MonoBehaviour
{
    private BoxCollider killFloor;
    private int deathCount;
    private int playersLeft;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    private void Awake()
    {
        killFloor = GetComponent<BoxCollider>();
        if (GameStats.Player1)
        {
            player1.SetActive(true);
            playersLeft++;
        }
        if (GameStats.Player2)
        {
            player2.SetActive(true);
            playersLeft++;
        }
        if (GameStats.Player3)
        {
            player3.SetActive(true);
            playersLeft++;
        }
        if (GameStats.Player4)
        {
            player4.SetActive(true);
            playersLeft++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            deathCount++;
        }
    }
}

