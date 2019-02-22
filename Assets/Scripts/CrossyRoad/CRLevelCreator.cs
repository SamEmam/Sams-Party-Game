using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRLevelCreator : MonoBehaviour
{
    public GameObject[] lanes;

    private GameObject tempLane;

    private float zPosition = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        CreateLanes();
    }

    public void CreateLanes()
    {
        float i;
        for (i = zPosition; i < zPosition + 40; i++)
        {
            tempLane = Instantiate(lanes[Random.Range(0, lanes.Length)], new Vector3(0, 0, i), Quaternion.identity) as GameObject;
            tempLane.transform.SetParent(gameObject.transform);
            i += tempLane.GetComponent<CRLanes>().numberOfLanes - 1;
        }

        zPosition = i;
    }
}
