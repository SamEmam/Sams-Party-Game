using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAllRaceRigidbody : MonoBehaviour
{
    public VehicleRandomizer vRNG;
    public Speedometer speedometer;
    public RandomAllRace RAR;

    private void LateUpdate()
    {
        if (RAR.updatedCar)
        {
            RAR.updatedCar = false;
            speedometer.rb = vRNG.GetRigidbody();
        }
    }
}
