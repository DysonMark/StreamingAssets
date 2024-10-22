using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadTexture : MonoBehaviour
{
    public string fileName = "penguin.jpeg";

    public string folderPath = Application.streamingAssetsPath;

    private string combinedPath;
    // Start is called before the first frame update
    void Start()
    {
        combinedPath = Path.Combine(folderPath, fileName);
        
        Load();
    }

    private void Load()
    {
        if (File.Exists(combinedPath))
        {
            byte[] imageBytes = File.ReadAllBytes(combinedPath);

            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageBytes);

            GetComponent<Renderer>().material.mainTexture = texture;
        }
        else
        {
            Debug.Log("Texture File not found at path " + combinedPath);
        }
    }
}
