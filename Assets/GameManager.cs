using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : Singleton<GameManager>
{
    public string playerName;
    public int health;
    public int xp;
    public int score;
    public int coins;
    public int lives;

    private void Awake()
    {
        Debug.Log("switched scene to persistent scene");
        SceneManager.LoadScene("PersistentScene", LoadSceneMode.Additive);
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
        data.playerName = playerName;
        data.health = health;
        data.xp = xp;
        data.score = score;
        data.coins = coins;
        data.lives = lives;

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
            playerName = data.playerName;
            health = data.health;
            xp = data.xp;
            score = data.score;
            coins = data.coins;
            lives = data.lives;

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

