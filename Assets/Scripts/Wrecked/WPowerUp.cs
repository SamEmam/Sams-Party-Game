using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPowerUp : MonoBehaviour
{
    public float seconds = 10f;
    public GameObject[] powerUps;

    private int rng;
    private bool canTriggerPowerUp = true;

    private void Start()
    {
        randomizePowerUp();
    }

    void randomizePowerUp()
    {
        rng = Random.Range(0, powerUps.Length);

        foreach (var powerUp in powerUps)
        {
            powerUp.SetActive(false);
        }

        powerUps[rng].SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && canTriggerPowerUp)
        {
            if (!other.GetComponent<WPowerUpPlayer>().HasPowerUp())
            {
                canTriggerPowerUp = false;
                other.GetComponent<WPowerUpPlayer>().EnablePowerUp(rng);
                StartCoroutine(DisablePowerUp());
            }
        }
    }

    IEnumerator DisablePowerUp()
    {
        powerUps[rng].SetActive(false);
        yield return new WaitForSeconds(seconds);
        randomizePowerUp();
        canTriggerPowerUp = true;
    }
}
