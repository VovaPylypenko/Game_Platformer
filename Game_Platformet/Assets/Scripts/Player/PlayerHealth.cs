﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour
{
    public int health = 3;
    public bool alive = true;

    private int currentHealth;
    private bool isSavedMood = false;
    
    void Start()
    {
        currentHealth = health;
        Debug.Log("health " + health);
    }

    public void UpHealth(int bonusUp)
    {
        currentHealth += bonusUp;
        if (currentHealth > health)
            currentHealth = health;
        Debug.Log(currentHealth);
    }
    
    public void TakeDamage(int damage)
    {
        if (isSavedMood) return;

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            alive = false;
        }
        else
            StartCoroutine("beSAVED");
    }
    
    IEnumerator beSAVED()
    {
        isSavedMood = true;
        yield return new WaitForSeconds(.5f);
        isSavedMood = false;
    }
}
