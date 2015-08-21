using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ToggleButton : NetworkBehaviour
{
    [SyncVar]
    private bool isActive = false;
    [SerializeField]
    private int numberID;
    [SerializeField]
    private ToggleController toggleController;
    [SerializeField]
    private Sprite inactiveSprite;
    [SerializeField]
    private Sprite activeSprite;

    // Use this for initialization
    void Start()
    {
        transform.GetChild(0).GetComponent<Text>().text = numberID.ToString();
    }

    // Update is called once per frame
    void Update()
    {  
        if(isActive)
        {
            GetComponent<Image>().sprite = activeSprite;
        }
        else
        {
            GetComponent<Image>().sprite = inactiveSprite;
        }
    }

    void OnVar(bool value)
    {
        Debug.LogError("Value Changed");
        isActive = value;
    }

    //set the toggle buttons active state. Called by the button the script it attached to when it is pressed.
    public void setActive()
    {
        if (!NetworkServer.active)
            return;

        //if the toggle isint active.
        if (!isActive)
        {
            //only set it to be active if there are less than 2 toggles already active
            if (toggleController.getToggleCount() < 2)
            {
                isActive = true;
                toggleController.addToggle(GetComponent<ToggleButton>());
                toggleController.toggleUp();
            }
        }
        //if the toggle is active.
        else if (isActive)
        {
            isActive = false;
            toggleController.removeToggle(GetComponent<ToggleButton>());
            toggleController.toggleDown();
        }
    }

    //Getters and Setters
    int getID()
    {
        return numberID;
    }
}
