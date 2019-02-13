using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
     public GameObject spawnPoint;



    public GameObject asteroidPrefab;
    public Vector3 spawnValues;
    public Vector3 offset;

    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(
                    Random.Range(spawnValues.x - offset.x, spawnValues.x + offset.x), 
                    Random.Range(spawnValues.y - offset.y, spawnValues.y + offset.y), 
                    Random.Range(spawnValues.z - offset.z, spawnValues.z + offset.z));

                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(asteroidPrefab, spawnPosition, spawnPoint.transform.rotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}

