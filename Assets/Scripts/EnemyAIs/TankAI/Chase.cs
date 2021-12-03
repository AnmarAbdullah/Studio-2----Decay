using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : State
{
    public Attack attackState;
    public bool isInAttackRange;
    StateManager statemanager;

    private void Start()
    {
        statemanager = GetComponentInParent<StateManager>();
    }
    public override State RunCurrentState()
    {
        transform.LookAt(statemanager.player);
        transform.Translate(Vector3.forward * 15 * Time.deltaTime);
        if (statemanager.dist <= 2)
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
