using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class CNetworkManager : MonoBehaviour//NetworkManager
{
    public static CNetworkManager _instance;
    private static string gameVersion = "Debug6";
    private static string gameName = "RWBY Combat Test";

    public Text ipInput;
    bool serverRunning;

    int port;
    int player1ID;
    int player2ID;
    
    public playerInfo[] connectedPlayers;

    void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            _instance = this;
        }
        else if (_instance != this)
            Destroy(this.gameObject);
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

    //public override void OnServerRemovePlayer(NetworkConnection conn, PlayerController player)
    //{
    //    Debug.Log("Client Disconnected");
    //    for (int i = 0; i < connectedPlayers.Length; ++i)
    //    {
    //        if(player.gameObject.GetComponent<playerInfo>() == connectedPlayers[i])
    //            connectedPlayers[i] = null;
    //    }
    //    NetworkManager.singleton.OnServerRemovePlayer(conn, player);
    //}

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

    //getters and setters
    public bool getServerRunning()
    {
        return serverRunning;
    }

    public int getPlayerID(int i)
    {
        if (i == 1)
            return player1ID;
        else
            return player2ID;
    }

    public void setPlayerID(int i, int iID)
    {
        if (i == 1)
            player1ID = iID;
        else
            player2ID = iID;
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
}
