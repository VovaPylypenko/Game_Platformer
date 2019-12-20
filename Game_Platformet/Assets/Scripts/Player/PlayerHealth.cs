using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour
{
    public int health;
    public bool alive = true;

    private int currentHealth;
    private bool isSavedMood = false;
    
    void Start()
    {
        currentHealth = health;
        Debug.Log("health " + health);
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
