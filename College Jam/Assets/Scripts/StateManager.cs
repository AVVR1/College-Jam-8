using Cinemachine.PostFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class StateManager : MonoBehaviour
{
	public enum State { present, past }
	public State currentState = State.present;
	[SerializeField] PostProcessVolume postProcessVolume;

	private void Update()
	{
		if (currentState == State.present)
		{
			// mustavalkoinen pois p‰‰lt‰
			postProcessVolume.enabled = false;
		}
		else
		{
			//mustavalkoinen p‰‰lle
			postProcessVolume.enabled = true;
		}
	}
}
