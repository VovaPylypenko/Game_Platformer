using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShield : NetworkBehaviour
{
    public Transform shieldPoint;

    public GameObject shieldPrefab;
    
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            CmdMakeShield();
        }
        
    }

    [Command]
    private void CmdMakeShield()
    {
        var shield = Instantiate(shieldPrefab, shieldPoint.position, shieldPoint.rotation);
        NetworkServer.Spawn(shield);
    }
}
