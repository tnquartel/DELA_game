using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject whyInfoPanel;
    public GameObject howInfoPanel;

    public void HideAllPanels()
    {
        startPanel.SetActive(false);
        whyInfoPanel.SetActive(false);
        howInfoPanel.SetActive(false);
    }

    public void ShowStartPanel()
    {
        HideAllPanels();
        startPanel.SetActive(true);
    }

    public void ShowWhyInfoPanel()
    {
        HideAllPanels();
        whyInfoPanel.SetActive(true);
    }

    public void ShowHowInfoPanel()
    {
        HideAllPanels();
        howInfoPanel.SetActive(true);
    }

    void Start()
    {
        ShowStartPanel();
    }

    public void SavePlayerName(string playerName)
    {
        PlayerPrefs.SetString("PlayerName", playerName);
    }
}
