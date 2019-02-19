using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour
{

    public ParticleSystem explosionParticles;
    public float blastRadius = 1;
    public int damage = 1;

    private bool explode;
    private float countdown = 5f;

    

    void OnCollisionEnter()
    {
        Instantiate(explosionParticles, transform.position, Quaternion.LookRotation(Vector3.forward));
        //explosionParticles.SetActive(true);
        //explosionParticles.transform.SetParent(null);
        explode = true;


    }

    void FixedUpdate()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            explode = true;
        }

        if (explode)
        {
            
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, blastRadius);
            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].GetComponent<IDamageable>() != null)
                {
                    hitColliders[i].GetComponent<IDamageable>().Damage(damage, hitColliders[i].transform.position);
                }

                if (hitColliders[i].GetComponent<Rigidbody>() != null)
                {
                    hitColliders[i].GetComponent<Rigidbody>().AddExplosionForce(1000, transform.position, blastRadius);
                }
            }
            Destroy(this.gameObject);
            //this.gameObject.SetActive(false);
        }
    }

}