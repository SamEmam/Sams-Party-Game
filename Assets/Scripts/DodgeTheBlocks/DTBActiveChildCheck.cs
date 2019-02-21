using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTBActiveChildCheck : MonoBehaviour
{
    public GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        if (!child.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
