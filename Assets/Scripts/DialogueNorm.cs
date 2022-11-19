using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueNorm : MonoBehaviour
{
    [SerializeField]
    private GameObject responseButton;
    [SerializeField]
    private GameObject step;

    [SerializeField]
    private GameObject uiTaskList;

    [SerializeField]
    private GameObject normDoor;
    [SerializeField]
    private Text normDialogue;
    [SerializeField]
    private Text playerDialogue;

    [SerializeField]
    private TextWriter.TextWriterSingle textWriter;
    private bool hasPlayer = false;

    private string[] normDialogueArray = new string[]
    {  "Are you talking about when it was raining presents?",
       "So they weren’t free?",
       "Welp finders keepers, losers weepers",
       "Okay you can have it, only if you do something for me",
       "The town is making us decorate our christmas trees' and I don’t have anything on it",
       "You mind hanging up all the Candy Canes on the table inside my home and put them on my tree?",
       "Place Candy Canes on Norm's Christmas Tree inside his home",
       "Thanks! Now the town can get off my ear’s about it"};

    private string[] playerDialogueArray = new string[]
   {   "Yes from Santa’s Sleigh",
       "No...",
       "I need that present back",
       "What do you need",
       "Continue",
       "Fine",
       ""};

    public void firstText()
    {
        if (hasPlayer == false)
        {
            string first = "Why does it always have to be cold here";
            textWriter = TextWriter.AddWriter_Static(normDialogue, first, 0.03f, true, true);
            hasPlayer = true;
        }
    }

    private int dialogueCount = -1;

    public void ChangeText()
    {
        dialogueCount++;
        Debug.Log(dialogueCount);
        switch (dialogueCount)
        {
            case 0:
                textWriter = TextWriter.AddWriter_Static(normDialogue, normDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 1:
                textWriter = TextWriter.AddWriter_Static(normDialogue, normDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 2:
                textWriter = TextWriter.AddWriter_Static(normDialogue, normDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 3:
                textWriter = TextWriter.AddWriter_Static(normDialogue, normDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 4:
                textWriter = TextWriter.AddWriter_Static(normDialogue, normDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 5:
                textWriter = TextWriter.AddWriter_Static(normDialogue, normDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 6:
                textWriter = TextWriter.AddWriter_Static(normDialogue, normDialogueArray[dialogueCount], 0.05f, true, true);
                NormDoorOpen();
                uiTaskList.SetActive(true);
                responseButton.SetActive(false);
                break;

            case 7:
                textWriter = TextWriter.AddWriter_Static(normDialogue, normDialogueArray[dialogueCount], 0.05f, true, true);
                TaskFinished();
                break;
        }
    }

    public void TaskFinished()
    {
        step.GetComponent<BaseStep>().DoneListener();
    }

    public void NormDoorOpen()
    {
        normDoor.SetActive(true);
    }
}