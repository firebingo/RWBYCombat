using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class CNetworkManager : NetworkManager
{
    public static CNetworkManager _instance;
    private static string gameVersion = "Debug6";
    private static string gameName = "RWBY Combat Test";

    public Text ipInput;
    public bool serverRunning;

    int port;
    string roomName;
    
    public playerInfo[] connectedPlayers;

    void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        serverRunning = false;
        port = 0;
        connectedPlayers = new playerInfo[NetworkManager.singleton.maxConnections];
        DontDestroyOnLoad(this);
    }

    public void startServer()
    {
        NetworkManager.singleton.networkAddress = ipInput.text.ToString();
        NetworkManager.singleton.networkPort = GameManager._instance.Port;
        NetworkManager.singleton.StartHost();
        serverRunning = true;
        if (!NetworkManager.singleton.isNetworkActive)
            closeServer();
    }

    public void joinServer()
    {
        NetworkManager.singleton.networkAddress = ipInput.text.ToString();
        NetworkManager.singleton.networkPort = GameManager._instance.Port;
        NetworkManager.singleton.StartClient();
        if (!NetworkManager.singleton.isNetworkActive)
            closeServer();
    }

    public void gLoadNetLevel(string iName)
    {
        NetworkManager.singleton.ServerChangeScene(iName);
    }

    public override void OnServerRemovePlayer(NetworkConnection conn, PlayerController player)
    {
        Debug.Log("Client Disconnected");
        for (int i = 0; i < connectedPlayers.Length; ++i)
        {
            if(player.gameObject.GetComponent<playerInfo>() == connectedPlayers[i])
                connectedPlayers[i] = null;
        }
        NetworkManager.singleton.OnServerRemovePlayer(conn, player);
    }

    public void setPort(Text iPort)
    {
        int temp = int.Parse(iPort.text.ToString());

        if (temp > 0 && temp < 65534)
            port = temp;
        else
            port = 25561;

        GameManager._instance.Port = port;
        GameManager._instance.refreshQuality = true;
    }

    public void setRoomName(string iName)
    {
        roomName = iName;
    }

    public void closeServer()
    {
        if (serverRunning)
        {
            NetworkManager.singleton.StopServer();
            NetworkManager.singleton.StopHost();
            serverRunning = false;
        }
        else
            NetworkManager.singleton.StopClient();
    }
}
