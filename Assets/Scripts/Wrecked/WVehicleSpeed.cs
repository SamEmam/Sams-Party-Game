using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class WVehicleSpeed : MonoBehaviour
{
    public CarController carC; 
    public Transform target;
    public Transform thisObj;

    [Header("Distance")]
    public float maxDist;
    public float minDist;

    [Header("SlipLimit")]
    public float slipLimit;
    public float maxSlip;
    public float minSlip;

    [Header("Topspeed")]
    public float topSpeed;
    public float maxSpeed;
    public float minSpeed;


    private void Update()
    {
        SpeedEvaluator();
        carC.m_SlipLimit = slipLimit;
        carC.m_Topspeed = topSpeed;
    }

    public void SpeedEvaluator()
    {
        var dist = Vector3.Distance(thisObj.position, target.position);

        if (dist > maxDist)
        {
            // target is far away, set max speed;
            slipLimit = maxSlip;
            topSpeed = maxSpeed;
        }
        else if (dist < minDist)
        {
            // target is close, set min speed;
            slipLimit = minSlip;
            topSpeed = minSpeed;
        }
        else
        {
            // target is between max/min dist, set speed proportional
            var distRatio = (dist - minDist) / (maxDist - minDist);
            var diffSlip = maxSlip - minSlip;
            var diffSpeed = maxSpeed - minSpeed;

            // Final calc
            slipLimit = (distRatio * diffSlip) + minSlip;
            topSpeed = (distRatio * diffSpeed) + minSpeed;
        }
    }
}
