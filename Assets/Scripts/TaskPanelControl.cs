using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPanelControl : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject UICanvas;
    [SerializeField]
    private GameObject settingsPanel;
    [SerializeField]
    private GameObject taskPanel;
    private bool settings = false;
    private bool canvasOn = false;
    private bool isCoolDown = false;
    private float coolDown = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (settings == false)
        {
            if (InputBridge.Instance.YButton)
            {
                if (isCoolDown == false)
                {
                    settingsPanel.SetActive(false);
                    taskPanel.SetActive(true);
                    UIPanelToggle();
                    StartCoroutine(CoolDown());
                }
            }
        }

        if (InputBridge.Instance.XButton)
        {
            if (isCoolDown == false)
            {
                if(settings == false)
                {
                    settings = true;
                }
                else if (settings == true)
                {
                    settings = false;
                }

                Player.GetComponent<CharacterController>().enabled = canvasOn;
                settingsPanel.SetActive(true);
                taskPanel.SetActive(false);
                UIPanelToggle();
                StartCoroutine(CoolDown());
            }
        }
    }

    IEnumerator CoolDown()
    {
        isCoolDown = true;
        yield return new WaitForSeconds(coolDown);
        isCoolDown = false;
    }

    private void UIPanelToggle()
    {
        if (canvasOn == false)
        {
            canvasOn = true;
            UICanvas.SetActive(canvasOn);
        }
        else if (canvasOn == true)
        {
            canvasOn = false;
            UICanvas.SetActive(canvasOn);
        }
    }
}
