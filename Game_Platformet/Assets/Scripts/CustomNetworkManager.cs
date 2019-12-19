using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomNetworkManager : NetworkManager
{
    int _changedScene = -1;
    int sceneOrderPlayer = 1;
    int sceneArenaMapping = 2;
    int sceneGame = 3;

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
            //SetupOtherSceneButtons();
            if (NetworkServer.active)
            {
                SpawnNetworkedItems();
            }
        }
        _changedScene = -1;
    }
    
    void SetupOrderPlayerScene()
    {
        GameObject.Find("Player1Button").GetComponent<Button>().onClick.AddListener(btn1);
    }

    void SetupMenuSceneButtons()
    {
        GameObject.Find("Join").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Join").GetComponent<Button>().onClick.AddListener(JoinGame);
        
        GameObject.Find("Create").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Create").GetComponent<Button>().onClick.AddListener(StartUpHost);
    }

    void SpawnNetworkedItems()
    {
        //GameObject BulletSpawner = Instantiate(Resources.Load("FireballSpawner", typeof(GameObject))) as GameObject;
        
        //NetworkServer.Spawn(BulletSpawner);
        NetworkServer.SpawnObjects();
    }
    
    public void JoinGame()
    {
        if (NetworkClient.active || NetworkServer.active)
            return;
        
        SetIPAddress();
        SetPort();
        NetworkManager.singleton.StartClient();
    }
    
    public void StartUpHost()
    {
        Debug.Log("StartUpHost");
        if (NetworkClient.active || NetworkServer.active)
            return;
        
        SetPort();
        NetworkManager.singleton.StartHost();
    }
    
    void SetPort()
    {
        NetworkManager.singleton.networkPort = 7777;
    }
    
    private void SetIPAddress()
    {
        string IpAddress = GameObject.Find("IpAddressText").transform.FindChild("Text").GetComponent<Text>().text;
        NetworkManager.singleton.networkAddress = IpAddress;
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
            Object playerGameObject = Resources.Load("Player", typeof(GameObject));
            GameObject player = Instantiate(playerGameObject) as GameObject;
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
