using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBSTarget : MonoBehaviour
{
    public int score = 0;
    public int enemyScore = 10000;
    public int targetBy = 0;
    public int temptTargetBy = 0;
    
    public SBSRotation SBSrotation;
    public SBSFaction SBSfaction;

    public string enemyTag;
    public GameObject[] enemies;

    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag(enemyTag);
    }

    private void Update()
    {
        foreach (GameObject enemy in enemies)
        {
            enemyScore = 10000;
            if (gameObject != enemy && SBSfaction.faction != enemy.GetComponent<SBSFaction>().faction)
            {
                if (enemy.GetComponent<SBSRotation>().target == SBSrotation.target)
                {
                    enemyScore -= 1000;
                    temptTargetBy++;
                }
                enemyScore -= enemy.GetComponent<SBSTarget>().targetBy * 200;

                var dist = Vector3.Distance(transform.position, enemy.transform.position);

                if (dist < 50)
                {
                    enemyScore -= (int)(dist * 10);
                }
                else if (dist < 100)
                {
                    enemyScore -= (int)(dist * 4);
                }
                else if (dist < 300)
                {
                    enemyScore -= (int)(dist / 2);
                }
                else if (dist < 500)
                {
                    enemyScore -= (int)(dist);
                }
                else
                {
                    enemyScore -= (int)(dist * 2);
                }

                if (enemyScore >= score)
                {
                    score = enemyScore;
                    SBSrotation.target = enemy.transform;
                }
            }
        }
        targetBy = temptTargetBy;
        score = 0;
    }
}
