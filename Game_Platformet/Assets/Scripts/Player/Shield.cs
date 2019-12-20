using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Shield : NetworkBehaviour
{
    public int health = 4;

    private int currentHealth;
    
    [Header("delay time")]
    public float delay = 3.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        StartCoroutine(WaitAndDestroy(delay));
    }
    
    IEnumerator WaitAndDestroy(float wait){
        yield return new WaitForSeconds(wait);
        Destroy (gameObject);
    }
    
    public void TakeDamage(int damage)
    {
        Debug.Log("TakeDamage");
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy (gameObject);
        }
        Debug.Log(currentHealth);
    }
}
