using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ERDistanceDial : MonoBehaviour
{
    public Transform destroyerWall;
    public TextMeshProUGUI distanceDial;
    private int distance;

    private void Update()
    {
        distance = (int)Vector3.Distance(transform.position, destroyerWall.position) - 100;
        distanceDial.text = distance + " m";
    }
}
