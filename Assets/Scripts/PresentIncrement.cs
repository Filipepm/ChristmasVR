using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentIncrement : MonoBehaviour
{
    [SerializeField]
    private GameObject mayorTask;
    [SerializeField]
    private Text presentCountText;
    public float presentCount = 0;

    public void PresentCount()
    {
        presentCount += 1;
        presentCountText.text = presentCount.ToString();
        if(presentCount == 7)
        {
            mayorTask.GetComponent<DialogueMayor>().ChangeText();
        }
    }
}
