using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public NavMeshAgent myAgent;
    public Transform goal;

    public void Start()
    {
        StartCoroutine(GoToTarget(goal));
    }

    public IEnumerator GoToTarget(Transform myTarget)
    {
        myAgent.SetDestination(myTarget.position);
        yield return null;
    }
}
