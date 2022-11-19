using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeCollision : MonoBehaviour
{
    [SerializeField]
    private GameObject lolaTask;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "CustomHandRightBlackNew" || collision.gameObject.name == "CustomHandLeftBlackNew")
        {
            lolaTask.GetComponent<DialogueLola>().Axe();
        }
    }
}
