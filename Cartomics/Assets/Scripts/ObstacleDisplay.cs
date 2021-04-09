using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObstacleDisplay : MonoBehaviour, IPointerClickHandler
{
    public Obstacle myObstacle;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (myObstacle.functionWithTime == false)
        {
            if (myObstacle.canActive == true)
            {
                if (myObstacle.ON == true)
                {
                    StartCoroutine(myObstacle.TurnOffObstacle());
                }
                else if (myObstacle.ON == false)
                {
                    StartCoroutine(myObstacle.TurnOnObstacle());
                }
            }
        }
        else if (myObstacle.functionWithTime == true)
        {
            if (myObstacle.canActive == true)
            {
                StartCoroutine(myObstacle.TurnOffObstacleByTime());
            }

        }
    }
}
