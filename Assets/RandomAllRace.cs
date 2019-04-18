﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAllRace : MonoBehaviour
{
    public VehicleRandomizer vRNG;
    public PlayerScore ps;
    private int lapCounter;
    //private int score;
    public bool updatedCar = true;

    private void Start()
    {
        lapCounter = vRNG.GetPlayerScore().laps;
        //score = vRNG.GetPlayerScore().score;
        updatedCar = true;
    }

    private void FixedUpdate()
    {
        if (vRNG.GetPlayerScore().laps != lapCounter)
        {
            lapCounter = vRNG.GetPlayerScore().laps;
            ps.laps = lapCounter;
            vRNG.RandomizeVehicle();
            vRNG.SetPosOnCarSwitch();
            updatedCar = true;
        }
    }
}
