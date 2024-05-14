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
    public GameObject dialogueUI;

    void Start()
    {
        ActivateDialogueUI(false);
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

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(senenteces.Count == 0){
            StartCoroutine(EndDialogue());
            return;
        }

        string sentence = senenteces.Dequeue();
        dialogueText.text = sentence;
    }

    private IEnumerator EndDialogue()
    {
        ActivateDialogueUI(false);
        yield return new WaitForSeconds(2f);
        FindObjectOfType<NPCInteractable>().StopInteraction();
    }

    public void ActivateDialogueUI(bool activate)
    {
        dialogueUI.SetActive(activate);
    }
}
