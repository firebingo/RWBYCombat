﻿using UnityEngine;
using UnityEngine.UI;
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
    public static NetworkManager _networkInstance;
	 
	//start variables
	int playerID; //the ID of the client. Defaults to 0 which should be host id.
    public int characterID; //the ID of the character the client has selected.
    string playerName;

	float time;
	//end variables

    //Options Variables
    public short Port;
    public bool VSync;
    public int wWidth;
    public int wHeight;
    public bool isFullscreen;
    public float Volume;
    public bool AAEnabled;
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
            _networkInstance = FindObjectOfType<NetworkManager>();

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
	}

	void Update()
	{
		time += Time.deltaTime;

        if(refreshQuality)
        {
            updateQuality();
        }
	}

    public void setPlayerName(Text iName)
    {
        if(iName.text.ToString() == "")
            playerName = "Good Name";
        else
            playerName = iName.text.ToString();
    }

    public void updateQuality()
    {
        if (VSync)
            QualitySettings.vSyncCount = 1;
        else
            QualitySettings.vSyncCount = 0;

        if(AAEnabled)
            QualitySettings.antiAliasing = 4;
        else
            QualitySettings.antiAliasing = 0;

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
        FileStream file = File.Open(Application.dataPath + "/gameOptions.ini", FileMode.OpenOrCreate);

        GameOptions options = new GameOptions(Port, VSync, wWidth, wHeight, isFullscreen, Volume, AAEnabled);

        bf.Serialize(file, options);
        file.Close();
    }

    //loads the game options from a file if it exists.
    private bool loadOptions()
    {
        if (File.Exists(Application.dataPath + "/gameOptions.ini"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/gameOptions.ini", FileMode.Open);
            GameOptions options = bf.Deserialize(file) as GameOptions;
            file.Close();

            Port = options.Port;
            VSync = options.VSync;
            wWidth = options.wWidth;
            wHeight = options.wHeight;
            isFullscreen = options.isFullscreen;
            Volume = options.Volume;
            AAEnabled = options.AAEnabled;
            
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
    public GameOptions(short iPort, bool iVSync, int iWWidth, int iWHeight, bool iIsFullscreen,float iVolume, bool iAAEnabled)
    {
        Port = iPort;
        VSync = iVSync;
        wWidth = iWWidth;
        wHeight = iWHeight;
        Volume = iVolume;
        AAEnabled = iAAEnabled;
    }

    //Options
    public short Port;
    public bool VSync;
    public int wWidth;
    public int wHeight;
    public bool isFullscreen;
    public float Volume;
    public bool AAEnabled;
}