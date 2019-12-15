﻿using UnityEngine;
using UnityEngine.Networking;

public class Ball : NetworkBehaviour
{
    public GameObject fireball;
    public Transform spawn;
    float timeToSpawn = 5f;

    // Use this for initialization
    void Start () {
        if(isServer)
            InvokeRepeating("ShootFireBall", timeToSpawn, timeToSpawn);
    }
	
    [Command]
    void CmdSpawnFireball()
    {
        GameObject ball = Instantiate(fireball, new Vector3(Random.Range(-20f, 20f), spawn.transform.position.y, 0), Quaternion.identity) as GameObject;
        ball.GetComponent<Rigidbody>().AddForce(Random.Range(-1500f, 1500f), Random.Range(-1010f, 1000f), 0);
        NetworkServer.Spawn(ball);
        Destroy(ball, 2.5f);
    }

    void ShootFireBall()
    {
        for (int i = 0; i < 2; i++)
        {
            CmdSpawnFireball();
        }
    }
}
