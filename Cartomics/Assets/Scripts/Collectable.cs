using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Collectable : MonoBehaviour, IPointerClickHandler
{
    //ASIGNAMOS EL GAMEMANAGER
    private GameManager myGameManager;
    //ASIGNAMOS UN BOOL SI EL OBJETO YA FUE ACTIVADO
    private bool canFound = true;

    private void Start()
    {
        //BUSCAMOS EL GAMEMANAGER
        myGameManager = FindObjectOfType<GameManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(canFound==true)
        {
            canFound = false;
            myGameManager.foundCollectables += 1;
            gameObject.SetActive(false);
        }

    }

}
