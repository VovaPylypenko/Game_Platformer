using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ResultsController : NetworkBehaviour
{
    int lives;
    
    [SyncVar]
    bool isGameOverVar;
    
    public Sprite victory;
    public Sprite lose;
    
    Canvas characterInfoPanel;
    
    Image result;

    
    void Start()
    {
        if (isLocalPlayer)
        {
            result = GameObject.Find("ResultImage").GetComponent<Image>();
            result.sprite = lose;
        }
    }

    void Victory()
    {
        if (!isLocalPlayer)
        {
            Debug.Log("WIN");
            result = GameObject.Find("ResultImage").GetComponent<Image>();
            result.sprite = victory;
        }
    }

    void Defeat()
    {
        if (isLocalPlayer)
        {
            Debug.Log("LOSE");
            
            result.sprite = lose;
        }
    }

    void Update()
    {
        isPlayerDead();
        if (isGameOverVar)
        {
            Victory();
            Defeat();
        }
    }

    [ClientCallback]
    void isPlayerDead()
    {
        if (isLocalPlayer)
        {
            CmdEndGame(!gameObject.GetComponent<PlayerHealth>().alive);
        }
    }

    [Command]
    void CmdEndGame(bool isGameOver)
    {
        isGameOverVar = isGameOver;
    }
}
