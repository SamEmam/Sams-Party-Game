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

    public GameSettings gs;
    public List<int> wreckedScenes;
    

    private void Awake()
    {
        for (int i = 3; i <= scenesInBuild; i++)
        {
            tempList.Add(i);
        }
        

        for (int i = 0; i < tempList.Count - 1; i++)
        {
            var r = Random.Range(i, tempList.Count);
            var temp = tempList[i];
            tempList[i] = tempList[r];
            tempList[r] = temp;
        }

        GameStats.LevelList = tempList;

        GameStats.WreckedList = wreckedScenes;
    }

    // Update is called once per frame
    void Update()
    {
        if (XCI.GetButtonDown(XboxButton.Start,controller))
        {
            
            switch (gs.pointer)
            {
                case 0:
                    GameStats.MaxRounds = gs.amountOfGames;
                    break;
                case 1:
                    GameStats.EndlessGame = true;
                    break;
                case 2:
                    GameStats.MaxRounds = gs.amountOfGames;
                    GameStats.WreckedGame = true;
                    break;
            }


            mainMenu.RandomLevel();
            GameStats.RoundsPlayed++;
        }
    }
}
