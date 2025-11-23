using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioMixer Audio;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider SFXSlider;

    void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            loadVolume();
        }
        else
        {
            setMasterVolume();
        }
       
    }

    public void SetUp()
    {
        gameObject.SetActive(true);
    }

    public void setMasterVolume()
    {
        float volume = masterSlider.value;
        Audio.SetFloat("Master", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void loadVolume()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        setMasterVolume();
    }

    public void LoadMenu()
    {
        gameObject.SetActive(false);
    }
}

