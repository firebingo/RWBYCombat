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
        StartCoroutine(updateCycle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateUI()
    {
        if (netGameManager._instance)
        {
            CNetworkManager._instance.setPlayerID(number, netGameManager._instance.getPlayerID(number));
            for (int i = 0; i < CNetworkManager._instance.connectedPlayers.Length; ++i)
            {
                if (CNetworkManager._instance.connectedPlayers[i])
                {
                    if (CNetworkManager._instance.connectedPlayers[i].getIsPlayer())
                    {
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
        yield return new WaitForSeconds(2.5f);
        updateUI();
    }

    public playerInfo getPlayer()
    {
        return uiPlayer;
    }
}
