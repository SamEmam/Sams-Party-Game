using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using XboxCtrlrInput;

public class BSGameManager : MonoBehaviour
{
    public event Action OnCubeSpawned = delegate { };
    
    public XboxController controller;
    public BSCubeSpawner[] spawners;
    private int spawnerIndex;
    private BSCubeSpawner currentSpawner;

    public Camera cam;
    public Vector3 cameraHeight;
    public Vector3 camStartPos;

    public GameObject lastCube;
    public GameObject currentCube;

    public int cubeScore;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        camStartPos = cam.transform.position;
    }

    void Update()
    {
        if (XCI.GetButtonDown(XboxButton.A,controller))
        {
            if (currentCube != null)
            {
                currentCube.GetComponent<BSMovingCube>().Stop();
            }

            scoreText.text = "Score: " + cubeScore;
            cubeScore++;

            
            spawnerIndex = spawnerIndex == 0 ? 1 : 0;
            currentSpawner = spawners[spawnerIndex];

            currentSpawner.SpawnCube();
            OnCubeSpawned();
            
        }
        Vector3 camTargetPos = new Vector3(cam.transform.position.x, camStartPos.y + cameraHeight.y, cam.transform.position.z);
        cam.transform.position = Vector3.Lerp(cam.transform.position, camTargetPos, Time.deltaTime);
    }
}
