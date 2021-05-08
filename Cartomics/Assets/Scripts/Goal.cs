using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //ASIGNAMOS EL GAMEMANAGER
    private GameManager myMaster;
    private MasterLemming myMasterLemming;

    //BUSCAMOS EL GAMEMANAGER
    private void Start()
    {
        myMaster = FindObjectOfType<GameManager>();
        myMasterLemming = FindObjectOfType<MasterLemming>();
    }

    //CONTAMOS LOS LEMMINGS QUE LLEGAN A LA META Y LOS DESACTIVAMOS UWU
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Lemmings>() == true)
        {
            //Actualizamos la lista de los lemmings vivos :D

            myMaster.lemmings += 1;
            other.gameObject.SetActive(false);

            //PREGUNTAMOS SI LA CANTIDAD DE LEMMINGS VIVOS ES IGUAL A LOS QUE LLEGARON A LA META PARA LLAMAR LA FUNCION WIN
            if (myMaster.lemmings == myMasterLemming.lemmingsAlive.Count)
            {
                myMaster.WIN();
            }
        }
    }
}
