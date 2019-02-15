using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 

public class GameMusic : MonoBehaviour
{
    static bool AudioBegin = false;
    public AudioSource music;

    void Awake()
    {

        if (!AudioBegin)
        {
            //music.Play();
            IntroLoop clip = new IntroLoop(music, 20f, 2.5f, 88f);
            clip.start();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }
    //void Update()
    //{
    //    if (Application.loadedLevelName == "Upgraded")
    //    {
    //        audio.Stop();
    //        AudioBegin = false;
    //    }
    //}
}