using UnityEngine.Networking;
using UnityEngine;
using System.Collections;

public class netGameManager : NetworkBehaviour
{
    public static netGameManager _instance;

    [SyncVar]
    [SerializeField]
    int player1ID;
    [SyncVar]
    [SerializeField]
    int player2ID;

    [SyncVar]
    int battlePhase;

    [SyncVar]
    int battleTurn;

    [SyncVar]
    int player1Position;
    [SyncVar]
    int player2Position;

    [SyncVar]
    int player1Action;
    [SyncVar]
    int player2Action;

    [SerializeField]
    characterObject player1Character;
    [SerializeField]
    characterObject player2Character;

    [SyncVar]
    int randomSeed;

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

        randomSeed = Time.frameCount;
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

        player1Position = 0;
        player2Position = 4;
        battlePhase = 1;
        battleTurn = 1;

        //StartCoroutine(updateCycle());

        //nameText[] names = FindObjectsOfType<nameText>();
        //for (int i = 0; i < names.Length; ++i)
        //{
        //    names[i].setUpdated(false);
        //}
    }

    public void setupGame()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator updateCycle()
    {
        yield return new WaitForSeconds(2.0f);
        setupGame();
    }

    //getters and setters
    public int getPlayerID(int i)
    {
        if (i == 1)
            return player1ID;
        else
            return player2ID;
    }

    public void setCharacterObject(int id, characterObject iChar)
    {
        if (id == player1ID)
            player1Character = iChar;
        else if (id == player2ID)
            player2Character = iChar;
    }

    public int getRandomSeed()
    {
        return randomSeed;
    }

    public void iterateSeed(int i)
    {
        randomSeed += i;
    }
}
