using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 70f;
    public float lifeSpan = 10f;
    public string enemyTag = "Player";

    public GameObject impactEffect;

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.forward * speed * Time.deltaTime;
        Destroy(gameObject, 10f);

    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        Destroy(gameObject,5f);
    }

    public void OnTriggerEnter(Collider col)
    {

        
        if (col.gameObject.tag == "Player")
        {
            //add an explosion or something
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, Quaternion.Inverse(transform.rotation));
            
            Destroy(effectIns, 5f);

            //destroy the projectile that just caused the trigger collision
            //Destroy(gameObject, 5f);
        }
    }
}
