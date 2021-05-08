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

    //
    public float delayToGo;

    private void Start()
    {
        //BUSCAMOS AL GAMEMANAGER
        myMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void Update()
    {
    }

    public IEnumerator GoBoys()
    {
        if (myMaster.myGameStates == GameStates.GAME)
        {
            Debug.Log("GO BOYS");
            for (int i = 0; i <= lemmingsAlive.Count - 1; i++)
            {
                yield return new WaitForSeconds(delayToGo);
                lemmingsAlive[i].GoToTarget(goalPosition);
            }
        }

    }

}
