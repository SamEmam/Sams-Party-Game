using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour, IDamageable
{

    public int startingHealth = 3;
    public GameObject hitParticles;
    public ParticleSystem deathEffect;

    public BattleManager bm;

    public int currentHealth;

    void Start()
    {
        currentHealth = startingHealth;
    }

    public void Damage(int damage, Vector3 hitPoint)
    {
        Instantiate(hitParticles, hitPoint, Quaternion.LookRotation(Vector3.back));
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Defeated();
        }
    }

    void Defeated()
    {
        PlayerScore ps = GetComponent<PlayerScore>();
        ps.score -= bm.playersLeft - 1;
        //ps.UpdateScore();
        bm.playersLeft--;
        Destroy(this.gameObject);
        Instantiate(ps.finishParticles, transform.position, Quaternion.LookRotation(Vector3.up));
        
    }

}