using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ToggleButton : NetworkBehaviour
{
    [SyncVar]
    private bool isBActive;
    [SerializeField]
    private int numberID;
    [SerializeField]
    private ToggleController toggleController;
    [SerializeField]
    private Sprite inactiveSprite;
    [SerializeField]
    private Sprite activeSprite;
    [SyncVar]
    private string playerName;

    // Use this for initialization
    void Start()
    {
        //if (NetworkServer.active)
        //    NetworkServer.Spawn(this.gameObject);
    }

    override public void OnStartServer()
    {
        //NetworkServer.Spawn(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {  
        if(isBActive)
        {
            GetComponent<Image>().sprite = activeSprite;
        }
        else
        {
            GetComponent<Image>().sprite = inactiveSprite;
        }

        transform.GetChild(0).GetComponent<Text>().text = numberID.ToString();

        if (NetworkServer.active)
        {
            if (CNetworkManager._instance.connectedPlayers[numberID - 1] != null)
                playerName = CNetworkManager._instance.connectedPlayers[numberID - 1].getPlayerName();
            else
                playerName = "empty";
        }
        if(playerName == "")
        {
            playerName = "empty";
        }
    }

    //set the toggle buttons active state. Called by the button the script it attached to when it is pressed.
    public void setActive()
    {
        if (!NetworkServer.active)
            return;

        //if the toggle isint active.
        if (!isBActive)
        {
            //only set it to be active if there are less than 2 toggles already active
            if (toggleController.getToggleCount() < 2 && CNetworkManager._instance.connectedPlayers[numberID-1])
            {
                isBActive = true;
                toggleController.addToggle(GetComponent<ToggleButton>());
                toggleController.toggleUp();
            }
        }
        //if the toggle is active.
        else if (isBActive)
        {
            isBActive = false;
            toggleController.removeToggle(GetComponent<ToggleButton>());
            toggleController.toggleDown();
        }
    }

    //Getters and Setters
    public int getID()
    {
        return numberID;
    }

    public string getPlayerName()
    {
        return playerName;
    }
}
