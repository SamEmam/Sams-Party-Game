using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using XboxCtrlrInput;

public class JoinManager : MonoBehaviour
{

    public TextMeshProUGUI P1, P2, P3, P4;

    public XboxController controller1;
    public XboxController controller2;
    public XboxController controller3;
    public XboxController controller4;
    private static bool didQueryNumOfCtrlrs = false;

    private void Awake()
    {
        P1.text = "P1: " + GameStats.Player1;
        P2.text = "P2: " + GameStats.Player2;
        P3.text = "P3: " + GameStats.Player3;
        P4.text = "P4: " + GameStats.Player4;
    }

    private void Start()
    {

        //switch (controller)
        //{
        //    case XboxController.First: GetComponent<Renderer>().material = matRed; break;
        //    case XboxController.Second: GetComponent<Renderer>().material = matGreen; break;
        //    case XboxController.Third: GetComponent<Renderer>().material = matBlue; break;
        //    case XboxController.Fourth: GetComponent<Renderer>().material = matYellow; break;
        //}



        // Call for the number of connected controllers once
        if (!didQueryNumOfCtrlrs)
        {
            didQueryNumOfCtrlrs = true;

            int queriedNumberOfCtrlrs = XCI.GetNumPluggedCtrlrs();

            if (queriedNumberOfCtrlrs == 1)
            {
                Debug.Log("Only " + queriedNumberOfCtrlrs + " Xbox controller plugged in.");
            }
            else if (queriedNumberOfCtrlrs == 0)
            {
                Debug.Log("No Xbox controllers plugged in!");
            }
            else
            {
                Debug.Log(queriedNumberOfCtrlrs + " Xbox controllers plugged in.");
            }

            XCI.DEBUG_LogControllerNames();

            // This code only works on Windows
            if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
            {
                Debug.Log("Windows Only:: Any Controller Plugged in: " + XCI.IsPluggedIn(XboxController.Any).ToString());

                Debug.Log("Windows Only:: Controller 1 Plugged in: " + XCI.IsPluggedIn(XboxController.First).ToString());
                Debug.Log("Windows Only:: Controller 2 Plugged in: " + XCI.IsPluggedIn(XboxController.Second).ToString());
                Debug.Log("Windows Only:: Controller 3 Plugged in: " + XCI.IsPluggedIn(XboxController.Third).ToString());
                Debug.Log("Windows Only:: Controller 4 Plugged in: " + XCI.IsPluggedIn(XboxController.Fourth).ToString());
            }
        }
    }

    private void Update()
    {

        if (XCI.GetButtonDown(XboxButton.A,controller1))
        {
            GameStats.Player1 = true;
            P1.text = "P1: " + GameStats.Player1;
        }
        if (XCI.GetButtonDown(XboxButton.A, controller2))
        {
            GameStats.Player2 = true;
            P2.text = "P2: " + GameStats.Player2;
        }
        if (XCI.GetButtonDown(XboxButton.A, controller3))
        {
            GameStats.Player3 = true;
            P3.text = "P3: " + GameStats.Player3;
        }
        if (XCI.GetButtonDown(XboxButton.A, controller4))
        {
            GameStats.Player4 = true;
            P4.text = "P4: " + GameStats.Player4;
        }

        //if (!GameStats.Player1)
        //{
        //    if (Input.GetButtonDown("Join_P1"))
        //    {
        //        GameStats.Player1 = true;
        //        P1.text = "P1: " + GameStats.Player1;
        //    }
        //}
        
    }
    
}
