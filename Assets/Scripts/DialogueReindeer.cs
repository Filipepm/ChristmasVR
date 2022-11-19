using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueReindeer : MonoBehaviour
{
    [SerializeField]
    private GameObject present;
    [SerializeField]
    private GameObject responseButton;
    [SerializeField]
    private GameObject step;
    [SerializeField]
    private Text reindeerDialogue;
    [SerializeField]
    private Text playerDialogue;

    [SerializeField]
    private GameObject uiTaskList;

    [SerializeField]
    private GameObject redNose;
    [SerializeField]
    private GameObject nose;
    [SerializeField]
    private GameObject noseComp;
    [SerializeField]
    private Rigidbody rigidbodyNose;
    public bool taskActive = false;

    [SerializeField]
    private TextWriter.TextWriterSingle textWriter;
    private bool hasPlayer = false;

    private string[] reindeerDialogueArray = new string[]
    {  "I’m too sad to think about that right now. If only I had a red nose, maybe that would help.",
       "Find the Reindeer a Red Nose",
       "It’s amazing! I can’t wait to join in all the reindeer games!",
       "Ahh yes there is one top of this house behind me, all you need to do is climb up from the back!",
       "Grab the present on top of the house behind the Deer"};

    private string[] playerDialogueArray = new string[]
   {   "I'll see what I can do",
       "",
       "So... Seen any presents?",
       "Thanks!",
       ""};

    public void firstText()
    {
        if (hasPlayer == false)
        {
            string first = "Sigh… All of the other reindeer used to laugh and call him names, but now everyone thinks Rudolph is so cool.";
            textWriter = TextWriter.AddWriter_Static(reindeerDialogue, first, 0.03f, true, true);
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
                textWriter = TextWriter.AddWriter_Static(reindeerDialogue, reindeerDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 1:
                textWriter = TextWriter.AddWriter_Static(reindeerDialogue, reindeerDialogueArray[dialogueCount], 0.05f, true, true);
                taskActive = true;
                uiTaskList.SetActive(true);
                responseButton.SetActive(false);
                break;

            case 2:
                textWriter = TextWriter.AddWriter_Static(reindeerDialogue, reindeerDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                responseButton.SetActive(true);
                break;

            case 3:
                textWriter = TextWriter.AddWriter_Static(reindeerDialogue, reindeerDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 4:
                textWriter = TextWriter.AddWriter_Static(reindeerDialogue, reindeerDialogueArray[dialogueCount], 0.05f, true, true);
                present.SetActive(true);
                responseButton.SetActive(false);
                StepComplete(step);
                break;
        }
    }

    public void StepComplete(GameObject gameObject)
    {
        gameObject.GetComponent<BaseStep>().DoneListener();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Nose")
        {
            collision.gameObject.SetActive(false);
            redNose.SetActive(true);
            ChangeText();
        }
    }

    public void Nose()
    {
        if (taskActive == true)
        {
            rigidbodyNose.constraints = RigidbodyConstraints.None;
            nose.GetComponent<BNG.Grabbable>().enabled = true;
            noseComp.SetActive(true);
        }
    }
}