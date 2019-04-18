using UnityEngine;
using XboxCtrlrInput;

public class WGun : MonoBehaviour
{
    [Header("Properties")]
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;
    public float spreadFactor = 0.1f;

    [Header("Setup")]
    public XboxController controller;
    public Transform firePoint;
    public GameObject muzzleFlash;
    public GameObject impactEffect1;
    public GameObject impactEffect2;



    private float nextTimeToFire = 0f;

    private void Awake()
    {
        muzzleFlash.SetActive(false);
    }

    private void Update()
    {
        if (XCI.GetButton(XboxButton.A,controller) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        if (XCI.GetButtonUp(XboxButton.A, controller))
        {
            muzzleFlash.SetActive(false);
        }
    }

    void Shoot()
    {
        muzzleFlash.SetActive(true);

        RaycastHit hit;
        
        Vector3 shootDirection = firePoint.forward;
        shootDirection.x += Random.Range(-spreadFactor, spreadFactor);
        shootDirection.y += Random.Range(-spreadFactor, spreadFactor);
        if (Physics.Raycast(firePoint.position, shootDirection, out hit, range))
        {
            //WTarget wTarget = hit.transform.GetComponent<WTarget>();
            //if (wTarget != null)
            //{
            //    wTarget.TakeDamage(damage);
            //}

            if (hit.rigidbody != null)
            {

                hit.rigidbody.AddForce(Vector3.up * (impactForce * 4));
                hit.rigidbody.AddForce(-hit.normal * (impactForce / 2));
            }

            GameObject impactGO1 = Instantiate(impactEffect1, hit.point, Quaternion.LookRotation(hit.normal));
            GameObject impactGO2 = Instantiate(impactEffect2, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO1, 2f);
            Destroy(impactGO2, 2f);
        }
    }
}
