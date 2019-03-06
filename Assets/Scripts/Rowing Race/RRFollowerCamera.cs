using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RRFollowerCamera : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;


    private void Start()
    {
        offset = transform.position - player.position;
    }

    // set x and z position equal to player + offset

    private void Update()
    {
        if (player)
        {
            transform.position = player.position + offset;
        }
        
    }
}
