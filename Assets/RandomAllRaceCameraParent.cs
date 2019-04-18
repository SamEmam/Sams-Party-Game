using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAllRaceCameraParent : MonoBehaviour
{
    public Camera cam;
    public GameObject vehicle;
    public VehicleRandomizer vRNG;

    private void Start()
    {
        vehicle = vRNG.GetGameObject();
        cam.transform.SetParent(vehicle.transform);
        cam.transform.localPosition = new Vector3(0, 5, -8);
        cam.transform.localRotation = Quaternion.Euler(new Vector3(15, 0, 0));
    }

    private void Update()
    {
        if (vehicle.activeSelf == false)
        {
            vehicle = vRNG.GetGameObject();
            cam.transform.SetParent(vehicle.transform);
            cam.transform.localPosition = new Vector3(0, 5, -8);
            cam.transform.localRotation = Quaternion.Euler(new Vector3(15, 0, 0));

            
        }
    }
}
