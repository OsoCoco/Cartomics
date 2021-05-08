using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GameStates
{
    //ESTADOS DEL JUEGO
    PREP,
    GAME,
    WIN,
    LOST
}

public class GameManager : MonoBehaviour
{
    //ASIGNAMOS EL TMPRO
    [SerializeField] TMP_Text textTime;

    //ASIGANOS EL TIEMPO DE PREPARACION Y VARIABLE DEL TIEMPO ACTUAL
    [Range(1, 100)]
    public int prepTime;
    int time;

    //ASIGNAMOS NUESTROS ESTADOS
    public GameStates myGameStates;

    //ASIGNAMOS AL MASTERLEMMING
    private MasterLemming myBoy;

    private void Start()
    {
        //BUSCAMOS AL MASTERLEMMING
        myBoy = FindObjectOfType<MasterLemming>();

        //INICIALIZAMOS ESTADO "PREP" Y LA FASE DE PREPARACION
        myGameStates = GameStates.PREP;
        time = prepTime;
        if (myGameStates == GameStates.PREP)
        {
            StartCoroutine(PrepPhase());
        }

    }

    //CORRUTINA O CREACION DE LA FASE DE PREPARACION
    private IEnumerator PrepPhase()
    {
        //RESTAMOS EL TIEMPO DE ESPERA HASTA LA SIQUIENTE FASE
        while (time > 0)
        {
            yield return new WaitForSeconds(1.0f);
            time -= 1;
            textTime.text = time.ToString();
        }

        //INICIALIZAMOS EL ESTADO "GAME"
        Debug.Log("ESTATE GAME");
        myGameStates = GameStates.GAME;
        StartCoroutine(MainPhase());
        
    }

    private IEnumerator MainPhase()
    {
        Debug.Log("MAIN PHASE");
        StartCoroutine(myBoy.GoBoys());
        yield return null;
    }

}
