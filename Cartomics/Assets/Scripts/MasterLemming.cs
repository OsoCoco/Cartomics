using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterLemming : MonoBehaviour
{
    //ASIGNAMOS EL GAMEMANAGER
    private GameManager myMaster;

    //ASIGNAMOS LA META DEL NIVEL Y LOS LEMMINGS VIVOS
    public Transform goalPosition;
    public List<Lemmings> lemmingsAlive;
    public List<Lemmings> lemmingsDeath;
    //
    public float delayToGo;

    private void Start()
    {
        //BUSCAMOS AL GAMEMANAGER
        myMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    //FUNCION PARA ASIGNARLE AL NAVMESH AGENT SU META DE DESTINO Y MOVER TODOS LOS LEMMINGS
    public IEnumerator GoBoys()
    {
        if (myMaster.myGameStates == GameStates.GAME)
        {
            Debug.Log("GO BOYS");
            float myDelay = 0;
            for (int i = 0; i <= lemmingsAlive.Count - 1; i++)
            {
                myDelay += 1;
                StartCoroutine(lemmingsAlive[i].GoToTarget(goalPosition, myDelay));
            }
           yield return null;
        }

    }

    //ACTUALIZAMOS LA LISTA DE LOS LEMMINGS VIVOS
    public void UpdateList(Lemmings myBoyDead)
    {
        /*foreach(Lemmings l in lemmingsDeath)
        {
            if(lemmingsAlive.Contains(l))
            {
                lemmingsAlive.Remove(l);
            }
            else
            {
                return;
            }
        }/*/
        if(lemmingsAlive.Contains(myBoyDead))
        {
            lemmingsAlive.Remove(myBoyDead);
        }
        else
        {
            return;
        }

    }

    public void CheckForLost()
    {
        if(lemmingsAlive.Count<=0)
            myMaster.LOST();
    }

}
