using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBSTargetInRange : MonoBehaviour
{
    public bool targetInRange;
    public int minRange = 135;
    public int maxRange = 225;
    public Transform turretBase;

    public SBSRotation SBSrotation;

    // Update is called once per frame
    void Update()
    {
        var directionToTarget = turretBase.position - SBSrotation.target.position;
        var angle = Vector3.Angle(turretBase.forward, directionToTarget);

        if (Mathf.Abs(angle) > minRange && Mathf.Abs(angle) < maxRange)
        {
            targetInRange = true;
        }
        else
        {
            targetInRange = false;
        }
    }
}
