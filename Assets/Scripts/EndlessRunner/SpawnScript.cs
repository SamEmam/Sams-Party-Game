using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    public GameObject[] obj;
    public Transform vehicle1;
    public Transform vehicle2;
    public Transform vehicle3;
    public Transform vehicle4;
    //public float distance;
    public float distanceToSpawn = 10f;
    public int blockSize = 6;
    private bool spawnBlock = false;



    private void FixedUpdate()
    {
        if (vehicle1 && Vector3.Distance(vehicle1.position, transform.position) <= distanceToSpawn)
        {
            spawnBlock = true;
        }

        if (vehicle2 && Vector3.Distance(vehicle2.position, transform.position) <= distanceToSpawn)
        {
            spawnBlock = true;
        }

        if (vehicle3 && Vector3.Distance(vehicle3.position, transform.position) <= distanceToSpawn)
        {
            spawnBlock = true;
        }

        if (vehicle4 && Vector3.Distance(vehicle4.position, transform.position) <= distanceToSpawn)
        {
            spawnBlock = true;
        }


        if (spawnBlock)
        {
            spawnBlock = false;
            Instantiate(obj[Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity);
            transform.position = new Vector3(0, 0, transform.position.z + blockSize);
        }
        
    }


}
