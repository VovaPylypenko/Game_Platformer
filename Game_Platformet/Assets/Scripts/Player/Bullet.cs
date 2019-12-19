using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour
{

    public float speed = 20f;
    public int damage = 40;
    [Header("delay time")]
    public float delay = 1.0f;
    private Rigidbody2D rb2D;

    
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        rb2D.velocity = transform.right * speed;
        StartCoroutine(WaitAndDestroy(delay));
    }
    
    IEnumerator WaitAndDestroy(float wait){
        yield return new WaitForSeconds(wait);
        Destroy (gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("IN OnTriggerEnter2D");
        var playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
