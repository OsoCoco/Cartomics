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
    public bool isPrisioner = false;

    //ASIGNAMOS LA LAYER DE LOS OBSTACULOS
    public LayerMask maskObstacle;

    //TIEMPO PARA PERDER SI LOS LEMMINGS CHOCAN CON UN OBSTACULO
    public float timeToLose;
    private float startTime;

    private void Start()
    {
        //BUSCAMOS AL PAPÁ Y AL NAVMESH AGENTE Y LOS CARGAMOS
        myDady = FindObjectOfType<MasterLemming>();
        myAgent = gameObject.GetComponent<NavMeshAgent>();

        //LLAMAMOS LA FUNCION
        if (isPrisioner == false)
        {
            InitLive();
        }


        //Igualamos los tiempos
        startTime = timeToLose;
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        //DIBUJAMOS Y CREAMOS UN RAY CAST QUE CHECA SI LOS LEMMINGS CHOCAN CON UN OBSTACULO
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1, maskObstacle))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            if (timeToLose > 0)
            {
                timeToLose -= Time.fixedDeltaTime;
                
            }
            else
            {
                if(myDady.lemmingsAlive.Count>0)
                {
                    Dead();
                    myDady.CheckForLost();

                }

            }

        }
        else
        {
            timeToLose = startTime;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
    }
    //INICIALIZAMOS AL LEMMING Y LO AGREGAMOS CON SU PAPI UWU
    public void InitLive()
    {
        myDady.lemmingsAlive.Add(this);
    }

    //SE MUERE EL LEMMING Y LO QUITAMOS DE SU PAPI U.U
    public void Dead()
    {
        isLive = false;
        myDady.lemmingsDeath.Add(this);
        myDady.UpdateList(this);
        gameObject.SetActive(false);
    }

    //MANDAMOS AL LEMMING A SU DESTINO
    public IEnumerator GoToTarget(Transform myTarget, float delay)
    {
        yield return new WaitForSeconds(delay);
        myAgent.SetDestination(myTarget.position);
    }


}
