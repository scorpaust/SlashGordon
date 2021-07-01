﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField]
    private bool deactivateGameObject;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(TagManager.PLAYER_TAG))
		{
			Debug.Log("Deal damage to Player");
		}

		if (collision.CompareTag(TagManager.ENEMY_TAG) || collision.CompareTag(TagManager.OBSTACLE_TAG))
		{
			Debug.Log("Deal damage to enemy");
		}
	}
}
