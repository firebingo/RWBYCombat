using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pNameField : MonoBehaviour
{
    [SerializeField]
    Text playerName;

    public void setPlayerName()
    {
        GameManager._instance.setPlayerName(playerName);
    }
}
