using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    public GameObject[] obj;
    public Transform vehicle1;
    public Transform vehicle2;
    public Transform vehicle3;
    public Transform vehicle4;
    public float distance;



    private void FixedUpdate()
    {
        if (Vector3.Distance(vehicle1.position, transform.position) <= 10f || Vector3.Distance(vehicle2.position, transform.position) <= 10f || Vector3.Distance(vehicle3.position, transform.position) <= 10f || Vector3.Distance(vehicle4.position, transform.position) <= 10f)
        {
            Instantiate(obj[Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity);
            transform.position = new Vector3(transform.position.x - 6, -0.7820005f, 1);

        }
    }


}
