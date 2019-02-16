using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWhenHit : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 originalPos;
    private Vector3 originalRot;
    private bool isHit = false;

    private float respawnTime = 10f;
    private float spawnTimeLeft;

    // Use this for initialization
    void Start()
    {

        rb = transform.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;

        originalPos = transform.position;
        originalRot = transform.eulerAngles;
        spawnTimeLeft = respawnTime;
    }

    private void FixedUpdate()
    {
        Respawn();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        if (rb == null)
        {
            return;
        }

        if (col.relativeVelocity.magnitude > 0.5 && col.gameObject.tag != "Foliage")
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            isHit = true;
        }

        else if (col.relativeVelocity.magnitude > 1.5 && col.gameObject.tag == "Foliage")
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            isHit = true;

        }


    }

    void Respawn()
    {
        if (spawnTimeLeft < 0)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
            transform.position = originalPos;
            transform.eulerAngles = originalRot;
            spawnTimeLeft = respawnTime;
            isHit = false;


        }

        if (isHit)
        {
            spawnTimeLeft -= Time.deltaTime;
        }
        else
        {
            spawnTimeLeft = respawnTime;
        }
    }


}
