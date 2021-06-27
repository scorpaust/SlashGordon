using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionBackground : MonoBehaviour
{
    private GameObject[] backgrounds;

    [SerializeField]
    private string bgTag;

    private float highestXPos;

    private float offsetValue;

    private float newXPos;

    private Vector3 newPos;

	private void Awake()
	{
        backgrounds = GameObject.FindGameObjectsWithTag(bgTag);

        offsetValue = backgrounds[0].GetComponent<BoxCollider2D>().bounds.size.x;

        highestXPos = backgrounds[0].transform.position.x;

        for (int i = 1; i < backgrounds.Length; i++)
		{
            if (backgrounds[i].transform.position.x > highestXPos)
			{
                highestXPos = backgrounds[i].transform.position.x;
            }
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(bgTag))
		{
            newXPos = highestXPos + offsetValue;

            highestXPos = newXPos;

            newPos = collision.transform.position;

            newPos.x = newXPos;

            collision.transform.position = newPos;
		}
	}
}
