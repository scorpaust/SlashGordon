using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 7f, jumpForce = 20f;

	[SerializeField]
	private LayerMask groundLayer;

	[SerializeField]
	private float attackWaitTime = 0.5f;

    private Rigidbody2D myBody;

	private Transform groundCheckPos;

	private bool canDoubleJump;

	private bool canAttack;

	private float attackTimer;

	private PlayerAnimationsWithTransitions playerAnim;

	private void Awake()
	{
		myBody = GetComponent<Rigidbody2D>();

		playerAnim = GetComponent<PlayerAnimationsWithTransitions>();

		groundCheckPos = transform.GetChild(0).transform;
	}

	private void Update()
	{
		Jump();

		AnimatePlayer();

		GetAttackInput();

		HandleAttackAction();
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

				playerAnim.PlayDoubleJump();
			}

			if (IsGrounded())
			{
				canDoubleJump = true;

				myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
			}
		}
	}

	private void AnimatePlayer()
	{
		playerAnim.PlayJump(myBody.velocity.y);

		playerAnim.PlayFromJumpToRunning(IsGrounded());
	}

	private void GetAttackInput()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			if (Time.time > attackTimer)
			{
				attackTimer = Time.time + attackWaitTime;

				canAttack = true;
			}
		}
	}

	private void HandleAttackAction()
	{
		if (canAttack && IsGrounded())
		{
			playerAnim.PlayAttack();

			canAttack = false;
		}

		else if (canAttack && !IsGrounded())
		{
			playerAnim.PlayJumpAttack();

			canAttack = false;
		}
	}
}
