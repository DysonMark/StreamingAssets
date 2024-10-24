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
    private int health = 100;
    private int n2;
    void Start()
    {
        savePath = Application.streamingAssetsPath + "/PlayerData.json";
        userData = new UserData();
        userData.health.ToString();
        userData.mana.ToString();
        userData.health.ToString();
        userData.position.ToString();
        //userData.health = "100";
        //int.TryParse(userData.health, out health);
        //userData.name = "Goku";
        //userData.mana = " " + 1000;
        //int.Parse(userData.mana);
        //userData.position = " " + new Vector3(10, 0, 10);
        //int.Parse(userData.position);
        Debug.Log("parsing : " + userData.health);
        if (Object.ReferenceEquals(health.GetType(), n2.GetType()))
        {
            Debug.Log("Parsing works");
        }
        //Debug.Log("parsing : " + userData.health + userData.name + userData.position);
    }

    public void SavePlayerData()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            string savePlayer = JsonUtility.ToJson(userData);
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
