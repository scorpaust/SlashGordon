using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 7f, jumpForce = 20f;

    private Rigidbody2D myBody;

	private void Awake()
	{
		myBody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		MovePlayer();
	}

	private void MovePlayer()
	{
		myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
	}
}
