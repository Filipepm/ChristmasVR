using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    [SerializeField]
	private GameObject Player;    
    private GameObject playerFade;
    [SerializeField]
    private bool allow = false;
    private bool hasCollide = false;

    private void Start()
    {
        hasCollide = false;
        playerFade = GameObject.FindWithTag("MainCamera");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (allow == true && collision.gameObject.name == "CustomHandRightBlackNew")
        {
            if (hasCollide == false)
            {
                hasCollide = true;
                playerFade.GetComponent<BNG.ScreenFader>().DoFadeIn();
                StartCoroutine(WaitBeforeTeleport());   
            }
        }
    }

    IEnumerator WaitBeforeTeleport()
    {
        yield return new WaitForSeconds(2f);
        playerFade.GetComponent<BNG.ScreenFader>().DoFadeOut();
    }

    public void Teleport()
    {
        Debug.Log("yes22");
        gameObject.GetComponent<BNG.TeleportDestination>();
        playerFade.GetComponent<BNG.ScreenFader>().DoFadeOut();
    }
}
