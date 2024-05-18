using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SectorManager : MonoBehaviour
{
    public TextMeshProUGUI sectorText;
    public CollectibleManager collectibleManager;
    private string _currentSector = "Knusse Kampeerplaats";

    public string CurrentSector {
        get { 
            return _currentSector;
        }
        set {
            if(_currentSector != value) {
                _currentSector = value;
                sectorText.text = value;
                collectibleManager.UpdateCollectableCanvas();
            }
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        collectibleManager.UpdateCollectableCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
