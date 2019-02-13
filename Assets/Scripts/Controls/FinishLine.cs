using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public int rewardScore = 3;
    public int playersLeft = 0;
    public int raceLaps;
    public int raceCheckpoints;
    public ParticleSystem finishParticles;

    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerScore ps = other.GetComponent<PlayerScore>();
            RespawnComponent rc = other.GetComponent<RespawnComponent>();

            if (!ps)
            {
                return;
            }

            if (rc.checkpointCount >= raceCheckpoints)
            {

                if (ps.laps < raceLaps - 1)
                {
                    ps.laps++;
                    rc.checkpointCount = 0;
                    return;
                }

                ps.score += rewardScore;
                ps.UpdateScore();
                rewardScore--;

                Instantiate(finishParticles, other.gameObject.transform.position, other.gameObject.transform.rotation);
                Destroy(other.gameObject, 1f);

                playersLeft--;
            }
        }
    }
}