using UnityEngine;
using System.Collections;

public class UIPlayerInfo : MonoBehaviour
{
    [SerializeField]
    playerInfo uiPlayer; //reference to the object to pull the info for display from.
    [SerializeField]
    int number;

    // Use this for initialization
    void Start()
    {
        //delay the initialization to make sure the syncvars get caught up on the clients.
        StartCoroutine(updateCycle());
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    void Initialize()
    {
        findPlayerInfo();
    }

    void findPlayerInfo()
    {
        if (netGameManager._instance)
        {
            //sets the playerIDs on the network manager to match those that are host controlled from the new game manager.
            CNetworkManager._instance.setPlayerID(number, netGameManager._instance.getPlayerID(number));
            //look through the list of players on the server.
            for (int i = 0; i < CNetworkManager._instance.connectedPlayers.Length; ++i)
            {
                if (CNetworkManager._instance.connectedPlayers[i])
                {
                    //if the player at i is "playing"
                    if (CNetworkManager._instance.connectedPlayers[i].getIsPlayer())
                    {
                        //if the player at i id is the id of the player that should be used for this ui object.
                        if (CNetworkManager._instance.connectedPlayers[i].getPlayerID() == netGameManager._instance.getPlayerID(number))
                        {
                            uiPlayer = CNetworkManager._instance.connectedPlayers[i];
                        }
                    }
                }
            }
        }
    }

    IEnumerator updateCycle()
    {
        yield return new WaitForSeconds(1.25f);
        Initialize();
    }

    public playerInfo getPlayer()
    {
        return uiPlayer;
    }
}
