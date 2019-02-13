using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            RespawnComponent rc = other.GetComponent<RespawnComponent>();
            

            if (!rc)
            {
                return;
            }

            rc.respawnPoint = transform;
            rc.checkpointCount++;
        }
    }
}
