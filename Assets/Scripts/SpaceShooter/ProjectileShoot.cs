using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

public class ProjectileShoot : MonoBehaviour
{

    public Rigidbody projectile;
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;
    public float projectileForce = 500f;
    public float fireRate = .25f;

    private float nextFireTime;

    public XboxController controller;


    // Update is called once per frame
    void Update()
    {
        if (XCI.GetButton(XboxButton.A, controller) && Time.time > nextFireTime)
        {
            Rigidbody cloneRb1 = Instantiate(projectile, bulletSpawn1.position, bulletSpawn1.rotation) as Rigidbody;
            cloneRb1.AddForce(bulletSpawn1.transform.forward * projectileForce);

            Rigidbody cloneRb2 = Instantiate(projectile, bulletSpawn2.position, bulletSpawn1.rotation) as Rigidbody;
            cloneRb2.AddForce(bulletSpawn2.transform.forward * projectileForce);

            nextFireTime = Time.time + fireRate;
        }
    }
}