using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSCubeSpawner : MonoBehaviour
{
    [SerializeField]
    private BSMovingCube cubePrefab;

    public BSMovingCube lastCube;

    public string startCube;
    public BSGameManager BSGM;

    [SerializeField]
    private BSMoveDirection moveDirection;


    public void SpawnCube()
    {
        var cube = Instantiate(cubePrefab);
        cube.lastCube = BSGM.lastCube;
        //BSGM.currentCube = cube.currentCube;
        //BSGM.lastCube = cube.gameObject;
        lastCube = BSGM.lastCube.GetComponent<BSMovingCube>();

        if (lastCube != null && lastCube.gameObject != GameObject.Find(startCube))
        {
            float x = moveDirection == BSMoveDirection.X ? transform.position.x : lastCube.transform.position.x;
            float z = moveDirection == BSMoveDirection.Z ? transform.position.z : lastCube.transform.position.z;

            cube.transform.position = new Vector3(x, lastCube.transform.position.y + cubePrefab.transform.localScale.y, z);
            BSGM.cameraHeight = cube.transform.position;
        }
        else
        {
            cube.transform.position = transform.position;
        }

        cube.MoveDirection = moveDirection;
        lastCube = cube;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, cubePrefab.transform.localScale);
    }
}
