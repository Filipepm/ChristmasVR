using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueSnowlady : MonoBehaviour
{
    [SerializeField]
    private GameObject responseButton;
    [SerializeField]
    private GameObject step;
    [SerializeField]
    private GameObject present;
    [SerializeField]
    private GameObject mistletoe;
    [SerializeField]
    private GameObject mistletoe2;

    [SerializeField]
    private Text snowladyDialogue;
    [SerializeField]
    private Text playerDialogue;

    [SerializeField]
    private GameObject uiTaskList;

    [SerializeField]
    private TextWriter.TextWriterSingle textWriter;
    private bool hasPlayer = false;

    private string[] snowladyDialogueArray = new string[]
    {  "Listen, I overheard your conversation with the snowman and I might just know the whereabouts of a present. Bring me a mistletoe and I’ll tell you where it is",
       "Find a Mistletoe",
       "Thank you! So about that present. I can still see the present! You might want to watch your head.",
       ""};

    private string[] playerDialogueArray = new string[]
   {   "Alright then",
       "",
       "Huh?",
       ""};

    public void firstText()
    {
        if (hasPlayer == false)
        {
            string first = "Wow! The snowman is so big and strong now! ";
            textWriter = TextWriter.AddWriter_Static(snowladyDialogue, first, 0.03f, true, true);
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
                textWriter = TextWriter.AddWriter_Static(snowladyDialogue, snowladyDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 1:
                textWriter = TextWriter.AddWriter_Static(snowladyDialogue, snowladyDialogueArray[dialogueCount], 0.05f, true, true);
                EnableMistletoe();
                uiTaskList.SetActive(true);
                responseButton.SetActive(false);
                break;

            case 2:
                textWriter = TextWriter.AddWriter_Static(snowladyDialogue, snowladyDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                responseButton.SetActive(true);
                break;

            case 3:
                TaskFinished();
                break;
        }
    }

    public void TaskFinished()
    {
        step.GetComponent<BaseStep>().DoneListener();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Mistletoe")
        {
            //collision.gameObject.transform.localPosition = new Vector3(6.78894f, 1.524f, 14.97498f);
            //collision.gameObject.transform.localRotation = Quaternion.Euler(0.44f, -47.57f, -1.025f);
            //mistletoe.constraints = RigidbodyConstraints.FreezeAll;
            mistletoe.SetActive(false);
            mistletoe2.SetActive(true);
            ChangeText();
        }
    }

    private void EnableMistletoe()
    {
        mistletoe.GetComponent<BNG.Grabbable>().enabled = true;
    }
}