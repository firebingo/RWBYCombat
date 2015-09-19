using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class playerInfo : NetworkBehaviour
{
    [SerializeField]
    int characterID;

    [SyncVar]
    [SerializeField]
    string playerName;

    [SyncVar]
    [SerializeField]
    int playerID;

    [SyncVar]
    bool isPlayer;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        CmdinitVars(GameManager._instance.playerName, GameManager._instance.characterID);
        if (NetworkServer.active)
        {
            for (int i = 0; i < CNetworkManager._instance.connectedPlayers.Length; ++i)
            {
                if (CNetworkManager._instance.connectedPlayers[i] == null)
                {
                    CNetworkManager._instance.connectedPlayers[i] = this;
                    playerID = i;
                    i = CNetworkManager._instance.connectedPlayers.Length + 1;
                }
            }
        }
        else
        {
            for (int i = 0; i < CNetworkManager._instance.connectedPlayers.Length; ++i)
            {
                if (CNetworkManager._instance.connectedPlayers[i] == null)
                {
                    CNetworkManager._instance.connectedPlayers[i] = this;
                    i = CNetworkManager._instance.connectedPlayers.Length + 1;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    [Command]
    void CmdinitVars(string pName, int cID)
    {
        playerName = pName;
        characterID = cID;
    }

    //getters and setters
    public string getPlayerName()
    {
        return playerName;
    }

    public int getPlayerID()
    {
        return playerID;
    }

    public bool getIsPlayer()
    {
        return isPlayer;
    }

    public void setIsPlayer(bool iIs)
    {
        isPlayer = iIs;
    }
}
