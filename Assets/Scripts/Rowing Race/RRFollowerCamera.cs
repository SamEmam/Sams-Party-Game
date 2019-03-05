using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RRFollowerCamera : MonoBehaviour
{
    public Transform player;
    Vector3 offset = new Vector3(-7.1f, 9.46f, 0);


    // set x and z position equal to player + offset

    private void Update()
    {
        transform.position = player.position + offset;
    }
}
