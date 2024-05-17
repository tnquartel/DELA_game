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
        SetScore(0);
    }

    public void SetScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void SetFeedback(string feedback)
    {
        feedbackText.text = feedback;
    }
}
