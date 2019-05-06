using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class WRocketVolley : MonoBehaviour
{
    [Header("Properties")]
    public float fireForce = 10f;
    public float fireDelay = .1f;
    public float spreadFactor = 0.5f;
    private bool canShoot = true;
    private int bulletCount;

    [Header("Setup")]
    public XboxController controller;
    public Transform[] firepoints;
    public GameObject rocket;
    public WPowerUpPlayer wPUP;
    public int powerUpNum = 5;
    

    private void OnEnable()
    {
        canShoot = true;
        bulletCount = firepoints.Length;
    }

    private void Start()
    {
        wPUP = GetComponentInParent<WPowerUpPlayer>();
    }

    private void Update()
    {
        if (bulletCount <= 0)
        {
            wPUP.DisablePowerUp(powerUpNum);
        }


        if (XCI.GetButtonDown(XboxButton.A, controller) && canShoot)
        {
            canShoot = false;
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        Quaternion shootDirection;
        WaitForSeconds wait = new WaitForSeconds(fireDelay);
        foreach (var firePoint in firepoints)
        {
            shootDirection = firePoint.rotation;
            shootDirection.x += Random.Range(-spreadFactor, spreadFactor);
            shootDirection.y += Random.Range(-spreadFactor, spreadFactor);
            GameObject rocketGO = Instantiate(rocket, firePoint.position, shootDirection);
            rocketGO.GetComponent<Rigidbody>().velocity = rocketGO.transform.forward * fireForce;
            rocketGO.GetComponent<WVolleyMissile>().parentGO = transform.parent.gameObject;
            bulletCount--;
            yield return wait;
        }
    }
}
