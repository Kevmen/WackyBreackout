using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBall;

    Timer timerSpawn;
    ConfigurationData configuration;

    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;

    bool retrySpawn = false;

    public void Spawner()
    {
        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null)
        {
            retrySpawn = false;
            Instantiate(prefabBall);
        }
        else
        {
            retrySpawn = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefabBall);
        configuration = new ConfigurationData();
        timerSpawn = gameObject.AddComponent<Timer>();
        SpawnRandomTime();
        GameObject tempBall = Instantiate<GameObject>(prefabBall);
        BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
        float ballColliderHalfWidth = collider.size.x / 2;
        float ballColliderHalfHeight = collider.size.y / 2;
        spawnLocationMin = new Vector2(
            tempBall.transform.position.x - ballColliderHalfWidth,
            tempBall.transform.position.y - ballColliderHalfHeight);
        spawnLocationMax = new Vector2(
            tempBall.transform.position.x + ballColliderHalfWidth,
            tempBall.transform.position.y + ballColliderHalfHeight);
        Destroy(tempBall);
    }
    void SpawnRandomTime()
    {
        timerSpawn.Duration = Random.Range(configuration.MinSpawnTimer, configuration.MaxSpawnTimer);
        timerSpawn.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if ((retrySpawn && Camera.main != null) || (!timerSpawn.Running ) )
        {
            Spawner();
            if (!timerSpawn.Running)
            {
                SpawnRandomTime();
            }
        }

        //if (!timerSpawn.Running && Camera.main != null)
        //{
        //    Spawner();
        //    SpawnRandomTime();
        //}
    }
}
