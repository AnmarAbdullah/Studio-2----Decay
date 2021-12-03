using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public Chase chaseState;
    public bool canSeePlayer = false;
    StateManager distance;

    private void Start()
    {
        distance = GetComponentInParent<StateManager>();
        canSeePlayer = false;
    }

    public override State RunCurrentState()
    {
       /*if(canSeePlayer)
        {
            return chaseState;   
        }
        else
        {
            return this;
        }*/
        if (distance.dist < 25)
        {
            canSeePlayer = true;
            return chaseState;
        }
        else
        {
            return this;
        }
    }
}
