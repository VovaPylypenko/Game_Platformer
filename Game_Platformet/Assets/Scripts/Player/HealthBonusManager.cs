using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HealthBonusManager : NetworkBehaviour
{
    private Vector2[] vectors = {
            new Vector2(-8.6F, 5.8F),
            new Vector2(8.6F, 5.8F),
            new Vector2(-13.5F, 1F),
            new Vector2(-13.5F, 1F),
            new Vector2(-5.6F, -6F),
            new Vector2(5.6F, -6F),
            new Vector2(0.4F, 0F)
            };

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBonus", 5, 5);
    }

    private void SpawnBonus()
    {
        if (!isServer)
            return;
        Object healthBonus = Resources.Load("HealthBonus", typeof(GameObject));
        GameObject healthBonusObject = Instantiate(healthBonus) as GameObject;
        var position = GetRandomPostion();
        healthBonusObject.transform.position = position;

        NetworkServer.Spawn(healthBonusObject);
        //Invoke("SpawnBonus", 9);
    }

    private Vector3 GetRandomPostion()
    {
        int randomIndex = Random.Range(0, vectors.Length);
        return vectors[randomIndex];
    }
}
