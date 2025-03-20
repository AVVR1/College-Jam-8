using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreenFade : MonoBehaviour
{
	private void OnEnable()
	{
		PressurePlate.onStateSwitch += FadeScreen;
	}

	private void OnDisable()
	{
		PressurePlate.onStateSwitch -= FadeScreen;
	}

	private void FadeScreen()
	{
		StartCoroutine(FadePanel());
		
	}

	private IEnumerator FadePanel()
	{
		yield return null;
	}
}
