﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class JoinManager : MonoBehaviour
{
    

    public XboxController controller1;
    public XboxController controller2;
    public XboxController controller3;
    public XboxController controller4;
    private static bool didQueryNumOfCtrlrs = false;

    public GameObject player1, player2, player3, player4;

    private void Awake()
    {

        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);
    }

    private void Start()
    {
        
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
            player1.SetActive(true);
        }
        if (XCI.GetButtonDown(XboxButton.A, controller2))
        {
            GameStats.Player2 = true;
            player2.SetActive(true);
        }
        if (XCI.GetButtonDown(XboxButton.A, controller3))
        {
            GameStats.Player3 = true;
            player3.SetActive(true);
        }
        if (XCI.GetButtonDown(XboxButton.A, controller4))
        {
            GameStats.Player4 = true;
            player4.SetActive(true);
        }
        

        
    }
    
}
