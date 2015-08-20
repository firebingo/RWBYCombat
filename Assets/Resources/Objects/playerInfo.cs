using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class playerInfo : MonoBehaviour
{
    [SerializeField]
    int characterID;

    [SerializeField]
    string playerName;

    // Use this for initialization
    void Start()
    {
        playerName = GameManager._instance.playerName;
        characterID = GameManager._instance.characterID;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
