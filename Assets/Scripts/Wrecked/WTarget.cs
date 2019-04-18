﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WTarget : MonoBehaviour
{
    public float health = 50f;


    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Dead");
    }
}
