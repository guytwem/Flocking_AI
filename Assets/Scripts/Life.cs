using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Wander,
    Flee,
    Hide,
    Pursuit,
    Attack

}

public abstract class Life : MonoBehaviour
{
    

    public State state;

    public Flock flock;

    public float changeState = 5;

   

    private void Start()
    {
        flock = Flock.instance;
        
      
        
    }

    protected void NextState()
    {
        // work out the name of the method we want to run
        string methodName = state.ToString() + "State"; //if our current state is walk then this will return "walkState" 
        //give us a variable so we run a method using it's name
        System.Reflection.MethodInfo info =
            GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        //run our method 
        StartCoroutine((IEnumerator)info.Invoke(this, null));
        //using StartCoroutine means we can leave and come back to the method that is running
        //All Coroutines must return IEnumerator
    }
}
