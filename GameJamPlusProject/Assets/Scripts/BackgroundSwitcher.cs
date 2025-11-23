using UnityEngine;

public class BackgroundSwitcher : MonoBehaviour
{
    public SpriteRenderer backgroundRenderer;
    public Sprite[] backgroundSprites;   // <-- USE SPRITES, NOT TEXTURES
    public int[] scoreThresholds;
    public PlayerScript playerScript;
    public int currentBGindex = 0;
    private int currentIndex = 0;

    void Update()
    {
        float score = playerScript.score;

        if (currentIndex < scoreThresholds.Length &&
            score >= scoreThresholds[currentIndex])
        {
            backgroundRenderer.sprite = backgroundSprites[currentIndex];
            currentIndex++;
            currentBGindex = currentIndex;
        }
    }
}
