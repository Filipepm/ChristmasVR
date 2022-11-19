using ChristmasLogvillage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueLola : MonoBehaviour
{
    [SerializeField]
    private GameObject responseButton;
    [SerializeField]
    private GameObject step;

    [SerializeField]
    private GameObject tree;
    [SerializeField]
    private GameObject axe;
    [SerializeField]
    private Rigidbody rigidbodyAxe;
    [SerializeField]
    private GameObject axeChild;
    [SerializeField]
    private GameObject willowDoor;
    public bool taskActive = false;

    [SerializeField]
    private GameObject uiTaskList;

    [SerializeField]
    private Text lolaDialogue;
    [SerializeField]
    private Text playerDialogue;

    [SerializeField]
    private TextWriter.TextWriterSingle textWriter;
    private bool hasPlayer = false;

    private string[] lolaDialogueArray = new string[]
    {  "No but I did see an elf called Willow take one into her home.",
       "By the water mill but good luck, she’s locked her door and hasn’t let anyone in.",
       "She asked me if I could cut down a tree for her today and got mad when I said I don’t work on holidays.",
       "If you want you can take my axe from my yard and cut the tree down for me. Maybe she’ll open the door for you",
       "Grab Lola’s Axe behind her and cut down the tree in front of Willow’s home. She lives next to the Water Mill.",
       "Nice work! Good luck with Willow!"};

    private string[] playerDialogueArray = new string[]
   {   "Where does she live?",
       "Why’s that?",
       "Continue",
       "Continue",
       "",
       ""};

    public void firstText()
    {
        if (hasPlayer == false)
        {
            string first = "What a jolly-good night it is!";
            textWriter = TextWriter.AddWriter_Static(lolaDialogue, first, 0.03f, true, true);
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
                textWriter = TextWriter.AddWriter_Static(lolaDialogue, lolaDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 1:
                textWriter = TextWriter.AddWriter_Static(lolaDialogue, lolaDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 2:
                textWriter = TextWriter.AddWriter_Static(lolaDialogue, lolaDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 3:
                textWriter = TextWriter.AddWriter_Static(lolaDialogue, lolaDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 4:
                textWriter = TextWriter.AddWriter_Static(lolaDialogue, lolaDialogueArray[dialogueCount], 0.05f, true, true);
                responseButton.SetActive(false);
                taskActive = true;
                uiTaskList.SetActive(true);
                break;

            case 5:
                textWriter = TextWriter.AddWriter_Static(lolaDialogue, lolaDialogueArray[dialogueCount], 0.05f, true, true);
                TaskFinished();
                WillowDoorOpen();
                break;
        }
    }

    public void TaskFinished()
    {
        step.GetComponent<BaseStep>().DoneListener();
    }

    public void Axe()
    {
        if (taskActive == true)
        {
            rigidbodyAxe.constraints = RigidbodyConstraints.None;
            axe.GetComponent<BNG.Grabbable>().enabled = true;
            axeChild.SetActive(true);
        }
    }

    public void WillowDoorOpen()
    {
        willowDoor.SetActive(true);
    }
}