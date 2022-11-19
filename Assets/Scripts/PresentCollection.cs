using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentCollection : MonoBehaviour
{
    [SerializeField]
    private GameObject presentCount;
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
            }
        }
    }
}
