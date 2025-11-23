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
    public float spawnInterval = 3f; // spawn every second

    private void Start()
    {
        currentSpeed = MinSpeed;
        StartCoroutine(SpawnLoop());
    }

    private System.Collections.IEnumerator SpawnLoop()
    {
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            generateObstacle();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void generateObstacle()
    {
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
    }
}
