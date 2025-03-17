using Cinemachine.PostFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class StateManager : MonoBehaviour
{
	public enum State { present, past }
	[Header("---Current State---")]
	public State currentState = State.present;

	[Header("Variables")]
	[SerializeField] PostProcessVolume postProcessVolume;
	[SerializeField] GameObject presentObjectsParent;
	[SerializeField] GameObject pastObjectsParent;
	List<GameObject> presentObjects = new List<GameObject>();
	List<GameObject> pastObjects = new List<GameObject>();

	private void Awake()
	{
		foreach (Transform child in presentObjectsParent.transform)
		{
			presentObjects.Add(child.gameObject);
		}

		foreach (Transform child in pastObjectsParent.transform)
		{
			pastObjects.Add(child.gameObject);
		}
	}

	private void Update()
	{
		if (currentState == State.present)
		{
			// mustavalkoinen pois p‰‰lt‰
			postProcessVolume.enabled = false;
			foreach (GameObject presentObject in presentObjects)
			{
				presentObject.SetActive(true);
			}
			foreach (GameObject pastObject in pastObjects)
			{
				pastObject.SetActive(false);
			}
		}
		else
		{
			//mustavalkoinen p‰‰lle
			postProcessVolume.enabled = true;
			foreach (GameObject presentObject in presentObjects)
			{
				presentObject.SetActive(false);
			}
			foreach (GameObject pastObject in pastObjects)
			{
				pastObject.SetActive(true);
			}
		}
	}
}
