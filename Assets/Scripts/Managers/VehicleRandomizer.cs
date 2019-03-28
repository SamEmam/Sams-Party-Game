using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleRandomizer : MonoBehaviour
{

    public GameObject[] vehicles;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var car in vehicles)
        {
            car.SetActive(false);
        }
        int rng = Random.Range(1, vehicles.Length);
        vehicles[rng].SetActive(true);
    }
    
}
