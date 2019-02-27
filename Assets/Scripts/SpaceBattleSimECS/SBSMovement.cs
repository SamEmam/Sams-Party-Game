using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBSMovement : MonoBehaviour
{
    public float movementSpeed;

    private void FixedUpdate()
    {
        transform.position += transform.forward * movementSpeed * Time.fixedDeltaTime;
    }
}
