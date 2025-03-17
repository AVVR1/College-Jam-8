using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
	public enum State { present, past }
	public State currentState = State.present;

	private void Update()
	{
		if (currentState == State.present)
		{

		}
		else
		{

		}
	}
}
