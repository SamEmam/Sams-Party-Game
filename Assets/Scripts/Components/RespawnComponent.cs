using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnComponent : MonoBehaviour
{
    public string respawn = "Respawn_P1";
    private Rigidbody rb;
    public int checkpointCount;

    public Transform respawnPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown(respawn))
        {
            Respawn(respawnPoint);
        }
    }

    void Respawn(Transform resPoint)
    {
        gameObject.transform.position = resPoint.position;
        gameObject.transform.rotation = resPoint.rotation;
        rb.velocity = new Vector3(0, 0, 0);
        rb.angularVelocity = new Vector3(0, 0, 0);
    }
}
