using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject groundPrefab, tree1Prefab, tree2Prefab;

    [SerializeField]
    private int groundsToSpawn = 5, treesToSpawn = 2;

    [SerializeField]
    private float groundYPos = -6f, treeYPos = -0.18f;

    [SerializeField]
    private float groundXDistance = 17.85f, treeXDistance = 41.2f;

    [SerializeField]
    private float generateLevelWaitTime = 3f;

    private float lastGroundXPos, lastTreeXPos;

    private float waitTimer;

	private void Update()
	{
        CheckToSpawnLevelParts();
	}

    private void CheckToSpawnLevelParts()
	{
        if (Time.time > waitTimer)
		{
            GenerateGrounds();

            GenerateTrees();

            waitTimer = Time.time + generateLevelWaitTime;
        }
	}

    private void GenerateGrounds()
	{
        Vector3 groundPosition = Vector3.zero;

        for (int i = 0; i < groundsToSpawn; i++)
		{
            groundPosition = new Vector3(lastGroundXPos, groundYPos, 0f);

            Instantiate(groundPrefab, groundPosition, Quaternion.identity).transform.SetParent(transform);

            lastGroundXPos += groundXDistance;
		}
	}

    private void GenerateTrees()
	{
        Vector3 treePos = Vector3.zero;

        for (int i = 0; i < treesToSpawn; i++)
		{
            treePos = new Vector3(lastTreeXPos, treeYPos, 0f);

            if (Random.Range(0, 2) > 0)
            {
                Instantiate(tree1Prefab, treePos, Quaternion.identity).transform.SetParent(transform);

                Instantiate(tree2Prefab, treePos, Quaternion.identity).transform.SetParent(transform);
            }
            else
			{
                Instantiate(tree2Prefab, treePos, Quaternion.identity).transform.SetParent(transform);

                Instantiate(tree1Prefab, treePos, Quaternion.identity).transform.SetParent(transform);
            }

            lastTreeXPos += treeXDistance;
        }
	}
}
