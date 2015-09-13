using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class ToggleController : MonoBehaviour
{
    private int toggleCount; //the amount of toggles that are active.
    private List<ToggleButton> toggleButtons; //the toggles that are active

    //adds a toggle to the toggleButtons list.
    public void addToggle(ToggleButton iTB)
    {
        toggleButtons.Add(iTB); 
    }

    //removes a toggle to the toggleButtons list.
    public void removeToggle(ToggleButton iTB)
    {
        toggleButtons.Remove(iTB);
    }

    void Start()
    {
        toggleCount = 0;
        toggleButtons = new List<ToggleButton>();
    }

    //increases the toggleCount
    public void toggleUp()
    {
        ++toggleCount;
    }

    //decreases the toggleCount
    public void toggleDown()
    {
        --toggleCount;
    }

    //Getters and setters
    public int getToggleCount()
    {
        return toggleCount;
    }

    //this bit of code is unused but was difficult to program the first time so it is here simply for documentation purpose.

    //this is a mess that I will attempt to explain.
    //first to understand, toggles call this method every time it's value changes.
    //so the first two toggles pushed act normal, if you push it it activates and increments togglecount.
    //and if you want to disable these two it will decrement togglecount and disable them as expected.

    //but if you push the third, which should not be selectable, it first disables the button, then flips its value back to false
    //which, makes the toggle call this method again, where it goes through and reenables the button, which causes the toggle to run
    // the method a third time. This run through goes and causes the block that decrements toggleCount to pass then end, which passes
    // the run back to the second method call which then ends, and goes back to the first call that increments toggleCount then ends,

    //To be honest this is just by best examination of it, I am unsure if this is how it actually works and there are holes in it
    // such as why toggleButton.enabled = false; doesn't cause the toggle to invoke it's methods again.
    //All I know is right now it works as expected and I don't completely understand why.
    //If somebody other than me is reading this in the future and figures out what the heck it's doing, please email 
    // your findings to matthew.t.kides@gmail.com, I would love to know what my problem was.
    //public void checkCount()
    //{
    //    if(!toggleButton.enabled)
    //        toggleButton.enabled = true;
    //    else if (toggleCount > 1 && toggleButton.isOn)
    //    {
    //        toggleButton.enabled = false;
    //        toggleButton.isOn = false;
    //        toggleUp();
    //    } 
    //    else if (!toggleButton.isOn && toggleCount < 3)
    //        toggleDown();
    //    else if (toggleButton.isOn)
    //        toggleUp();
    //}
}