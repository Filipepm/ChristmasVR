using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseCollision : MonoBehaviour
{
    [SerializeField]
    private GameObject reindeerTask;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "CustomHandRightBlackNew" || collision.gameObject.name == "CustomHandLeftBlackNew")
        {
            reindeerTask.GetComponent<DialogueReindeer>().Nose();
        }
    }
}