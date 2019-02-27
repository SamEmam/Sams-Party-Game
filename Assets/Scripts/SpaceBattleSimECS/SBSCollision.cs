using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBSCollision : MonoBehaviour
{
    public int damage;
    public GameObject impactEffect;
    public string enemyTag;

    public void OnTriggerEnter(Collider col)
    {

        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
        if (col.gameObject.tag == enemyTag && col.gameObject.GetComponent<SBSHP>() != null)
        {
            col.gameObject.GetComponent<SBSHP>().health -= damage;
            //add an explosion or something
            Instantiate(impactEffect, transform.position, Quaternion.Inverse(transform.rotation));
            //destroy the projectile that just caused the trigger collision
            Destroy(gameObject);


        }
    }
}
