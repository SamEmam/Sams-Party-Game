using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class WMineLauncher : MonoBehaviour
{
    [Header("Properties")]
    public float fireRate = 5f;
    public float fireForce = 10f;
    public float spreadFactor = 0.05f;
    public int bulletCount = 3;

    [Header("Setup")]
    public XboxController controller;
    public Transform firePoint;
    public GameObject landmine;
    public WPowerUpPlayer wPUP;
    public int powerUpNum = 4;

    private float nextTimeToFire = 0f;

    private void OnEnable()
    {
        bulletCount = 3;
    }

    private void Update()
    {
        if (bulletCount <= 0)
        {
            wPUP.DisablePowerUp(powerUpNum);
        }
        

        if (XCI.GetButtonDown(XboxButton.A, controller) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        bulletCount--;
        var shootDirection = firePoint.rotation;
        shootDirection.x += Random.Range(-spreadFactor, spreadFactor);
        shootDirection.y += Random.Range(-spreadFactor, spreadFactor);

        GameObject landmineGO = Instantiate(landmine, firePoint.position, Quaternion.identity);
        landmineGO.GetComponent<Rigidbody>().velocity = firePoint.transform.forward * fireForce;
    }
}
