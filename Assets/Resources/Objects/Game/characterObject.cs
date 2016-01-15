using UnityEngine;
using System.Collections;

public class characterObject : MonoBehaviour
{
    [SerializeField]
    playerInfo uiPlayer; //reference to the object to pull the info for display from.
    [SerializeField]
    int number;

    Character gameCharacter;

    SpriteRenderer characterSprite;

    int animationID;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(updateCycle());
        characterSprite = this.GetComponent<SpriteRenderer>();
    }

    void Initialize()
    {
        findPlayerInfo();
        setPlayerSprite();
        netGameManager._instance.setCharacterObject(uiPlayer.getPlayerID(), this);
    }

    // Update is called once per frame
    void Update()
    {

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

    void setPlayerSprite()
    {
        switch (uiPlayer.getCharacterID())
        {
            case 1:
                characterSprite.sprite = GameManager._instance.chracterSprites[1];
            break;
            case 2:
                characterSprite.sprite = GameManager._instance.chracterSprites[2];
            break;
        }

        if (!characterSprite.sprite)
            characterSprite.sprite = GameManager._instance.chracterSprites[0];
    }

    IEnumerator updateCycle()
    {
        yield return new WaitForSeconds(2.0f);
        Initialize();
    }
}
