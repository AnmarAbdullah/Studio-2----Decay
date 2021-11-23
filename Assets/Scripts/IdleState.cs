using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public bool canSeePlayer;
    public ChaseState chase;
    public override State RunCurrentState()
    {
        if(canSeePlayer)
        {
            return chase;
        }
        else
        {
            return this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
