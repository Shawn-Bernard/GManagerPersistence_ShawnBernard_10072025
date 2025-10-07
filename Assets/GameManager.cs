using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : Singleton<GameManager>
{


    public static int gameManagerCount;

    private string playerName;
    private int health;
    private int xp;
    private int score;
    private int coins;
    private int lives;

    private string playerInfoPath = "/playerinfo.data";

    public string PlayerName 
    {  
        get { return playerName; } 
        set { playerName = value; } 
    }
    public int Health 
    {
        get { return health; }
        set { health = Mathf.Max(0,value); }
    }
    public int Xp 
    {  
        get { return xp; }
        set { xp = Mathf.Max(0,value); }
    }
    public int Score 
    {  
        get { return score; }
        set { score = Mathf.Max(0, value); }
    }
    public int Coins 
    {  
        get { return coins; } 
        set { coins  = Mathf.Max(0, value); }
    }
    public int Lives 
    { 
        get { return lives; } 
        set { lives  = Mathf.Max(0, value); }
    }

    public int GetManagerCount()
    {
        return gameManagerCount;
    }

    private void OnDestroy()
    {
        gameManagerCount--;
    }

    private void Awake()
    {
        gameManagerCount++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current[Key.Digit1].wasPressedThisFrame)
        {
            Debug.Log("switched scene to menu");
            SceneManager.LoadScene(0);
        }
        if (Keyboard.current[Key.Digit2].wasPressedThisFrame)
        {
            Debug.Log("switched scene to level 1");
            SceneManager.LoadScene(1);
        }
        if (Keyboard.current[Key.Digit3].wasPressedThisFrame)
        {
            Debug.Log("switched scene to level 2");
            SceneManager.LoadScene(2);
        }
        if (Keyboard.current[Key.Digit4].wasPressedThisFrame)
        {
            Debug.Log("switched scene to level 3");
            SceneManager.LoadScene(3);
        }
        /*
        if (Keyboard.current[Key.S].wasPressedThisFrame)
        {
            Debug.Log("Saving game");
            SaveGame();
        }
        if (Keyboard.current[Key.L].wasPressedThisFrame)
        {
            Debug.Log("Loading game data");
            LoadSave();
        }
        */
    }

    public void SaveGame()
    {
        // Binary converter
        BinaryFormatter bf = new BinaryFormatter();

        // Crates a new file
        FileStream file = File.Create(Application.persistentDataPath + playerInfoPath);// playerInfoPath = "/playerinfo.data"

        PlayerData data = new PlayerData();
        // Saving my data 
        data.playerName = PlayerName;
        data.health = Health;
        data.xp = Xp;
        data.score = Score;
        data.coins = Coins;
        data.lives = Lives;

        // Takes the data and applies it to the new file 
        bf.Serialize(file, data);
        // Then closes the file
        file.Close();
    }

    public void LoadSave()
    {
        //Making a string with persistant data path + player info string path 
        string path = Application.persistentDataPath + playerInfoPath;

        //Checks to see if the file exists
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);

            // Storing my data | casting my data into a playerdata object | copy the data also
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            // Sets my loaded data into the real player data
            PlayerName = data.playerName;
            Health = data.health;
            Xp = data.xp;
            Score = data.score;
            Coins = data.coins;
            Lives = data.lives;

        }
        else
        {
            Debug.Log("Save file not found");
        }
        
    }

    public void ResetGame()
    {
        playerName = " ";
        Health = 0;
        Xp = 0;
        Score = 0;
        Coins = 0;
        Lives = 0;
    }
}

// This let the data made into a file/ makes it serializable
[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int health;
    public int xp;
    public int score;
    public int coins;
    public int lives;
}

