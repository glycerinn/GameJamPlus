using System.CodeDom.Compiler;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstacle;
    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;
    public float speedMultiplier;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentSpeed = MinSpeed;
        generateObstacle();
    }

    public void generateWithGap()
    {
        float randomWait = Random.Range(0.1f, 0.2f);
        Invoke("generateObstacle", randomWait);
    }

    public void generateObstacle()
    {
        GameObject ObstacleIns = Instantiate(obstacle[0], transform.position, transform.rotation);

        ObstacleIns.GetComponent<ObstacleScript>().obstacleGenerator = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSpeed < MaxSpeed)
        {
            currentSpeed += speedMultiplier;
        }
    }
}
