using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WLandmine : MonoBehaviour
{
    [Header("Attributes")]
    public float impactForce;
    public float radius = 50f;
    public float upwardsThrust = 5f;

    [Header("Setup")]
    public ParticleSystem explosion;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
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
            Destroy(gameObject);
        }
    }
}
