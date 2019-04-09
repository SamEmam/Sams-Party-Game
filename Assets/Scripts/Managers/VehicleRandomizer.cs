using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleRandomizer : MonoBehaviour
{

    public GameObject[] vehicles;
    private int prevActiveVehicle;
    private int curActiveVehicle;
    private bool hasRunOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        RandomizeVehicle();
    }

    public void RandomizeVehicle()
    {
        int rng = Random.Range(0, vehicles.Length);

        if (hasRunOnce)
        {
            prevActiveVehicle = curActiveVehicle;
            while (rng == prevActiveVehicle)
            {
                rng = Random.Range(0, vehicles.Length);
            }
        }

        foreach (var car in vehicles)
        {
            car.SetActive(false);
        }
        
        vehicles[rng].SetActive(true);
        curActiveVehicle = rng;
        hasRunOnce = true;
    }

    public void SetPosOnCarSwitch()
    {
        vehicles[curActiveVehicle].transform.position = vehicles[prevActiveVehicle].transform.position;
        vehicles[curActiveVehicle].transform.rotation = vehicles[prevActiveVehicle].transform.rotation;
        Rigidbody rb = vehicles[curActiveVehicle].GetComponent<Rigidbody>();
        rb.velocity = vehicles[prevActiveVehicle].GetComponent<Rigidbody>().velocity;
        PlayerScore ps = vehicles[curActiveVehicle].GetComponent<PlayerScore>();
        ps.laps = vehicles[prevActiveVehicle].GetComponent<PlayerScore>().laps;
    }

    public PlayerScore GetPlayerScore()
    {
        return vehicles[curActiveVehicle].GetComponent<PlayerScore>();
    }

    public Rigidbody GetRigidbody()
    {
        Debug.Log("Getting Rigidbody for: " + vehicles[curActiveVehicle].gameObject.name);
        return vehicles[curActiveVehicle].GetComponent<Rigidbody>();
    }

    public GameObject GetGameObject()
    {
        return vehicles[curActiveVehicle].gameObject;
    }

}
