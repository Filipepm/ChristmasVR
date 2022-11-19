using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AxeTouch : MonoBehaviour
{
    public GameObject lolaTask;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player touched");
            lolaTask.GetComponent<DialogueLola>().Axe();
        }
    }
}
