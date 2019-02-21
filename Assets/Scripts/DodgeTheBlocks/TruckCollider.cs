using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckCollider : MonoBehaviour
{
    //public ParticleSystem deathEffect;

    public BattleManager bm;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerScore ps = other.gameObject.GetComponent<PlayerScore>();
            DTBPlayer DTBp = other.gameObject.GetComponent<DTBPlayer>();
            if (DTBp.isRewarded)
            {
                return;
            }
            DTBp.isRewarded = true;
            ps.score -= bm.playersLeft - 1;
            ps.UpdateScore();
            bm.playersLeft--;
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
            rb.useGravity = true;
            //Destroy(this.gameObject,5f);
            //Instantiate(deathEffect, transform.position, Quaternion.LookRotation(Vector3.up));
        }
    }
}
