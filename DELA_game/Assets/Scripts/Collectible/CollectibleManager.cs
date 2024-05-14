using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
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
}
