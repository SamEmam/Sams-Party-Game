using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSBManager : MonoBehaviour
{
    public GameObject p1car, p1zone, p1points, p2car, p2zone, p2points, p3car, p3zone, p3points, p4car, p4zone, p4points;

    private void Awake()
    {
        if (!GameStats.Player1)
        {
            p1car.SetActive(false);
            p1zone.SetActive(false);
            p1points.SetActive(false);
        }
        if (!GameStats.Player2)
        {
            p2car.SetActive(false);
            p2zone.SetActive(false);
            p2points.SetActive(false);
        }
        if (!GameStats.Player3)
        {
            p3car.SetActive(false);
            p3zone.SetActive(false);
            p3points.SetActive(false);
        }
        if (!GameStats.Player4)
        {
            p4car.SetActive(false);
            p4zone.SetActive(false);
            p4points.SetActive(false);
        }
        if (!GameStats.Player3 && !GameStats.Player4)
        {
            p1zone.transform.localScale = new Vector3(110, p1zone.transform.localScale.y, p1zone.transform.localScale.z);
            p2zone.transform.localScale = new Vector3(110, p2zone.transform.localScale.y, p2zone.transform.localScale.z);
        }
    }
}
