using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Dictionary<string, NPCInteractState> npcScoreList;

    public UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        //fill dictioanry
        npcScoreList = new Dictionary<string, NPCInteractState>(
            new KeyValuePair<string, NPCInteractState>[]
            {
                new KeyValuePair<string, NPCInteractState>("NPCLake", new NPCInteractState { Score = 0, IsInteracted = false }),
                new KeyValuePair<string, NPCInteractState>("NPCWaterTower", new NPCInteractState { Score = 0, IsInteracted = false }),
                new KeyValuePair<string, NPCInteractState>("NPCFootball", new NPCInteractState { Score = 0, IsInteracted = false }),
                new KeyValuePair<string, NPCInteractState>("NPCForrestHut", new NPCInteractState { Score = 0, IsInteracted = false }),
                new KeyValuePair<string, NPCInteractState>("NPCMines", new NPCInteractState { Score = 0, IsInteracted = false })
            }

        );
    }

    public void AddScore(string npcName)
    {
        if (npcScoreList.ContainsKey(npcName))
            npcScoreList[npcName].Score++;

        Debug.Log(npcName + " score: " + npcScoreList[npcName].Score);
    }

    public void SetInteracted(string npcName)
    {
        if (npcScoreList.ContainsKey(npcName))
            npcScoreList[npcName].IsInteracted = true;

        CheckAllNPCsInteracted();
    }

    public void CheckAllNPCsInteracted()
    {
        if (npcScoreList.All(npc => npc.Value.IsInteracted))
        {
            Debug.Log("All NPCs interacted");
            uiManager.ShowWhyInfoPanel();
        }
    }

    public int GetScore(string npcName)
    {
        if (npcScoreList.ContainsKey(npcName))
            return npcScoreList[npcName].Score;
        else
            return 0;
    }
}

public class NPCInteractState
{
    public int Score = 0;
    public bool IsInteracted = false;
}