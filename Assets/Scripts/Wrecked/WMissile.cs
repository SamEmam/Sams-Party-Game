using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class WMissile : MonoBehaviour
{
    [Header("Properties")]
    public float damage = 10f;
    public float fireRate = 1f;
    public float impactForce = 10000f;
    public float fireForce = 500f;
    public float spreadFactor = 0.05f;

    [Header("Setup")]
    public XboxController controller;
    public Transform firePoint;
    public GameObject missile;
    public GameObject missileProjectile;


    private float nextTimeToFire = 0f;

    private void Update()
    {
        if (Time.time >= nextTimeToFire)
        {
            missile.SetActive(true);
        }

        if (XCI.GetButtonDown(XboxButton.A, controller) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            missile.SetActive(false);
            Shoot();
        }
    }

    void Shoot()
    {
        var shootDirection = firePoint.rotation;
        shootDirection.x += Random.Range(-spreadFactor, spreadFactor);
        shootDirection.y += Random.Range(-spreadFactor, spreadFactor);

        GameObject rocketGO = Instantiate(missileProjectile, firePoint.position, shootDirection);
        WRocket wRocket = rocketGO.GetComponent<WRocket>();
        wRocket.impactForce = impactForce;
        wRocket.rb.velocity = rocketGO.transform.forward * fireForce;
    }
}
