using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCameraYaw : MonoBehaviour
{
    public CameraMultiTarget cam;

    private void LateUpdate()
    {
        cam.Yaw = transform.rotation.eulerAngles.y;
    }
}
