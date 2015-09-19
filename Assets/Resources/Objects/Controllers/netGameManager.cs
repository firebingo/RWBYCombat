using UnityEngine.Networking;
using UnityEngine;

public class netGameManager : NetworkBehaviour
{
    public static netGameManager _instance;

    [SyncVar]
    [SerializeField]
    int player1ID;
    [SyncVar]
    [SerializeField]
    int player2ID;

    void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            _instance = this;
        }
        else if (_instance != this)
            Destroy(this.gameObject);

        player1ID = CNetworkManager._instance.getPlayerID(1);
        player2ID = CNetworkManager._instance.getPlayerID(2);
    }

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < CNetworkManager._instance.connectedPlayers.Length; ++i)
        {
            if (CNetworkManager._instance.connectedPlayers[i])
            {
                if (CNetworkManager._instance.connectedPlayers[i].getPlayerID() == player1ID || CNetworkManager._instance.connectedPlayers[i].getPlayerID() == player2ID)
                    CNetworkManager._instance.connectedPlayers[i].setIsPlayer(true);
            }
        }

        nameText[] names = FindObjectsOfType<nameText>();
        for (int i = 0; i < names.Length; ++i)
        {
            names[i].setUpdated(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //getters and setters
    public int getPlayerID(int i)
    {
        if (i == 1)
            return player1ID;
        else
            return player2ID;
    }
}
