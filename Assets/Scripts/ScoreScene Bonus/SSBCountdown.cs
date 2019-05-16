using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSBCountdown : MonoBehaviour
{

    private int countdown = 60;
    public GameObject[] charObjArray;
    public SSBScoreCounter p1, p2, p3, p4;
    public SceneFader sceneFader;

    private void Start()
    {
        InvokeRepeating("SpawnCountdown", 1f, 1f);
        GameStats.BonusScenesPlayed++;
        GameStats.LevelsWithoutBonusScene = 0;
    }

    private void Update()
    {
        if (countdown <= 0)
        {
            if (GameStats.Player1)
            {
                GameStats.Player1Score = p1.score;
            }
            if (GameStats.Player2)
            {
                GameStats.Player2Score = p2.score;
            }
            if (GameStats.Player3)
            {
                GameStats.Player3Score = p3.score;
            }
            if (GameStats.Player4)
            {
                GameStats.Player4Score = p4.score;
            }

            StartCoroutine(EndScene());
        }
    }

    IEnumerator EndScene()
    {
        //Time.timeScale = 0.25f;
        yield return new WaitForSeconds(1);
        //Time.timeScale = 1f;
        if (!GameStats.Player1 && !GameStats.Player2 && !GameStats.Player3 && !GameStats.Player4)
        {
            sceneFader.FadeTo("MainMenu");
        }
        sceneFader.FadeTo("ScoreScene");
    }


    void SpawnCountdown()
    {
        if (countdown >= 0)
        {
            StringToCharArray(countdown.ToString(), transform);
            countdown--;
        }
    }


    void StringToCharArray(string countdownString, Transform position)
    {
        int temp;
        Vector3 offset = Vector3.forward;
        char[] countdownCharArray = countdownString.ToCharArray();

        for (int i = 0; i < countdownCharArray.Length; i++)
        {
            temp = (int)System.Char.GetNumericValue(countdownCharArray[i]);
            var num = Instantiate(charObjArray[temp], position.position + offset, position.rotation);
            Destroy(num, 1f);
            offset += Vector3.forward * 2;
        }

    }
}
