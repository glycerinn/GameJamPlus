using UnityEngine;
using UnityEngine.UIElements;

public class Chaser : MonoBehaviour
{
    public RuntimeAnimatorController[] Animators;
    public BackgroundSwitcher backgroundSwitcher;
    public Animator animator;

    void Start()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        int bg = backgroundSwitcher.currentBGindex;
        if(bg==0 || bg == 1 || bg == 5)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            animator.runtimeAnimatorController = Animators[0];
        }else if( bg == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            animator.runtimeAnimatorController = Animators[1];
        }
        else if(bg == 2|| bg==4)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
