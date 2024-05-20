using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject whyInfoPanel;
    public GameObject howInfoPanel;
    public GameObject endPanel;
    public GameObject collectibleCanvas;
    public GameObject regionText;
    public TextMeshProUGUI instructionTextMove;
    public TextMeshProUGUI instructionTextJump;
    public Text playerNameText;

    public InputField playerNameInput;
    public GameObject player;

    [SerializeReference]
    public List<NPCFeedbackManager> feedbackManagers;

    private bool isFading = false;
    private bool shouldMove;
    private bool shouldJump;

    private void Update()
    {
        if (!isFading)
        {
            if (shouldMove && player.transform.position.x > 1 || shouldMove && player.transform.position.x < -1 || shouldMove && player.transform.position.z > -5 || shouldMove && player.transform.position.z < -7)
            {
                shouldMove = false;
                StartCoroutine(FadeOutMoveText());
            }
            if (shouldJump && Input.GetKeyDown(KeyCode.Space))
            {
                shouldJump = false;
                StartCoroutine(FadeOutJumpText());
            }
        }
    }

    public void HideAllPanels()
    {
        startPanel.SetActive(false);
        whyInfoPanel.SetActive(false);
        howInfoPanel.SetActive(false);
        endPanel.SetActive(false);
        collectibleCanvas.SetActive(false);
        regionText.SetActive(false);
        instructionTextMove.gameObject.SetActive(false);
        instructionTextJump.gameObject.SetActive(false);
    }

    public void ShowInGameUI()
    {
        HideAllPanels();
        collectibleCanvas.SetActive(true);
        regionText.SetActive(true);
        instructionTextMove.gameObject.SetActive(true);
        StartCoroutine(FadeInMoveText());
    }
    private IEnumerator FadeInMoveText()
    {
        isFading = true;
        Color originalColor = instructionTextMove.color;
        while (instructionTextMove.color.a < 1)
        {
            float newAlpha = instructionTextMove.color.a + Time.deltaTime;
            instructionTextMove.color = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha);
            yield return null;
        }
        isFading = false;
        instructionTextMove.gameObject.SetActive(true);
        shouldMove = true;
    }

    private IEnumerator FadeOutMoveText()
    {
        isFading = true;
        Color originalColor = instructionTextMove.color;
        while (instructionTextMove.color.a > 0)
        {
            float newAlpha = instructionTextMove.color.a - Time.deltaTime;
            instructionTextMove.color = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha);
            yield return null;
        }
        isFading = false;
        instructionTextMove.gameObject.SetActive(false);
        instructionTextJump.gameObject.SetActive(true);
        StartCoroutine(FadeInJumpText());
    }

    private IEnumerator FadeInJumpText()
    {
        isFading = true;
        Color originalColor = instructionTextJump.color;
        while (instructionTextJump.color.a < 1)
        {
            float newAlpha = instructionTextJump.color.a + Time.deltaTime;
            instructionTextJump.color = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha);
            yield return null;
        }
        isFading = false;
        instructionTextJump.gameObject.SetActive(true);
        shouldJump = true;
    }

    private IEnumerator FadeOutJumpText()
    {
        isFading = true;
        Color originalColor = instructionTextJump.color;
        while (instructionTextJump.color.a > 0)
        {
            float newAlpha = instructionTextJump.color.a - Time.deltaTime;
            instructionTextJump.color = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha);
            yield return null;
        }
        isFading = false;
        instructionTextJump.gameObject.SetActive(false);
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

        foreach (NPCFeedbackManager feedbackManager in feedbackManagers)
        {
            int score = feedbackManager.npc.GetScore(feedbackManager.areaName);
            feedbackManager.SetScore(score);
        }

        endPanel.SetActive(true);
    }

    void Start()
    {
        ShowStartPanel();
    }

    public void StartGame()
    {
        if (playerNameInput.text == "")
        {
            playerNameInput.text = "speler";
        }

        PlayerPrefs.SetString("PlayerName", playerNameInput.text);
        ShowHowInfoPanel();
    }

    public void StopGame()
    {
        Application.Quit();
    }
}
