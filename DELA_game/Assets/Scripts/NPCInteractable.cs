using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    [SerializeField] private string interactText;

    private Vector3 originalCameraPosition;
    private Quaternion originalCameraRotation;
    private bool isInteracting = false;
    private Transform cameraTransform;
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
        cameraTransform = Camera.main.transform;
        originalCameraPosition = cameraTransform.position;
        originalCameraRotation = cameraTransform.rotation;
    }

    public void Update()
    {
        if(isInteracting && Input.GetKeyDown(KeyCode.Escape))
        {
            ResetCamera();
            TogglePlayerComponents(true);
        }
    }

    public void Interact(GameObject npc)
    {
        TogglePlayerComponents(false);
        ZoomOnNPC(npc.transform);
    }

    private void TogglePlayerComponents(bool isEnabled)
    {
        foreach (Renderer r in player.GetComponentsInChildren<Renderer>())
            r.enabled = isEnabled;
        playerMovement.enabled = isEnabled;
        playerRenderer.enabled = isEnabled;
        playerInteract.enabled = isEnabled;
    }


    private void ZoomOnNPC(Transform npcTransform)
    {
        Vector3 targetPosition = npcTransform.position + npcTransform.forward * 3f + Vector3.up * 1.5f;  // Position camera slightly above and behind the NPC
        Quaternion targetRotation = Quaternion.LookRotation(npcTransform.position - targetPosition);
        StartCoroutine(SmoothZoom(targetPosition, targetRotation));
        isInteracting = true;
    }

    IEnumerator SmoothZoom(Vector3 targetPosition, Quaternion targetRotation)
    {
        float startTime = Time.time;
        while (Time.time - startTime < 1.5f)
        {
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetPosition, 5f * Time.deltaTime);
            cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, targetRotation, 5f * Time.deltaTime);
            yield return null;
        }
    }

    private void ResetCamera()
    {
        StartCoroutine(SmoothZoom(originalCameraPosition, originalCameraRotation));
        isInteracting = false;
    }

    public string GetInteractText()
    {
        return interactText;
    }
}
