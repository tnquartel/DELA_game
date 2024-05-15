using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSectorChecker : MonoBehaviour
{
    public SectorManager sectorManager;
    public LayerMask floorMask;
    public float groundCheckDistance = 0.1f;

    void Start() {
        InvokeRepeating("CheckFloor", 0, 1.0f);
    }

    // void Update() {
    //     CheckFloor();
    // }

     void CheckFloor()
    {
        RaycastHit hit;
        Vector3 origin = transform.position + Vector3.up * 0.1f;

        if (Physics.Raycast(origin, Vector3.down, out hit, groundCheckDistance, floorMask))
        {

            string tag = hit.collider.tag;

            switch (tag)
            {
                case "StarterSector":
                    sectorManager.sectorText.text = "Knusse Kampeerplaats";
                    break;
                case "LakeSector":
                    sectorManager.sectorText.text = "Matige Meren";
                    break;
                case "FootballSector":
                    sectorManager.sectorText.text = "Diepe Doelen";
                    break;
                case "WaterTowerSector":
                    sectorManager.sectorText.text = "Woeste Wateren";
                    break;
                case "MountainSector":
                    sectorManager.sectorText.text = "Boze Bergen";
                    break;
                case "ForestHutSector":
                    sectorManager.sectorText.text = "Wazige Woud";
                    break;
            }
        }
    }
}
