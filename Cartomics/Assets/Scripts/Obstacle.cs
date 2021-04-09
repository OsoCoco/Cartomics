using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Obstacle", menuName ="Obstacle")]
public class Obstacle : ScriptableObject
{
    public Animator obsAnimator;
    public string turnOnAction, turnOffAction;
    public bool functionWithTime = false;
    public bool ON = true;
    public bool canActive = true;

    [SerializeField]
    private float delayForUse = 3.0f;
    [SerializeField]
    private float waitForActive = 1.5f;

    public IEnumerator TurnOffObstacle()
    {
        ON = false;
        canActive = false;
        obsAnimator.SetTrigger(turnOffAction);
        yield return new WaitForSeconds(delayForUse);
        canActive = true;
    }

    public IEnumerator TurnOnObstacle()
    {
        ON = true;
        canActive = false;
        obsAnimator.SetTrigger(turnOnAction);
        yield return new WaitForSeconds(delayForUse);
        canActive = true;
    }

    public IEnumerator TurnOffObstacleByTime()
    {
        ON = false;
        canActive = false;
        obsAnimator.SetTrigger(turnOffAction);
        yield return new WaitForSeconds(delayForUse);
        ON = true;
        obsAnimator.SetTrigger(turnOnAction);
        yield return new WaitForSeconds(waitForActive);
        canActive = true;
    }

}
