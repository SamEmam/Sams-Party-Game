using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Soccer : MonoBehaviour
{
    public int rewardScore = 0;
    public int bestOutOf = 2;
    public int playersLeft = 0;

    

    public GameObject t1p1;
    public Vector3 t1p1Pos;

    public GameObject t1p2;
    public Vector3 t1p2Pos;

    public GameObject t2p1;
    public Vector3 t2p1Pos;

    public GameObject t2p2;
    public Vector3 t2p2Pos;

    public int team = 1;

    public ParticleSystem finishParticles;

    public SceneFader sceneFader;

    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        t1p1Pos = t1p1.transform.position;
        t1p2Pos = t1p1.transform.position;
        t2p1Pos = t1p1.transform.position;
        t2p2Pos = t1p1.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            if (team == 1)
            {
                PlayerScore ps1 = t1p1.GetComponent<PlayerScore>();
                PlayerScore ps2 = t1p2.GetComponent<PlayerScore>();

                if (!ps1 && !ps2)
                {
                    return;
                }

                Instantiate(finishParticles, other.gameObject.transform.position, other.gameObject.transform.rotation);
                other.GetComponent<SoccerBall>().ResetBall();
                //t1p1.transform.position = t1p1Pos;
                //t1p1.transform.position = t1p2Pos;
                //t1p1.transform.position = t2p1Pos;
                //t1p1.transform.position = t2p2Pos;

                if (GameStats.Player1)
                {
                    ps1.score++;
                    ps1.UpdateScore();
                }
                if (GameStats.Player2)
                {
                    ps2.score++;
                    ps2.UpdateScore();
                }
                
                bestOutOf--;
                if (bestOutOf <= 0)
                {
                    sceneFader.FadeTo("ScoreScene");
                }
            }

            if (team == 2)
            {
                PlayerScore ps3 = t2p1.GetComponent<PlayerScore>();
                PlayerScore ps4 = t2p2.GetComponent<PlayerScore>();

                if (!ps3 && !ps4)
                {
                    return;
                }

                Instantiate(finishParticles, other.gameObject.transform.position, other.gameObject.transform.rotation);
                other.GetComponent<SoccerBall>().ResetBall();
                //t1p1.transform.position = t1p1Pos;
                //t1p1.transform.position = t1p2Pos;
                //t1p1.transform.position = t2p1Pos;
                //t1p1.transform.position = t2p2Pos;

                if (GameStats.Player3)
                {
                    ps3.score++;
                    ps3.UpdateScore();
                }
                if (GameStats.Player4)
                {
                    ps4.score++;
                    ps4.UpdateScore();
                }
                bestOutOf--;
                if (bestOutOf <= 0)
                {
                    sceneFader.FadeTo("ScoreScene");
                }
            }
        }
    }
}