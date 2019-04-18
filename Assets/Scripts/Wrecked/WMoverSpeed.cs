using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WMoverSpeed : MonoBehaviour
{
    public WMover wMover;
    public Transform target;
    public Transform thisObj;
    public float speed;
    public float maxSpeed;
    public float minSpeed;
    public float maxDist;
    public float minDist;

    private void Update()
    {
        SpeedEvaluator();
        wMover.speed = speed;
    }

    public void SpeedEvaluator()
    {
        var dist = Vector3.Distance(thisObj.position, target.position);

        if (dist > maxDist)
        {
            // target is far away, set max speed;
            speed = maxSpeed;
        }
        else if (dist < minDist)
        {
            // target is close, set min speed;
            speed = minSpeed;
        }
        else
        {
            // target is between max/min dist, set speed proportional
            var distRatio = (dist - minDist) / (maxDist - minDist);
            var diffSpeed = maxSpeed - minSpeed;

            // Final calc
            speed = (distRatio * diffSpeed) + minSpeed;
        }
    }
}
