using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObstacleDisplay : MonoBehaviour, IPointerClickHandler
{
    //ASIGNO EL SCRIPTABLE OBJECT
    public Obstacle myObstacle;
    //ASIGNAMOS EL GAMEMANAGER
    private GameManager myMaster;

    private void Start()
    {
        //BUSCAMOS EL GAMEMANAGER
        myMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        //GameObject.FindObjectOfType<GameManager>();

        //ASIGNAMOS EL ANIMATOR
        myObstacle.obsAnimator = GetComponent<Animator>();
        myObstacle.ON = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //SI ES EL ESTAD ES PREP ACTIVAMOS EL INPUT
        if (myMaster.myGameStates == GameStates.PREP)
        {
            //APAGAMOS O ENCENDEMOS EL OBSTACULO
            myObstacle.ON = !myObstacle.ON;

            Debug.Log(myObstacle.ON);
            if (myObstacle.ON == true)
            {
                StartCoroutine(myObstacle.TurnOffObstacle());
            }
            else
            {
                StartCoroutine(myObstacle.TurnOnObstacle());
            }

            /*if (myObstacle.canActive == true)
            {
                if (myObstacle.ON == true)
                {
                    StartCoroutine(myObstacle.TurnOffObstacle());
                }
 
            }

            if (myObstacle.canActive == true && myObstacle.ON == false)
            {
                StartCoroutine(myObstacle.TurnOnObstacle());
            }*/

        }

    }

}
