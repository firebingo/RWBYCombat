using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    private bool isActive;
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

    }

    //set the toggle buttons active state. Called by the button the script it attached to when it is pressed.
    public void setActive()
    {
        //if the toggle isint active.
        if (isActive == false)
        {
            //only set it to be active if there are less than 2 toggles already active
            if (toggleController.getToggleCount() < 2)
            {
                isActive = true;
                toggleController.addToggle(GetComponent<ToggleButton>());
                toggleController.toggleUp();
                GetComponent<Image>().sprite = activeSprite;
            }
        }
        //if the toggle is active.
        else
        {
            isActive = false;
            toggleController.removeToggle(GetComponent<ToggleButton>());
            toggleController.toggleDown();
            GetComponent<Image>().sprite = inactiveSprite;
        }
    }

    //Getters and Setters
    int getID()
    {
        return numberID;
    }
}
