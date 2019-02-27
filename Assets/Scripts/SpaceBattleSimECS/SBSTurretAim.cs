using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBSTurretAim : MonoBehaviour
{
    public SBSRotation SBSrotation;

    private void Update()
    {
        if (SBSrotation.target == null)
        {
            return;
        }
        var pos = SBSrotation.target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(pos);
    }
}
