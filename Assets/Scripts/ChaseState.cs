using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public AttackState attack;
    public bool isInAttackRange;
    public override State RunCurrentState()
    {
        if (isInAttackRange)
        {
            return attack;
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
