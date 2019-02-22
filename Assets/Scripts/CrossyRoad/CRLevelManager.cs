using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRLevelManager : MonoBehaviour
{
    

    private int steps;
    public int stepsToCreateMoreLanes = 24;
    private int currentSteps;
    

    public void SetSteps()
    {
        steps++;
        currentSteps++;

        if (currentSteps > stepsToCreateMoreLanes)
        {
            currentSteps = 0;
            GetComponent<CRLevelCreator>().CreateLanes();
        }
    }
    
}
