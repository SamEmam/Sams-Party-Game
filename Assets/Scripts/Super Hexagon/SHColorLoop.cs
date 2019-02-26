using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHColorLoop : MonoBehaviour
{
    public float r, g, b;
    

    // Update is called once per frame
    void Update()
    {
        if (r == 255 && g < 255 && b == 0)
        {
            g++;
        }

        if (r > 0 && g == 255 && b == 0)
        {
            r--;
        }

        if (r == 0 && g == 255 && b < 255)
        {
            b++;
        }

        if (r == 0 && g > 0 && b == 255)
        {
            g--;
        }

        if (r < 255 && g == 0 && b == 255)
        {
            r++;
        }

        if (r == 255 && g == 0 && b > 0)
        {
            b--;
        }
    }
}
