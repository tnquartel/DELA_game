using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences; 
    public new TextMeshProUGUI name;
    public TextMeshProUGUI dialogueText;
    public GameObject npcUIContainer;
    public GameObject playerUIContainer;
    private List<string> playerResponses = new List<string>(); 
    public Transform playerResponsesContainer;
    public GameObject responseButtonPrefab;
    public TMP_InputField playerResponseInputField;

    void Start()
    {
        npcUIContainer.SetActive(false);
        playerUIContainer.SetActive(false);
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        npcUIContainer.SetActive(true);
        name.text = dialogue.name;
        sentences.Clear();

        foreach(string senentece in dialogue.sentences){
            sentences.Enqueue(senentece);
        }

        if(sentences.Count == 0){
            EndDialogue();
            return;
        }
        
        dialogueText.text = sentences.Dequeue();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }
        dialogueText.text = sentences.Dequeue();
    }

    public void DisplayPlayerResponses()
    {
        playerResponseInputField.text = "";
        npcUIContainer.SetActive(false);
        playerUIContainer.SetActive(true);
        playerResponses.Clear();
        playerResponses.Add("Response 1");
        playerResponses.Add("Response 2");
        playerResponses.Add("Response 3");

        foreach (Transform child in playerResponsesContainer)
        {
            Destroy(child.gameObject);
        }

        // Create buttons for each response
        foreach (string response in playerResponses)
        {
            GameObject responseWrapper = Instantiate(responseButtonPrefab, playerResponsesContainer);
            responseWrapper.GetComponentInChildren<TextMeshProUGUI>().text = response;

            // Add a listener for the button click (optional)
            responseWrapper.GetComponentInChildren<Button>().onClick.AddListener(() => fillInputField(response));
        }
    }

    private void fillInputField(string response)
    {
        playerResponseInputField.text = response;
    }

    public void OnResponseSelected()
    {
        if(string.IsNullOrEmpty(playerResponseInputField.text)) return;
        npcUIContainer.SetActive(true);
        playerUIContainer.SetActive(false);
        DisplayNextSentence();
    }

    private void EndDialogue()
    {
        npcUIContainer.SetActive(false);
        FindObjectOfType<NPCInteractable>().StopInteraction();
    }

    public void ActivateDialogueUI(bool activate)
    {
        npcUIContainer.SetActive(activate);
    }
}
