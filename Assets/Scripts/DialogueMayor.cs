using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueMayor : MonoBehaviour
{
    [SerializeField]
    private GameObject fadetrigger;
    [SerializeField]
    private GameObject santa;

    [SerializeField]
    private GameObject uiCancel;
    [SerializeField]
    private GameObject responseButton;
    [SerializeField]
    private GameObject step;
    [SerializeField]
    private GameObject stepp2;
    [SerializeField]
    private GameObject stepmain;
    [SerializeField]
    private Text mayorDialogue;
    [SerializeField]
    private Text playerDialogue;

    [SerializeField]
    private TextWriter.TextWriterSingle textWriter;
    private bool hasPlayer = false; 


    private string[] mayorDialogueArray = new string[]
    {  "We need your help to find the presents so Santa can deliver them on time.",
       "If I knew that, I wouldn’t need you. I think the Snowman near town center might have seen something though.",
       "Talk to the Snowman near the Town Center",
       "Hmmm the snowman told you they scattered around the village? The elfs and creatures probably know something about this",
       "Talk to Town Residents and find the Presents",
       "Well Done! You saved Christmas!",
       "You saved Christmas!"};

    private string[] playerDialogueArray = new string[]
   {   "Where are the presents?",
       "Finish",
       "",
       "Continue",
       "Alright!",
       "Woohoo!"};


    public void firstText()
    {   if (hasPlayer == false)
        {
            string first = "Late as usual, I see. Here’s the deal: Santa hit some bad weather on his way to deliver presents";
            textWriter = TextWriter.AddWriter_Static(mayorDialogue, first, 0.03f, true, true);
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
                textWriter = TextWriter.AddWriter_Static(mayorDialogue, mayorDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 1:
                textWriter = TextWriter.AddWriter_Static(mayorDialogue, mayorDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 2:
                textWriter = TextWriter.AddWriter_Static(mayorDialogue, mayorDialogueArray[dialogueCount], 0.05f, true, true);
                responseButton.SetActive(false);
                StepComplete(step);
                break;

            case 3:
                textWriter = TextWriter.AddWriter_Static(mayorDialogue, mayorDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                responseButton.SetActive(true);
                break;

            case 4:
                textWriter = TextWriter.AddWriter_Static(mayorDialogue, mayorDialogueArray[dialogueCount], 0.05f, true, true);
                responseButton.SetActive(false);
                StepComplete(stepp2);
                break;

            case 5:
                textWriter = TextWriter.AddWriter_Static(mayorDialogue, mayorDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                responseButton.SetActive(true);
                break;

            case 6:
                textWriter = TextWriter.AddWriter_Static(mayorDialogue, mayorDialogueArray[dialogueCount], 0.05f, true, true);
                responseButton.SetActive(false);
                fadetrigger.GetComponent<BNG.ScreenFader>().DoFadeIn();
                StartCoroutine(WaitBeforeTeleport());
                StepComplete(stepmain);
                break;
        }
    }

    public void StepComplete(GameObject gameObject)
    {
        gameObject.GetComponent<BaseStep>().DoneListener();
    }

    IEnumerator WaitBeforeTeleport()
    {
        yield return new WaitForSeconds(2f);
        fadetrigger.GetComponent<BNG.ScreenFader>().DoFadeOut();
        santa.SetActive(true);
    }
}
