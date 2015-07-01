using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleController : MonoBehaviour
{
    Toggle toggleButton;
    public int toggleCount;

    void Start()
    {
        toggleCount = 0;
    }

    public void toggleUp()
    {
        ++toggleCount;
    }

    public void toggleDown()
    {
        --toggleCount;
    }

    //this is a mess that I will attempt to explain.
    //first to understand, toggles calls this method everytime it's value changes.
    //so the first two toggles pushed act normal, if you push it it activates and incrments togglecount.
    //and if you want to disalbe these two it will decrement togglecount and disalbe them as expected.

    //but if you push the third, which should not be selectable, it first disables the bitton, then flips its value back to false
    //which, makes the toggle call this method again, where it goes through and renables the button, which causes the toggle to run
    // the method a third time. This run through goes and causes the block that decrements toggleCount to pass then end, which passes
    // the run back to the second method call which then ends, and goes back to the first call that increments toggleCount then ends,

    //To be honest this is just by best examinatiion of it, I am unsure if this is how it actually works and there are holes it it
    // such as why toggleButton.enabled = false; doesn't cause the toggle to invoke it's methods again.
    //All I know is right now it works as expected and I don't completly understand why.
    //If somebody other than me is reading this in the future and figures out what the heck it's doing, please email 
    // your findings to matthew.t.kides@gmail.com, I would love to know what my problem was.
    public void checkCount()
    {
        if(!toggleButton.enabled)
            toggleButton.enabled = true;
        else if (toggleCount > 1 && toggleButton.isOn)
        {
            toggleButton.enabled = false;
            toggleButton.isOn = false;
            toggleUp();
        } 
        else if (!toggleButton.isOn && toggleCount < 3)
            toggleDown();
        else if (toggleButton.isOn)
            toggleUp();
    }

    public void setButton(Toggle iButton)
    {
        toggleButton = iButton;
    }
}