using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<DialogueSentence> sentences; 
    public new TextMeshProUGUI name;
    public TextMeshProUGUI dialogueText;
    public GameObject npcUIContainer;
    public GameObject playerUIContainer;
    private List<Collectible> playerResponses;
    public Transform playerResponsesContainer;
    public GameObject responseButtonPrefab;
    public TMP_InputField playerResponseInputField;
    private List<Collectible> tempPlayerResponses;
    private Collectible selectedResponse;
    private DialogueSentence currentSentence;
    private ScoreManager scoreManager;
    public SectorManager sectorManager;
    

    void Start()
    {
        npcUIContainer.SetActive(false);
        playerUIContainer.SetActive(false);
        sentences = new Queue<DialogueSentence>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        playerResponses = FindObjectOfType<CollectibleManager>().GetCollectible();
        tempPlayerResponses = playerResponses;
        npcUIContainer.SetActive(true);
        name.text = dialogue.name;
        sentences.Clear();

        foreach(DialogueSentence senentece in dialogue.sentences){
            sentences.Enqueue(senentece);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }
        currentSentence = sentences.Dequeue();
        dialogueText.text = currentSentence.sentence;
    }

    public void DisplayPlayerResponses()
    {
        playerResponseInputField.text = "";
        npcUIContainer.SetActive(false);
        playerUIContainer.SetActive(true);

        foreach (Transform child in playerResponsesContainer)
        {
            Destroy(child.gameObject);
        }

        // Create buttons for each response
        foreach (Collectible response in tempPlayerResponses)
        {
            GameObject responseWrapper = Instantiate(responseButtonPrefab, playerResponsesContainer);
            responseWrapper.GetComponentInChildren<TextMeshProUGUI>().text = response.text;

            // Add a listener for the button click (optional)
            responseWrapper.GetComponentInChildren<Button>().onClick.AddListener(() => fillInputField(response));
        }
    }

    private void fillInputField(Collectible response)
    {
        selectedResponse = response;
        playerResponseInputField.text = response.text;
    }

    public void OnResponseSelected()
    {
        if(string.IsNullOrEmpty(playerResponseInputField.text)) return;
        tempPlayerResponses.Remove(selectedResponse);
        npcUIContainer.SetActive(true);
        playerUIContainer.SetActive(false);
        CheckResponse();
        DisplayNextSentence();
    }

    private void CheckResponse()
    {
        if(currentSentence.answer == selectedResponse){
        string currentSector = sectorManager.CurrentSector;

        switch (currentSector)
            {
                case "Matige Meren":
                    scoreManager.AddScore("NPCLake");
                    break;
                case "Diepe Doelen":
                    scoreManager.AddScore("NPCFootball");
                    break;
                case "Woeste Wateren":
                    scoreManager.AddScore("NPCWaterTower");
                    break;
                case "Boze Bergen":
                    scoreManager.AddScore("NPCMines");
                    break;
                case "Wazige Woud":
                    scoreManager.AddScore("NPCForrestHut");
                    break;
            }

            Debug.Log("Good!");
        }
        else Debug.Log("Bad!");
    }

    private void EndDialogue()
    {
        npcUIContainer.SetActive(false);
        FindObjectOfType<NPCInteractable>().StopInteraction();
        playerResponses = tempPlayerResponses;
    }

    public void ActivateDialogueUI(bool activate)
    {
        npcUIContainer.SetActive(activate);
        playerUIContainer.SetActive(activate);
    }
}
