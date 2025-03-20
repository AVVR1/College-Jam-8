using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
	[SerializeField] GameObject levelEndPanel;
	private void OnTriggerEnter(Collider other)
	{
		Time.timeScale = 0;
	}
}
