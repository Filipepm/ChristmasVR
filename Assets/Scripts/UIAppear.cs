using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAppear : MonoBehaviour
{
    [SerializeField]
    private bool taskActive = false;
    [SerializeField]
    private bool turnOnTask = false;
    [SerializeField]
    private GameObject uiPanel;
    [SerializeField]
    private GameObject NPC;
    public void turnOn()
    {
        turnOnTask = true;
    }

    public void turnOnUI()
    {
        if (turnOnTask == true)
        {
            if (taskActive == false)
            {
                uiPanel.SetActive(true);
                taskActive = true;
                NPC.GetComponent<DialogueMayor>().firstText();
            }
            else if (taskActive == true)
            {
                uiPanel.SetActive(false);
                taskActive = false;
            }
        }
    }
}
