using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class GameSettings : MonoBehaviour
{
    public XboxController controller;
    public GameObject oneOfEach;
    public GameObject endless;
    public GameObject wrecked;
    public int amountOfGames;
    public int pointer = 0;
    public RoundsCounter rc;

    // Start is called before the first frame update
    void Start()
    {
        oneOfEach.SetActive(true);
        endless.SetActive(false);
        wrecked.SetActive(false);
        amountOfGames = GameStats.LevelList.Count;
    }

    // Update is called once per frame
    void Update()
    {

        if (XCI.GetButtonDown(XboxButton.DPadRight, controller))
        {
            switch (pointer) {
                case 0:
                    oneOfEach.SetActive(false);
                    endless.SetActive(true);
                    rc.DestroyScore();
                    pointer = 1;
                    break;
                case 1:
                    endless.SetActive(false);
                    wrecked.SetActive(true);
                    rc.DestroyScore();
                    rc.BuildScore();
                    pointer = 2;
                    break;
                case 2:
                    wrecked.SetActive(false);
                    oneOfEach.SetActive(true);
                    rc.DestroyScore();
                    rc.BuildScore();
                    pointer = 0;
                    break;
            }
        }

        if (XCI.GetButtonDown(XboxButton.DPadLeft, controller))
        {
            switch (pointer)
            {
                case 0:
                    oneOfEach.SetActive(false);
                    wrecked.SetActive(true);
                    rc.DestroyScore();
                    rc.BuildScore();
                    pointer = 2;
                    break;
                case 1:
                    endless.SetActive(false);
                    oneOfEach.SetActive(true);
                    rc.DestroyScore();
                    rc.BuildScore();
                    pointer = 0;
                    break;
                case 2:
                    wrecked.SetActive(false);
                    endless.SetActive(true);
                    rc.DestroyScore();
                    pointer = 1;
                    break;
            }
        }
        if (pointer == 1)
        {
            return;
        }

        if (XCI.GetButtonDown(XboxButton.DPadUp, controller))
        {
            if (amountOfGames < GameStats.LevelList.Count)
            {
                amountOfGames++;
            }
        }

        if (XCI.GetButtonDown(XboxButton.DPadDown, controller))
        {
            if (amountOfGames > 1)
            {
                amountOfGames--;
            }
        }
    }
}
