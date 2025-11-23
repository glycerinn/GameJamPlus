using System.CodeDom.Compiler;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstacle;
    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;
    public float speedMultiplier;
    public float startDelay;
    public BackgroundSwitcher backgroundSwitcher;
    public static float globalCooldownEnd = 0f;
    public float spawnCooldown = 0.25f;
    private float nextSpawnTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentSpeed = MinSpeed;
        if (startDelay > 0f)
            {
                Invoke("generateObstacle", startDelay);
            }
            else
            {
                generateObstacle();
            }
            }

    public void generateWithGap()
    {
        float randomWait = Random.Range(0.1f, 0.3f);
        Invoke(nameof(generateObstacle), randomWait);
    }

    public void generateObstacle()
    {
        if (Time.time < globalCooldownEnd)
        {
            float retryDelay = 0.05f;
            Invoke(nameof(generateObstacle), retryDelay);
            return;
        }

   
        globalCooldownEnd = Time.time + spawnCooldown;

        if (Random.value < 0.90f)
        {
            float randomWait = Random.Range(0f, 0.1f);
            Invoke(nameof(generateObstacle), randomWait);
            return;
        }

        int bg = backgroundSwitcher.currentBGindex;
        GameObject prefab;

        if (bg == 0 || bg == 1 || bg == 5)
            prefab = obstacle[0];
        else if (bg == 2 || bg == 4)
            prefab = obstacle[1];
        else
            prefab = obstacle[2];

        GameObject obstacleIns = Instantiate(prefab, transform.position, transform.rotation);
        obstacleIns.GetComponent<ObstacleScript>().obstacleGenerator = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSpeed < MaxSpeed)
        {
            currentSpeed += speedMultiplier;
        }

         if (Time.time >= nextSpawnTime)
        {
            generateObstacle();
            nextSpawnTime = Time.time + Random.Range(0.3f, 0.6f); // adjust to taste
        }   
    }
}
