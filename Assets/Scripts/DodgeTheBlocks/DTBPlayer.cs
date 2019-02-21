using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class DTBPlayer : MonoBehaviour
{
    public XboxController controller;

    public float speed = 15f;
    public float mapWidth = 20f;
    public bool isRewarded = false;

    private Rigidbody rb;

    public BattleManager bm;
    public PlayerScore ps;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float x = XCI.GetAxis(XboxAxis.LeftStickX, controller) * Time.fixedDeltaTime * speed;

        Vector3 newPosition = rb.position + Vector3.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);
        
        rb.MovePosition(newPosition);

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Truck")
        {
            if (isRewarded)
            {
                return;
            }
            isRewarded = true;
            ps.score -= bm.playersLeft - 1;
            ps.UpdateScore();
            bm.playersLeft--;
            rb.constraints = RigidbodyConstraints.None;
            rb.useGravity = true;
            //Destroy(this.gameObject,5f);
            //Instantiate(deathEffect, transform.position, Quaternion.LookRotation(Vector3.up));
        }
    }
}
