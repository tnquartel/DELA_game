using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject whyInfoPanel;
    public GameObject howInfoPanel;
    public GameObject endPanel;
    public GameObject collectibleCanvas;
    public GameObject regionText;
    public Text playerNameText;

    public InputField playerNameInput;

    public void HideAllPanels()
    {
        startPanel.SetActive(false);
        whyInfoPanel.SetActive(false);
        howInfoPanel.SetActive(false);
        endPanel.SetActive(false);
        collectibleCanvas.SetActive(false);
        regionText.SetActive(false);
    }

    public void ShowInGameUI() {
        HideAllPanels();
        collectibleCanvas.SetActive(true);
        regionText.SetActive(true);
    }

    public void ShowStartPanel()
    {
        HideAllPanels();
        startPanel.SetActive(true);
    }

    public void ShowCollectibleCanvas()
    {
        collectibleCanvas.SetActive(true);
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

    public void ShowEndPanel()
    {
        HideAllPanels();
        playerNameText.text = "Goed gedaan, " + PlayerPrefs.GetString("PlayerName") + "!";
        endPanel.SetActive(true);
    }

    void Start()
    {
        ShowStartPanel();
    }

    public void StartGame()
    {
        PlayerPrefs.SetString("PlayerName", playerNameInput.text);
        ShowHowInfoPanel();
    }

    public void PlayAgain()
    {
        ShowStartPanel();
    }

    public void StopGame()
    {
        Application.Quit();
    }
}
