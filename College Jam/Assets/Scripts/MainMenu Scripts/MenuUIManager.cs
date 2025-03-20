using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject[] tabs;
    [SerializeField] private SettingsManager settingsManager;

    //start button
    public void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Settings()
    {
        CloseAllUI();
        settingsPanel.SetActive(true);
    }

    public void SwitchToTab(int tab)
    {
        CloseAllTabs();
        tabs[tab].SetActive(true);
    }

    //closes all panels
    public void CloseAllUI()
    {
        //all panels getting disabled
        settingsPanel.SetActive(false);
        settingsManager.LoadSettings();
    }

    private void CloseAllTabs()
    {
        foreach (GameObject tab in tabs)
        {
            tab.SetActive(false);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
