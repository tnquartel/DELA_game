using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> senenteces; 
    public new TextMeshProUGUI name;
    public TextMeshProUGUI dialogueText;
    public GameObject npcUIContainer;
    public GameObject playerUIContainer;
    private int turnIndex = 0;
    private List<string> playerResponses = new List<string>(); 

    void Start()
    {
        ActivateDialogueUI(false);
        playerUIContainer.SetActive(false);
        senenteces = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        ActivateDialogueUI(true);
        name.text = dialogue.name;
        senenteces.Clear();

        foreach(string senentece in dialogue.sentences){
            senenteces.Enqueue(senentece);
        }

        turnIndex = 0;
        if(senenteces.Count == 0){
            EndDialogue();
            return;
        }
        
        string sentence = senenteces.Dequeue();
        dialogueText.text = sentence;
    }

    public void DisplayNextSentence()
    {
        if(senenteces.Count == 0){
            EndDialogue();
            return;
        }

        if(turnIndex == 0){
            string sentence = senenteces.Dequeue();
            dialogueText.text = sentence;
            turnIndex = 1;
            ActivateDialogueUI(false);

            playerResponses.Clear();
            playerResponses.Add("Response 1");
            playerResponses.Add("Response 2");
            playerResponses.Add("Response 3");

            DisplayPlayerResponses();
        }

    }

    private void DisplayPlayerResponses()
    {
        playerUIContainer.SetActive(true);

    }

    public void OnResponseSelected()
    {
        Debug.Log("Response selected");
        playerUIContainer.SetActive(false);
        turnIndex = 0;
        ActivateDialogueUI(true);
        DisplayNextSentence();
    }

    private void EndDialogue()
    {
        ActivateDialogueUI(false);
        FindObjectOfType<NPCInteractable>().StopInteraction();
    }

    public void ActivateDialogueUI(bool activate)
    {
        npcUIContainer.SetActive(activate);
    }
}
