using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class StartGame : MonoBehaviour
{
    public MainMenu mainMenu;

    public XboxController controller;

    // Update is called once per frame
    void Update()
    {
        if (XCI.GetButtonDown(XboxButton.Start,controller))
        {
            mainMenu.RandomLevel();
        }
    }
}
