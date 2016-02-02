using gameEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

class turnButton : MonoBehaviour
{
    [SerializeField]
    int actionID;
    [SerializeField]
    Slider moveSlider;

    void Start()
    {
        //should get the turn action from the actions enum for the button based on its name.
        for (int i = 0; i < (int)(Enum.GetValues(typeof(turnActions)).Cast<turnActions>().Max() + 1); ++i)
        {
            if (this.gameObject.name == Enum.Parse(typeof(turnActions), i.ToString()).ToString())
                actionID = ((int[])(Enum.GetValues(typeof(turnActions))))[i];
        }
    }

    public void onPush()
    {
        //Get the corresponding player that pushed to button then calls the command on the
        // net game manager to set their action for this phase.
        if (netGameManager._instance.getPlayerID(1) == GameManager._instance.playerID)
        {
            netGameManager._instance.CmdsetPlayerAction(1, actionID);
            if (actionID == (int)turnActions.Move && moveSlider)
                netGameManager._instance.CmdsetPlayerMove(1, (int)moveSlider.value);
        }
        else if (netGameManager._instance.getPlayerID(2) == GameManager._instance.playerID)
        {
            netGameManager._instance.CmdsetPlayerAction(2, actionID);
            if (actionID == (int)turnActions.Move && moveSlider)
                netGameManager._instance.CmdsetPlayerMove(2, (int)moveSlider.value);
        }

        if (CNetworkManager._instance.getServerRunning())
            netGameManager._instance.addActionsReady(1);

        netGameManager._instance.iterateSeed(2);
    }
}
