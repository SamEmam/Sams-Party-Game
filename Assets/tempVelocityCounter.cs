using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempVelocityCounter : MonoBehaviour
{
    private Rigidbody rb;
    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = rb.velocity.magnitude;
    }
}
