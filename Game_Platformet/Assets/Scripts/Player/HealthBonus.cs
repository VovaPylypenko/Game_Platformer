using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HealthBonus : NetworkBehaviour
{

    private int healthBonus = 2;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (other.gameObject.CompareTag("bonus"))
        {
            GetComponent<PlayerHealth>().UpHealth(healthBonus);
            Destroy(other.gameObject);
        }
    }
}
