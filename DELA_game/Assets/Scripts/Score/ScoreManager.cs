using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Dictionary<string, int> npcScoreList;

    // Start is called before the first frame update
    void Start()
    {
        //fill dictioanry
        npcScoreList = new Dictionary<string, int>(
            new KeyValuePair<string, int>[]
            {
                new KeyValuePair<string, int>("NPCLake", 0),
                new KeyValuePair<string, int>("NPCWaterTower", 0),
                new KeyValuePair<string, int>("NPCFootball", 0),
                new KeyValuePair<string, int>("NPCForrestHut", 0),
                new KeyValuePair<string, int>("NPCMines", 0)
            }
        );
    }

    public void AddScore(string npcName)
    {
        if (npcScoreList.ContainsKey(npcName))
            npcScoreList[npcName]++;

        Debug.Log(npcName + " score: " + npcScoreList[npcName]);
    }

    public int GetScore(string npcName)
    {
        if (npcScoreList.ContainsKey(npcName))
            return npcScoreList[npcName];
        else
            return 0;
    }
}
