using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueSentence
{
    [TextArea(3, 10)]
    public string sentence;
    public Collectible[] answer;
}

[System.Serializable]
public class Dialogue
{
    public string name;
    public DialogueSentence[] sentences;
}