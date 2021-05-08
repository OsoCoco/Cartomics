using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Lemmings : MonoBehaviour
{
    //ASIGNAMOS EL PAPÁ DE LOS LEMMINGS
    private MasterLemming myDady;

    //ASIGNAMOS EL AGENTE DE NAVMESH
    private NavMeshAgent myAgent;

    //ASIGNAMOS SI ESTAN VIVOS O NO :O
    public bool isLive = true;

    private void Start()
    {
        //BUSCAMOS AL PAPÁ Y AL NAVMESH AGENTE Y LOS CARGAMOS
        myDady = FindObjectOfType<MasterLemming>();
        myAgent = gameObject.GetComponent<NavMeshAgent>();

        //LLAMAMOS LA FUNCION
        InitLive();
    }


    //INICIALIZAMOS AL LEMMING Y LO AGREGAMOS CON SU PAPI UWU
    public void InitLive()
    {
        myDady.lemmingsAlive.Add(this);
    }

    //MANDAMOS AL LEMMING A SU DESTINO
    public void GoToTarget(Transform myTarget)
    {
        myAgent.SetDestination(myTarget.position);
    }

    //SE MUERE EL LEMMING Y LO QUITAMOS DE SU PAPI U.U
    public void Dead()
    {
        isLive = false;
        myDady.lemmingsAlive.Remove(this);
    }
}
