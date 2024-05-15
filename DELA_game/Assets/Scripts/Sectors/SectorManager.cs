using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SectorManager : MonoBehaviour
{
    public TextMeshProUGUI sectorText;
    public string _currentSector {
        set {
            _currentSector = value;
            sectorText.text = value;
        }
    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
