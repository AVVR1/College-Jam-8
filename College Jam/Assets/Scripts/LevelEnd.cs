using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
	[SerializeField] GameObject levelEndPanel;
	private void OnTriggerEnter(Collider other)
	{
		levelEndPanel.SetActive(true);
		Time.timeScale = 0;
	}
}
