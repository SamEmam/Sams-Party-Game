using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float speed = 1f;

    public float minSpeed = 20f;
    public float maxSpeed = 40f;

    public float minSize = 0.1f;
    public float maxSize = 1f;

    public float minTumble = 5f;
    public float maxTumble = 10f;

    private Rigidbody rb;
    public float lifetime = 5f;
    public float tumble;
    public bool randomize = false;
    private float size;

    private void Start()
    {
        if (randomize)
        {
            speed = Random.Range(minSpeed, maxSpeed);
            tumble = Random.Range(minTumble, maxTumble);
            size = Random.Range(minSize, maxSize);
            transform.localScale = new Vector3(size, size, size);
        }
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }

    private void Update()
    {
        //rb.AddTorque(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f),ForceMode.Force);
    }
}
