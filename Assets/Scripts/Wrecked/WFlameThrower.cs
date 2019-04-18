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
    public Rigidbody rb;

    private void OnEnable()
    {
        flame.Stop();
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
        }
    }


    void Shoot()
    {
        flame.Play();
        rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
    }
}
