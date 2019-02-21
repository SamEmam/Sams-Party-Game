using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckSpawner : MonoBehaviour
{

    public SpawnController SC;
    public float spawnSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        SC.spawnWait = spawnSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (SC.spawnWait >= 0.5f)
        {
            SC.spawnWait -= 0.001f;
        }
    }

    
}
