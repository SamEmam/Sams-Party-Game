using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WRocketDirection : MonoBehaviour
{
    public Rigidbody rb;

    private Vector3 angleCorrection = new Vector3(90,0,0);

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(rb.velocity);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + angleCorrection);
    }
}
