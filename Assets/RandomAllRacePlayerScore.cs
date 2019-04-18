using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAllRacePlayerScore : MonoBehaviour
{
    public PlayerScore vehicle, parent;


    public void UpdatePlayerScore()
    {
        parent.score = vehicle.score;
    }
}
