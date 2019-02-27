using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBSRotation : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed;


    private void FixedUpdate()
    {
        var pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.fixedDeltaTime);
    }
}
