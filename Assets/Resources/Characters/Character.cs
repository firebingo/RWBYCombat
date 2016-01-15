using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour
{
    int playerID; //ID of the player using this character.
    int characterID; //ID of the character for charcter selection.
        
    //Character stats
    float Health; //self-explained
    float Defense; //value from 0-100 to denote a percentage.
    float Melee; //value from 0-100 to denote a percentage.
    float Ranged; //value from 0-100 to denote a percentage.
    float Spirit; //value from 0-100 to denote a percentage.
    float Endurance; //the current aura count of the character.
    float pastEndurance; //
    float fullEndurance; //stores the initial value of endurance.
    float Dodge; //value from 0-100 to denote a percentage.
    float Speed; //the speed of the character

    bool Stance; //0 is melee, 1 is ranged.
    int turnAction; //the action to do this turn.

    // Use this for initialization
    protected abstract void Start();
    
    // Update is called once per frame
    protected abstract void Update();

    public abstract void runTurn();

    void updateStats()
    {
        //floor endurance at 0
        if (Endurance < 0)
            Endurance = 0;

        //Endurance regeneration
        Endurance += fullEndurance * (Spirit * 0.01f);

        if (pastEndurance != Endurance)
        {
            pastEndurance = Endurance;
            float auraRemaining = Endurance / fullEndurance;
            if (auraRemaining < 0.2f)
                auraRemaining = 0.2f;

            Defense = Defense * auraRemaining;
            Dodge = Dodge * auraRemaining;
            Speed = Speed * auraRemaining;
        }
    }

    protected void setInitialEndurance()
    {
        fullEndurance = Endurance;
    }

    protected abstract void passiveSemblence();

    public abstract void activeSemblence();

    public void takeDamage(float damage)
    {
        if (Endurance > 0)
            Endurance -= damage - (damage * Defense);
        else
            Health -= damage - (damage * Defense);
    }

    //getters and setters
    //
    public void setTurnAction(int i)
    {
        turnAction = i;
    }
}
