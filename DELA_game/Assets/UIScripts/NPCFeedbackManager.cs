using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCFeedbackManager : MonoBehaviour
{
    public NPCInteractable npc;

    public Sprite sprite;
    public Text nameText;
    public Text scoreText;
    public Text feedbackText;
    public Image spriteObject;

    void Start()
    {
        nameText.text = npc.dialogue.name;
        spriteObject.sprite = sprite;

        System.Random random = new System.Random();
        SetScore(random.Next(0, 3));
    }

    public void SetScore(int score)
    {
        string scoreString = "";
        switch (score)
        {
            case 0:
                scoreText.color = Color.red;
                scoreString = "Helaas.";
                break;
            case 1:
                scoreText.color = Color.yellow;
                scoreString = "Dit kan beter.";
                break;
            case 2:
                scoreText.color = Color.green;
                scoreString = "Super!";
                break;
        }
        scoreText.text = scoreString;
    }

    public void SetFeedback(string feedback)
    {
        feedbackText.text = feedback;
    }
}
