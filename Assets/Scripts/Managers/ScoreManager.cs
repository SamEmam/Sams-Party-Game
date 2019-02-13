using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI P1Score,P2Score,P3Score,P4Score;

    private void LateUpdate()
    {
        P1Score.text = "P1 Score: " + GameStats.Player1Score;
        P2Score.text = "P2 Score: " + GameStats.Player2Score;
        P3Score.text = "P3 Score: " + GameStats.Player3Score;
        P4Score.text = "P4 Score: " + GameStats.Player4Score;
    }
}
