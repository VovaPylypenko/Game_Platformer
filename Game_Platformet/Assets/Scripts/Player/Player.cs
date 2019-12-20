using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    private Rigidbody2D rb2D;

    public float speed;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetAxis("Horizontal") == 0)
        {

        }
        else
        {
            Flip();
        }
    }
    
    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        rb2D.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb2D.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (other.gameObject.CompareTag($"enemy"))
        {
            Invoke(nameof(ReloadLevel), 1);
        }
        if (other.gameObject.name == "HealthBonus")
        {
            Debug.Log("asdad");
            GetComponent<PlayerHealth>().health = GetComponent<PlayerHealth>().health + 2;
            Destroy(other.gameObject);
        }
    }

    private void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.rotation = Quaternion.Euler(0,0,0);
        
        if (Input.GetAxis("Horizontal") < 0)
            transform.rotation = Quaternion.Euler(0,180,0);
    }

    private void ReloadLevel()
    {
        // Application.LoadLevel(index: Application.loadedLevel);
    }
}
