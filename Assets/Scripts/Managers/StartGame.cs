using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public MainMenu mainMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("StartButton"))
        {
            mainMenu.RandomLevel();
        }
    }
}
