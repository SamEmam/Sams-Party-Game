using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBall : MonoBehaviour
{
    public Vector3 startPos;
    private Vector3 zeroV = new Vector3(0,0,0);
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetBall()
    {
        transform.position = startPos;
        rb.velocity = zeroV;
        rb.angularVelocity = zeroV;
    }
}
