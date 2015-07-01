using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Currently this class does not have any specific functionatly other than creating a manager object and preventing more from being created.

//The purpose of this as a class though is that it can basically store global information that can be accessed and will
//stay persistant while the application is running, even through scene transitions. This can also be extended as a way 
//to save/load the game between restarts of the application.

public class GameManager : MonoBehaviour
{
	static GameManager _instance;
	 
	//start variables
	int playerID; //the ID of the client. Defaults to 0 which should be host id.
    public int characterID; //the ID of the character the client ahs selected.
    string playerName;

	float time;
	//end variables

	//returns true if the AI manager exists.
	static public bool isActive
	{
		get
		{
			return _instance != null;
		}
	}

	//creates the manager when this is first called, and sets it so it won't be destroyed on level transitions.
	//if a ai manager already exists it just returns the existing manager to prevent more than 1 being created.
	static public GameManager instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType(typeof(GameManager)) as GameManager;

				if (_instance == null)
				{
					GameObject go = new GameObject("_GameManager");
					DontDestroyOnLoad(go);
					_instance = go.AddComponent<GameManager>();
				}
			}
			return _instance;
		}
	}

	void Start()
	{
		time = 0;
		playerID = 0;
	}

	void Update()
	{
		time += Time.deltaTime;
	}

    public void setPlayerName(Text iName)
    {
        if(iName.text.ToString() == "")
            playerName = "Good Name";
        else
            playerName = iName.text.ToString();
    }
}