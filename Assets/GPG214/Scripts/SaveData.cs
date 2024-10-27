using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using System.IO;
using File = System.IO.File;
using Input = UnityEngine.Input;

//using Input = UnityEngine.Windows.Input;

//using File = UnityEngine.Windows.File;

public class SaveData : MonoBehaviour
{
    // Start is called before the first frame update

    private UserData userData;
    private string savePath;

    string health;

    string mana;

    string position;
    //private int health = 100;
    //private int n2;
    void Start()
    {
        savePath = Application.streamingAssetsPath + "/PlayerData.json";
        userData = new UserData();
        health = userData.health.ToString();
        mana = userData.mana.ToString();
        position = userData.position.ToString();
        var name = userData.name;
        if (userData.health.ToString() == "100")
        {
            Debug.Log("Parsing works");
        }
    }

    public void SavePlayerData()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            string savePlayer = JsonUtility.ToJson(health + mana + position + name);
            File.WriteAllText(savePath, savePlayer);
            Debug.Log("Save file has been created at " + savePath);
        }
    }

    public void LoadGame()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (File.Exists(savePath))
            {
                string loadPlayer = File.ReadAllText(savePath);
                userData = JsonUtility.FromJson<UserData>(loadPlayer);
                Debug.Log("Game has been saved");
            }
            else
            {
                Debug.Log("File doesn't exist");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        SavePlayerData();
        LoadGame();
    }
}
