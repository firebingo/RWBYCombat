using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HostButton : MonoBehaviour
{
    public Text portInput;
    public Text gameNameInput;
    GameManager Manager;

    // Use this for initialization
    void Start()
    {
        Manager = FindObjectOfType<GameManager>();
    }

    public void setPort()
    {
        string portS;
        if (portInput)
        {
            if (portInput.text.ToString() == "")
                portS = "25555";
            else
                portS = portInput.text.ToString();
        }
        else
            portS = "25555";

        int port = -1;
        port = int.Parse(portS);

        if (port > 1 && port < 65534)
            Manager.GetComponent<NetworkManager>().setPort(port);
        else
            Manager.GetComponent<NetworkManager>().setPort(25555);
    }

    public void setRoomName()
    {
        string gameName;
        if(gameNameInput)
        {
            if(gameNameInput.text.ToString() == "")
                gameName = "Invalid";
            else
                gameName = gameNameInput.text.ToString();
        }
        else
            gameName = "Invalid";

        Manager.GetComponent<NetworkManager>().setRoomName(gameName);
    }
}
