using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private PlayerInteract playerInteract;
    public TextMeshProUGUI keyText;
    public GameObject endPanel;

    private void Update()
    {
        if (playerInteract.GetInteractable() != null && !endPanel.activeSelf) Show();
        else Hide();

    }

    private void Show()
    {
        container.SetActive(true);
    }

    private void Hide()
    {
        container.SetActive(false);
    }
}