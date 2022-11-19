using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollision : MonoBehaviour
{
    private float candyCaneNum = 0;
    private bool hasCollide = false;
    [SerializeField]
    private GameObject normTask;
    [SerializeField]
    private GameObject normTaskUI;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "CandyCane")
        {
            candyCaneNum += 1;
            normTaskUI.GetComponent<CandyCaneUI>().ChangeColor();
            Debug.Log("Candy Cane=" + candyCaneNum);
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            collision.gameObject.GetComponent<BNG.Grabbable>().enabled = false;
            Debug.Log(candyCaneNum);
            if (candyCaneNum == 5)
            {
                normTask.GetComponent<DialogueNorm>().ChangeText();
            }
            
        }
    }
}
