using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager: MonoBehaviour
{
 
    void Start()
    {

    }

    public void SetUp()
    {
        gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void BacktoMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");
    }

}
