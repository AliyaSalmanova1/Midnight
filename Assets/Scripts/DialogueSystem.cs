using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum DialogueState
{
    AUTO,
    MANUAL
}

public enum Character
{
    FATHER,
    DAUGHTER
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


public class DialogueSystem : MonoBehaviour
{

    public InputActionsController inputActionsController;
    public FatherDisappearingBehavior fatherDisappearingBehavior;

    public TMP_Text daughterDialogueText;

    public TMP_Text fatherDialogueText;


    int dialogueIndex = 0;

    [SerializeField]
    private List<DialogueGroup> dialogueGroups = new List<DialogueGroup>();


    public float dialogueSwitcherSpeed = 2f;

    

    void Start()
    {
        fatherDisappearingBehavior = FindAnyObjectByType<FatherDisappearingBehavior>();
        inputActionsController = FindAnyObjectByType<InputActionsController>();

        inputActionsController.DisableInputActions();
        StartCoroutine(SwitchDialogueAutomatically());
    }

    

    

    IEnumerator SwitchDialogueAutomatically()
    {

        int interludeIndex = PlayerPrefs.GetInt("CurrentInterlude");
        

        while (dialogueIndex < dialogueGroups[interludeIndex].dialogues.Count)
        {
            
            switch (dialogueGroups[interludeIndex].dialogues[dialogueIndex].character)
            {
                case Character.DAUGHTER: 
                    daughterDialogueText.text = dialogueGroups[interludeIndex].dialogues[dialogueIndex].text;
                    fatherDialogueText.text = "";
                    break;
                case Character.FATHER: 
                    fatherDialogueText.text = dialogueGroups[interludeIndex].dialogues[dialogueIndex].text;
                    daughterDialogueText.text = "";
                    break;

            }
            dialogueIndex++;
    
            yield return new WaitForSeconds(dialogueSwitcherSpeed);

            if (dialogueIndex == dialogueGroups[interludeIndex].dialogues.Count)
            {
                fatherDisappearingBehavior.DestroyFather();
                daughterDialogueText.text = "";
                fatherDialogueText.text = "";
                inputActionsController.EnableGirlInterludeMovements();
                StopCoroutine(SwitchDialogueAutomatically());
                
            }
        }
        
    }

    public void SwitchDialogueManually()
    {
        
    }






}