using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class WPowerUpPlayer : MonoBehaviour
{
    public GameObject[] PowerUps;
    public float[] seconds;
    public bool[] useSeconds;
    public XboxController controller;

    private bool powerUpTriggered = false;

    private void Update()
    {
        if (XCI.GetButtonDown(XboxButton.Y, controller))
        {
            DisableAll();
        }
    }

    public bool HasPowerUp()
    {
        return powerUpTriggered;
    }

    public void EnablePowerUp(int powerUpNum)
    {
        PowerUps[powerUpNum].SetActive(true);
        powerUpTriggered = true;
        if (useSeconds[powerUpNum])
        {
            StartCoroutine(DisablePowerUpOnSeconds(powerUpNum));
        }
    }

    IEnumerator DisablePowerUpOnSeconds(int powerUpNum)
    {
        yield return new WaitForSeconds(seconds[powerUpNum]);
        PowerUps[powerUpNum].SetActive(false);
        powerUpTriggered = false;
    }

    public void DisablePowerUp(int powerUpNum)
    {
        PowerUps[powerUpNum].SetActive(false);
        powerUpTriggered = false;
    }

    public void DisableAll()
    {
        for (int i = 0; i < PowerUps.Length; i++)
        {
            DisablePowerUp(i);
        }
    }
}
