using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.IO;
public class FileManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path = Application.persistentDataPath;
        string streamingAssetsPath = Application.streamingAssetsPath;
        Debug.Log(Application.dataPath);
        //Check if streaming asset file exits and if not create it
        if (Directory.Exists(streamingAssetsPath))
            Debug.Log("Streaming Assets Path: " + streamingAssetsPath);
        else
            Directory.CreateDirectory(Path.Combine(Application.dataPath, "StreamingAssets"));
        //Checks if folder exists
        if (Directory.Exists(path))
            Debug.Log("Path to root folder: " + path);
        else
            Debug.Log("Path don't exist");
        /*
        if (File.Exists(Path.Combine(streamingAssetsPath, "newfile.txt")))
                Debug.Log("new text file created");
        else
            Debug.Log("streaming asset doesn't exist");*/
    }
}
