using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float timeUntilShrink = 5f;
    public Vector3 targetScale = new Vector3(10,30,10);
    private bool shrinking = false;
    public float shrinkSpeed = 0.1f;
    public float rotateSpeed = 1f;
    public int pauseSize = 20;
    public float shrinkSensitivity = 0.04f;


    private Vector3 tempSize;

    void Shrink()
    {
        shrinking = true;
    }

    void Update()
    {
        timeUntilShrink -= Time.deltaTime;
        if (timeUntilShrink <= 0)
        {
            Shrink();
        }

        

        if (shrinking)
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
            tempSize = transform.localScale;
            tempSize.x -= Time.deltaTime * shrinkSpeed;
            tempSize.z -= Time.deltaTime * shrinkSpeed;
            transform.localScale = tempSize;
            
        }

        if (transform.localScale.x % pauseSize <= shrinkSensitivity && shrinking)
        {
            timeUntilShrink = 5f;
            shrinking = false;
        }

        if (transform.localScale.x <= targetScale.x)
            transform.localScale = targetScale;
    }
}
