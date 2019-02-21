using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRCamera : MonoBehaviour
{
    public Transform player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x + offset.x, offset.y, player.position.z + offset.z);
    }
}
