using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : Singleton<GameManager>
{
    private string playerName;
    private int health;
    private int xp;
    private int score;
    private int coins;
    private int lives;

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

    
    private void Start()
    {
        /*
        if (!SceneManager.GetSceneByName("PersistentScene").isLoaded)
        {
            Debug.Log("Loading scene to persistent scene");
            SceneManager.LoadScene("PersistentScene", LoadSceneMode.Additive);
        }
        */
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
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.dat");

        PlayerData data = new PlayerData();
        data.playerName = PlayerName;
        data.health = Health;
        data.xp = Xp;
        data.score = Score;
        data.coins = Coins;
        data.lives = Lives;

        // Takes the data and applies it to the new file 
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadSave()
    {
        string path = Application.persistentDataPath + "/playerinfo.dat";
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);

            // Storing my data | casting my data into a playerdata object | copy the data also
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
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
}
// This let the data made into a file
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

