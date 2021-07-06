using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float offsetX = -7f;

    private Vector3 tempPos;

    private Transform playerPos;

	private void Awake()
	{
		// FindPlayerRef();
	}

	private void LateUpdate()
	{
		FollowPlayer();
	}

	public void FindPlayerRef()
	{
		playerPos = GameObject.FindWithTag(TagManager.PLAYER_TAG).transform;
	}

	private void FollowPlayer()
	{
		if (!playerPos) return;

		tempPos = transform.position;

		tempPos.x = playerPos.position.x - offsetX;

		transform.position = tempPos;
	}
}
