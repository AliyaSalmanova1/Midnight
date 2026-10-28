using UnityEngine;
using System.Collections.Generic;
using System;

public enum Character
{
    FATHER,
    DAUGHTER
}

public enum DialogueState
{
    AUTO,
    MANUAL
}

[Serializable]
public class ItemData
{
    public Character character;
    public string text;
}

[Serializable]
public class DialogueGroup
{
    public List<ItemData> dialogues = new List<ItemData>();
}

public class DialogueModel : MonoBehaviour
{

    public int dialogueIndex = 0;

    [SerializeField]
    public List<DialogueGroup> dialogueGroups = new List<DialogueGroup>();


    

}
