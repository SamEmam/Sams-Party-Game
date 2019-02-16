using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Camera mainCamera;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
    }
}
