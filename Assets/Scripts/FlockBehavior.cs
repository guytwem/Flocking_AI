using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlockBehavior : ScriptableObject // can run the code without attaching it to a gameobject
{// abstract means that the class isnt finished and the code wont be used
    public abstract Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock);

}