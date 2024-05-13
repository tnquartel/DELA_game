using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour
{
    public Sprite sprite;
    public string npcName;
    public Text nameText;
    public Image spriteObject;

    void Start()
    {
        nameText.text = npcName;
        spriteObject.sprite = sprite;
    }
}
