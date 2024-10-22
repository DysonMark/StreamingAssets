using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AssetBundles : MonoBehaviour
{
    private string folderPath = "AssetBundles";

    private string fileName = "obstacle";

    private string combinedPath;

    private AssetBundle obstacle;

    // Start is called before the first frame update
    void Start()
    {
      LoadAssetBundle();
      LoadObstacle();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadObstacle()
    {
        if (obstacle == null)
            return;
        GameObject square = obstacle.LoadAsset<GameObject>("Square");
        if (square != null)
            Instantiate(square);
    }
    void LoadAssetBundle()
    {
        combinedPath = Path.Combine(Application.streamingAssetsPath, folderPath, fileName);
        if (File.Exists(combinedPath))
        {
            obstacle = AssetBundle.LoadFromFile(combinedPath);
            Debug.Log("Asset bundle Loaded");
        }
        else
        {
            Debug.Log("No file " + combinedPath);
        }  
    }

}
