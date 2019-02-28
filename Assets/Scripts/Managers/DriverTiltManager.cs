using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class DriverTiltManager : MonoBehaviour
{

    public XboxController controller;
    public Transform rightShoulder;
    public Transform leftShoulder;
    public float maxTilt = 15f;
    private Vector3 rightStartRotation = new Vector3(0, 180, 270);
    private Vector3 leftStartRotation = new Vector3(0, 180, 270);
    

    // Update is called once per frame
    void FixedUpdate()
    {
        rightShoulder.localEulerAngles = new Vector3(rightStartRotation.x, rightStartRotation.y, rightStartRotation.z + (XCI.GetAxis(XboxAxis.LeftStickX, controller) * maxTilt));
        leftShoulder.localEulerAngles = new Vector3(leftStartRotation.x, leftStartRotation.y, leftStartRotation.z + (XCI.GetAxis(XboxAxis.LeftStickX, controller) * maxTilt));
    }
}
