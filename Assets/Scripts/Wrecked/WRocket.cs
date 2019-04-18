using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WRocket : MonoBehaviour
{
    public Rigidbody rb;
    public float impactForce;
    public ParticleSystem explosion;

    private float radius = 10f;
    private float upwardsThrust = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider hit in colliders)
        {
            Rigidbody hitRB = hit.GetComponent<Rigidbody>();
            if (hitRB != null)
            {
                hitRB.AddExplosionForce(impactForce, transform.position, radius, upwardsThrust, ForceMode.Impulse);
            }
        }
        
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject,2f);
    }
}
