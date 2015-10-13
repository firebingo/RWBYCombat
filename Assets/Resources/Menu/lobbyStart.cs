using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Linq;

public class lobbyStart : MonoBehaviour
{
    [SerializeField]
    ToggleController tCont;
    GameObject sText;
    Image sImage;
    Button sButton;

    // Use this for initialization
    void Start()
    {
        sText = transform.GetChild(0).gameObject;
        sImage = GetComponent<Image>();
        sButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tCont.getToggleCount() == 2 && NetworkServer.active)
        {
            sText.SetActive(true);
            sImage.enabled = true;
            sButton.enabled = true;
        }
        else
        {
            sText.SetActive(false);
            sImage.enabled = false;
            sButton.enabled = false;
        }
    }

    public void onBClick()
    {
        for(int i = 0; i < CNetworkManager._instance.connectedPlayers.Length;++i)
        {
            if(CNetworkManager._instance.connectedPlayers[i])
            {
                //if the character id for a player is set to 0/random assign it a random value.
                if(CNetworkManager._instance.connectedPlayers[i].getCharacterID() == 0)
                {
                    CNetworkManager._instance.connectedPlayers[i].setCharacterID(UnityEngine.Random.Range(1, (int)(Enum.GetValues(typeof(GameManager.characterNames)).Cast<GameManager.characterNames>().Max())));
                }
            }
        }
        GameManager._instance.gloadLevel("Game");
    }
}
