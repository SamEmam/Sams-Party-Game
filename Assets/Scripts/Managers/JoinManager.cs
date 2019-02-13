using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JoinManager : MonoBehaviour
{

    public TextMeshProUGUI P1, P2, P3, P4;

    private void Awake()
    {
        P1.text = "P1: " + GameStats.Player1;
        P2.text = "P2: " + GameStats.Player2;
        P3.text = "P3: " + GameStats.Player3;
        P4.text = "P4: " + GameStats.Player4;
    }

    private void Update()
    {
        if (!GameStats.Player1)
        {
            if (Input.GetButtonDown("Join_P1"))
            {
                GameStats.Player1 = true;
                P1.text = "P1: " + GameStats.Player1;
            }
        }
        if (!GameStats.Player2)
        {
            if (Input.GetButtonDown("Join_P2"))
            {
                GameStats.Player2 = true;
                P2.text = "P2: " + GameStats.Player2;
            }
        }
        if (!GameStats.Player3)
        {
            if (Input.GetButtonDown("Join_P3"))
            {
                GameStats.Player3 = true;
                P3.text = "P3: " + GameStats.Player3;
            }
        }
        if (!GameStats.Player4)
        {
            if (Input.GetButtonDown("Join_P4"))
            {
                GameStats.Player4 = true;
                P4.text = "P4: " + GameStats.Player4;
            }
        }
    }
    
}
