using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSCameraManager : MonoBehaviour
{
    
    public Camera p1Cam;
    public Camera p2Cam;
    public Camera p3Cam;
    public Camera p4Cam;

    private void Awake()
    {

        p1Cam.gameObject.SetActive(false);
        p2Cam.gameObject.SetActive(false);
        p3Cam.gameObject.SetActive(false);
        p4Cam.gameObject.SetActive(false);

        if (GameStats.Player1)
        {
            p1Cam.gameObject.SetActive(true);
            p1Cam.rect = new Rect(0, 0, 1, 1);
        }
        if (GameStats.Player2)
        {
            p2Cam.gameObject.SetActive(true);
            p1Cam.rect = new Rect(0   , 0, 0.5f, 1);
            p2Cam.rect = new Rect(0.5f, 0, 0.5f, 1);
        }
        if (GameStats.Player3)
        {
            p3Cam.gameObject.SetActive(true);
            p1Cam.rect = new Rect(0   , 0.5f, 0.5f, 0.5f);
            p2Cam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            p3Cam.rect = new Rect(0   , 0   , 1   , 0.5f);

            p1Cam.orthographicSize = 1.5f;
            p2Cam.orthographicSize = 1.5f;
            p3Cam.orthographicSize = 1.5f;
        }
        if (GameStats.Player4)
        {
            p4Cam.gameObject.SetActive(true);

            p1Cam.rect = new Rect(0   , 0.5f, 0.5f, 0.5f);
            p2Cam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            p3Cam.rect = new Rect(0   , 0   , 0.5f, 0.5f);
            p4Cam.rect = new Rect(0.5f, 0   , 0.5f, 0.5f);

            p1Cam.orthographicSize = 1.5f;
            p2Cam.orthographicSize = 1.5f;
            p3Cam.orthographicSize = 1.5f;
            p4Cam.orthographicSize = 1.5f;
        }
    }

}
