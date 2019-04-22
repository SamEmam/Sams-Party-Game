using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListenerController : MonoBehaviour
{
    public Transform p1, p2, p3, p4;
    public float speed = 2f;
    

    private void Update()
    {
        Vector3 tempPos = Vector3.zero;
        float count = 0f;
        if (p1 && p1.gameObject.activeSelf)
        {
            tempPos += p1.position;
            count++;
        }
        if (p2 && p2.gameObject.activeSelf)
        {
            tempPos += p2.position;
            count++;
        }
        if (p3 && p3.gameObject.activeSelf)
        {
            tempPos += p3.position;
            count++;
        }
        if (p4 && p4.gameObject.activeSelf)
        {
            tempPos += p4.position;
            count++;
        }
        
        tempPos = tempPos / count;

        transform.position = Vector3.Lerp(transform.position, tempPos, speed * Time.deltaTime);
    }

}
