using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSMovingCube : MonoBehaviour
{
    public static BSMovingCube CurrentCube { get; private set; }
    public static BSMovingCube LastCube { get; private set; }

    [SerializeField]
    private float moveSpeed = 1f;

    private void OnEnable()
    {
        if (LastCube == null)
        {
            LastCube = GameObject.Find("Start").GetComponent<BSMovingCube>();
        }
        CurrentCube = this;
    }

    internal void Stop()
    {
        moveSpeed = 0;
        float hangover = transform.position.z - LastCube.transform.position.z;

        SplitCubeOnZ(hangover);
    }

    void SplitCubeOnZ(float hangover)
    {
        float newZSize = LastCube.transform.localScale.z - Mathf.Abs(hangover);
        float fallingBlockSize = transform.localScale.z - newZSize;
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }
}
