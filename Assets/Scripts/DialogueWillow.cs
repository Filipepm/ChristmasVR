using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueWillow : MonoBehaviour
{
    [SerializeField]
    private GameObject responseButton;
    [SerializeField]
    private GameObject step;
    [SerializeField]
    private GameObject latern;
    [SerializeField]
    private GameObject laternComp;

    [SerializeField]
    private GameObject uiTaskList;

    [SerializeField]
    private Text willowDialogue;
    [SerializeField]
    private Text playerDialogue;

    [SerializeField]
    private TextWriter.TextWriterSingle textWriter;
    private bool hasPlayer = false;

    private string[] willowDialogueArray = new string[]
    {  "Ah I see, you must want something. Well what is it",
       "Of course I did. I'm an elf, I work with presents everyday.",
       "I don’t know what you’re talking about",
       "Fine, okay! I hid it behind my home through the dark path. Take my lantern to light the way.",
       "Take the Lantern and go through the dark path behind Willow’s home to find the Present",
       "That kid better enjoy that present more than I would've",};

    private string[] playerDialogueArray = new string[]
   {   "Have you seen any Presents?",
       "None just laying around?",
       "That fell from the sky?",
       "Thank you",
       "",
       ""};

    public void firstText()
    {
        if (hasPlayer == false)
        {
            string first = "Oh my gosh it’s about time she cut down that tree";
            textWriter = TextWriter.AddWriter_Static(willowDialogue, first, 0.03f, true, true);
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
                textWriter = TextWriter.AddWriter_Static(willowDialogue, willowDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 1:
                textWriter = TextWriter.AddWriter_Static(willowDialogue, willowDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 2:
                textWriter = TextWriter.AddWriter_Static(willowDialogue, willowDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 3:
                textWriter = TextWriter.AddWriter_Static(willowDialogue, willowDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 4:
                textWriter = TextWriter.AddWriter_Static(willowDialogue, willowDialogueArray[dialogueCount], 0.05f, true, true);
                uiTaskList.SetActive(true);
                responseButton.SetActive(false);
                CollisionOn();
                break;

            case 5:
                textWriter = TextWriter.AddWriter_Static(willowDialogue, willowDialogueArray[dialogueCount], 0.05f, true, true);
                TaskFinished();
                break;
        }
    }

    public void TaskFinished()
    {
        step.GetComponent<BaseStep>().DoneListener();
    }

    public void CollisionOn()
    {
        latern.GetComponent<BNG.Grabbable>().enabled = true;
        laternComp.SetActive(true);
    }
}