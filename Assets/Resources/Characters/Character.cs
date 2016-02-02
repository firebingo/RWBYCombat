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
    protected float Speed; //the current speed of the character
    protected float fullSpeed; //the full speed of the character

    protected float movementPenalty; //percentage of damage reduction from movement penalty
    protected float totalDamagePenalty; //The total percentge of damage reduction for the turn.

    protected bool canUseSemblence; //whether or not the character can currently use their semblence.
    protected bool semblenceActive; //Whether or not the semblence is active.
    protected int semblenceTurns; //How many turns the semblence will be active for.

    protected int fMoveSpaces; //how many spaces it's possible to move forward.
    protected int bMoveSpaces; //how many spaces it's possible to move backward.
    protected int movedSpaces; //how many spaces have been moved this turn.
    protected int consecutiveMoves; //how many spaces you've moved in consecutive turns, goes down by 2 each turn you don't move

    protected int turnAction; //the action to do this turn.

    // Use this for initialization
    protected abstract void Start();
    
    // Update is called once per frame
    protected abstract void Update();

    public abstract void runTurn();

    public virtual void updateStats()
    {
        Random.seed = netGameManager._instance.getRandomSeed();

        //floor endurance at 0
        if (Endurance < 0)
            Endurance = 0;

        //Endurance regeneration
        Endurance += (fullEndurance * (Spirit * 0.01f)) + fullEndurance * Random.Range(-0.02f, 0.02f);

        //speed change based on Endurance left
        Speed = fullSpeed * (Endurance / fullEndurance);
        if (Speed < 3)
            Speed = 3;

        //consecutive move update
        if(movedSpaces == 0)
            consecutiveMoves -= 2;
        if (consecutiveMoves < 0)
            consecutiveMoves = 0;

        //if moved and over the consecutivemoves limit do endurance damage.
        if (consecutiveMoves > 4 && movedSpaces > 0)
        {
            Endurance -= fullEndurance * (0.03f * (consecutiveMoves - 4));
        }

        //update pastendurance.
        if (pastEndurance != Endurance)
            pastEndurance = Endurance;

        netGameManager._instance.iterateSeed(1);
    }

    protected abstract void passiveSemblence();

    public abstract void activeSemblence();

    protected abstract void endSemblence();

    /// <summary>
    /// Does damage to the character and returns the amount of damage done to their health (not endurance).
    /// </summary>
    /// <param name="damage"></param>
    /// <returns></returns>
    public virtual float takeDamage(float damage)
    {
        Random.seed = netGameManager._instance.getRandomSeed();
        float healthTaken = 0;

        //if a random number between 0 and 100 is less than the dodge chanche dont take damage.
        if (!(Random.Range(0, 100) < (int)(Dodge * (Endurance / fullEndurance))))
        {
            //endurance takes full amount of damage not depending on defense.
            Endurance -= damage + (damage * Random.Range(-0.02f, 0.02f));
            //health damage gets reduced based on defense from endurance remaining.
            healthTaken = damage - (damage * ((Defense * 0.01f) * (Endurance / fullEndurance))) + (damage * Random.Range(-0.02f, 0.02f));
            Health -= healthTaken;
        }

        netGameManager._instance.iterateSeed((int)healthTaken);
        return healthTaken;
    }

    //getters and setters
    //
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

    public float getSpeed()
    {
        return Speed;
    }

    public void setTurnAction(int i)
    {
        turnAction = i;
    }

    public void setPlayerID(int ID)
    {
        playerID = ID;
    }
}
