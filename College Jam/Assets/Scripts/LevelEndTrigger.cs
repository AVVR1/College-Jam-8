using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTrigger : MonoBehaviour
{
	[SerializeField] GameObject levelEndPanel;
	private void OnTriggerEnter(Collider other)
	{
		levelEndPanel.SetActive(false);
		StartCoroutine(LoadMainMenu());
	}

	private IEnumerator LoadMainMenu()
	{
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene("MainMenu");
	}
}
