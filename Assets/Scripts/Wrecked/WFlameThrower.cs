using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class WFlameThrower : MonoBehaviour
{
    [Header("Properties")]
    public float speed = 2f;
    
    [Header("Setup")]
    public XboxController controller;
    public ParticleSystem flame;
    public ParticleSystem flame2;
    public Rigidbody rb;

    private void OnEnable()
    {
        flame.Stop();
        if (flame2)
        {
            flame2.Stop();
        }
    }

    private void Update()
    {
        if (XCI.GetButton(XboxButton.A, controller))
        {
            Shoot();
        }
        if (XCI.GetButtonUp(XboxButton.A, controller))
        {
            flame.Stop();
            if (flame2)
            {
                flame2.Stop();
            }
        }
    }


    void Shoot()
    {
        flame.Play();
        if (flame2)
        {
            flame2.Play();
        }
        rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
    }
}
