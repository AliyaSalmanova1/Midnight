
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;





public class DialogueUI : MonoBehaviour
{
    public TMP_Text daughterDialogueText;

    public TMP_Text fatherDialogueText;


    
    public void ClearDialogue()
    {
        daughterDialogueText.text = "";
        fatherDialogueText.text = "";
    }

    public void ChangeDaughterDialogue(string text)
    {
        daughterDialogueText.text = text;
        fatherDialogueText.text = "";
    }
    
    public void ChangeFatherDialogue(string text)
    {
        fatherDialogueText.text = text;
        daughterDialogueText.text = "";
    }
}