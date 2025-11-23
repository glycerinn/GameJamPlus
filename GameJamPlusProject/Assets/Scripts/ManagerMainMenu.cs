using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Options options;
    public TextMeshProUGUI MyHighScore;
    public float HighScore;
   
    void Start()
    {
        HighScore = PlayerPrefs.GetFloat("HighScore", 0);
       if (PlayerPrefs.HasKey("MasterVolume"))
        {
            options.loadVolume();
        }
        else
        {
            options.setMasterVolume();
        }

        MyHighScore.text = "HighScore: " + HighScore.ToString("F");
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

