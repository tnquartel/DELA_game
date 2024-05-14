using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteractable : MonoBehaviour
{
    private TextMeshProUGUI interactText;

    private Vector3 originalCameraPosition;
    private Quaternion originalCameraRotation;
    private bool isInteracting = false;
    private bool isZooming = false;
    private Transform cameraTransform;
    private GameObject player;
    private PlayerMovement playerMovement;
    private Renderer playerRenderer;
    private PlayerInteract playerInteract;
    public Dialogue dialogue;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        playerRenderer = player.GetComponent<Renderer>();
        playerInteract = player.GetComponent<PlayerInteract>();
        cameraTransform = Camera.main.transform;
        originalCameraPosition = cameraTransform.position;
        originalCameraRotation = cameraTransform.rotation;
        interactText = GameObject.Find("InteractText").GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInteracting && !isZooming)
        {
            StopInteraction();
        }
    }

    public void Interact(GameObject npc)
    {
        Debug.Log("Interacting!");
        if(isZooming) return;
        TogglePlayerComponents(false);
        ZoomOnNPC(npc.transform);
        TriggerDialogue();
    }

    public void StopInteraction()
    {
        ResetCamera();
        TogglePlayerComponents(true);
        FindObjectOfType<DialogueManager>().ActivateDialogueUI(false);
    }

    private void TogglePlayerComponents(bool isEnabled)
    {
        Debug.Log(isEnabled);
        foreach (Renderer r in player.GetComponentsInChildren<Renderer>())
            r.enabled = isEnabled;
        playerMovement.enabled = isEnabled;
        playerRenderer.enabled = isEnabled;
        playerInteract.enabled = isEnabled;
        isInteracting = !isEnabled;
        UpdateInteractText();
    }


    private void ZoomOnNPC(Transform npcTransform)
    {
        Vector3 targetPosition = npcTransform.position + npcTransform.forward * 3f + Vector3.up * 1.5f;  // Position camera slightly above and behind the NPC
        Quaternion targetRotation = Quaternion.LookRotation(npcTransform.position - targetPosition);
        StartCoroutine(SmoothZoom(targetPosition, targetRotation));
    }

    IEnumerator SmoothZoom(Vector3 targetPosition, Quaternion targetRotation)
    {
        if(isZooming) yield break;
        isZooming = true; 

        float startTime = Time.time;
        while (Time.time - startTime < 1.5f)
        {
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetPosition, 5f * Time.deltaTime);
            cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, targetRotation, 5f * Time.deltaTime);
            yield return null;
        }

        isZooming = false;
    }

    private void ResetCamera()
    {
        StartCoroutine(SmoothZoom(originalCameraPosition, originalCameraRotation));
    }

    private void UpdateInteractText()
{
    if (interactText != null)
        interactText.text = GetInteractText();
}

    public string GetInteractText()
    {
         return isInteracting ? "Stop Interacting" : "Interact";
    }

    private void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
