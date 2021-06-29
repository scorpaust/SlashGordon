using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 7f, jumpForce = 20f;

	[SerializeField]
	private LayerMask groundLayer;

    private Rigidbody2D myBody;

	private Transform groundCheckPos;

	private bool canDoubleJump;

	private void Awake()
	{
		myBody = GetComponent<Rigidbody2D>();

		groundCheckPos = transform.GetChild(0).transform;
	}

	private void Update()
	{
		Jump();
	}

	private void FixedUpdate()
	{
		MovePlayer();
	}

	private void MovePlayer()
	{
		myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
	}

	private bool IsGrounded()
	{
		return Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
	}

	private void Jump()
	{
		if (Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown(TagManager.JUMP_BUTTON))
		{

			if (!IsGrounded() && canDoubleJump)
			{
				canDoubleJump = false;

				myBody.velocity = Vector2.zero;

				myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
			}

			if (IsGrounded())
			{
				canDoubleJump = true;

				myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
			}
		}
	}
}
