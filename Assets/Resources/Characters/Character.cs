using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour
{
    protected int playerID; //ID of the player using this character.
    protected int characterID; //ID of the character for charcter selection.
        
    //Character stats
    protected float Health; //self-explained
    protected float Defense; //value from 0-100 to denote a percentage.
    protected float Melee; //value from 0-100 to denote a percentage.
    protected float Ranged; //value from 0-100 to denote a percentage.
    protected float Spirit; //value from 0-100 to denote a percentage.
    protected float Endurance; //the current aura count of the character.
    protected float pastEndurance; //
    protected float fullEndurance; //stores the initial value of endurance.
    protected float Dodge; //value from 0-100 to denote a percentage.
    protected float Speed; //the speed of the character

    protected float movementPenalty; //percentage of damage reduction from movement penalty
    protected float totalDamagePenalty; //The total percentge of damage reduction for the turn.

    protected bool semblenceActive; //Whether or not the semblence is active.
    protected int semblenceTurns; //How many turns the semblence will be active for.

    protected int fMoveSpaces; //how many spaces it's possible to move forward.
    protected int bMoveSpaces; //how many spaces it's possible to move backward.
    protected int movedSpaces; //how many spaces have been moved this turn.

    protected int turnAction; //the action to do this turn.

    // Use this for initialization
    protected abstract void Start();
    
    // Update is called once per frame
    protected abstract void Update();

    public abstract void runTurn();

    void updateStats()
    {
        Random.seed = netGameManager._instance.getRandomSeed();

        //floor endurance at 0
        if (Endurance < 0)
            Endurance = 0;

        //Endurance regeneration
        Endurance += (fullEndurance * (Spirit * 0.01f)) + fullEndurance * Random.Range(-0.02f, 0.02f);

        if (pastEndurance != Endurance)
        {
            pastEndurance = Endurance;
            float auraRemaining = Endurance / fullEndurance;
            if (auraRemaining < 0.2f)
                auraRemaining = 0.2f;
        }
    }

    protected abstract void passiveSemblence();

    public abstract void activeSemblence();

    protected abstract void endSemblence();

    public void takeDamage(float damage)
    {
        Random.seed = netGameManager._instance.getRandomSeed();

        if (Endurance > 0)
            Endurance -= damage + (damage * Random.Range(-0.02f, 0.02f));
        else
            Health -= damage - (damage * ((Defense * 0.01f) * (Endurance / fullEndurance))) + (damage * Random.Range(-0.02f, 0.02f));
    }

    //getters and setters
    //
    public void setTurnAction(int i)
    {
        turnAction = i;
    }

    public float getFullEndurance()
    {
        return fullEndurance;
    }

    public float getCurrentEndurance()
    {
        return Endurance;
    }

    public int getPlayerID()
    {
        return playerID;
    }

    public void setPlayerID(int ID)
    {
        playerID = ID;
    }
}
