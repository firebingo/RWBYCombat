using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class CNetworkManager : MonoBehaviour
{
    private static string gameVersion = "Debug6";
    private static string gameName = "RWBY Combat Test";

    public Text ipInput;
    public bool serverRunning;

    int port;
    string roomName;
    string[] playerNames;
    
    void start()
    {
        serverRunning = false;
        port = 0;
        playerNames = new string[NetworkManager.singleton.maxConnections];
    }

    public void startServer()
    {
        NetworkManager.singleton.networkAddress = ipInput.text.ToString();
        NetworkManager.singleton.networkPort = GameManager._instance.Port;
        NetworkManager.singleton.StartHost();
        serverRunning = true;
        if (NetworkManager.singleton.isNetworkActive)
        {
            GameManager._instance.mainMenuParent.SetActive(false);
            GameManager._instance.lobbyParent.SetActive(true);
        }
        else
            closeServer();
    }

    public void joinServer()
    {
        NetworkManager.singleton.networkAddress = ipInput.text.ToString();
        NetworkManager.singleton.networkPort = GameManager._instance.Port;
        NetworkManager.singleton.StartClient();
        if (NetworkManager.singleton.isNetworkActive)
        {
            GameManager._instance.mainMenuParent.SetActive(false);
            GameManager._instance.lobbyParent.SetActive(true);
        }
        else
            closeServer();
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
