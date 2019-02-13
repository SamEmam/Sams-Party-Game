using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float timeUntilShrink = 5f;
    public float targetScale = 10f;
    public float shrinkSpeed = 0.1f;
    private bool shrinking = false;

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
            tempSize = transform.localScale;
            tempSize.x -= Time.deltaTime * shrinkSpeed;
            tempSize.z -= Time.deltaTime * shrinkSpeed;
            transform.localScale = tempSize;
            
        }

        if (transform.localScale.x % 20 <= 0.05 && shrinking)
        {
            timeUntilShrink = 5f;
            shrinking = false;
        }

        if (transform.localScale.x < targetScale)
            transform.localScale = new Vector3(10, 30, 10);
    }
}
