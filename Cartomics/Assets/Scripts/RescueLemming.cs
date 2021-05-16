using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueLemming : MonoBehaviour
{
    public GameObject myPrisioner;
    private MasterLemming myMasterLemming;

    private void Start()
    {
        myPrisioner.GetComponent<Collider>().enabled = false;
        myMasterLemming = FindObjectOfType<MasterLemming>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Lemmings>().isPrisioner == false)
        {
            Debug.Log("Ganaste un Lemming C:");
            myPrisioner.GetComponent<Collider>().enabled = true;
            myPrisioner.GetComponent<Lemmings>().InitLive();
            StartCoroutine(myPrisioner.GetComponent<Lemmings>().GoToTarget(myMasterLemming.goalPosition, 1.25f));
            gameObject.GetComponent<Collider>().enabled = false;

        }
    }
}
