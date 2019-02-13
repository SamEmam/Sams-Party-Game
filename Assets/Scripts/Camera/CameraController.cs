using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CameraMultiTarget cameraMultiTarget;
    public List<GameObject> targets;

    private void FixedUpdate()
    {
        targets = new List<GameObject>();
        targets.AddRange(GameObject.FindGameObjectsWithTag("Player"));

        if (targets.Count == 0)
        {
            return;
        }
        cameraMultiTarget.SetTargets(targets.ToArray());
    }

}