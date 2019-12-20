using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour
{
    public int health = 3;
    
    //[SyncVar(hook = "OnHealthChanged")]
    private int currentHealth;
    private bool isSavedMood = false;
    
    void Start()
    {
        currentHealth = health;
    }
    
    public void TakeDamage(int damage)
    {
        if (!isLocalPlayer)
            return;

        currentHealth -= damage;
        
        StartCoroutine("beSAVED");
    }
    
    IEnumerator beSAVED()
    {
        isSavedMood = true;
        yield return new WaitForSeconds(.5f);
        isSavedMood = false;
    }
}
