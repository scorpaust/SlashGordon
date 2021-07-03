using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerPool : MonoBehaviour
{
    [SerializeField]
    private GameObject spikePrefab, swingingObstaclePrefab, wolfPrefab;

    [SerializeField]
    private GameObject rotatingObstaclePrefab_1, rotatingObstaclePrefab_2, rotatingObstaclePrefab_3;

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

    [SerializeField]
    private int initialObstaclesToSpawn = 10;

    private float spawnWaitTime;

    private int obstacleTypeCount = 4;

    private int obstacleToSpawn;

    private Camera mainCam;

    private Vector3 obstacleSpawnPos = Vector2.zero;

    private GameObject newObstacle;

    private List<GameObject> spikePool = new List<GameObject>();

    private List<GameObject> swingingObstaclePool = new List<GameObject>();

    private List<GameObject> rotatingObstaclePool = new List<GameObject>();

    private List<GameObject> wolfPool = new List<GameObject>();

    private void Awake()
    {
        mainCam = Camera.main;

        InitializeObstacles();
    }

	private void Update()
	{
        HandleObstacleSpawning();
	}

	private void InitializeObstacles()
	{
        for (int i = 0; i < 6; i++)
		{
            SpawnInitialObstacles(i);
		}
	}

    private void  SpawnInitialObstacles(int obstacleType)
	{
        switch(obstacleType)
		{
            case 0:
                for (int i = 0; i < initialObstaclesToSpawn; i++)
				{
                    newObstacle = Instantiate(spikePrefab);

                    newObstacle.transform.SetParent(transform);

                    spikePool.Add(newObstacle);

                    newObstacle.SetActive(false);
				}
                break;
            case 1:
                for (int i = 0; i < initialObstaclesToSpawn; i++)
                {
                    newObstacle = Instantiate(swingingObstaclePrefab);

                    newObstacle.transform.SetParent(transform);

                    swingingObstaclePool.Add(newObstacle);

                    newObstacle.SetActive(false);
                }
                break;
            case 2:
                for (int i = 0; i < initialObstaclesToSpawn; i++)
                {
                    newObstacle = Instantiate(wolfPrefab);

                    newObstacle.transform.SetParent(transform);

                    wolfPool.Add(newObstacle);

                    newObstacle.SetActive(false);
                }
                break;
            case 3:
                for (int i = 0; i < initialObstaclesToSpawn; i++)
                {
                    newObstacle = Instantiate(rotatingObstaclePrefab_1);

                    newObstacle.transform.SetParent(transform);

                    rotatingObstaclePool.Add(newObstacle);

                    newObstacle.SetActive(false);
                }
                break;
            case 4:
                for (int i = 0; i < initialObstaclesToSpawn; i++)
                {
                    newObstacle = Instantiate(rotatingObstaclePrefab_2);

                    newObstacle.transform.SetParent(transform);

                    rotatingObstaclePool.Add(newObstacle);

                    newObstacle.SetActive(false);
                }
                break;
            case 5:
                for (int i = 0; i < initialObstaclesToSpawn; i++)
                {
                    newObstacle = Instantiate(rotatingObstaclePrefab_3);

                    newObstacle.transform.SetParent(transform);

                    rotatingObstaclePool.Add(newObstacle);

                    newObstacle.SetActive(false);
                }
                break;
        }
	}

    private void SpawnObstacleInGame()
	{
        obstacleToSpawn = Random.Range(0, obstacleTypeCount);

        obstacleSpawnPos.x = mainCam.transform.position.x + 20f;

        switch (obstacleToSpawn)
        {
            case 0:
                for (int i = 0; i < spikePool.Count; i++)
				{
                    if (!spikePool[i].activeInHierarchy)
					{
                        spikePool[i].SetActive(true);

                        obstacleSpawnPos.y = spikeYPos;

                        newObstacle = spikePool[i];
                        
                        break;
                    }
                        
				}
                break;
            case 1:
                for (int i = 0; i < swingingObstaclePool.Count; i++)
                {
                    if (!swingingObstaclePool[i].activeInHierarchy)
                    {
                        swingingObstaclePool[i].SetActive(true);

                        obstacleSpawnPos.y = Random.Range(swingObstacleMinY, swingObstacleMaxY);

                        newObstacle = swingingObstaclePool[i];

                        break;
                    }

                }
                break;
            case 2:
                for (int i = 0; i < wolfPool.Count; i++)
                {
                    if (!wolfPool[i].activeInHierarchy)
                    {
                        wolfPool[i].SetActive(true);

                        obstacleSpawnPos.y = wolfYPos;

                        newObstacle = wolfPool[i];

                        break;
                    }

                }
                break;
            case 3:
                bool notActiveFound = true;

                while (notActiveFound)
				{
                    int randElement = Random.Range(0, rotatingObstaclePool.Count);

                    if (!rotatingObstaclePool[randElement].activeInHierarchy)
					{
                        rotatingObstaclePool[randElement].SetActive(true);

                        obstacleSpawnPos.y = Random.Range(rotatingObstacleMinY, rotatingObstacleMaxY);

                        newObstacle = rotatingObstaclePool[randElement];

                        notActiveFound = false;
                    }
				}
                break;
        }

        newObstacle.transform.position = obstacleSpawnPos;
    }

    private void HandleObstacleSpawning()
	{
        if (Time.time > spawnWaitTime)
        {
            spawnWaitTime = Time.time + Random.Range(minSpawnWaitTime, maxSpawnWaitTime);

            SpawnObstacleInGame();
        }
    }
}
