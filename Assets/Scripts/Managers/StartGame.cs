using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class StartGame : MonoBehaviour
{
    public MainMenu mainMenu;

    public XboxController controller;
    public int scenesInBuild = 32;
    public List<int> tempList;
    

    private void Start()
    {
        for (int i = 2; i <= scenesInBuild; i++)
        {
            tempList.Add(i);
        }

        //for (int i = 0; i < tempList.Count; i++)
        //{
        //    int temp = tempList.Count;
        //    int randomIndex = Random.Range(i, tempList.Count);
        //    tempList[i] = tempList[randomIndex];
        //    tempList[randomIndex] = temp;
        //}

        for (int i = 0; i < tempList.Count - 1; i++)
        {
            var r = Random.Range(i, tempList.Count);
            var temp = tempList[i];
            tempList[i] = tempList[r];
            tempList[r] = temp;
        }

        GameStats.LevelList = tempList;
        Debug.Log(GameStats.LevelList.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (XCI.GetButtonDown(XboxButton.Start,controller))
        {
            mainMenu.RandomLevel();
            GameStats.RoundsPlayed++;
        }
    }
}
