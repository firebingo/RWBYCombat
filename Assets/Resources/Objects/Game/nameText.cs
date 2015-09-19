using UnityEngine;
using UnityEngine.UI;

public class nameText : MonoBehaviour
{
    [SerializeField]
    int number;
    bool updated = false;

    // Update is called once per frame
    void LateUpdate()
    {
        if (netGameManager._instance && !updated)
        {
            for (int i = 0; i < CNetworkManager._instance.connectedPlayers.Length; ++i)
            {
                if (CNetworkManager._instance.connectedPlayers[i])
                {
                    if (CNetworkManager._instance.connectedPlayers[i].getPlayerID() == netGameManager._instance.getPlayerID(number))
                        GetComponent<Text>().text = CNetworkManager._instance.connectedPlayers[i].getPlayerName();

                    if (CNetworkManager._instance.connectedPlayers[i].isLocalPlayer)
                    {
                        if (CNetworkManager._instance.connectedPlayers[i].getIsPlayer())
                        {
                            if (number == 1)
                                GetComponent<Text>().text = CNetworkManager._instance.connectedPlayers[i].getPlayerName();
                            if (number == 2)
                            {
                                for (int j = 0; j < CNetworkManager._instance.connectedPlayers.Length; ++j)
                                {
                                    if (CNetworkManager._instance.connectedPlayers[j])
                                    {
                                        if (CNetworkManager._instance.connectedPlayers[j].getIsPlayer())
                                        {
                                            if (CNetworkManager._instance.connectedPlayers[j].getPlayerID() != CNetworkManager._instance.connectedPlayers[i].getPlayerID())
                                            {
                                                GetComponent<Text>().text = CNetworkManager._instance.connectedPlayers[j].getPlayerName();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                updated = true;
            }
        }
    }

    public void setUpdated(bool iUp)
    {
        updated = iUp;
    }
}
