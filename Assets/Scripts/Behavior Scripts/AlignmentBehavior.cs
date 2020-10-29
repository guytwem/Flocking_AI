﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
public class AlignmentBehavior : FilteredFlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
        {
            //maintain same direction
            return agent.transform.up;
        }

        //add all points together and average
        Vector2 alignmentMove = Vector2.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        int count = 0;
        foreach (Transform item in filteredContext)
        {
            if (Vector2.SqrMagnitude(item.position - agent.transform.position) <= flock.SquareSmallRadius)
            {
                alignmentMove += (Vector2)item.transform.up;
                count++;
            }

        }
        if(count != 0)
        {
            alignmentMove /= count;
        }
        

        return alignmentMove;
    }
}
