using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundsCounter : MonoBehaviour
{
    public GameObject[] charObjArray;
    private List<GameObject> spawnedScore = new List<GameObject>();
    public GameSettings gs;
    private int counter;
    

    private void Update()
    {
        if (gs.amountOfGames != counter)
        {
            counter = gs.amountOfGames;
            DestroyScore();
            BuildScore();
        }
    }

    public void DestroyScore()
    {
        foreach (GameObject score in spawnedScore)
        {
            Destroy(score);
        }
    }

    public void BuildScore()
    {
        StringToCharArray(counter.ToString(), transform);
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
            offset += Vector3.forward * 2.5f;
        }

    }
}
