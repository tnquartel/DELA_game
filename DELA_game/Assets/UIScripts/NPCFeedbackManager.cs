using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCFeedbackManager : MonoBehaviour
{
    public NPCInteractable npc;

    public string areaName;

    public Sprite sprite;
    public Text nameText;
    public Text scoreText;
    public Text feedbackText;
    public Image spriteObject;
    public string feedbackForBad;
    public string feedbackForGood;

    void Start()
    {
        nameText.text = npc.dialogue.name;
        spriteObject.sprite = sprite;
    }

    public void SetScore(int score)
    {
        string scoreString = "";
        string feedbackString = "";
        switch (score)
        {
            case 0:
                scoreText.color = Color.red;
                scoreString = "Helaas.";
                feedbackString = feedbackForBad;
                break;
            case 1:
                scoreText.color = Color.yellow;
                scoreString = "Dit kan beter.";
                feedbackString = feedbackForBad;
                break;
            case 2:
                scoreText.color = Color.green;
                scoreString = "Super!";
                feedbackString = feedbackForGood;
                break;
        }
        scoreText.text = scoreString;
        feedbackText.text = feedbackString;
    }
}