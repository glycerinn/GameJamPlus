using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] bool grounded = false;
    [SerializeField] bool Alive = true;
    Rigidbody2D myRb;
    public float jumpForce;
    float score;
    public TextMeshProUGUI ScoreTXT;
    public GameOverManager gameOverManager;

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(grounded == true)
            {
                myRb.AddForce(Vector2.up * jumpForce);
                grounded = false;
            }    
        }

        if (Alive)
        {
            score += Time.deltaTime * 4;
            ScoreTXT.text = "Score: " + score.ToString("F");
        }
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if(grounded == false)
            {
                grounded = true;
            }
        }

        if (collision.gameObject.CompareTag("obstacle"))
        {
            Alive = false;
            Time.timeScale = 0;
            gameOverManager.SetUp();
        }
    }

}
