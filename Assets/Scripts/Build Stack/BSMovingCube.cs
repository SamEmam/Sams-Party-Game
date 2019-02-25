using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BSMovingCube : MonoBehaviour
{
    public string player;
    public GameObject playerObject;
    public BSPlayerManager BSPM;

    public GameObject currentCube;
    public GameObject lastCube;
    public string gameManager;
    private BSGameManager BSGM;
    public BSMoveDirection MoveDirection { get; set; }

    [SerializeField]
    private float moveSpeed = 1f;

    private void OnEnable()
    {
        playerObject = GameObject.Find(player);
        BSPM = GameObject.Find("PlayerManager").GetComponent<BSPlayerManager>();
        BSGM = GameObject.Find(gameManager).GetComponent<BSGameManager>();
        BSGM.currentCube = this.gameObject;
        //currentCube = this.gameObject;
        lastCube = BSGM.lastCube;
        
        GetComponent<Renderer>().material.color = GetRandomColor();

        transform.localScale = new Vector3(lastCube.transform.localScale.x, transform.localScale.y, lastCube.transform.localScale.z);
        
    }

    private Color GetRandomColor()
    {
        return new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
    }

    public void Stop()
    {
        
        moveSpeed = 0;
        float hangover = GetHangover();
        float max = MoveDirection == BSMoveDirection.Z ? lastCube.transform.localScale.z : lastCube.transform.localScale.x;
        if (Mathf.Abs(hangover) >= max)
        {
            lastCube = null;
            currentCube = null;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            //PlayerScore ps = playerObject.GetComponent<PlayerScore>();
            //ps.score -= BSPM.playersLeft - 1;
            //ps.UpdateScore();
            BSPM.playersLeft--;

            // if lost
            BSPM.myDictionary.Add(player, BSGM.cubeScore);

        }

        float direction = hangover > 0 ? 1f : -1f;

        if (MoveDirection == BSMoveDirection.Z)
        {
            SplitCubeOnZ(hangover, direction);
        }
        else
        {
            SplitCubeOnX(hangover, direction);
        }

        //lastCube = this.gameObject;
        BSGM.lastCube = this.gameObject;
    }

    private float GetHangover()
    {
        if (MoveDirection == BSMoveDirection.Z)
        {
            return transform.position.z - lastCube.transform.position.z;
        }
        else
        {
            return transform.position.x - lastCube.transform.position.x;
        }
    }

    void SplitCubeOnX(float hangover, float direction)
    {
        float newXSize = lastCube.transform.localScale.x - Mathf.Abs(hangover);
        float fallingBlockSize = transform.localScale.x - newXSize;

        float newXPosition = lastCube.transform.position.x + (hangover / 2);
        transform.localScale = new Vector3(newXSize, transform.localScale.y, transform.localScale.z);
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);

        float cubeEdge = transform.position.x + (newXSize / 2 * direction);
        float fallingBlockXPosition = cubeEdge + fallingBlockSize / 2 * direction;

        SpawnDropCube(fallingBlockXPosition, fallingBlockSize);

    }

    void SplitCubeOnZ(float hangover, float direction)
    {
        float newZSize = lastCube.transform.localScale.z - Mathf.Abs(hangover);
        float fallingBlockSize = transform.localScale.z - newZSize;

        float newZPosition = lastCube.transform.position.z + (hangover / 2);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newZSize);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition);

        float cubeEdge = transform.position.z + (newZSize / 2 * direction);
        float fallingBlockZPosition = cubeEdge + fallingBlockSize / 2 * direction;
        
        SpawnDropCube(fallingBlockZPosition, fallingBlockSize);

    }

    private void SpawnDropCube(float fallingBlockZPosition, float fallingBlockSize)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        if (MoveDirection == BSMoveDirection.Z)
        {
            cube.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, fallingBlockSize);
            cube.transform.position = new Vector3(transform.position.x, transform.position.y, fallingBlockZPosition);
        }
        else
        {
            cube.transform.localScale = new Vector3(fallingBlockSize, transform.localScale.y, transform.localScale.z);
            cube.transform.position = new Vector3(fallingBlockZPosition, transform.position.y, transform.position.z);
        }
        

        cube.AddComponent<Rigidbody>();
        cube.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;

        Destroy(cube.gameObject, 2f);
    }

    void Update()
    {
        if (MoveDirection == BSMoveDirection.Z)
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
        else
        {
            transform.position += transform.right * Time.deltaTime * moveSpeed;
        }
    }
}
