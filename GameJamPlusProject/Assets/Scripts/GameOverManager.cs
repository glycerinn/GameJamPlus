using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameOverManager: MonoBehaviour
{
    public Sprite[] GameOverimgs;
    public Image GOscreen;
    public BackgroundSwitcher backgroundSwitcher;
    public PlayerScript player;
 
    void Start()
    {

    }

    void Update()
    {
        int bg = backgroundSwitcher.currentBGindex;
        if (bg == 0 || bg == 1)
        {
            GOscreen.sprite = GameOverimgs[0];
        }else if (bg == 2 || bg == 4)
        {
            GOscreen.sprite = GameOverimgs[1];
        }else if (bg == 3)
        {
            GOscreen.sprite = GameOverimgs[2];
        }
        
        if(bg == 5 && player.score > 600)
        {
            GOscreen.sprite = GameOverimgs[3];
        }else if(bg == 5 && player.score < 700)
        {
            GOscreen.sprite = GameOverimgs[0];
        }

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
