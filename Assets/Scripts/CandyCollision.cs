using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyCollision : MonoBehaviour
{
    [SerializeField]
    private GameObject normTask;
    private bool hasCollide = false;
    public void CollisionOn()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "CustomHandRightBlackNew" || collision.gameObject.name == "CustomHandLeftBlackNew")
        {
            if (hasCollide == false)
            {
                hasCollide = true;
                this.gameObject.SetActive(false);
                normTask.GetComponent<CandyCaneUI>().ChangeColor();
            }
        }
    }
}
