using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventos : MonoBehaviour
{
    //ASIGNAMOS EL COMPONENTE LEMMING
    private Lemmings myVictim;

    private void OnTriggerEnter(Collider other)
    {
        //OBTENEMOS EL LEMMING  Y LO MATAMAMOS CON LA FUNCION DEAD Y DESCATIVAMOS EL COLLIDER PARA NO MATAR A OTROS LEMMINGS
        if (other.GetComponent<Lemmings>())
        {
            Debug.Log("Perdiste un Lemming :C");
            myVictim = other.GetComponent<Lemmings>();
            myVictim.Dead();
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
