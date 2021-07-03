using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spikePrefab, swingingObstaclePrefab, wolfPrefab;

    [SerializeField]
    private GameObject[] rotatingObstaclesPrefabs;

    [SerializeField]
    private float spikeYPos = -3.5f;

    [SerializeField]
    private float wolfYPos = -3.1f;

    [SerializeField]
    private float rotatingObstacleMinY = -3.3f, rotatingObstacleMaxY = -0.6f;

    [SerializeField]
    private float swingObstacleMinY = 0.7f, swingObstacleMaxY = 3f;

    [SerializeField]
    private float minSpawnWaitTime = 2f, maxSpawnWaitTime = 3.5f;

    private float spawnWaitTime;

    private int obstacleTypeCount = 4;

    private int obstacleToSpawn;

    private Camera mainCam;

    private Vector3 obstacleSpawnPos = Vector2.zero;

    private GameObject newObstacle;

	private void Awake()
	{
        mainCam = Camera.main;
	}

	private void Update()
	{
        HandleObstacleSpawning();
	}

    private void HandleObstacleSpawning()
	{
        if (Time.time > spawnWaitTime)
		{
            spawnWaitTime = Time.time + Random.Range(minSpawnWaitTime, maxSpawnWaitTime);

            SpawnObstacle();
		}
	}

    private void SpawnObstacle()
	{
        obstacleToSpawn = Random.Range(0, obstacleTypeCount);

        obstacleSpawnPos.x = mainCam.transform.position.x + 20f;

        switch(obstacleToSpawn)
		{
            case 0:
                newObstacle = Instantiate(spikePrefab);
                obstacleSpawnPos.y = spikeYPos;
                break;
            case 1:
                newObstacle = Instantiate(swingingObstaclePrefab);
                obstacleSpawnPos.y = Random.Range(swingObstacleMinY, swingObstacleMaxY);
                break;
            case 2:
                newObstacle = Instantiate(wolfPrefab);
                obstacleSpawnPos.y = wolfYPos;
                break;
            case 3:
                newObstacle = Instantiate(rotatingObstaclesPrefabs[Random.Range(0, rotatingObstaclesPrefabs.Length)]);
                obstacleSpawnPos.y = Random.Range(rotatingObstacleMinY, rotatingObstacleMaxY);
                break;
        }

        newObstacle.transform.position = obstacleSpawnPos;
	}
}
