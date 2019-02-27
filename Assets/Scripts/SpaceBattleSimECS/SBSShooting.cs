using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBSShooting : MonoBehaviour
{
    public float fireRate = 1f;
    public float fireCountdown = 0f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public SBSRotation SBSrotation;
    public SBSTargetInRange SBStargetInRange;

    // Update is called once per frame
    void Update()
    {
        if (fireCountdown <= 0f && SBStargetInRange.targetInRange)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Destroy(bullet, 10f);

            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }
}
