﻿using UnityEngine;
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

    void Initialize()
    {
        findPlayerInfo();
    }

    void findPlayerInfo()
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
                            //Debug.LogError(number);
                            //Debug.LogError(netGameManager._instance.getPlayerID(number));
                            //Debug.LogError(CNetworkManager._instance.connectedPlayers[i].getPlayerID());
                            uiPlayer = CNetworkManager._instance.connectedPlayers[i];
                        }
                    }
                }
            }
        }
    }

    IEnumerator updateCycle()
    {
        yield return new WaitForSeconds(2.0f);
        Initialize();
    }

    public playerInfo getPlayer()
    {
        return uiPlayer;
    }
}
