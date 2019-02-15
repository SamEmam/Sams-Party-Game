using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
