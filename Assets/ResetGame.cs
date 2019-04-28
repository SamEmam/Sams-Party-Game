using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class ResetGame : MonoBehaviour
{
    public GameObject popup, yesOn, noOn, yesOff, noOff;
    public XboxController controller;
    public bool yesReset = false, canSwitch = false;
    public SceneFader sceneFader;


    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);
        yesOn.SetActive(false);
        yesOff.SetActive(true);
        noOff.SetActive(false);
        noOn.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (canSwitch)
        {
            if (XCI.GetButtonDown(XboxButton.Start, controller))
            {
                popup.SetActive(false);
                canSwitch = false;
                Time.timeScale = 1f;
            }

            if (XCI.GetButtonDown(XboxButton.DPadRight, controller) || XCI.GetButtonDown(XboxButton.DPadLeft, controller))
            {
                if (yesReset)
                {
                    yesReset = false;
                    yesOn.SetActive(false);
                    yesOff.SetActive(true);
                    noOff.SetActive(false);
                    noOn.SetActive(true);
                }
                else
                {
                    yesReset = true;
                    yesOff.SetActive(false);
                    yesOn.SetActive(true);
                    noOn.SetActive(false);
                    noOff.SetActive(true);

                }
            }

            if (XCI.GetButtonDown(XboxButton.A, controller))
            {
                if (yesReset)
                {
                    Time.timeScale = 1f;
                    ResetStats();
                    sceneFader.FadeTo(0);
                }
                else
                {
                    popup.SetActive(false);
                    canSwitch = false;
                    Time.timeScale = 1f;
                }
            }
        }

        if (XCI.GetButtonDown(XboxButton.Start, controller))
        {
            popup.SetActive(true);
            canSwitch = true;
            Time.timeScale = 0.025f;
        }

        

    }

    void ResetStats()
    {
        GameStats.Player1Score = 0;
        GameStats.Player2Score = 0;
        GameStats.Player3Score = 0;
        GameStats.Player4Score = 0;
        GameStats.Player1 = false;
        GameStats.Player2 = false;
        GameStats.Player3 = false;
        GameStats.Player4 = false;
        GameStats.EndlessGame = false;
        GameStats.WreckedGame = false;
        GameStats.BonusScenesPlayed = 0;
        GameStats.LevelsWithoutBonusScene = 0;
        GameStats.LevelPointer = 0;
        GameStats.RoundsPlayed = 0;
}
}
