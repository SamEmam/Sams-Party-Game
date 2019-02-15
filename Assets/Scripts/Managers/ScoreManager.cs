using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI P1Score,P2Score,P3Score,P4Score;

    private void Awake()
    {
        P1Score.color = new Color32(255, 0, 0, 255);
        P2Score.color = new Color32(0, 0, 255, 255);
        P3Score.color = new Color32(0, 255, 0, 255);
        P4Score.color = new Color32(255, 255, 0, 255);
    }

    private void LateUpdate()
    {
        P1Score.text = "P1 Score: " + GameStats.Player1Score;
        P2Score.text = "P2 Score: " + GameStats.Player2Score;
        P3Score.text = "P3 Score: " + GameStats.Player3Score;
        P4Score.text = "P4 Score: " + GameStats.Player4Score;
    }
}
