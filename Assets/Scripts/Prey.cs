using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Prey : Life
{
    [SerializeField] protected CompositeBehavior preyWanderCompositeBehavior = null;
    [SerializeField] protected CompositeBehavior preyFleeCompositeBehavior = null;
    [SerializeField] protected CompositeBehavior preyHideCompositeBehavior = null;

    private void Start()
    {
        NextState();
    }



    IEnumerator WanderState()
    {


        Debug.Log("Prey Wander Enter");
        //flock.behavior = wanderCompositeBehavior;
        while (state == State.Wander)
        {
            flock.behavior = preyWanderCompositeBehavior;

            changeState -= 1 * Time.deltaTime;

            if (changeState <= 0)
            {
                state = State.Flee;
                changeState = 5;
            }



            yield return 0;
        }
        Debug.Log("Prey Wander Exit");

        NextState();

    }



    IEnumerator FleeState()
    {



        Debug.Log("Prey Flee Enter");
        flock.behavior = preyFleeCompositeBehavior;
        while (state == State.Flee)
        {
            flock.behavior = preyFleeCompositeBehavior;


            changeState -= 1 * Time.deltaTime;

            if (changeState <= 0)
            {
                state = State.Hide;
                changeState = 5;
            }
            else
            {
                state = State.Flee;
            }

            yield return null;
        }
        Debug.Log("Prey Flee Exit");
        NextState();

    }

    IEnumerator HideState()
    {

        Debug.Log("Prey Hide Enter");
        flock.behavior = preyHideCompositeBehavior;
        while (state == State.Hide)
        {
            flock.behavior = preyHideCompositeBehavior;

            changeState -= 1 * Time.deltaTime;

            if (changeState <= 0)
            {
                state = State.Wander;
                changeState = 5;
            }

            

            yield return null;
        }
        Debug.Log("Prey Hide Exit");
        NextState();

    }

  
}
