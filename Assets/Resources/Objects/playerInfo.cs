using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class playerInfo : NetworkBehaviour
{
    [SerializeField]
    [SyncVar]
    int characterID;

    [SerializeField]
    [SyncVar]
    string playerName;

    // Use this for initialization
    void Start()
    {
        CmdinitVars(GameManager._instance.playerName, GameManager._instance.characterID);
    }

    // Update is called once per frame
    void Update()
    {

    }

    [Command]
    void CmdinitVars(string pName, int pID)
    {
        playerName = pName;
        characterID = pID;
    }
}
