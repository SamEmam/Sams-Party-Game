using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPowerUpPlayer : MonoBehaviour
{
    public GameObject[] PowerUps;
    public float[] seconds;

    private bool powerUpTriggered = false;

    public bool HasPowerUp()
    {
        return powerUpTriggered;
    }

    public void EnablePowerUp(int powerUpNum)
    {
        PowerUps[powerUpNum].SetActive(true);
        StartCoroutine(DisablePowerUp(powerUpNum));
    }

    IEnumerator DisablePowerUp(int powerUpNum)
    {
        powerUpTriggered = true;
        yield return new WaitForSeconds(seconds[powerUpNum]);
        PowerUps[powerUpNum].SetActive(false);
        powerUpTriggered = false;
    }
}
