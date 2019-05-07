using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WVolleyMissile : MonoBehaviour
{
    [Header("Attributes")]
    public float delayBeforeActive = 2.5f;
    public float impactForce;
    private float rotationSpeed = 750f;
    private bool isActive = false;
    private float closestDistance = float.MaxValue;


    [Header("Setup")]
    public GameObject parentGO;
    public Rigidbody rb;
    public ParticleSystem thrustParticle;
    public ParticleSystem explosion;
    private ParticleSystem.EmissionModule emit;
    private Transform closetsTarget;

    private float radius = 10f;
    private float upwardsThrust = 10f;

    private void Start()
    {
        emit = thrustParticle.emission;
        //emit.enabled = false;
        StartCoroutine(StartDelay());
    }

    private void Update()
    {
        if (isActive)
        {
            RotateTowardsTarget();
            MoveForward();
        }
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(delayBeforeActive);
        //emit.enabled = true;
        FindNearestTarget();
        isActive = true;
    }

    private void FindNearestTarget ()
    {
        GameObject[] GOs = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject GO in GOs)
        {
            float dist = Vector3.Distance(GO.transform.position, transform.position);
            if (dist < closestDistance && GO != parentGO)
            {
                closestDistance = dist;
                closetsTarget = GO.transform;
            }
        }
    }

    private void RotateTowardsTarget()
    {
        var direction = (closetsTarget.position - transform.position).normalized;
        var lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    private void MoveForward()
    {
        rb.AddForce(transform.forward * 40, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody hitRB = hit.GetComponent<Rigidbody>();
            if (hitRB != null && !hit.GetComponent<WNotAffected>())
            {
                hitRB.AddExplosionForce(impactForce, transform.position, radius, upwardsThrust, ForceMode.Impulse);
            }
        }

        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject, 3f);
    }
}
