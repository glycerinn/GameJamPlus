using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Options options;
   
    void Start()
    {
       if (PlayerPrefs.HasKey("MasterVolume"))
        {
            options.loadVolume();
        }
        else
        {
            options.setMasterVolume();
            options.setMusicVolume();
            options.setSFXVolume();
        }
    }


    public void OpenSettings()
    {
        options.SetUp();
    }


    public void QuitGame()
    {
        Application.Quit();
    }

}

