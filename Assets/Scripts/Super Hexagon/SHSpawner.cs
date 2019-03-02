using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHSpawner : MonoBehaviour
{
    public float spawnRate = 0.05f;

    public GameObject hexagonPrefab;

    public SHColorLoop SHcolor;

    private float nextTimeToSpawn = 6f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTimeToSpawn)
        {
            GameObject hexagon = Instantiate(hexagonPrefab, Vector3.zero, Quaternion.identity);
            Color color = new Color(SHcolor.r/255, SHcolor.g/255, SHcolor.b/255);
            hexagon.GetComponent<LineRenderer>().startColor = color;
            hexagon.GetComponent<LineRenderer>().endColor = color;
            nextTimeToSpawn = Time.time + 1f / spawnRate;
        }
        spawnRate += Time.deltaTime * 0.01f;
    }

    private Color GetRandomColor()
    {
        return new Color(UnityEngine.Random.Range(0.1f, 1f), UnityEngine.Random.Range(0.1f, 1f), UnityEngine.Random.Range(0.1f, 1f));
    }
}
