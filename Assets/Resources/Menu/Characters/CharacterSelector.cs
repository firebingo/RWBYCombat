using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterSelector : MonoBehaviour
{
    public List<GameObject> characters; //the index of the characters in this list must match the character's ID in their script
    public int currentLocation; //the current index that is highlighted.
    public float time; //self-explained.

    void Start()
    {
        currentLocation = 0;
        //sets the index variable of all the characters in the list.
        for (int i = 0; i < characters.Count; ++i)
            characters [i].GetComponent<CharacterSelection>().index = i;
    }

    void Update()
    {
        if (time < 2.0f)
        {
            time += Time.deltaTime;
        }
        //controller input for selection
        if (Input.GetAxis("Dpad Horizontal") > 0)
        {
            moveRight();  
        }
        if (Input.GetAxis("Dpad Horizontal") < 0)
        {
            moveLeft();
        }
    }

    public void moveLeft()
    {
        if (currentLocation > 0 && time > 0.3f)
        {
            //sets the currently highlighted character to not be highlighted 
            characters [currentLocation].GetComponent<CharacterSelection>().isActive = false;
            characters [currentLocation].GetComponent<SpriteRenderer>().sortingOrder = 1;
            characters [currentLocation].transform.position = new Vector3(characters [currentLocation].transform.position.x, -3.0f, 22.056f);
            currentLocation--;
            //highlights the next character.
            characters [currentLocation].GetComponent<CharacterSelection>().isActive = true;
            characters [currentLocation].GetComponent<SpriteRenderer>().sortingOrder = 2;
            characters [currentLocation].transform.position = new Vector3(characters [currentLocation].transform.position.x, -0.798f, 22.056f);
            //moves all the characters to their right
            //hitting left makes the selection move left but all characters move right 
            for (int i = 0; i < characters.Count; ++i)
            {
                characters [i].GetComponent<CharacterSelection>().moveRight();
            }
            time = 0.0f;
        }
    }

    public void moveRight()
    {
        if (currentLocation < characters.Count - 1 && time > 0.3f)
        {
            //sets the currently highlighted character to not be highlighted 
            characters [currentLocation].GetComponent<CharacterSelection>().isActive = false;
            characters [currentLocation].GetComponent<SpriteRenderer>().sortingOrder = 1;
            characters [currentLocation].transform.position = new Vector3(characters [currentLocation].transform.position.x, -3.0f, 22.056f);
            currentLocation++;
            //highlights the next character.
            characters [currentLocation].GetComponent<CharacterSelection>().isActive = true;
            characters [currentLocation].GetComponent<SpriteRenderer>().sortingOrder = 2;
            characters [currentLocation].transform.position = new Vector3(characters [currentLocation].transform.position.x, -0.798f, 22.056f);
            //moves all the characters to their left
            //hitting left makes the selection move right but all characters move left 
            for (int i = 0; i < characters.Count; ++i)
            {
                characters [i].GetComponent<CharacterSelection>().moveLeft();
            }
            time = 0.0f;
        }
    }

    //sets the character selection id in the GameManager to be the selected character.
    public void setCharacter()
    {
        GameManager._instance.characterID = currentLocation;
    }
}
