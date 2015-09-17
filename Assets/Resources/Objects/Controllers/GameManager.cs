using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

//Currently this class does not have any specific functionatly other than creating a manager object and preventing more from being created.

//The purpose of this as a class though is that it can basically store global information that can be accessed and will
//stay persistant while the application is running, even through scene transitions. This can also be extended as a way 
//to save/load the game between restarts of the application.

public class GameManager : MonoBehaviour
{
	public static GameManager _instance;
    public static CNetworkManager _networkInstance;
	 
	//start variables
	public int playerID; //the ID of the client. Defaults to 0 which should be host id.
    public int characterID; //the ID of the character the client has selected.
    public string playerName;

	float time;
	//end variables

    //Options Variables
    public int Port;
    public bool VSync;
    public int wWidth;
    public int wHeight;
    public bool isFullscreen;
    public float Volume;
    public bool refreshQuality;

    void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(this.gameObject);
        }

        if (!_networkInstance)
            _networkInstance = FindObjectOfType<CNetworkManager>();

        if (loadOptions())
            refreshQuality = true;
        else
        {
            Port = 25561;
            VSync = false;
            wWidth = Screen.width;
            wHeight = Screen.height;
            Volume = 1.0f;
        }

        saveOptions();
    }

	void Start()
	{
		time = 0;
		playerID = 0;
        characterID = 0;
        playerName = "\"Good Name\"";
    }

	void Update()
	{
		time += Time.deltaTime;

        if (refreshQuality)
        {
            updateQuality();
        }
    }

    public void gloadLevel(string iName)
    {
        if (NetworkManager.singleton.isNetworkActive)
            CNetworkManager._instance.gLoadNetLevel(iName);
        else
            Application.LoadLevel(iName);
    }

    public void setPlayerName(Text iName)
    {
        if (iName.text == "")
            playerName = "\"Good Name\"";
        else
            playerName = iName.text;
    }

    public void updateQuality()
    {
        if (VSync)
            QualitySettings.vSyncCount = 1;
        else
            QualitySettings.vSyncCount = 0;

        if (isFullscreen)
            Screen.SetResolution(wWidth, wHeight, true);
        else
            Screen.SetResolution(wWidth, wHeight, false);

        AudioListener.volume = Volume;

        saveOptions();
        refreshQuality = false;
    }

    //saves the game options to a file.
    private void saveOptions()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.dataPath + "/gameOptions.wort", FileMode.OpenOrCreate);

        GameOptions options = new GameOptions(Port, VSync, wWidth, wHeight, isFullscreen, Volume);

        bf.Serialize(file, options);
        file.Close();
    }

    //loads the game options from a file if it exists.
    private bool loadOptions()
    {
        if (File.Exists(Application.dataPath + "/gameOptions.wort"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/gameOptions.wort", FileMode.Open);
            GameOptions options = bf.Deserialize(file) as GameOptions;
            file.Close();

            Port = options.Port;
            VSync = options.VSync;
            wWidth = options.wWidth;
            wHeight = options.wHeight;
            isFullscreen = options.isFullscreen;
            Volume = options.Volume;
            
            return true;
        }
        else
            return false;
    }
}

//class for storing the game options.
[Serializable]
class GameOptions
{
    public GameOptions(int iPort, bool iVSync, int iWWidth, int iWHeight, bool iIsFullscreen, float iVolume)
    {
        Port = iPort;
        VSync = iVSync;
        wWidth = iWWidth;
        wHeight = iWHeight;
        Volume = iVolume;
    }

    //Options
    public int Port;
    public bool VSync;
    public int wWidth;
    public int wHeight;
    public bool isFullscreen;
    public float Volume;
}