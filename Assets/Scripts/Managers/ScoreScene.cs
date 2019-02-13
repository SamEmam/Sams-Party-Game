using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScene : MonoBehaviour
{
    public float scoreScreenCounter = 10;

    public MainMenu mainMenu;

    public TextMeshProUGUI countdown;

    private bool newScene = false;

    private void Update()
    {
        if (scoreScreenCounter <= 0 && !newScene)
        {
            mainMenu.RandomLevel();
            newScene = true;
        }

        scoreScreenCounter -= Time.deltaTime;
        countdown.text = "Next match in: " + (int)scoreScreenCounter;
    }


}
