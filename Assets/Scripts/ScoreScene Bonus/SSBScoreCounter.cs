using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSBScoreCounter : MonoBehaviour
{
    public GameObject[] charObjArray;
    public int score = 0;
    private List<GameObject> spawnedScore = new List<GameObject>();
    public int playerNum;
    public Transform ScorePos;

    private void Start()
    {
        switch (playerNum)
        {
            case 1:
                GameStats.Player1Score -= 10;
                score = GameStats.Player1Score;
                break;
            case 2:
                GameStats.Player2Score -= 10;
                score = GameStats.Player2Score;
                break;
            case 3:
                GameStats.Player3Score -= 10;
                score = GameStats.Player3Score;
                break;
            case 4:
                GameStats.Player4Score -= 10;
                score = GameStats.Player4Score;
                break;
            default:
                break;
        }
        SpawnScore();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "point")
        {
            foreach (GameObject score in spawnedScore)
            {
                Destroy(score);
            }
            score++;
            SpawnScore();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "point")
        {
            foreach (GameObject score in spawnedScore)
            {
                Destroy(score);
            }
            score--;
            SpawnScore();
        }
    }


    void SpawnScore()
    {
        if (score >= 0)
        {
            StringToCharArray(score.ToString(), ScorePos);
        }
    }


    void StringToCharArray(string scoreString, Transform position)
    {
        int temp;
        Vector3 offset = Vector3.forward;
        char[] scoreCharArray = scoreString.ToCharArray();

        for (int i = 0; i < scoreCharArray.Length; i++)
        {
            temp = (int)System.Char.GetNumericValue(scoreCharArray[i]);
            var num = Instantiate(charObjArray[temp], position.position + offset, position.rotation);
            spawnedScore.Add(num);
            offset += Vector3.forward * 2;
        }

    }
}
