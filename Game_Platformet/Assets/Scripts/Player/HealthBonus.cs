using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HealthBonus : NetworkBehaviour
{

    private int healthBonus = 2;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter");
        GetComponent<PlayerHealth>().health = GetComponent<PlayerHealth>().health + healthBonus;
        Destroy(other.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter");
        if (collision.gameObject.name == "Player")
        {
            GetComponent<PlayerHealth>().health = GetComponent<PlayerHealth>().health + healthBonus;
            Destroy(gameObject);
        }
    }

}
