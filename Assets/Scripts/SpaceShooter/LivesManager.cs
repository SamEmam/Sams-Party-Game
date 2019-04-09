using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    public TextMeshProUGUI P1Lives, P2Lives, P3Lives, P4Lives;
    public EnemyHealth P1HP, P2HP, P3HP, P4HP;

    private void Awake()
    {
        P1Lives.color = new Color32(255, 0, 0, 150);
        P2Lives.color = new Color32(0, 0, 255, 150);
        P3Lives.color = new Color32(0, 255, 0, 150);
        P4Lives.color = new Color32(255, 255, 0, 150);

        if (!GameStats.Player1)
        {
            P1Lives.enabled = false;
        }
        if (!GameStats.Player2)
        {
            P2Lives.enabled = false;
        }
        if (!GameStats.Player3)
        {
            P3Lives.enabled = false;
        }
        if (!GameStats.Player4)
        {
            P4Lives.enabled = false;
        }
    }

    private void LateUpdate()
    {
        if (GameStats.Player1)
        {
            P1Lives.text = "Lives: " + P1HP.currentHealth;
        }
        if (GameStats.Player2)
        {
            P2Lives.text = "Lives: " + P2HP.currentHealth;
        }
        if (GameStats.Player3)
        {
            P3Lives.text = "Lives: " + P3HP.currentHealth;
        }
        if (GameStats.Player4)
        {
            P4Lives.text = "Lives: " + P4HP.currentHealth;
        }
    }
}
