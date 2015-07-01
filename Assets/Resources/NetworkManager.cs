using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour
{
    private static string gameVersion = "Debug6";
    private static string gameName = "RWBY Combat Test";

    int port;
    string roomName;
    bool serverRunning;
    string[] playerNames;

    void start()
    {
        port = 0;
        serverRunning = false;
        playerNames = new string[8];
    }

    public void startServer()
    {
        if (!serverRunning)
        {
            Network.InitializeServer(2, port, !Network.HavePublicAddress());
            MasterServer.RegisterHost(gameName, roomName);
        }
    }

    void OnServerInitialized()
    {
        serverRunning = true;
        Debug.Log("Server Initializied");
    }

    public void setPort(int iPort)
    {
        port = iPort;
    }

    public void setRoomName(string iName)
    {
        roomName = iName;
    }

    public void closeServer()
    {
        if (serverRunning)
        {
            Network.Disconnect();
            serverRunning = false;
        }
    }
}
