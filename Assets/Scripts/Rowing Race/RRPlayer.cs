using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class RRPlayer : MonoBehaviour
{
    //private bool leftRow;
    private Rigidbody rb;
    private readonly float speed = 100f;
    private readonly float rotation = 80f;
    public float cooldown;
    public ParticleSystem waterSpray;

    public Animator anim;

    public XboxController controller;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (XCI.GetAxis(XboxAxis.RightTrigger,controller) > 0.1f && cooldown > .5f)
        {
            rb.AddForce(transform.forward * speed * cooldown);
            rb.AddRelativeTorque(-Vector3.up * rotation * cooldown);
            cooldown = 0f;
            anim.Play("LeftRow");
        }

        else if (XCI.GetAxis(XboxAxis.LeftTrigger,controller) > 0.1f && cooldown > .5f)
        {
            rb.AddForce(transform.forward * speed * cooldown);
            rb.AddRelativeTorque(Vector3.up * rotation * cooldown);
            cooldown = 0f;
            anim.Play("RightRow");
        }

        if (cooldown < 1.5f)
        {
            cooldown += Time.deltaTime;
        }
        var main = waterSpray.main;
        var emission = waterSpray.emission;
        main.startSpeed = rb.velocity.magnitude / 3;
        emission.rateOverTime = rb.velocity.magnitude * 20;

        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }




}
