using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadAudio : MonoBehaviour
{
    public string fileName = "darksouls.wav";
    public string folderName = "Sounds";
    public string combinedFilePath;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip epicClip;

    void Start()
    {
        combinedFilePath = Path.Combine(Application.streamingAssetsPath, folderName, fileName);
        Debug.Log(combinedFilePath);
        LoadSoundFromFile();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("here");
            PlaySound();
        }
    }

    void LoadSoundFromFile()
    {
        if (File.Exists(combinedFilePath))
        {
            //store data in this array
            byte[] audioData = File.ReadAllBytes(combinedFilePath);
            
            //convert the byte array into a float, we divide by two because its 2 bits to a byte
            float[] floatArray = new float[audioData.Length / 2];

            // loop over the array
            for (int i = 0; i < floatArray.Length; i++)
            {
                //convert the audio data to a 16bit int, and move the offset by two each time
                short bitValue = System.BitConverter.ToInt16(audioData, i * 2);
                
                //then normalise the current value between -1, 1 with 32768 being the max value
                floatArray[i] = bitValue / 32768.0f;
            }
            // call the create function
            epicClip = AudioClip.Create("epicClip", floatArray.Length, 1, 44100, false);
            
            //set the audio data

            epicClip.SetData(floatArray, 0);
            Debug.Log(" sound loading work");
        }
        else
        {
            Debug.Log("No file found " + combinedFilePath);
        }
    }

    void PlaySound()
    {
        if (audioSource == null || epicClip == null)
        {
            return;
        } 
        audioSource.PlayOneShot(epicClip);
    }
}
