﻿using System;
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
        rb2D.velocity = new Vector2(Input.GetAxis("Horizontal") * 12f, rb2D.velocity.y);
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
