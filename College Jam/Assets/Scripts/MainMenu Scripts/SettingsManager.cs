using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider maxFpsSlider;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private TMP_Dropdown graphicsQualityDropdown;
    private void Awake()
    {
        LoadSettings();
    }

    public void Apply()
    {
        PlayerPrefs.SetFloat("Master", masterSlider.value);
        PlayerPrefs.SetFloat("Music", musicSlider.value);
        PlayerPrefs.SetFloat("SFX", sfxSlider.value);
        PlayerPrefs.SetFloat("MaxFPS", maxFpsSlider.value);
        PlayerPrefs.SetInt("Resolution", resolutionDropdown.value);
        PlayerPrefs.SetInt("GraphicsQuality", graphicsQualityDropdown.value);
    }

    public void LoadSettings()
    {
        masterSlider.value = PlayerPrefs.GetFloat("Master", 0.5f);
        musicSlider.value = PlayerPrefs.GetFloat("Music", 0.5f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFX", 0.5f);
        maxFpsSlider.value = PlayerPrefs.GetFloat("MaxFPS", 60f);
        resolutionDropdown.value = PlayerPrefs.GetInt("Resolution");
        graphicsQualityDropdown.value = PlayerPrefs.GetInt("GraphicsQuality");
    }
}
