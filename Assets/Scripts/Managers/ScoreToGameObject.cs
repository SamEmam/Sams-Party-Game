using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreToGameObject : MonoBehaviour
{
    public GameObject player1, player2, player3, player4;
    private string p1String, p2String, p3String, p4String;
    public Transform p1ScorePos, p2ScorePos, p3ScorePos, p4ScorePos;
    public GameObject[] charObjArray;


    private void Awake()
    {
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);

        // Test code
        //p1String = "12";
        //p2String = "14";
        //p3String = "425";
        //p4String = "7";
        //StringToCharArray(p1String, p1ScorePos);
        //StringToCharArray(p2String, p2ScorePos);
        //StringToCharArray(p3String, p3ScorePos);
        //StringToCharArray(p4String, p4ScorePos);

        if (GameStats.Player1)
        {
            player1.SetActive(true);
            p1String = GameStats.Player1Score.ToString();
            StringToCharArray(p1String, p1ScorePos);
        }
        if (GameStats.Player2)
        {
            player2.SetActive(true);
            p2String = GameStats.Player2Score.ToString();
            StringToCharArray(p2String, p2ScorePos);

        }
        if (GameStats.Player3)
        {
            player3.SetActive(true);
            p3String = GameStats.Player3Score.ToString();
            StringToCharArray(p3String, p3ScorePos);
        }
        if (GameStats.Player4)
        {
            player4.SetActive(true);
            p4String = GameStats.Player4Score.ToString();
            StringToCharArray(p4String, p4ScorePos);
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
            Instantiate(charObjArray[temp], position.position + offset, position.rotation);
            offset += Vector3.forward * 3;
        }
        
    }

    
}
