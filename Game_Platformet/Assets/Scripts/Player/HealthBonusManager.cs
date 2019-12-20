using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HealthBonusManager : NetworkBehaviour
{
    private Vector3[] vectors = {
            new Vector3(-8.6F, 5.8F),
            new Vector3(8.6F, 5.8F),
            new Vector3(-10.5F, 3.4F),
            new Vector3(10.5F, 3.4F),
            new Vector3(-5.6F, -6F),
            new Vector3(5.6F, -6F),
            new Vector3(0.4F, 0F)
            };

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBonus", 5, 5);
    }

    private void SpawnBonus()
    {
        Object healthBonus = Resources.Load("HealthBonus", typeof(GameObject));
        GameObject healthBonusObject = Instantiate(healthBonus) as GameObject;
        healthBonusObject.transform.position = GetRandomPostion();
        NetworkServer.Spawn(healthBonusObject);
        //Invoke("SpawnBonus", 9);
    }

    private Vector3 GetRandomPostion()
    {
        int randomIndex = Random.Range(0, vectors.Length);
        return vectors[randomIndex];
    }
}
