using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGeneratorPooling : MonoBehaviour
{
    [SerializeField]
    private GameObject groundPrefab, treePrefab;

    [SerializeField]
    private float groundYPos = -6f, treeYPos = -0.18f;

    [SerializeField]
    private float groundXDistance = 17.85f, treeXDistance = 41.2f;

    [SerializeField]
    private float generateLevelWaitTime = 3f;

    [SerializeField]
    private int initialGroundsToSpawn = 10, initialTreesToSpawn = 5;

    public List<GameObject> groundPool = new List<GameObject>();

    public List<GameObject> treePool = new List<GameObject>();

    private float lastGroundXPos, lastTreeXPos;

    private float waitTime;

	private void Start()
	{
        GenerateInitialGroundAndTrees();

        waitTime = Time.time + generateLevelWaitTime;
    }

	private void Update()
	{
        CheckForGroundAndTrees();
	}

	private void GenerateInitialGroundAndTrees()
	{
        Vector3 groundPos = Vector3.zero;

        GameObject newGround;

        for (int i = 0; i < initialGroundsToSpawn; i++)
		{
            groundPos = new Vector3(lastGroundXPos, groundYPos, 0f);

            newGround = Instantiate(groundPrefab, groundPos, Quaternion.identity);

            newGround.transform.SetParent(transform);

            groundPool.Add(newGround);

            lastGroundXPos += groundXDistance;
		}

        Vector3 treePos = Vector3.zero;

        GameObject newTree;

        for (int i = 0; i < initialTreesToSpawn; i++)
		{
            treePos = new Vector3(lastTreeXPos, treeYPos, 0f);

            newTree = Instantiate(treePrefab, treePos, Quaternion.identity);

            newTree.transform.SetParent(transform);

            treePool.Add(newTree);

            lastTreeXPos += treeXDistance;
		}
	}

    private void SetNewGrounds()
	{
        Vector3 groundPos = Vector3.zero;

        for (int i = 0; i < groundPool.Count; i++)
		{
            if (!groundPool[i].activeInHierarchy)
			{
                groundPos = new Vector3(lastGroundXPos, groundYPos, 0f);

                groundPool[i].transform.position = groundPos;

                groundPool[i].SetActive(true);

                lastGroundXPos += groundXDistance;
			}
		}
	}

    private void SetNewTrees()
    {
        Vector3 treePos = Vector3.zero;

        for (int i = 0; i < treePool.Count; i++)
        {
            if (!treePool[i].activeInHierarchy)
            {
                treePos = new Vector3(lastTreeXPos, treeYPos, 0f);

                treePool[i].transform.position = treePos;

                treePool[i].SetActive(true);

                lastTreeXPos += treeXDistance;
            }
        }
    }

    private void CheckForGroundAndTrees()
	{
        if (Time.time > waitTime)
        { 
            SetNewGrounds();

            SetNewTrees();

            waitTime = Time.time + generateLevelWaitTime;
		}
	}
}
