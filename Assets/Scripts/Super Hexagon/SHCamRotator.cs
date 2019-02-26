using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHCamRotator : MonoBehaviour
{
    public Camera cam;
    public SHColorLoop SHcolor;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * 30f);
        cam.backgroundColor = new Color(SHcolor.r / 255, SHcolor.g / 255, SHcolor.b / 255, 100);
    }
}
