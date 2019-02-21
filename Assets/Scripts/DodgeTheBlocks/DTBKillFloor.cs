using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTBKillFloor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.transform.parent.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
