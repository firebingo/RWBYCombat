using UnityEngine;
using System.Collections;

public class Ruby : Character
{

    // Use this for initialization
    protected override void Start()
    {
        playerID = 0;
        characterID = 1;

        Health = 500;
        Defense = 15;
        Melee = 90;
        Ranged = 110;
        Spirit = 15;
        fullEndurance = 300;
        Endurance = fullEndurance;
        pastEndurance = 0;
        Dodge = 9;
        Speed = 11;

        movementPenalty = 20;

        semblenceActive = false;
        semblenceTurns = 0;

        fMoveSpaces = 2;
        bMoveSpaces = 2;
        movedSpaces = 0;

        turnAction = 0;
    }

    // Update is called once per frame
    protected override void Update()
    {

    }

    public override void runTurn()
    {

    }

    protected override void passiveSemblence()
    {

    }

    public override void activeSemblence()
    {
        fMoveSpaces = 4;
        bMoveSpaces = 4;
    }

    protected override void endSemblence()
    {

    }
}
