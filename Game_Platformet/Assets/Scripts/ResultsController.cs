using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ResultsController : NetworkBehaviour
{
    int lives;
    
    [SyncVar]
    bool isGameOverVar;
    
    Canvas characterInfoPanel;

    void Start()
    {

    }

    void Victory()
    {
        if (!isLocalPlayer)
        {
            Debug.Log("WIN");
            if(GameObject.FindObjectsOfType(typeof(Result)).Length == 0)
            {
                Object win = Resources.Load("Win", typeof(GameObject));
                GameObject winObject = Instantiate(win) as GameObject;
                winObject.transform.position = new Vector3(0, 0);
                NetworkServer.Spawn(winObject);
            }
        } 
    }

    void Defeat()
    {
        if (isLocalPlayer)
        {
            Debug.Log("LOSE");
            if (GameObject.FindObjectsOfType(typeof(Result)).Length == 0)
            {
                Object lose = Resources.Load("Lose", typeof(GameObject));
                GameObject loseObject = Instantiate(lose) as GameObject;
                loseObject.transform.position = new Vector3(0, 0);
                NetworkServer.Spawn(loseObject);
            }
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
