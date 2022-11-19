using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentWillow : MonoBehaviour
{
    [SerializeField]
    private GameObject presentCount;
    [SerializeField]
    private GameObject willowTask;
    private bool hasCollide = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "CustomHandRightBlackNew" || collision.gameObject.name == "CustomHandLeftBlackNew")
        {
            if (hasCollide == false)
            {
                hasCollide = true;
                this.gameObject.SetActive(false);
                presentCount.GetComponent<PresentIncrement>().PresentCount();
                willowTask.GetComponent<DialogueWillow>().ChangeText();
            }
        }
    }
}
