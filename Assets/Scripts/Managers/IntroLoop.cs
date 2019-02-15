using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////Example of use
////Construct
//IntroLoop clip = new IntroLoop(audioSource, 5f, 10f, 20f);

////no intro just loop
//IntroLoop clip2 = new IntroLoop(audioSource, 10f, 20f, false);

////you can set it to play once
//clip2.playOnce = true;    

////call to start
//clip.start();

////call once a frame, this resets the loop if the time hits the loop boundary
////or stops playing if playOnce = true
//clip.checkTime(); 

////call to stop
//clip.stop();


/* **************************************************** */
//The Music IntroLoop Class handles looping music, and playing an intro to the loop
public class IntroLoop
{
    private AudioSource source;
    private float startBoundary;
    private float introBoundary;
    private float loopBoundary;
    //set to play a clip once
    public bool playOnce = false;

    //play from start for intro
    public IntroLoop(AudioSource source, float introBoundary, float loopBoundary)
    {
        this.source = source;
        this.startBoundary = 0;
        this.introBoundary = introBoundary;
        this.loopBoundary = loopBoundary;
    }
    //play from start for intro or just loop
    public IntroLoop(AudioSource source, float introBoundary, float loopBoundary, bool playIntro)
    {
        this.source = source;
        this.startBoundary = playIntro ? 0 : introBoundary;
        this.introBoundary = introBoundary;
        this.loopBoundary = loopBoundary;
    }
    //play from startBoundary for intro, then loop
    public IntroLoop(AudioSource source, float startBoundary, float introBoundary, float loopBoundary)
    {
        this.source = source;
        this.startBoundary = startBoundary;
        this.introBoundary = introBoundary;
        this.loopBoundary = loopBoundary;
    }
    //call to start
    public void start() { this.source.time = this.startBoundary; this.source.Play(); }
    //call every frame
    public void checkTime()
    {
        Debug.Log(this.source.time);
        if (this.source.time >= this.loopBoundary)
        {
            if (!this.playOnce) { this.source.time = introBoundary; }
        }
    }
    //call to stop
    public void stop() { this.source.Stop(); }
}
//The Music IntroLoop Class
/* **************************************************** */
