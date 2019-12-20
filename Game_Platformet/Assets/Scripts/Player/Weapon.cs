using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Weapon : NetworkBehaviour
{
    public Transform firePoint;

    public GameObject bulletPrefab;
    
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            CmdShoot();
        }
        
    }

    [Command]
    private void CmdShoot()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        NetworkServer.Spawn(bullet);
    }
}
