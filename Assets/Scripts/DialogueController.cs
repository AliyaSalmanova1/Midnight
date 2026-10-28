using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts;




public class DialogueController : MonoBehaviour
{

    public InputActionsController inputActionsController;
    public FatherDisappearingBehavior fatherDisappearingBehavior;

    

    public DialogueUI dialogueUI;

    public DialogueModel dialogueModel;

    

    void Start()
    {
        fatherDisappearingBehavior = FindAnyObjectByType<FatherDisappearingBehavior>();
        inputActionsController = FindAnyObjectByType<InputActionsController>();


        if (dialogueUI == null)
        {
            dialogueUI = FindAnyObjectByType<DialogueUI>();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Girl"))
        {
            StartDialogueCoroutine();
        }
    }


    void StartDialogueCoroutine()
    {
        inputActionsController.DisableInputActions();
        StartCoroutine(SwitchDialogueAutomatically());
    }

    

    

    IEnumerator SwitchDialogueAutomatically()
    {

        int interludeIndex = PlayerPrefs.GetInt("CurrentInterlude");
        

        while (dialogueModel.dialogueIndex < dialogueModel.dialogueGroups[interludeIndex].dialogues.Count)
        {
            
            switch (dialogueModel.dialogueGroups[interludeIndex].dialogues[dialogueModel.dialogueIndex].character)
            {
                case Character.DAUGHTER: 
                    dialogueUI.ChangeDaughterDialogue(dialogueModel.dialogueGroups[interludeIndex].dialogues[dialogueModel.dialogueIndex].text);
                    break;
                case Character.FATHER: 
                    dialogueUI.ChangeFatherDialogue(dialogueModel.dialogueGroups[interludeIndex].dialogues[dialogueModel.dialogueIndex].text);
                    break;

            }
            dialogueModel.dialogueIndex++;
    
            yield return new WaitForSeconds(Config.dialogueSwitcherSpeed);

            if (dialogueModel.dialogueIndex == dialogueModel.dialogueGroups[interludeIndex].dialogues.Count)
            {
                fatherDisappearingBehavior.DestroyFather();
                dialogueUI.ClearDialogue();
                inputActionsController.EnableGirlInterludeMovements();
                StopCoroutine(SwitchDialogueAutomatically());
                
            }
        }
        
    }

    public void SwitchDialogueManually()
    {
        
    }






}