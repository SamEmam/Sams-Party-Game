using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class SoccerJumpMananger : MonoBehaviour
{
    private HoverMotor hm;
    public XboxController controller;

    private void Start()
    {
        hm = GetComponent<HoverMotor>();
    }

    private void Update()
    {
        if (XCI.GetButton(XboxButton.A,controller))
        {
            hm.enabled = true;
        }
        else
        {
            hm.enabled = false;
        }
    }
}
