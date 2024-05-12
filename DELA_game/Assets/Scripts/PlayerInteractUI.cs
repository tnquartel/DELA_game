using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private PlayerInteract playerInteract;
    public TextMeshProUGUI keyText;

    private void Update()
    {
        if (playerInteract.GetInteractable() != null) Show();
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

    public void changeInteractBtn()
    {
        if(playerInteract.getIsInteracting()) keyText.text = "Esc";
        else keyText.text = "E";
    }
}
