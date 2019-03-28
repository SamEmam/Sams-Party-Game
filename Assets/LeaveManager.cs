using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class LeaveManager : MonoBehaviour
{
    public XboxController controller1;
    public XboxController controller2;
    public XboxController controller3;
    public XboxController controller4;

    public GameObject player1, player2, player3, player4;

    private void Update()
    {

        if (XCI.GetButtonDown(XboxButton.Back, controller1))
        {
            GameStats.Player1 = false;
            GameStats.Player1Score = 0;
            player1.SetActive(false);
        }
        if (XCI.GetButtonDown(XboxButton.Back, controller2))
        {
            GameStats.Player2 = false;
            GameStats.Player2Score = 0;
            player2.SetActive(false);
        }
        if (XCI.GetButtonDown(XboxButton.Back, controller3))
        {
            GameStats.Player3 = false;
            GameStats.Player3Score = 0;
            player3.SetActive(false);
        }
        if (XCI.GetButtonDown(XboxButton.Back, controller4))
        {
            GameStats.Player4 = false;
            GameStats.Player4Score = 0;
            player4.SetActive(false);
        }
        

    }
}
