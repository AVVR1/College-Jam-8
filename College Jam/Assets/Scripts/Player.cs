using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
	float sprintMultiplier = 1;
	public float moveSpeed;

	[SerializeField] Camera cam;

	[SerializeField] AudioClip clickSound;
	[SerializeField] AudioSource generalSource;

    Rigidbody rb;

	public int selectedKeyID = -1;

	StateManager statemanager;

	private void Awake()
	{
		statemanager = FindAnyObjectByType<StateManager>();
		rb = GetComponent<Rigidbody>();
	}

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
	{
		Movement();
		MouseInput();
		DropInput();
		SyncRotation();
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

	public Collider Raycast()
	{
		RaycastHit hit;
		Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 3);
		if (hit.collider != null)
		{
			return hit.collider;
		}
		return null;
	}

	private void PickupKey(Collider rayCollider)
	{
		selectedKeyID = rayCollider.GetComponent<Key>().ID;
		rayCollider.transform.parent = gameObject.transform;
		List<GameObject> list = GetStateObjectsList(rayCollider.GetComponent<Key>().state);
		list.Remove(rayCollider.gameObject);
		rayCollider.GetComponent<Rigidbody>().isKinematic = true;
		rayCollider.transform.localPosition = new Vector3(0, 0, 1);
	}

	private void DropKey()
	{
		GameObject parent = null;
		Transform child = transform.GetChild(0);

		parent = GetStateObjectsParent(statemanager.currentState);
		child.parent = parent.transform;
		GetStateObjectsList(statemanager.currentState).Add(child.gameObject);
		child.GetComponent<Rigidbody>().isKinematic = false;
		selectedKeyID = -1;
	}

	private void Interact(Collider rayCollider)
	{
		if (selectedKeyID == rayCollider.GetComponent<Lock>().ID)
		{
			//find door with correct ID
			GameObject[] objects = GameObject.FindGameObjectsWithTag("Door");
			foreach (GameObject obj in objects)
			{
				Door door = obj.GetComponent<Door>();
				if (door != null && door.ID == rayCollider.GetComponent<Lock>().ID)
				{
					//correct door found
					GameObject target = obj;
					//destroy door
					Destroy(target);
					//remove door
					List<GameObject> list = GetStateObjectsList(door.state);
					list.Remove(target);
					//destroy key
					selectedKeyID = -1;
					Destroy(transform.GetChild(0).gameObject);
					
					break;
				}
			}
		}
	}

	private void MouseInput()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Collider rayCollider = Raycast();
			if (rayCollider != null)
			{
				if (rayCollider.CompareTag("Key"))
				{
					generalSource.PlayOneShot(clickSound);
					if (selectedKeyID == -1)
					{
						PickupKey(rayCollider);
					}
					else
					{
						DropKey();
						PickupKey(rayCollider);
					}
				}
				else if (rayCollider.CompareTag("Lock"))
				{
                    generalSource.PlayOneShot(clickSound);
                    Interact(rayCollider);
				}
			}
		}
	}

	private void DropInput()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			if (selectedKeyID != -1)
			{
				DropKey();
			}
		}
	}

	private GameObject GetStateObjectsParent(StateManager.State state)
	{
		switch (state)
		{
			case StateManager.State.present:
			return statemanager.presentObjectsParent;
			case StateManager.State.past:
			return statemanager.pastObjectsParent;
		}
		return null;
	}

	private List<GameObject> GetStateObjectsList(StateManager.State state)
	{
		switch (state)
		{
			case StateManager.State.present:
			return statemanager.presentObjects;
			case StateManager.State.past:
			return statemanager.pastObjects;
		}
		return null;
	}

	private void SyncRotation()
	{
		transform.rotation = Quaternion.Euler(0,cam.transform.rotation.eulerAngles.y,0);
	}
}
