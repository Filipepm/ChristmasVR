using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternCollision : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Lantern")
        {
            Debug.Log("yessir");
            this.gameObject.SetActive(false);
        }
    }
}
