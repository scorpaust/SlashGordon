using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingObstacle : MonoBehaviour
{
	[SerializeField]
	private float rotateSpeed = 50f;

	[SerializeField]
	private float minZRotation = -0.6f, maxZRotation = 0.6f;

	private Rigidbody2D myBody;

	private bool rotateLeft;

	private float zAngle;

	private void Awake()
	{

		myBody = GetComponent<Rigidbody2D>();

		if (Random.Range(0,2) > 0) 
		{
			rotateLeft = true;
		}
	}

	private void Update()
	{
		HandleRotationWithRigidbody();
	}

	private void HandleRotationWithRigidbody()
	{
		if (transform.rotation.z > maxZRotation)
			rotateLeft = true;

		if (transform.rotation.z < minZRotation)
			rotateLeft = false;

		if (rotateLeft)
			myBody.angularVelocity = -rotateSpeed;
		else
			myBody.angularVelocity = rotateSpeed;
	}

	private void HandleRotationWithTransform()
	{
		zAngle += Time.deltaTime * rotateSpeed;

		transform.rotation = Quaternion.AngleAxis(zAngle, Vector3.forward);

		if (transform.rotation.z < minZRotation)
			rotateSpeed = Mathf.Abs(rotateSpeed);

		if (transform.rotation.z > maxZRotation)
			rotateSpeed = -Mathf.Abs(rotateSpeed);
	}
}
