using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class WShockWave : MonoBehaviour
{
    [Header("Attributes")]
    public float impactForce;
    public float radius = 50f;
    public float upwardsThrust = 5f;


    [Header("Setup")]
    public XboxController controller;
    public ParticleSystem explosion;
    public Rigidbody rb;
    public WPowerUpPlayer wPUP;
    public int powerUpNum = 3;

    private void Update()
    {
        if (XCI.GetButton(XboxButton.A, controller))
        {
            Shockwave();
            
        }
    }

    void Shockwave()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody hitRB = hit.GetComponent<Rigidbody>();
            if (hitRB != null && !hit.GetComponent<WNotAffected>() && hitRB != rb)
            {
                hitRB.AddExplosionForce(impactForce, transform.position, radius, upwardsThrust, ForceMode.Impulse);
            }
        }

        Instantiate(explosion, transform.position, transform.rotation);
        wPUP.DisablePowerUp(powerUpNum);
    }
    
}