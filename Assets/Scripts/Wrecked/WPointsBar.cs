using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WPointsBar : MonoBehaviour
{

    public PlayerScore ps;
    public int playerNum;
    public WDestroyer destroyer;
    public Image imgPointsBar;
    public TextMeshProUGUI txtPoints;
    public int min, max;
    public GameObject canvas;
    private bool canUpdate = true;
    private bool overrideUpdate = true;

    private int currentValue;
    private float currenctPercent;

    private void Start()
    {
            ps = destroyer.GetPlayerScore(playerNum);
        if (!ps || !ps.transform.gameObject.activeInHierarchy)
        {
            canUpdate = false;
            canvas.SetActive(false);
        }
        else
        {
            max = destroyer.winScore;
            Debug.Log("PointsBar: " + gameObject.name);
        }
        
    }

    public void SetPoints(int points)
    {
        
        if (points != currentValue)
        {
            if (max - min == 0)
            {
                currentValue = 0;
                currenctPercent = 0;
            }
            else
            {
                currentValue = points;
                currenctPercent = (float)currentValue / (float)(max - min);
            }
            txtPoints.text = currentValue + " / " + max;

            imgPointsBar.fillAmount = currenctPercent;
        }
    }
     private void OverrideSetPoints(int points)
    {
        overrideUpdate = false;
        max = destroyer.winScore;
        currentValue = points;
        currenctPercent = (float)currentValue / (float)(max - min);
    
        txtPoints.text = currentValue + " / " + max;
        imgPointsBar.fillAmount = currenctPercent;

    }

    private void LateUpdate()
    {
        if (overrideUpdate)
        {
            OverrideSetPoints(ps.score);
        }
        if (!ps)
        {
            canUpdate = false;
            canvas.SetActive(false);
        }
        if (canUpdate)
        {
            SetPoints(ps.score);
        }
    }

    public float CurrentPercent
    {
        get { return currenctPercent; }
    }
    public int CurrentValue
    {
        get { return currentValue; }
    }
}
