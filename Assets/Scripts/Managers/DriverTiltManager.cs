using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class DriverTiltManager : MonoBehaviour
{

    public XboxController controller;
    public Transform rightShoulder;
    private Vector3 rightStartRotation = new Vector3(0, 180, 270);
    public Vector3 rightRotation;
    public Transform leftShoulder;
    public Vector3 leftStartRotation = new Vector3(0, 180, 270);
    public Vector3 leftRotation;

    // Start is called before the first frame update
    void Start()
    {
        rightRotation = rightStartRotation;
        leftRotation = leftShoulder.localEulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
        

        if (XCI.GetAxis(XboxAxis.LeftStickX, controller) > 0.1f)
        {
            rightShoulder.localEulerAngles = new Vector3(rightStartRotation.x, rightStartRotation.y, rightRotation.z + 15f);
            leftShoulder.localEulerAngles = new Vector3(leftStartRotation.x, leftStartRotation.y, leftRotation.z + 15f);
        }

        else if (XCI.GetAxis(XboxAxis.LeftStickX, controller) < -0.1f)
        {
            rightShoulder.localEulerAngles = new Vector3(rightStartRotation.x, rightStartRotation.y, rightRotation.z - 15f);
            leftShoulder.localEulerAngles = new Vector3(leftStartRotation.x, leftStartRotation.y, leftRotation.z - 15f);
        }

        else
        {
            rightShoulder.localEulerAngles = rightStartRotation;
            leftShoulder.localEulerAngles = leftStartRotation;
        }
    }
}
