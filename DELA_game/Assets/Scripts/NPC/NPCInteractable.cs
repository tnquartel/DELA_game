using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class NPCInteractable : MonoBehaviour
{
    private TextMeshProUGUI interactText;

    public UnityEvent zoomEvent;
    public UnityEvent resetCamera;
    public UnityEvent setInvisible;

    private bool isInteracting = false;
    private bool isZooming = false;
    private GameObject player;
    private PlayerMovement playerMovement;
    private Renderer playerRenderer;
    private PlayerInteract playerInteract;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        playerRenderer = player.GetComponent<Renderer>();
        playerInteract = player.GetComponent<PlayerInteract>();
        interactText = (TextMeshProUGUI)FindObjectOfType(typeof(TextMeshProUGUI));
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInteracting && !isZooming)
        {
            ResetCamera();

            TogglePlayerComponents(true);
        }
    }

    public void Interact(GameObject npc)
    {
        if(isZooming) return;
        TogglePlayerComponents(false);
        ZoomOnNPC();
    }

    private void TogglePlayerComponents(bool isEnabled)
    {
        setInvisible.Invoke();
        foreach (Renderer r in player.GetComponentsInChildren<Renderer>())
            r.enabled = isEnabled;
        playerMovement.enabled = isEnabled;
        playerRenderer.enabled = isEnabled;
        playerInteract.enabled = isEnabled;
        isInteracting = !isEnabled;
        UpdateInteractText();
    }


    private void ZoomOnNPC()
    {
        zoomEvent.Invoke();
    }

    private void ResetCamera()
    {
        resetCamera.Invoke();
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
}
