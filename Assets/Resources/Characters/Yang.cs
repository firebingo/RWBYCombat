using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Yang : Character
{
    // Use this for initialization
    protected override void Start()
    {
        playerID = 0;
        characterID = (int)gameEnums.characterNames.Yang;

        Health = 650;
        Defense = 25;
        Melee = 110;
        Ranged = 80;
        Spirit = 9;
        fullEndurance = 450;
        Endurance = fullEndurance;
        pastEndurance = 0;
        Dodge = 4;
        fullSpeed = 6;
        Speed = fullSpeed;

        movementPenalty = 25;

        canUseSemblence = false;
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
        
    }

    protected override void endSemblence()
    {

    }
}
