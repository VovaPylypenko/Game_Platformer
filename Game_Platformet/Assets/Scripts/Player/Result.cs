using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Result : NetworkBehaviour
{
    [Header("delay time")]
    public float delay = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndDestroy(delay));
    }

    IEnumerator WaitAndDestroy(float wait)
    {
        yield return new WaitForSeconds(wait);
        Destroy(gameObject);
        //todo script for future logic
        GameObject.Find("NetworkManager").GetComponent<CustomNetworkManager>().DoOfflineServer();
    }
}
