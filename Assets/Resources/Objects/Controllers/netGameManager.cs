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
    [SyncVar]
    int player1MoveSpaces;
    [SyncVar]
    int player2MoveSpaces;

    [SyncVar]
    int actionsReady;

    [SerializeField]
    characterObject player1Character;
    [SerializeField]
    characterObject player2Character;

    [SyncVar]
    int randomSeed;

    bool turnRunning;

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
        foreach (var player in CNetworkManager._instance.connectedPlayers)
        {
            if (player)
            {
                if (player.getPlayerID() == player1ID || player.getPlayerID() == player2ID)
                    player.setIsPlayer(true);

                if (player.getPlayerName() == GameManager._instance.playerName)
                    GameManager._instance.playerID = player.getPlayerID();
            }
        }

        player1Position = 0;
        player2Position = 4;
        battlePhase = 1;
        battleTurn = 1;
        actionsReady = 0;

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
        if (actionsReady == 2)
            StartCoroutine(doWaitThenTurn());
    }

    public void iterateSeed(int i)
    {
        randomSeed += i;
    }

    public void doTurn()
    {
        Character player1GameCharacter = player1Character.getCharacter();
        Character player2GameCharacter = player2Character.getCharacter();

        if (player1GameCharacter.getSpeed() > player2GameCharacter.getSpeed())
        {
            StartCoroutine(player1Turn());
            turnRunning = true;
        }
        else
        {
            StartCoroutine(player2Turn());
            turnRunning = true;
        }
    }

    IEnumerator player1Turn()
    {
        yield return new WaitForSeconds(2.0f);
    }

    IEnumerator player2Turn()
    {
        yield return new WaitForSeconds(2.0f);
    }

    IEnumerator updateCycle()
    {
        yield return new WaitForSeconds(2.0f);
        setupGame();
    }

    IEnumerator doWaitThenTurn()
    {
        yield return new WaitForSeconds(0.5f);
        doTurn();
    }

    //getters and setters
    public int getPlayerID(int i)
    {
        if (i == 1)
            return player1ID;
        else
            return player2ID;
    }

    public int getRandomSeed()
    {
        return randomSeed;
    }

    public void setCharacterObject(int id, characterObject iChar)
    {
        if (id == player1ID)
            player1Character = iChar;
        else if (id == player2ID)
            player2Character = iChar;
    }

    [Command]
    public void CmdsetPlayerAction(int player, int iAction)
    {
        if (player == 1)
            player1Action = iAction;
        else
            player2Action = iAction;
    }

    [Command]
    public void CmdsetPlayerMove(int player, int iMove)
    {
        if (player == 1)
            player1MoveSpaces = iMove;
        else                   
            player2MoveSpaces = iMove;
    }

    public void addActionsReady(int i)
    {
        actionsReady += i;
    }
}
