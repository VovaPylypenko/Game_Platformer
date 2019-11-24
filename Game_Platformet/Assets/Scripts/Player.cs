using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Controller")] public GameObject[] controller;

    [Header("Skins")] public GameObject[] skins;
    [Header("Guns")] public GameObject[] guns;
    [Header("Bullet")] public GameObject bullet;

    [Header("Jump")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    
    private bool grounded = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            grounded = false;
            Jump();
        }
        if (rb2D.velocity.y < 0)
        {
            rb2D.velocity += Time.deltaTime * Physics2D.gravity.y * (fallMultiplier - 1) * Vector2.up;
        } else if (rb2D.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb2D.velocity += Time.deltaTime * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Vector2.up;
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            //TODO: add side animation
        }
        else
        {
            Flip();
            //TODO: add walk animation
        }
    }
    
    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        rb2D.velocity = new Vector2(Input.GetAxis("Horizontal") * 12f, rb2D.velocity.y);
        //rb2D.velocity = new Vector2( joystick.Horizontal * 12f, rb2D.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!grounded && other.gameObject.tag.Equals("ground"))
        {
            grounded = true;
        }
        if (other.gameObject.CompareTag($"enemy"))
        {
            Invoke(nameof(ReloadLevel), 1);
        }
        if (other.gameObject.CompareTag($"complete_level"))
        {
            Debug.Log("WIN!");
        }
    }

    private void Jump()
    {
        rb2D.AddForce(transform.up * 18f, ForceMode2D.Impulse);
    }

    private void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0,0,0);
        
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0,180,0);
    }

    private void ReloadLevel()
    {
        Application.LoadLevel(index: Application.loadedLevel);
    }
}
