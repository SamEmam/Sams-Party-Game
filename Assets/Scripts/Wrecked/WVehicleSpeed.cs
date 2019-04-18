using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class WVehicleSpeed : MonoBehaviour
{
    public CarController carC; 
    public Transform target;
    public Transform thisObj;
    public float slipLimit;
    public float maxSlip;
    public float minSlip;
    public float maxDist;
    public float minDist;

    private void Update()
    {
        SpeedEvaluator();
        carC.m_SlipLimit = slipLimit;
    }

    public void SpeedEvaluator()
    {
        var dist = Vector3.Distance(thisObj.position, target.position);

        if (dist > maxDist)
        {
            // target is far away, set max speed;
            slipLimit = maxSlip;
        }
        else if (dist < minDist)
        {
            // target is close, set min speed;
            slipLimit = minSlip;
        }
        else
        {
            // target is between max/min dist, set speed proportional
            var distRatio = (dist - minDist) / (maxDist - minDist);
            var diffSpeed = maxSlip - minSlip;

            // Final calc
            slipLimit = (distRatio * diffSpeed) + minSlip;
        }
    }
}
