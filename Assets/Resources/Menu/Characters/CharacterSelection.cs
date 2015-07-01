using UnityEngine;
using System.Collections;

public class CharacterSelection : MonoBehaviour
{
    public bool isActive; //whether or not this character is highlighted or not.
    public int index;

    CharacterSelector selector;
    SpriteRenderer thisRenderer;

    // Use this for initialization
    void Start()
    {
        selector = FindObjectOfType<CharacterSelector>();
        thisRenderer =  GetComponent<SpriteRenderer>();
        index = 0;
    }

    public void moveRight()
    {
        if (isActive)
        {
            transform.localScale = new Vector3(74, 74, 0);
            thisRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(40, 40, 0);
            thisRenderer.color = new Color(0.8f, 0.8f, 0.8f, 1.0f);
        }
        transform.position = new Vector3(transform.position.x + 3.039f, transform.position.y, transform.position.z);

        if(selector.currentLocation > index + 2 || selector.currentLocation < index - 2)
            thisRenderer.color = new Color(thisRenderer.color.r, thisRenderer.color.g, thisRenderer.color.b, 0.0f);
        else
            thisRenderer.color = new Color(thisRenderer.color.r, thisRenderer.color.g, thisRenderer.color.b, 1.0f);
    }

    public void moveLeft()
    {
        if (isActive)
        {
            transform.localScale = new Vector3(74, 74, 0);
            thisRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(40, 40, 0);
            thisRenderer.color = new Color(0.8f, 0.8f, 0.8f, 1.0f);
        }
        transform.position = new Vector3(transform.position.x - 3.039f, transform.position.y, transform.position.z);

        if(selector.currentLocation > index + 2 || selector.currentLocation < index - 2)
            thisRenderer.color = new Color(thisRenderer.color.r, thisRenderer.color.g, thisRenderer.color.b, 0.0f);
        else
            thisRenderer.color = new Color(thisRenderer.color.r, thisRenderer.color.g, thisRenderer.color.b, 1.0f);
    }
}
