using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomNetworkManager : NetworkManager
{
    int _changedScene = -1;
    int sceneOrderPlayer = 2;
    int sceneArenaMapping = 3;
    int sceneGame = 4;
    
    public int chosenCharacter = 0;
    
    void Start()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        _changedScene = arg0.buildIndex;
    }

    void Update()
    {
        if (_changedScene == -1)
            return;
        
        if (_changedScene == sceneOrderPlayer)
        {
            SetupOrderPlayerScene();
        }
        else if (_changedScene == sceneArenaMapping)
        {
            SetupMenuSceneButtons();
        }
        else if (_changedScene == sceneGame)
        {
            if(NetworkServer.active)
                SpawnNetworkedItems();
        }
        _changedScene = -1;
    }
    
    void SetupOrderPlayerScene()
    {
        //GameObject.Find("Player1Button").GetComponent<Button>().onClick.AddListener(btn1);
    }
    
    void SetupMenuSceneButtons()
    {
        GameObject.Find("Join").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Join").GetComponent<Button>().onClick.AddListener(StartUpHost);

        //GameObject.Find("JoinGame").GetComponent<Button>().onClick.RemoveAllListeners();
        //GameObject.Find("JoinGame").GetComponent<Button>().onClick.AddListener(JoinGame);
    }
    
    void SpawnNetworkedItems()
    {
        //GameObject FireballSpawner = Instantiate(Resources.Load("Game/FireballSpawner", typeof(GameObject))) as GameObject;
        //GameObject PowerUpManager = Instantiate(Resources.Load("Game/PowerUpManager", typeof(GameObject))) as GameObject;
        //
        //NetworkServer.Spawn(FireballSpawner);
        //NetworkServer.Spawn(PowerUpManager);
        NetworkServer.SpawnObjects();
    }
    
    public void JoinGame()
    {
        if (NetworkClient.active || NetworkServer.active)
            return;

        NetworkManager.singleton.networkPort = 7777;
        NetworkManager.singleton.StartClient();
    }
    
    public void StartUpHost()
    {
        if (NetworkClient.active || NetworkServer.active)
            return;

        NetworkManager.singleton.networkPort = 7777;
        NetworkManager.singleton.StartHost();

    }
    
    //subclass for sending network messages
    public class NetworkMessage : MessageBase
    {
        public int chosenClass;
    }
    
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
    {
        NetworkMessage message = extraMessageReader.ReadMessage<NetworkMessage>();
        int selectedClass = message.chosenClass;
        // Debug.Log("server add with message " + selectedClass);

        if (selectedClass == 0)
        {
            GameObject player = Instantiate(Resources.Load("Characters/Player", typeof(GameObject))) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
    }
    
    public override void OnClientConnect(NetworkConnection conn)
    {
        NetworkMessage test = new NetworkMessage();
        test.chosenClass = chosenCharacter;

        ClientScene.AddPlayer(conn, 0, test);
    }
    
    public override void OnClientSceneChanged(NetworkConnection conn)
    {
        //base.OnClientSceneChanged(conn);
    }
    
    public void btn1()
    {
        chosenCharacter = 0;
    }
}
