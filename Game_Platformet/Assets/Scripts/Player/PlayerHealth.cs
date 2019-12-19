using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour
{
    public int health = 100;
    
    //[SyncVar(hook = "OnHealthChanged")]
    private int currentHealth;
    
    void Start()
    {
        currentHealth = health;
    }
    
    public void TakeDamage(int damage)
    {
        if (!isServer)
            return;

        currentHealth -= damage;
    }
}
