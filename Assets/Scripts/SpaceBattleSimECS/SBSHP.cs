using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBSHP : MonoBehaviour
{
    public GameObject particlePrefab;
    public GameObject deadSpaceshipPrefab;
    public int health = 100;
    public int startHP;
    public Transform respawnPoint;

    private void Start()
    {
        startHP = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            
            // instantiate death
            GameObject obj = Instantiate(deadSpaceshipPrefab, transform.position, transform.rotation);
            GameObject particle = Instantiate(particlePrefab, transform.position, transform.rotation);
            // respawn
            transform.position = respawnPoint.position;
            health = startHP;
            // despawn death
            Destroy(obj, 20f);
            Destroy(particle, 20f);
        }
    }
}
