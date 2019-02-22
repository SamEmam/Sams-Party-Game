using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class BSGameManager : MonoBehaviour
{
    

    public XboxController controller;

    

    void Update()
    {
        if (XCI.GetButton(XboxButton.A,controller))
        {
            BSMovingCube.CurrentCube.Stop();
        }
    }
}
