using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueSnowman : MonoBehaviour
{
    [SerializeField]
    private GameObject responseButton;
    [SerializeField]
    private GameObject step;
    [SerializeField]
    private GameObject mayorPrefab;

    [SerializeField]
    private GameObject snow1;
    [SerializeField]
    private GameObject snow1Comp;
    [SerializeField]
    private GameObject snow2;
    [SerializeField]
    private GameObject snow2Comp;

    [SerializeField]
    private Text snowmanDialogue;
    [SerializeField]
    private Text playerDialogue;

    [SerializeField]
    private GameObject uiTaskList;
    [SerializeField]
    private GameObject uiTaskList2;

    [SerializeField]
    private TextWriter.TextWriterSingle textWriter;
    private bool hasPlayer = false;

    private string[] mayorDialogueArray = new string[]
    {  "Presents? I don’t know anything about them. Maybe you could help me get taller to refresh my memory.",
       "Find the Snowman some Snow",
       "Wow! I grew a bit! but not enough... Could you find some more snow for me?",
       "Thank you, friend! I feel like a new snowman. Now about those presents…",
       "The presents fell from the sky and scattered all around the village. I’d help you look for them, but I don’t have arms or legs.",
       ""};

    private string[] playerDialogueArray = new string[]
   {   "Weird, but okay.",
       "",
       "",
       "Continue",
       "Thanks!",
       ""};

    public void firstText()
    {
        if (hasPlayer == false)
        {
            string first = "It’s hard to be a little snowman in a big winter wonderland. If only I was taller...";
            textWriter = TextWriter.AddWriter_Static(snowmanDialogue, first, 0.03f, true, true);
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
                uiTaskList.SetActive(false);
                textWriter = TextWriter.AddWriter_Static(snowmanDialogue, mayorDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 1:
                uiTaskList2.SetActive(true);
                textWriter = TextWriter.AddWriter_Static(snowmanDialogue, mayorDialogueArray[dialogueCount], 0.05f, true, true);
                Snow();
                responseButton.SetActive(false);
                break;

            case 2:
                textWriter = TextWriter.AddWriter_Static(snowmanDialogue, mayorDialogueArray[dialogueCount], 0.05f, true, true);
                break;

            case 3:
                textWriter = TextWriter.AddWriter_Static(snowmanDialogue, mayorDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                uiTaskList2.SetActive(false);
                responseButton.SetActive(true);
                break;

            case 4:
                textWriter = TextWriter.AddWriter_Static(snowmanDialogue, mayorDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 5:
                TaskFinished();
                mayorPrefab.GetComponent<DialogueMayor>().ChangeText();
                break;

        }
    }

    public void TaskFinished()
    {
        step.GetComponent<BaseStep>().DoneListener();
    }

    public void Snow()
    {
        snow1.GetComponent<BNG.Grabbable>().enabled = true;
        snow1Comp.SetActive(true);

        snow2.GetComponent<BNG.Grabbable>().enabled = true;
        snow2Comp.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Snow")
        {
            Debug.Log("YEY");
            this.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            collision.gameObject.SetActive(false);
            ChangeText();
        }
    }
}
