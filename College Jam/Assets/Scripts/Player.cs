using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	float sprintMultiplier = 1;
	public float moveSpeed;
	Rigidbody rb;
	[SerializeField] Camera cam;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		Movement();
	}

	private void Movement()
	{
		//WASD or arrow key inputs into vector values
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		if (Input.GetKey(KeyCode.LeftShift))
		{
			sprintMultiplier = 1.5f;
		}
		else
		{
			sprintMultiplier = 1;
		}

		//WASD pressed
		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
		{
			Vector3 moveDirForward = cam.transform.forward;
			Vector3 moveDirRight = cam.transform.right;
			//move player
			moveDirForward.y = 0f;
			moveDirRight.y = 0f;
			rb.velocity = (moveDirRight.normalized * horizontal + moveDirForward.normalized * vertical) * moveSpeed * sprintMultiplier + Vector3.up * rb.velocity.y;
		}
	}
}
