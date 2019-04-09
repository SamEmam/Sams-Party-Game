using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRotation : MonoBehaviour
{
    public bool x, y, z;

    private void Update()
    {
        var rot = transform.rotation;
        if (x)
        {
            rot.x = 0;
        }
        if (y)
        {
            rot.y = 0;
        }
        if (z)
        {
            rot.z = 270;
        }

        transform.rotation = Quaternion.Euler(rot.x,rot.y,rot.z);
    }
}
