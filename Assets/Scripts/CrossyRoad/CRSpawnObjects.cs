using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRSpawnObjects : MonoBehaviour
{
    public GameObject[] objects;

    public float minSpawnTime, maxSpawnTime;

    public bool spawnMovingObjects = false;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnMovingObjects)
        {
            SpawnMovingObjects();
        }
        else
        {
            SpawnStaticObjects();
        }
    }

    void SpawnMovingObjects()
    {
        Instantiate(objects[Random.Range(0, objects.Length)], transform);

        Invoke("SpawnMovingObjects", Random.Range(minSpawnTime,maxSpawnTime));
    }

    void SpawnStaticObjects()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(objects[Random.Range(0, objects.Length)], new Vector3(Random.Range(-15, 15), 0, transform.position.z), Quaternion.identity);
        }
    }
}
