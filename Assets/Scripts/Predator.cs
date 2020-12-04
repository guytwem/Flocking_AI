using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator : Life
{
    [SerializeField] protected CompositeBehavior wanderCompositeBehavior = null;
    [SerializeField] protected CompositeBehavior pursuitCompositeBehavior = null;
    [SerializeField] protected CompositeBehavior attackCompositeBehavior = null;

    private void Start()
    {
        NextState();
    }

    IEnumerator WanderState()
    {


        Debug.Log("Predator Wander Enter");
        
        while (state == State.Wander)
        {
            flock.behavior = wanderCompositeBehavior;

            changeState -= 1 * Time.deltaTime;

            if (changeState <= 0)
            {
                state = State.Pursuit;
                changeState = 5;
            }

            yield return null;
        }
        Debug.Log("Predator Wander Exit");
        NextState();

    }

    IEnumerator PursuitState()
    {


        Debug.Log("Predator Pursuit Enter");
        
        while (state == State.Pursuit)
        {
            flock.behavior = pursuitCompositeBehavior;

            changeState -= 1 * Time.deltaTime;

            if (changeState <= 0)
            {
                state = State.Attack;
                changeState = 5;
            }

            yield return null;
        }
        Debug.Log("Predator Pursuit Exit");
        NextState();

    }

    IEnumerator AttackState()
    {

        Debug.Log("Predator Attack Enter");
        
        while (state == State.Attack)
        {
            flock.behavior = attackCompositeBehavior;

            changeState -= 1 * Time.deltaTime;

            if (changeState <= 0)
            {
                state = State.Wander;
                changeState = 5;
            }



            yield return null;
        }
        Debug.Log("Predator Attack Exit");
        NextState();

    }


}
