using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    public int checkpointNum;

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

            

            
            if (rc.checkpointNum == checkpointNum - 1)
            {
                rc.checkpointCount++;
                rc.checkpointNum = checkpointNum;
                rc.respawnPoint = transform;
            }
            else if (rc.checkpointNum == checkpointNum)
            {
                rc.checkpointNum = checkpointNum;
                rc.respawnPoint = transform;
            }
        }
    }
}
