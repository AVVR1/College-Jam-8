using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreenFade : MonoBehaviour
{
	[SerializeField] GameObject BlackPanel;
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
		BlackPanel.SetActive(true);
		float alpha = 1.0f;
		Image blackPanelImage = BlackPanel.GetComponent<Image>();
		blackPanelImage.color = new Color(0, 0, 0, 1);
		while (blackPanelImage.color.a > 0)
		{
			alpha -= Time.deltaTime / 2;
			blackPanelImage.color = new Color(0, 0, 0, alpha);
			yield return null;
		}
		BlackPanel.SetActive(false);
		yield return null;
	}
}
