using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public enum States
{
    PREP,
    GAME,
    END
}
public class Manager : MonoBehaviour
{
    [SerializeField] TMP_Text textTime; 
    [Range(1,100)]
    public int prepTime;
    int time;
    public States myState;
    // Start is called before the first frame update
    void Start()
    {
        myState = States.PREP;
        time = prepTime;
        if (myState == States.PREP)
            StartCoroutine(PrepTime());
    }
    
    IEnumerator PrepTime()
    {
        while(time > 0)
        {
            yield return new WaitForSeconds(1);
            time -= 1;
            textTime.text = time.ToString();
        }
        //yield return new WaitForSeconds(prepTime);

        Debug.Log("Game");
        myState = States.GAME;
    }


}
