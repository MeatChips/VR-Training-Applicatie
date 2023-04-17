using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string SceneName;

    public AudioSource NormalButtonClick;
    public AudioSource PlayButtonClick;
 

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Quit()
    {
        Application.Quit();
        Console.WriteLine("BYE!!!");
    }

    public void PlayButtonAudio()
    {
        PlayButtonClick.Play();
    }

    public void NormalButtonAudio()
    {
        NormalButtonClick.Play();
    }
}
