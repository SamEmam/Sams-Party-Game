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
        P1Lives.color = new Color32(255, 0, 0, 255);
        P2Lives.color = new Color32(0, 0, 255, 255);
        P3Lives.color = new Color32(0, 255, 0, 255);
        P4Lives.color = new Color32(255, 255, 0, 255);
    }

    private void LateUpdate()
    {
        P1Lives.text = "Lives: " + P1HP.currentHealth;
        P2Lives.text = "Lives: " + P2HP.currentHealth;
        P3Lives.text = "Lives: " + P3HP.currentHealth;
        P4Lives.text = "Lives: " + P4HP.currentHealth;
    }
}
