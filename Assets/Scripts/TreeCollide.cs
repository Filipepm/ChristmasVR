using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollide : MonoBehaviour
{
    [SerializeField]
    private GameObject treeStub;
    [SerializeField]
    private GameObject lolaStep;
    [SerializeField]
    private float treeHealth = 3;
    [SerializeField]
    private GameObject woodParticle;
    private bool hasCollide = false;
    [SerializeField]
    private AudioSource woodHit;

    void Start()
    { }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Axe")
        {
                woodHit.Play();
                treeHealth--;
                Explode();
                if (treeHealth == 0) 
                {
                    treeStub.SetActive(true);
                    gameObject.SetActive(false);
                    lolaStep.GetComponent<DialogueLola>().ChangeText();
                }
            
        }
    }

    void Explode()
    {
        GameObject woodparticle = Instantiate(woodParticle, new Vector3(1205.59f, 31f, 1025.87f), Quaternion.identity);
        woodParticle.GetComponent<ParticleSystem>().Play();
    }
}
