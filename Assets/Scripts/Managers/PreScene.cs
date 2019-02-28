using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PreScene : MonoBehaviour
{
    public float scoreScreenCounter = 10f;

    public TextMeshProUGUI countdown;

    private bool newScene = false;

    public SceneFader sceneFader;

    public int levelToLoad;

    private void Update()
    {
        if (scoreScreenCounter <= 0 && !newScene)
        {
            PlayLevel(levelToLoad);
            newScene = true;
        }

        scoreScreenCounter -= Time.deltaTime;
        countdown.text = "Match begins in: " + (int)scoreScreenCounter;
    }



    public void PlayLevel(int level)
    {
        sceneFader.FadeTo(level);
    }


}

