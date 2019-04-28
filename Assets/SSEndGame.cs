using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSEndGame : MonoBehaviour
{
    public MainMenu mainMenu;


    private void Awake()
    {
        if (GameStats.LevelPointer == GameStats.MaxRounds)
        {
            if (!GameStats.EndlessGame)
            {
                mainMenu.EndGame();
            }
        }
        else
        {
            mainMenu.BonusLevel();
        }
    }
}
