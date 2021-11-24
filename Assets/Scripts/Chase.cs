using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : State
{
    public Attack attackState;
    public bool isInAttackRange;
    StateManager distance;

    private void Start()
    {
        distance = GetComponentInParent<StateManager>();
    }
    public override State RunCurrentState()
    {
        transform.LookAt(distance.player);
        if (distance.dist <= 2)
        {
            isInAttackRange = true;
            return attackState;
        }
        else //if (distance.dist >= 2.5f)
        {
            return this;
        }


        //do running animation
    }
}
