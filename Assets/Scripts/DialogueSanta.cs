using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSanta : MonoBehaviour
{
    [SerializeField]
    private GameObject uiCancel;
    [SerializeField]
    private GameObject responseButton;
    [SerializeField]
    private Text santaDialogue;
    [SerializeField]
    private Text playerDialogue;
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private TextWriter.TextWriterSingle textWriter;
    private bool hasPlayer = false;

    private string[] santaDialogueArray = new string[]
    {  "Thank you so much for finding those presents! That bad weather hit us pretty hard, I thought we would never be able to find those presents",
       "Luckly for us, all kids are going to recieve their presents this year! All thanks to you!",
       "Now if you'll excuse me, I'm going to start my streches before take off again"};

    private string[] playerDialogueArray = new string[]
   {   "Continue",
       "No Problem!",
       "Good Luck!"};

    public void firstText()
    {
        if (hasPlayer == false)
        {
            string first = "Late as usual, I see. Here’s the deal: Santa hit some bad weather on his way to deliver presents";
            textWriter = TextWriter.AddWriter_Static(santaDialogue, first, 0.03f, true, true);
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
                textWriter = TextWriter.AddWriter_Static(santaDialogue, santaDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 1:
                textWriter = TextWriter.AddWriter_Static(santaDialogue, santaDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 2:
                textWriter = TextWriter.AddWriter_Static(santaDialogue, santaDialogueArray[dialogueCount], 0.05f, true, true);
                playerDialogue.text = playerDialogueArray[dialogueCount];
                break;

            case 3:
                uiCancel.SetActive(false);
                AnimationCheck();
                break;
        }
    }
    public void AnimationCheck()
    {
        anim.SetBool("stretch", true);
    }
}
