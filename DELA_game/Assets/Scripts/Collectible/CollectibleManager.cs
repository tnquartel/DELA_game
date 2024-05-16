using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public TextMeshProUGUI collectibleText;
    public SectorManager sectorManager;
    public List<Collectible> Responses;
    public List<Collectible> Tips;

    public void addResponse(Collectible response)
    {
        Responses.Add(response);
    }

    public void addTip(Collectible tip)
    {
        Tips.Add(tip);
    }

    public void UpdateCollectableCanvas() {
        string currentSector = sectorManager.CurrentSector;
        Debug.Log(currentSector);
        Debug.Log("Filter");
        int collectiblesCollected = 0;

        switch (currentSector)
            {
                case "Knusse Kampeerplaats":
                    Debug.Log("Camp");
                    collectiblesCollected = Responses.FindAll(response => response.CompareTag("CollectibleStarter")).Count;
                    collectibleText.text = collectiblesCollected + "/1 Responses Collected";
                    return;
                case "Matige Meren":
                    collectiblesCollected = Responses.FindAll(response => response.CompareTag("CollectibleLake")).Count;
                    break;
                case "Diepe Doelen":
                    collectiblesCollected = Responses.FindAll(response => response.CompareTag("CollectibleFootball")).Count;
                    break;
                case "Woeste Wateren":
                    collectiblesCollected = Responses.FindAll(response => response.CompareTag("CollectibleWaterTower")).Count;
                    break;
                case "Boze Bergen":
                    collectiblesCollected = Responses.FindAll(response => response.CompareTag("CollectibleMountain")).Count;
                    break;
                case "Wazige Woud":
                    collectiblesCollected = Responses.FindAll(response => response.CompareTag("CollectibleForrestHut")).Count;
                    break;
            }

            Debug.Log(collectiblesCollected);

            collectibleText.text = collectiblesCollected + "/4 Responses Collected";
        }
    }